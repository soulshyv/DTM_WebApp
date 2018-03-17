namespace DTM.DbManager.Contracts
{
    public interface ICharacPicSearcher
    {
        string GetPicture(string nomPerso, bool displayed = false);
    }
}