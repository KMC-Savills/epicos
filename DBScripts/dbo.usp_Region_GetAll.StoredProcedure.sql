USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Region_GetAll]    Script Date: 11/29/2019 1:11:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Region_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT RegionID, RegionName, Coordinates
	FROM Region
	WHERE IsDeleted = 0

END
GO
