USE [master]
GO
/****** Object:  Database [ManufacturersDB]    Script Date: 8/30/2021 10:11:19 AM ******/
CREATE DATABASE [ManufacturersDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Manufacturers', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Manufacturers.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Manufacturers_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Manufacturers_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ManufacturersDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ManufacturersDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ManufacturersDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ManufacturersDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ManufacturersDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ManufacturersDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ManufacturersDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ManufacturersDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ManufacturersDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ManufacturersDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ManufacturersDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ManufacturersDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ManufacturersDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ManufacturersDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ManufacturersDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ManufacturersDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ManufacturersDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ManufacturersDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ManufacturersDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ManufacturersDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ManufacturersDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ManufacturersDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ManufacturersDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ManufacturersDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ManufacturersDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ManufacturersDB] SET  MULTI_USER 
GO
ALTER DATABASE [ManufacturersDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ManufacturersDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ManufacturersDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ManufacturersDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ManufacturersDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ManufacturersDB] SET QUERY_STORE = OFF
GO
USE [ManufacturersDB]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 8/30/2021 10:11:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[ArticlesID] [int] IDENTITY(0,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[MakerID] [int] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[ArticlesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 8/30/2021 10:11:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[MakerID] [int] IDENTITY(0,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[MakerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([ArticlesID], [Code], [Name], [Price], [MakerID]) VALUES (1, 0, N'C++ and You', 25.0000, 5)
INSERT [dbo].[Articles] ([ArticlesID], [Code], [Name], [Price], [MakerID]) VALUES (2, 1, N'Stay C#', 37.5000, 2)
INSERT [dbo].[Articles] ([ArticlesID], [Code], [Name], [Price], [MakerID]) VALUES (3, 2, N'Lil'' SQL', 44.5000, 3)
INSERT [dbo].[Articles] ([ArticlesID], [Code], [Name], [Price], [MakerID]) VALUES (4, 3, N'Lamia HTML', 10.0000, 6)
INSERT [dbo].[Articles] ([ArticlesID], [Code], [Name], [Price], [MakerID]) VALUES (5, 4, N'CSS', 5.0000, 6)
INSERT [dbo].[Articles] ([ArticlesID], [Code], [Name], [Price], [MakerID]) VALUES (6, 5, N'Laser Printer', 15.0000, 8)
INSERT [dbo].[Articles] ([ArticlesID], [Code], [Name], [Price], [MakerID]) VALUES (7, 6, N'This is Ruby', 10.0000, 7)
INSERT [dbo].[Articles] ([ArticlesID], [Code], [Name], [Price], [MakerID]) VALUES (8, 7, N'Python and Ai', 35.0000, 1)
INSERT [dbo].[Articles] ([ArticlesID], [Code], [Name], [Price], [MakerID]) VALUES (9, 8, N'Javascript ', 15.0000, 9)
INSERT [dbo].[Articles] ([ArticlesID], [Code], [Name], [Price], [MakerID]) VALUES (10, 9, N'Java', 20.0000, 10)
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
SET IDENTITY_INSERT [dbo].[Manufacturers] ON 

INSERT [dbo].[Manufacturers] ([MakerID], [Code], [Name]) VALUES (1, 1, N'Alchemax')
INSERT [dbo].[Manufacturers] ([MakerID], [Code], [Name]) VALUES (2, 2, N'Keeneye')
INSERT [dbo].[Manufacturers] ([MakerID], [Code], [Name]) VALUES (3, 3, N'Penier')
INSERT [dbo].[Manufacturers] ([MakerID], [Code], [Name]) VALUES (4, 4, N'Fad')
INSERT [dbo].[Manufacturers] ([MakerID], [Code], [Name]) VALUES (5, 5, N'Walter''s')
INSERT [dbo].[Manufacturers] ([MakerID], [Code], [Name]) VALUES (6, 6, N'Reiners')
INSERT [dbo].[Manufacturers] ([MakerID], [Code], [Name]) VALUES (7, 7, N'Daily')
INSERT [dbo].[Manufacturers] ([MakerID], [Code], [Name]) VALUES (8, 8, N'Yens')
INSERT [dbo].[Manufacturers] ([MakerID], [Code], [Name]) VALUES (9, 9, N'Donald''s')
INSERT [dbo].[Manufacturers] ([MakerID], [Code], [Name]) VALUES (10, 10, N'Sweaty')
SET IDENTITY_INSERT [dbo].[Manufacturers] OFF
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Manufacturers] FOREIGN KEY([MakerID])
REFERENCES [dbo].[Manufacturers] ([MakerID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Manufacturers]
GO
USE [master]
GO
ALTER DATABASE [ManufacturersDB] SET  READ_WRITE 
GO
