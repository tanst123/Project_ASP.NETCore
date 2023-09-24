using ASP.NETCore.Data.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Data.Entites
{
    public class Category
    {
        public int Id {get; set;}
        public int SortOrder {get; set;}
        public bool IsShowOnHome {get; set;}
        public int? ParentId {get; set;}
        public StatusEnum Status { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set;}
        public List<CategoryTranslation> CategoryTranslations { get; set;}
    }
}
