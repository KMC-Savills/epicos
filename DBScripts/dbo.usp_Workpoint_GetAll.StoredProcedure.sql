USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Workpoint_GetAll]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Lance Concepcion
-- Create date: 26/09/2019
-- Description:	Get all Workpoint
-- =============================================
CREATE PROCEDURE [dbo].[usp_Workpoint_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, Name, MAC, IPaddress, CoordinateX, CoordinateY, CoordinateZ, OfficeID, FloorID, RoomID, HubID, IsActive, IsDeleted
	FROM Workpoint
	WHERE IsDeleted = 0

END
GO
