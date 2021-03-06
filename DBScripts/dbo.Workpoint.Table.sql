USE [EpicOS]
GO
/****** Object:  Table [dbo].[Workpoint]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workpoint](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MAC] [nvarchar](20) NULL,
	[IPaddress] [nvarchar](100) NULL,
	[CoordinateX] [float] NULL,
	[CoordinateY] [float] NULL,
	[CoordinateZ] [float] NULL,
	[OfficeID] [int] NULL,
	[FloorID] [int] NULL,
	[RoomID] [int] NULL,
	[HubID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Workpoint] ADD  CONSTRAINT [DF_Workpoint_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Workpoint] ADD  CONSTRAINT [DF_Workpoint_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
