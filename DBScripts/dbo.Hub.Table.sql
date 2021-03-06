USE [EpicOS]
GO
/****** Object:  Table [dbo].[Hub]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hub](
	[ID] [int] NULL,
	[Name] [nvarchar](250) NULL,
	[DeviceType] [int] NULL,
	[MAC] [nvarchar](20) NULL,
	[IPaddress] [nvarchar](100) NULL,
	[OfficeID] [int] NULL,
	[FloorID] [int] NULL,
	[RoomID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hub] ADD  CONSTRAINT [DF_Hub_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Hub] ADD  CONSTRAINT [DF_Hub_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
