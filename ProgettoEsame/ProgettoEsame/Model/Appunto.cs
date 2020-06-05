using System;
using System.Collections.Generic;
using System.Text;

namespace ProgettoEsame.Model
{
    public class Appunto
    {
        public string Id { get; set; }
        public string IdCorso { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Appunto()
        {
        }
    }
}
