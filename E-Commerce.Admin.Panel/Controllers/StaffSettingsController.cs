using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class StaffSettingsController : Controller
    {
        // GET: StaffSettings
        public ActionResult AddNewDeliveryMan()
        {
            AdminViewModel deliveryman = new AdminViewModel();
            deliveryman.DeliveryMane = new DeliveryManModel();
            deliveryman.viewzone = DeliverySettingsManager.GetAllZone();
            deliveryman.User = new UserModel();
            return View("AddNewDeliveryMan", deliveryman);
        }
        [HttpPost]
        public ActionResult AddNewDeliveryMan(AdminViewModel deliveryman, HttpPostedFileBase File)
        {
            if (deliveryman.DeliveryMane.DeliverManId > 0)
            {
                if(File.ContentLength>0)
                {
                    deliveryman.DeliveryMane.DeliveryManeProfilePic = UploadImage(File);
                }
                UserModel UserUpdate = new UserModel();
                UserUpdate.UserId = deliveryman.DeliveryMan.UserId;
                UserUpdate.UserName = deliveryman.DeliveryMan.UserName;
                UserUpdate.UserPassword = deliveryman.DeliveryMan.UserPassword;
                if (StaffSettingsManager.UpdateDeliveryMan(deliveryman.DeliveryMane) && UserSettingManager.UpdateUser(UserUpdate))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            else
            {
              
                deliveryman.User.UserType = "Delivery Man";
                deliveryman.DeliveryMane.DeliveryManeProfilePic = UploadImage(File);
                deliveryman.User.UserPassword = PasswordEncrypt(deliveryman.User.UserPassword);
                deliveryman.User.UserTotalLogin = 0;
                deliveryman.User.UserLastLogin = DateTime.Now;
                int UserId = Convert.ToInt32(UserSettingManager.AddNewUser(deliveryman.User));
                deliveryman.DeliveryMane.UserId = UserId;
                if(StaffSettingsManager.AddNewDeliveryMan(deliveryman.DeliveryMane) > 0)
                {
                    ViewData["Message"] = "Your data have been Added";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Added";
                }
            }
            return View("AddNewDeliveryMan", deliveryman);
        }
        public ActionResult ViewAllDeliveryMan()
        {
            AdminViewModel deliveryman = new AdminViewModel();
            deliveryman.DeliveryManeList = StaffSettingsManager.GetAllDeliveryMan();
            List<DeliveryManModel> deliverymanlist = new List<DeliveryManModel>();
            foreach (DeliveryManModel admindycrept in deliveryman.DeliveryManeList)
            {
                var password = PasswordDencrypt(admindycrept.UserPassword);
                deliveryman.DeliveryMan = admindycrept;
                deliveryman.DeliveryMan.UserPassword = password;
                deliverymanlist.Add(deliveryman.DeliveryMan);
            }
            deliveryman.DeliveryManeList = deliverymanlist;
            return View("ViewAllDeliveryMan", deliveryman);
        }
        public ActionResult GetSingleDeliveryMan(int id)
        {
            AdminViewModel deliveryman = new AdminViewModel();
            deliveryman.DeliveryMane = StaffSettingsManager.GetSingleDeliveryMan(id);
            deliveryman.DeliveryMane.UserPassword = PasswordDencrypt(deliveryman.DeliveryMane.UserPassword);
            return View("AddNewDeliveryMan", deliveryman);
        }
        public ActionResult DeleteDeliveryMan(int id, int userid)
        {
            AdminViewModel deliveryman = new AdminViewModel();
            bool check = UserSettingManager.DeleteUser(userid);
            if (StaffSettingsManager.DeleteDeliveryMan(id) && check== true)
            {
                ViewData["Message"] = "Your data have been Deleted";
            }
            else
            {
                ViewData["Message"] = "Your data have not been Deleted";
            }
            deliveryman.DeliveryManeList = StaffSettingsManager.GetAllDeliveryMan();
            List<DeliveryManModel> deliverymanlist = new List<DeliveryManModel>();
            foreach (var admindycrept in deliveryman.DeliveryManeList)
            {
                var password = PasswordDencrypt(admindycrept.UserPassword);
                deliveryman.DeliveryMane = admindycrept;
                deliveryman.DeliveryMane.UserPassword = password;
                deliverymanlist.Add(deliveryman.DeliveryMane);
            }
            deliveryman.DeliveryManeList = deliverymanlist;
            return View("ViewAllDeliveryMan", deliveryman);
        }
        public JsonResult GetSelectedArea(int zoneid)
        {
            List<Area> categorylist = DeliverySettingsManager.GetSingleZoneAllArea(zoneid);
            string result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchdataDeliveryMan(string serachvalue)
        {
            List<CategoryModel> categorylist = CategoryManager.SearchCategory(serachvalue);
            var result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // supplier
        public ActionResult AddNewSupplier()
        {
            AdminViewModel supplier = new AdminViewModel();
            supplier.Supplier = new SupplierModel();
            supplier.User = new UserModel();
            supplier.CategoryList = CategoryManager.GetAllCategory();
            return View("AddNewSupplier", supplier);
        }
        [HttpPost]
        public ActionResult AddNewSupplier(SupplierModel Supplier, UserModel User , HttpPostedFileBase File)
        {
            if (Supplier.SupplierId > 0)
            {
                if (File.ContentLength > 0)
                {
                    Supplier.SupplierProfilePic = UploadImage(File);
                }
                UserModel UserUpdate = new UserModel();
                UserUpdate.UserId = Supplier.UserId;
                UserUpdate.UserName = Supplier.UserName;
                UserUpdate.UserPassword = Supplier.UserPassword;
                UserUpdate.UserPassword = PasswordEncrypt(UserUpdate.UserPassword);
                if (StaffSettingsManager.UpdateSupplier(Supplier) && UserSettingManager.UpdateUser(UserUpdate))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            else
            {
                AdminViewModel Suppliers = new AdminViewModel();
                User.UserType = "Supplier";
                Supplier.SupplierProfilePic = UploadImage(File);
                User.UserPassword = PasswordEncrypt(User.UserPassword);
                User.UserTotalLogin = 0;
                User.UserLastLogin = DateTime.Now;
                int UserId = Convert.ToInt32(UserSettingManager.AddNewUser(User));
                Supplier.UserId = UserId;
                Supplier.TotalAssngComplete = 0;
                if (StaffSettingsManager.AddNewSupplier(Supplier) > 0)
                {
                    ViewData["Message"] = "Your data have been Added";
                    ModelState.Clear();

                    Suppliers.SupplierList = StaffSettingsManager.GetAllSupplier();
                    return View("ViewAllSupplier", Suppliers);
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Added";
                    return View("AddNewSupplier", Supplier);
                }
            }
            return View("AddNewSupplier");
        }
        public ActionResult ViewAllSupplier()
        {
            AdminViewModel Supplier = new AdminViewModel();
            Supplier.SupplierList = StaffSettingsManager.GetAllSupplier();
            List<SupplierModel> supplier = new List<SupplierModel>();
            foreach (SupplierModel admindycrept in Supplier.SupplierList)
            {
                var password = PasswordDencrypt(admindycrept.UserPassword);
                Supplier.Supplier = admindycrept;
                Supplier.Supplier.UserPassword = password;
                supplier.Add(Supplier.Supplier);
            }
            Supplier.SupplierList = supplier;
            return View("ViewAllSupplier", Supplier);
        }
        public ActionResult GetSingleSupplier(int id)
        {
            AdminViewModel Supplier = new AdminViewModel();
            Supplier.Supplier = StaffSettingsManager.GetSingleSupplier(id);
            Supplier.CategoryList = CategoryManager.GetAllCategory();
            Supplier.Supplier.UserPassword = PasswordDencrypt(Supplier.Supplier.UserPassword);
            return View("AddNewSupplier", Supplier);
        }
        public ActionResult DeleteSupplier(int id, int userid)
        {
            AdminViewModel Supplier = new AdminViewModel();
            var deleteduser = UserSettingManager.DeleteUser(userid);
            Supplier.SupplierList = StaffSettingsManager.GetAllSupplier();
            List<SupplierModel> supplier = new List<SupplierModel>();
            foreach (var admindycrept in Supplier.SupplierList)
            {
                var password = PasswordDencrypt(admindycrept.UserPassword);
                Supplier.Supplier = admindycrept;
                Supplier.Supplier.UserPassword = password;
                supplier.Add(Supplier.Supplier);
            }
            Supplier.SupplierList = supplier;
            if(StaffSettingsManager.DeleteSupplier(id) && deleteduser == true)
            {
                ViewData["Message"] = "Your data have been Deleted";
            }
            else
            {
                ViewData["Message"] = "Your data have not been Deleted";
            }
            return View("ViewAllSupplier", Supplier);
        }
        public JsonResult SearchdataSupplier(string serachvalue)
        {
            List<CategoryModel> categorylist = CategoryManager.SearchCategory(serachvalue);
            var result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // Admin
        public ActionResult AddNewAdmin()
        {
            AdminViewModel admin = new AdminViewModel();
            admin.Admin = new AdminModel();
            admin.User = new UserModel();
            return View("AddNewAdmin",admin);
        }
        [HttpPost]
        public ActionResult AddNewAdmin(AdminModel admin,UserModel User, HttpPostedFileBase File)
        {
            if (admin.AdminId > 0)
            {
                if (File.ContentLength > 0)
                {
                    admin.AdminProfilePic = UploadImage(File);
                }
                UserModel UserUpdate = new UserModel();
                UserUpdate.UserId = admin.UserId;
                UserUpdate.UserName = admin.UserName;
                UserUpdate.UserPassword = admin.UserPassword;
                UserUpdate.UserPassword = PasswordEncrypt(UserUpdate.UserPassword);
                if (StaffSettingsManager.UpdateAdmin(admin) && UserSettingManager.UpdateUser(UserUpdate))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            else
            {
                User.UserType = "Admin";
                admin.AdminProfilePic = UploadImage(File);
                User.UserPassword = PasswordEncrypt(User.UserPassword);
                User.UserTotalLogin = 0;
               User.UserLastLogin = DateTime.Now;
                int UserId = Convert.ToInt32(UserSettingManager.AddNewUser(User));
                admin.UserId = UserId;
                if(StaffSettingsManager.AddNewAdmin(admin)>0 && UserId>0)
                {
                    ViewData["Message"] = "Your data have been Added";
                    ModelState.Clear();
                    AdminViewModel adminitem = new AdminViewModel();
                    adminitem.AdminList = StaffSettingsManager.GetAllAdmin();
                    List<AdminModel> adminlist = new List<AdminModel>();
                    foreach (AdminModel admindycrept in adminitem.AdminList)
                    {
                        var password = PasswordDencrypt(admindycrept.UserPassword);
                        adminitem.Admin = admindycrept;
                        adminitem.Admin.UserPassword = password;
                        adminlist.Add(adminitem.Admin);
                    }
                    adminitem.AdminList = adminlist;
                    return View("ViewAllAdmin", admin);
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Added";
                    AdminViewModel adminitem = new AdminViewModel();
                    adminitem.Admin = admin;
                    adminitem.User = User;
                    return View("AddNewAdmin", adminitem);
                }
            }

            return View("ViewAllAdmin");
        }
        public ActionResult ViewAllAdmin()
        {
            AdminViewModel admin = new AdminViewModel();
            admin.AdminList = StaffSettingsManager.GetAllAdmin();
            List<AdminModel> adminlist = new List<AdminModel>();
            foreach (AdminModel admindycrept in admin.AdminList)
            {
                var password= PasswordDencrypt(admindycrept.UserPassword);
                admin.Admin = admindycrept;
                admin.Admin.UserPassword = password;
                adminlist.Add(admin.Admin);
            }
            admin.AdminList = adminlist; 
            return View("ViewAllAdmin", admin);
        }
        public ActionResult GetSingleAdmin(int id)
        {
            AdminViewModel admin = new AdminViewModel();
            admin.Admin = StaffSettingsManager.GetSingleAdmin(id);
            admin.Admin.UserPassword = PasswordDencrypt(admin.Admin.UserPassword);
            return View("AddNewAdmin", admin);
        }
        public ActionResult DeleteAdmin(int id, int userid)
        {
            AdminViewModel admin = new AdminViewModel();
            var deleteduser = UserSettingManager.DeleteUser(userid);
            admin.AdminList = StaffSettingsManager.GetAllAdmin();
            List<AdminModel> adminlist = new List<AdminModel>();
            foreach (var admindycrept in admin.AdminList)
            {
                admin.Admin.UserPassword = PasswordDencrypt(admindycrept.UserPassword);
                adminlist.Add(admin.Admin);
            }
            admin.AdminList = adminlist;
            if (StaffSettingsManager.DeleteAdmin(id) && deleteduser== true)
            {
                ViewData["Message"] = "Your data have been Deleted";
            }
            else
            {
                ViewData["Message"] = "Your data have not been Deleted";
            }
          
            return View("ViewAllAdmin", admin);
        }
        public JsonResult SearchdataAdmin(string serachvalue)
        {
            List<CategoryModel> categorylist = CategoryManager.SearchCategory(serachvalue);
            var result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // common feautures
        public string PasswordEncrypt(string Password)
        {
            string encryptedpassword;
            if (!string.IsNullOrEmpty(Password))
            {
                byte[] convertpasswordbyte = ASCIIEncoding.Unicode.GetBytes(Password);
                encryptedpassword = Convert.ToBase64String(convertpasswordbyte);
            }
            else
            {
                encryptedpassword = "";
            }
            return encryptedpassword;
        }
        public string PasswordDencrypt(string Password)
        {
            string encryptedpassword;
            if (!string.IsNullOrEmpty(Password))
            {
                // parse base64 string
                byte[] encryptpassword = Convert.FromBase64String(Password);
                //decrypt data
                encryptedpassword = Encoding.Unicode.GetString(encryptpassword);
            }
            else
            {
                encryptedpassword = "";
            }
            return encryptedpassword;
        }
        public string UploadImage(HttpPostedFileBase CategoryImage)
        {
            string savepath = "";
            string imageurl, imagepath, filepath;
            if (CategoryImage.ContentLength > 0)
            {
                var filename = Path.GetFileName(Guid.NewGuid() + CategoryImage.FileName);
                imagepath = Server.MapPath("~/Image/");
                filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/");
                if (imagepath == null)
                {
                    Directory.CreateDirectory(imagepath);
                }
                imageurl = Path.Combine(imagepath, filename);
                savepath = "/Image/" + filename;
                CategoryImage.SaveAs(imageurl);
            }
            return savepath;
        }

        public JsonResult CheckUserId(string username)
        {
            bool checkedvalue;
            if (UserSettingManager.CheckUserName(username))
            {
                checkedvalue = true;
            }
            else
            {
                checkedvalue = false;
            }
            return Json(checkedvalue, JsonRequestBehavior.AllowGet);
        }
    }
}