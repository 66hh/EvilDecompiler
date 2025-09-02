namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandConst : QuickJsOperand
    {

        public uint Value;

        public List<JsObject.Types.Objects.JsObject> CPool;

        public QuickJsOperandConst(uint num, List<JsObject.Types.Objects.JsObject> cPool)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_const;
            Value = num;
            CPool = cPool;
        }

        public override string GetString()
        {
            return Value.ToString() + ": " + CPool[(int)Value].ToString();
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

    }
}
