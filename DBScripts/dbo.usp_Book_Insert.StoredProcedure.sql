USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Insert]    Script Date: 20/11/2019 2:18:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Jezreel Pilapil
-- Create date: 11/20/2019
-- Description:	Insert new books
-- =============================================

CREATE PROCEDURE [dbo].[usp_Book_Insert]
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
	
	INSERT INTO Book (UserID, WorkpointID, OfficeID, FloorID, CheckIn, CheckOut, IsActive, IsDeleted)
	VALUES (@UserID, @WorkpointID,@OfficeID, @FloorID, @CheckIn, @CheckOut,  @IsActive, @IsDeleted)

	SELECT @@IDENTITY
		
END
GO
