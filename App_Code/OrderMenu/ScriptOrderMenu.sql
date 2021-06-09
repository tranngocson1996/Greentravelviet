
--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[OrderMenuInsert]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[OrderMenuInsert]
	@OrderCode nvarchar(30),
	@OrderStatus nvarchar(20),
	@Customer nvarchar(50),
	@OrderSubTotal float,
	@OrderTax float,
	@OrderDiscount2 float,
	@OrderDiscount float,
	@OrderShippingFee float,
	@CustomerIp nvarchar(20),
	@PaymentMethod nvarchar(20),
	@PaymentStatus nvarchar(20),
	@DeliveryStaff nvarchar(50),
	@ShippingMethod nvarchar(20),
	@ShippingStatus nvarchar(20),
	@ShippingFullName nvarchar(20),
	@ShippingEmail nvarchar(30),
	@ShippingPhone nvarchar(30),
	@ShippingFax nvarchar(30),
	@ShippingCompany nvarchar(50),
	@ShippingAddress nvarchar(300),
	@ShippingDate datetime,
	@ShippingDeliveredDate datetime,
	@ShippingCity nvarchar(20),
	@ShippingState nvarchar(20),
	@ShippingCountry nvarchar(20),
	@BillingFullName nvarchar(20),
	@BillingEmail nvarchar(30),
	@BillingPhone nvarchar(30),
	@BillingFax nvarchar(30),
	@BillingCompany nvarchar(50),
	@BillingShippingAddress nvarchar(300),
	@BillingCity nvarchar(20),
	@BillingState nvarchar(20),
	@BillingCountry nvarchar(20),
	@InvoiceTaxCode nvarchar(50),
	@InvoiceAddress nvarchar(50),
	@OrderNote nvarchar(1000),
	@ModifiedBy nvarchar(40),
	@ModifiedDate datetime,
	@Column4 nvarchar(50),
	@Column3 nvarchar(50),
	@Column2 nvarchar(50),
	@Column1 nvarchar(50),
	@Priority int,
	@IsActive bit
 
,@OrderMenuID int output
AS
DECLARE @MaxOrderMenuID int
SELECT @MaxOrderMenuID = isnull(max(OrderMenuID),0) from OrderMenu
SET @MaxOrderMenuID =@MaxOrderMenuID +1


INSERT INTO [dbo].[OrderMenu] (
	[OrderMenuID],
	[OrderCode],
	[OrderStatus],
	[Customer],
	[OrderSubTotal],
	[OrderTax],
	[OrderDiscount2],
	[OrderDiscount],
	[OrderShippingFee],
	[CustomerIp],
	[PaymentMethod],
	[PaymentStatus],
	[DeliveryStaff],
	[ShippingMethod],
	[ShippingStatus],
	[ShippingFullName],
	[ShippingEmail],
	[ShippingPhone],
	[ShippingFax],
	[ShippingCompany],
	[ShippingAddress],
	[ShippingDate],
	[ShippingDeliveredDate],
	[ShippingCity],
	[ShippingState],
	[ShippingCountry],
	[BillingFullName],
	[BillingEmail],
	[BillingPhone],
	[BillingFax],
	[BillingCompany],
	[BillingShippingAddress],
	[BillingCity],
	[BillingState],
	[BillingCountry],
	[InvoiceTaxCode],
	[InvoiceAddress],
	[OrderNote],
	[ModifiedBy],
	[ModifiedDate],
	[Column4],
	[Column3],
	[Column2],
	[Column1],
	[Priority],
	[IsActive]
) VALUES (
		@MaxOrderMenuID,
	@OrderCode,
	@OrderStatus,
	@Customer,
	@OrderSubTotal,
	@OrderTax,
	@OrderDiscount2,
	@OrderDiscount,
	@OrderShippingFee,
	@CustomerIp,
	@PaymentMethod,
	@PaymentStatus,
	@DeliveryStaff,
	@ShippingMethod,
	@ShippingStatus,
	@ShippingFullName,
	@ShippingEmail,
	@ShippingPhone,
	@ShippingFax,
	@ShippingCompany,
	@ShippingAddress,
	@ShippingDate,
	@ShippingDeliveredDate,
	@ShippingCity,
	@ShippingState,
	@ShippingCountry,
	@BillingFullName,
	@BillingEmail,
	@BillingPhone,
	@BillingFax,
	@BillingCompany,
	@BillingShippingAddress,
	@BillingCity,
	@BillingState,
	@BillingCountry,
	@InvoiceTaxCode,
	@InvoiceAddress,
	@OrderNote,
	@ModifiedBy,
	@ModifiedDate,
	@Column4,
	@Column3,
	@Column2,
	@Column1,
	@Priority,
	@IsActive
 
)
exec('declare @CurrentOrderMenuID int
declare @Position int
SET @CurrentOrderMenuID = '+@MaxOrderMenuID+
' SET @Position = '+@Priority+
' declare @DestOrderMenuID int
declare @DestPriority int
declare @CountChangeItems int
declare @NewOrderMenuID int

set @DestOrderMenuID = (select  top 1 OrderMenuID from (select top '+@Priority+ ' OrderMenuID,Priority  from OrderMenu order by Priority) as a order by Priority desc)
set @DestPriority = (select  top 1 Priority from (select top '+@Priority+' Priority  from OrderMenu order by Priority) as a order by Priority desc)
SELECT @CountChangeItems = (select count(OrderMenuID) from OrderMenu where Priority > @DestPriority)
SET @CountChangeItems = @CountChangeItems - 1
if @Position = 1
BEGIN
	SET @DestPriority  = 1
END
	
UPDATE [dbo].OrderMenu SET
			[Priority] = @DestPriority
		WHERE
			OrderMenuID = @CurrentOrderMenuID
select @DestPriority = @DestPriority + 1				
		
UPDATE [dbo].OrderMenu SET
			[Priority] = @DestPriority
		WHERE
			OrderMenuID = @DestOrderMenuID
		
WHILE @CountChangeItems > 0
		BEGIN
		select top 1 @DestOrderMenuID = OrderMenuID from OrderMenu where Priority >= @DestPriority and OrderMenuID != @DestOrderMenuID  order by Priority
		select @DestPriority = @DestPriority + 1
	
		UPDATE [dbo].OrderMenu SET
			[Priority] = @DestPriority
		WHERE
			OrderMenuID = @DestOrderMenuID
			
		SELECT @CountChangeItems=@CountChangeItems - 1
		
		END')

select @OrderMenuID =  @MaxOrderMenuID
--endregion

GO


--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[OrderMenuUpdate]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[OrderMenuUpdate]
	@OrderMenuID int,
	@OrderCode nvarchar(30),
	@OrderStatus nvarchar(20),
	@Customer nvarchar(50),
	@OrderSubTotal float,
	@OrderTax float,
	@OrderDiscount2 float,
	@OrderDiscount float,
	@OrderShippingFee float,
	@CustomerIp nvarchar(20),
	@PaymentMethod nvarchar(20),
	@PaymentStatus nvarchar(20),
	@DeliveryStaff nvarchar(50),
	@ShippingMethod nvarchar(20),
	@ShippingStatus nvarchar(20),
	@ShippingFullName nvarchar(20),
	@ShippingEmail nvarchar(30),
	@ShippingPhone nvarchar(30),
	@ShippingFax nvarchar(30),
	@ShippingCompany nvarchar(50),
	@ShippingAddress nvarchar(300),
	@ShippingDate datetime,
	@ShippingDeliveredDate datetime,
	@ShippingCity nvarchar(20),
	@ShippingState nvarchar(20),
	@ShippingCountry nvarchar(20),
	@BillingFullName nvarchar(20),
	@BillingEmail nvarchar(30),
	@BillingPhone nvarchar(30),
	@BillingFax nvarchar(30),
	@BillingCompany nvarchar(50),
	@BillingShippingAddress nvarchar(300),
	@BillingCity nvarchar(20),
	@BillingState nvarchar(20),
	@BillingCountry nvarchar(20),
	@InvoiceTaxCode nvarchar(50),
	@InvoiceAddress nvarchar(50),
	@OrderNote nvarchar(1000),
	@ModifiedBy nvarchar(40),
	@ModifiedDate datetime,
	@Column4 nvarchar(50),
	@Column3 nvarchar(50),
	@Column2 nvarchar(50),
	@Column1 nvarchar(50),
	@Priority int,
	@IsActive bit
 
AS


UPDATE [dbo].[OrderMenu] SET
	[OrderCode] = @OrderCode,
	[OrderStatus] = @OrderStatus,
	[Customer] = @Customer,
	[OrderSubTotal] = @OrderSubTotal,
	[OrderTax] = @OrderTax,
	[OrderDiscount2] = @OrderDiscount2,
	[OrderDiscount] = @OrderDiscount,
	[OrderShippingFee] = @OrderShippingFee,
	[CustomerIp] = @CustomerIp,
	[PaymentMethod] = @PaymentMethod,
	[PaymentStatus] = @PaymentStatus,
	[DeliveryStaff] = @DeliveryStaff,
	[ShippingMethod] = @ShippingMethod,
	[ShippingStatus] = @ShippingStatus,
	[ShippingFullName] = @ShippingFullName,
	[ShippingEmail] = @ShippingEmail,
	[ShippingPhone] = @ShippingPhone,
	[ShippingFax] = @ShippingFax,
	[ShippingCompany] = @ShippingCompany,
	[ShippingAddress] = @ShippingAddress,
	[ShippingDate] = @ShippingDate,
	[ShippingDeliveredDate] = @ShippingDeliveredDate,
	[ShippingCity] = @ShippingCity,
	[ShippingState] = @ShippingState,
	[ShippingCountry] = @ShippingCountry,
	[BillingFullName] = @BillingFullName,
	[BillingEmail] = @BillingEmail,
	[BillingPhone] = @BillingPhone,
	[BillingFax] = @BillingFax,
	[BillingCompany] = @BillingCompany,
	[BillingShippingAddress] = @BillingShippingAddress,
	[BillingCity] = @BillingCity,
	[BillingState] = @BillingState,
	[BillingCountry] = @BillingCountry,
	[InvoiceTaxCode] = @InvoiceTaxCode,
	[InvoiceAddress] = @InvoiceAddress,
	[OrderNote] = @OrderNote,
	[ModifiedBy] = @ModifiedBy,
	[ModifiedDate] = @ModifiedDate,
	[Column4] = @Column4,
	[Column3] = @Column3,
	[Column2] = @Column2,
	[Column1] = @Column1,
	[Priority] = @Priority,
	[IsActive] = @IsActive
WHERE
	[OrderMenuID] = @OrderMenuID
Declare @OldPosition int
SELECT @OldPosition = count(OrderMenuID) from OrderMenu where Priority <= (SELECT Priority From OrderMenu where OrderMenuID = @OrderMenuID)
IF @OldPosition != @Priority
BEGIN
exec('declare @CurrentOrderMenuID int
declare @Position int
SET @CurrentOrderMenuID = '+@OrderMenuID+
' SET @Position = '+@Priority+
' declare @DestOrderMenuID int
declare @DestPriority int
declare @CountChangeItems int
declare @NewOrderMenuID int

set @DestOrderMenuID = (select  top 1 OrderMenuID from (select top '+@Priority+ ' OrderMenuID,Priority  from OrderMenu order by Priority) as a order by Priority desc)
set @DestPriority = (select  top 1 Priority from (select top '+@Priority+' Priority  from OrderMenu order by Priority) as a order by Priority desc)
SELECT @CountChangeItems = (select count(OrderMenuID) from OrderMenu where Priority > @DestPriority)
SET @CountChangeItems = @CountChangeItems - 1
if @Position = 1
BEGIN
	SET @DestPriority  = 1
END
	
UPDATE [dbo].OrderMenu SET
			[Priority] = @DestPriority
		WHERE
			OrderMenuID = @CurrentOrderMenuID
select @DestPriority = @DestPriority + 1				
		
UPDATE [dbo].OrderMenu SET
			[Priority] = @DestPriority
		WHERE
			OrderMenuID = @DestOrderMenuID
		
WHILE @CountChangeItems > 0
		BEGIN
		select top 1 @DestOrderMenuID = OrderMenuID from OrderMenu where Priority >= @DestPriority and OrderMenuID != @DestOrderMenuID  order by Priority
		select @DestPriority = @DestPriority + 1
	
		UPDATE [dbo].OrderMenu SET
			[Priority] = @DestPriority
		WHERE
			OrderMenuID = @DestOrderMenuID
			
		SELECT @CountChangeItems=@CountChangeItems - 1
		
		END')
END
--endregion

GO


--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[OrderMenuDelete]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[OrderMenuDelete]
	@OrderMenuID int
AS
DELETE FROM [dbo].[OrderMenu]
WHERE
	[OrderMenuID] = @OrderMenuID

--endregion

GO


--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[OrderMenuGetByID]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[OrderMenuGetByID]
	@OrderMenuID int
AS


SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[OrderMenuID],
	[OrderCode],
	[OrderStatus],
	[Customer],
	[OrderSubTotal],
	[OrderTax],
	[OrderDiscount2],
	[OrderDiscount],
	[OrderShippingFee],
	[CustomerIp],
	[PaymentMethod],
	[PaymentStatus],
	[DeliveryStaff],
	[ShippingMethod],
	[ShippingStatus],
	[ShippingFullName],
	[ShippingEmail],
	[ShippingPhone],
	[ShippingFax],
	[ShippingCompany],
	[ShippingAddress],
	[ShippingDate],
	[ShippingDeliveredDate],
	[ShippingCity],
	[ShippingState],
	[ShippingCountry],
	[BillingFullName],
	[BillingEmail],
	[BillingPhone],
	[BillingFax],
	[BillingCompany],
	[BillingShippingAddress],
	[BillingCity],
	[BillingState],
	[BillingCountry],
	[InvoiceTaxCode],
	[InvoiceAddress],
	[OrderNote],
	[ModifiedBy],
	[ModifiedDate],
	[Column4],
	[Column3],
	[Column2],
	[Column1],
	[Priority],
	[IsActive]
FROM
	[dbo].[OrderMenu]
WHERE
	[OrderMenuID] = @OrderMenuID

--endregion

GO




--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[OrderMenusGetAll]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[OrderMenusGetAll]
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[OrderMenuID],
	[OrderCode],
	[OrderStatus],
	[Customer],
	[OrderSubTotal],
	[OrderTax],
	[OrderDiscount2],
	[OrderDiscount],
	[OrderShippingFee],
	[CustomerIp],
	[PaymentMethod],
	[PaymentStatus],
	[DeliveryStaff],
	[ShippingMethod],
	[ShippingStatus],
	[ShippingFullName],
	[ShippingEmail],
	[ShippingPhone],
	[ShippingFax],
	[ShippingCompany],
	[ShippingAddress],
	[ShippingDate],
	[ShippingDeliveredDate],
	[ShippingCity],
	[ShippingState],
	[ShippingCountry],
	[BillingFullName],
	[BillingEmail],
	[BillingPhone],
	[BillingFax],
	[BillingCompany],
	[BillingShippingAddress],
	[BillingCity],
	[BillingState],
	[BillingCountry],
	[InvoiceTaxCode],
	[InvoiceAddress],
	[OrderNote],
	[ModifiedBy],
	[ModifiedDate],
	[Column4],
	[Column3],
	[Column2],
	[Column1],
	[Priority],
	[IsActive]
FROM
	[dbo].[OrderMenu]

--endregion

GO

