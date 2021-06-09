
--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[OrderDetailInsert]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[OrderDetailInsert]
	@OrderMenuID int,
	@ProductName nvarchar(250),
	@ProductID int,
	@ProductCode nvarchar(30),
	@ProductPrice float,
	@Discount float,
	@SubTotal float,
	@Total float,
	@Tax float,
	@Priority int,
	@IsActive bit
 
,@OrderDetailID int output
AS
DECLARE @MaxOrderDetailID int
SELECT @MaxOrderDetailID = isnull(max(OrderDetailID),0) from OrderDetail
SET @MaxOrderDetailID =@MaxOrderDetailID +1


INSERT INTO [dbo].[OrderDetail] (
	[OrderDetailID],
	[OrderMenuID],
	[ProductName],
	[ProductID],
	[ProductCode],
	[ProductPrice],
	[Discount],
	[SubTotal],
	[Total],
	[Tax],
	[Priority],
	[IsActive]
) VALUES (
		@MaxOrderDetailID,
	@OrderMenuID,
	@ProductName,
	@ProductID,
	@ProductCode,
	@ProductPrice,
	@Discount,
	@SubTotal,
	@Total,
	@Tax,
	@Priority,
	@IsActive
 
)
exec('declare @CurrentOrderDetailID int
declare @Position int
SET @CurrentOrderDetailID = '+@MaxOrderDetailID+
' SET @Position = '+@Priority+
' declare @DestOrderDetailID int
declare @DestPriority int
declare @CountChangeItems int
declare @NewOrderDetailID int

set @DestOrderDetailID = (select  top 1 OrderDetailID from (select top '+@Priority+ ' OrderDetailID,Priority  from OrderDetail order by Priority) as a order by Priority desc)
set @DestPriority = (select  top 1 Priority from (select top '+@Priority+' Priority  from OrderDetail order by Priority) as a order by Priority desc)
SELECT @CountChangeItems = (select count(OrderDetailID) from OrderDetail where Priority > @DestPriority)
SET @CountChangeItems = @CountChangeItems - 1
if @Position = 1
BEGIN
	SET @DestPriority  = 1
END
	
UPDATE [dbo].OrderDetail SET
			[Priority] = @DestPriority
		WHERE
			OrderDetailID = @CurrentOrderDetailID
select @DestPriority = @DestPriority + 1				
		
UPDATE [dbo].OrderDetail SET
			[Priority] = @DestPriority
		WHERE
			OrderDetailID = @DestOrderDetailID
		
WHILE @CountChangeItems > 0
		BEGIN
		select top 1 @DestOrderDetailID = OrderDetailID from OrderDetail where Priority >= @DestPriority and OrderDetailID != @DestOrderDetailID  order by Priority
		select @DestPriority = @DestPriority + 1
	
		UPDATE [dbo].OrderDetail SET
			[Priority] = @DestPriority
		WHERE
			OrderDetailID = @DestOrderDetailID
			
		SELECT @CountChangeItems=@CountChangeItems - 1
		
		END')

select @OrderDetailID =  @MaxOrderDetailID
--endregion

GO


--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[OrderDetailUpdate]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[OrderDetailUpdate]
	@OrderDetailID int,
	@OrderMenuID int,
	@ProductName nvarchar(250),
	@ProductID int,
	@ProductCode nvarchar(30),
	@ProductPrice float,
	@Discount float,
	@SubTotal float,
	@Total float,
	@Tax float,
	@Priority int,
	@IsActive bit
 
AS


UPDATE [dbo].[OrderDetail] SET
	[OrderMenuID] = @OrderMenuID,
	[ProductName] = @ProductName,
	[ProductID] = @ProductID,
	[ProductCode] = @ProductCode,
	[ProductPrice] = @ProductPrice,
	[Discount] = @Discount,
	[SubTotal] = @SubTotal,
	[Total] = @Total,
	[Tax] = @Tax,
	[Priority] = @Priority,
	[IsActive] = @IsActive
WHERE
	[OrderDetailID] = @OrderDetailID
Declare @OldPosition int
SELECT @OldPosition = count(OrderDetailID) from OrderDetail where Priority <= (SELECT Priority From OrderDetail where OrderDetailID = @OrderDetailID)
IF @OldPosition != @Priority
BEGIN
exec('declare @CurrentOrderDetailID int
declare @Position int
SET @CurrentOrderDetailID = '+@OrderDetailID+
' SET @Position = '+@Priority+
' declare @DestOrderDetailID int
declare @DestPriority int
declare @CountChangeItems int
declare @NewOrderDetailID int

set @DestOrderDetailID = (select  top 1 OrderDetailID from (select top '+@Priority+ ' OrderDetailID,Priority  from OrderDetail order by Priority) as a order by Priority desc)
set @DestPriority = (select  top 1 Priority from (select top '+@Priority+' Priority  from OrderDetail order by Priority) as a order by Priority desc)
SELECT @CountChangeItems = (select count(OrderDetailID) from OrderDetail where Priority > @DestPriority)
SET @CountChangeItems = @CountChangeItems - 1
if @Position = 1
BEGIN
	SET @DestPriority  = 1
END
	
UPDATE [dbo].OrderDetail SET
			[Priority] = @DestPriority
		WHERE
			OrderDetailID = @CurrentOrderDetailID
select @DestPriority = @DestPriority + 1				
		
UPDATE [dbo].OrderDetail SET
			[Priority] = @DestPriority
		WHERE
			OrderDetailID = @DestOrderDetailID
		
WHILE @CountChangeItems > 0
		BEGIN
		select top 1 @DestOrderDetailID = OrderDetailID from OrderDetail where Priority >= @DestPriority and OrderDetailID != @DestOrderDetailID  order by Priority
		select @DestPriority = @DestPriority + 1
	
		UPDATE [dbo].OrderDetail SET
			[Priority] = @DestPriority
		WHERE
			OrderDetailID = @DestOrderDetailID
			
		SELECT @CountChangeItems=@CountChangeItems - 1
		
		END')
END
--endregion

GO


--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[OrderDetailDelete]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[OrderDetailDelete]
	@OrderDetailID int
AS
DELETE FROM [dbo].[OrderDetail]
WHERE
	[OrderDetailID] = @OrderDetailID

--endregion

GO


--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[OrderDetailGetByID]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[OrderDetailGetByID]
	@OrderDetailID int
AS


SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[OrderDetailID],
	[OrderMenuID],
	[ProductName],
	[ProductID],
	[ProductCode],
	[ProductPrice],
	[Discount],
	[SubTotal],
	[Total],
	[Tax],
	[Priority],
	[IsActive]
FROM
	[dbo].[OrderDetail]
WHERE
	[OrderDetailID] = @OrderDetailID

--endregion

GO




--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[OrderDetailsGetAll]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[OrderDetailsGetAll]
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[OrderDetailID],
	[OrderMenuID],
	[ProductName],
	[ProductID],
	[ProductCode],
	[ProductPrice],
	[Discount],
	[SubTotal],
	[Total],
	[Tax],
	[Priority],
	[IsActive]
FROM
	[dbo].[OrderDetail]

--endregion

GO

