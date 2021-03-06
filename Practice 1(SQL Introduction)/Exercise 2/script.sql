USE [master]
GO
/****** Object:  Database [ProductDB]    Script Date: 8/27/2021 9:48:22 AM ******/
CREATE DATABASE [ProductDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ProductDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ProductDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProductDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProductDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductDB] SET QUERY_STORE = OFF
GO
USE [ProductDB]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8/27/2021 9:48:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[lname] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[address] [varchar](50) NULL,
	[dob] [date] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/27/2021 9:48:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[customerid] [int] NOT NULL,
	[productid] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 8/27/2021 9:48:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[productid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[code] [varchar](50) NULL,
	[price] [money] NULL,
	[vendorid] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[productid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 8/27/2021 9:48:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[vendorid] [int] IDENTITY(1,1) NOT NULL,
	[refnum] [int] NULL,
	[name] [varchar](50) NULL,
	[address] [varchar](50) NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[vendorid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (0, N'Bill', N'Gates', N'123456', N'1st Street', CAST(N'1970-01-01' AS Date))
INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (1, N'Fedrick', N'Jones', N'654321', N'2nd Street', CAST(N'1981-02-05' AS Date))
INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (2, N'Emily', N'Faire', N'173897', N'3rd Street', CAST(N'1975-03-21' AS Date))
INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (3, N'Aident', N'Tingler', N'841654', N'4th Street', CAST(N'1985-12-15' AS Date))
INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (4, N'Steve', N'Ditko', N'365411', N'5th Street', CAST(N'1987-09-30' AS Date))
INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (5, N'Reily', N'Reid', N'256161', N'6th Street', CAST(N'1984-11-05' AS Date))
INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (6, N'Donald', N'Hagen', N'841850', N'7th Street', CAST(N'1984-11-05' AS Date))
INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (7, N'Tim', N'Goddman', N'415412', N'8th Street', CAST(N'1979-11-05' AS Date))
INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (8, N'Fred', N'Jones', N'765468', N'9th Street', CAST(N'1977-11-05' AS Date))
INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (9, N'Ryan', N'Tickey', N'586485', N'10th Street', CAST(N'1975-11-05' AS Date))
INSERT [dbo].[Customers] ([customerid], [name], [lname], [phone], [address], [dob]) VALUES (10, N'Hekid', N'Yeonid', N'485628', N'11th Street', CAST(N'1964-11-05' AS Date))
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (0, 1, 1)
INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (1, 2, 2)
INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (2, 3, 3)
INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (3, 4, 4)
INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (4, 5, 5)
INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (5, 6, 6)
INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (6, 7, 7)
INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (7, 8, 8)
INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (8, 9, 9)
INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (9, 10, 10)
INSERT [dbo].[Orders] ([orderid], [customerid], [productid]) VALUES (10, 0, 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (0, N'Pencil Pack', N'01', 1.5750, 0)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (1, N'Notebook', N'02', 2.1000, 1)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (2, N'Paper', N'03', 1.1130, 2)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (3, N'Thermometer', N'04', 5.2500, 3)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (4, N'Crayons', N'05', 5.2500, 8)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (5, N'Ruler', N'06', 5.2500, 2)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (6, N'Keyboard', N'07', 21.0000, 4)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (7, N'Mouse', N'08', 21.0000, 5)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (8, N'Folder', N'09', 0.5250, 7)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (9, N'Calculator', N'10', 10.5000, 9)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (10, N'Scientific Calculator', N'11', 52.5000, 10)
INSERT [dbo].[Products] ([productid], [name], [code], [price], [vendorid]) VALUES (11, N'Tissues', N'12', 3.1500, 8)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Vendors] ON 

INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (0, 0, N'Will Vick', N'1st Street')
INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (1, 1, N'Eziko Hen', N'2nd Street')
INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (2, 2, N'Redin Sole', N'3rd Street')
INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (3, 3, N'jfklds sdf', N'4th Street')
INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (4, 4, N'Abcde Biden', N'5th Street')
INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (5, 5, N'Feas Lopen', N'6th Street')
INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (6, 6, N'Yupein Rein', N'7th Street')
INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (7, 7, N'feds', N'8th Street')
INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (8, 8, N'desa', N'9th Street')
INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (9, 9, N'Doun Nigma', N'10th Street')
INSERT [dbo].[Vendors] ([vendorid], [refnum], [name], [address]) VALUES (10, 10, N'Loiel Tupp', N'11th Street')
SET IDENTITY_INSERT [dbo].[Vendors] OFF
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [CustomerLink] FOREIGN KEY([customerid])
REFERENCES [dbo].[Customers] ([customerid])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [CustomerLink]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [Product LInk] FOREIGN KEY([productid])
REFERENCES [dbo].[Products] ([productid])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [Product LInk]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Vendors] FOREIGN KEY([vendorid])
REFERENCES [dbo].[Vendors] ([vendorid])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Vendors]
GO
USE [master]
GO
ALTER DATABASE [ProductDB] SET  READ_WRITE 
GO
