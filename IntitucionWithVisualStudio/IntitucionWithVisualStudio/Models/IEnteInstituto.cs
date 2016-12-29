namespace IntitucionWithVisualStudio
{
	public interface IEnteInstituto
	{
		string CodigoInterno { get; set; }
		string ConstruirLlaveSecreta(string nombreEnte);
	}
}
