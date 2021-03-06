USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Insert]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Lance Concepcion
-- Create date: 26/09/2019
-- Description:	Insert User
-- =============================================
CREATE PROCEDURE [dbo].[usp_User_Insert]
	@FirstName nvarchar(250) = '',
	@LastName nvarchar(250) = '',
	@UserName nvarchar(250) = '',
	@Password nvarchar(250) = '',
	@CompanyID int = 0,
	@Phone nvarchar(250) = '',
	@EmailAddress nvarchar(250) = '',
	@RoleID int = 0,
	@IsActive bit = 1,
	@IsDeleted bit = 0
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [User] (FirstName, LastName, UserName, [Password], CompanyID, Phone, EmailAddress, RoleID, IsActive, IsDeleted)
	VALUES (@FirstName, @LastName, @UserName, @Password, @CompanyID, @Phone, @EmailAddress, @RoleID, @IsActive, @IsDeleted)

	SELECT @@IDENTITY

END
GO
