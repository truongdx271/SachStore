﻿using SachApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Dao
{
    public class TacGiaDao : dbContext
    {
        public DataTable GetData()
        {
            return base.GetData("TACGIA_GETALL", null);
        }
        public int Delete(int Ma)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MATG",Ma)
            };
            return base.ExecuteSQL("TACGIA_DELETE", para);
        }
        public int Insert(TacGia obj)
        {
            SqlParameter[] para =
            {
                
                new SqlParameter("TENTG",obj.TENTG),
                new SqlParameter("GIOITHIEU",obj.GIOITHIEU),
                new SqlParameter("DIACHI",obj.DIACHI),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("EMAIL",obj.EMAIL),
            };
            return base.ExecuteSQL("TACGIA_INSERT", para);
        }
        public int Update(TacGia obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MATG",obj.MATG),
                new SqlParameter("TENTG",obj.TENTG),
                new SqlParameter("DIACHI",obj.DIACHI),
                new SqlParameter("EMAIL",obj.EMAIL),
                new SqlParameter("DIENTHOAI",obj.DIENTHOAI),
                new SqlParameter("GIOITHIEU",obj.GIOITHIEU),
            };
            return base.ExecuteSQL("TACGIA_UPDATE", para);
        }
    }
}
