CREATE TABLE [dbo].[ItemProfilePhoto](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[FilePath] [nvarchar](500) NOT NULL,
	[FileType] [nvarchar](10) NOT NULL,
	[ProfileOrder] [int] NOT NULL,
	[IsThumbnail] [bit] NOT NULL,
	primary key(Id)
 )