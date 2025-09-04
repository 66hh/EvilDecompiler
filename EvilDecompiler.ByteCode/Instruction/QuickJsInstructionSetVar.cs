using EvilDecompiler.ByteCode.Type;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;
using static EvilDecompiler.ByteCode.Type.QuickJsOPCode;

namespace EvilDecompiler.ByteCode.Instruction
{
    public class QuickJsInstructionSetVar : QuickJsInstruction
    {

        public string Value;

        public bool PopNewValue;

        public bool GlobalVar;

        public bool Uninitialized;

        public QuickJsInstructionSetVar(long pc, QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod, AtomSet atoms) : base(pc, opCode, operand, quickJsMethod, atoms)
        {
            Value = operandObjects.GetString();

            OPCodeValue code = opCode.OPCode;

            if (code == OPCodeValue.OP_set_arg ||
                code == OPCodeValue.OP_set_arg0 ||
                code == OPCodeValue.OP_set_arg1 ||
                code == OPCodeValue.OP_set_arg2 ||
                code == OPCodeValue.OP_set_arg3 ||
                code == OPCodeValue.OP_set_loc ||
                code == OPCodeValue.OP_set_loc0 ||
                code == OPCodeValue.OP_set_loc1 ||
                code == OPCodeValue.OP_set_loc2 ||
                code == OPCodeValue.OP_set_loc3 ||
                code == OPCodeValue.OP_set_loc8 ||
                code == OPCodeValue.OP_set_var_ref ||
                code == OPCodeValue.OP_set_var_ref1 ||
                code == OPCodeValue.OP_set_var_ref2 ||
                code == OPCodeValue.OP_set_var_ref3 ||
                code == OPCodeValue.OP_set_name)
            {
                PopNewValue = true;
            }
            else
            {
                PopNewValue = false;
            }

            if (code == OPCodeValue.OP_set_loc_uninitialized)
                Uninitialized = true;
            else
                Uninitialized = false;

            if (code == OPCodeValue.OP_set_name)
                GlobalVar = true;
            else
                GlobalVar = false;
        }
    }
}
