USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Office_Update]    Script Date: 11/22/2019 12:31:36 PM ******/
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
	@ID int = null,
	@Name nvarchar(250) = null,
	@Address nvarchar(250) = null,
	@CityID int = null,
	@Latitude float = null,
	@Longitude float = null,
	@Filename nvarchar(250) = null,
	@IsActive bit = null,
	@IsDeleted bit = null
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
