using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;
using EvilDecompiler.JsObject.Utils;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandAtomU8 : QuickJsOperand
    {

        public uint Value;

        public uint U8;

        public AtomSet Atoms;

        public QuickJsOperandAtomU8(uint num, byte u8, AtomSet atoms)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_atom_u8;
            Value = num;
            U8 = u8;
            Atoms = atoms;
        }

        public override string GetString()
        {

            JsString? str = Atoms.Get((int)Value);

            if (str == null)
            {
                return "[atom: " + Value.ToString() + "], " + U8.ToString();
            }
            else
            {
                return "\"" + str.Value + "\", " + U8.ToString();
            }
        }

        public override byte[] GetBytes()
        {
            return ByteUtils.Combine(BitConverter.GetBytes(Value), BitConverter.GetBytes(U8));
        }

    }
}
