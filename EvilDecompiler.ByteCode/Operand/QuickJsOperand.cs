﻿using EvilDecompiler.ByteCode.Type;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperand : IQuickJsOperand
    {
        public QuickJsOPCodeFormat Format;

        public virtual string GetString()
        {
            return "/* Unsupported Operand */";
        }

        public virtual byte[] GetBytes()
        {
            return [];
        }
    }
}
