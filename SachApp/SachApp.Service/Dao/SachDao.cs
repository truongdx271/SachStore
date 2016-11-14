
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
    public class SachDao : dbContext
    {
        public DataTable GetData()
        {
            return base.GetData("SACH_SELECT_ALL", null);
        }
        public DataTable GetDataByID(string MASACH)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MASACH", MASACH)
            };
            return base.GetData("SACH_SELECT_BYID", para);
        }
        public int Insert(Sach obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("TENSACH",obj.TENSACH),
                new SqlParameter("MATHELOAI",obj.MATHELOAI),
                new SqlParameter("NAMXUATBAN",obj.NAMXUATBAN),
                new SqlParameter("GIAMUA",obj.GIAMUA),
                new SqlParameter("GIABAN",obj.GIABAN),
                new SqlParameter("SOLUONGKHO",obj.SOLUONGKHO),
                new SqlParameter("MANXB",obj.MANXB),
                new SqlParameter("MOTA",obj.MOTA)

            };
            return base.ExecuteSQL("SACH_INSERT", para);
        }

        public int Update(Sach obj)
        {
            SqlParameter[] para =
           {
                new SqlParameter("TENSACH",obj.TENSACH),
                new SqlParameter("MATHELOAI",obj.MATHELOAI),
                new SqlParameter("NAMXUATBAN",obj.NAMXUATBAN),
                new SqlParameter("GIAMUA",obj.GIAMUA),
                new SqlParameter("GIABAN",obj.GIABAN),
                new SqlParameter("SOLUONGKHO",obj.SOLUONGKHO),
                new SqlParameter("MANXB",obj.MANXB),
                new SqlParameter("MOTA",obj.MOTA)
            };
            return base.ExecuteSQL("SACH_UPDATE", para);
        }
        public int Delete(string MASACH)
        {
            SqlParameter[] para =
               {
                new SqlParameter("MASACH", MASACH)
            };
            return base.ExecuteSQL("SACH_DELETE", para);
        }

    }
}
