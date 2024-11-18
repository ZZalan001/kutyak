using kutyak.DTOs;
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
                    var response = context.Kutyas.Include(f => f.Gazda.IrszamNavigation).Include(f => f.Fajta).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<Kutya> response = new List<Kutya>();
                    response.Add(new Kutya { Id = -1, Nev = ex.Message });
                    return response;
                }
            };
        }

        public static List<KutyakDTO> GetKutyakDTO()
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    var response = context.Kutyas.Include(f => f.Gazda.IrszamNavigation).Include(f => f.Fajta).Select(f => new KutyakDTO()
                    {
                        Id = f.Id,
                        Nev = f.Nev,
                        GazdaNev = f.Gazda.Nev,
                        Irszam = f.Gazda.Irszam,
                        Telepules = f.Gazda.IrszamNavigation.Telepules,
                        Lakcim = f.Gazda.Lakcim,
                        FajtaNev = f.Fajta.Nev,
                        Eletkor = f.Eletkor,
                        ChipNumber = f.ChipNumber,
                        IndexKep = f.IndexKep
                    }).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<KutyakDTO> response = new List<KutyakDTO>();
                    response.Add(new KutyakDTO { Id = -1, Nev = ex.Message });
                    return response;
                }
            };
        }

        public static KutyaGumi GetKutyaGumi(int id)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    var response = context.Kutyas.Where(f=>f.Id == id).Select(f => new KutyaGumi()
                    {
                        Kep = f.Kep
                    }).ToList();
                    return response[0];
                }
                catch (Exception ex)
                {
                    return null;
                }
            };
        }

        public static string KutyaTorol(int id)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    Kutya kutya = new Kutya { Id = id };
                    context.Kutyas.Remove(kutya);
                    //context.SaveChanges();
                    return "Sike(haha Sike xddddd)resen törölve a kutya adata.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            };
        }
    }
}
