using System;
using System.Runtime.CompilerServices;
using System.Text;

class MainClass
{
    static int Main()
    {
        Console.WriteLine("Birinci asal sayıyı giriniz : ");
        int p = int.Parse(Console.ReadLine());

        Console.WriteLine("İkinci asal sayıyı giriniz : ");
        int q = int.Parse(Console.ReadLine());
      

        int n = p * q;
        int phi = (p - 1) * (q - 1);

        int random;
        int e;

        while (true)
        {
            random = new Random().Next(1, phi);

            if (GCD(random, phi) == 1)
            {
                e = random;
                break;
            }

        }
        Console.WriteLine("Şifrelenecek mesajı giriniz : ");
        string message = Console.ReadLine();

        string cipherMessage = RSAEncription(message, n, e);
        Console.WriteLine("Şifrelenmiş mesaj : " +  cipherMessage);//c=cipherMessage
        Console.WriteLine(e);
        
        return 0;
    }

    static int GCD(int x, int y)
    {
        int min = Math.Min(x, y);
        int gcd = 1;

        for (int i = 2; i <= min; i++)
        {
            if(x%i == 0 && y%i == 0)
            {
                gcd = i;
            }
        }
        return gcd;
    }
    static int Mod(int a, int b, int n) // a^b(mod(n))
    {
        int _a = a % n;
        int _b = b;

        if(b == 0)
        {
            return 1;
        }
        while(_b > 1)
        {
            _a *= a;
            _a %= n;
            _b--;
        }
        return _a;
    }
    static string RSAEncription(string message, int n, int e)
    {      
        char[] chars = message.ToCharArray();
        StringBuilder builder = new StringBuilder();
        for(int i = 0; i < chars.Length; i++)
        {
            builder.Append(Convert.ToChar(Mod(chars[i], e, n)));
        }
        return builder.ToString();
    }
    static int RSADecription(int e, int phi)
    {
        int d = Mod(1, 1, phi) / e;
        return d;
    }
}
