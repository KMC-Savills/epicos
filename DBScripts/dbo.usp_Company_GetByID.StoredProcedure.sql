USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Company_GetByID]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Get company by ID
-- =============================================
CREATE PROCEDURE [dbo].[usp_Company_GetByID]
	@ID int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT ID, Name, IsActive, IsDeleted
	FROM Company
	WHERE IsDeleted = 0
		AND ID = @ID

END
GO
