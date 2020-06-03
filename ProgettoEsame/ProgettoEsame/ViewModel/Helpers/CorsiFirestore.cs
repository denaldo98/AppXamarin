using ProgettoEsame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface CorsiFirestore
    {
        bool InsertCorso(Corso corso);
        Task<bool> DeleteCorso(Corso corso);
        Task<bool> UpdateCorso(Corso corso);
        Task<IList<Corso>> ReadCorsi();
    }
    public class DatabaseCorsiHelper
    {
        private static CorsiFirestore firestore = DependencyService.Get<CorsiFirestore>();

        public static Task<bool> DeleteCorso(Corso corso)
        {
            return firestore.DeleteCorso(corso);
        }

        public static bool InsertCorso(Corso corso)
        {
            return firestore.InsertCorso(corso);
        }

        public static Task<IList<Corso>> ReadCorsi()
        {
            return firestore.ReadCorsi();
        }

        public static Task<bool> UpdateCorso(Corso corso)
        {
            return firestore.UpdateCorso(corso);
        }

    }
}
