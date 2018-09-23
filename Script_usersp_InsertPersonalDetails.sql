USE [PatientDemographics]
GO

/****** Object:  StoredProcedure [dbo].[usersp_InsertPersonalDetails]    Script Date: 9/23/2018 9:35:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Nithin,Name>
-- Create date: <Create Date,23-09-2018,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usersp_InsertPersonalDetails] 
	-- Add the parameters for the stored procedure here
	@xmlInfo as xml
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into PatientDetails (PatientDetails)
	Values(@xmlInfo)
END

GO


