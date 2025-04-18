USE [master]
GO
/****** Object:  Database [ComputerTechnician]    Script Date: 4/12/2025 8:41:18 PM ******/
CREATE DATABASE [ComputerTechnician]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComputerTechnician', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ComputerTechnician.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ComputerTechnician_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ComputerTechnician_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ComputerTechnician] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComputerTechnician].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComputerTechnician] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComputerTechnician] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComputerTechnician] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComputerTechnician] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComputerTechnician] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComputerTechnician] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ComputerTechnician] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComputerTechnician] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComputerTechnician] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComputerTechnician] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComputerTechnician] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComputerTechnician] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComputerTechnician] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComputerTechnician] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComputerTechnician] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComputerTechnician] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComputerTechnician] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComputerTechnician] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComputerTechnician] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComputerTechnician] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComputerTechnician] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComputerTechnician] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComputerTechnician] SET RECOVERY FULL 
GO
ALTER DATABASE [ComputerTechnician] SET  MULTI_USER 
GO
ALTER DATABASE [ComputerTechnician] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComputerTechnician] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComputerTechnician] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComputerTechnician] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ComputerTechnician] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ComputerTechnician] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ComputerTechnician', N'ON'
GO
ALTER DATABASE [ComputerTechnician] SET QUERY_STORE = ON
GO
ALTER DATABASE [ComputerTechnician] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ComputerTechnician]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_fname] [varchar](25) NOT NULL,
	[customer_lname] [varchar](25) NOT NULL,
	[customer_email] [varchar](75) NOT NULL,
	[customer_phone] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[job_id] [int] IDENTITY(1,1) NOT NULL,
	[job_technician] [varchar](50) NOT NULL,
	[job_created] [datetime] NOT NULL,
	[job_finished] [datetime] NULL,
	[customer_id] [int] NOT NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[job_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[job_id] [int] NOT NULL,
	[service_id] [int] NOT NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[job_id] ASC,
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[service_id] [int] IDENTITY(1,1) NOT NULL,
	[service_name] [varchar](50) NOT NULL,
	[service_description] [varchar](100) NOT NULL,
	[service_cost] [float] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (1, N'Bobby', N'Chickin', N'chickfila@g.com', N'323-424-3333')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (3, N'Bruno', N'Mars', N'twentyfourkmagic@email.com', N'843-348-2439')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (6, N'Burger', N'King', N'bk@burgertown.org', N'123-342-3342')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (7, N'Tommy', N'Versetti', N'vicecity@rkstr.com', N'1-(456)-892-4856')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (9, N'Leon', N'Kennedy', N'wdegb@re.net', N'795-246-5684')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (11, N'Richard', N'Nixon', N'trickynixon@email.gov', N'424-867-5309')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (12, N'Ricky', N'LaFleur', N'bubbles@tpb.net', N'189-648-8976')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (13, N'Benjamin', N'Cuison', N'benc@email.com', N'123-456-7890')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (14, N'Dustin', N'Nastaj', N'dustinn@email.com', N'098-765-4321')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (15, N'Professor', N'Einstein', N'profeinstein@grcc.edu', N'888-222-3333')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (16, N'Issac', N'Newton', N'sirissacnewton@grcc.edu', N'124-678-3456')
INSERT [dbo].[Customer] ([customer_id], [customer_fname], [customer_lname], [customer_email], [customer_phone]) VALUES (17, N'Robert', N'Boyle', N'boyleslawrulz@email.edu', N'883-384-3399')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Job] ON 

INSERT [dbo].[Job] ([job_id], [job_technician], [job_created], [job_finished], [customer_id]) VALUES (15, N'Ben C', CAST(N'2025-04-11T23:24:00.000' AS DateTime), NULL, 17)
INSERT [dbo].[Job] ([job_id], [job_technician], [job_created], [job_finished], [customer_id]) VALUES (16, N'Ben C', CAST(N'2025-04-11T23:29:00.000' AS DateTime), NULL, 16)
INSERT [dbo].[Job] ([job_id], [job_technician], [job_created], [job_finished], [customer_id]) VALUES (17, N'Dustin N', CAST(N'2025-04-11T23:44:00.000' AS DateTime), CAST(N'2025-04-14T23:44:00.000' AS DateTime), 11)
INSERT [dbo].[Job] ([job_id], [job_technician], [job_created], [job_finished], [customer_id]) VALUES (18, N'Ben', CAST(N'2025-04-19T13:47:00.000' AS DateTime), NULL, 3)
SET IDENTITY_INSERT [dbo].[Job] OFF
GO
INSERT [dbo].[Receipt] ([job_id], [service_id]) VALUES (15, 6)
INSERT [dbo].[Receipt] ([job_id], [service_id]) VALUES (15, 7)
INSERT [dbo].[Receipt] ([job_id], [service_id]) VALUES (16, 2)
INSERT [dbo].[Receipt] ([job_id], [service_id]) VALUES (16, 8)
INSERT [dbo].[Receipt] ([job_id], [service_id]) VALUES (16, 9)
INSERT [dbo].[Receipt] ([job_id], [service_id]) VALUES (17, 6)
INSERT [dbo].[Receipt] ([job_id], [service_id]) VALUES (18, 2)
INSERT [dbo].[Receipt] ([job_id], [service_id]) VALUES (18, 8)
INSERT [dbo].[Receipt] ([job_id], [service_id]) VALUES (18, 9)
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([service_id], [service_name], [service_description], [service_cost]) VALUES (2, N'de', N'dw', 12.05)
INSERT [dbo].[Service] ([service_id], [service_name], [service_description], [service_cost]) VALUES (3, N'Android Screen Repair', N'Replace a damaged screen with a quality new screen', 50.99)
INSERT [dbo].[Service] ([service_id], [service_name], [service_description], [service_cost]) VALUES (6, N'Android Cleaning', N'Cleaning an android device', 30.24)
INSERT [dbo].[Service] ([service_id], [service_name], [service_description], [service_cost]) VALUES (7, N'Android Battery Replacement', N'Switch out old android battery for a new battery', 15.99)
INSERT [dbo].[Service] ([service_id], [service_name], [service_description], [service_cost]) VALUES (8, N'Apple Cleaning', N'Deep clean of the exhaust vents, speakers, and ports', 19.99)
INSERT [dbo].[Service] ([service_id], [service_name], [service_description], [service_cost]) VALUES (9, N'Apple Battery Replacement', N'Replacing old battery with new high quality apple device battery', 89.99)
INSERT [dbo].[Service] ([service_id], [service_name], [service_description], [service_cost]) VALUES (10, N'de', N'dw', 12)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_Customer]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Job] FOREIGN KEY([job_id])
REFERENCES [dbo].[Job] ([job_id])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Job]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Service] FOREIGN KEY([service_id])
REFERENCES [dbo].[Service] ([service_id])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Service]
GO
/****** Object:  StoredProcedure [dbo].[CreateCustomer]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Cuison>
-- Create date: <Create Date,, 3/22/2025>
-- Description:	<Description,, Stored Proc for Creating Customers>
-- =============================================
CREATE PROCEDURE [dbo].[CreateCustomer]
	-- Add the parameters for the stored procedure here
	@CustomerFirstName VarChar(25),
	@CustomerLastName VarChar(25),
	@CustomerEmail VarChar(75),
	@CustomerPhone VarChar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Customer (customer_fname, customer_lname, customer_email, customer_phone)
	VALUES (@CustomerFirstName, @CustomerLastName, @CustomerEmail, @CustomerPhone)

	SELECT * FROM Customer;
END
GO
/****** Object:  StoredProcedure [dbo].[CreateJob]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Name, Benjamin, Cuison>
-- Create date: <Create Date, 4/09/2025>
-- Description:	<Description, Stored Proc for Deleting Jobs and Receipt records>
-- =============================================
CREATE PROCEDURE [dbo].[CreateJob]
	-- Add the parameters for the stored procedure here
	@JobTechnician VarChar (50),
	@JobCreated DateTime,
	@JobFinished DateTime,
	@CustomerID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Job (job_technician, job_created, job_finished, customer_id) 
	VALUES (@JobTechnician, @JobCreated, @JobFinished, @CustomerID)
	
	SELECT * FROM Job WHERE customer_id = @CustomerID;

END
GO
/****** Object:  StoredProcedure [dbo].[CreateService]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        Name Dustin Nastaj
-- Create date: 
-- Description:
-- =============================================
CREATE PROCEDURE [dbo].[CreateService] 
    -- Add the parameters for the stored procedure here
    --@service_id int = null, 
    @service_name varchar(50) ,
    @service_description varchar(100),
    @service_price decimal(10, 2)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT INTO [Service] (service_name, service_description, service_cost)
    VALUES (@service_name, @service_description, @service_price)

    SELECT * FROM [Service];
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Cuison>
-- Create date: <Create Date,, 3/22/2025>
-- Description:	<Description,, Stored Proc for Deleting Customers>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCustomer]
	-- Add the parameters for the stored procedure here
	@CustomerID Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Customer WHERE customer_id = @CustomerID;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteJob]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Name, Benjamin, Cuison>
-- Create date: <Create Date, 4/09/2025>
-- Description:	<Description, Stored Proc for Deleting Jobs and Receipt records>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteJob]
	-- Add the parameters for the stored procedure here
	@JobID Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM	Receipt 
	WHERE job_id = @JobID

	DELETE FROM Job 
	WHERE job_id = @JobID;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteLinkJobService]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Name, Benjamin, Cuison>
-- Create date: <Create Date, 4/09/2025>
-- Description:	<Description, Stored Proc for Modifying and Creating Receipt records>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLinkJobService]
	-- Add the parameters for the stored procedure here
	@JobID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM RECEIPT
	WHERE job_id = @JobID;
	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteService]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        Name Dustin Nastaj
-- Create date: 
-- Description:
-- =============================================
CREATE PROCEDURE [dbo].[DeleteService] 
    -- Add the parameters for the stored procedure here
    @service_id Int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    DELETE FROM [Service] WHERE service_id = @service_id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditCustomer]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Cuison>
-- Create date: <Create Date,, 3/22/2025>
-- Description:	<Description,, Stored Proc for Editing Customers>
-- =============================================
CREATE PROCEDURE [dbo].[EditCustomer]
	-- Add the parameters for the stored procedure here
	@CustomerID Int,
	@CustomerFirstName VarChar(25),
	@CustomerLastName VarChar(25),
	@CustomerEmail VarChar(75),
	@CustomerPhone VarChar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Customer 
	SET customer_fname = @CustomerFirstName, customer_lname = @CustomerLastName,
	customer_email = @CustomerEmail, customer_phone = @CustomerPhone
	WHERE customer_id = @CustomerID

	SELECT * FROM Customer;
END
GO
/****** Object:  StoredProcedure [dbo].[EditJob]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Name, Benjamin, Cuison>
-- Create date: <Create Date, 4/09/2025>
-- Description:	<Description, Stored Proc for Editing Job table, but not receipt table>
-- =============================================
CREATE PROCEDURE [dbo].[EditJob]
	-- Add the parameters for the stored procedure here
	@JobID int,
	@JobTechnician VarChar (50),
	@JobCreated DateTime,
	@JobFinished DateTime,
	@CustomerID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Job
	SET 
	job_technician = @JobTechnician,
	job_created = @JobCreated,
	job_finished = @JobFinished, 
	customer_id = @CustomerID
	
	WHERE job_id = @JobID;
	
	SELECT * FROM Job WHERE job_id = @JobID;

END
GO
/****** Object:  StoredProcedure [dbo].[EditService]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        Name Dustin Nastaj
-- Create date: 
-- Description:
-- =============================================

CREATE PROCEDURE [dbo].[EditService]
    @service_id INT,
    @service_name VARCHAR(50),
    @service_description VARCHAR(100),
    @service_price DECIMAL(10, 2)
AS
BEGIN
    UPDATE Service
    SET 
        service_name = @service_name,
        service_description = @service_description,
        service_cost = @service_price
    WHERE service_id = @service_id;

    SELECT * FROM Service WHERE service_id = @service_id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerList]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Cuison>
-- Create date: <Create Date,, 3/22/2025>
-- Description:	<Description,, Stored Proc for Getting the Customer List>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerList]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Customer;
END
GO
/****** Object:  StoredProcedure [dbo].[GetDashboardModel]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Name, Benjamin, Cuison>
-- Create date: <Create Date, 4/10/2025>
-- Description:	<Description, Stored Proc for retrieving DashboardModel records via joins>
-- =============================================
CREATE PROCEDURE [dbo].[GetDashboardModel]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  Job.job_id, Job.job_technician, Job.job_created, Job.job_finished, 
	Job.customer_id, Customer.customer_fname, Customer.customer_lname, Customer.customer_email, Customer.customer_phone, 
	Service.service_id, Service.service_name, Service.service_description, Service.service_cost 
	FROM Job 
	JOIN Customer ON Customer.customer_id = Job.customer_id
	JOIN Receipt ON Receipt.job_id = Job.job_id 
	JOIN Service ON Receipt.service_id = Service.service_id;

END
GO
/****** Object:  StoredProcedure [dbo].[GetJobList]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Name, Benjamin, Cuison>
-- Create date: <Create Date, 4/10/2025>
-- Description:	<Description, Stored Proc for getting the job lists>
-- =============================================
CREATE PROCEDURE [dbo].[GetJobList]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Job;
END
GO
/****** Object:  StoredProcedure [dbo].[GetReceiptList]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Name, Benjamin, Cuison>
-- Create date: <Create Date, 4/11/2025>
-- Description:	<Description, Stored Proc for getting the job lists>
-- =============================================
CREATE PROCEDURE [dbo].[GetReceiptList]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Receipt;
END
GO
/****** Object:  StoredProcedure [dbo].[GetServiceList]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Name Dustin Nastaj
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetServiceList] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [Service];
END
GO
/****** Object:  StoredProcedure [dbo].[LinkJobService]    Script Date: 4/12/2025 8:41:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Name, Benjamin, Cuison>
-- Create date: <Create Date, 4/09/2025>
-- Description:	<Description, Stored Proc for Modifying and Creating Receipt records>
-- =============================================
CREATE PROCEDURE [dbo].[LinkJobService]
	-- Add the parameters for the stored procedure here
	@JobID int,
	@ServiceID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Receipt (job_id, service_id)
	VALUES (@JobID, @ServiceID);
	
END
GO
USE [master]
GO
ALTER DATABASE [ComputerTechnician] SET  READ_WRITE 
GO
