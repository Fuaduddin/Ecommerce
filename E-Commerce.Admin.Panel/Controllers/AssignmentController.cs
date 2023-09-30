using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Assignment
        // Assign Appointment
        public ActionResult AssignAdmin(int Id)
        {
            AdminViewModel assingadmin = new AdminViewModel();
            assingadmin.Appointment = ContactManager.GetSingleAppointment(Id);
            assingadmin.AdminList = StaffSettingsManager.GetAllAdmin();
            assingadmin.AdminAssignment = new AdminAssignmentModel();
            return View("AssignAdmin",assingadmin);
        }
        [HttpPost]
        public ActionResult AssignAdmin(AdminAssignmentModel assignment, AppointmentModel appointment)
        {
            if(assignment.AssigentmentAppointmentId>0)
            {
                assignment.AssigentmentAppointmentDate = DateTime.Now;
                appointment.AssingedUpdate = 1;
                if (ContactManager.UpdateAppointment(appointment) && AssignmentManager.UpdateAssignmentAppointment(assignment))
                {
                    ViewData["Message"] = "Your data have  been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have  not been Updated";
                }
            }
            else
            {
                assignment.AppointId = appointment.AppointmentId;
                assignment.AssigentmentAppointmentDate = DateTime.Now;
                assignment.AssigentmentUpdate = 0;
                appointment.AssingedUpdate = 1;
                appointment.AppointDate = DateTime.Now;
                if (ContactManager.UpdateAppointment(appointment) && AssignmentManager.AddNewAssignmentAppointment(assignment)>0)
                {
                    ViewData["Message"] = "Your data have  been added";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have  not been added";
                }
            }
            AdminViewModel assingadmin = new AdminViewModel();
            assingadmin.AdminAssignmentList = perpageshowdataadmin(1, 10, 0);
            return View("ViewAllAssignAdmin", assingadmin);
        }
        public ActionResult ViewAllAssignAdmin()
        {
            AdminViewModel assignment = new AdminViewModel();
            assignment.AdminAssignmentList = perpageshowdataadmin(1,10,0);
            return View("ViewAllAssignAdmin", assignment);
        }
        public ActionResult Multiedelete(int[] multidelete)
        {
            int i = 0;
            if (multidelete != null)
            {
                foreach (int multid in multidelete)
                {
                    DeliverySettingsManager.DeleteDeliveryCost(multid);
                    i++;
                }
            }
            if (multidelete.Length == i)
            {
                ViewData["Message"] = "Your data have  been Deleted";
            }
            else
            {
                ViewData["Message"] = "Your data have not been Deleted";
            }
            AdminViewModel assignment = new AdminViewModel();
            assignment.AdminAssignmentList = perpageshowdataadmin(1, 10, 0);
            assignment.totalpage = pagecountadmin(10);
            return View("ViewAllAssignAdmin", assignment);
        }
        public ActionResult DeletedAssignAdmin(int id)
        {
            AdminViewModel assignment = new AdminViewModel();
            if (AssignmentManager.DeleteAssignmentAppointment(id))
            {
                ViewData["Message"] = "Your data have  been deleted";
            }
            else
            {
                ViewData["Message"] = "Your data have not been deleted";
            }
            assignment.AdminAssignmentList = perpageshowdataadmin(1, 10,0);
            assignment.totalpage = pagecountadmin(10);
            return View("ViewAllAssignAdmin", assignment);
        }
        public ActionResult GetSingleAssignAdmin(int id)
        {
            AdminViewModel assignment = new AdminViewModel();
            assignment.AdminAssignment = AssignmentManager.GetSingleAssignmentAppointment(id);
            assignment.AdminList = StaffSettingsManager.GetAllAdmin();
            return View("AssignAdmin", assignment);
        }
        public int pagecountadmin(int perpagedata)
        {
            IEnumerable<AdminAssignmentModel> adminassingment = AssignmentManager.GetAllAssignmentAppointment();
            return Convert.ToInt32(Math.Ceiling(adminassingment.Count() / (double)perpagedata));
        }

        public List<AdminAssignmentModel> perpageshowdataadmin(int pageindex, int pagesize, int assignmentupdate)
        {
            IEnumerable<AdminAssignmentModel> adminassingment = AssignmentManager.GetAllAssignmentAppointment();
            List<AdminAssignmentModel> assignmentlist=new List<AdminAssignmentModel>();
            if (assignmentupdate== 1)
            {
                 assignmentlist= adminassingment.Skip((pageindex - 1) * pagesize).Where(x => x.AssigentmentUpdate == 0).Take(pagesize).ToList();
            }
            else if(assignmentupdate==2)
            {
                assignmentlist = adminassingment.Skip((pageindex - 1) * pagesize).Where(x => x.AssigentmentUpdate == 1).Take(pagesize).ToList();
            }
            else
            {
                 assignmentlist = adminassingment.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            }
            return assignmentlist;
        }

        public JsonResult Getpaginatiotabledataadmin(int pageindex, int pagesize, int  assignmentupdate)
        {
            List<AdminAssignmentModel> adminassingment = perpageshowdataadmin(pageindex, pagesize, assignmentupdate);
            var result = JsonConvert.SerializeObject(adminassingment);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Searchdataadmin(string serachvalue)
        {
            List<CategoryModel> categorylist = CategoryManager.SearchCategory(serachvalue);
            var result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // Assign Supplier

        public ActionResult AssignSupplier(int Id)
        {
            AdminViewModel assingadmin = new AdminViewModel();
            assingadmin.Product = AssignmentManager.GetSupplyProduct(Id);
            assingadmin.SupplierList = StaffSettingsManager.GetAllSupplier();
            assingadmin.SupplierAssignment = new SupplierAssignmentModel();
            return View("AssignSupplier", assingadmin);
        }
        [HttpPost]
        public ActionResult AssignSupplier(AdminViewModel assignment, ProductModel product)
        {
            AdminViewModel assingadmin = new AdminViewModel();
            if (assignment.SupplierAssignment.AssigentmentSupplierId > 0)
            {
                assignment.SupplierAssignment.ProductId = product.ProductId;
                assignment.SupplierAssignment.AssignDate = DateTime.Now;
                assignment.SupplierAssignment.AssignmentUpdate = 0;
                if (AssignmentManager.AddNewAssignmentSupplier(assignment.SupplierAssignment) > 0)
                {
                    ViewData["Message"] = "Your data have  been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have  not been Updated";
                }
            }
            else
            {
                assignment.SupplierAssignment.ProductId = assignment.Product.ProductId;
                assignment.SupplierAssignment.AssignDate = DateTime.Now;
                assignment.SupplierAssignment.AssignmentUpdate = 0;
                if (AssignmentManager.AddNewAssignmentSupplier(assignment.SupplierAssignment) > 0)
                {
                    ViewData["Message"] = "Your data have  been added";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have  not been added";
                }
            }
            assignment.ViewSupplierAssignmentList = perpageshowdataSupplier(1, 10, 0);
            assignment.totalpage = pagecountadmin(10);
            return View("ViewAllAssignSupplier", assignment);
        }
        public ActionResult ViewAllAssignSupplier()
        {
            AdminViewModel assignment = new AdminViewModel();
            assignment.ViewSupplierAssignmentList = AssignmentManager.GetAllAssignmentSupplier();
            // deliverycharge.deliverychargeList = perpageshowdata(1, 10);
            // deliverycharge.totalpage = pagecount(10);
            return View("ViewAllAssignSupplier", assignment);
        }
        public ActionResult MultiedeleteAssignSupplier(int[] multidelete)
        {
            int i = 0;
            if (multidelete != null)
            {
                foreach (int multid in multidelete)
                {
                    AssignmentManager.DeleteAssignmentSupplier(multid);
                    i++;
                }
            }
            AdminViewModel supplierassign = new AdminViewModel();
            if (multidelete.Length==i)
            {
                ViewData["Message"] = "Your data have  been deleted"; 
            }
            else
            {
                ViewData["Message"] = "Your data have  not been deleted";
            }
            supplierassign.ViewSupplierAssignmentList = perpageshowdataSupplier(1, 10, 0);
            supplierassign.totalpage = pagecountSupplier(10);
            return View("ViewAllAssignSupplier", supplierassign);
        }
        public ActionResult DeletedAssignSupplier(int id)
        {
            AdminViewModel assignment = new AdminViewModel();
            if (AssignmentManager.DeleteAssignmentSupplier(id))
            {
                ViewData["Message"] = "Your data have  been deleted";

            }
            else
            {
                ViewData["Message"] = "Your data have  not been deleted";
            }
            assignment.ViewSupplierAssignmentList = perpageshowdataSupplier(1, 10, 0);
            assignment.totalpage = pagecountSupplier(10);
            return View("ViewAllAssignSupplier", assignment);

        }
        public ActionResult GetSingleAssignSupplier(int id)
        {
            AdminViewModel assignment = new AdminViewModel();
            // deliverycharge.deliverycharge = DeliverySettingsManager.GetSingleDeliveryCost(id);
            //  deliverycharge.deliverychargeList = perpageshowdata(1, 10);
            //   deliverycharge.totalpage = pagecount(10);
            return View("ViewAllAssignSupplier", assignment);
        }
        public int pagecountSupplier(int perpagedata)
        {
            IEnumerable<ViewSupplierAssignmentModel> assingment = AssignmentManager.GetAllAssignmentSupplier();
            return Convert.ToInt32(Math.Ceiling(assingment.Count() / (double)perpagedata));
        }

        public List<ViewSupplierAssignmentModel> perpageshowdataSupplier(int pageindex, int pagesize,int assignmentupdate)
        {
            IEnumerable<ViewSupplierAssignmentModel> assingment = AssignmentManager.GetAllAssignmentSupplier();
            List<ViewSupplierAssignmentModel> SupplierAssign = new List<ViewSupplierAssignmentModel>();
            if (assignmentupdate == 1)
            {
                SupplierAssign= assingment.Skip((pageindex - 1) * pagesize).Where(x=>x.AssignmentUpdate==0).Take(pagesize).ToList();
            }
            else if (assignmentupdate == 2)
            {
                SupplierAssign = assingment.Skip((pageindex - 1) * pagesize).Where(x => x.AssignmentUpdate == 1).Take(pagesize).ToList();
            }
            else
            {
                SupplierAssign= assingment.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            }

            return SupplierAssign;
        }

        public JsonResult GetpaginatiotabledataSupplier(int pageindex, int pagesize,int assignmentupdate)
        {
            List<ViewSupplierAssignmentModel> deliverychargelist = perpageshowdataSupplier(pageindex, pagesize, assignmentupdate);
            var result = JsonConvert.SerializeObject(deliverychargelist);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Searchdata(string serachvalue)
        {
            List<CategoryModel> categorylist = CategoryManager.SearchCategory(serachvalue);
            var result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Assign Delivery Man
        public ActionResult AssignDeliveryMan(int Id)
        {
            AdminViewModel AssingDeliveryManAssignment = new AdminViewModel();
            AssingDeliveryManAssignment.Cart.Order = OrderManager.GetSingleOrderDetails(Id);
            AssingDeliveryManAssignment.Cart.OrderItem = OrderManager.GetSIngleOrderItem(Id);
            AssingDeliveryManAssignment.Cart.Payment = OrderManager.GetSInglePayment(Id);
            AssingDeliveryManAssignment.Cart.Shipment = OrderManager.GetSIngleShipment(Id);
            AssingDeliveryManAssignment.viewzone = DeliverySettingsManager.GetAllZone();
            return View("AssignDeliveryMan", AssingDeliveryManAssignment);
        }
        [HttpPost]
        public ActionResult AssignDeliveryMan(DeliveryManAssignmentModel assignment)
        {
            if (assignment.AssignmentDeliveryId > 0)
            {
                if (AssignmentManager.UpdateAssignmentDeliveryMan(assignment))
                {
                    ViewData["Message"] = "Your data have been Updated";
                }
                else
                {
                    ViewData["Message"] = "!!!! Error !!!!!!";
                }
            }
            else
            {
                if (AssignmentManager.AddNewAssignmentDeliveryMan(assignment) > 0)
                {
                    ViewData["Message"] = "Your data have been Added";
                }
                else
                {
                    ViewData["Message"] = "!!!! Error !!!!!!";
                }
            }
            return View("ViewAssignDeliveryMan");
        }
        public ActionResult DeleteAssignDeliveryMan(int id)
        {
            AdminViewModel AssingDeliveryManAssignment = new AdminViewModel();
            if (AssignmentManager.DeleteAssignmentDeliveryMant(id))
            {
                ViewData["Message"] = "Your data have been delete";
            }
            else
            {
                ViewData["Message"] = "!!!! Error !!!!!!";
            }
            return View("ViewAssignDeliveryMan");
        }
        public ActionResult ViewAssignDeliveryMan()
        {
            AdminViewModel AssingDeliveryManAssignment = new AdminViewModel();
            AssingDeliveryManAssignment.DeliverymanAssignmentList = AssignmentManager.GetAllAssignmentDeliveryMan();
            return View("AssignDeliveryMan", AssingDeliveryManAssignment);
        }
        public JsonResult GetAreaList(int zoneid)
        {
            List<Area> Arealist = DeliverySettingsManager.GetAllArea();
            var output = Arealist.Where(x => x.Placeid == zoneid).ToList();
            string result = JsonConvert.SerializeObject(output);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetDeliveryManList(int areaid)
        {
            List<DeliveryManModel> DeliveryManlist = StaffSettingsManager.GetAllDeliveryMan();
            var output = DeliveryManlist.Where(x => x.DeliveryManeAreaName == areaid).ToList();
            string result = JsonConvert.SerializeObject(output);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}