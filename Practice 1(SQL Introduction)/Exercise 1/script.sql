USE [master]
GO
/****** Object:  Database [DepartmentDB]    Script Date: 8/27/2021 8:00:16 AM ******/
CREATE DATABASE [DepartmentDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DepartmentDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DepartmentDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DepartmentDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DepartmentDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DepartmentDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DepartmentDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DepartmentDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DepartmentDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DepartmentDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DepartmentDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DepartmentDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DepartmentDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DepartmentDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DepartmentDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DepartmentDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DepartmentDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DepartmentDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DepartmentDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DepartmentDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DepartmentDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DepartmentDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DepartmentDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DepartmentDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DepartmentDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DepartmentDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DepartmentDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DepartmentDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DepartmentDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DepartmentDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DepartmentDB] SET  MULTI_USER 
GO
ALTER DATABASE [DepartmentDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DepartmentDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DepartmentDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DepartmentDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DepartmentDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DepartmentDB] SET QUERY_STORE = OFF
GO
USE [DepartmentDB]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 8/27/2021 8:00:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[assignid] [int] NOT NULL,
	[departmentid] [int] NULL,
	[employeeid] [int] NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[assignid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 8/27/2021 8:00:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[departmentid] [int] NOT NULL,
	[name] [varchar](50) NULL,
	[director] [varchar](50) NULL,
	[annual_budget] [money] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[departmentid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 8/27/2021 8:00:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[employeeid] [int] NOT NULL,
	[fname] [varchar](50) NULL,
	[lname] [varchar](50) NULL,
	[category] [varchar](50) NULL,
	[activity] [varchar](50) NULL,
	[departmentid] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[employeeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (0, 2, 0)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (1, 2, 1)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (2, 1, 2)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (3, 4, 3)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (4, 6, 4)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (5, 7, 5)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (6, 8, 6)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (7, 9, 7)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (8, 11, 8)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (9, 10, 9)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (10, 3, 10)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (11, 5, 11)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (12, 2, 12)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (13, 2, 13)
INSERT [dbo].[Assignments] ([assignid], [departmentid], [employeeid]) VALUES (14, 3, 14)
GO
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (0, N'IT', N'Tyler', 133650.0000)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (1, N'Research', N'Bill', 142560.0446)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (2, N'Human Resources', N'Werner', 124740.0000)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (3, N'Accounting', N'Herbert', 115830.0000)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (4, N'Finance', N'Sasha', 98010.0000)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (5, N'QA', N'Lillie', 8910.0000)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (6, N'Intendance', N'Yaldric', 8910.0000)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (7, N'Computing', N'Ben', 160380.0000)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (8, N'Legal', N'Egen', 142560.2673)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (9, N'School Control', N'Ted', 8910.0000)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (10, N'Commerce', N'Laura', 151470.0000)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (11, N'Law', N'Henry', 115830.0000)
INSERT [dbo].[Departments] ([departmentid], [name], [director], [annual_budget]) VALUES (12, N'Unimportant Matters', NULL, 124740.0000)
GO
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (0, N'Ted', N'Bundy', N'IT', N'Testing', 0)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (1, N'Ben', N'Parker', N'IT', N'Manangement', 0)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (2, N'Vick', N'Ton', N'Programming', N'Head Designer', 7)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (3, N'Sebastin', N'Montalavo', N'Tech', N'Coding', 7)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (4, N'Effe', N'IDK', N'Repair', N'Automation', 10)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (5, N'Will', N'Smith', N'Actor', N'Jokes', 8)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (6, N'Gary', N'Wilbert', N'Testing', N'Playtesting', 9)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (7, N'Terry', N'William', N'Waivers', N'Assisstant', 11)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (8, N'Gavin', N'Baltist', N'Management', N'Vice-Mananger', 4)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (9, N'Gideon', N'Baltist', N'Management', N'Mananger', 4)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (10, N'Darcy', N'Hemsworth', N'Accounting', N'Assistant', 3)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (11, N'Henry', N'Stickman', N'Reference', N'Obscure', 6)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (12, N'Wakin', N'Peacock', N'Psycology', N'Teetering', 2)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (13, N'Steven', N'King', N'Horror', N'Writer', 5)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (14, N'David', N'Fuller', N'Acting', N'Monk', 6)
INSERT [dbo].[Employees] ([employeeid], [fname], [lname], [category], [activity], [departmentid]) VALUES (17, N'John', N'Smith', NULL, NULL, 12)
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [DepartmentLink] FOREIGN KEY([departmentid])
REFERENCES [dbo].[Departments] ([departmentid])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [DepartmentLink]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [EmployeeLink] FOREIGN KEY([employeeid])
REFERENCES [dbo].[Employees] ([employeeid])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [EmployeeLink]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [Emp2DepLink] FOREIGN KEY([departmentid])
REFERENCES [dbo].[Departments] ([departmentid])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [Emp2DepLink]
GO
USE [master]
GO
ALTER DATABASE [DepartmentDB] SET  READ_WRITE 
GO
