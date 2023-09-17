using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class DashBoardModel
    {
        public int TotalDueAssignment { get; set; }
        public int TotalCompleteAssignment { get; set; }
        public int TotalOrder { get; set; }
        public int TotalProdut { get; set; }
        public int TotalCategory { get; set; }
        public int TotalSubcategory { get; set; }
        public int TotalSupplier { get; set; }
        public int TotalDeliveryMan { get; set; }
        public int TotalCustomer { get; set; }
        public int TotalAppointment { get; set; }
        public int TotalSupplierAssignment { get; set; }
        public int TotalDeliveryManAssignment { get; set; }
        public int TotalPayment { get; set; }
        public int TotalCancelOrder{ get; set; }
        public CommonDashBoardModel Common { get; set; }
    }
    public class CommonDashBoardModel
    {
        public int TotalDueAssignment { get; set; }
        public int TotalCompleteAssignment { get; set; }
        public int TotalAssignment { get; set; }
    }

}
