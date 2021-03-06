USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_User_GetAll]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Lance Concepcion
-- Create date: 26/09/2019
-- Description:	Get all users
-- =============================================
CREATE PROCEDURE [dbo].[usp_User_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, FirstName, LastName, UserName, Password, CompanyID, Phone, EmailAddress, RoleID, IsActive, IsDeleted
	FROM   [User]
	WHERE IsDeleted = 0

END
GO
