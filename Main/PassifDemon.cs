﻿using System;
using System.Collections.Generic;

namespace Main
{
    public partial class PassifDemon
    {
        public int Id { get; set; }
        public int PassifId { get; set; }
        public int DemonId { get; set; }

        public Demon Demon { get; set; }
        public Passif Passif { get; set; }
    }
}
