
--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[CategoryInsert]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[CategoryInsert]
	@Name nvarchar(50),
	@Value nvarchar(50),
	@Note nvarchar(50),
	@TypeOfCategory int,
	@Priority int,
	@IsActive bit
 
,@CategoryID int output
AS
DECLARE @MaxCategoryID int
SELECT @MaxCategoryID = isnull(max(CategoryID),0) from Category
SET @MaxCategoryID =@MaxCategoryID +1


INSERT INTO [dbo].[Category] (
	[CategoryID],
	[Name],
	[Value],
	[Note],
	[TypeOfCategory],
	[Priority],
	[IsActive]
) VALUES (
		@MaxCategoryID,
	@Name,
	@Value,
	@Note,
	@TypeOfCategory,
	@Priority,
	@IsActive
 
)
exec('declare @CurrentCategoryID int
declare @Position int
SET @CurrentCategoryID = '+@MaxCategoryID+
' SET @Position = '+@Priority+
' declare @DestCategoryID int
declare @DestPriority int
declare @CountChangeItems int
declare @NewCategoryID int

set @DestCategoryID = (select  top 1 CategoryID from (select top '+@Priority+ ' CategoryID,Priority  from Category order by Priority) as a order by Priority desc)
set @DestPriority = (select  top 1 Priority from (select top '+@Priority+' Priority  from Category order by Priority) as a order by Priority desc)
SELECT @CountChangeItems = (select count(CategoryID) from Category where Priority > @DestPriority)
SET @CountChangeItems = @CountChangeItems - 1
if @Position = 1
BEGIN
	SET @DestPriority  = 1
END
	
UPDATE [dbo].Category SET
			[Priority] = @DestPriority
		WHERE
			CategoryID = @CurrentCategoryID
select @DestPriority = @DestPriority + 1				
		
UPDATE [dbo].Category SET
			[Priority] = @DestPriority
		WHERE
			CategoryID = @DestCategoryID
		
WHILE @CountChangeItems > 0
		BEGIN
		select top 1 @DestCategoryID = CategoryID from Category where Priority >= @DestPriority and CategoryID != @DestCategoryID  order by Priority
		select @DestPriority = @DestPriority + 1
	
		UPDATE [dbo].Category SET
			[Priority] = @DestPriority
		WHERE
			CategoryID = @DestCategoryID
			
		SELECT @CountChangeItems=@CountChangeItems - 1
		
		END')

select @CategoryID =  @MaxCategoryID
--endregion

GO


--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[CategoryUpdate]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[CategoryUpdate]
	@CategoryID int,
	@Name nvarchar(50),
	@Value nvarchar(50),
	@Note nvarchar(50),
	@TypeOfCategory int,
	@Priority int,
	@IsActive bit
 
AS


UPDATE [dbo].[Category] SET
	[Name] = @Name,
	[Value] = @Value,
	[Note] = @Note,
	[TypeOfCategory] = @TypeOfCategory,
	[Priority] = @Priority,
	[IsActive] = @IsActive
WHERE
	[CategoryID] = @CategoryID
Declare @OldPosition int
SELECT @OldPosition = count(CategoryID) from Category where Priority <= (SELECT Priority From Category where CategoryID = @CategoryID)
IF @OldPosition != @Priority
BEGIN
exec('declare @CurrentCategoryID int
declare @Position int
SET @CurrentCategoryID = '+@CategoryID+
' SET @Position = '+@Priority+
' declare @DestCategoryID int
declare @DestPriority int
declare @CountChangeItems int
declare @NewCategoryID int

set @DestCategoryID = (select  top 1 CategoryID from (select top '+@Priority+ ' CategoryID,Priority  from Category order by Priority) as a order by Priority desc)
set @DestPriority = (select  top 1 Priority from (select top '+@Priority+' Priority  from Category order by Priority) as a order by Priority desc)
SELECT @CountChangeItems = (select count(CategoryID) from Category where Priority > @DestPriority)
SET @CountChangeItems = @CountChangeItems - 1
if @Position = 1
BEGIN
	SET @DestPriority  = 1
END
	
UPDATE [dbo].Category SET
			[Priority] = @DestPriority
		WHERE
			CategoryID = @CurrentCategoryID
select @DestPriority = @DestPriority + 1				
		
UPDATE [dbo].Category SET
			[Priority] = @DestPriority
		WHERE
			CategoryID = @DestCategoryID
		
WHILE @CountChangeItems > 0
		BEGIN
		select top 1 @DestCategoryID = CategoryID from Category where Priority >= @DestPriority and CategoryID != @DestCategoryID  order by Priority
		select @DestPriority = @DestPriority + 1
	
		UPDATE [dbo].Category SET
			[Priority] = @DestPriority
		WHERE
			CategoryID = @DestCategoryID
			
		SELECT @CountChangeItems=@CountChangeItems - 1
		
		END')
END
--endregion

GO


--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[CategoryDelete]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[CategoryDelete]
	@CategoryID int
AS
DELETE FROM [dbo].[Category]
WHERE
	[CategoryID] = @CategoryID

--endregion

GO


--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[CategoryGetByID]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[CategoryGetByID]
	@CategoryID int
AS


SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[CategoryID],
	[Name],
	[Value],
	[Note],
	[TypeOfCategory],
	[Priority],
	[IsActive]
FROM
	[dbo].[Category]
WHERE
	[CategoryID] = @CategoryID

--endregion

GO




--=============================================
-- Author: Bach Hop Investment Company
-- Stored Procedure Name: [dbo].[CategoriesGetAll]
-- Create Date: Monday, April 14, 2014
--=============================================

CREATE PROCEDURE [dbo].[CategoriesGetAll]
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[CategoryID],
	[Name],
	[Value],
	[Note],
	[TypeOfCategory],
	[Priority],
	[IsActive]
FROM
	[dbo].[Category]

--endregion

GO

