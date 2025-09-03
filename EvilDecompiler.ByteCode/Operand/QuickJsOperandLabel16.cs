namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandLabel16 : QuickJsOperand
    {

        public short Value;

        public QuickJsOperandLabel16(short num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_label16;
            Value = num;
        }

        public override string GetString()
        {
            string addr = Value < 0 ? Value.ToString() : "+" + Value.ToString();
            return "[pc: $" + addr + "]";
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

    }
}
