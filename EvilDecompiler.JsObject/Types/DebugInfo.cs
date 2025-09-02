namespace EvilDecompiler.JsObject.Types
{
    public class DebugInfo
    {

        public AtomIdx FileName;

        public int LineNumber;

        public byte[] MapData;

        public DebugInfo(AtomIdx file, int line, byte[] map)
        {
            FileName = file;
            LineNumber = line;
            MapData = map;
        }

    }
}
