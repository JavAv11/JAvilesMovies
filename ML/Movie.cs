namespace ML
{
    public class Movie
    {

        public string Titulo { get; set; }
        public int? IdMovie { get; set; }
        public string Descripcion { get; set; }
       
        public string Idioma { get; set; }
        public string Imagen { get; set; }
        public string Ranking { get; set; }

        public List<object>Movies { get; set; }

    }
}