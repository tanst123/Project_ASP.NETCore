using ASP.NETCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Data.Entites
{
    public class Order
    {
        public int Id {get;set;}
        public DateTime OrderDate {get;set;}
        public Guid UserId {get;set;}
        public string ShipName {get;set;}
        public string ShipEmail {get;set;}
        public string ShipAddress {get;set;}
        public string ShipPhoneNumber {get;set;}
        public OrderStatusEnum Status { get; set; }

        public List<OrderDetail> OrderDetails { get;set;}

        public AppUser AppUser { get;set;}
    }
}
