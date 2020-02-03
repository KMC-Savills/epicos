USE [EpicOS]
GO
/****** Object:  StoredProcedure [dbo].[usp_Log_GetAll]    Script Date: 1/23/2020 2:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Log_GetAll]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT ID, DateCreated, MAC, IPaddress, Message, IsDeleted FROM Log WHERE IsDeleted = 0
END
GO
