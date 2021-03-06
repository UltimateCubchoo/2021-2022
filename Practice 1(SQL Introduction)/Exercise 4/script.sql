USE [master]
GO
/****** Object:  Database [WarehouseDB]    Script Date: 8/31/2021 10:19:30 AM ******/
CREATE DATABASE [WarehouseDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NewDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\NewDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NewDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\NewDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WarehouseDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WarehouseDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WarehouseDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WarehouseDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WarehouseDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WarehouseDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WarehouseDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WarehouseDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WarehouseDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WarehouseDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WarehouseDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WarehouseDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WarehouseDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WarehouseDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WarehouseDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WarehouseDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WarehouseDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WarehouseDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WarehouseDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WarehouseDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WarehouseDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WarehouseDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WarehouseDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WarehouseDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WarehouseDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WarehouseDB] SET  MULTI_USER 
GO
ALTER DATABASE [WarehouseDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WarehouseDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WarehouseDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WarehouseDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WarehouseDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WarehouseDB] SET QUERY_STORE = OFF
GO
USE [WarehouseDB]
GO
/****** Object:  Table [dbo].[Boxes]    Script Date: 8/31/2021 10:19:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boxes](
	[boxid] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NULL,
	[content] [varchar](50) NULL,
	[price] [money] NULL,
	[warehouseid] [int] NULL,
 CONSTRAINT [PK_Boxes] PRIMARY KEY CLUSTERED 
(
	[boxid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouses]    Script Date: 8/31/2021 10:19:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouses](
	[warehouseid] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NULL,
	[location] [varchar](50) NULL,
	[capacity] [int] NULL,
 CONSTRAINT [PK_Warehouses] PRIMARY KEY CLUSTERED 
(
	[warehouseid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Boxes] ON 

INSERT [dbo].[Boxes] ([boxid], [code], [content], [price], [warehouseid]) VALUES (2, N'02b', N'Knife Set', 224.8250, 3)
INSERT [dbo].[Boxes] ([boxid], [code], [content], [price], [warehouseid]) VALUES (4, N'04d', N'Shoes', 281.0313, 2)
INSERT [dbo].[Boxes] ([boxid], [code], [content], [price], [warehouseid]) VALUES (6, N'06f', N'Keyboard', 393.4438, 2)
INSERT [dbo].[Boxes] ([boxid], [code], [content], [price], [warehouseid]) VALUES (9, N'09i', N'Tablet', 674.4750, 5)
INSERT [dbo].[Boxes] ([boxid], [code], [content], [price], [warehouseid]) VALUES (11, N'11k', N'Phone', 5395.8000, 4)
INSERT [dbo].[Boxes] ([boxid], [code], [content], [price], [warehouseid]) VALUES (12, N'08y', N'Paper', 224.8250, 2)
INSERT [dbo].[Boxes] ([boxid], [code], [content], [price], [warehouseid]) VALUES (13, N'05r', N'Pencils', 337.2375, 1)
INSERT [dbo].[Boxes] ([boxid], [code], [content], [price], [warehouseid]) VALUES (14, N'15e', N'YoYos', 899.3000, 3)
INSERT [dbo].[Boxes] ([boxid], [code], [content], [price], [warehouseid]) VALUES (15, N'06l', N'Rulers', 112.4125, 4)
SET IDENTITY_INSERT [dbo].[Boxes] OFF
GO
SET IDENTITY_INSERT [dbo].[Warehouses] ON 

INSERT [dbo].[Warehouses] ([warehouseid], [code], [location], [capacity]) VALUES (1, N'01a', N'Tallahasee', 500)
INSERT [dbo].[Warehouses] ([warehouseid], [code], [location], [capacity]) VALUES (2, N'02b', N'Miami', 450)
INSERT [dbo].[Warehouses] ([warehouseid], [code], [location], [capacity]) VALUES (3, N'03c', N'Naples', 350)
INSERT [dbo].[Warehouses] ([warehouseid], [code], [location], [capacity]) VALUES (4, N'04d', N'Tampa', 400)
INSERT [dbo].[Warehouses] ([warehouseid], [code], [location], [capacity]) VALUES (5, N'05e', N'Jacksonville', 200)
INSERT [dbo].[Warehouses] ([warehouseid], [code], [location], [capacity]) VALUES (6, N'06f', N'Bonita Springs', 300)
SET IDENTITY_INSERT [dbo].[Warehouses] OFF
GO
ALTER TABLE [dbo].[Boxes]  WITH CHECK ADD  CONSTRAINT [FK_Boxes_Warehouses] FOREIGN KEY([warehouseid])
REFERENCES [dbo].[Warehouses] ([warehouseid])
GO
ALTER TABLE [dbo].[Boxes] CHECK CONSTRAINT [FK_Boxes_Warehouses]
GO
USE [master]
GO
ALTER DATABASE [WarehouseDB] SET  READ_WRITE 
GO
