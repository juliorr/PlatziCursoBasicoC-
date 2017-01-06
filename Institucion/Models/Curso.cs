namespace Institucion.Models
{
    public struct CursoStruct
    {
        const string NOMBRE_DEFECT_CURSO = "No asignado";
        public string curso { get; set; }
        public readonly short max_capacidad; 
        
        public CursoStruct(short max_cap)
        {
            max_capacidad = max_cap;
            curso = NOMBRE_DEFECT_CURSO;
        }
    }
}