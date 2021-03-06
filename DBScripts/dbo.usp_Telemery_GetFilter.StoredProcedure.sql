USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Telemery_GetFilter]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Lance Concepcion
-- Create date: 26/09/2019
-- Description:	Get all telemery
-- =============================================
CREATE PROCEDURE [dbo].[usp_Telemery_GetFilter]
	@DateStart datetime = '01/01/2019',
	@DateEnd datetime = '01/01/2030',
	@OfficeID int = 0,
	@FloorID int = 0
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Telemery.ID, Telemery.MAC, Telemery.IPaddress, Telemery.DateCreated, Telemery.Battery, Telemery.HubID, Telemery.WorkpointID, Telemery.IsActive, Telemery.IsDeleted
	FROM   Telemery INNER JOIN Workpoint ON Telemery.WorkpointID = Workpoint.ID
	WHERE Telemery.IsDeleted = 0
	AND DateCreated BETWEEN @DateStart AND @DateEnd
	AND Workpoint.OfficeID = @OfficeID
	AND Workpoint.FloorID = @FloorID

END
GO
