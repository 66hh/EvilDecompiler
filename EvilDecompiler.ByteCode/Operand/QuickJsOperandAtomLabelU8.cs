using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;
using EvilDecompiler.JsObject.Utils;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandAtomLabelU8 : QuickJsOperand
    {

        public uint Value;

        public uint Label;

        public byte U8;

        public AtomSet Atoms;

        public QuickJsOperandAtomLabelU8(uint num, uint label, byte u8, AtomSet atoms)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_atom_label_u8;
            Value = num;
            Label = label;
            U8 = u8;
            Atoms = atoms;
        }

        public override string GetString()
        {

            JsString? str = Atoms.Get((int)Value);

            if (str == null)
            {
                return "[atom: " + Value.ToString() + "], [pc: " + Label.ToString() + "], " + U8.ToString();
            }
            else
            {
                return "\"" + str.Value + "\",  [pc: " + Label.ToString() + "], " + U8.ToString();
            }
        }

        public override byte[] GetBytes()
        {
            return ByteUtils.Combine(BitConverter.GetBytes(Value), ByteUtils.Combine(BitConverter.GetBytes(Label), [U8]));
        }

    }
}
