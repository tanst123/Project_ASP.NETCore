using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Data.Entites
{
    public class Language
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public bool isDefault { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }


    }
}
