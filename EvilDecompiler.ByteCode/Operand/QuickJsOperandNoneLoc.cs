namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandNoneLoc : QuickJsOperand
    {

        public readonly int Value;

        public QuickJsOperandNoneLoc(int num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_none_loc;
            Value = num;
        }

        public override string GetString()
        {
            return Value.ToString();
        }

    }
}
