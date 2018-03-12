using System;
using System.Collections.Generic;

namespace Main
{
    public partial class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public int PersoId { get; set; }

        public Perso Perso { get; set; }
    }
}
