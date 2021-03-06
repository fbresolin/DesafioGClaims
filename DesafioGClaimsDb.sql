USE [master]
GO
/****** Object:  Database [DesafioGClaimsDb]    Script Date: 07/05/2022 01:00:55 ******/
CREATE DATABASE [DesafioGClaimsDb]
 CONTAINMENT = NONE
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DesafioGClaimsDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DesafioGClaimsDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DesafioGClaimsDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DesafioGClaimsDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DesafioGClaimsDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DesafioGClaimsDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DesafioGClaimsDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DesafioGClaimsDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DesafioGClaimsDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DesafioGClaimsDb] SET  MULTI_USER 
GO
ALTER DATABASE [DesafioGClaimsDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DesafioGClaimsDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DesafioGClaimsDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DesafioGClaimsDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DesafioGClaimsDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DesafioGClaimsDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DesafioGClaimsDb] SET QUERY_STORE = OFF
GO
USE [DesafioGClaimsDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 07/05/2022 01:00:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 07/05/2022 01:00:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Characters](
	[CharacterId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Characters] PRIMARY KEY CLUSTERED 
(
	[CharacterId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07/05/2022 01:00:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_User_Id]    Script Date: 07/05/2022 01:00:55 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[Characters]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Characters]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Characters_dbo.Users_User_Id] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Characters] CHECK CONSTRAINT [FK_dbo.Characters_dbo.Users_User_Id]
GO
USE [master]
GO
ALTER DATABASE [DesafioGClaimsDb] SET  READ_WRITE 
GO
