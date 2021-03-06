USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Hub_GetAll]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Get all Hubs
-- =============================================
CREATE PROCEDURE [dbo].[usp_Hub_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT ID, Name, DeviceType, MAC, IPaddress, OfficeID, FloorID, RoomID, IsActive, IsDeleted
	FROM Hub
	WHERE IsDeleted = 0

END
GO
