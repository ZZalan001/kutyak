using kutyak.Models;

namespace kutyak.Services
{
    public class GazdaService
    {
        public static List<Gazdum> GetGazdak()
        {
            using(
                var context = new KutyakContext())
            {
                try
                {
                    return context.Gazda.ToList();
                }
                catch
                {
                    return new List<Gazdum>();
                }
            }
        }
    }
}
