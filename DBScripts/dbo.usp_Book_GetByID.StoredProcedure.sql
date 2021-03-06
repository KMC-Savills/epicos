USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Book_GetByID]    Script Date: 20/11/2019 2:40:34 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Jezreel Pilapil
-- Create date: 11/20/2019
-- Description:	Get office by ID
-- =============================================
CREATE PROCEDURE [dbo].[usp_Book_GetByID]
	@ID int = 0
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, UserID, WorkpointID, FloorID, CheckIn, CheckOut, OfficeID, IsActive, IsDeleted
	FROM Book
	WHERE IsDeleted = 0
	AND ID = @ID

END
GO
