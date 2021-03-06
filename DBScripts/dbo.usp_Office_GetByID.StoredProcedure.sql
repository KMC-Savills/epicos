USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Office_GetByID]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Lance Concepcion
-- Create date: 26/09/2019
-- Description:	Get office by ID
-- =============================================
CREATE PROCEDURE [dbo].[usp_Office_GetByID]
	@ID int = 0
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, Name, Address, CityID, Latitude, Longitude, Filename, IsActive, IsDeleted
	FROM Office
	WHERE IsDeleted = 0
	AND ID = @ID

END
GO
