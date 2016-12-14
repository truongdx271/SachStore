﻿using SachApp.Service.Dao;
using SachApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.BLL
{
    public class KhachHangBus
    {
        KhachHangDao dao = new KhachHangDao();
        public DataTable GetKH()
        {
            return dao.GetKH();
        }
        public int Insert(KhachHang obj)
        {
            return dao.Insert(obj);
        }
    }
}
