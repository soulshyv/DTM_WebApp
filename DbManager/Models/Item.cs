namespace DTM.DbManager.Models
{
    public class Item
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public string TypeItem { get; set; }
        public int Prix { get; set; }
        public string Commentaire { get; set; }
        public int Quantite { get; set; }
    }
}