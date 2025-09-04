using EvilDecompiler.ByteCode.Operand;
using EvilDecompiler.ByteCode.Type;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler.ByteCode.Instruction
{
    public class QuickJsInstructionCall : QuickJsInstruction
    {

        public int ExtPopCount;

        public bool HasResult;

        public QuickJsInstructionCall(long pc, QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod, AtomSet atoms) : base(pc, opCode, operand, quickJsMethod, atoms)
        {

            QuickJsOperandNPop? pop = operandObjects as QuickJsOperandNPop;
            if (pop != null)
                ExtPopCount = pop.NPop;

            if (opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_call_method)
                HasResult = true;
            else
                HasResult = false;

        }
    }
}
