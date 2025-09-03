namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandNoneArg : QuickJsOperand
    {

        public readonly int Value;

        public QuickJsOperandNoneArg(int num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_none_arg;
            Value = num;
        }

        public override string GetString()
        {
            return Value.ToString();
        }

    }
}
