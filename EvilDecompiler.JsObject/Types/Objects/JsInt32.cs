namespace EvilDecompiler.JsObject.Types.Objects
{
    public class JsInt32 : JsObject
    {

        public int Value;

        public JsInt32(int value)
        {
            Tag = ObjectTag.BC_TAG_INT32;
            Value = value;
        }
    }
}
