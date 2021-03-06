USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Hub_INSERT]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Insert new Hub
-- =============================================
CREATE PROCEDURE [dbo].[usp_Hub_INSERT]
	@ID int = 0,
	@Name nvarchar(250) = '',
	@DeviceType int = 0,
	@MAC  nvarchar(20) = '',
	@IPaddress nvarchar(100) = '',
	@OfficeID int = 0,
	@FloorID int = 0,
	@RoomID int = 0,
	@IsActive bit = 1,
	@IsDeleted bit = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Hub (Name, DeviceType, MAC, IPaddress, OfficeID, FloorID, RoomID, IsActive, IsDeleted)
	VALUES (@Name, @DeviceType, @MAC, @IPaddress, @OfficeID, @FloorID, @RoomID, @IsActive, @IsDeleted)

	SELECT @@IDENTITY

END
GO
