using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;
using EvilDecompiler.JsObject.Utils;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandAtomU16 : QuickJsOperand
    {

        public uint AtomIndex;

        public JsString? AtomValue;

        public ushort U16;

        public QuickJsOperandAtomU16(uint atomIndex, ushort u16, AtomSet atoms)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_atom_u16;
            AtomIndex = atomIndex;
            AtomValue = atoms.Get((int)AtomIndex & ~(1 << 31));
            U16 = u16;
        }

        public override string GetString()
        {
            if (AtomValue == null)
            {
                return "[atom: " + AtomIndex.ToString() + "], " + U16.ToString();
            }
            else
            {
                return "\"" + AtomValue.Value + "\", " + U16.ToString();
            }
        }

        public override byte[] GetBytes()
        {
            return ByteUtils.Combine(BitConverter.GetBytes(AtomIndex), BitConverter.GetBytes(U16));
        }

    }
}
