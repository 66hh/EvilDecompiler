using EvilDecompiler.ByteCode.Type;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler.ByteCode.Instruction
{
    public class QuickJsInstructionThrow : QuickJsInstruction
    {

        public bool NoArg;

        public QuickJsInstructionThrow(long pc, QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod, AtomSet atoms) : base(pc, opCode, operand, quickJsMethod, atoms)
        {

            if (opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_throw_error)
                NoArg = true;
            else
                NoArg = false;

        }
    }
}
