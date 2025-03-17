USE [master]
GO
/****** Object:  Database [CodeChallengeGlasslewis]    Script Date: 17/03/2025 13:36:05 ******/
CREATE DATABASE [CodeChallengeGlasslewis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CodeChallengeGlasslewis', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CodeChallengeGlasslewis.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CodeChallengeGlasslewis_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CodeChallengeGlasslewis_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CodeChallengeGlasslewis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET ARITHABORT OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET  MULTI_USER 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET QUERY_STORE = ON
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CodeChallengeGlasslewis]
GO
/****** Object:  Table [dbo].[dbo.tbl_UserMaster]    Script Date: 17/03/2025 13:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dbo.tbl_UserMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.tbl_UserMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_companyData]    Script Date: 17/03/2025 13:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_companyData](
	[Id] [int] IDENTITY(501,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Exchange] [nvarchar](50) NOT NULL,
	[Ticker] [nvarchar](10) NOT NULL,
	[Isin] [varchar](12) NOT NULL,
	[website] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_companyData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[dbo.tbl_UserMaster] ON 

INSERT [dbo].[dbo.tbl_UserMaster] ([Id], [UserName], [Password]) VALUES (1, N'Developer123', N'dev@Full$pqrs')
SET IDENTITY_INSERT [dbo].[dbo.tbl_UserMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_companyData] ON 

INSERT [dbo].[tbl_companyData] ([Id], [Name], [Exchange], [Ticker], [Isin], [website]) VALUES (501, N'Apple Inc.', N'NASDAQ', N'AAPL', N'US0378331005', N'http://www.apple.com')
INSERT [dbo].[tbl_companyData] ([Id], [Name], [Exchange], [Ticker], [Isin], [website]) VALUES (502, N'British Airways Plc', N'Pink Sheets', N'BAIRY', N'US1104193065', NULL)
INSERT [dbo].[tbl_companyData] ([Id], [Name], [Exchange], [Ticker], [Isin], [website]) VALUES (506, N'Heineken NV', N'Euronext Amsterdam', N'HEIA', N'NL0000009165', NULL)
INSERT [dbo].[tbl_companyData] ([Id], [Name], [Exchange], [Ticker], [Isin], [website]) VALUES (508, N'Panasonic Corp', N'Tokyo Stock Exchange', N'6752', N'JP3866800000', N'http://www.panasonic.co.jp')
INSERT [dbo].[tbl_companyData] ([Id], [Name], [Exchange], [Ticker], [Isin], [website]) VALUES (510, N'Porsche Automobil', N'Deutsche Borse', N'PAH3', N'DE000PAH0038', N'https://www.porsche.com/')
SET IDENTITY_INSERT [dbo].[tbl_companyData] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [some_name]    Script Date: 17/03/2025 13:36:05 ******/
ALTER TABLE [dbo].[tbl_companyData] ADD  CONSTRAINT [some_name] UNIQUE NONCLUSTERED 
(
	[Isin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [CodeChallengeGlasslewis] SET  READ_WRITE 
GO
