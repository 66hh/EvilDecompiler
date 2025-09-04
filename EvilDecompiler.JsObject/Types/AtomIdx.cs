namespace EvilDecompiler.JsObject.Types
{
    public class AtomIdx
    {

        public bool IsTaggedInt
        {
            get
            {
                return (Flag & 1) != 0;
            }
            set
            {
                Flag = (Value << 1) | (value ? 1 : 0);
            }
        }

        public int Value
        {
            get
            {
                return Flag >> 1;
            }
            set
            {
                Flag = (value << 1) | (IsTaggedInt ? 1 : 0);
            }
        }

        public int Flag;

        public AtomIdx(int flag)
        {
            Flag = flag;
        }

        public AtomIdx(int value, bool tagged)
        {
            IsTaggedInt = tagged;
            Value = value;
        }
    }
}
