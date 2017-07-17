/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--3reference data for Category
MERGE INTO Category AS Target 
USING (VALUES 
        (1, 'Economics', N'sách kinh tế',1, 1,1, 
		'2017-3-12', 1, '2017-3-22',1 ) ,
		(2, 'History', N'Sách lịch sử', 1, 1, 1,
		'2016-12-5',2, '2016-12-29', 1 ),
		(3,'Modern History', N'Lịch sử cận đại', 1, 2, 1,
		'2016-12-12', 3, '2017-2-14', 1)
       
) 
AS Source ([Id] ,
	[Name],
	[Description],
	[ParrentCategoryId] ,
	[LibraryId] ,
	[CreatedByUserId],

	[CreatedDateTime] ,
	[LastModifiedByUserId] ,
	[LastModifiedDataTime] ,
	[IsActive]) 
ON Target.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN 
INSERT (
	[Name],
	[Description],
	[ParrentCategoryId] ,
	[LibraryId] ,
	[CreatedByUserId],
	[CreatedDateTime] ,
	[LastModifiedByUserId] ,
	[LastModifiedDataTime] ,
	[IsActive]) 
VALUES (
	[Name],
	[Description],
	[ParrentCategoryId] ,
	[LibraryId] ,
	[CreatedByUserId],
	[CreatedDateTime] ,
	[LastModifiedByUserId] ,
	[LastModifiedDataTime] ,
	[IsActive]);
--4reference data for Country
--5reference data for Item

MERGE INTO Item AS Target
USING (VALUES(1, N'Tony Buổi sáng', N'cafe cùng tony', N'BestSeller2014','ISBN222222',
 1, 1, 1, 1,1,
 getdate(), 40000, 20000, 4.5, 1, 1, '2016-3-3 12:00:00', 2, '2017-3-31T11:45:34.123124', 1),

 (2, N'Mật mã Davincy', N'The Davinc Code', N'Novel of Ennglish', 'ISBN32611627',
 2,2,1,1,1,
 getdate(), 60000, 20000, 4.0, 1,
 1, '2016-6-28 11:59:59', 2, '2017-2-12 10:34:56', 1),


 (3, N'Nhập môn lập trình', N'Lập trình C++', N'KHTNLib','ISBN876543',
 1,1,1,1,1,
 getdate(), 70000, 30000, 4.5, 1,
 1, '2016-7-28 7:23:45',3, '2017-1-4 11:11:11', 1 )
 )
AS source([Id],
	[Name] ,
	[AdditionalName],
	[Description] ,
	[SerialNumber] ,

	[ManufactoryId] ,
	[MadeInCountryId] ,
	[ManagedByLibrarianId] ,
	[LibraryId],
	[ContributorId] ,

	[ContributionDate] ,
	[OriginalPrice] ,
	[PresentValue] ,
	[Rating],
	[StatusId],

	[CreatedByUserId],
	[CreatedDateTime] ,
	[LastModifiedByUserId] ,
	[LastModifiedDataTime] ,
	[IsActive] 
	)
ON Target.[Id]=source.[Id]
WHEN NOT MATCHED BY TARGET THEN 
INSERT (
	[Name] ,
	[AdditionalName],
	[Description] ,
	[SerialNumber] ,

	[ManufactoryId] ,
	[MadeInCountryId] ,
	[ManagedByLibrarianId] ,
	[LibraryId],
	[ContributorId] ,

	[ContributionDate] ,
	[OriginalPrice] ,
	[PresentValue] ,
	[Rating],
	[StatusId],

	[CreatedByUserId],
	[CreatedDateTime] ,
	[LastModifiedByUserId] ,
	[LastModifiedDataTime] ,
	[IsActive] 
	) 
VALUES (
	[Name] ,
	[AdditionalName],
	[Description] ,
	[SerialNumber] ,

	[ManufactoryId] ,
	[MadeInCountryId],
	[ManagedByLibrarianId] ,
	[LibraryId],
	[ContributorId] ,

	[ContributionDate] ,
	[OriginalPrice] ,
	[PresentValue] ,
	[Rating],
	[StatusId],

	[CreatedByUserId],
	[CreatedDateTime] ,
	[LastModifiedByUserId] ,
	[LastModifiedDataTime] ,
	[IsActive] 
	);
--6reference data for ItemCategory

Merge Into ItemCategory as Target
USing (values(1, 1, 1))
as source([Id],
	[CategoryId],
	[ItemId])
on Target.[Id]=source.[Id]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id],
	[CategoryId],
	[ItemId]) 
VALUES ([Id],
	[CategoryId],
	[ItemId]);
--7reference data for ItemProfilePhoto
/*[Id] [bigint] NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[FilePath] [nvarchar](500) NOT NULL,
	[FileType] [nvarchar](10) NOT NULL,
	[ProfileOrder] [int] NOT NULL,
	[IsThumbnail] [bit] NOT NULL,*/
Merge Into ItemProfilePhoto as Target
USing (values(1, 1, ':\\D','.png', 1, 1))
as source([Id],
	[ItemId],
	[FilePath] ,
	[FileType] ,
	[ProfileOrder],
	[IsThumbnail])
on Target.[Id]=source.[Id]
WHEN NOT MATCHED BY TARGET THEN 
INSERT (
	[ItemId],
	[FilePath] ,
	[FileType] ,
	[ProfileOrder],
	[IsThumbnail]) 
VALUES (
	[ItemId],
	[FilePath] ,
	[FileType] ,
	[ProfileOrder],
	[IsThumbnail]);
--8. Reference data for Joining Reuest
--9. Reference data for Library
--10. Reference data for Manuafactory
--11.Reference data for Notification
--12.Reference data for Review
--13.Reference data for Status
--14.Reference data for Transefer
--15.Reference data for warehouse
--16.Reference data for userprofile
Merge Into UserProfile as Target
USing (values(1, N'Nguyễn Tiến Dũng', N'kuro@gmail.com',1, 1, 1, 1),
			(2, N'Vũ Đình Thăng', N'dinhthang2307@gmail.com', 2, 2, 2, 2)
)
as source([UserId],
	[FullName],
	[Email],
	[OrgId],
	[CompanyId],
	[AddressId],
	[ProfilePhotoId])
on Target.[UserId]=source.[UserId]
WHEN NOT MATCHED BY TARGET THEN 
INSERT (
	[FullName],
	[Email],
	[OrgId],
	[CompanyId],
	[AddressId],
	[ProfilePhotoId]) 
VALUES (
	[FullName],
	[Email],
	[OrgId],
	[CompanyId],
	[AddressId],
	[ProfilePhotoId]);

/************add foreign key*******/
