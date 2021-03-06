USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Update]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Lance Concepcion
-- Create date: 26/09/2019
-- Description:	Update User
-- =============================================
CREATE PROCEDURE [dbo].[usp_User_Update]
	@ID int = 0,
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

	UPDATE [User] SET
	FirstName = ISNULL(@FirstName, FirstName),
	LastName = ISNULL(@LastName, LastName),
	UserName =  ISNULL(@UserName, UserName),
	[Password] = ISNULL(@Password, [Password]),
	CompanyID = ISNULL(@CompanyID, CompanyID),
	Phone = ISNULL(@Phone, Phone),
	EmailAddress = ISNULL(@EmailAddress, EmailAddress),
	RoleID = ISNULL(@RoleID, RoleID),
	IsActive = ISNULL(@IsActive, IsActive),
	IsDeleted = ISNULL(@IsDeleted, IsDeleted)
	WHERE ID = @ID

END
GO
