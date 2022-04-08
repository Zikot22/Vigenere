namespace vizhenere
{
    class Program
    {
        static char[] alphabet = { 'a', 'b', 'c', 'd', 'e','f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
            'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        static void Main(string[] args)
        {
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("1. зашифровать сообщение 2. расшифровать сообщение 3. выход");
                string temp = Console.ReadLine();
                switch (temp)
                {
                    case "1":
                        EncodeMessage();
                        break;
                    case "2":
                        DecodeMessage();
                        break;
                    case "3":
                        isWorking = false;
                        break;
                    default:
                        break;
                }
            }
        }

        static void EncodeMessage()
        {
            Console.Write("Введите сообщение: ");
            string messageInput = Console.ReadLine();
            Console.Write("Введите ключ: ");
            string keyInput = Console.ReadLine();

            char[] message = (messageInput.ToLowerInvariant()).ToCharArray();
            char[] key = (keyInput.ToLowerInvariant()).ToCharArray();
            char[] encodedMessage = new char[message.Length];

            int j = 0;
            for (int i = 0; i < message.Length; i++)
            {
                int index = Array.IndexOf(alphabet, message[i]) + Array.IndexOf(alphabet, key[j]) + 1;
                if (index >= alphabet.Length)
                {
                    index -= alphabet.Length;
                }
                encodedMessage[i] = alphabet[index];
                j++;
                if (j == key.Length)
                {
                    j = 0;
                }
            }
            Console.Write("Зашифрованное сообщение: ");
            foreach (char c in encodedMessage)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }

        static void DecodeMessage()
        {
            Console.Write("Введите сообщение: ");
            string messageInput = Console.ReadLine();
            Console.Write("Введите ключ: ");
            string keyInput = Console.ReadLine();

            char[] message = (messageInput.ToLowerInvariant()).ToCharArray();
            char[] key = (keyInput.ToLowerInvariant()).ToCharArray();
            char[] encodedMessage = new char[message.Length];

            int j = 0;
            for (int i = 0; i < message.Length; i++)
            {
                int index = Array.IndexOf(alphabet, message[i]) - Array.IndexOf(alphabet, key[j]) - 1;
                if (index < 0)
                {
                    index += alphabet.Length;
                }
                encodedMessage[i] = alphabet[index];
                j++;
                if (j == key.Length)
                {
                    j = 0;
                }
            }
            Console.Write("Расшифрованное сообщение: ");
            foreach (char c in encodedMessage)
            {
                Console.Write(c);
            }
            Console.WriteLine("");
        }
    }
}
