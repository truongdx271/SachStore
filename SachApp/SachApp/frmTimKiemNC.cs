using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SachApp.Service.Models;
using SachApp.Service.Dao;

namespace SachApp
{
    public partial class frmTimKiemNC : DevExpress.XtraEditors.XtraForm
    {
        public frmTimKiemNC()
        {
            InitializeComponent();
        }
        public void FillKetQuaTimKiemGrid()
        {
            ThongTinTimKiem timkiem = new ThongTinTimKiem();
            if(ckbSach.Checked)
            {
                timkiem.TENSACH =txtSach.Text;
            }
            if (ckbTacGia.Checked)
            {
                timkiem.TENTG = txtTacGia.Text;
            }
            if (ckbNXB.Checked)
            {
                timkiem.MANXB = Convert.ToInt32(cbNXB.EditValue);
            }
            if(ckbTheLoai.Checked)
            {
                timkiem.MATHELOAI = Convert.ToInt32(cbTheLoai.EditValue);
            }
            ThongTinTimKiemDao timkiemDao = new ThongTinTimKiemDao();
            if(ckbNamXb.Checked)
            {
                timkiem.NAMXB = Int32.Parse(cbNamXB.Text);
            }
            if(ckbGia.Checked)
            {
                timkiem.giaMAX = Decimal.Parse(txtGiaMax.Text);
                timkiem.giaMIN = Decimal.Parse(txtGiaMin.Text);
            }  
            gridControlTK.DataSource = timkiemDao.GetData(timkiem);
        }
       
        private void frmTimKiemNC_Load(object sender, EventArgs e)
        {
            FillKetQuaTimKiemGrid();
            NhaXuatBanDao nxbDao = new NhaXuatBanDao();
            cbNXB.Properties.DataSource = nxbDao.GetData();
            cbNXB.Properties.DisplayMember = "TENNXB";
            cbNXB.Properties.ValueMember = "MANXB";

            TheLoaiDao theloaiDao = new TheLoaiDao();
            cbTheLoai.Properties.DataSource = theloaiDao.GetData();
            cbTheLoai.Properties.DisplayMember = "TENTHELOAI";
            cbTheLoai.Properties.ValueMember = "MATHELOAI";

            SachDao sachDao = new SachDao();
            cbNamXB.Properties.DataSource = sachDao.GetData();
            cbNamXB.Properties.DisplayMember = "NAMXUATBAN";
            cbNamXB.Properties.ValueMember = "MASACH";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FillKetQuaTimKiemGrid();
        }
    }
}