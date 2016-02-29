using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace ConfigEncrypter
{
    /// <summary>
    /// https://github.com/gsscoder/commandline/wiki/Quickstart
    /// </summary>
        class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (Parser.Default.ParseArguments(args, options))
            {
                IEncrypter encrypter = new Encrypter();
                switch (options.Command)
                {
                    case CommandType.Encrypt:
                        encrypter.EncryptSection(options.ExeFilePath, options.Section);
                        break;
                    case CommandType.Decrypt:
                        encrypter.DencryptSection(options.ExeFilePath, options.Section);
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
