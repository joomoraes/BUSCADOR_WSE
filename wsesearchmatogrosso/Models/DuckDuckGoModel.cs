using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsesearchmatogrosso.Models
{
    public class DuckDuckGoModel
    {
        public string Abstract { get; set; }

        public string AbstractSource { get; set; }

        public string AbstractText { get; set; }

        public string AbstractURL { get; set; }

        public string Answer { get; set; }

        public string AnswerType { get; set; }

        public string Definition { get; set; }

        public string DefinitionSource { get; set; }

        public string DefinitionURL { get; set; }

        public string Entity { get; set; }

        public string Heading { get; set; }

        public string Image { get; set; }

        public string ImageHeight { get; set; }

        public string ImageIsLogo { get; set; }

        public string ImageWidth { get; set; }

        public string Infobox { get; set; }

        public string Redirect { get; set; }

        public IEnumerable<relatedTopics> RelatedTopics { get; set; }

        public class relatedTopics
        {
            public string FirstURL { get; set; }

            public icon Icon { get; set; }

            public class icon
            {
                public string Height { get; set; }

                public string URL { get; set; }

                public string Width { get; set; }
            }

            public string Result { get; set; }

            public string Text { get; set; }
        }

        public object Results { get; set; }

        public string Type { get; set; }

        public Meta meta { get; set; }

        public class Meta
        {
            public string attribution { get; set; }

            public int? blockgroup { get; set; }

            public DateTime? created_date { get; set; }

            public string description { get; set; }

            public DateTime? dev_date { get; set; }

            public string dev_milestone { get; set; }

            public IEnumerable<Developer> developer { get; set; }

            public class Developer
            {
                public string name { get; set; }

                public string type { get; set; }

                public string url { get; set; }
            }

            public string example_query { get; set; }

            public string id { get; set; }

            public int? is_stackexchange { get; set; }

            public string js_callback_name { get; set; }

            public DateTime? live_date { get; set; }

            public Mainteiner mainteiner { get; set; }

            public class Mainteiner
            {
                public string github { get; set; }
            }

            public string name { get; set; }

            public string perl_module { get; set; }

            public int? producer { get; set; }

            public string production_state { get; set; }

            public string repo { get; set; }

            public string signal_from { get; set; }

            public string src_domain { get; set; }

            public int? src_id { get; set; }

            public string src_name { get; set; }

            public Src_options src_options { get; set; }

            public class Src_options
            {
                public string directory { get; set; }

                public int? is_fanon { get; set; }

                public int? is_mediawiki { get; set; }

                public int? is_wikipedia { get; set; }

                public string language { get; set; }

                public string min_abstract_length { get; set; }

                public int? skip_abstract { get; set; }

                public int? skip_abstract_paren { get; set; }

                public string skip_end { get; set; }

                public int? skip_icon { get; set; }

                public int? skip_image_name { get; set; }

                public string skip_qr { get; set; }

                public string source_skipe { get; set; }

                public string src_info { get; set; }
            }

            public string src_url { get; set; }

            public string status { get; set; }

            public string tab { get; set; }

            public object topic { get; set; }
        }
    }
}