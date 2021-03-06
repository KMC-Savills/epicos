USE [EpicOS]
GO
/****** Object:  Table [dbo].[Office]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Office](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[CityID] [int] NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[Filename] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Office] ADD  CONSTRAINT [DF_Office_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Office] ADD  CONSTRAINT [DF_Office_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
