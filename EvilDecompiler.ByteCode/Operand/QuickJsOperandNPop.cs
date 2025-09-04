namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandNPop : QuickJsOperand
    {

        public ushort NPop;

        public QuickJsOperandNPop(ushort nPop)
        {
            Format = Type.QuickJsOPCodeFormat.OP_FMT_npop;
            NPop = nPop;
        }

        public override string GetString()
        {
            return NPop.ToString();
        }

        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(NPop);
        }

    }
}
