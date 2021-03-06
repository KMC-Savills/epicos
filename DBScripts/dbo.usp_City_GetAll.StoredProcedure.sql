USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_City_GetAll]    Script Date: 11/29/2019 1:11:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jezreel Pilapil
-- Create date: 11/20/2019
-- Description:	Get all Books
-- =============================================
CREATE PROCEDURE [dbo].[usp_City_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT CityID, CityName, Province, Country, Coordinates
	FROM City
END
GO
