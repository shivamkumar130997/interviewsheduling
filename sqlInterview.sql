USE [master]
GO
/****** Object:  Database [InterviewSchedulingProject]    Script Date: 6/20/2022 1:28:53 AM ******/
CREATE DATABASE [InterviewSchedulingProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InterviewSchedulingProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\InterviewSchedulingProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InterviewSchedulingProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\InterviewSchedulingProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [InterviewSchedulingProject] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InterviewSchedulingProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InterviewSchedulingProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [InterviewSchedulingProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InterviewSchedulingProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InterviewSchedulingProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET  ENABLE_BROKER 
GO
ALTER DATABASE [InterviewSchedulingProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InterviewSchedulingProject] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [InterviewSchedulingProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InterviewSchedulingProject] SET  MULTI_USER 
GO
ALTER DATABASE [InterviewSchedulingProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InterviewSchedulingProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InterviewSchedulingProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InterviewSchedulingProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InterviewSchedulingProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InterviewSchedulingProject] SET QUERY_STORE = OFF
GO
USE [InterviewSchedulingProject]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[candidateFullDetails]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[candidateFullDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DOB] [datetime2](7) NULL,
	[Experince] [real] NULL,
	[Gender] [int] NULL,
	[Password] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[firstname] [nvarchar](max) NULL,
	[graduation] [real] NULL,
	[lastname] [nvarchar](max) NULL,
	[phoneno] [nvarchar](max) NULL,
	[postgraduation] [real] NULL,
	[skills] [nvarchar](max) NULL,
	[tenth] [real] NULL,
	[twelth] [real] NULL,
	[username] [nvarchar](max) NULL,
	[selected] [bit] NULL,
 CONSTRAINT [PK_candidateFullDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CandidateUser]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](100) NULL,
	[username] [nvarchar](50) NULL,
	[firstname] [nvarchar](100) NULL,
	[lastname] [nvarchar](100) NULL,
	[phoneno] [nvarchar](max) NULL,
	[Gender] [int] NULL,
	[DOB] [datetime2](7) NULL,
	[Role] [nvarchar](max) NULL,
	[selected] [bit] NULL,
	[InterviewTiming] [datetime2](7) NULL,
 CONSTRAINT [PK_CandidateUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[condidateDetails]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[condidateDetails](
	[canditateid] [int] IDENTITY(1,1) NOT NULL,
	[tenth] [real] NULL,
	[twelth] [real] NULL,
	[graduation] [real] NULL,
	[postgraduation] [real] NULL,
	[skills] [nvarchar](1000) NULL,
	[Experince] [real] NULL,
	[Candidateid] [int] NULL,
	[Company] [nvarchar](1000) NULL,
 CONSTRAINT [PK_condidateDetails] PRIMARY KEY CLUSTERED 
(
	[canditateid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_condidateDetails_Candidateid]    Script Date: 6/20/2022 1:28:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_condidateDetails_Candidateid] ON [dbo].[condidateDetails]
(
	[Candidateid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[condidateDetails]  WITH CHECK ADD  CONSTRAINT [FK_condidateDetails_CandidateUser_Candidateid] FOREIGN KEY([Candidateid])
REFERENCES [dbo].[CandidateUser] ([id])
GO
ALTER TABLE [dbo].[condidateDetails] CHECK CONSTRAINT [FK_condidateDetails_CandidateUser_Candidateid]
GO
/****** Object:  StoredProcedure [dbo].[Customers_SearchCustomers]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create PROCEDURE [dbo].[Customers_SearchCustomers]
    @Name NVARCHAR(30)

AS

BEGIN 
SET NOCOUNT ON;

SELECT s.id, s.username ,s.password,s.firstname,s.selected,s.lastname,s.phoneno,s.Gender,s.DOB,s.role,t.Experince,t.graduation,t.postgraduation,t.skills,t.tenth,t.twelth

FROM   [dbo].[CandidateUser] s  
left join  [dbo].[condidateDetails] t
ON t.Candidateid= s.id where  s.Role='Candidate' and s.username LIKE '%' + @Name + '%' or s.firstname LIKE '%' + @Name + '%' or s.phoneno  LIKE '%' + @Name + '%' or t.skills  LIKE '%' + @Name + '%'  or t.Experince LIKE '%' + @Name + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[GetCandidateList]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetCandidateList]
   

AS

BEGIN 

SELECT s.id, s.username ,s.password,s.firstname,s.lastname,s.phoneno,s.Gender,s.DOB,s.role,t.Experince,t.graduation,t.postgraduation,t.skills,t.tenth,t.twelth,t.Company

FROM   [dbo].[CandidateUser] s  
left join  [dbo].[condidateDetails] t
ON t.Candidateid= s.id 
END

GO
/****** Object:  StoredProcedure [dbo].[GetCandidateList1]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetCandidateList1]
   

AS

BEGIN 

SELECT s.id, s.username ,s.password,s.firstname,s.selected,s.lastname,s.phoneno,s.Gender,s.DOB,s.role,t.Experince,t.graduation,t.postgraduation,t.skills,t.tenth,t.twelth,t.Company

FROM   [dbo].[CandidateUser] s  
left join  [dbo].[condidateDetails] t
ON t.Candidateid= s.id where s.Role='Candidate'
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeDetail]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetEmployeeDetail]
    @userid int

AS

BEGIN 

SELECT s.id, s.username ,s.password,s.firstname,s.lastname,s.phoneno,s.Gender,s.DOB,s.role,t.Experince,t.graduation,t.postgraduation,t.skills,t.tenth,t.twelth

FROM   [dbo].[CandidateUser] s  
left join  [dbo].[condidateDetails] t
ON t.Candidateid= s.id 
WHERE  s.id = @userid
END

GO
/****** Object:  StoredProcedure [dbo].[GetSelectedCandidateList1]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[GetSelectedCandidateList1]
   

AS

BEGIN 

SELECT s.id, s.username ,s.password,s.firstname,s.selected,s.lastname,s.phoneno,s.Gender,s.DOB,s.role,t.Experince,t.graduation,t.postgraduation,t.skills,t.tenth,t.twelth,t.Company

FROM   [dbo].[CandidateUser] s  
left join  [dbo].[condidateDetails] t
ON t.Candidateid= s.id 
where s.selected='True' and s.Role='Candidate'
END

GO
/****** Object:  StoredProcedure [dbo].[SearchCandidate]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SearchCandidate]
    @Name NVARCHAR(30)

AS

BEGIN 
SET NOCOUNT ON;

SELECT s.id, s.username ,s.password,s.firstname,s.selected,s.lastname,s.phoneno,s.Gender,s.DOB,s.role,t.Experince,t.graduation,t.postgraduation,t.skills,t.tenth,t.twelth,t.Company

FROM   [dbo].[CandidateUser] s  
left join  [dbo].[condidateDetails] t
ON t.Candidateid= s.id where  s.Role='Candidate' and (s.username LIKE '%' + @Name + '%' or s.firstname LIKE '%' + @Name + '%' or s.phoneno  LIKE '%' + @Name + '%' or t.skills  LIKE '%' + @Name + '%'  or t.Experince LIKE '%' + @Name + '%' or t.Company LIKE '%' + @Name + '%')
END
GO
/****** Object:  StoredProcedure [dbo].[SearchCandidateselcted]    Script Date: 6/20/2022 1:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[SearchCandidateselcted]
    @Name NVARCHAR(30)

AS

BEGIN 
SET NOCOUNT ON;

SELECT s.id, s.username ,s.password,s.firstname,s.selected,s.lastname,s.phoneno,s.Gender,s.DOB,s.role,t.Experince,t.graduation,t.postgraduation,t.skills,t.tenth,t.twelth,t.Company

FROM   [dbo].[CandidateUser] s  
left join  [dbo].[condidateDetails] t
ON t.Candidateid= s.id where  s.Role='Candidate'and s.selected='1' and (s.username LIKE '%' + @Name + '%' or s.firstname LIKE '%' + @Name + '%' or s.phoneno  LIKE '%' + @Name + '%' or t.skills  LIKE '%' + @Name + '%'  or t.Experince LIKE '%' + @Name + '%' or t.Company LIKE '%' + @Name + '%')
END
GO
USE [master]
GO
ALTER DATABASE [InterviewSchedulingProject] SET  READ_WRITE 
GO
