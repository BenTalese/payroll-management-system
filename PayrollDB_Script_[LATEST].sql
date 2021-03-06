USE [master]
GO
/****** Object:  Database [PayrollDB]    Script Date: 15/06/2021 12:28:46 PM ******/
CREATE DATABASE [PayrollDB]
ALTER DATABASE [PayrollDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PayrollDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PayrollDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PayrollDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PayrollDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PayrollDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PayrollDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PayrollDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PayrollDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PayrollDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PayrollDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PayrollDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PayrollDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PayrollDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PayrollDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PayrollDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PayrollDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PayrollDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PayrollDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PayrollDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PayrollDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PayrollDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PayrollDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PayrollDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PayrollDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PayrollDB] SET  MULTI_USER 
GO
ALTER DATABASE [PayrollDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PayrollDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PayrollDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PayrollDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PayrollDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PayrollDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PayrollDB] SET QUERY_STORE = OFF
GO
USE [PayrollDB]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 15/06/2021 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PayRate] [decimal](6, 3) NULL,
	[YearToDate] [decimal](10, 3) NULL,
 CONSTRAINT [Employee_PK] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payslip]    Script Date: 15/06/2021 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payslip](
	[PayslipID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[HoursWorked] [decimal](8, 3) NOT NULL,
	[GrossPay] [decimal](10, 3) NOT NULL,
	[NetPay] [decimal](10, 3) NOT NULL,
	[Tax] [decimal](10, 3) NOT NULL,
	[PayStateID] [int] NOT NULL,
 CONSTRAINT [Payslip_PK] PRIMARY KEY CLUSTERED 
(
	[PayslipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RosteredShift]    Script Date: 15/06/2021 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RosteredShift](
	[EmployeeID] [int] NOT NULL,
	[ShiftID] [int] NOT NULL,
 CONSTRAINT [ShiftWorked_PK] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[ShiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 15/06/2021 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shift](
	[ShiftID] [int] IDENTITY(1,1) NOT NULL,
	[ShiftDate] [date] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
 CONSTRAINT [Shift_PK] PRIMARY KEY CLUSTERED 
(
	[ShiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [PayRate], [YearToDate]) VALUES (11111, N'John', N'Doe', CAST(25.513 AS Decimal(6, 3)), CAST(22536.500 AS Decimal(10, 3)))
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [PayRate], [YearToDate]) VALUES (22222, N'Jane', N'Smith', CAST(31.120 AS Decimal(6, 3)), CAST(36567.430 AS Decimal(10, 3)))
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [PayRate], [YearToDate]) VALUES (33333, N'Bob', N'Lee', CAST(48.150 AS Decimal(6, 3)), CAST(75046.257 AS Decimal(10, 3)))
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [PayRate], [YearToDate]) VALUES (44444, N'Hank', N'Jebbs', CAST(29.850 AS Decimal(6, 3)), CAST(10900.980 AS Decimal(10, 3)))
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Payslip] ON 

INSERT [dbo].[Payslip] ([PayslipID], [EmployeeID], [HoursWorked], [GrossPay], [NetPay], [Tax], [PayStateID]) VALUES (1, 11111, CAST(0.000 AS Decimal(8, 3)), CAST(0.000 AS Decimal(10, 3)), CAST(0.000 AS Decimal(10, 3)), CAST(0.000 AS Decimal(10, 3)), 1)
SET IDENTITY_INSERT [dbo].[Payslip] OFF
GO
INSERT [dbo].[RosteredShift] ([EmployeeID], [ShiftID]) VALUES (11111, 10101)
INSERT [dbo].[RosteredShift] ([EmployeeID], [ShiftID]) VALUES (11111, 20202)
INSERT [dbo].[RosteredShift] ([EmployeeID], [ShiftID]) VALUES (11111, 60608)
INSERT [dbo].[RosteredShift] ([EmployeeID], [ShiftID]) VALUES (22222, 10101)
INSERT [dbo].[RosteredShift] ([EmployeeID], [ShiftID]) VALUES (33333, 30303)
INSERT [dbo].[RosteredShift] ([EmployeeID], [ShiftID]) VALUES (33333, 40404)
INSERT [dbo].[RosteredShift] ([EmployeeID], [ShiftID]) VALUES (33333, 50505)
INSERT [dbo].[RosteredShift] ([EmployeeID], [ShiftID]) VALUES (33333, 60606)
INSERT [dbo].[RosteredShift] ([EmployeeID], [ShiftID]) VALUES (44444, 10101)
INSERT [dbo].[RosteredShift] ([EmployeeID], [ShiftID]) VALUES (44444, 60606)
GO
SET IDENTITY_INSERT [dbo].[Shift] ON 

INSERT [dbo].[Shift] ([ShiftID], [ShiftDate], [StartTime], [EndTime]) VALUES (10101, CAST(N'2019-09-17' AS Date), CAST(N'08:30:00' AS Time), CAST(N'16:30:00' AS Time))
INSERT [dbo].[Shift] ([ShiftID], [ShiftDate], [StartTime], [EndTime]) VALUES (20202, CAST(N'2019-09-18' AS Date), CAST(N'08:30:00' AS Time), CAST(N'16:30:00' AS Time))
INSERT [dbo].[Shift] ([ShiftID], [ShiftDate], [StartTime], [EndTime]) VALUES (30303, CAST(N'2019-09-19' AS Date), CAST(N'08:30:00' AS Time), CAST(N'16:30:00' AS Time))
INSERT [dbo].[Shift] ([ShiftID], [ShiftDate], [StartTime], [EndTime]) VALUES (40404, CAST(N'2019-09-17' AS Date), CAST(N'10:30:00' AS Time), CAST(N'14:30:00' AS Time))
INSERT [dbo].[Shift] ([ShiftID], [ShiftDate], [StartTime], [EndTime]) VALUES (50505, CAST(N'2019-09-18' AS Date), CAST(N'10:30:00' AS Time), CAST(N'14:30:00' AS Time))
INSERT [dbo].[Shift] ([ShiftID], [ShiftDate], [StartTime], [EndTime]) VALUES (60606, CAST(N'2019-09-19' AS Date), CAST(N'10:30:00' AS Time), CAST(N'14:30:00' AS Time))
INSERT [dbo].[Shift] ([ShiftID], [ShiftDate], [StartTime], [EndTime]) VALUES (60607, CAST(N'2021-06-14' AS Date), CAST(N'15:36:45.9824129' AS Time), CAST(N'16:36:45.9824129' AS Time))
INSERT [dbo].[Shift] ([ShiftID], [ShiftDate], [StartTime], [EndTime]) VALUES (60608, CAST(N'2021-06-14' AS Date), CAST(N'15:39:10.0383788' AS Time), CAST(N'16:39:10.0383788' AS Time))
SET IDENTITY_INSERT [dbo].[Shift] OFF
GO
ALTER TABLE [dbo].[Payslip]  WITH CHECK ADD  CONSTRAINT [Payslip_Employee_FK] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Payslip] CHECK CONSTRAINT [Payslip_Employee_FK]
GO
ALTER TABLE [dbo].[RosteredShift]  WITH CHECK ADD  CONSTRAINT [ShiftWorked_Employee_FK] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[RosteredShift] CHECK CONSTRAINT [ShiftWorked_Employee_FK]
GO
ALTER TABLE [dbo].[RosteredShift]  WITH CHECK ADD  CONSTRAINT [ShiftWorked_Shift_FK] FOREIGN KEY([ShiftID])
REFERENCES [dbo].[Shift] ([ShiftID])
GO
ALTER TABLE [dbo].[RosteredShift] CHECK CONSTRAINT [ShiftWorked_Shift_FK]
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectEmployees]    Script Date: 15/06/2021 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SelectEmployees]
AS
BEGIN
	SELECT * FROM Employee;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectRosteredShiftsByEmployeeID]    Script Date: 15/06/2021 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_SelectRosteredShiftsByEmployeeID]
	@id int
AS
BEGIN
	SELECT s.ShiftID, s.ShiftDate, s.StartTime, s.EndTime
	FROM dbo.RosteredShift rs, dbo.[Shift] s
	WHERE rs.ShiftID = s.ShiftID
	AND rs.EmployeeID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectShifts]    Script Date: 15/06/2021 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SelectShifts]
AS
BEGIN
	SELECT * FROM [Shift];
END
GO
USE [master]
GO
ALTER DATABASE [PayrollDB] SET  READ_WRITE 
GO
