USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Telemery_GetAll]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Lance Concepcion
-- Create date: 26/09/2019
-- Description:	Get all telemery
-- =============================================
CREATE PROCEDURE [dbo].[usp_Telemery_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, MAC, IPaddress, DateCreated, Battery, HubID, WorkpointID, IsActive, IsDeleted
	FROM Telemery
	WHERE IsDeleted = 0

END
GO
