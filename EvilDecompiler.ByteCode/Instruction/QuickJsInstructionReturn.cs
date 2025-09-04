using EvilDecompiler.ByteCode.Type;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler.ByteCode.Instruction
{
    public class QuickJsInstructionReturn : QuickJsInstruction
    {

        public bool HasValue;

        public QuickJsInstructionReturn(long pc, QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod, AtomSet atoms) : base(pc, opCode, operand, quickJsMethod, atoms)
        {

            if (opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_return ||
                opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_return_async)
                HasValue = true;
            else
                HasValue = false;

        }
    }
}
