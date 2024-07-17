namespace KSL_API.DTO.Servico;

public class UpdateServicoDTO
{
    public string Nome { get; set; }
    public int IdCategoria{ get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
}