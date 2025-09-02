namespace EvilDecompiler.JsObject.Types.Objects
{
    public class JsArray : JsObject
    {

        public List<JsObject> Array;

        public JsObject? Template;

        public JsArray(List<JsObject> array, JsObject? template)
        {
            if (template == null)
                Tag = ObjectTag.BC_TAG_ARRAY;
            else
                Tag = ObjectTag.BC_TAG_TEMPLATE_OBJECT;

            Array = array;
            Template = template;
        }
    }
}
