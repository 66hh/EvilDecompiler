using EvilDecompiler.ByteCode.Operand;
using EvilDecompiler.ByteCode.Type;

namespace EvilDecompiler.ByteCode.Instruction
{

    public interface IQuickJsInstruction
    {
        int getPC();

        QuickJsOPCode getOpCode();

        QuickJsOPCodeFormat getFormat();

        QuickJsOperand[] getParams();
    }

}
