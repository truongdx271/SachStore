using SachApp.Service.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.BLL
{
    public class TacGiaBus
    {
        TacGiaDao dao = new TacGiaDao();
        public DataTable GetTacGia()
        {
            return dao.GetTacGia();
        }
    }
}
