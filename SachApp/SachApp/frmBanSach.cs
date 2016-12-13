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
using SachApp.Service.BLL;
using DevExpress.XtraGrid.Columns;

namespace SachApp
{
    public partial class frmBanSach : DevExpress.XtraEditors.XtraForm
    {
        public frmBanSach()
        {
            InitializeComponent();
        }

        SachBus sBus = new SachBus();
        KhachHangBus khBus = new KhachHangBus();
        HoaDonBus hdBus = new HoaDonBus();
        ChiTietHoaDonBus cthdBus = new ChiTietHoaDonBus();
        DataTable dtKH = new DataTable();
        DataTable dtHD = new DataTable();
        HoaDon hdObj = new HoaDon();

        void KhoaDieuKhien()
        {
            txtTenNhanVien.Enabled = false;
            dENgayLap.Enabled = false;
            luKhachHang.Enabled = false;

            btnAddKhachHang.Enabled = false;
            btnTinhTien.Enabled = false;
            btnIn.Enabled = false;
            btnThemMoi.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }

        void MoKhoaDieuKhien()
        {
            txtTenNhanVien.Enabled = false;
            dENgayLap.Enabled = false;
            luKhachHang.Enabled = true;

            btnAddKhachHang.Enabled = true;
            btnTinhTien.Enabled = true;
            btnIn.Enabled = true;
            btnThemMoi.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
        }
        void XoaText()
        {
            dENgayLap.Text = string.Empty;
        }

        private void frmBanSach_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();

            DataTable dt = sBus.GetData();
            gridListSach.DataSource = dt;
            dgvListSach.ExpandAllGroups();


        }

        private void LoadKhachHang(DataTable dt)
        {
            luKhachHang.Properties.DataSource = dt;
            luKhachHang.Properties.ValueMember = "MAKH";
            luKhachHang.Properties.DisplayMember = "TENKH";
            luKhachHang.ItemIndex = dt.Rows.Count - 1;
        }

        private void LoadHoaDon()
        {
            dtHD = cthdBus.GetData(hdObj.MAHD);
            gridListHoaDon.DataSource = dtHD;
            gridListHoaDon.ForceInitialize();
        }




        private void btnAddKhachHang_Click(object sender, EventArgs e)
        {
            frmAddKhachHang frm = new frmAddKhachHang();
            frm.ShowInTaskbar = false;
            frm.getData = new frmAddKhachHang.getDataSoucre(LoadKhachHang);
            frm.ShowDialog();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            MoKhoaDieuKhien();
            dENgayLap.Text = DateTime.Now.ToString();

            dtKH = khBus.GetKH();
            LoadKhachHang(dtKH);
            luKhachHang.ItemIndex = -1;

            hdObj.NGAYLAP = DateTime.Parse(dENgayLap.Text.ToString());
            hdObj.MANV = 1;
            hdObj.MAKH = int.Parse(luKhachHang.EditValue.ToString());
            hdObj.TONGTIEN = 0;
            hdBus.Insert(hdObj);
            hdObj = hdBus.GetNewHoaDon();

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            hdObj.TONGTIEN = decimal.Parse(dgvListHoaDon.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString());
            hdBus.Update(hdObj);
            gridListHoaDon.DataSource = null;
            KhoaDieuKhien();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvListSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void gridListSach_Click(object sender, EventArgs e)
        {
            //lbTenSach.Text=dgvListSach.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            //lbTenSach.Text = dgvListSach.GetRowCellValue(dgvListSach.FocusedRowHandle, dgvListSach.Columns["TENSACH"]).ToString();
            //lbDonGia.Text = dgvListSach.GetRowCellValue(dgvListSach.FocusedRowHandle, dgvListSach.Columns["GIABAN"]).ToString();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void dgvListSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            lbTenSach.Text = dgvListSach.GetFocusedDataRow()["TENSACH"].ToString();
            lbDonGia.Text = dgvListSach.GetFocusedDataRow()["GIABAN"].ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon cthdObj = new ChiTietHoaDon();
            cthdObj.MAHD = hdObj.MAHD;
            cthdObj.MASACH = int.Parse(dgvListSach.GetFocusedDataRow()["MASACH"].ToString());
            cthdObj.GIASACH = decimal.Parse(dgvListSach.GetFocusedDataRow()["GIABAN"].ToString());
            cthdObj.SOLUONG = int.Parse(spSoLuong.Text);
            cthdObj.THANHTIEN = int.Parse(spSoLuong.Text) * decimal.Parse(dgvListSach.GetFocusedDataRow()["GIABAN"].ToString());

            cthdBus.Insert(cthdObj);
            LoadHoaDon();
        }

        private void dgvListHoaDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(gridListHoaDon.DataSource != null)
            {
                lbTenSach.Text = dgvListHoaDon.GetFocusedDataRow()["TENSACH"].ToString();
                lbDonGia.Text = dgvListHoaDon.GetFocusedDataRow()["GIASACH"].ToString();
                spSoLuong.Text = dgvListHoaDon.GetFocusedDataRow()["SOLUONG"].ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon cthdObj = new ChiTietHoaDon();
            cthdObj.MAHD = hdObj.MAHD;
            cthdObj.MASACH = int.Parse(dgvListHoaDon.GetFocusedDataRow()["MASACH"].ToString());
            cthdObj.GIASACH = decimal.Parse(dgvListHoaDon.GetFocusedDataRow()["GIASACH"].ToString());
            cthdObj.SOLUONG = int.Parse(spSoLuong.Text);
            cthdObj.THANHTIEN = int.Parse(spSoLuong.Text) * decimal.Parse(dgvListHoaDon.GetFocusedDataRow()["GIASACH"].ToString());

            cthdBus.Update(cthdObj);

            LoadHoaDon();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maSach = int.Parse(dgvListHoaDon.GetFocusedDataRow()["MASACH"].ToString());
            if (XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông Báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    cthdBus.Delete(hdObj.MAHD, maSach);
                    XtraMessageBox.Show("Đã xóa thành công");
                    //XoaText();
                }
                catch
                {
                }
            }
            LoadHoaDon();
        }

        private void luKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            hdObj.MAKH = int.Parse(luKhachHang.EditValue.ToString());
            hdBus.UpdateKH(hdObj);
        }

        private void gridListHoaDon_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}