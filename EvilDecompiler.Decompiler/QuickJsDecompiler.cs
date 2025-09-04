using EvilDecompiler.ByteCode;
using EvilDecompiler.ByteCode.Instruction;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;
using System.Text;

namespace EvilDecompiler.Decompiler
{
    public class QuickJsDecompiler
    {
        protected AtomSet atomSet;

        protected JsFunctionBytecode function;

        protected QuickJsInstruction[] ins;

        public QuickJsDecompiler(JsFunctionBytecode func, AtomSet atoms)
        {
            QuickJsDisAssembler disasm = new QuickJsDisAssembler(new MemoryStream(func.Bytecode), func, atoms);
            ins = disasm.ReadAllInstructions();
            function =  func;
            atomSet = atoms;
        }

        private void BuildLocalVarDefine(ref StringBuilder builder, int padding)
        {

            if (function.VarCount == 0)
                return;

            builder.Append(new string(' ', padding * 4));

            builder.Append("let ");
            for (int i = 0; i < function.VarCount; i++)
            {
                if (i > 0)
                    builder.Append(", loc" + i.ToString());
                else
                    builder.Append("loc" + i.ToString());
            }
            builder.Append(";");
        }

        private void BuildFunctionDefine(ref StringBuilder builder, int padding)
        {
            builder.Append(new string(' ', padding * 4));

            builder.Append("function ");

            string funcName = "sub_" + function.GetHashCode().ToString();

            JsString? atomString = atomSet.Get(function.FunctionName.Value);

            if (atomString != null)
            {
                funcName = atomString.Value;
            }

            builder.Append(funcName);

            builder.Append("(");

            for (int i = 0; i < function.ArgCount; i++)
            {
                if (i > 0)
                    builder.Append(", arg" + i.ToString());
                else
                    builder.Append("arg" + i.ToString());
            }

            builder.Append(")");
        }

        public string Decompile(int padding = 0)
        {

            StringBuilder builder = new StringBuilder();

            BuildFunctionDefine(ref builder, padding);

            builder.Append('\n');
            builder.Append(new string(' ', padding * 4));
            builder.Append("{\n");

            padding++;

            BuildLocalVarDefine(ref builder, padding);

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < ins.Length; i++)
            {

                QuickJsInstruction curIns = ins[i];

                if (curIns is QuickJsInstructionGetVar getVar)
                {
                    stack.Push(getVar.Value);
                }
                else if (curIns is QuickJsInstructionGetProperty getProperty)
                {
                    // 判断是否要在栈中保留原始变量

                    string origin;

                    if (getProperty.PushOrigin)
                    {
                        origin = stack.Peek();
                    }
                    else
                    {
                        origin = stack.Pop();
                    }
                    stack.Push(origin + "[" + getProperty.Value + "]");
                }
                else if (curIns is QuickJsInstructionPushValue pushValue)
                {
                    stack.Push(pushValue.Value);
                }
                else if (curIns is QuickJsInstructionClosure closure)
                {
                    if (closure.Function != null)
                    {
                        try
                        {
                            QuickJsDecompiler closureDecompiler = new QuickJsDecompiler(closure.Function, atomSet);
                            builder.Append('\n');
                            builder.Append(closureDecompiler.Decompile(padding));
                            stack.Push("sub_" + closure.Function.GetHashCode().ToString());
                        }
                        catch(Exception e)
                        {
                            builder.Append("\n // " + e.ToString());
                            stack.Push("sub_" + closure.Function.GetHashCode().ToString());
                        }

                    }
                    else
                    {
                        stack.Push("null");
                    }
                        
                }
                else if (curIns is QuickJsInstructionSetVar setVar)
                {
                    string expression = stack.Pop();
                    builder.Append('\n');
                    builder.Append(new string(' ', padding * 4));

                    if (setVar.GlobalVar)
                        builder.Append("Global[" + setVar.Value + "] = " + expression + ";");
                    else
                        builder.Append(setVar.Value + " = " + expression + ";");

                    if (setVar.PopNewValue)
                        if (setVar.GlobalVar)
                            stack.Push("Global[" + setVar.Value + "]");
                        else
                            stack.Push(setVar.Value);
                }
                else if (curIns is QuickJsInstructionDup dup)
                {
                    string value = stack.Peek();
                    for (int j = 0; j < dup.DupCount; j++)
                    {
                        stack.Push(value);
                    }
                }
                else if (curIns is QuickJsInstructionPop pop)
                {
                    stack.Pop();
                }
                else
                {
                    builder.Append('\n');

                    for (int j = 0; j < curIns.getOpCode().PopCount; j++)
                    {
                        builder.Append('\n');
                        builder.Append(new string(' ', padding * 4));
                        builder.Append("// stack " + j.ToString() + " total " + (stack.Count() - 1).ToString() + ": " + stack.Pop());
                    }

                    for (int j = 0; j < curIns.getOpCode().PushCount; j++)
                    {
                        stack.Push("UnsupportedValue");
                    }

                    builder.Append('\n');
                    builder.Append(new string(' ', padding * 4));
                    builder.Append("// Unsupported Instruction: " + curIns.ToString());
                    builder.Append('\n');

                }

                Console.WriteLine("stack: " + stack.Count.ToString());

            }

            builder.Append('\n');
            builder.Append(new string(' ', padding * 4));
            builder.Append("}\n");

            return builder.ToString();
        }

    }
}
