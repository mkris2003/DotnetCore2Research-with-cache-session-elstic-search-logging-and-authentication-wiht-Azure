USE [master]
GO
/****** Object:  Database [DotnetCoreDB]    Script Date: 5/7/2019 7:56:38 PM ******/
CREATE DATABASE [DotnetCoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DotnetCoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DotnetCoreDB.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DotnetCoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DotnetCoreDB_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DotnetCoreDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DotnetCoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DotnetCoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DotnetCoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DotnetCoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DotnetCoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DotnetCoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DotnetCoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [DotnetCoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DotnetCoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DotnetCoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DotnetCoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DotnetCoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DotnetCoreDB', N'ON'
GO
ALTER DATABASE [DotnetCoreDB] SET QUERY_STORE = OFF
GO
USE [DotnetCoreDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DotnetCoreDB]
GO
/****** Object:  Table [dbo].[City]    Script Date: 5/7/2019 7:56:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] NULL,
	[CityName] [varchar](50) NULL,
	[StateId] [int] NULL,
	[CountryId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 5/7/2019 7:56:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] NULL,
	[CountryName] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/7/2019 7:56:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpNo] [int] NULL,
	[EmpFirstName] [varchar](50) NULL,
	[EmpLastName] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[DateofJoined] [datetime2](7) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 5/7/2019 7:56:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](128) NULL,
	[TimeStamp] [datetimeoffset](7) NOT NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [xml] NULL,
	[LogEvent] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateId] [int] NULL,
	[StateName] [varchar](50) NULL,
	[CountryId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteCity]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		murali,Konanki
-- Create date: April-21-2019
-- Description:	Update City details
CREATE PROCEDURE [dbo].[USP_DeleteCity]
	-- Add the parameters for the stored procedure here
	(
		@CityId INT
		
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM  [dbo].[City]  
		WHERE [CityId]=@CityId
END
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteCountry]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		murali,Konanki
-- Create date: April-21-2019
-- Description:	Insert Country details
-- =============================================
CREATE PROCEDURE [dbo].[USP_DeleteCountry]
	-- Add the parameters for the stored procedure here
	(
		@CountryId INT
		
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  DELETE FROM [dbo].[Country]     
	WHERE [CountryId]=@CountryId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteEmployeeDetails]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Murali,Konanki
-- Create date: April-21-2019
-- Description:	Delete emaployee details

-- =============================================
CREATE PROCEDURE [dbo].[USP_DeleteEmployeeDetails]
	-- Add the parameters for the stored procedure here
	(
		@EmpNo INT=0		
		
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
DELETE FROM  [dbo].[Employee]  
 WHERE [EmpNo] =@EmpNo

END
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteStates]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		murali,Konanki
-- Create date: April-21-2019
-- Description:	Delete State details
-- =============================================
CREATE PROCEDURE [dbo].[USP_DeleteStates]
	-- Add the parameters for the stored procedure here
	(
		@StateId INT		
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[States] 
	WHERE  StateId=@StateId
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetCities]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Murali,Konanki
-- Create date: April-18-2019
-- Description:	 Get Cities details
-- =============================================
CREATE PROCEDURE [dbo].[USP_GetCities]
	-- Add the parameters for the stored procedure here
	(
		@CountryId INT,
		@StateId INT
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT TOP (1000) [CityId]
      ,[CityName]
	  ,[StateId]
      ,[CountryId]
     
  FROM [DotnetCoreDB].[dbo].[City] WITH(NOLOCK)
  WHERE [CountryId]=@CountryId AND  [StateId]=@StateId
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetCountry]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Murali,Konanki
-- Create date:April-18-2019
-- Description:	Get country details
-- =============================================
CREATE PROCEDURE [dbo].[USP_GetCountry]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP (1000) [CountryId]
      ,[CountryName]
  FROM [DotnetCoreDB].[dbo].[Country] WITH (NOLOCK)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetEmployeeDetails]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Murali,Konanki
-- Create date: April-18-2019
-- Description:	Get emaployee details
-- EXECUTE USP_GetEmployeeDetails
-- =============================================
CREATE PROCEDURE [dbo].[USP_GetEmployeeDetails]
	-- Add the parameters for the stored procedure here
	(
		@EmpNo INT=0,
		@EmpFirstName [varchar](50)='',
		@EmpLastName [varchar](50)='',
		@City [varchar](50)='',
		@State [varchar](50)='',
		@Country [varchar](50)='',
		@BeginDate [datetime2](7)= NULL,
		@EndDate [datetime2](7)= NULL,
		@PageNo INT = 1,
		@PageSize INT = 10,
		@SortColumn VARCHAR(20) = 'EmpNo',
		@SortOrder VARCHAR(20) = 'DESC'
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @DefaultIntValue INT =0,
	@DefaultStringValue VARCHAR(5)= '',
	@DefaultNullValue DATETIME2(7) = NULL;

  SELECT  [EmpNo]
      ,[EmpFirstName]
      ,[EmpLastName]
      ,[City]
      ,[State]
      ,[Country]
      ,[DateofJoined]
  FROM [DotnetCoreDB].[dbo].[Employee] WITH(NOLOCK)
  WHERE 
	[EmpNo]=
			CASE @EmpNo WHEN @DefaultIntValue THEN [EmpNo] ELSE  @EmpNo END 
	AND [EmpFirstName]=
			CASE @EmpFirstName WHEN @DefaultStringValue THEN [EmpFirstName] ELSE  @EmpFirstName END 
	AND [EmpLastName]=
			CASE @EmpLastName WHEN @DefaultStringValue THEN [EmpLastName] ELSE  @EmpLastName END 	
	AND [City]=
			CASE @City WHEN @DefaultStringValue THEN [City] ELSE  @City END 	
	AND [State]=
			CASE @State WHEN @DefaultStringValue THEN [State] ELSE  @State END 
	AND [Country]=
			CASE @Country WHEN @DefaultStringValue THEN [Country] ELSE  @Country END 
	AND [DateofJoined] BETWEEN CASE WHEN ISNULL( @BeginDate,@DefaultStringValue)=@DefaultStringValue THEN [DateofJoined] ELSE @BeginDate END
					AND CASE WHEN ISNULL(@EndDate,@DefaultStringValue)=@DefaultStringValue THEN [DateofJoined] ELSE @EndDate END

 ORDER BY
   		 CASE WHEN (@SortColumn = 'EmpNo' AND @SortOrder='ASC')
                    THEN EmpNo
        END ASC,
        CASE WHEN (@SortColumn = 'EmpNo' AND @SortOrder='DESC')
                   THEN EmpNo
		END DESC,

		CASE WHEN (@SortColumn = 'EmpFirstName' AND @SortOrder='ASC')
                    THEN EmpFirstName
        END ASC,
        CASE WHEN (@SortColumn = 'EmpFirstName' AND @SortOrder='DESC')
                   THEN EmpFirstName
		END DESC,
		CASE WHEN (@SortColumn = 'EmpLastName' AND @SortOrder='ASC')
                    THEN EmpLastName
        END ASC,
        CASE WHEN (@SortColumn = 'EmpLastName' AND @SortOrder='DESC')
                   THEN EmpLastName
		END DESC,
		CASE WHEN (@SortColumn = 'City' AND @SortOrder='ASC')
                    THEN City
        END ASC,
        CASE WHEN (@SortColumn = 'City' AND @SortOrder='DESC')
                   THEN City
		END DESC,
		CASE WHEN (@SortColumn = 'State' AND @SortOrder='ASC')
                    THEN [State]
        END ASC,
        CASE WHEN (@SortColumn = 'State' AND @SortOrder='DESC')
                   THEN [State]
		END DESC,
		CASE WHEN (@SortColumn = 'Country' AND @SortOrder='ASC')
                    THEN Country
        END ASC,
        CASE WHEN (@SortColumn = 'Country' AND @SortOrder='DESC')
                   THEN Country
		END DESC,
		CASE WHEN (@SortColumn = 'DateofJoined' AND @SortOrder='ASC')
                    THEN DateofJoined
        END ASC,
        CASE WHEN (@SortColumn = 'DateofJoined' AND @SortOrder='DESC')
                   THEN DateofJoined
		END DESC

		OFFSET @PageSize * (@PageNo - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetStates]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Murali,Konanki
-- Create date: April-18-2019
-- Description:	GetStates
-- USP_GetStates 1
-- =============================================
CREATE PROCEDURE [dbo].[USP_GetStates]
	-- Add the parameters for the stored procedure here
	(
		@CountryId INT
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP (1000) [StateId]
      ,[StateName]
      ,[CountryId]
  FROM [DotnetCoreDB].[dbo].[States] WITH (NOLOCK)
  WHERE [CountryId]=@CountryId
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertCity]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		murali,Konanki
-- Create date: April-21-2019
-- Description:	Insert City details
CREATE PROCEDURE [dbo].[USP_InsertCity]
	-- Add the parameters for the stored procedure here
	(
		@CityId INT,
		@CityName VARCHAR(50),
		@StateId INT,
		@CountryId INT
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[City]
           ([CityId]
           ,[CityName]
           ,[StateId]
           ,[CountryId])
     VALUES
           (@CityId
           ,@CityName
           ,@StateId
           ,@CountryId)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertCountry]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		murali,Konanki
-- Create date: April-20-2019
-- Description:	Insert Country details
-- =============================================
CREATE PROCEDURE [dbo].[USP_InsertCountry]
	-- Add the parameters for the stored procedure here
	(
		@CountryId INT,
		@CountryName VARCHAR(50)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   INSERT INTO [dbo].[Country]
           ([CountryId]
           ,[CountryName])
     VALUES
           (@CountryId
           ,@CountryName
		   )
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertEmployeeDetails]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Murali,Konanki
-- Create date: April-21-2019
-- Description:	Insert emaployee details

-- =============================================
CREATE PROCEDURE [dbo].[USP_InsertEmployeeDetails]
	-- Add the parameters for the stored procedure here
	(
		@EmpNo INT=0,
		@EmpFirstName [varchar](50)='',
		@EmpLastName [varchar](50)='',
		@City [varchar](50)='',
		@State [varchar](50)='',
		@Country [varchar](50)='',
		@DateofJoined [datetime2](7)= NULL
		
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Employee]
           ([EmpNo]
           ,[EmpFirstName]
           ,[EmpLastName]
           ,[City]
           ,[State]
           ,[Country]
           ,[DateofJoined])
     VALUES
           (@EmpNo
           ,@EmpFirstName
           ,@EmpLastName
           ,@City
           ,@State
           ,@Country
           ,@DateofJoined)

END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertStates]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		murali,Konanki
-- Create date: April-21-2019
-- Description:	Insert State details
-- =============================================
CREATE PROCEDURE [dbo].[USP_InsertStates]
	-- Add the parameters for the stored procedure here
	(
		@StateId INT,
		@StateName VARCHAR(50),
		@CountryId INT
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[States]
           ([StateId]
           ,[StateName]
           ,[CountryId])
     VALUES
           (@StateId
           ,@StateName
           ,@CountryId)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateCity]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		murali,Konanki
-- Create date: April-21-2019
-- Description:	Update City details
CREATE PROCEDURE [dbo].[USP_UpdateCity]
	-- Add the parameters for the stored procedure here
	(
		@CityId INT,
		@CityName VARCHAR(50),
		@StateId INT,
		@CountryId INT
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[City]
   SET 
      [CityName] = @CityName
      ,[StateId] = @StateId
      ,[CountryId] = @CountryId
 WHERE [CityId]=@CityId
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateCountry]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		murali,Konanki
-- Create date: April-20-2019
-- Description:	Insert Country details
-- =============================================
CREATE PROCEDURE [dbo].[USP_UpdateCountry]
	-- Add the parameters for the stored procedure here
	(
		@CountryId INT,
		@CountryName VARCHAR(50)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  UPDATE [dbo].[Country]
   SET 
     [CountryName] = @CountryName
 WHERE [CountryId]=@CountryId

END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateEmployeeDetails]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Murali,Konanki
-- Create date: April-21-2019
-- Description:	Update emaployee details

-- =============================================
CREATE PROCEDURE [dbo].[USP_UpdateEmployeeDetails]
	-- Add the parameters for the stored procedure here
	(
		@EmpNo INT=0,
		@EmpFirstName [varchar](50)='',
		@EmpLastName [varchar](50)='',
		@City [varchar](50)='',
		@State [varchar](50)='',
		@Country [varchar](50)='',
		@DateofJoined [datetime2](7)= NULL
		
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
UPDATE [dbo].[Employee]
   SET  
      [EmpFirstName] = @EmpFirstName
      ,[EmpLastName] = @EmpLastName
      ,[City] = @City
      ,[State] = @State
      ,[Country] = @Country
      ,[DateofJoined] = @DateofJoined
 WHERE [EmpNo] =@EmpNo

END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateStates]    Script Date: 5/7/2019 7:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		murali,Konanki
-- Create date: April-21-2019
-- Description:	Update State details
-- =============================================
CREATE PROCEDURE [dbo].[USP_UpdateStates]
	-- Add the parameters for the stored procedure here
	(
		@StateId INT,
		@StateName VARCHAR(50),
		@CountryId INT
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[States]
   SET 
      [StateName] = @StateName
      ,[CountryId] = @CountryId
 WHERE  StateId=@StateId
END
GO
USE [master]
GO
ALTER DATABASE [DotnetCoreDB] SET  READ_WRITE 
GO
