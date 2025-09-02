namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandNPopX : QuickJsOperand
    {

        public readonly int Value;

        public QuickJsOperandNPopX(int num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_npopx;
            Value = num;
        }

        public override string GetString()
        {
            return Value.ToString();
        }

    }
}
