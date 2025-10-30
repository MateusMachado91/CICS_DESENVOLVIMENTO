using System.ComponentModel.DataAnnotations;

namespace PYBWeb.Web.Models;

/// <summary>
/// Modelo para nova solicitação CICS
/// </summary>
public class NovaSolicitacaoCicsModel
{
    // Campos para usuário final
    
    [Required(ErrorMessage = "Ambiente CICS é obrigatório")]
    [Display(Name = "Ambiente CICS")]
    public int AmbienteId { get; set; }
    
    [Display(Name = "Nome do Ambiente (preenchido automaticamente)")]
    public string Appli { get; set; } = "";
    
    [Required(ErrorMessage = "Matrícula do solicitante é obrigatória")]
    [Display(Name = "Matrícula Solicitante")]
    public string Usuario { get; set; } = "";
    
    [Required(ErrorMessage = "Sigla do sistema é obrigatória")]
    [Display(Name = "Sigla do Sistema")]
    [StringLength(3, ErrorMessage = "Sigla deve ter 3 caracteres")]
    public string Css { get; set; } = "";
    
    // Seleção da tabela
    [Required(ErrorMessage = "Tipo de tabela é obrigatório")]
    [Display(Name = "Tipo de Tabela")]
    public string TipoTabela { get; set; } = "";
    
    // Campos específicos para FCT
    [Display(Name = "Nome do Arquivo")]
    public string? NameArq { get; set; }
    
    [Display(Name = "Tipo")]
    public string? Type { get; set; }
    
    [Display(Name = "DSNAME do Arquivo")]
    public string? DsnameArq { get; set; }
    
    [Display(Name = "Estado Inicial")]
    public string? EstInit { get; set; }
    
    [Display(Name = "Serviço")]
    public string? Service { get; set; }
    
    [Display(Name = "Número de String")]
    public string? NumStrng { get; set; }
    
    // Campos específicos para DCT
    [Display(Name = "Nome do Arquivo")]
    public string? FileName { get; set; }
    
    [Display(Name = "Tipo de Fila")]
    public string? QueueType { get; set; }
    
    [Display(Name = "DDNAME")]
    public string? Ddname { get; set; }
    
    [Display(Name = "DSNAME")]
    public string? Dsname { get; set; }
    
    [Display(Name = "Estado do Arquivo")]
    public string? EstFile { get; set; }
    
    [Display(Name = "Formato do Registro")]
    public string? FormReg { get; set; }
    
    [Display(Name = "Formato do Registro 2")]
    public string? FormReg2 { get; set; }
    
    [Display(Name = "Formato do Registro 3")]
    public string? FormReg3 { get; set; }
    
    [Display(Name = "Tipo de Arquivo")]
    public string? FileType { get; set; }
    
    [Display(Name = "Tamanho do Registro")]
    public string? RegSize { get; set; }
    
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