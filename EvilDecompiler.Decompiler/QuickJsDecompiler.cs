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

        private void BuildLocalVarDefine(ref StringBuilder builder)
        {
            builder.Append("    let ");
            for (int i = 0; i < function.VarCount; i++)
            {
                if (i > 0)
                    builder.Append(", loc" + i.ToString());
                else
                    builder.Append("loc" + i.ToString());
            }
            builder.Append(";");
        }

        private void BuildFunctionDefine(ref StringBuilder builder)
        {
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

        public string Decompile()
        {

            StringBuilder builder = new StringBuilder();

            BuildFunctionDefine(ref builder);
            
            builder.Append("\n{\n");

            BuildLocalVarDefine(ref builder);

            for (int i = 0; i < ins.Length; i++)
            {

                QuickJsInstruction curIns = ins[i];



            }

            builder.Append("\n}\n");

            return builder.ToString();
        }

    }
}
