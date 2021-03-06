USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Update]    Script Date: 22/11/2019 11:44:03 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jezreel Pilapil
-- Create date: 11/20/2019
-- Description:	 Update Book
-- =============================================
CREATE PROCEDURE [dbo].[usp_Book_Update]
	@ID int = null,
	@UserID int = null,
	@WorkpointID int = null,
	@FloorID int = null,	
	@OfficeID int = null, 
	@CheckIn datetime = null,
	@CheckOut datetime = null, 
	@IsActive int = null, 
	@IsDeleted int = null
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Book SET
		UserID = ISNULL(@UserID, UserID),
		WorkpointID = ISNULL(@WorkpointID, @WorkpointID),
		FloorID = ISNULL(@FloorID, @FloorID),
		OfficeID = ISNULL(@OfficeID, OfficeID),
		CheckIn = ISNULL(@CheckIn, @CheckIn),
		CheckOut = ISNULL(@CheckOut, @CheckOut),
		IsActive = ISNULL(@IsActive, IsActive),
		IsDeleted = ISNULL(@IsDeleted, IsDeleted)
	WHERE ID = @ID

END
GO
