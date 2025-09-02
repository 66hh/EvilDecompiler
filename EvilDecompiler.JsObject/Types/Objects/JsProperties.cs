namespace EvilDecompiler.JsObject.Types.Objects
{
    public class JsProperties : JsObject
    {

        public Dictionary<AtomIdx, JsObject> Properties;

        public JsProperties(Dictionary<AtomIdx, JsObject> props)
        {
            Tag = ObjectTag.BC_TAG_OBJECT;
            Properties = props;
        }

    }
}
