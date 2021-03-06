USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Telemery_Update]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Lance Concepcion
-- Create date: 01/10/2019
-- Description:	Get all telemery
-- =============================================
CREATE PROCEDURE [dbo].[usp_Telemery_Update]
	@ID int = null,
	@MAC nvarchar(20) = null,
	@IPaddress nvarchar(100) = null,
	@DateCreated datetime = null,
	@Battery nvarchar(250) = NULL,
	@HubID int = null,
	@WorkpointID int = null,
	@IsActive bit = null,
	@IsDeleted bit = null
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Telemery SET
		MAC = ISNULL(@MAC, MAC),
		IPaddress = ISNULL(@IPaddress, IPaddress),
		DateCreated = ISNULL(@DateCreated, DateCreated),
		Battery = ISNULL(@Battery, Battery),
		HubID = ISNULL(@HubID, HubID),
		WorkpointID = ISNULL(@WorkpointID, WorkpointID),
		IsActive = ISNULL(@IsActive, IsActive),
		IsDeleted = ISNULL(@IsDeleted, IsDeleted)
	WHERE ID = @ID

END
GO
