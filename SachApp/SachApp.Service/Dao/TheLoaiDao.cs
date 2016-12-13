using SachApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Dao
{
    public class TheLoaiDao : dbContext
    {
        public DataTable GetTheLoai()
        {
            return base.GetData("THELOAI_GETALL", null);
        }
    }
}
