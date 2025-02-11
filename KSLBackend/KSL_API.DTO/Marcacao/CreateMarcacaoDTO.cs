namespace KSL_API.DTO.Marcacao;

public class CreateMarcacaoDTO
{
    public int IdUtilizador { get; set; }
    public int IdCategoria { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan Hora { get; set; }
    public List<Models.ItenMarcacao> ServicosMarcados { get; set; }
}