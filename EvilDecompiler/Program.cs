using EvilDecompiler.ByteCode;
using EvilDecompiler.ByteCode.Instruction;
using EvilDecompiler.Decompiler;
using EvilDecompiler.JsObject;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler
{
    internal class Program
    {

        static void Disassemble(string path)
        {
            JsObjectReader jsObjectReader = new JsObjectReader(new MemoryStream(File.ReadAllBytes(path)));
            JsModule? module = (JsModule?)jsObjectReader.JsObject;

            if (module == null || jsObjectReader.Atoms == null)
            {
                Console.WriteLine("Internal Error!");
                return;
            }

            JsFunctionBytecode functionBytecode = (JsFunctionBytecode)module.FunctionObject;

            QuickJsDisAssembler disAssembler = new QuickJsDisAssembler(new MemoryStream(functionBytecode.Bytecode), functionBytecode, jsObjectReader.Atoms);

            QuickJsInstruction[] ins = disAssembler.ReadAllInstructions();

            string result = "";

            for (int i = 0; i < ins.Length; i++)
            {
                result += ins[i].ToString() + "\n";
            }

            Console.WriteLine(result);

            File.WriteAllText(Path.ChangeExtension(path, null) + ".txt", result);
        }

        static void Decompile(string path, bool detail)
        {
            JsObjectReader jsObjectReader = new JsObjectReader(new MemoryStream(File.ReadAllBytes(path)));
            JsModule? module = (JsModule?)jsObjectReader.JsObject;

            if (module == null || jsObjectReader.Atoms == null)
            {
                Console.WriteLine("Internal Error!");
                return;
            }

            JsFunctionBytecode functionBytecode = (JsFunctionBytecode)module.FunctionObject;

            QuickJsDecompiler decompiler = new QuickJsDecompiler(functionBytecode, jsObjectReader.Atoms);

            string result = decompiler.Decompile(detail);

            Console.WriteLine(result);

            File.WriteAllText(Path.ChangeExtension(path, null) + ".js", result);
        }

        static void PrintUsages()
        {
            Console.WriteLine("EvilDecompiler.exe <all|disassemble|decompile|decompile-detail> [jsc file]");
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                PrintUsages();
                return;
            }

            if (!File.Exists(args[1]))
            {
                Console.WriteLine("File " + args[1] + " does not exist!");
                return;
            }

            switch (args[0])
            {
                case "all":
                    Disassemble(args[1]);
                    Decompile(args[1], true);
                    break;
                case "disassemble":
                    Disassemble(args[1]);
                    break;
                case "decompile":
                    Decompile(args[1], false);
                    break;
                case "decompile-detail":
                    Decompile(args[1], true);
                    break;

                default:
                    PrintUsages();
                    return;
            }
        }
    }
}
