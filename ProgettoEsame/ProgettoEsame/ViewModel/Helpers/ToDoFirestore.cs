using ProgettoEsame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface ToDoFirestore   
    {
        bool InsertAttivita(Attivita attivita);
        Task<bool> DeleteAttivita(Attivita attivita);
        Task<bool> UpdateAttivita(Attivita attivita);
        Task<IList<Attivita>> ReadAttivita();
    }


    public class DatabaseToDoHelper
    {
        private static ToDoFirestore firestore = DependencyService.Get<ToDoFirestore>();

        public static Task<bool> DeleteAttivita(Attivita attivita)
        {
            return firestore.DeleteAttivita(attivita);
        }

        public static bool InsertAttivita(Attivita attivita)
        {
            return firestore.InsertAttivita(attivita);
        }

        public static Task<IList<Attivita>> ReadAttivita()
        {
            return firestore.ReadAttivita();
        }

        public static Task<bool> UpdateAttivita(Attivita attivita)
        {
            return firestore.UpdateAttivita(attivita);
        }

    }
}
