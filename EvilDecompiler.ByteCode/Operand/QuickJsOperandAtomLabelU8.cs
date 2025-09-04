using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;
using EvilDecompiler.JsObject.Utils;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandAtomLabelU8 : QuickJsOperand
    {

        public AtomIdx AtomIndex;

        public JsString? AtomValue;

        public uint Label;

        public byte U8;

        public QuickJsOperandAtomLabelU8(uint atomIndex, uint label, byte u8, AtomSet atoms)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_atom_label_u8;
            AtomIndex = new AtomIdx((int)atomIndex);
            AtomValue = atoms.Get(AtomIndex.Value);
            Label = label;
            U8 = u8;
        }

        public override string GetString()
        {
            string addr = Label < 0 ? Label.ToString() : "+" + Label.ToString();

            if (AtomValue == null)
            {
                return "[atom: " + AtomIndex.ToString() + "], [pc: $" + addr + "], " + U8.ToString();
            }
            else
            {
                return "\"" + AtomValue.Value + "\",  [pc: $" + addr + "], " + U8.ToString();
            }
        }

        public override byte[] GetBytes()
        {
            return ByteUtils.Combine(BitConverter.GetBytes(AtomIndex.Flag), ByteUtils.Combine(BitConverter.GetBytes(Label), [U8]));
        }

    }
}
