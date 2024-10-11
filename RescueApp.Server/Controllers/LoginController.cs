using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using RescueApp.Server.Models;
using System.IO;


namespace RescueApp.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost, ActionName("insertuser")]
        [Route("insertuser")]
        public JsonResult Insertuser(users usr)
        {
            string StoredProc2 = "exec InsertUser " +
                    "@UserName = '" + usr.UserName + "'," +
                    "@Password = '" + usr.Password + "'," +
                    "@Email= '" + usr.Email + "'," +
                    "@UserType= '" + usr.UserRole + "'";

            String permission;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DevConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(StoredProc2, myCon))
                {
                    permission = (String)myCommand.ExecuteScalar();
                    myCon.Close();
                }
            }

            return new JsonResult(permission);
        }






    }
}
