using ASPANETLOGINIDENTITY.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Dapper;

namespace ASPANETLOGINIDENTITY.Controllers
{
   
    public class RolesController : Controller
    {
        SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

        // GET: Roles
        public ActionResult Index()
        {
            return View(GetDataRoles());
        }
        public async Task<ActionResult>GetDataRoles()//mengambil data dalam tabels
        {
            var result = await sqlconnection.QueryAsync<RoleVm>("EXEC SP_Retrieve_Role");
            return Json( new { data = result }, JsonRequestBehavior.AllowGet);
            
        }
        public async Task<ActionResult>Create(RoleVm roleVM)
        {
            var affectedRows = await sqlconnection.ExecuteAsync("EXEC SP_Insert_Role @name", new { Name = roleVM.Name });
            return Json(new { data = affectedRows}, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Details( int id)
        {
            var result = await sqlconnection.QueryAsync<RoleVm>(" EXEC SP_Retrieve_By_Id @id", new { Id = id });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Edit(RoleVm roleVM)
        {
            var affectedRows = await sqlconnection.ExecuteAsync("EXEC SP_Update_Role @id, @name", new { Name = roleVM.Name , Id = roleVM.Id});
            return Json(new { data = affectedRows}, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await sqlconnection.ExecuteAsync("EXEC SP_Delete_Role @id, @name", new {Id = id });
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }
    }
}