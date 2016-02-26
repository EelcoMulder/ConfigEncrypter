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
    class Options
    {
        [Option('c', "command", Required = true,
          HelpText = "Encrypt or decrypt")]
        public string Command { get; set; }

        [Option('f', "exefilepath", Required = true,
          HelpText = "Path to the exe which the app.config belongs to")]
        public string ExeFilePath { get; set; }

        [Option('s', "section", Required = true,
          HelpText = "Name of the section the be encrypted or decrypted")]
        public string Section { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (Parser.Default.ParseArguments(args, options))
            {
                IEncrypter encrypter = new Encrypter();
                if (options.Command.Equals("encrypt", StringComparison.InvariantCultureIgnoreCase))
                    encrypter.EncryptSection(options.ExeFilePath, options.Section);
                else if (options.Command.Equals("decrypt", StringComparison.InvariantCultureIgnoreCase))
                    encrypter.DencryptSection(options.ExeFilePath, options.Section);
                else
                    Console.WriteLine("Unknown command: {0}", options.Command);
            }
            Console.ReadKey();
        }
    }
}
