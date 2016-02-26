using System.Configuration;

namespace ConfigEncrypter
{
    public class Encrypter : IEncrypter
    {
        public void EncryptSection(string filePath, string sectionName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(filePath);
            ConfigurationSection section = config.GetSection(sectionName);
            if (!section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            }
            config.Save();
        }

        public void DencryptSection(string filePath, string sectionName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(filePath);
            ConfigurationSection section = config.GetSection(sectionName);
            if (section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
            }
            config.Save();
        }
    }
}