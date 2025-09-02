namespace EvilDecompiler.JsObject.Types
{
    public class ClosureVarDef
    {

        public AtomIdx VarName;

        public int VarIdx;

        public ClosureVarFlag Flag;

        public ClosureVarDef(AtomIdx name, int idx, ClosureVarFlag flag)
        {
            VarName = name;
            VarIdx = idx;
            Flag = flag;
        }
    }
}
