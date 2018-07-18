namespace RpgManager.Ged.Contracts
{
    public interface IFileExtensionValidator
    {
        bool IsAuthorized(string ext);
    }
}