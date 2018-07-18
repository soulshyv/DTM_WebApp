namespace RpgManager.Ged.Contracts
{
    public interface ICreateDocumentRequest : IDocumentMetadata
    {
        IDocument Document { get; }
    }
}