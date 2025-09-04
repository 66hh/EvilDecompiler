using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandAtom : QuickJsOperand
    {

        public uint AtomIndex;

        public JsString? AtomValue;

        public QuickJsOperandAtom(uint atomIndex, AtomSet atoms)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_atom;
            AtomIndex = atomIndex;
            AtomValue = atoms.Get((int)atomIndex);
        }

        public override string GetString()
        {
            if (AtomValue == null)
            {
                return "[atom: " + AtomIndex.ToString() + "]";
            }
            else
            {
                return "\"" + AtomValue.Value + "\"";
            }
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(AtomIndex);
        }

    }
}
