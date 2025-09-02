using EvilDecompiler.ByteCode.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EvilDecompiler.ByteCode.Operand.QuickJsOperandNumber;

namespace EvilDecompiler.ByteCode.Operand
{
    public class QuickJsOperandNumber : QuickJsOperand
    {

        public enum NumberType
        {
            UInt64,
            Int64,
            UInt32,
            Int32,
            UInt16,
            Int16,
            UInt8,
            Int8
        }

        ulong number = 0;

        NumberType numberType;

        public ulong UInt64
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public ulong Int64
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public uint UInt32
        {
            get
            {
                return (uint)number;
            }
            set
            {
                number = value;
            }
        }

        public int Int32
        {
            get
            {
                return (int)number;
            }
            set
            {
                number = (ulong)value;
            }
        }

        public ushort UInt16
        {
            get
            {
                return (ushort)number;
            }
            set
            {
                number = value;
            }
        }

        public short Int16
        {
            get
            {
                return (short)number;
            }
            set
            {
                number = (ulong)value;
            }
        }

        public byte UInt8
        {
            get
            {
                return (byte)number;
            }
            set
            {
                number = value;
            }
        }

        public sbyte Int8
        {
            get
            {
                return (sbyte)number;
            }
            set
            {
                number = (ulong)value;
            }
        }

        public QuickJsOperandNumber(ulong value, NumberType type, QuickJsOPCodeFormat format)
        {
            number = value;
            numberType = type;
            Format = format;
        }

        public override string String()
        {
            switch (numberType)
            {
                case NumberType.UInt64:
                    return UInt64.ToString();
                case NumberType.Int64:
                    return Int64.ToString();
                case NumberType.UInt32:
                    return UInt32.ToString();
                case NumberType.Int32:
                    return Int32.ToString();
                case NumberType.UInt16:
                    return UInt16.ToString();
                case NumberType.Int16:
                    return Int16.ToString();
                case NumberType.UInt8:
                    return UInt8.ToString();
                case NumberType.Int8:
                    return Int8.ToString();
                default:
                    return "/* Unsupported Operand */";
            }

        }
    }
}
