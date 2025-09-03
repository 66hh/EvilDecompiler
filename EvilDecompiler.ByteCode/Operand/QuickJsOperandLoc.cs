namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandLoc : QuickJsOperand
    {

        public ushort Value;

        public QuickJsOperandLoc(ushort num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_loc;
            Value = num;
        }

        public override string GetString()
        {
            return Value.ToString();
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

    }
}
