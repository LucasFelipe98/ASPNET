using Instituição_de_adoção_ASP;
using Instituição_de_adoção_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Instituição_de_adoção_ASP.DAL
{
    internal class Singleton
    {

        private static readonly Singleton instance = new Singleton();
        private readonly Entities entities;

        private Singleton()
        {
            entities = new Entities();
        }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public Entities Entities
        {
            get
            {
                return entities;
            }
        }
    }
}