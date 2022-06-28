using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wsesearchmatogrosso.Models.b3
{
    public class EmpresasPregaoModel
    {
        [Display(Name = "id", Description = "id da empresa")]
        public int id { get; set; }

        [Display(Name = "Acao", Description = "Nome da Ação")]
        public string cd_acao_raiz { get; set; }

        [Display(Name = "nm_empresa", Description = "Nome da Empresa")]
        public string nm_empresa { get; set; }
        
        [Display(Name = "setor_economico", Description = "Setor Economico")]
        public string setor_economico { get; set; }

        [Display(Name = "subsetor", Description = "Subsetor")]
        public string subsetor { get; set; }

        [Display(Name = "segmento", Description = "segmento")]
        public string segmento { get; set; }

        [Display(Name = "segmento_b3", Description = "Segmento B3")]
        public string segmento_b3 { get; set; }

        [Display(Name = "nm_segmento_b3", Description = "nm_segmento_b3")]
        public string nm_segmento_b3 { get; set; }

        [Display(Name = "cd_acao", Description = "Cd Acao")]
        public string cd_acao { get; set; }

        [Display(Name = "tx_cnpj", Description = "Tx Cnpj")]
        public string tx_cnpj { get; set; }

        [Display(Name = "vl_cnpj", Description = "Vl Cnpj")]
        public string vl_cnpj { get; set; }

        [Display(Name = "created_at", Description = "Created At")]
        public string created_at { get; set; }

        [Display(Name = "updated_at", Description = "Updated At")]
        public string updated_at { get; set; }
    }
}