USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Update]    Script Date: 20/11/2019 2:18:40 pm ******/
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
	@ID int = 0,
	@UserID int = 0,
	@WorkpointID int = 0,
	@FloorID int = 0,	
	@OfficeID int = 0, 
	@CheckIn datetime = GETDATE,
	@CheckOut datetime = GETDATE, 
	@IsActive int = 1, 
	@IsDeleted int = 0
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
