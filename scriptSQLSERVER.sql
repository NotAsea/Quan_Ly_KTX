USE [KTX_KMA]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 1/22/2022 8:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDV] [int] NOT NULL,
	[Ten_DV] [nvarchar](15) NULL,
	[GiaDV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DienNuocPhong]    Script Date: 1/22/2022 8:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DienNuocPhong](
	[MaPhong] [int] NOT NULL,
	[GiaDien] [int] NOT NULL,
	[GiaNuoc] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ĐKDVCN]    Script Date: 1/22/2022 8:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ĐKDVCN](
	[MaDK] [int] IDENTITY(1,1) NOT NULL,
	[MSV] [char](15) NOT NULL,
	[MaDV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DV_ĐKDVCN]    Script Date: 1/22/2022 8:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DV_ĐKDVCN](
	[MaDK] [int] NOT NULL,
	[MaDV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDK] ASC,
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[He]    Script Date: 1/22/2022 8:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[He](
	[MaHe] [char](10) NOT NULL,
	[TenHe] [nvarchar](75) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 1/22/2022 8:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] NOT NULL,
	[MSV] [char](15) NOT NULL,
	[MaDK] [int] NOT NULL,
	[Gia_HD] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 1/22/2022 8:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[MaPhong] [int] NOT NULL,
	[MaHe] [char](10) NOT NULL,
	[TinhTrangPhong] [nvarchar](75) NOT NULL,
	[Loai_Phong] [nchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 1/22/2022 8:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MSV] [char](15) NOT NULL,
	[Hoten] [nvarchar](75) NOT NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[NgaySinh] [date] NULL,
	[NamHoc] [int] NOT NULL,
	[MaHe] [char](10) NOT NULL,
	[MaPhong] [int] NOT NULL,
	[ID_user] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_NguoiDung]    Script Date: 1/22/2022 8:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_NguoiDung](
	[ID_user] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](75) NOT NULL,
	[MatKhau] [varchar](15) NOT NULL,
	[RoleID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaiTro]    Script Date: 1/22/2022 8:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaiTro](
	[RoleID] [int] NOT NULL,
	[RoleName] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DichVu] ([MaDV], [Ten_DV], [GiaDV]) VALUES (1, N'Giặt là', 50000)
INSERT [dbo].[DichVu] ([MaDV], [Ten_DV], [GiaDV]) VALUES (2, N'Gym', 200000)
GO
INSERT [dbo].[DienNuocPhong] ([MaPhong], [GiaDien], [GiaNuoc]) VALUES (102, 150000, 180000)
INSERT [dbo].[DienNuocPhong] ([MaPhong], [GiaDien], [GiaNuoc]) VALUES (103, 100000, 50000)
INSERT [dbo].[DienNuocPhong] ([MaPhong], [GiaDien], [GiaNuoc]) VALUES (104, 36000, 75000)
GO
SET IDENTITY_INSERT [dbo].[ĐKDVCN] ON 

INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (3, N'AT150419       ', 1)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (5, N'AT150432       ', 2)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (7, N'AT150416       ', 2)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (9, N'AT150455       ', 2)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (17, N'AT150422       ', 1)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (18, N'AT150422       ', 2)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (19, N'AT150438       ', 1)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (20, N'AT150438       ', 2)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (24, N'AT150411       ', 1)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (25, N'AT150411       ', 2)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (26, N'AT150432       ', 1)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (27, N'AT150404       ', 1)
INSERT [dbo].[ĐKDVCN] ([MaDK], [MSV], [MaDV]) VALUES (28, N'AT150404       ', 2)
SET IDENTITY_INSERT [dbo].[ĐKDVCN] OFF
GO
INSERT [dbo].[DV_ĐKDVCN] ([MaDK], [MaDV]) VALUES (3, 1)
INSERT [dbo].[DV_ĐKDVCN] ([MaDK], [MaDV]) VALUES (3, 2)
GO
INSERT [dbo].[He] ([MaHe], [TenHe]) VALUES (N'DS        ', N'Dân Sự')
INSERT [dbo].[He] ([MaHe], [TenHe]) VALUES (N'QS        ', N'Quân Sự')
GO
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (101, N'DS        ', N'Hết', N'Nam')
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (102, N'DS        ', N'Còn', N'Nam')
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (103, N'DS        ', N'Còn', N'Nữ ')
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (104, N'DS        ', N'Còn', N'Nam')
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (105, N'DS        ', N'Còn', N'Nữ ')
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (201, N'QS        ', N'Hết', N'Nữ ')
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (202, N'DS        ', N'Còn', N'Nam')
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (203, N'QS        ', N'Còn', N'Nữ ')
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (205, N'QS        ', N'Còn', N'Nam')
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (301, N'DS        ', N'Hết', N'Nữ ')
INSERT [dbo].[Phong] ([MaPhong], [MaHe], [TinhTrangPhong], [Loai_Phong]) VALUES (302, N'QS        ', N'Còn', N'Nam')
GO
INSERT [dbo].[SinhVien] ([MSV], [Hoten], [GioiTinh], [NgaySinh], [NamHoc], [MaHe], [MaPhong], [ID_user]) VALUES (N'AT150404       ', N'Nguyễn Thị Oanh', N'Nữ', CAST(N'2000-02-02' AS Date), 2018, N'DS        ', 105, 18)
INSERT [dbo].[SinhVien] ([MSV], [Hoten], [GioiTinh], [NgaySinh], [NamHoc], [MaHe], [MaPhong], [ID_user]) VALUES (N'AT150411       ', N'Long Vũ', N'Nam', CAST(N'2000-05-11' AS Date), 2018, N'DS        ', 102, 16)
INSERT [dbo].[SinhVien] ([MSV], [Hoten], [GioiTinh], [NgaySinh], [NamHoc], [MaHe], [MaPhong], [ID_user]) VALUES (N'AT150412       ', N'Bùi Thành Công', N'Nam', CAST(N'2000-05-23' AS Date), 2018, N'DS        ', 102, 6)
INSERT [dbo].[SinhVien] ([MSV], [Hoten], [GioiTinh], [NgaySinh], [NamHoc], [MaHe], [MaPhong], [ID_user]) VALUES (N'AT150415       ', N'Thái', N'Nam', CAST(N'2000-10-30' AS Date), 2018, N'DS        ', 101, 3)
INSERT [dbo].[SinhVien] ([MSV], [Hoten], [GioiTinh], [NgaySinh], [NamHoc], [MaHe], [MaPhong], [ID_user]) VALUES (N'AT150416       ', N'Thanh Thủy', N'Nữ', CAST(N'2000-11-02' AS Date), 2018, N'QS        ', 203, 7)
INSERT [dbo].[SinhVien] ([MSV], [Hoten], [GioiTinh], [NgaySinh], [NamHoc], [MaHe], [MaPhong], [ID_user]) VALUES (N'AT150419       ', N'Thanh Hoa', N'Nữ', CAST(N'2000-09-05' AS Date), 2018, N'DS        ', 103, 5)
INSERT [dbo].[SinhVien] ([MSV], [Hoten], [GioiTinh], [NgaySinh], [NamHoc], [MaHe], [MaPhong], [ID_user]) VALUES (N'AT150422       ', N'Thị Ngọc', N'Nữ', CAST(N'2000-12-04' AS Date), 2018, N'DS        ', 103, 2)
INSERT [dbo].[SinhVien] ([MSV], [Hoten], [GioiTinh], [NgaySinh], [NamHoc], [MaHe], [MaPhong], [ID_user]) VALUES (N'AT150432       ', N'Lương Hữu Hải', N'Nam', CAST(N'2000-02-11' AS Date), 2018, N'QS        ', 302, 1)
INSERT [dbo].[SinhVien] ([MSV], [Hoten], [GioiTinh], [NgaySinh], [NamHoc], [MaHe], [MaPhong], [ID_user]) VALUES (N'AT150438       ', N'Hoàng Long', N'Nam', CAST(N'2000-01-12' AS Date), 2017, N'DS        ', 102, 11)
INSERT [dbo].[SinhVien] ([MSV], [Hoten], [GioiTinh], [NgaySinh], [NamHoc], [MaHe], [MaPhong], [ID_user]) VALUES (N'AT150455       ', N'Quốc Huy', N'Nam', CAST(N'2000-01-02' AS Date), 2017, N'QS        ', 302, 10)
GO
SET IDENTITY_INSERT [dbo].[User_NguoiDung] ON 

INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (1, N'Hai', N'1234567', 1)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (2, N'Ngoc', N'1234567', 1)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (3, N'Thai', N'1234567', 1)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (5, N'Hoa', N'1234567', 1)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (6, N'Cong', N'1234567', 1)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (7, N'Thuy', N'1234567', 1)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (8, N'Cuong', N'1234567', 2)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (10, N'Huy', N'123', 1)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (11, N'Long', N'123', 1)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (16, N'Vu', N'123', 1)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (18, N'oanh', N'123456', 1)
INSERT [dbo].[User_NguoiDung] ([ID_user], [Username], [MatKhau], [RoleID]) VALUES (19, N'Tien Anh', N'1234567', 1)
SET IDENTITY_INSERT [dbo].[User_NguoiDung] OFF
GO
INSERT [dbo].[VaiTro] ([RoleID], [RoleName]) VALUES (1, N'User')
INSERT [dbo].[VaiTro] ([RoleID], [RoleName]) VALUES (2, N'Admin')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__DichVu__AD1E9A0828711DB2]    Script Date: 1/22/2022 8:13:23 AM ******/
ALTER TABLE [dbo].[DichVu] ADD UNIQUE NONCLUSTERED 
(
	[Ten_DV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SinhVien] ADD  DEFAULT ('Nam') FOR [GioiTinh]
GO
ALTER TABLE [dbo].[DienNuocPhong]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
GO
ALTER TABLE [dbo].[ĐKDVCN]  WITH CHECK ADD FOREIGN KEY([MSV])
REFERENCES [dbo].[SinhVien] ([MSV])
GO
ALTER TABLE [dbo].[DV_ĐKDVCN]  WITH CHECK ADD FOREIGN KEY([MaDK])
REFERENCES [dbo].[ĐKDVCN] ([MaDK])
GO
ALTER TABLE [dbo].[DV_ĐKDVCN]  WITH CHECK ADD FOREIGN KEY([MaDV])
REFERENCES [dbo].[DichVu] ([MaDV])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaDK])
REFERENCES [dbo].[ĐKDVCN] ([MaDK])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MSV])
REFERENCES [dbo].[SinhVien] ([MSV])
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD FOREIGN KEY([MaHe])
REFERENCES [dbo].[He] ([MaHe])
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [eee] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [eee]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD FOREIGN KEY([ID_user])
REFERENCES [dbo].[User_NguoiDung] ([ID_user])
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [SV_MaHe] FOREIGN KEY([MaHe])
REFERENCES [dbo].[He] ([MaHe])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [SV_MaHe]
GO
ALTER TABLE [dbo].[User_NguoiDung]  WITH CHECK ADD  CONSTRAINT [User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[VaiTro] ([RoleID])
GO
ALTER TABLE [dbo].[User_NguoiDung] CHECK CONSTRAINT [User_Role]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD CHECK  (([NgaySinh]<getdate()))
GO
