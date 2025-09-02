using EvilDecompiler.ByteCode.Type;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperand : IQuickJsOperand
    {
        public QuickJsOPCodeFormat Format;

        public virtual string String()
        {
            return "/* Unsupported Operand */";
        }
    }
}
