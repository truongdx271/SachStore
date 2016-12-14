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
using SachApp.Service.Dao;

namespace SachApp
{
    public partial class frmListSach : DevExpress.XtraEditors.XtraForm
    {
        public frmListSach()
        {
            InitializeComponent();
        }
        SachDao sachdao = new SachDao();

        void HienThi()
        {
            msdsSach.DataSource = sachdao.GetData();
            girdSach.ExpandAllGroups();
        }

        SachDao sDao = new SachDao();

        private void LoadListSach()
        {
            DataTable dt = new DataTable();
            dt = sDao.GetData();
            gridControl1.DataSource = dt;
            dgvListSach.ExpandAllGroups(); 
        }


        private void frmListSach_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            btnXoa.Enabled = false;
            LoadListSach();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            frmAddSach frm = new frmAddSach();
            frm.IsInsert = true;
            frm.LamMoi += new EventHandler(btnHienThi_Click);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadListSach();
=======
            HienThi();
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            HienThi();
>>>>>>> refs/remotes/origin/master
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông Báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int Ma = int.Parse(girdSach.GetRowCellValue(girdSach.FocusedRowHandle, girdSach.Columns[0]).ToString());
                    sachdao.Delete(Ma);
                    XtraMessageBox.Show("Đã xóa thành công");
                    HienThi();
                }
                catch
                {
                }
            }
        }

        
    }
}