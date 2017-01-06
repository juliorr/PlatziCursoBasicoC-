using System;

namespace Institucion.Models
{
    public class Dummy
    {
        private string DummyId
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
    }
}