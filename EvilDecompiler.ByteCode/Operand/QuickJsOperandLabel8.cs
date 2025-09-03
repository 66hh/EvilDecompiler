namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandLabel8 : QuickJsOperand
    {

        public sbyte Value;

        public QuickJsOperandLabel8(sbyte num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_label8;
            Value = num;
        }

        public override string GetString()
        {
            return "[pc: " + Value.ToString() + "]";
        }

        public override byte[] GetBytes()
        {
            return [(byte)Value];
        }

    }
}
