CREATE TABLE [dbo].[Error]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Message] nvarchar(50),
	[StackTrace] nvarchar(50),
	[CreatedDate] DateTime 

)
