using kutyak.Models;
using Microsoft.EntityFrameworkCore;

namespace kutyak.Services
{
    public class KutyaService
    {
        public static List<Kutya> GetKutyak()
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    var response = context.Kutyas.Include(f=>f.Gazda.IrszamNavigation).Include(f=>f.Fajta).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<Kutya> response = new List<Kutya>();
                    response.Add(new Kutya{ Id=-1,Nev=ex.Message});
                    return response;
                }
            };
        }
    }
}
