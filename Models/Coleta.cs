namespace NotificacaoColetaApi.Models
{
    public class Coleta
    {
        public int ColetaId { get; set; }
        public DateTime DataColeta { get; set; }
        public string? TipoResiduos { get; set; }
    }
}