namespace EvilDecompiler.JsObject.Utils
{
    public class Writer : BinaryWriter
    {

        public Writer(Stream output) : base(output) { }

        public void WriteLeb128(int value)
        {
            for (; ; )
            {
                int a = value & 0x7f;
                value >>= 7;
                if (value != 0)
                {
                    Write((byte)(a | 0x80));
                }
                else
                {
                    Write((byte)a);
                    break;
                }
            }
        }

        public void WriteSLeb128(int value)
        {
            WriteLeb128((2 * value) ^ -(value >> 31));
        }

    }
}
