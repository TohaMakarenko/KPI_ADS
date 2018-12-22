namespace Lab_3
{
    public class EncryptedMessage
    {
        public ushort A { get; set; }
        public ushort B { get; set; }

        public EncryptedMessage(ushort a, ushort b)
        {
            A = a;
            B = b;
        }
    }
}