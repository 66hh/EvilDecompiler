namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandI8 : QuickJsOperand
    {

        public sbyte Value;

        public QuickJsOperandI8(sbyte num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_i8;
            Value = num;
        }

        public override string GetString()
        {
            return Value.ToString();
        }

        public override byte[] GetBytes()
        {
            return [(byte)Value];
        }

    }
}
