using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce.Model;
using E_Commerce.BusinessLayer;

namespace E_Commerce.Admin.Panel.GlobalDashBoardSettings
{
    public class GlobalDashBoardSettingsModel
    {
        public static DashBoardModel DashboardInformation()
        {
            return new DashBoardModel()
            {
                TotalSupplierAssignment = AssignmentManager.GetAllAssignmentSupplier().Count(),
                TotalDueAssignment = AssignmentManager.GetAllAssignmentSupplier().Select(x => x.AssignmentUpdate == 0).ToList().Count(),
                TotalCompleteAssignment =AssignmentManager.GetAllAssignmentSupplier().Select(x=>x.AssignmentUpdate==1).ToList().Count(),
                TotalOrder=OrderManager.GetAllCustomerOrder().Count(),
                TotalCancelOrder = OrderManager.GetAllCustomerOrder().Select(x => x.OrderDeliveryUpdate == 3).ToList().Count(),
                TotalCompleteOrder= OrderManager.GetAllCustomerOrder().Select(x => x.OrderDeliveryUpdate == 1).ToList().Count(),
                TotalDueOrder= OrderManager.GetAllCustomerOrder().Select(x => x.OrderDeliveryUpdate == 0).ToList().Count(),
                TotalProdut =ProductManager.GetAllProduct().Count(),
                TotalCategory = CategoryManager.GetAllCategory().Count(),
                TotalSubcategory = SubCategoryManager.GetAllSubCategory().Count(),
                TotalSupplier = StaffSettingsManager.GetAllSupplier().Count(),
                TotalDeliveryMan = StaffSettingsManager.GetAllDeliveryMan().Count(),
                TotalCustomer=CustomerManager.GetAllCustomer().Count(),
                TotalAppointment= ContactManager.GetAllAppointment().Count(),
                TotalDueAppointment= AssignmentManager.GetAllAssignmentAppointment().Select(x => x.AssigentmentUpdate == 0).ToList().Count(),
                TotalCompleteAppointment = AssignmentManager.GetAllAssignmentAppointment().Select(x => x.AssigentmentUpdate == 1).ToList().Count(),
                TotalDeliveryManAssignment = AssignmentManager.GetAllAssignmentDeliveryMan().Count(),
                TotalDeliveryManDueAssignment= AssignmentManager.GetAllAssignmentDeliveryMan().Select(x => x.AssigentmentUpdate == 0).ToList().Count(),
                TotalDeliveryManCompleteAssignment= AssignmentManager.GetAllAssignmentDeliveryMan().Select(x => x.AssigentmentUpdate == 1).ToList().Count()
                //TotalPayment =OrderManager.GetAllCustomerOrder().Select(x=>x),
                //TotalCompletePayment=0,
                //TotalDuePayment=0  
            };
        }
    }
}