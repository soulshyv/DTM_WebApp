namespace DTM.Core.Models
{
    public partial class Demon
    {
        public Demon(DemonForm df)
        {
            Nom = df.Nom;
        }

        public DemonForm GetForm()
        {
            return new DemonForm();
        }

        public class DemonForm
        {
            public string Nom { get; set; }

            public DemonForm()
            {
            }

            public DemonForm(Demon d)
            {
                Nom = d.Nom;
            }
        }
    }
}