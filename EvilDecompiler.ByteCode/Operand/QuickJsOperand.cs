using EvilDecompiler.ByteCode.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
