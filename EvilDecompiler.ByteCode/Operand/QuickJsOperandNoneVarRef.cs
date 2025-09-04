namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandNoneVarRef : QuickJsOperand
    {

        public readonly int RefIndex;

        public QuickJsOperandNoneVarRef(int refIndex)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_none_var_ref;
            RefIndex = refIndex;
        }

        public override string GetString()
        {
            return RefIndex.ToString();
        }

    }
}
