using CommandLine;
using CommandLine.Text;

namespace ConfigEncrypter
{
    public enum CommandType
    {
        Encrypt,
        Decrypt
    }
    public class Options
    {
        [Option('c', "command", Required = true,
          HelpText = "Encrypt or decrypt")]
        public CommandType Command { get; set; }

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
}