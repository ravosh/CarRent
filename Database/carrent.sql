USE [CarRent]
GO
/****** Object:  Table [dbo].[Tbl_Car_Info]    Script Date: 9/7/2020 10:52:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Car_Info](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[CarName] [varchar](50) NULL,
	[CarImage] [varchar](100) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_Car_Info] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_UserStory1]    Script Date: 9/7/2020 10:52:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_UserStory1](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Carid] [int] NULL,
	[Hourlyrate] [varchar](50) NULL,
	[Ondate] [datetime] NULL,
 CONSTRAINT [PK_Tbl_UserStory1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_UserStory2]    Script Date: 9/7/2020 10:52:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_UserStory2](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[CustomerName] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Ondate] [datetime] NULL,
 CONSTRAINT [PK_Tbl_UserStory2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_UserStory3]    Script Date: 9/7/2020 10:52:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_UserStory3](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[Status] [varchar](50) NULL,
	[Ondate] [datetime] NULL,
 CONSTRAINT [PK_Tbl_UserStory3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Car_Info] ON 

INSERT [dbo].[Tbl_Car_Info] ([Id], [CarName], [CarImage], [Status]) VALUES (1000, N'Audi', N'/Upload/MVC_25e028d0-6933-4637-ad9f-a6c17a7fd768.jpg', N'Available')
INSERT [dbo].[Tbl_Car_Info] ([Id], [CarName], [CarImage], [Status]) VALUES (1001, N'Audi1', N'/Upload/MVC_38a19576-e07d-44a6-8e61-813fc6b889b6.jpg', N'Available')
INSERT [dbo].[Tbl_Car_Info] ([Id], [CarName], [CarImage], [Status]) VALUES (1002, N'Audi2', N'/Upload/MVC_0afa7145-ff6b-42d9-b82c-5725b6281b8f.jpg', N'Rented')
INSERT [dbo].[Tbl_Car_Info] ([Id], [CarName], [CarImage], [Status]) VALUES (1003, N'Audi3', N'/Upload/MVC_4262aca8-ff10-4e91-8b07-1c3de9914915.jpg', N'Available')
INSERT [dbo].[Tbl_Car_Info] ([Id], [CarName], [CarImage], [Status]) VALUES (1004, N'Audi4', N'/Upload/MVC_2707f011-ddf6-4ed5-8f82-872c3f3b1af1.jpg', N'Available')
INSERT [dbo].[Tbl_Car_Info] ([Id], [CarName], [CarImage], [Status]) VALUES (1005, N'Audi5', N'/Upload/MVC_a19610b2-d668-4b98-bdf1-2af9088a72ed.jpg', N'Available')
INSERT [dbo].[Tbl_Car_Info] ([Id], [CarName], [CarImage], [Status]) VALUES (1006, N'Audi6', N'/Upload/MVC_5628bd90-bdf8-4afd-a2ba-9bd6df1d1f44.jpg', N'Available')
INSERT [dbo].[Tbl_Car_Info] ([Id], [CarName], [CarImage], [Status]) VALUES (1007, N'Audi7', N'/Upload/MVC_963256af-2748-460f-89b2-b0cf845ba875.jpg', N'Available')
INSERT [dbo].[Tbl_Car_Info] ([Id], [CarName], [CarImage], [Status]) VALUES (1008, N'Audi10', N'/Upload/MVC_bb14885f-a600-48f1-b11d-5ab7abe6c35b.jpg', N'Available')
SET IDENTITY_INSERT [dbo].[Tbl_Car_Info] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_UserStory1] ON 

INSERT [dbo].[Tbl_UserStory1] ([Id], [Carid], [Hourlyrate], [Ondate]) VALUES (16, 1001, N'222', CAST(N'2020-09-07T10:23:11.800' AS DateTime))
INSERT [dbo].[Tbl_UserStory1] ([Id], [Carid], [Hourlyrate], [Ondate]) VALUES (17, 1002, N'500', CAST(N'2020-09-07T10:29:37.453' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_UserStory1] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_UserStory2] ON 

INSERT [dbo].[Tbl_UserStory2] ([Id], [CarId], [CustomerName], [Status], [Ondate]) VALUES (11, 1001, N'Ravi', N'Returned', CAST(N'2020-09-07T10:23:38.717' AS DateTime))
INSERT [dbo].[Tbl_UserStory2] ([Id], [CarId], [CustomerName], [Status], [Ondate]) VALUES (12, 1002, N'Raj', N'Rented', CAST(N'2020-09-07T10:29:46.967' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_UserStory2] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_UserStory3] ON 

INSERT [dbo].[Tbl_UserStory3] ([Id], [CarId], [Status], [Ondate]) VALUES (10, 1001, N'True', CAST(N'2020-09-07T10:36:43.087' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_UserStory3] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_CAR_INFO]    Script Date: 9/7/2020 10:52:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CAR_INFO]
@Id	int=0,		 
	@carname	varchar(50)=NULL,
	@image	varchar(100)=NULL,
	@status varchar(20)=null
	
	
AS 
BEGIN
if(@Id=0)
Begin
	insert into [dbo].[Tbl_Car_Info] (carname, carimage,status) 
	values( @carname, @image,@status)

	 
End
else
Begin
	update [dbo].[Tbl_Car_Info] set carname=@carname, [Status]=@status,
	carimage=IIF(@image is NULL or @image='',carimage,@image)
	 where id=@Id 
	
	
	
End
END
GO
/****** Object:  StoredProcedure [dbo].[SP_USERSTORY1_INFO]    Script Date: 9/7/2020 10:52:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_USERSTORY1_INFO]
	@Id	int=0,		 
	@carid	int=0,
	@hourlyrate varchar(20)=null
	
	
AS 
BEGIN
insert into [dbo].[Tbl_UserStory1] (carid, hourlyrate,ondate) 
	values(@carid, @hourlyrate,getdate())

	 update Tbl_Car_Info set Status='Booked' where id=@carid
END
GO
/****** Object:  StoredProcedure [dbo].[SP_USERSTORY2_INFO]    Script Date: 9/7/2020 10:52:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_USERSTORY2_INFO]
	@Id	int=0,		 
	@carid	int=0,
	@customername varchar(20)=null,
	@status varchar(20)=null
	
	
AS 
BEGIN
declare @sts varchar(20)
set @sts=(select status from Tbl_Car_Info where id=@carid)
if(@sts='Rented')
Begin
	select 'Already rented out' as msg
End
else if(@sts='Booked')
Begin
	insert into [dbo].[Tbl_UserStory2] (carid, customername,ondate,status) 
	values(@carid, @customername,getdate(),@status)

	update Tbl_Car_Info set Status='Rented' where id=@carid
	select 'Car has been rented out!!' as msg
End
else
Begin
	select 'Wrong car selected!!' as msg
End
END
GO
/****** Object:  StoredProcedure [dbo].[SP_USERSTORY3_INFO]    Script Date: 9/7/2020 10:52:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_USERSTORY3_INFO]
	@Id	int=0,		 
	@carid	int=0,
	@status varchar(20)=null	
	
AS 
BEGIN
declare @sts varchar(20)
set @sts=(select status from Tbl_Car_Info where id=@carid)
if(@sts='Rented')
Begin
insert into [dbo].[Tbl_UserStory3] (carid, status,ondate) 
	values(@carid, @status,getdate())

	 update Tbl_Car_Info set Status='Available' where id=@carid
	 update Tbl_UserStory2 set Status='Returned' where carid=@carid

	select 'Car Returned!!' as msg

	declare @u2 datetime
	declare @u3 datetime
	declare @rate int
set @u2=(select ondate from Tbl_UserStory2 where carid=@carid)
	set @u3=(select ondate from Tbl_UserStory3 where carid=@carid)
	set @rate=(select Hourlyrate from Tbl_UserStory1 where carid=@carid)
	SELECT  (DATEDIFF(hour, @u2, @u3)+1) as howmanyhour,((DATEDIFF(hour, @u2, @u3)+1) * @rate) as price

End
else if exists(select id from Tbl_UserStory3 where carid=@carid and status=@status)
begin
select 'This car already returned!!' as msg

SELECT  '' as howmanyhour,'' as price
end
else 
Begin
	select 'This car number has not rented out,Its Available' as msg

SELECT  '' as howmanyhour,'' as price
End

END
GO
/****** Object:  StoredProcedure [dbo].[SP_USERSTORY4_INFO]    Script Date: 9/7/2020 10:52:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_USERSTORY4_INFO]
	@Id	int=0,		 
	@carid	int=0	
AS 
BEGIN
delete Tbl_UserStory1 where Carid=@carid
delete Tbl_UserStory2 where Carid=@carid
delete Tbl_UserStory3 where Carid=@carid
END
GO
