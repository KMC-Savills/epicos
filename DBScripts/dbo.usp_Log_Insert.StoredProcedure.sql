USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Log_Insert]    Script Date: 1/23/2020 2:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
​
-- =============================================
-- Author:		Lance
-- Create date: 19/12/2019
-- Description:	Insert Log
-- =============================================
CREATE PROCEDURE [dbo].[usp_Log_Insert]
	@ID int = 0,
	@DateCreated datetime = GETDATE,
	@MAC nvarchar(20) = '',
	@IPaddress nvarchar(100) = '',
	@Message nvarchar(500) = ''
AS
BEGIN
	SET NOCOUNT ON;
​
    INSERT INTO Log (DateCreated, MAC, IPaddress, [Message])
	VALUES (@DateCreated, @MAC, @IPaddress, @Message)
​
	SELECT @@IDENTITY
​
END
GO
