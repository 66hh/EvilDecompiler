namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandArg : QuickJsOperand
    {

        public ushort Value;

        public QuickJsOperandArg(ushort num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_arg;
            Value = num;
        }

        public override string GetString()
        {
            return "arg" + Value.ToString();
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

    }
}
