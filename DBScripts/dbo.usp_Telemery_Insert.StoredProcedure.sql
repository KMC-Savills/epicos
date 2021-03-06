USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Telemery_Insert]    Script Date: 20/11/2019 10:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		Lance Concepcion
-- Create date: 26/09/2019
-- Description:	Get all telemery
-- =============================================
CREATE PROCEDURE [dbo].[usp_Telemery_Insert]
	@MAC nvarchar(20) = '',
	@IPAddress nvarchar(100) = '',
	@DateCreated datetime = GETDATE,
	@Battery nvarchar(250) = NULL,
	@HubID int = 0,
	@WorkpointID int = 0,
	@IsActive bit = 1,
	@IsDeleted bit = 0
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Telemery (MAC, IPAddress, DateCreated, Battery, HubID, WorkpointID, IsActive, IsDeleted)
	VALUES (@MAC, @IPaddress, @DateCreated, @Battery, @HubID, @WorkpointID, @IsActive, @IsDeleted)

	SELECT @@IDENTITY

END
GO
