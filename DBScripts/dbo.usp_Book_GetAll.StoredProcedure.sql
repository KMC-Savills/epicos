USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Book_GetAll]    Script Date: 20/11/2019 2:18:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jezreel Pilapil
-- Create date: 11/20/2019
-- Description:	Get all Books
-- =============================================
CREATE PROCEDURE [dbo].[usp_Book_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT ID, UserID, WorkpointID, FloorID, CheckIn, CheckOut, OfficeID, IsActive, IsDeleted
	FROM Book
	WHERE IsDeleted = 0

END
GO
