using EvilDecompiler.ByteCode;
using EvilDecompiler.ByteCode.Instruction;
using EvilDecompiler.JsObject;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsObjectReader reader = new JsObjectReader(new MemoryStream(File.ReadAllBytes("../../../../Test.jsc")));
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
                    for (int i = 0; i < ins.Length; i++)
                    {
                        Console.WriteLine(ins[i].ToString());
                    }
                }
            }

        }
    }
}
