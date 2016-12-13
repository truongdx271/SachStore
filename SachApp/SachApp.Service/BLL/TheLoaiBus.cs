using SachApp.Service.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.BLL
{
    public class TheLoaiBus
    {
        TheLoaiDao dao = new TheLoaiDao();
        public DataTable GetTheLoai()
        {
            return dao.GetTheLoai();
        }
    }
}
