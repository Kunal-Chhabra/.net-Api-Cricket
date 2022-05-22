using System;
using System.Collections.Generic;

namespace Cricket1.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int? PlayerAge { get; set; }
        public int? PlayerCountryid { get; set; }

        public Country PlayerCountry { get; set; }
    }
}
