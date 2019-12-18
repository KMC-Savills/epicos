USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Floor_GetAll]    Script Date: 12/17/2019 5:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Floor_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, Name, Filename, Type, OfficeID, IsActive, IsDeleted
	FROM Floor
	WHERE IsDeleted = 0

END
GO
