USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Floor_GetByOfficeID]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Lance Concepcion
-- Create date: 26/09/2019
-- Description:	Get floors by OfficeID
-- =============================================
CREATE PROCEDURE [dbo].[usp_Floor_GetByOfficeID]
	@OfficeID int = 0
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, Name, Filename, Type, OfficeID, IsActive, IsDeleted
	FROM [Floor]
	WHERE IsDeleted = 0
	AND OfficeID = @OfficeID

END
GO
