USE [master]
GO
/****** Object:  Database [CuaHangSach]    Script Date: 11/14/2016 9:15:51 PM ******/
CREATE DATABASE [CuaHangSach]
 --CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'CuaHangSach', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CuaHangSach.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'CuaHangSach_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CuaHangSach_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CuaHangSach] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CuaHangSach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CuaHangSach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CuaHangSach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CuaHangSach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CuaHangSach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CuaHangSach] SET ARITHABORT OFF 
GO
ALTER DATABASE [CuaHangSach] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CuaHangSach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CuaHangSach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CuaHangSach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CuaHangSach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CuaHangSach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CuaHangSach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CuaHangSach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CuaHangSach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CuaHangSach] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CuaHangSach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CuaHangSach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CuaHangSach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CuaHangSach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CuaHangSach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CuaHangSach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CuaHangSach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CuaHangSach] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CuaHangSach] SET  MULTI_USER 
GO
ALTER DATABASE [CuaHangSach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CuaHangSach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CuaHangSach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CuaHangSach] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CuaHangSach] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CuaHangSach]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MAHD] [int] NOT NULL,
	[MASACH] [int] NULL,
	[SOLUONG] [int] NULL,
	[GIASACH] [decimal](18, 0) NULL,
	[THANHTIEN] [decimal](18, 0) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MAPN] [int] NOT NULL,
	[MASACH] [int] NULL,
	[SOLUONG] [int] NULL,
	[DONGIA] [decimal](10, 0) NULL,
	[THANHTIEN] [decimal](18, 0) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MAHD] [int] IDENTITY(1,1) NOT NULL,
	[MANV] [int] NULL,
	[NGAYLAP] [datetime] NOT NULL,
	[MAKH] [int] NULL,
	[TONGTIEN] [decimal](10, 0) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MAKH] [int] IDENTITY(1,1) NOT NULL,
	[TENKH] [nvarchar](500) NULL,
	[DIENTHOAI] [int] NULL,
	[DIACHI] [nvarchar](500) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MANV] [int] IDENTITY(1,1) NOT NULL,
	[TENNV] [nvarchar](500) NULL,
	[GT] [nvarchar](3) NULL,
	[NGAYSINH] [date] NULL,
	[DIENTHOAI] [int] NULL,
	[DIACHI] [nvarchar](500) NULL,
	[TAIKHOAN] [nchar](32) NULL,
	[MATKHAU] [nchar](32) NULL,
	[EMAIL] [nchar](100) NULL,
	[MAQUYEN] [int] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaPhanPhoi]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaPhanPhoi](
	[MANPP] [int] IDENTITY(1,1) NOT NULL,
	[TENNPP] [nvarchar](500) NULL,
	[DIACHI] [nvarchar](500) NULL,
	[DIENTHOAI] [int] NULL,
	[FAX] [int] NULL,
	[EMAIL] [nvarchar](500) NULL,
 CONSTRAINT [PK_NhaPhanPhoi] PRIMARY KEY CLUSTERED 
(
	[MANPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[MANXB] [int] IDENTITY(1,1) NOT NULL,
	[TENNXB] [nvarchar](500) NULL,
	[DIACHI] [nvarchar](500) NULL,
	[DIENTHOAI] [int] NULL,
	[EMAIL] [nvarchar](500) NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MANXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MAPN] [int] IDENTITY(1,1) NOT NULL,
	[MANV] [int] NULL,
	[MANPP] [int] NULL,
	[NGAYLAP] [datetime] NULL,
	[TONGTIEN] [decimal](10, 0) NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MAPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[MAQUYEN] [int] IDENTITY(1,1) NOT NULL,
	[TENQUYEN] [nvarchar](50) NULL,
	[MOTA] [nvarchar](50) NULL,
	[TRANGTHAI] [bit] NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[MAQUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sach]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MASACH] [int] IDENTITY(1,1) NOT NULL,
	[TENSACH] [nvarchar](500) NULL,
	[MATHELOAI] [int] NULL,
	[NAMXUATBAN] [int] NULL,
	[GIAMUA] [decimal](18, 0) NULL,
	[GIABAN] [decimal](18, 0) NULL,
	[SOLUONGKHO] [int] NULL,
	[MANXB] [int] NULL,
	[MOTA] [nvarchar](500) NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MASACH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sach_TG]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach_TG](
	[MASACH] [int] NOT NULL,
	[MATG] [int] NOT NULL,
 CONSTRAINT [PK_Sach_TG] PRIMARY KEY CLUSTERED 
(
	[MASACH] ASC,
	[MATG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[MATG] [int] IDENTITY(1,1) NOT NULL,
	[TENTG] [nvarchar](500) NULL,
	[GIOITHIEU] [nvarchar](500) NULL,
	[DIACHI] [nvarchar](500) NULL,
	[DIENTHOAI] [int] NULL,
	[EMAIL] [nvarchar](500) NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[MATG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MATHELOAI] [int] IDENTITY(1,1) NOT NULL,
	[TENTHELOAI] [nvarchar](500) NULL,
	[MOTA] [nvarchar](500) NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MATHELOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Sach] ON 

INSERT [dbo].[Sach] ([MASACH], [TENSACH], [MATHELOAI], [NAMXUATBAN], [GIAMUA], [GIABAN], [SOLUONGKHO], [MANXB], [MOTA]) VALUES (4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Sach] OFF
SET IDENTITY_INSERT [dbo].[TheLoai] ON 

INSERT [dbo].[TheLoai] ([MATHELOAI], [TENTHELOAI], [MOTA]) VALUES (1, N'Toán học', N'Toán')
SET IDENTITY_INSERT [dbo].[TheLoai] OFF
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MAHD])
REFERENCES [dbo].[HoaDon] ([MAHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_Sach] FOREIGN KEY([MASACH])
REFERENCES [dbo].[Sach] ([MASACH])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_Sach]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap] FOREIGN KEY([MAPN])
REFERENCES [dbo].[PhieuNhap] ([MAPN])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_Sach] FOREIGN KEY([MASACH])
REFERENCES [dbo].[Sach] ([MASACH])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_Sach]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KhachHang] ([MAKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MANV])
REFERENCES [dbo].[NhanVien] ([MANV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Quyen] FOREIGN KEY([MAQUYEN])
REFERENCES [dbo].[Quyen] ([MAQUYEN])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_Quyen]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MANV])
REFERENCES [dbo].[NhanVien] ([MANV])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaPhanPhoi] FOREIGN KEY([MANPP])
REFERENCES [dbo].[NhaPhanPhoi] ([MANPP])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaPhanPhoi]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NhaXuatBan] FOREIGN KEY([MANXB])
REFERENCES [dbo].[NhaXuatBan] ([MANXB])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NhaXuatBan]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TheLoai] FOREIGN KEY([MATHELOAI])
REFERENCES [dbo].[TheLoai] ([MATHELOAI])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TheLoai]
GO
ALTER TABLE [dbo].[Sach_TG]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TG_Sach] FOREIGN KEY([MASACH])
REFERENCES [dbo].[Sach] ([MASACH])
GO
ALTER TABLE [dbo].[Sach_TG] CHECK CONSTRAINT [FK_Sach_TG_Sach]
GO
ALTER TABLE [dbo].[Sach_TG]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TG_TacGia] FOREIGN KEY([MATG])
REFERENCES [dbo].[TacGia] ([MATG])
GO
ALTER TABLE [dbo].[Sach_TG] CHECK CONSTRAINT [FK_Sach_TG_TacGia]
GO
/****** Object:  StoredProcedure [dbo].[THELOAI_DELETE]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[THELOAI_DELETE]
@MATHELOAI INT
AS
BEGIN
DELETE FROM [dbo].[TheLoai]
      WHERE MATHELOAI=@MATHELOAI
	  END

GO
/****** Object:  StoredProcedure [dbo].[THELOAI_GETALL]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[THELOAI_GETALL]
AS
BEGIN
SELECT [MATHELOAI]
      ,[TENTHELOAI]
      ,[MOTA]
  FROM [dbo].[TheLoai]
END

GO
/****** Object:  StoredProcedure [dbo].[THELOAI_INSERT]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[THELOAI_INSERT]

@TENTHELOAI  nvarchar(500),
@MOTA nvarchar(500)
AS
BEGIN
INSERT INTO [dbo].[TheLoai]
           ([TENTHELOAI]
           ,[MOTA])
     VALUES
           (@TENTHELOAI
           ,@MOTA)
		   END

GO
/****** Object:  StoredProcedure [dbo].[THELOAI_UPDATE]    Script Date: 11/14/2016 9:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[THELOAI_UPDATE]
@MATHELOAI INT,
@TENTHELOAI nvarchar(500),
@MOTA nvarchar(500)
AS
BEGIN
UPDATE [dbo].[TheLoai]
   SET [TENTHELOAI] = @TENTHELOAI
      ,[MOTA] = @MOTA
 WHERE MATHELOAI=@MATHELOAI
END

GO
USE [master]
GO
ALTER DATABASE [CuaHangSach] SET  READ_WRITE 
GO
