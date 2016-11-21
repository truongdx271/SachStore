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

        private void frmListSach_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            HienThi();
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