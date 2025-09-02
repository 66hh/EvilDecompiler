using EvilDecompiler.JsObject.Utils;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandNPopU16 : QuickJsOperand
    {

        public ushort NPop;

        public ushort Value;

        public QuickJsOperandNPopU16(ushort nPop, ushort num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_npop_u16;
            NPop = nPop;
            Value = num;
        }

        public override string GetString()
        {
            return NPop.ToString() + "," + Value.ToString();
        }

        public override byte[] GetBytes()
        {
            return ByteUtils.Combine(BitConverter.GetBytes(NPop), BitConverter.GetBytes(Value));
        }

    }
}
