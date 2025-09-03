namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandLabel : QuickJsOperand
    {

        public uint Value;

        public QuickJsOperandLabel(uint num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_label;
            Value = num;
        }

        public override string GetString()
        {
            return "[pc: " + Value.ToString() + "]";
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

    }
}
