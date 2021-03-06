USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Company_Update]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Update Company
-- =============================================
CREATE PROCEDURE [dbo].[usp_Company_Update]
	@ID int = 0,
	@Name nvarchar(250) = '',
	@IsActive bit = 1,
	@IsDeleted bit = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Company SET
		Name = ISNULL(@Name, Name),
		IsActive = ISNULL(@IsActive, IsActive),
		IsDeleted = ISNULL(@IsDeleted, IsDeleted)
	WHERE ID = @ID

END
GO
