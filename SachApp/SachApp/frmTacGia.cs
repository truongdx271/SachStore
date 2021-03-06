﻿using System;
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
using SachApp.Service.Models;

namespace SachApp
{
    public partial class frmTacGia : DevExpress.XtraEditors.XtraForm
    {
        public frmTacGia()
        {
            InitializeComponent();
        }
        TacGiaDao tacgiadao = new TacGiaDao();
        TacGia tacgia = new TacGia();
        bool IsInsert = false;

        public void HienThi()
        {
            msdsTacGia.DataSource = tacgiadao.GetData();
        }
        void KhoaDieuKhien()
        {
            txtTenTG.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            txtGioiThieu.Enabled = false;
            txtEmail.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }
        void MoKhoaDieuKhien()
        {
            txtTenTG.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtGioiThieu.Enabled = true;
            txtEmail.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }
        private void frmTacGia_Load(object sender, EventArgs e)
        {
            HienThi();
            KhoaDieuKhien();
        }
        void XoaText()
        {
            txtTenTG.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtGioiThieu.Text = string.Empty;
            txtEmail.Text = string.Empty;
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
                    tacgiadao.Delete(int.Parse(gridTacGia.GetRowCellValue(gridTacGia.FocusedRowHandle, gridTacGia.Columns[0]).ToString()));
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
            tacgia.MATG = int.Parse(gridTacGia.GetRowCellValue(gridTacGia.FocusedRowHandle, gridTacGia.Columns[0]).ToString());
            tacgia.TENTG = txtTenTG.Text;
            tacgia.DIACHI = txtDiaChi.Text;
            tacgia.DIENTHOAI = txtDienThoai.Text;
            tacgia.GIOITHIEU = txtGioiThieu.Text;
            tacgia.EMAIL = txtEmail.Text;
            if (IsInsert == true)
            {
                //insert
                tacgiadao.Insert(tacgia);
                XtraMessageBox.Show("Thêm thành công!");
                HienThi();
                XoaText();
                KhoaDieuKhien();
            }
            else
            {
                //update
                tacgiadao.Update(tacgia);
                XtraMessageBox.Show("Sửa thành công!");
                HienThi();
                XoaText();
                KhoaDieuKhien();
            }
        }

        private void msdsTacGia_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                txtTenTG.Text = gridTacGia.GetRowCellValue(gridTacGia.FocusedRowHandle, gridTacGia.Columns[1]).ToString();
                txtDiaChi.Text = gridTacGia.GetRowCellValue(gridTacGia.FocusedRowHandle, gridTacGia.Columns[2]).ToString();
                txtDienThoai.Text = gridTacGia.GetRowCellValue(gridTacGia.FocusedRowHandle, gridTacGia.Columns[3]).ToString();
                txtEmail.Text = gridTacGia.GetRowCellValue(gridTacGia.FocusedRowHandle, gridTacGia.Columns[4]).ToString();
                txtGioiThieu.Text = gridTacGia.GetRowCellValue(gridTacGia.FocusedRowHandle, gridTacGia.Columns[5]).ToString();
            }
            catch
            {

            }
        }
    }
}