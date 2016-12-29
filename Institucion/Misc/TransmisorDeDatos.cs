using System;
using Models.Institucion;

namespace Institucion.Misc
{
    public delegate string Formatter(string input);

    public class TransmisorDeDatos
    {
        public void FormatearYEnviar(IEnteInstituto ente, Formatter localFormater, string nombre)
        {
            var rawString = $"{ente.CodigoInterno}:{ente.ConstruirLlaveSecreta(nombre)}";
            rawString = localFormater(rawString);
            Enviar(rawString);
        }

        private void Enviar(string rawString)
        {
            System.Console.WriteLine($"Transmicion de datos : {rawString}");

            if (InformacionEnviada != null ) {
                InformacionEnviada(this, new EventArgs());
            }
        }

        public event EventHandler InformacionEnviada;
    }
}