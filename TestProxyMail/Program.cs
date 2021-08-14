using System;
using GenericProxy;
using Mailer;

namespace TestProxyMail
{
    class Program
    {
        static void TestMail()
        {
            try
            {
                using var mailer = new MailSender("smtp.free.fr");
                mailer.Send("lionel.desorme@free.fr", "toto", "Blah Blah", @"c:\tmp\db.json", @"c:\tmp\db2.json");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void TestProxy()
        {
            try
            {
                var proxy = new Proxy(25, "smtp.free.fr", 25);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void Main(string[] args)
        {
          
        }
    }
}
