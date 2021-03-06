USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Workpoint_Insert]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Insert Workpoint
-- =============================================
CREATE PROCEDURE [dbo].[usp_Workpoint_Insert]
	@ID int = 0,
	@Name nvarchar(250) = '',
	@MAC nvarchar(20) = '',
	@IPaddress nvarchar(100) = '',
	@CoordinateX float = 0,
	@CoordinateY float = 0,
	@CoordinateZ float = 0,
	@OfficeID int = 0,
	@FloorID int = 0,
	@RoomID int = 0,
	@HubID int = 0,
	@IsActive bit = 1,
	@IsDeleted bit = 0
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Workpoint (Name, MAC, IPaddress, CoordinateX, CoordinateY, CoordinateZ, OfficeID, FloorID, RoomID, HubID, IsActive, IsDeleted)
	VALUES (@Name, @MAC, @IPaddress, @CoordinateX, @CoordinateY, @CoordinateZ, @OfficeID, @FloorID, @RoomID, @HubID, @IsActive, @IsDeleted)

	SELECT @@IDENTITY

END
GO
