using System.ComponentModel.DataAnnotations;

namespace PYBWeb.Domain.Models;

/// <summary>
/// Modelo para nova solicitação CICS
/// </summary>
public class NovaSolicitacaoCicsModel
{
    // Campos para usuário final
   
        [Display(Name = "Ambiente CICS")]
    public int AmbienteId { get; set; }
    
    [Display(Name = "Nome do Ambiente (preenchido automaticamente)")]
    public string Appli { get; set; } = "";
    
        [Display(Name = "Matrícula Solicitante")]
    public string Usuario { get; set; } = "";
    
        [Display(Name = "Sigla do Sistema")]
    [StringLength(3, ErrorMessage = "Sigla deve ter 3 caracteres")]
    public string Css { get; set; } = "";
    
    // Seleção da tabela
        [Display(Name = "Tipo de Tabela")]
    public string TipoTabela { get; set; } = "";
    
    // Campos específicos para FCT
    [Display(Name = "Nome do Arquivo")]
    public string? NameArq { get; set; }

    public string? Recfm { get; set; }
    
    [Display(Name = "Tipo")]
    public string? Type { get; set; }
    
    [Display(Name = "DSNAME do Arquivo")]
    public string? DsnameArq { get; set; }
    
    [Display(Name = "Estado Inicial")]
    public string? EstInit { get; set; }
    
    [Display(Name = "Serviço")]
    public string? Service { get; set; }
    public List<string> Services { get; set; } = new();
    
    [Display(Name = "Número de String")]
    public string? NumStrng { get; set; }
    
    // Campos específicos para DCT

    // Campos específicos para DCT INTRA
    public string? Transacao { get; set; }

    public int? TrigLevel { get; set; }

    public string? Destino { get; set; }

    [Display(Name = "Terminal")]
    public string? Terminal { get; set; }

        public string? FileName { get; set; }
    
    [Display(Name = "Tipo de Fila")]
    public string? QueueType { get; set; }
    
    [Display(Name = "DDNAME")]
    public string? Ddname { get; set; }
    
    [Display(Name = "DSNAME")]
    public string? Dsname { get; set; }
    
    public string? FormReg { get; set; }

    public string? FormReg2 { get; set; }

    public string? FormReg3 { get; set; }

    public string? RegSize { get; set; }

    public string? FileType { get; set; }

    [Display(Name = "Estado do Arquivo")]
    public string? EstFile { get; set; }
       
    [Display(Name = "Tamanho do Bloco")]
    public string? BlockSize { get; set; }
    
    // Campos específicos para PCT
    [Display(Name = "Nome da Transação")]
    public string? NameTrans { get; set; }
    
    [Display(Name = "Programa para Ativar")]
    public string? ActiveSoft { get; set; }
    
    [Display(Name = "TWA Size")]
    public string? TwaSize { get; set; } = "0";
    
    [Display(Name = "Descrição")]
    public string? Coment { get; set; }
    
    [Display(Name = "Data de Previsão")]
    public string? Prev { get; set; }
    
    [Display(Name = "Alocação de Dados")]
    public string? DataAllocation { get; set; }
    
    public string? JustificativaBelow { get; set; }
    
    // Campos específicos para PPT
    [Display(Name = "Nome do Software")]
    public string? NameSoft { get; set; }
    
    [Display(Name = "Nome do Link")]
    public string? LinkName { get; set; }
    
    [Display(Name = "Linguagem")]
    public string? Language { get; set; }
    
    [Display(Name = "Tipo PPT")]
    public string? TypePpt { get; set; }
    
    [Display(Name = "Auto Alteração")]
    public string? AutoAlt { get; set; }
}