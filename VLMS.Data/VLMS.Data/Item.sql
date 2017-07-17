﻿CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[AdditionalName] [nvarchar](200) NULL,
	[Description] [nvarchar](2000) NULL,
	[SerialNumber] [nvarchar](200) NULL,
	[ManufactoryId] [int] NULL,
	[MadeInCountryId] [int] NULL,
	[ManagedByLibrarianId] [bigint] NULL,
	[LibraryId] [int] NOT NULL,
	[ContributorId] [bigint] NULL,
	[ContributionDate] [date] NULL,
	[OriginalPrice] [decimal](18, 0) NULL,
	[PresentValue] [decimal](18, 0) NULL,
	[Rating] [decimal](2, 1) NULL,
	[StatusId] [int] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[LastModifiedByUserId] [bigint] NULL,
	[LastModifiedDataTime] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	primary key(Id)
)