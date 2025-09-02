using EvilDecompiler.ByteCode.Operand;
using EvilDecompiler.ByteCode.Type;
using EvilDecompiler.JsObject.Types.Objects;


namespace EvilDecompiler.ByteCode.Instruction
{

    public class QuickJsInstruction : IQuickJsInstruction
    {

        private int pc;
        private QuickJsOPCode opCode;
        private IQuickJsOperand[] operandObjects;

        public QuickJsInstruction(int pc, QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod)
        {
            this.pc = pc;
            this.opCode = opCode;
            operandObjects = parseOperandByFormat(opCode, operand, quickJsMethod);
        }

        public QuickJsOPCodeFormat getFormat()
        {
            return opCode.Format;
        }

        public QuickJsOPCode getOpCode()
        {
            return opCode;
        }

        public IQuickJsOperand[] getParams()
        {
            return operandObjects;
        }

        public int getPC()
        {
            return pc;
        }

        private IQuickJsOperand[] parseOperandByFormat(QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod)
        {

            List<IQuickJsOperand> list = new List<IQuickJsOperand>();

            switch (getFormat())
            {

            }

            return list.ToArray();
        }
    }

}
