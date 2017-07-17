CREATE TABLE [dbo].[Library](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[LibraryAdminId] [bigint] NULL,
	primary key(Id)
 )