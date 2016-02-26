namespace ConfigEncrypter
{
    public interface IEncrypter
    {
        void DencryptSection(string filePath, string sectionName);
        void EncryptSection(string filePath, string sectionName);
    }
}