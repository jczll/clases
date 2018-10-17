exec sp_CustomerAddress 1
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE sp_CustomerAddress 
	-- Add the parameters for the stored procedure here
	@CustomerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT top 1 BillingAddress,BillingCity,BillingState,BillingCountry,BillingPostalCode
	       from Invoice where CustomerId=@CustomerID 
END
GO
