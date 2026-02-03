namespace Common.IServices
{
    public interface IHashingService
    {
        string CreateSalt();
        string Create(string value, string salt);
        bool Validate(string value, string salt, string hash); 
    }
}