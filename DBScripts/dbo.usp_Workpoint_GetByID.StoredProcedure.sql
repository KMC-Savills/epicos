USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Workpoint_GetByID]    Script Date: 1/21/2020 10:47:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Get all Hubs
-- =============================================
CREATE PROCEDURE [dbo].[usp_Workpoint_GetByID]
	@ID int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT  ID, Name, MAC, IPaddress, OfficeID, FloorID, RoomID, HubID, IsActive, IsDeleted
FROM    Workpoint
	WHERE IsDeleted = 0
	AND ID = @ID

END
GO
