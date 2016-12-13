using SachApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Dao
{
    public class NhaPhanPhoiDao : dbContext
    {
        public DataTable GetNPP()
        {
            return base.GetData("NPP_GETALL", null);
        }

        public int Insert(NhaPhanPhoi obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("TENNPP",obj.TENNPP),
                new SqlParameter("DIACHI",obj.DIACHI),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("FAX",obj.FAX),
                new SqlParameter("EMAIL",obj.EMAIL)
            };
            return base.ExecuteSQL("NPP_INSERT", para);
        }

    }
}
