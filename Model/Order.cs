using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model { 
    public class Order
    {
        public string OID { get; set; }
        public int MID { get; set; }
        public string ODate { get; set; }
        public string OConsignee { get; set; }
        public string OAddress { get; set; }
        public string OTelephone { get; set; }
        public double OSumPrice { get; set; }
        public string OState { get; set; }
        public enum enumOState { 新订单 = 1, 订单确认, 发货, 订单结束 }
    }
}
