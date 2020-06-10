using ProgettoEsame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface SabatoFirestore
    {
        bool InsertSabato(Evento sabato);
        Task<bool> DeleteSabato(Evento sabato);
        Task<bool> UpdateSabato(Evento sabato);
        Task<IList<Evento>> ReadSabato();
    }

    public class DatabaseSabatoHelper
    {
        private static SabatoFirestore firestore = DependencyService.Get<SabatoFirestore>();

        public static Task<bool> DeleteSabato(Evento sabato)
        {
            return firestore.DeleteSabato(sabato);
        }

        public static bool InsertSabato(Evento sabato)
        {
            return firestore.InsertSabato(sabato);
        }

        public static Task<IList<Evento>> ReadSabato()
        {
            return firestore.ReadSabato();
        }

        public static Task<bool> UpdateSabato(Evento sabato)
        {
            return firestore.UpdateSabato(sabato);
        }

    }
}