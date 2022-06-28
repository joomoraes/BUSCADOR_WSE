using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wsesearchmatogrosso.Models.b3
{
    public class CarteiraPregaoModel
    {
        [Display(Name = "id", Description = "id")]
        public int id { get; set; }

        [Display(Name = "cd_acao", Description = "Cd Ação")]
        public string cd_acao { get; set; }

        [Display(Name = "AMBEV", Description = "AMBEV SA")]
        public string cd_acao_rdz { get; set; }

        [Display(Name = "nm_empresa", Description = "Nome Empresa")]
        public string nm_empresa { get; set; }

        [Display(Name = "pctl_ctra", Description = "pctl_ctra")]
        public double pctl_ctra { get; set; }
        
        [Display(Name = "qtd_teorica", Description = "Quantidade Teorica")]
        public Int64 qtd_teorica { get; set; }

        [Display(Name = "created_at", Description = "Criado Em")]
        public string created_at { get; set; }

        [Display(Name = "updated_at", Description = "Atualizado Em")]
        public string updated_at { get; set; }
    }
}