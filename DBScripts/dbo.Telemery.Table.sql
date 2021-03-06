USE [EpicOS]
GO
/****** Object:  Table [dbo].[Telemery]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telemery](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MAC] [nvarchar](20) NULL,
	[IPaddress] [nvarchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[Battery] [nvarchar](250) NULL,
	[HubID] [int] NULL,
	[WorkpointID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Telemery] ADD  CONSTRAINT [DF_Table_1_Stamp]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Telemery] ADD  CONSTRAINT [DF_Telemery_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Telemery] ADD  CONSTRAINT [DF_Telemery_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
