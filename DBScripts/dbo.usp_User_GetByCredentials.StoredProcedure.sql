USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_GetByCredentials]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Lance Concepcion
-- Create date: 26/09/2019
-- Description:	Get by credentials
-- =============================================
CREATE PROCEDURE [dbo].[usp_User_GetByCredentials]
	@UserName nvarchar(250),
	@EmailAddress nvarchar(250),
	@Password nvarchar(250)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP(1) ID, FirstName, LastName, UserName, Password, CompanyID, Phone, EmailAddress, RoleID, IsActive, IsDeleted
	FROM   [User]
	WHERE IsDeleted = 0
	AND (UserName = @UserName OR EmailAddress = @EmailAddress)
	AND Password = @Password

END
GO
