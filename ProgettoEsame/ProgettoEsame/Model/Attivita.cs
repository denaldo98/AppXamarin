using System;
using System.Collections.Generic;
using System.Text;

namespace ProgettoEsame.Model
{
    public class Attivita
    {
        public string Id { get; set; }
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Scadenza { get; set; }
        public Attivita()
        {
        }
    }
}
