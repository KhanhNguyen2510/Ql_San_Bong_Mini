Create database SANBONGMINI
GO
Use SANBONGMINI
GO


Create table TAIKHOAN
(
	Tendangnhap VARCHAR(20)NOT NULL,
	MADN VARCHAR(8) NOT NULL,
	Pass VARCHAR(20) NOT NULL
)
select * from taikhoan
insert into TAIKHOAN values('ADMIN','NV1','09');
CREATE TABLE NHANVIEN
(
	MaNV VARCHAR(8) PRIMARY KEY,
	TenNV NVARCHAR(30) NOT NULL,
	Gioitinh nvarchAR(4)CHECK (Gioitinh=N'NAM' OR Gioitinh=N'NỮ'),
	Ngaysinh DATE,
	SDT VARCHAR(20) NOT NULL,
	LuongThang DECIMAL(10,3) NOT NULL,
)
SET DATEFORMAT DMY
INSERT INTO NHANVIEN VALUES('NV002',N'ĐINH QUỐC KHÁNH NGUYÊN','NAM','25/10/2000','0794201396',3000);

select * from NHANVIEN
--------------------------------------------------------------------------------------------------------------------------
CREATE TABLE KHACHHANG(
	MaKH VARCHAR(8) PRIMARY KEY,
	TenKH NVARCHAR(50) NOT NULL,
	Gioitinh nvarchAR(4)CHECK (Gioitinh=N'NAM' OR Gioitinh=N'NỮ'),
	SDT VARCHAR(20) NOT NULL,
	Ghichu NVARCHAR(100) DEFAULT NULL,
)

INSERT INTO KHACHHANG VALUES ('KH001',N'HUỲNH THANH PHƯƠNG','NAM','0372711572','')

----------------------------------------------------------------------------------------------------------
CREATE TABLE SANBONG(
	MaSB VARCHAR(8)PRIMARY KEY,
	TenSB NVARCHAR(30) NOT NULL,
	Dientich NVARCHAR (20), 
)
	INSERT INTO SANBONG VALUES ('S7_7',N'Sân 7 (sân 7 người)','60m x 40m'),
								('S7_8',N'Sân 8 (sân 7 người)','60m x 40m')

INSERT INTO SANBONG VALUES ('S5_1',N'Sân 1 (sân 5 người)','20m x 30m'),
							('S5_2',N'Sân 2 (sân 5 người)','20m x 30m'),
							('S5_3',N'Sân 3 (sân 5 người)','20m x 30m'),
							('S5_4',N'Sân 4 (sân 5 người)','20m x 30m'),
							('S5_5',N'Sân 5 (sân 5 người)','20m x 30m'),
							('S5_6',N'Sân 6 (sân 5 người)','20m x 30m')

CREATE TABLE GIAGIOTHUE(
	Magio VARCHAR(15) PRIMARY KEY,
	Chitiet NVARCHAR(50),
	Dongia DECIMAL NOT NULL,
	) 
	
INSERT INTO GIAGIOTHUE VALUES('S5_8h_16h',N'Sân 5 người từ 8:00AM đến 4:00PM','180000'),
							('S5_17h_21h',N'Sân 5 từ 5:00PM đến 9:00PM','200000'),
							('S7_8h_16h',N'Sân 7 người từ 8:00AM đến 4:00PM','300000'),
							('S7_17h_21h',N'Sân 7 từ 5:00PM đến 9:00PM','400000')
CREATE TABLE PHIEUDATSAN( 
	MaPDS INT IDENTITY(1,1) PRIMARY KEY,
	MaKH VARCHAR(8) NOT NULL,
	MaSB VARCHAR(8) NOT NULL,
	MaNV VARCHAR(8) NOT NULL,
	Magio VARCHAR(15) NOT NULL,
	Ngaydatsan DATEtime  default getdate(),
	Ngaylap DATEtime  default getdate(),
	Trangthai nvarchar(20) default N'Chưa thanh toán',
	CONSTRAINT fk_PDS_MaSB FOREIGN KEY (MaSB) REFERENCES SANBONG (MaSB) ,
	CONSTRAINT fk_PDS_MaNV FOREIGN KEY (MaNV) REFERENCES NHANVIEN (MaNV) ,
	CONSTRAINT fk__PDS_MaKH FOREIGN KEY (MaKH) REFERENCES KHACHHANG (MaKH) ,
	CONSTRAINT fk__PDS_Magio FOREIGN KEY (Magio) REFERENCES GIAGIOTHUE (Magio) 
	ON DELETE CASCADE ON UPDATE CASCADE
	)
	SET DATEFORMAT DMY
--------------------------------------------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------------------------------
CREATE TABLE HDTHANHTOAN(
	 SoHDTT INT IDENTITY(100,1) PRIMARY KEY,
	 MaPDS INT,
	 MaKH VARCHAR(8) NOT NULL,
	 MaNV VARCHAR(8) NOT NULL,  
	 Ngaylap DATEtime default getdate(),
	 thanhtien DECIMAL default 0,
	 CONSTRAINT fk_HDTT_MaKH FOREIGN KEY (MaKH) REFERENCES KHACHHANG (MaKH),
	 CONSTRAINT fk_HDTT_MaNV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
	 CONSTRAINT fk_HDTT_pds FOREIGN KEY (MaPDS) REFERENCES PHIEUDATSAN(MaPDS)
	 ON DELETE CASCADE ON UPDATE CASCADE	  
  )
--------------------------------------------------------------------------------------------------------------------------

-----------TRIGGER---------
go 
CREATE TRIGGER trg_thanhtiem ON HDTHANHTOAN AFTER INSERT AS 
BEGIN
	UPDATE PHIEUDATSAN
	SET Trangthai = N'Đã thanh toán'
	FROM PHIEUDATSAN
	JOIN inserted ON PHIEUDATSAN.MaPDS = inserted.MaPDS
END
go
--LẤY THÔNG TIN NHÂN VIÊN LÀM ĐĂNG NHẬP
CREATE TRIGGER TRG_TAOTK ON NHANVIEN AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;
	INSERT INTO TAIKHOAN(Tendangnhap,MADN ,
	Pass)
	SELECT  'ADMIN',MaNV, SDT
	FROM INSERTED

END
go
--LẤY THÔNG TIN KHÁCH HÀNG LÀM ĐĂNG NHẬP
CREATE TRIGGER TRG_TAOTKKH ON KHACHHANG AFTER INSERT AS 
BEGIN
	SET NOCOUNT ON;
	INSERT INTO TAIKHOAN(Tendangnhap,MADN ,
	Pass)
	SELECT 'KHACHHANG', MaKH, SDT
	FROM INSERTED

END

GO
