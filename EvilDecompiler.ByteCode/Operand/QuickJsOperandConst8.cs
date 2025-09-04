namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandConst8 : QuickJsOperand
    {

        public byte ConstIndex;

        public JsObject.Types.Objects.JsObject ConstValue;

        public QuickJsOperandConst8(byte constIndex, List<JsObject.Types.Objects.JsObject> cPool)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_const8;
            ConstIndex = constIndex;
            ConstValue = cPool[ConstIndex];
        }

        public override string GetString()
        {
            return ConstIndex.ToString() + ": " + ConstValue.ToString();
        }

        public override byte[] GetBytes()
        {
            return [ConstIndex];
        }

    }
}
