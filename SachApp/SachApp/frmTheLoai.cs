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
    public partial class frmTheLoai : DevExpress.XtraEditors.XtraForm
    {
        public frmTheLoai()
        {
            InitializeComponent();
        }
        TheLoai theloai = new TheLoai();
        TheLoaiDao theloaidao = new TheLoaiDao();
        bool IsInsert = false;

        void KhoaDieuKhien()
        {
            txtTenTL.Enabled = false;
            txtMota.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }
        void MoKhoaDieuKhien()
        {
            
            txtTenTL.Enabled = true;
            txtMota.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        void XoaText()
        {
            txtTenTL.Text = string.Empty;
            txtMota.Text = string.Empty;
        }

        public void HienThi()
        {
            msdsTheLoai.DataSource = theloaidao.GetData();
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaText();
            MoKhoaDieuKhien();
            IsInsert = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MoKhoaDieuKhien();
            IsInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông Báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    theloaidao.Delete(int.Parse(gridTheLoai.GetRowCellValue(gridTheLoai.FocusedRowHandle, gridTheLoai.Columns[1]).ToString()));
                    XtraMessageBox.Show("Đã xóa thành công");
                    XoaText();
                    KhoaDieuKhien();
                    HienThi();
                }
                catch
                {
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            theloai.MATHELOAI = int.Parse(gridTheLoai.GetRowCellValue(gridTheLoai.FocusedRowHandle, gridTheLoai.Columns[0]).ToString());
            theloai.TENTHELOAI = txtTenTL.Text;
            theloai.MOTA = txtMota.Text;
            if (IsInsert == true)
            {
                //insert
                theloaidao.Insert(theloai);
                XtraMessageBox.Show("Thêm thành công!");
                HienThi();
                XoaText();
                KhoaDieuKhien();
            }
            else
            {
                //update
                theloaidao.Update(theloai);
                XtraMessageBox.Show("Sửa thành công!");
                HienThi();
                XoaText();
                KhoaDieuKhien();
            }
        }

        private void msdsTheLoai_Click(object sender, EventArgs e)
        {
            txtTenTL.Text = gridTheLoai.GetRowCellValue(gridTheLoai.FocusedRowHandle, gridTheLoai.Columns[1]).ToString();
            txtMota.Text = gridTheLoai.GetRowCellValue(gridTheLoai.FocusedRowHandle, gridTheLoai.Columns[2]).ToString();
        }
    }
 }