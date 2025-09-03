using System.Reflection.Emit;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandLabel : QuickJsOperand
    {

        public uint Value;

        public QuickJsOperandLabel(uint num)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_label;
            Value = num;
        }

        public override string GetString()
        {
            string addr = Value < 0 ? Value.ToString() : "+" + Value.ToString();
            return "[pc: $" + addr + "]";
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(Value);
        }

    }
}
