using EvilDecompiler.ByteCode.Instruction;
using EvilDecompiler.ByteCode.Type;
using EvilDecompiler.JsObject.Types.Objects;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Utils;

namespace EvilDecompiler.ByteCode
{
    public class QuickJsDisAssembler
    {

        Reader reader;
        JsFunctionBytecode jsFunctionBytecode;
        AtomSet Atoms;

        public QuickJsDisAssembler(Stream stream, JsFunctionBytecode quickJsMethod, AtomSet atoms)
        {
            reader = new Reader(stream);
            jsFunctionBytecode = quickJsMethod;
            Atoms = atoms;
        }

        public QuickJsInstruction ReadInstruction()
        {
            long pc = reader.BaseStream.Position;
            QuickJsOPCode opcode = new QuickJsOPCode(reader.ReadByte());
            byte[] operand = reader.ReadBytes(opcode.Size - 1);

            QuickJsInstruction result;

            switch (opcode.OPCode)
            {

                case QuickJsOPCode.OPCodeValue.OP_push_minus1:
                case QuickJsOPCode.OPCodeValue.OP_push_0:
                case QuickJsOPCode.OPCodeValue.OP_push_1:
                case QuickJsOPCode.OPCodeValue.OP_push_2:
                case QuickJsOPCode.OPCodeValue.OP_push_3:
                case QuickJsOPCode.OPCodeValue.OP_push_4:
                case QuickJsOPCode.OPCodeValue.OP_push_5:
                case QuickJsOPCode.OPCodeValue.OP_push_6:
                case QuickJsOPCode.OPCodeValue.OP_push_7:
                case QuickJsOPCode.OPCodeValue.OP_push_i8:
                case QuickJsOPCode.OPCodeValue.OP_push_i16:
                case QuickJsOPCode.OPCodeValue.OP_push_i32:
                case QuickJsOPCode.OPCodeValue.OP_push_this:
                case QuickJsOPCode.OPCodeValue.OP_push_true:
                case QuickJsOPCode.OPCodeValue.OP_push_false:
                case QuickJsOPCode.OPCodeValue.OP_push_const:
                case QuickJsOPCode.OPCodeValue.OP_push_const8:
                case QuickJsOPCode.OPCodeValue.OP_push_atom_value:
                case QuickJsOPCode.OPCodeValue.OP_push_empty_string:
                    result = new QuickJsInstructionPushValue(pc, opcode, operand, jsFunctionBytecode, Atoms);
                    break;

                case QuickJsOPCode.OPCodeValue.OP_get_arg:
                case QuickJsOPCode.OPCodeValue.OP_get_arg0:
                case QuickJsOPCode.OPCodeValue.OP_get_arg1:
                case QuickJsOPCode.OPCodeValue.OP_get_arg2:
                case QuickJsOPCode.OPCodeValue.OP_get_arg3:
                case QuickJsOPCode.OPCodeValue.OP_get_loc:
                case QuickJsOPCode.OPCodeValue.OP_get_loc1:
                case QuickJsOPCode.OPCodeValue.OP_get_loc2:
                case QuickJsOPCode.OPCodeValue.OP_get_loc3:
                case QuickJsOPCode.OPCodeValue.OP_get_loc8:
                case QuickJsOPCode.OPCodeValue.OP_get_var:
                case QuickJsOPCode.OPCodeValue.OP_get_var_undef:
                    result = new QuickJsInstructionGetVar(pc, opcode, operand, jsFunctionBytecode, Atoms);
                    break;

                default:
                    result = new QuickJsInstruction(pc, opcode, operand, jsFunctionBytecode, Atoms);
                    break;
            }

            return result;
        }

        public QuickJsInstruction[] ReadAllInstructions()
        {

            List<QuickJsInstruction> list = new List<QuickJsInstruction>();

            while (true) {
                if (IsEnd())
                    break;
                list.Add(ReadInstruction());
            }

            return list.ToArray();
        }

        public bool IsEnd()
        {
            if (reader.BaseStream.Position >= reader.BaseStream.Length)
            {
                return true;
            }
            return false;
        }

    }
}
