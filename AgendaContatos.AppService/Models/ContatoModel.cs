using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaContatos.AppService.Models
{
    public class ContatoModel
    {
        public int ContatoId { get; set; }

        [Display(Name = "Nome Contato")]
        public string ContatoNome { get; set; }

        [Display(Name = "E-mail Contato")]
        public string ContatoEmail { get; set; }

        [Display(Name = "Celular Contato")]
        public string ContatoCelular { get; set; }

        public Dictionary<string, string> ListaErros { get; set; }

        public ContatoModel()
        {
            ListaErros = new Dictionary<string, string>();
        }
    }
}
