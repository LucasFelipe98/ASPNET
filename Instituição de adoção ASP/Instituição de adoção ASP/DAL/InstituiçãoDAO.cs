using Instituição_de_adoção_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Instituição_de_adoção_ASP.DAL
{
    public class InstituiçãoDAO
    {
        private static Entities entities = new Entities();
        //private static Entities entities = Singleton.Instance.Entities;

        public static List<Instituição> ListarInstituições()
        {
            return entities.Instituições.ToList();
        }

        public static Instituição BuscarInstituiçãoPorId(int? idInstituição)
        {
            return entities.Instituições.Find(idInstituição);
        }

        public static bool CadastrarInstituição(Instituição instituição)
        {
            try
            {
                entities.Instituições.Add(instituição);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Instituição BuscarInstituiçãoPorLogin(string login)
        {
            return entities.Instituições.FirstOrDefault(x => x.InstituiçãoLogin.Equals(login));
        }

        public static Instituição BuscarInstituiçãoPorLoginSenha(Instituição instituição)
        {
            return entities.Instituições.FirstOrDefault(x => x.InstituiçãoLogin.Equals(instituição.InstituiçãoLogin) && x.InstituiçãoSenha.Equals(instituição.InstituiçãoSenha));
        }
        public static bool EditarInstituição(Instituição instituição)
        {
            try
            {
                entities.Entry(instituição).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}