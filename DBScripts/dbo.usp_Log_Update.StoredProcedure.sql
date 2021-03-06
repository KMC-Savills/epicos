USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Log_Update]    Script Date: 1/23/2020 2:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Log_Update]
	@ID int = null,
	@DateCreated datetime = null,
	@MAC nvarchar(250) = null,
	@IPaddress nvarchar(250) = null,
	@Message nvarchar(250) = null,
	@IsDeleted bit = null
AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE Log SET
	DateCreated = ISNULL(@DateCreated, DateCreated),
	MAC = ISNULL(@MAC, MAC),
	IPaddress = ISNULL(@IPaddress, IPaddress),
	Message = ISNULL(@Message, Message),
	IsDeleted = ISNULL(@IsDeleted, IsDeleted)
	WHERE ID = @ID
END
GO
