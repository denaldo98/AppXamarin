using System;
using System.Collections.Generic;
using System.Text;

namespace ProgettoEsame.Model
{
    public class Corso
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string NameProf { get; set; }

        public string NumCFU { get; set; }

        public string EmailProf { get; set; }

        public Corso()
        {
        }
    }
}
