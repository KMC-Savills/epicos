USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Hub_Update]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Update Hub
-- =============================================
CREATE PROCEDURE [dbo].[usp_Hub_Update]
	@ID int = null,
	@Name nvarchar(250) = null,
	@DeviceType int = null,
	@MAC  nvarchar(20) = null,
	@IPaddress nvarchar(100) = null,
	@OfficeID int = null,
	@FloorID int = null,
	@RoomID int = null,
	@IsActive bit = null,
	@IsDeleted bit = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Hub SET
		Name = ISNULL(@Name, Name),
		DeviceType = ISNULL(@DeviceType, DeviceType),
		MAC = ISNULL(@MAC, MAC),
		IPaddress = ISNULL(@IPaddress, IPaddress),
		OfficeID = ISNULL(@OfficeID, OfficeID),
		FloorID = ISNULL(@FloorID, FloorID),
		RoomID = ISNULL(@RoomID, RoomID),
		IsActive = ISNULL(@IsActive, IsActive),
		IsDeleted = ISNULL(@IsDeleted, IsDeleted)
	WHERE ID = @ID

END
GO
