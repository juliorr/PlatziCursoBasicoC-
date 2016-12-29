namespace Models.Institucion
{
    public interface IEnteInstituto
    {
         string CodigoInterno { get; set; }
         string ConstruirLlaveSecreta(string nombreEnte);
    }
}