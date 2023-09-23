using ASP.NETCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ASP.NETCore.Data.Entites
{
    public class Promotion
    {
        public int Id {get;set;}
        public DateTime FromDate {get;set;}
        public DateTime ToDate {get;set;}
        public bool ApplyForAll {get;set;}
        public int? DiscountPercent {get;set;}
        public decimal? DiscountAmount {get;set;}
        public int ProductIds {get;set;}
        public int ProductCategoryIds {get;set;}
        public StatusEnum Status {get;set;}
        public string Name { get; set; }

    }
}
