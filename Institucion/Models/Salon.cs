using System;
using Models.Institucion;

namespace Institucion.Models
{
    public class Salon : IEnteInstituto
    {
        public string CodigoInterno
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public string ConstruirLlaveSecreta(string nombreEnte)
        {
            return "SAL ON";
        }
    }
}