namespace APICatalogo.Models.Base
{
    public class BaseAll
    {
        public int Id { get; set; }
        public string? ImagemUrl { get; set; }
        public DateTime DataInsercao { get; set; }
        public DateTime? DataExclusao { get; set; } // Usando '?' para permitir valores nulos
        public DateTime? DataAlteracao { get; set; } // Usando '?' para permitir valores nulos
        public bool Ativo { get; set; }
    }
}
