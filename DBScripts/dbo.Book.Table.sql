USE [EpicOS]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[WorkpointID] [int] NULL,
	[FloorID] [int] NULL,
	[OfficeID] [int] NULL,
	[CheckIn] [datetime] NULL,
	[CheckOut] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
