USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Office_Insert]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Insert new Office
-- =============================================
CREATE PROCEDURE [dbo].[usp_Office_Insert]
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

	INSERT INTO Office (Name, Address, CityID, Latitude, Longitude, Filename, IsActive, IsDeleted)
	VALUES (@Name, @Address, @CityID, @Latitude, @Longitude, @Filename, @IsActive, @IsDeleted)

	SELECT @@IDENTITY


END
GO
