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
                case QuickJsOPCode.OPCodeValue.OP_get_loc0:
                case QuickJsOPCode.OPCodeValue.OP_get_loc1:
                case QuickJsOPCode.OPCodeValue.OP_get_loc2:
                case QuickJsOPCode.OPCodeValue.OP_get_loc3:
                case QuickJsOPCode.OPCodeValue.OP_get_loc8:
                case QuickJsOPCode.OPCodeValue.OP_get_var:
                case QuickJsOPCode.OPCodeValue.OP_get_var_undef:
                case QuickJsOPCode.OPCodeValue.OP_get_var_ref: // 暂时不知道var ref是咋和外面的变量对应的先写这里
                case QuickJsOPCode.OPCodeValue.OP_get_var_ref0:
                case QuickJsOPCode.OPCodeValue.OP_get_var_ref1:
                case QuickJsOPCode.OPCodeValue.OP_get_var_ref2:
                case QuickJsOPCode.OPCodeValue.OP_get_var_ref3:
                    result = new QuickJsInstructionGetVar(pc, opcode, operand, jsFunctionBytecode, Atoms);
                    break;

                case QuickJsOPCode.OPCodeValue.OP_get_field:
                case QuickJsOPCode.OPCodeValue.OP_get_field2:
                    result = new QuickJsInstructionGetProperty(pc, opcode, operand, jsFunctionBytecode, Atoms);
                    break;

                case QuickJsOPCode.OPCodeValue.OP_put_arg:
                case QuickJsOPCode.OPCodeValue.OP_put_arg0:
                case QuickJsOPCode.OPCodeValue.OP_put_arg1:
                case QuickJsOPCode.OPCodeValue.OP_put_arg2:
                case QuickJsOPCode.OPCodeValue.OP_put_arg3:
                case QuickJsOPCode.OPCodeValue.OP_put_loc:
                case QuickJsOPCode.OPCodeValue.OP_put_loc0:
                case QuickJsOPCode.OPCodeValue.OP_put_loc1:
                case QuickJsOPCode.OPCodeValue.OP_put_loc2:
                case QuickJsOPCode.OPCodeValue.OP_put_loc3:
                case QuickJsOPCode.OPCodeValue.OP_put_loc8:
                case QuickJsOPCode.OPCodeValue.OP_put_var:
                case QuickJsOPCode.OPCodeValue.OP_put_var_init:
                case QuickJsOPCode.OPCodeValue.OP_put_var_ref:
                case QuickJsOPCode.OPCodeValue.OP_put_var_ref0:
                case QuickJsOPCode.OPCodeValue.OP_put_var_ref1:
                case QuickJsOPCode.OPCodeValue.OP_put_var_ref2:
                case QuickJsOPCode.OPCodeValue.OP_put_var_ref3:

                case QuickJsOPCode.OPCodeValue.OP_set_arg:
                case QuickJsOPCode.OPCodeValue.OP_set_arg0:
                case QuickJsOPCode.OPCodeValue.OP_set_arg1:
                case QuickJsOPCode.OPCodeValue.OP_set_arg2:
                case QuickJsOPCode.OPCodeValue.OP_set_arg3:
                case QuickJsOPCode.OPCodeValue.OP_set_loc:
                case QuickJsOPCode.OPCodeValue.OP_set_loc0:
                case QuickJsOPCode.OPCodeValue.OP_set_loc1:
                case QuickJsOPCode.OPCodeValue.OP_set_loc2:
                case QuickJsOPCode.OPCodeValue.OP_set_loc3:
                case QuickJsOPCode.OPCodeValue.OP_set_loc8:
                case QuickJsOPCode.OPCodeValue.OP_set_var_ref:
                case QuickJsOPCode.OPCodeValue.OP_set_var_ref0:
                case QuickJsOPCode.OPCodeValue.OP_set_var_ref1:
                case QuickJsOPCode.OPCodeValue.OP_set_var_ref2:
                case QuickJsOPCode.OPCodeValue.OP_set_var_ref3:
                case QuickJsOPCode.OPCodeValue.OP_set_name:
                    result = new QuickJsInstructionSetVar(pc, opcode, operand, jsFunctionBytecode, Atoms);
                    break;

                case QuickJsOPCode.OPCodeValue.OP_dup:
                case QuickJsOPCode.OPCodeValue.OP_dup1:
                case QuickJsOPCode.OPCodeValue.OP_dup2:
                case QuickJsOPCode.OPCodeValue.OP_dup3:
                    result = new QuickJsInstructionDup(pc, opcode, operand, jsFunctionBytecode, Atoms);
                    break;

                case QuickJsOPCode.OPCodeValue.OP_drop:
                    result = new QuickJsInstructionPop(pc, opcode, operand, jsFunctionBytecode, Atoms);
                    break;

                case QuickJsOPCode.OPCodeValue.OP_fclosure:
                case QuickJsOPCode.OPCodeValue.OP_fclosure8:
                    result = new QuickJsInstructionClosure(pc, opcode, operand, jsFunctionBytecode, Atoms);
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
