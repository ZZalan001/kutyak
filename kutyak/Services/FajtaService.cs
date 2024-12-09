using kutyak.DTOs;
using kutyak.Models;
using Microsoft.EntityFrameworkCore;

namespace kutyak.Services
{
    public class FajtaService
    {
        public static List<Fajtum> GetFajtak()
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    return context.Fajta.ToList();
                }
                catch (Exception ex)
                {
                    List<Fajtum> response = new List<Fajtum>();
                    response.Add(new Fajtum { Id = -1, Nev = ex.Message });
                    return response;
                }
            }
        }

        public static List<FajtaDTO> GetFajtakDTO()
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    var response = context.Fajta.Select(f => new FajtaDTO()
                    {
                        Id = f.Id,
                        Nev = f.Nev,
                        Leiras = f.Leiras,
                    }).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<FajtaDTO> response = new List<FajtaDTO>();
                    response.Add(new FajtaDTO { Id = -1, Nev = ex.Message });
                    return response;
                }
            };
        }

        public static string FajtaTorol(int id)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    Fajtum fajta = new Fajtum { Id = id };
                    context.Fajta.Remove(fajta);
                    //context.SaveChanges();
                    return "Sikeresen törölve a fajta adata.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            };
        }

        public static Fajtum GetFajta(int id)
        {
            using (
                var context = new KutyakContext())
            {
                try
                {
                    return context.Fajta.FirstOrDefault(f => f.Id == id);
                }
                catch
                {
                    return new Fajtum { Id = 0 };
                }
            }
        }





    }
}
