USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Workpoint_Update]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Insert Workpoint
-- =============================================
CREATE PROCEDURE [dbo].[usp_Workpoint_Update]
	@ID int = null,
	@Name nvarchar(250) = null,
	@MAC nvarchar(20) = null,
	@IPaddress nvarchar(100) = null,
	@CoordinateX float = null,
	@CoordinateY float = null,
	@CoordinateZ float = null,
	@OfficeID int = null,
	@FloorID int = null,
	@RoomID int = null,
	@HubID int = null,
	@IsActive bit = null,
	@IsDeleted bit = null
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Workpoint SET
		[Name] = ISNULL(@Name, [Name]),
		MAC = ISNULL(@MAC, MAC),
		IPaddress = ISNULL(@IPaddress, IPaddress),
		CoordinateX = ISNULL(@CoordinateX, CoordinateX),
		CoordinateY = ISNULL(@CoordinateY, CoordinateY),
		CoordinateZ = ISNULL(@CoordinateZ, CoordinateZ),
		OfficeID = ISNULL(@OfficeID, OfficeID),
		FloorID = ISNULL(@FloorID, FloorID),
		RoomID = ISNULL(@RoomID, RoomID),
		HubID = ISNULL(@HubID, HubID),
		IsActive = ISNULL(@IsActive, IsActive),
		IsDeleted = ISNULL(@IsDeleted, IsDeleted)
	WHERE ID = @ID

END
GO
