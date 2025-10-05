namespace APICatalogo.Models.Base
{
    public class BaseAll
    {
        public int Id { get; set; }
        public string? ImagemUrl { get; set; }
        public DateTime DataInsercao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
