-- =============================================
-- Create database template
-- =============================================
USE master
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'Quanlytruonghoc'
)
DROP DATABASE Quanlytruonghoc
GO

CREATE DATABASE Quanlytruonghoc
GO

USE Quanlytruonghoc

CREATE TABLE KHOA (
    Makhoa int,
    Tenkhoa nvarchar(255),
    Dienthoai int,
);

CREATE TABLE GIANGVIEN (
    MaGV int,
    Hoten nvarchar(255),
    Luong int,
    MaKhoa int,
);

CREATE TABLE SINHVIEN (
	MaSV int,
    Hoten nvarchar(255),
    MaKhoa int,
    Namsinh int,
    Quequan nvarchar(255)
);

set dateformat dmy;

INSERT INTO KHOA(Makhoa, Tenkhoa, Dienthoai)
VALUES ('111', N'Công nghệ thông tin', 011022033);
INSERT INTO KHOA(Makhoa, Tenkhoa, Dienthoai)
VALUES ('222', N'Luật kinh tế', 011032033);
INSERT INTO KHOA(Makhoa, Tenkhoa, Dienthoai)
VALUES ('333', N'Ngôn ngữ anh', 011042033);



INSERT INTO GIANGVIEN(MaGV, Hoten, Luong, MaKhoa)
VALUES ('011', N'Trần Quang Huy', 20000000,'111');
INSERT INTO GIANGVIEN(MaGV, Hoten, Luong, MaKhoa)
VALUES ('012', N'Hứa Minh Nhựt', 15000000,'222');
INSERT INTO GIANGVIEN(MaGV, Hoten, Luong, MaKhoa)
VALUES ('012', N'Đỗ Anh Thư', 10000000,'333');


INSERT INTO SINHVIEN(MaSV, Hoten, MaKhoa, Namsinh, Quequan)
VALUES ('001', N'Lê Văn Tự', '111', '2004',N'Cà Mau');
INSERT INTO SINHVIEN(MaSV, Hoten, MaKhoa, Namsinh, Quequan)
VALUES ('002', N'Lê Trọng Khả', '222', '2006',N'Cà Mau');
INSERT INTO SINHVIEN(MaSV, Hoten, MaKhoa, Namsinh, Quequan)
VALUES ('003', N'Vương Nguyễn Vân Anh', '333', '2008',N'Cà Mau');

select * from KHOA
select * from GIANGVIEN
select * from SINHVIEN