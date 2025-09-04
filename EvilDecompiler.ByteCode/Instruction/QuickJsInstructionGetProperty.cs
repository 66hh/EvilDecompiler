using EvilDecompiler.ByteCode.Type;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler.ByteCode.Instruction
{
    public class QuickJsInstructionGetProperty : QuickJsInstruction
    {

        public string Value;

        public bool PushOrigin;

        public bool StackValue;

        public QuickJsInstructionGetProperty(long pc, QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod, AtomSet atoms) : base(pc, opCode, operand, quickJsMethod, atoms)
        {
            Value = operandObjects.GetString();
            if (opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_get_field2 || opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_get_array_el2)
            {
                PushOrigin = true;
            }
            else
            {
                PushOrigin = false;
            }

            if (opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_get_length)
                Value = "\"length\"";

            if (opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_get_array_el2 || opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_get_array_el)
                StackValue = true;
            else
                StackValue = false;
        }
    }
}
