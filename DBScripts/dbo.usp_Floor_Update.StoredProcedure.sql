USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Floor_Update]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Update floor
-- =============================================
CREATE PROCEDURE [dbo].[usp_Floor_Update]
	@ID int = null,
	@Name nvarchar(250) = null,
	@Filename nvarchar(250) = null,
	@Type nvarchar(250) = null,
	@OfficeID int = null,
	@IsActive bit = null,
	@IsDeleted bit = null

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Floor SET
		Name = ISNULL(@Name, Name),
		Filename = ISNULL(@Filename, Filename),
		Type = ISNULL(@Type, Type),
		OfficeID = ISNULL(@OfficeID, OfficeID),
		IsActive = ISNULL(@IsActive, IsActive),
		IsDeleted = ISNULL(@IsDeleted, IsDeleted)
	WHERE ID = @ID

END
GO
