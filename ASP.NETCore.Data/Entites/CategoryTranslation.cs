﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASP.NETCore.Data.Entites
{
    public class CategoryTranslation
    {
        public int Id {get; set;}
        public int CategoryId {get; set;}
        public string Name {get; set;}
        public string SeoDescription {get; set;}
        public string SeoTitle {get; set;}
        public string LanguageId {get; set;}
        public string SeoAlias { get; set; }

        public Category Category { get; set;}
        public Language Language { get; set;}
    }
}
