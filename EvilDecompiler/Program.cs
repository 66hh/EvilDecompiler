using EvilDecompiler.ByteCode;
using EvilDecompiler.ByteCode.Instruction;
using EvilDecompiler.Decompiler;
using EvilDecompiler.JsObject;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsObjectReader reader = new JsObjectReader(new MemoryStream(File.ReadAllBytes("../../../../verify.jsc")));
            JsModule? module = reader.JsObject as JsModule;
            AtomSet? atoms = reader.Atoms;

            if (module != null && atoms != null)
            {
                JsFunctionBytecode? func = module.FunctionObject as JsFunctionBytecode;
                if (func != null)
                {
                    JsFunctionBytecode func2 = (JsFunctionBytecode)((JsFunctionBytecode)func.CPool[0]).CPool[0];
                    QuickJsDisAssembler disasm = new QuickJsDisAssembler(new MemoryStream(func2.Bytecode), func2, atoms);
                    QuickJsInstruction[] ins = disasm.ReadAllInstructions();

                    QuickJsDecompiler dec = new QuickJsDecompiler(func, atoms);

                    string output = dec.Decompile();

                    Console.WriteLine(output);

                    File.WriteAllText(@"../../../../verify.js", output);

                    Stack<string> stack = new Stack<string>();

                    int stack_count = 0;

                    for (int i = 0; i < ins.Length; i++)
                    {
                    
                        QuickJsInstruction qjsins = ins[i];

                        int pop = qjsins.getOpCode().PopCount;
                        int push = qjsins.getOpCode().PushCount;

                        stack_count -= pop;
                        stack_count += push;

                        for (int j = 0; j < pop; j++)
                        {
                            //Console.WriteLine(stack.Pop());
                        }

                        for (int j = 0; j < push; j++)
                        {
                            // todo
                            if (qjsins.getOpCode().Name == "add")
                            {
                                stack.Push("+");
                                break;
                            }

                            stack.Push(qjsins.getOperand().ToString());
                        }


                        //Console.WriteLine(ins[i].ToString());
                        //Console.WriteLine(stack_count.ToString());

                        QuickJsInstructionPushValue? pv = qjsins as QuickJsInstructionPushValue;
                        if (pv != null)
                        {
                            //Console.WriteLine("Push Value: " + pv.Value);
                        }

                        QuickJsInstructionGetVar? gv = qjsins as QuickJsInstructionGetVar;
                        if (gv != null)
                        {
                            //Console.WriteLine("Get Var: " + gv.Value);
                        }

                    }

                    byte[] data = new byte[func2.Bytecode.Length];
                    QuickJsAssembler asm = new QuickJsAssembler(new MemoryStream(data));
                    asm.WriteAllInstructions(ins);

                    //Console.WriteLine(BitConverter.ToString(func2.Bytecode).Replace("-", ""));
                    //Console.WriteLine(BitConverter.ToString(data).Replace("-", ""));
                }
            }

        }
    }
}
