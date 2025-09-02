namespace EvilDecompiler.JsObject.Types
{
    public class VarDef
    {

        public AtomIdx VarName;

        public int ScopeLevel;

        public int ScopeNext;

        public VarFlag Flag;

        public VarDef(AtomIdx name, int level, int next, VarFlag flag)
        {
            VarName = name;
            ScopeLevel = level;
            ScopeNext = next;
            Flag = flag;
        }

    }
}
