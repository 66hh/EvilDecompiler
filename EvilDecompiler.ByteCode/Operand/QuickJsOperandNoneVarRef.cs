namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandNoneVarRef : QuickJsOperand
    {

        public readonly int Value;

        public QuickJsOperandNoneVarRef(int num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_none_int;
            Value = num;
        }

        public override string GetString()
        {
            return Value.ToString();
        }

    }
}
