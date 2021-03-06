USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Floor_Insert]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Insert new floors
-- =============================================
CREATE PROCEDURE [dbo].[usp_Floor_Insert]
	@ID int = 0,
	@Name nvarchar(250) = '',
	@Filename nvarchar(250) = '',
	@Type nvarchar(250) = '',
	@OfficeID int = 0,
	@IsActive bit = 1,
	@IsDeleted bit = 0

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Floor (Name, Filename, Type, OfficeID, IsActive, IsDeleted)
	VALUES (@Name, @Filename, @Type, @OfficeID, @IsActive, @IsDeleted)

	SELECT @@IDENTITY

END
GO
