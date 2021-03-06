USE [master]
GO
/****** Object:  Database [StoreDB]    Script Date: 9/2/2021 10:17:01 AM ******/
CREATE DATABASE [StoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\StoreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\StoreDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StoreDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [StoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StoreDB] SET QUERY_STORE = OFF
GO
USE [StoreDB]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/2/2021 10:17:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[grade] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/2/2021 10:17:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[purchaseamt] [money] NULL,
	[date] [date] NULL,
	[salesmenid] [int] NULL,
	[customerid] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salesmen]    Script Date: 9/2/2021 10:17:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salesmen](
	[salesmenid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[commission] [money] NULL,
 CONSTRAINT [PK_Salesmen] PRIMARY KEY CLUSTERED 
(
	[salesmenid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([customerid], [name], [city], [grade]) VALUES (1, N'Nick', N'Rimando', 100)
INSERT [dbo].[Customers] ([customerid], [name], [city], [grade]) VALUES (2, N'Graham Zusi', N'California', 200)
INSERT [dbo].[Customers] ([customerid], [name], [city], [grade]) VALUES (3, N'Brad Guzan', N'London', 300)
INSERT [dbo].[Customers] ([customerid], [name], [city], [grade]) VALUES (4, N'Fabain Johns', N'Paris', 200)
INSERT [dbo].[Customers] ([customerid], [name], [city], [grade]) VALUES (5, N'Brad Davis', N'New York', 100)
INSERT [dbo].[Customers] ([customerid], [name], [city], [grade]) VALUES (8, N'Geoff Camero', N'Berlin', 100)
INSERT [dbo].[Customers] ([customerid], [name], [city], [grade]) VALUES (9, N'Julian Green', N'London', 300)
INSERT [dbo].[Customers] ([customerid], [name], [city], [grade]) VALUES (10, N'Jozy Altidor', N'Moscow', 200)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (1, 150.5000, CAST(N'2017-10-05' AS Date), 1, 10)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (2, 270.6500, CAST(N'2017-09-10' AS Date), 2, 9)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (3, 65.2600, CAST(N'2017-10-05' AS Date), 5, 8)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (4, 110.5000, CAST(N'2017-08-17' AS Date), 4, 5)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (5, 948.5000, CAST(N'2017-09-10' AS Date), 5, 4)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (6, 2400.6000, CAST(N'2017-07-27' AS Date), 6, 2)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (7, 5760.0000, CAST(N'2017-09-10' AS Date), 5, 3)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (8, 1983.4300, CAST(N'2017-10-10' AS Date), 4, 1)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (9, 4280.4000, CAST(N'2017-10-10' AS Date), 3, 10)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (10, 250.4500, CAST(N'2017-06-27' AS Date), 2, 8)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (11, 75.2900, CAST(N'2017-08-17' AS Date), 1, 5)
INSERT [dbo].[Orders] ([orderid], [purchaseamt], [date], [salesmenid], [customerid]) VALUES (12, 3045.6000, CAST(N'2017-04-25' AS Date), 6, 9)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Salesmen] ON 

INSERT [dbo].[Salesmen] ([salesmenid], [name], [city], [commission]) VALUES (1, N'James Hoog', N'New Yourk', 0.1500)
INSERT [dbo].[Salesmen] ([salesmenid], [name], [city], [commission]) VALUES (2, N'Nail Knite', N'Paris', 0.1300)
INSERT [dbo].[Salesmen] ([salesmenid], [name], [city], [commission]) VALUES (3, N'Pit Alex', N'London', 0.1100)
INSERT [dbo].[Salesmen] ([salesmenid], [name], [city], [commission]) VALUES (4, N'Mc Lyon', N'Paris', 0.1400)
INSERT [dbo].[Salesmen] ([salesmenid], [name], [city], [commission]) VALUES (5, N'Lauson Hen', N'Naples', 0.1200)
INSERT [dbo].[Salesmen] ([salesmenid], [name], [city], [commission]) VALUES (6, N'Paul Adam', N'Rome', 0.1300)
SET IDENTITY_INSERT [dbo].[Salesmen] OFF
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([customerid])
REFERENCES [dbo].[Customers] ([customerid])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Salesmen] FOREIGN KEY([salesmenid])
REFERENCES [dbo].[Salesmen] ([salesmenid])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Salesmen]
GO
USE [master]
GO
ALTER DATABASE [StoreDB] SET  READ_WRITE 
GO
