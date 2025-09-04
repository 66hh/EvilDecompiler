using EvilDecompiler.ByteCode.Type;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler.ByteCode.Instruction
{
    public class QuickJsInstructionDup : QuickJsInstruction
    {

        public int DupCount;

        public QuickJsInstructionDup(long pc, QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod, AtomSet atoms) : base(pc, opCode, operand, quickJsMethod, atoms)
        {

            DupCount = opCode.OPCode - QuickJsOPCode.OPCodeValue.OP_dup + 1;

        }
    }
}
