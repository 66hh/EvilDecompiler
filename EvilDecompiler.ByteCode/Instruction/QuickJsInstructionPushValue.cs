using EvilDecompiler.ByteCode.Type;
using EvilDecompiler.JsObject.Types;
using EvilDecompiler.JsObject.Types.Objects;

namespace EvilDecompiler.ByteCode.Instruction
{
    public class QuickJsInstructionPushValue : QuickJsInstruction
    {

        public string Value;

        public QuickJsInstructionPushValue(long pc, QuickJsOPCode opCode, byte[] operand, JsFunctionBytecode quickJsMethod, AtomSet atoms) : base(pc, opCode, operand, quickJsMethod, atoms)
        {
            if (opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_push_this)
            {
                Value = "this";
            }
            else if (opCode.OPCode == QuickJsOPCode.OPCodeValue.OP_push_empty_string)
            {
                Value = "";
            }
            else
            {
                Value = operandObjects.GetString().Replace("\r", "\\r").Replace("\n", "\\n");
            }
        }
    }
}
