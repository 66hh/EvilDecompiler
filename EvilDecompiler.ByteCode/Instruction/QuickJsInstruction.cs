using EvilDecompiler.ByteCode.Operand;
using EvilDecompiler.ByteCode.Type;
using EvilDecompiler.JsObject.Types.Objects;
using EvilDecompiler.JsObject.Utils;


namespace EvilDecompiler.ByteCode.Instruction
{

    public class QuickJsInstruction : IQuickJsInstruction
    {

        private int pc;
        private QuickJsOPCode opCode;
        private QuickJsOperand[] operandObjects;

        public QuickJsInstruction(int pc, QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod)
        {
            this.pc = pc;
            this.opCode = opCode;
            operandObjects = parseOperandByFormat(opCode, operand, quickJsMethod);
        }

        public QuickJsOPCodeFormat getFormat()
        {
            return opCode.Format;
        }

        public QuickJsOPCode getOpCode()
        {
            return opCode;
        }

        public QuickJsOperand[] getParams()
        {
            return operandObjects;
        }

        public int getPC()
        {
            return pc;
        }

        private QuickJsOperand[] parseOperandByFormat(QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod)
        {
            Reader reader = new Reader(new MemoryStream(operand));
            List<QuickJsOperand> list = new List<QuickJsOperand>();

            QuickJsOPCodeFormat format = getFormat();

            switch (format)
            {

                case QuickJsOPCodeFormat.OP_FMT_none:
                    list.Add(new QuickJsOperandNone());
                    break;

                case QuickJsOPCodeFormat.OP_FMT_none_int:
                    list.Add(new QuickJsOperandNoneInt(opCode.OPCode - QuickJsOPCode.OPCodeValue.OP_push_0));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_npopx:
                    list.Add(new QuickJsOperandNPopX(opCode.OPCode - QuickJsOPCode.OPCodeValue.OP_call0));
                    break;

                // 以上Format均是伪操作数(无实际字节)

                case QuickJsOPCodeFormat.OP_FMT_u8:
                    list.Add(new QuickJsOperandU8(reader.ReadByte()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_i8:
                    list.Add(new QuickJsOperandI8(reader.ReadSByte()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_u16:
                    list.Add(new QuickJsOperandU16(reader.ReadUInt16()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_i16:
                    list.Add(new QuickJsOperandI16(reader.ReadInt16()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_u32:
                    list.Add(new QuickJsOperandU32(reader.ReadUInt32()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_i32:
                    list.Add(new QuickJsOperandI32(reader.ReadInt32()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_npop:
                    list.Add(new QuickJsOperandNPop(reader.ReadUInt16()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_npop_u16:
                    list.Add(new QuickJsOperandNPopU16(reader.ReadUInt16(), reader.ReadUInt16()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_label8:
                    list.Add(new QuickJsOperandLabel8(reader.ReadSByte()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_label16:
                    list.Add(new QuickJsOperandLabel16(reader.ReadInt16()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_label:
                    list.Add(new QuickJsOperandLabel(reader.ReadUInt32()));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_const8:
                    list.Add(new QuickJsOperandConst8(reader.ReadByte(), quickJsMethod.CPool));
                    break;

                case QuickJsOPCodeFormat.OP_FMT_const:
                    list.Add(new QuickJsOperandConst(reader.ReadUInt32(), quickJsMethod.CPool));
                    break;

                default:
                    list.Add(new QuickJsOperandRaw(operand, format));
                    break;
            }

            return list.ToArray();
        }
    }

}
