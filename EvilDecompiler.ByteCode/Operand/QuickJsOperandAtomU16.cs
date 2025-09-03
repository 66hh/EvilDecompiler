using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;
using EvilDecompiler.JsObject.Utils;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandAtomU16 : QuickJsOperand
    {

        public uint Value;

        public ushort U16;

        public AtomSet Atoms;

        public QuickJsOperandAtomU16(uint num, ushort u16, AtomSet atoms)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_atom_u16;
            Value = num;
            U16 = u16;
            Atoms = atoms;
        }

        public override string GetString()
        {

            JsString? str = Atoms.Get((int)Value);

            if (str == null)
            {
                return "[atom: " + Value.ToString() + "], " + U16.ToString();
            }
            else
            {
                return "\"" + str.Value + "\", " + U16.ToString();
            }
        }

        public override byte[] GetBytes()
        {
            return ByteUtils.Combine(BitConverter.GetBytes(Value), BitConverter.GetBytes(U16));
        }

    }
}
