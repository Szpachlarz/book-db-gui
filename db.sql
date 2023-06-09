USE [master]
GO
/****** Object:  Database [ProjectDB]    Script Date: 21.06.2022 23:42:32 ******/
CREATE DATABASE [ProjectDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectDB', FILENAME = N'C:\Users\tenag\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\PoSrv\ProjectDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectDB_log', FILENAME = N'C:\Users\tenag\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\PoSrv\ProjectDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjectDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [ProjectDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [ProjectDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [ProjectDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [ProjectDB] SET ARITHABORT ON 
GO
ALTER DATABASE [ProjectDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [ProjectDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [ProjectDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [ProjectDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProjectDB] SET QUERY_STORE = OFF
GO
USE [ProjectDB]
GO
/****** Object:  Table [dbo].[PITy]    Script Date: 21.06.2022 23:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PITy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data_rozliczenia] [nvarchar](max) NULL,
	[usid] [int] NOT NULL,
	[pesel] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[surname] [nvarchar](max) NULL,
	[miejscowosc] [nvarchar](max) NULL,
	[ulica] [nvarchar](max) NULL,
	[adres] [nvarchar](max) NULL,
	[numer_domu] [nvarchar](max) NULL,
	[kod_pocztowy] [nvarchar](max) NULL,
	[birthdate] [nvarchar](max) NULL,
	[ubezp_zdrow] [nvarchar](max) NULL,
	[ubezp_spol] [nvarchar](max) NULL,
	[p_zwolniony] [nvarchar](max) NULL,
	[p_opodatkowany] [nvarchar](max) NULL,
	[naleznosc] [nvarchar](max) NULL,
	[do_zaplaty] [nvarchar](max) NULL,
	[nadplata] [nvarchar](max) NULL,
	[zaliczki] [nvarchar](max) NULL,
 CONSTRAINT [PK_PITy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[PITyView]    Script Date: 21.06.2022 23:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PITyView]
AS
SELECT dbo.PITy.*
FROM     dbo.PITy
GO
/****** Object:  Table [dbo].[PIT_m]    Script Date: 21.06.2022 23:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PIT_m](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data_rozliczenia] [nvarchar](max) NULL,
	[usid] [int] NOT NULL,
	[pesel] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[surname] [nvarchar](max) NULL,
	[miejscowosc] [nvarchar](max) NULL,
	[ulica] [nvarchar](max) NULL,
	[adres] [nvarchar](max) NULL,
	[numer_domu] [nvarchar](max) NULL,
	[kod_pocztowy] [nvarchar](max) NULL,
	[birthdate] [nvarchar](max) NULL,
	[ubezp_zdrow] [nvarchar](max) NULL,
	[ubezp_spol] [nvarchar](max) NULL,
	[p_zwolniony] [nvarchar](max) NULL,
	[p_opodatkowany] [nvarchar](max) NULL,
	[naleznosc] [nvarchar](max) NULL,
	[do_zaplaty] [nvarchar](max) NULL,
	[nadplata] [nvarchar](max) NULL,
	[zaliczki] [nvarchar](max) NULL,
 CONSTRAINT [PK_PIT_m] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Pit_mView]    Script Date: 21.06.2022 23:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Pit_mView]
AS
SELECT dbo.PIT_m.*
FROM     dbo.PIT_m
GO
/****** Object:  Table [dbo].[UsersTab]    Script Date: 21.06.2022 23:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersTab](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Passwd] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_UsersTab] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UsersView]    Script Date: 21.06.2022 23:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UsersView]
AS
SELECT dbo.UsersTab.*
FROM     dbo.UsersTab
GO
ALTER TABLE [dbo].[UsersTab] ADD  CONSTRAINT [DF_UsersTab_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
/****** Object:  StoredProcedure [dbo].[NewDeleteCommand]    Script Date: 21.06.2022 23:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NewDeleteCommand]
(
	@Original_ID int,
	@Original_Name nvarchar(50),
	@Original_Surname nvarchar(50),
	@Original_Email nvarchar(50),
	@Original_Passwd nvarchar(50),
	@Original_Country nvarchar(50),
	@IsNull_IsAdmin Int,
	@Original_IsAdmin bit
)
AS
	SET NOCOUNT OFF;
DELETE FROM [UsersTab] WHERE (([ID] = @Original_ID) AND ([Name] = @Original_Name) AND ([Surname] = @Original_Surname) AND ([Email] = @Original_Email) AND ([Passwd] = @Original_Passwd) AND ([Country] = @Original_Country) AND ((@IsNull_IsAdmin = 1 AND [IsAdmin] IS NULL) OR ([IsAdmin] = @Original_IsAdmin)))
GO
/****** Object:  StoredProcedure [dbo].[NewInsertCommand]    Script Date: 21.06.2022 23:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NewInsertCommand]
(
	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Email nvarchar(50),
	@Passwd nvarchar(50),
	@Country nvarchar(50),
	@IsAdmin bit
)
AS
	SET NOCOUNT OFF;
INSERT INTO [UsersTab] ([Name], [Surname], [Email], [Passwd], [Country], [IsAdmin]) VALUES (@Name, @Surname, @Email, @Passwd, @Country, @IsAdmin);
	
SELECT ID, Name, Surname, Email, Passwd, Country, IsAdmin FROM UsersTab WHERE (ID = SCOPE_IDENTITY())
GO
/****** Object:  StoredProcedure [dbo].[NewSelectCommand]    Script Date: 21.06.2022 23:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NewSelectCommand]
AS
	SET NOCOUNT ON;
SELECT UsersTab.*
FROM     UsersTab
GO
/****** Object:  StoredProcedure [dbo].[NewUpdateCommand]    Script Date: 21.06.2022 23:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NewUpdateCommand]
(
	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Email nvarchar(50),
	@Passwd nvarchar(50),
	@Country nvarchar(50),
	@IsAdmin bit,
	@Original_ID int,
	@Original_Name nvarchar(50),
	@Original_Surname nvarchar(50),
	@Original_Email nvarchar(50),
	@Original_Passwd nvarchar(50),
	@Original_Country nvarchar(50),
	@IsNull_IsAdmin Int,
	@Original_IsAdmin bit,
	@ID int
)
AS
	SET NOCOUNT OFF;
UPDATE [UsersTab] SET [Name] = @Name, [Surname] = @Surname, [Email] = @Email, [Passwd] = @Passwd, [Country] = @Country, [IsAdmin] = @IsAdmin WHERE (([ID] = @Original_ID) AND ([Name] = @Original_Name) AND ([Surname] = @Original_Surname) AND ([Email] = @Original_Email) AND ([Passwd] = @Original_Passwd) AND ([Country] = @Original_Country) AND ((@IsNull_IsAdmin = 1 AND [IsAdmin] IS NULL) OR ([IsAdmin] = @Original_IsAdmin)));
	
SELECT ID, Name, Surname, Email, Passwd, Country, IsAdmin FROM UsersTab WHERE (ID = @ID)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PIT_m"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 257
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Pit_mView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Pit_mView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PITy"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 257
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PITyView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PITyView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "UsersTab"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UsersView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UsersView'
GO
USE [master]
GO
ALTER DATABASE [ProjectDB] SET  READ_WRITE 
GO
