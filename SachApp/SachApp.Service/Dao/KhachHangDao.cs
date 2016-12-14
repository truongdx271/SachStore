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
    public class KhachHangDao : dbContext
    {
        public DataTable GetKH()
        {
            return base.GetData("KHACHHANG_GETALL", null);
        }

        public int Insert(KhachHang obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("TENKH",obj.TENKH),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("DIACHI",obj.DIACHI),
            };
            return base.ExecuteSQL("KHACHHANG_INSERT", para);
        }
    }
}
