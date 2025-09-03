namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandLoc8 : QuickJsOperand
    {

        public byte Value;

        public QuickJsOperandLoc8(byte num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_loc8;
            Value = num;
        }

        public override string GetString()
        {
            return Value.ToString();
        }

        public override byte[] GetBytes()
        {
            return [Value];
        }

    }
}
