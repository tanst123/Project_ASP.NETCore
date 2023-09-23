using ASP.NETCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Data.Entites
{
    public class Contact
    {
         public int Id {get; set;}
         public string Name {get; set;}
         public string Email {get; set;}
         public string PhoneNumber {get; set;}
         public string Message {get; set;}
         public StatusEnum Status { get; set; }

    }
}
