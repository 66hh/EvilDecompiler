namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandConst8 : QuickJsOperand
    {

        public byte Value;

        public List<JsObject.Types.Objects.JsObject> CPool;

        public QuickJsOperandConst8(byte num, List<JsObject.Types.Objects.JsObject> cPool)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_const8;
            Value = num;
            CPool = cPool;
        }

        public override string GetString()
        {
            return Value.ToString() + ": " + CPool[Value].ToString();
        }

        public override byte[] GetBytes()
        {
            return [Value];
        }

    }
}
