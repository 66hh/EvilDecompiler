using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;
using EvilDecompiler.JsObject.Utils;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandAtomLabelU16 : QuickJsOperand
    {

        public uint Value;

        public uint Label;

        public ushort U16;

        public AtomSet Atoms;

        public QuickJsOperandAtomLabelU16(uint num, uint label, ushort u16, AtomSet atoms)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_atom_label_u16;
            Value = num;
            Label = label;
            U16 = u16;
            Atoms = atoms;
        }

        public override string GetString()
        {

            JsString? str = Atoms.Get((int)Value);

            if (str == null)
            {
                return "[atom: " + Value.ToString() + "], " + Label.ToString() + ", " + U16.ToString();
            }
            else
            {
                return "\"" + str.Value + "\", " + Label.ToString() + ", " + U16.ToString();
            }
        }

        public override byte[] GetBytes()
        {
            return ByteUtils.Combine(BitConverter.GetBytes(Value), ByteUtils.Combine(BitConverter.GetBytes(Label), BitConverter.GetBytes(U16)));
        }

    }
}
