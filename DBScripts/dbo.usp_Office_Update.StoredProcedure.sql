USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Office_Update]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Update Office
-- =============================================
CREATE PROCEDURE [dbo].[usp_Office_Update]
	@ID int = 0,
	@Name nvarchar(250) = '',
	@Address nvarchar(250) = '',
	@CityID int = 0,
	@Latitude float = 0,
	@Longitude float = 0,
	@Filename nvarchar(250) = '',
	@IsActive bit = 1,
	@IsDeleted bit = 0
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Office SET
		Name = ISNULL(@Name, Name),
		Address = ISNULL(@Address, Address),
		CityID = ISNULL(@CityID, CityID),
		Latitude = ISNULL(@Latitude, Latitude),
		Longitude = ISNULL(@Longitude, Longitude),
		Filename = ISNULL(@Filename, Filename),
		IsActive = ISNULL(@IsActive, IsActive),
		IsDeleted = ISNULL(@IsDeleted, IsDeleted)
	WHERE ID = @ID

END
GO
