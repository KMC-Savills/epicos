USE [EpicOS]
GO
/****** Object:  Table [dbo].[Floor]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Floor](
	[ID] [int] NULL,
	[Name] [nvarchar](250) NULL,
	[Filename] [nvarchar](250) NULL,
	[Type] [int] NULL,
	[OfficeID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Floor] ADD  CONSTRAINT [DF_Floor_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Floor] ADD  CONSTRAINT [DF_Floor_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
