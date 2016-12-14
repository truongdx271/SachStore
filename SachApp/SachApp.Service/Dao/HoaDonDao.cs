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
    public class HoaDonDao : dbContext
    {
        public DataTable GetData()
        {
            return base.GetData("HOADON_GETALL", null);
        }
        public DataTable GetDataByID(int MAHD)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MAHD", MAHD)
            };
            return base.GetData("HOADON_GET_BY_MAHD", para);
        }

        public DataTable GetNew()
        {
            return base.GetData("HOADON_GETNEW", null);
        }

        public int Insert(HoaDon obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MANV",obj.MANV),
                new SqlParameter("NGAYLAP",obj.NGAYLAP),
                new SqlParameter("MAKH",obj.MAKH),
                new SqlParameter("TONGTIEN",obj.TONGTIEN)
            };
            return base.ExecuteSQL("HOADON_INSERT", para);
        }

        public int Update(HoaDon obj)
        {
            SqlParameter[] para =
           {
                new SqlParameter("MAHD",obj.MAHD),
                new SqlParameter("TONGTIEN",obj.TONGTIEN)
            };
            return base.ExecuteSQL("HOADON_UPDATE", para);
        }

        public int UpdateKH(HoaDon obj)
        {
            SqlParameter[] para =
           {
                new SqlParameter("MAHD",obj.MAHD),
                new SqlParameter("MAKH",obj.MAKH)
            };
            return base.ExecuteSQL("HOADON_UPDATE_KH", para);
        }


        public int Delete(int MAHD)
        {
            SqlParameter[] para =
               {
                new SqlParameter("MAHD", MAHD)
            };
            return base.ExecuteSQL("HOADON_DELETE", para);
        }
    }
}
