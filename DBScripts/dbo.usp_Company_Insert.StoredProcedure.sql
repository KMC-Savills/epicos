USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Company_Insert]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Insert new Company
-- =============================================
CREATE PROCEDURE [dbo].[usp_Company_Insert]
	@ID int = 0,
	@Name nvarchar(250) = '',
	@IsActive bit = 1,
	@IsDeleted bit = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Company (Name, IsActive, IsDeleted)
	VALUES (@Name, @IsActive, @IsDeleted)

	SELECT @@IDENTITY

END
GO
