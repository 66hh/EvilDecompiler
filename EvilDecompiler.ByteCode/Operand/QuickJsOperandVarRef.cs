namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandVarRef : QuickJsOperand
    {

        public ushort Value;

        public QuickJsOperandVarRef(ushort num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_var_ref;
            Value = num;
        }

        public override string GetString()
        {
            return "var_ref" + Value.ToString();
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

    }
}
