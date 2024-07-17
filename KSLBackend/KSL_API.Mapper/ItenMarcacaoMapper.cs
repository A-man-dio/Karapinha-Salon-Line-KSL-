using KSL_API.DTO.ItenMarcacao;
using KSL_API.Models;

namespace KSL_API.Mapper;

public static class ItenMarcacaoMapper
{   //oq será salvo na bd 
    public static ItenMarcacao ToItenMarcacaoFromCreatedDTO(this CreateItenMarcacaoDTO itenMarcacaoDTO, int idMarcacao)
    {
        return new ItenMarcacao
        {
            IdMarcacao = idMarcacao,
            IdProfissional = itenMarcacaoDTO.IdProfissional,
            IdServico = itenMarcacaoDTO.IdServico
        };
    }  
}