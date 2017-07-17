CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[ParrentCategoryId] [int] NULL,
	[LibraryId] [int] NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[LastModifiedByUserId] [bigint] NULL,
	[LastModifiedDataTime] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	primary key([Id])
)