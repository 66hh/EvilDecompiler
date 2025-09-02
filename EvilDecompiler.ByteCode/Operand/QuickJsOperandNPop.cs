namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandNPop : QuickJsOperand
    {

        public ushort Value;

        public QuickJsOperandNPop(ushort num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_npop;
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
