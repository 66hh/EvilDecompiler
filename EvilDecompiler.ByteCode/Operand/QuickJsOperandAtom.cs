using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandAtom : QuickJsOperand
    {

        public uint Value;

        public AtomSet Atoms;

        public QuickJsOperandAtom(uint num, AtomSet atoms)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_u32;
            Value = num;
            Atoms = atoms;
        }

        public override string GetString()
        {

            JsString? str = Atoms.Get((int)Value);

            if (str == null)
            {
                return "[atom: " + Value.ToString() + "]";
            }
            else
            {
                return "\"" + str.Value + "\"";
            }
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

    }
}
