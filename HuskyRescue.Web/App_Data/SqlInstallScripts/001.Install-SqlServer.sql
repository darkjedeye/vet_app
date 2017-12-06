/****** Object:  Database [HuskyRescue]    Script Date: 10/29/2013 10:03:46 PM ******/
CREATE DATABASE [HuskyRescue]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HuskyRescue', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\HuskyRescue.mdf' , SIZE = 9216KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HuskyRescue_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\HuskyRescue_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HuskyRescue] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HuskyRescue].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HuskyRescue] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HuskyRescue] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HuskyRescue] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HuskyRescue] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HuskyRescue] SET ARITHABORT OFF 
GO
ALTER DATABASE [HuskyRescue] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HuskyRescue] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HuskyRescue] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HuskyRescue] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HuskyRescue] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HuskyRescue] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HuskyRescue] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HuskyRescue] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HuskyRescue] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HuskyRescue] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HuskyRescue] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HuskyRescue] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HuskyRescue] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HuskyRescue] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HuskyRescue] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HuskyRescue] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HuskyRescue] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HuskyRescue] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HuskyRescue] SET RECOVERY FULL 
GO
ALTER DATABASE [HuskyRescue] SET  MULTI_USER 
GO
ALTER DATABASE [HuskyRescue] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HuskyRescue] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HuskyRescue] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HuskyRescue] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
/****** Object:  Table [dbo].[Applicant]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applicant](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PersonID] [uniqueidentifier] NOT NULL,
	[ApplicantVeterinariansID] [uniqueidentifier] NULL,
	[ApplicantType] [nvarchar](1) NOT NULL,
	[DateSubmitted] [datetime2](7) NOT NULL,
	[AppNameFirst] [nvarchar](50) NOT NULL,
	[AppNameLast] [nvarchar](50) NOT NULL,
	[AppSpouseNameFirst] [nvarchar](50) NULL,
	[AppSpouseNameLast] [nvarchar](50) NULL,
	[AppCellPhone] [nvarchar](15) NULL,
	[AppHomePhone] [nvarchar](15) NULL,
	[AppAddressStreet1] [nvarchar](50) NOT NULL,
	[AppAddressCity] [nvarchar](50) NOT NULL,
	[AppAddressStateId] [nvarchar](2) NULL,
	[AppAddressZIP] [nvarchar](10) NOT NULL,
	[AppEmail] [nvarchar](200) NULL,
	[AppDateBirth] [datetime2](7) NULL,
	[AppEmployer] [nvarchar](50) NULL,
	[ResidenceOwnershipID] [int] NOT NULL,
	[ResidenceTypeID] [int] NOT NULL,
	[ResidenceIsPetAllowed] [bit] NULL,
	[ResidenceIsPetDepositRequired] [bit] NULL,
	[ResidencePetDepositAmount] [decimal](18, 2) NULL,
	[ResidenceIsPetDepositPaid] [bit] NULL,
	[ResidencePetDepositCoverageID] [int] NULL,
	[ResidenceIsPetSizeWeightLimit] [bit] NULL,
	[ResidenceLandlordName] [nvarchar](100) NULL,
	[ResidenceLandlordNumber] [nvarchar](14) NULL,
	[ResidenceLengthOfResidence] [nvarchar](30) NOT NULL,
	[IsAppOrSpouseStudent] [bit] NOT NULL,
	[StudentTypeID] [int] NULL,
	[IsAppTravelFrequent] [bit] NOT NULL,
	[AppTravelFrequency] [nvarchar](50) NULL,
	[WhatIfTravelPetPlacement] [nvarchar](4000) NULL,
	[WhatIfMovingPetPlacement] [nvarchar](4000) NULL,
	[ResidenceNumberOccupants] [nvarchar](50) NULL,
	[ResidenceAgesOfChildren] [nvarchar](200) NULL,
	[ResidenceIsYardFenced] [bit] NOT NULL,
	[ResidenceFenceType] [nvarchar](50) NULL,
	[ResidenceFenceHeight] [nvarchar](50) NULL,
	[LengthPetLeftAloneHoursInDay] [nvarchar](20) NULL,
	[LengthPetLeftAloneDaysOfWeek] [nvarchar](20) NULL,
	[PetKeptLocationInOutDoors] [nvarchar](200) NULL,
	[IsPetKeptLocationInOutDoorsTotallyInside] [bit] NOT NULL,
	[IsPetKeptLocationInOutDoorsMostlyInside] [bit] NOT NULL,
	[IsPetKeptLocationInOutDoorsTotallyOutside] [bit] NOT NULL,
	[IsPetKeptLocationInOutDoorMostlyOutsides] [bit] NOT NULL,
	[PetKeptLocationInOutDoorsExplain] [nvarchar](4000) NULL,
	[PetLeftAloneHours] [nvarchar](20) NULL,
	[PetLeftAloneDays] [nvarchar](20) NULL,
	[PetKeptLocationAloneRestriction] [nvarchar](max) NULL,
	[IsPetKeptLocationAloneRestrictionLooseIndoors] [bit] NOT NULL,
	[IsPetKeptLocationAloneRestrictionGarage] [bit] NOT NULL,
	[IsPetKeptLocationAloneRestrictionOutsideKennel] [bit] NOT NULL,
	[IsPetKeptLocationAloneRestrictionCratedIndoors] [bit] NOT NULL,
	[IsPetKeptLocationAloneRestrictionCratedOutdoors] [bit] NOT NULL,
	[IsPetKeptLocationAloneRestrictionLooseInBackyard] [bit] NOT NULL,
	[IsPetKeptLocationAloneRestrictionTiedUpOutdoors] [bit] NOT NULL,
	[IsPetKeptLocationAloneRestrictionBasement] [bit] NOT NULL,
	[IsPetKeptLocationAloneRestrictionOther] [bit] NOT NULL,
	[PetKeptLocationAloneRestrictionExplain] [nvarchar](4000) NULL,
	[PetKeptLocationSleepingRestriction] [nvarchar](max) NULL,
	[IsPetKeptLocationSleepingRestrictionLooseIndoors] [bit] NOT NULL,
	[IsPetKeptLocationSleepingRestrictionGarage] [bit] NOT NULL,
	[IsPetKeptLocationSleepingRestrictionOutsideKennel] [bit] NOT NULL,
	[IsPetKeptLocationSleepingRestrictionCratedIndoors] [bit] NOT NULL,
	[IsPetKeptLocationSleepingRestrictionCratedOutdoors] [bit] NOT NULL,
	[IsPetKeptLocationSleepingRestrictionLooseInBackyard] [bit] NOT NULL,
	[IsPetKeptLocationSleepingRestrictionTiedUpOutdoors] [bit] NOT NULL,
	[IsPetKeptLocationSleepingRestrictionBasement] [bit] NOT NULL,
	[IsPetKeptLocationSleepingRestrictionInBedOwner] [bit] NOT NULL,
	[IsPetKeptLocationSleepingRestrictionOther] [bit] NOT NULL,
	[PetKeptLocationSleepingRestrictionExplain] [nvarchar](4000) NULL,
	[PetAdoptionReason] [nvarchar](4000) NULL,
	[IsPetAdoptionReasonHousePet] [bit] NOT NULL,
	[IsPetAdoptionReasonGuardDog] [bit] NOT NULL,
	[IsPetAdoptionReasonWatchDog] [bit] NOT NULL,
	[IsPetAdoptionReasonGift] [bit] NOT NULL,
	[IsPetAdoptionReasonCompanionChild] [bit] NOT NULL,
	[IsPetAdoptionReasonCompanionPet] [bit] NOT NULL,
	[IsPetAdoptionReasonJoggingPartner] [bit] NOT NULL,
	[IsPetAdoptionReasonOther] [bit] NOT NULL,
	[PetAdoptionReasonExplain] [nvarchar](4000) NULL,
	[FilterAppHasOwnedHuskyBefore] [bit] NOT NULL,
	[FilterAppTraitsDesired] [nvarchar](4000) NULL,
	[FilterAppIsCatOwner] [bit] NOT NULL,
	[FilterAppCatsOwnedCount] [nvarchar](20) NULL,
	[FilterAppIsAwareHuskyAttributes] [bit] NOT NULL,
	[IsAllAdultsAgreedOnAdoption] [bit] NOT NULL,
	[IsAllAdultsAgreedOnAdoptionReason] [nvarchar](4000) NULL,
	[FilterAppDogsInterestedIn] [nvarchar](4000) NULL,
	[IsCompleted] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_AdoptionApplications] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicantOwnedAnimals]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicantOwnedAnimals](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ApplicantID] [uniqueidentifier] NOT NULL,
	[PersonID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Breed] [nvarchar](20) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[AgeMonths] [nvarchar](100) NULL,
	[OwnershipLengthMonths] [nvarchar](100) NULL,
	[IsAltered] [bit] NOT NULL,
	[AlteredReason] [nvarchar](200) NULL,
	[IsHwPrevention] [bit] NOT NULL,
	[HwPreventionReason] [nvarchar](200) NULL,
	[IsFullyVaccinated] [bit] NOT NULL,
	[FullyVaccinatedReason] [nvarchar](200) NULL,
	[IsStillOwned] [bit] NOT NULL,
	[IsStillOwnedReason] [nvarchar](200) NULL,
 CONSTRAINT [PK_ApplicantOwnedAnimals] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[ApplicantID] ASC,
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicantVeterinarians]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicantVeterinarians](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[NameOffice] [nvarchar](50) NULL,
	[NameDr] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
 CONSTRAINT [PK_ApplicantVeterinarians_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Applications]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[ApplicationName] [nvarchar](235) NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blog_Comments]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog_Comments](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PostID] [uniqueidentifier] NOT NULL,
	[ParentCommentID] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsSpam] [bit] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[AuthorIP] [nvarchar](50) NULL,
	[ModeratedByUserID] [uniqueidentifier] NULL,
	[ModeratedDate] [datetime2](7) NULL,
	[AuthorRegisteredUserID] [uniqueidentifier] NULL,
	[AuthorName] [nvarchar](255) NULL,
	[AuthorEmail] [nvarchar](255) NULL,
	[AuthorWebsite] [nvarchar](255) NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Blog_Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blog_Post]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog_Post](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[IsPublished] [bit] NOT NULL,
	[IsCommentEnabled] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[OriginalAuthor] [uniqueidentifier] NOT NULL,
	[LastModifyAuthor] [uniqueidentifier] NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Slug] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[PostContent] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Blog_Post] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blog_Tags]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog_Tags](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Blog_Tags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blog_TagsMapped]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog_TagsMapped](
	[PostID] [uniqueidentifier] NOT NULL,
	[TagID] [int] NOT NULL,
 CONSTRAINT [PK_Blog_TagsMapped] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_Addresses]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Entity_Addresses](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Street] [nvarchar](80) NOT NULL,
	[Street2] [nvarchar](80) NULL,
	[City] [nvarchar](50) NOT NULL,
	[StateID] [char](2) NOT NULL,
	[ZIP] [nvarchar](10) NOT NULL,
	[Type] [char](3) NOT NULL,
	[EntityID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Entity_Addresses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EntityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entity_Base]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_Base](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Type] [nchar](3) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateActive] [date] NULL,
	[DateInActive] [date] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[IsMailable] [bit] NOT NULL,
	[IsEmailable] [bit] NOT NULL,
	[WebsiteUrl] [nvarchar](200) NULL,
 CONSTRAINT [PK__Entity_B__3214EC2717036CC0] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_Dog]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Entity_Dog](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[GroupID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[IsIntake] [bit] NULL,
	[IntakeID] [uniqueidentifier] NULL,
	[Name] [nvarchar](50) NULL,
	[MicrochipID] [nvarchar](75) NULL,
	[MicrochipVendorID] [uniqueidentifier] NULL,
	[ShelterAnimalID] [nvarchar](50) NULL,
	[ShelterID] [uniqueidentifier] NULL,
	[TattooID] [nvarchar](50) NULL,
	[RegistrationID] [nvarchar](50) NULL,
	[RabiesID] [nvarchar](25) NULL,
	[OtherID] [nvarchar](50) NULL,
	[DateIntake] [date] NULL,
	[IntakeFromID] [int] NULL,
	[InitialActivityID] [int] NULL,
	[GenderID] [char](3) NULL,
	[DateOfBirth] [date] NULL,
	[BreedID] [int] NULL,
	[BreedSecondID] [int] NULL,
	[IsMix] [bit] NULL,
	[SizeID] [int] NULL,
	[Weight] [decimal](6, 2) NULL,
	[ColorID] [int] NULL,
	[IsAdoptionReady] [bit] NULL,
	[IsSpecialNeeds] [bit] NULL,
	[TimestampLastModify] [datetime] NULL,
	[SpecialNeedsNotes] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Biography] [nvarchar](max) NULL,
 CONSTRAINT [PK_Entity_Dog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entity_DogIntake]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_DogIntake](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[IntakeStatus] [int] NOT NULL,
	[ShelterName] [nvarchar](50) NULL,
	[WorkerName] [nvarchar](50) NULL,
	[HasUntil] [nvarchar](200) NULL,
	[VettingNotes] [nvarchar](1000) NULL,
	[HasDhppv] [bit] NULL,
	[HasDhlppv] [bit] NULL,
	[HasRabies] [bit] NULL,
	[HasBordetella] [bit] NULL,
	[IsDewormed] [bit] NULL,
	[IsHwPositive] [bit] NULL,
	[IsAltered] [bit] NULL,
	[IsUrgent] [bit] NULL,
	[FacebookUrl] [nvarchar](1000) NULL,
	[PetfinderUrl] [nvarchar](1000) NULL,
	[PetangoUrl] [nvarchar](1000) NULL,
	[OtherUrl] [nvarchar](1000) NULL,
	[Comments] [nvarchar](max) NULL,
	[UpdateTimestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Entity_DogIntake] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_DogPlacement]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_DogPlacement](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DogID] [uniqueidentifier] NOT NULL,
	[LocationID] [uniqueidentifier] NOT NULL,
	[DateIn] [date] NULL,
	[DateOut] [date] NOT NULL,
	[Status] [int] NOT NULL,
	[Comments] [nvarchar](3000) NULL,
 CONSTRAINT [PK_Entity_DogPlacement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_DonationItems]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_DonationItems](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PersonID] [uniqueidentifier] NULL,
	[OrganisationID] [uniqueidentifier] NULL,
	[Quantity] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[CostPerItem] [money] NULL,
	[DonationItemType] [int] NOT NULL,
	[HasBeenReceived] [bit] NOT NULL,
	[DateReceived] [date] NULL,
	[EventID] [uniqueidentifier] NULL,
	[EventPurposeID] [int] NULL,
 CONSTRAINT [PK_Event_DonationItems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_EmailAddress]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Entity_EmailAddress](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EntityID] [uniqueidentifier] NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Type] [char](3) NOT NULL,
 CONSTRAINT [PK_Entity_EmailAddresses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EntityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entity_File]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_File](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[PersonID] [uniqueidentifier] NULL,
	[OrgID] [uniqueidentifier] NULL,
	[DogID] [uniqueidentifier] NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[ContentType] [nvarchar](100) NOT NULL,
	[ServerPath] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_Entity_File] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_Organisation]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Entity_Organisation](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[BaseID] [uniqueidentifier] NOT NULL,
	[BusinessName] [nvarchar](50) NOT NULL,
	[ContactName] [nvarchar](50) NULL,
	[ContactTitle] [nvarchar](30) NULL,
	[EIN] [nchar](10) NULL,
	[Type] [char](3) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Entity_Organisation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entity_OrganisationContacts]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_OrganisationContacts](
	[OrganisationID] [uniqueidentifier] NOT NULL,
	[PersonID] [uniqueidentifier] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Entity_OrganisationContacts] PRIMARY KEY CLUSTERED 
(
	[OrganisationID] ASC,
	[PersonID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_OrganisationServices]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_OrganisationServices](
	[OrganisationID] [uniqueidentifier] NOT NULL,
	[ServiceID] [int] NOT NULL,
 CONSTRAINT [PK_Entity_OrganisationServices] PRIMARY KEY CLUSTERED 
(
	[OrganisationID] ASC,
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_Person]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Entity_Person](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[BaseID] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [char](3) NULL,
	[LicenseNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Entity_Person] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entity_PersonProfile]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_PersonProfile](
	[UserID] [uniqueidentifier] NOT NULL,
	[EntityPersonID] [uniqueidentifier] NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Website] [nvarchar](255) NULL,
	[Phone] [nvarchar](20) NULL,
 CONSTRAINT [PK_Entity_PersonProfile] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_PersonSkills]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_PersonSkills](
	[PersonID] [uniqueidentifier] NOT NULL,
	[SkillCode] [nvarchar](4) NOT NULL,
 CONSTRAINT [PK_Entity_PersonSkills] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC,
	[SkillCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_PhoneNumber]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Entity_PhoneNumber](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EntityID] [uniqueidentifier] NOT NULL,
	[Number] [nvarchar](15) NOT NULL,
	[Type] [char](3) NOT NULL,
 CONSTRAINT [PK_Entity_PhoneNumber] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EntityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entity_Supplies]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_Supplies](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[SupplyType] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastUpdateTimestamp] [datetime] NOT NULL,
	[Notes] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Entity_Supplies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_SupplyPlacement]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_SupplyPlacement](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[SupplyID] [uniqueidentifier] NOT NULL,
	[DateIn] [date] NOT NULL,
	[DateOut] [date] NULL,
	[Status] [int] NULL,
	[LocationID] [uniqueidentifier] NOT NULL,
	[Notes] [nvarchar](3000) NULL,
 CONSTRAINT [PK_Entity_SupplyPlacement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entity_SupplyType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity_SupplyType](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ProductUrl] [nvarchar](500) NULL,
	[Cost] [money] NULL,
	[Notes] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Entity_SupplyType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_AddressType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enum_AddressType](
	[ID] [char](3) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_AddressType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Enum_Breed]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_Breed](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_Breed] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_DogPlacementType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_DogPlacementType](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Enum_DogPlacementType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_DonationItemType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_DonationItemType](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_DonationItemType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_EmailType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enum_EmailType](
	[ID] [char](3) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_EmailType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Enum_EntityType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_EntityType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_EntityType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_EventAttendeeType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_EventAttendeeType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_EventAttendeeType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_EventDonationPurpose]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_EventDonationPurpose](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Enum_EventDonationPurpose] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_EventType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enum_EventType](
	[ID] [char](3) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_EventType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Enum_Gender]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enum_Gender](
	[ID] [char](3) NOT NULL,
	[Value] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Enum_Gender] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Enum_HuskyColor]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_HuskyColor](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_HuskyColor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_HuskySize]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_HuskySize](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_HuskySize] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_InitialActivity]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_InitialActivity](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_InitialActivity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_IntakeFrom]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_IntakeFrom](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_IntakeFrom] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_IntakeStatusType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_IntakeStatusType](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Enum_IntakeStatusType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_LogActivityEventType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_LogActivityEventType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](15) NULL,
 CONSTRAINT [PK_Enum_LogActivityEventType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_Misc]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_Misc](
	[ID] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Enum_Misc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_OrganisationRoles]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_OrganisationRoles](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Enum_OrganisationRoles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_OrganisationServices]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_OrganisationServices](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[Cost] [money] NULL,
 CONSTRAINT [PK_Enum_OrganisationServices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_OrganisationType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enum_OrganisationType](
	[ID] [char](3) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_BusinessType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Enum_PetDepositCoverage]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_PetDepositCoverage](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_PetDepositCoverage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_PhoneType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enum_PhoneType](
	[ID] [char](3) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_PhoneType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Enum_ResidenceOwnershipType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_ResidenceOwnershipType](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_ResidenceOwnershipType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_ResidenceType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_ResidenceType](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_ResidenceType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_Skills]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_Skills](
	[ID] [nvarchar](4) NOT NULL,
	[Value] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_StudentType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_StudentType](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_StudentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_SupplyPlacementType]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enum_SupplyPlacementType](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](100) NULL,
 CONSTRAINT [PK_Enum_SupplyPlacementType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enum_UsaStates]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enum_UsaStates](
	[ID] [char](2) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Enum_UsaStates_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Event_Attendee]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event_Attendee](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[EventRegistrationID] [uniqueidentifier] NOT NULL,
	[PersonID] [uniqueidentifier] NULL,
	[IsPrimaryContact] [bit] NULL,
	[AttendeeType] [int] NOT NULL,
 CONSTRAINT [PK_Event_Attendee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event_Registration]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event_Registration](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[EventID] [uniqueidentifier] NOT NULL,
	[DateSubmitted] [date] NOT NULL,
	[HasPaid] [bit] NULL,
	[PaymentMethod] [int] NULL,
	[Comments] [nvarchar](max) NULL,
	[AmountPaid] [money] NULL,
	[TicketsBought] [int] NULL,
 CONSTRAINT [PK_Event_Registration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event_Sponsor]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event_Sponsor](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[EventID] [uniqueidentifier] NOT NULL,
	[DateAdded] [date] NOT NULL,
	[IsSponsoring] [bit] NOT NULL,
	[SponsorshipLevel] [int] NULL,
	[IsDonating] [bit] NOT NULL,
	[DonationAmount] [money] NULL,
	[IsDonationRecieved] [bit] NOT NULL,
	[OrganisationID] [uniqueidentifier] NULL,
	[PersonID] [uniqueidentifier] NULL,
	[IsSingageComplete] [bit] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[HasLogoBeenReceived] [bit] NOT NULL,
	[WebsiteUrl] [nvarchar](200) NULL,
 CONSTRAINT [PK_Event_Sponsor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event_SponsorshipLevel]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event_SponsorshipLevel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SponsorID] [uniqueidentifier] NOT NULL,
	[SponsorshipLevelType] [int] NOT NULL,
 CONSTRAINT [PK_Event_SponsorshipLevels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event_SponsorshipLevelTypes]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event_SponsorshipLevelTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[SponsorAmount] [money] NULL,
 CONSTRAINT [PK_Event_SponsorshipLevelTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Events]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Events](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[OrganisationID] [uniqueidentifier] NULL,
	[DateOfEvent] [date] NULL,
	[IsActive] [bit] NOT NULL,
	[Type] [char](3) NOT NULL,
	[AmountSpent] [money] NULL,
	[AmountReceived] [money] NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Purpose] [nvarchar](max) NULL,
	[Results] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[IsAllDay] [bit] NULL,
	[IsTicketsSold] [bit] NULL,
	[TicketPrice] [money] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Log]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsVisible] [bit] NULL,
	[UpdatedByUserId] [uniqueidentifier] NULL,
	[UpdatedTimeStam] [datetime] NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Level] [nvarchar](5) NOT NULL,
	[Logger] [nvarchar](200) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[ExceptionType] [nvarchar](max) NULL,
	[Operation] [nvarchar](max) NULL,
	[ExceptionMessage] [nvarchar](max) NULL,
	[StackTrace] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LogUserActivity]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogUserActivity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[EventTypeID] [int] NOT NULL,
	[EntityTypeID] [int] NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_LogUserActivity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Memberships]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memberships](
	[UserId] [uniqueidentifier] NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowsStart] [datetime] NOT NULL,
	[Comment] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profiles](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [nvarchar](max) NOT NULL,
	[PropertyValueStrings] [nvarchar](max) NOT NULL,
	[PropertyValueBinary] [varbinary](max) NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[System_Config]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[System_Config](
	[CategoryName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_System_Config] PRIMARY KEY CLUSTERED 
(
	[CategoryName] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[System_ConfigCategory]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[System_ConfigCategory](
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_System_ConfigCategory] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[Event_RegistrationAttendees]    Script Date: 10/29/2013 10:03:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Event_RegistrationAttendees]
AS
SELECT 
	reg.DateSubmitted, 
	reg.PaymentMethod,
	evt.DateOfEvent,
	evt.IsActive as IsActiveEvent,
	misc.ID as EventType,
	evt.Name as EventName,
	reg.EventID as EventId,
	reg.ID as RegistrationId,
	evt.OrganisationID as OrganisationId,
	STUFF((SELECT '|' + person.FirstName + ';' + person.LastName + ':' + convert(nvarchar(50), person.ID)
			FROM Event_Attendee attendee
			LEFT JOIN Entity_Person person ON attendee.PersonID = person.ID
			WHERE reg.ID = attendee.EventRegistrationID
			FOR XML PATH('')),1,1,'') Attendees
FROM Event_Registration reg 
	LEFT JOIN [Events] evt ON evt.ID = reg.EventID
	LEFT JOIN [Enum_Misc] misc ON convert(nvarchar(50), evt.ID) = misc.Value


GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_UserName]    Script Date: 10/29/2013 10:03:46 PM ******/
CREATE NONCLUSTERED INDEX [IDX_UserName] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applicant] ADD  CONSTRAINT [DF_AdoptionApplications_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Applicant] ADD  CONSTRAINT [DF_Applicant_ApplicantType]  DEFAULT ('A') FOR [ApplicantType]
GO
ALTER TABLE [dbo].[Applicant] ADD  CONSTRAINT [DF__AdoptionA__IsCom__56E8E7AB]  DEFAULT ((0)) FOR [IsCompleted]
GO
ALTER TABLE [dbo].[Applicant] ADD  CONSTRAINT [DF__AdoptionA__IsDel__57DD0BE4]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ApplicantOwnedAnimals] ADD  CONSTRAINT [DF_ApplicantOwnedAnimals_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ApplicantVeterinarians] ADD  CONSTRAINT [DF_ApplicantVeterinarians_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Blog_Comments] ADD  CONSTRAINT [DF_Blog_Comments_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Blog_Post] ADD  CONSTRAINT [DF_Blog_Post_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_Addresses] ADD  CONSTRAINT [DF_Entity_Addresses_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_Base] ADD  CONSTRAINT [DF_Entity_Base_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_Dog] ADD  CONSTRAINT [DF_Entity_Dog_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_DogIntake] ADD  CONSTRAINT [DF_Entity_DogIntake_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_DogPlacement] ADD  CONSTRAINT [DF_Entity_DogPlacement_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_DonationItems] ADD  CONSTRAINT [DF_Event_DonationItems_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_File] ADD  CONSTRAINT [DF_Entity_File_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_Organisation] ADD  CONSTRAINT [DF_Entity_Organisation_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_Organisation] ADD  CONSTRAINT [DF_Entity_Business_ID]  DEFAULT (newid()) FOR [BaseID]
GO
ALTER TABLE [dbo].[Entity_Person] ADD  CONSTRAINT [DF_Entity_Person_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_Supplies] ADD  CONSTRAINT [DF_Entity_Supplies_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Entity_SupplyPlacement] ADD  CONSTRAINT [DF_Entity_SupplyPlacement_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Event_Attendee] ADD  CONSTRAINT [DF_Event_Attendee_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Event_Registration] ADD  CONSTRAINT [DF_Event_Registration_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Event_Sponsor] ADD  CONSTRAINT [DF_Event_Sponsor_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Event_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Applicant]  WITH CHECK ADD  CONSTRAINT [FK_AdoptionApplications_ApplicantVeterinarians] FOREIGN KEY([ApplicantVeterinariansID])
REFERENCES [dbo].[ApplicantVeterinarians] ([ID])
GO
ALTER TABLE [dbo].[Applicant] CHECK CONSTRAINT [FK_AdoptionApplications_ApplicantVeterinarians]
GO
ALTER TABLE [dbo].[Applicant]  WITH CHECK ADD  CONSTRAINT [FK_AdoptionApplications_Enum_PetDepositCoverage] FOREIGN KEY([ResidencePetDepositCoverageID])
REFERENCES [dbo].[Enum_PetDepositCoverage] ([ID])
GO
ALTER TABLE [dbo].[Applicant] CHECK CONSTRAINT [FK_AdoptionApplications_Enum_PetDepositCoverage]
GO
ALTER TABLE [dbo].[Applicant]  WITH CHECK ADD  CONSTRAINT [FK_AdoptionApplications_Enum_ResidenceOwnershipType] FOREIGN KEY([ResidenceOwnershipID])
REFERENCES [dbo].[Enum_ResidenceOwnershipType] ([ID])
GO
ALTER TABLE [dbo].[Applicant] CHECK CONSTRAINT [FK_AdoptionApplications_Enum_ResidenceOwnershipType]
GO
ALTER TABLE [dbo].[Applicant]  WITH CHECK ADD  CONSTRAINT [FK_AdoptionApplications_Enum_ResidenceType] FOREIGN KEY([ResidenceTypeID])
REFERENCES [dbo].[Enum_ResidenceType] ([ID])
GO
ALTER TABLE [dbo].[Applicant] CHECK CONSTRAINT [FK_AdoptionApplications_Enum_ResidenceType]
GO
ALTER TABLE [dbo].[Applicant]  WITH CHECK ADD  CONSTRAINT [FK_AdoptionApplications_Enum_StudentType] FOREIGN KEY([StudentTypeID])
REFERENCES [dbo].[Enum_StudentType] ([ID])
GO
ALTER TABLE [dbo].[Applicant] CHECK CONSTRAINT [FK_AdoptionApplications_Enum_StudentType]
GO
ALTER TABLE [dbo].[Applicant]  WITH CHECK ADD  CONSTRAINT [FK_EntityPersonID__AdoptionApplications_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Entity_Person] ([ID])
GO
ALTER TABLE [dbo].[Applicant] CHECK CONSTRAINT [FK_EntityPersonID__AdoptionApplications_PersonID]
GO
ALTER TABLE [dbo].[ApplicantOwnedAnimals]  WITH CHECK ADD  CONSTRAINT [FK_ApplicantOwnedAnimals_AdoptionApplications] FOREIGN KEY([ApplicantID], [PersonID])
REFERENCES [dbo].[Applicant] ([ID], [PersonID])
GO
ALTER TABLE [dbo].[ApplicantOwnedAnimals] CHECK CONSTRAINT [FK_ApplicantOwnedAnimals_AdoptionApplications]
GO
ALTER TABLE [dbo].[ApplicantOwnedAnimals]  WITH CHECK ADD  CONSTRAINT [FK_EntityPerson_ID__ApplicantOwnedAnimals_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Entity_Person] ([ID])
GO
ALTER TABLE [dbo].[ApplicantOwnedAnimals] CHECK CONSTRAINT [FK_EntityPerson_ID__ApplicantOwnedAnimals_PersonID]
GO
ALTER TABLE [dbo].[Blog_Comments]  WITH CHECK ADD  CONSTRAINT [FK_BlogComments_ID__BlogComments_ParentComentID] FOREIGN KEY([ParentCommentID])
REFERENCES [dbo].[Blog_Comments] ([ID])
GO
ALTER TABLE [dbo].[Blog_Comments] CHECK CONSTRAINT [FK_BlogComments_ID__BlogComments_ParentComentID]
GO
ALTER TABLE [dbo].[Blog_Comments]  WITH CHECK ADD  CONSTRAINT [FK_BlogPost_ID__BlogComments_PostID] FOREIGN KEY([PostID])
REFERENCES [dbo].[Blog_Post] ([ID])
GO
ALTER TABLE [dbo].[Blog_Comments] CHECK CONSTRAINT [FK_BlogPost_ID__BlogComments_PostID]
GO
ALTER TABLE [dbo].[Blog_TagsMapped]  WITH CHECK ADD  CONSTRAINT [FK_BlogPost_ID__BlogTagsMapped_PostID] FOREIGN KEY([PostID])
REFERENCES [dbo].[Blog_Post] ([ID])
GO
ALTER TABLE [dbo].[Blog_TagsMapped] CHECK CONSTRAINT [FK_BlogPost_ID__BlogTagsMapped_PostID]
GO
ALTER TABLE [dbo].[Blog_TagsMapped]  WITH CHECK ADD  CONSTRAINT [FK_BlogTags_ID__BlogTagsMapped_TagID] FOREIGN KEY([TagID])
REFERENCES [dbo].[Blog_Tags] ([ID])
GO
ALTER TABLE [dbo].[Blog_TagsMapped] CHECK CONSTRAINT [FK_BlogTags_ID__BlogTagsMapped_TagID]
GO
ALTER TABLE [dbo].[Entity_Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Entity_Addresses_Entity_Base] FOREIGN KEY([EntityID])
REFERENCES [dbo].[Entity_Base] ([ID])
GO
ALTER TABLE [dbo].[Entity_Addresses] CHECK CONSTRAINT [FK_Entity_Addresses_Entity_Base]
GO
ALTER TABLE [dbo].[Entity_Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Entity_Addresses_Enum_UsaStates] FOREIGN KEY([StateID])
REFERENCES [dbo].[Enum_UsaStates] ([ID])
GO
ALTER TABLE [dbo].[Entity_Addresses] CHECK CONSTRAINT [FK_Entity_Addresses_Enum_UsaStates]
GO
ALTER TABLE [dbo].[Entity_Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Enum_AddressType_Entity_Addresses] FOREIGN KEY([Type])
REFERENCES [dbo].[Enum_AddressType] ([ID])
GO
ALTER TABLE [dbo].[Entity_Addresses] CHECK CONSTRAINT [FK_Enum_AddressType_Entity_Addresses]
GO
ALTER TABLE [dbo].[Entity_Dog]  WITH CHECK ADD  CONSTRAINT [FK_EntityDogIntake_ID__EntityDog_IntakeID] FOREIGN KEY([IntakeID])
REFERENCES [dbo].[Entity_DogIntake] ([ID])
GO
ALTER TABLE [dbo].[Entity_Dog] CHECK CONSTRAINT [FK_EntityDogIntake_ID__EntityDog_IntakeID]
GO
ALTER TABLE [dbo].[Entity_Dog]  WITH CHECK ADD  CONSTRAINT [FK_EntityOrganisation_ID__EntityDog_MicrochipVendorID] FOREIGN KEY([MicrochipVendorID])
REFERENCES [dbo].[Entity_Organisation] ([ID])
GO
ALTER TABLE [dbo].[Entity_Dog] CHECK CONSTRAINT [FK_EntityOrganisation_ID__EntityDog_MicrochipVendorID]
GO
ALTER TABLE [dbo].[Entity_Dog]  WITH CHECK ADD  CONSTRAINT [FK_EntityOrganisation_ID__EntityDog_ShelterID] FOREIGN KEY([ShelterID])
REFERENCES [dbo].[Entity_Organisation] ([ID])
GO
ALTER TABLE [dbo].[Entity_Dog] CHECK CONSTRAINT [FK_EntityOrganisation_ID__EntityDog_ShelterID]
GO
ALTER TABLE [dbo].[Entity_Dog]  WITH CHECK ADD  CONSTRAINT [FK_EnumBreed_ID__EntityDog_BreedID] FOREIGN KEY([BreedID])
REFERENCES [dbo].[Enum_Breed] ([ID])
GO
ALTER TABLE [dbo].[Entity_Dog] CHECK CONSTRAINT [FK_EnumBreed_ID__EntityDog_BreedID]
GO
ALTER TABLE [dbo].[Entity_Dog]  WITH CHECK ADD  CONSTRAINT [FK_EnumBreed_ID__EntityDog_BreedSecondID] FOREIGN KEY([BreedSecondID])
REFERENCES [dbo].[Enum_Breed] ([ID])
GO
ALTER TABLE [dbo].[Entity_Dog] CHECK CONSTRAINT [FK_EnumBreed_ID__EntityDog_BreedSecondID]
GO
ALTER TABLE [dbo].[Entity_Dog]  WITH CHECK ADD  CONSTRAINT [FK_EnumHuskyColor_ID__EntityDog_ColorID] FOREIGN KEY([ColorID])
REFERENCES [dbo].[Enum_HuskyColor] ([ID])
GO
ALTER TABLE [dbo].[Entity_Dog] CHECK CONSTRAINT [FK_EnumHuskyColor_ID__EntityDog_ColorID]
GO
ALTER TABLE [dbo].[Entity_Dog]  WITH CHECK ADD  CONSTRAINT [FK_EnumHuskySize_ID__EntityDog_SizeID] FOREIGN KEY([SizeID])
REFERENCES [dbo].[Enum_HuskySize] ([ID])
GO
ALTER TABLE [dbo].[Entity_Dog] CHECK CONSTRAINT [FK_EnumHuskySize_ID__EntityDog_SizeID]
GO
ALTER TABLE [dbo].[Entity_Dog]  WITH CHECK ADD  CONSTRAINT [FK_EnumInitialActivity_ID__EntityDog_InitialActivityID] FOREIGN KEY([InitialActivityID])
REFERENCES [dbo].[Enum_InitialActivity] ([ID])
GO
ALTER TABLE [dbo].[Entity_Dog] CHECK CONSTRAINT [FK_EnumInitialActivity_ID__EntityDog_InitialActivityID]
GO
ALTER TABLE [dbo].[Entity_Dog]  WITH CHECK ADD  CONSTRAINT [FK_EnumIntakeFrom_ID__EntityDog_IntakeFromID] FOREIGN KEY([IntakeFromID])
REFERENCES [dbo].[Enum_IntakeFrom] ([ID])
GO
ALTER TABLE [dbo].[Entity_Dog] CHECK CONSTRAINT [FK_EnumIntakeFrom_ID__EntityDog_IntakeFromID]
GO
ALTER TABLE [dbo].[Entity_DogIntake]  WITH CHECK ADD  CONSTRAINT [FK_EnumIntakeStatusType_ID__EntityDogIntake_IntakeStatus] FOREIGN KEY([IntakeStatus])
REFERENCES [dbo].[Enum_IntakeStatusType] ([ID])
GO
ALTER TABLE [dbo].[Entity_DogIntake] CHECK CONSTRAINT [FK_EnumIntakeStatusType_ID__EntityDogIntake_IntakeStatus]
GO
ALTER TABLE [dbo].[Entity_DogPlacement]  WITH CHECK ADD  CONSTRAINT [FK_EntityBase_ID__EntityDogPlacement_LocationID] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Entity_Base] ([ID])
GO
ALTER TABLE [dbo].[Entity_DogPlacement] CHECK CONSTRAINT [FK_EntityBase_ID__EntityDogPlacement_LocationID]
GO
ALTER TABLE [dbo].[Entity_DogPlacement]  WITH CHECK ADD  CONSTRAINT [FK_EntityDog_ID__EntityDogPlacement_DogID] FOREIGN KEY([DogID])
REFERENCES [dbo].[Entity_Dog] ([ID])
GO
ALTER TABLE [dbo].[Entity_DogPlacement] CHECK CONSTRAINT [FK_EntityDog_ID__EntityDogPlacement_DogID]
GO
ALTER TABLE [dbo].[Entity_DogPlacement]  WITH CHECK ADD  CONSTRAINT [FK_EnumDogPlacementType_ID__EntityDogPlacement_Status] FOREIGN KEY([Status])
REFERENCES [dbo].[Enum_DogPlacementType] ([ID])
GO
ALTER TABLE [dbo].[Entity_DogPlacement] CHECK CONSTRAINT [FK_EnumDogPlacementType_ID__EntityDogPlacement_Status]
GO
ALTER TABLE [dbo].[Entity_DonationItems]  WITH CHECK ADD  CONSTRAINT [FK_EnumDonationItemType_ID___EventDonationItems_DonationItemType] FOREIGN KEY([DonationItemType])
REFERENCES [dbo].[Enum_DonationItemType] ([ID])
GO
ALTER TABLE [dbo].[Entity_DonationItems] CHECK CONSTRAINT [FK_EnumDonationItemType_ID___EventDonationItems_DonationItemType]
GO
ALTER TABLE [dbo].[Entity_DonationItems]  WITH CHECK ADD  CONSTRAINT [FK_EnumEventDonationPurpose_ID__EntityDonationItems_EventPurposeID] FOREIGN KEY([EventPurposeID])
REFERENCES [dbo].[Enum_EventDonationPurpose] ([ID])
GO
ALTER TABLE [dbo].[Entity_DonationItems] CHECK CONSTRAINT [FK_EnumEventDonationPurpose_ID__EntityDonationItems_EventPurposeID]
GO
ALTER TABLE [dbo].[Entity_DonationItems]  WITH CHECK ADD  CONSTRAINT [FK_EventDonationItems_OrganisationID__EntityOrganisation_ID] FOREIGN KEY([OrganisationID])
REFERENCES [dbo].[Entity_Organisation] ([ID])
GO
ALTER TABLE [dbo].[Entity_DonationItems] CHECK CONSTRAINT [FK_EventDonationItems_OrganisationID__EntityOrganisation_ID]
GO
ALTER TABLE [dbo].[Entity_DonationItems]  WITH CHECK ADD  CONSTRAINT [FK_EventDonationItems_PersonID__EntityPerson_ID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Entity_Person] ([ID])
GO
ALTER TABLE [dbo].[Entity_DonationItems] CHECK CONSTRAINT [FK_EventDonationItems_PersonID__EntityPerson_ID]
GO
ALTER TABLE [dbo].[Entity_DonationItems]  WITH CHECK ADD  CONSTRAINT [FK_Events_ID___EntityDonationItems_EventID] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([ID])
GO
ALTER TABLE [dbo].[Entity_DonationItems] CHECK CONSTRAINT [FK_Events_ID___EntityDonationItems_EventID]
GO
ALTER TABLE [dbo].[Entity_EmailAddress]  WITH CHECK ADD  CONSTRAINT [Email_Entity] FOREIGN KEY([EntityID])
REFERENCES [dbo].[Entity_Base] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Entity_EmailAddress] CHECK CONSTRAINT [Email_Entity]
GO
ALTER TABLE [dbo].[Entity_EmailAddress]  WITH CHECK ADD  CONSTRAINT [FK_Entity_EmailAddress_Enum_EmailType] FOREIGN KEY([Type])
REFERENCES [dbo].[Enum_EmailType] ([ID])
GO
ALTER TABLE [dbo].[Entity_EmailAddress] CHECK CONSTRAINT [FK_Entity_EmailAddress_Enum_EmailType]
GO
ALTER TABLE [dbo].[Entity_File]  WITH CHECK ADD  CONSTRAINT [FK_EntityDog_ID__EntityFile_DogID] FOREIGN KEY([DogID])
REFERENCES [dbo].[Entity_Dog] ([ID])
GO
ALTER TABLE [dbo].[Entity_File] CHECK CONSTRAINT [FK_EntityDog_ID__EntityFile_DogID]
GO
ALTER TABLE [dbo].[Entity_File]  WITH CHECK ADD  CONSTRAINT [FK_EntityOrganisation_ID_EntityFile_OrgID] FOREIGN KEY([OrgID])
REFERENCES [dbo].[Entity_Organisation] ([ID])
GO
ALTER TABLE [dbo].[Entity_File] CHECK CONSTRAINT [FK_EntityOrganisation_ID_EntityFile_OrgID]
GO
ALTER TABLE [dbo].[Entity_File]  WITH CHECK ADD  CONSTRAINT [FK_EntityPerson_ID__EntityFile_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Entity_Person] ([ID])
GO
ALTER TABLE [dbo].[Entity_File] CHECK CONSTRAINT [FK_EntityPerson_ID__EntityFile_PersonID]
GO
ALTER TABLE [dbo].[Entity_Organisation]  WITH CHECK ADD  CONSTRAINT [FK_Entity_Business_Entity_Base] FOREIGN KEY([BaseID])
REFERENCES [dbo].[Entity_Base] ([ID])
GO
ALTER TABLE [dbo].[Entity_Organisation] CHECK CONSTRAINT [FK_Entity_Business_Entity_Base]
GO
ALTER TABLE [dbo].[Entity_Organisation]  WITH CHECK ADD  CONSTRAINT [FK_Entity_Business_Enum_BusinessType] FOREIGN KEY([Type])
REFERENCES [dbo].[Enum_OrganisationType] ([ID])
GO
ALTER TABLE [dbo].[Entity_Organisation] CHECK CONSTRAINT [FK_Entity_Business_Enum_BusinessType]
GO
ALTER TABLE [dbo].[Entity_OrganisationContacts]  WITH CHECK ADD  CONSTRAINT [FK_EntityOrganisation_id___EntityOrganisationContacts_orgID] FOREIGN KEY([OrganisationID])
REFERENCES [dbo].[Entity_Organisation] ([ID])
GO
ALTER TABLE [dbo].[Entity_OrganisationContacts] CHECK CONSTRAINT [FK_EntityOrganisation_id___EntityOrganisationContacts_orgID]
GO
ALTER TABLE [dbo].[Entity_OrganisationContacts]  WITH CHECK ADD  CONSTRAINT [FK_EntityPerson_ID__EntityOrganisationContacts_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Entity_Person] ([ID])
GO
ALTER TABLE [dbo].[Entity_OrganisationContacts] CHECK CONSTRAINT [FK_EntityPerson_ID__EntityOrganisationContacts_PersonID]
GO
ALTER TABLE [dbo].[Entity_OrganisationContacts]  WITH CHECK ADD  CONSTRAINT [FK_EnumOrganisationRoles_id___EntityOrganisationContacts_roleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Enum_OrganisationRoles] ([ID])
GO
ALTER TABLE [dbo].[Entity_OrganisationContacts] CHECK CONSTRAINT [FK_EnumOrganisationRoles_id___EntityOrganisationContacts_roleID]
GO
ALTER TABLE [dbo].[Entity_OrganisationServices]  WITH CHECK ADD  CONSTRAINT [FK_EntityOrganisation_id___EntityOrganisationServices_orgID] FOREIGN KEY([OrganisationID])
REFERENCES [dbo].[Entity_Organisation] ([ID])
GO
ALTER TABLE [dbo].[Entity_OrganisationServices] CHECK CONSTRAINT [FK_EntityOrganisation_id___EntityOrganisationServices_orgID]
GO
ALTER TABLE [dbo].[Entity_OrganisationServices]  WITH CHECK ADD  CONSTRAINT [FK_EnumOrganisationServices_id___EntityOrganisationServices_serviceID] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Enum_OrganisationServices] ([ID])
GO
ALTER TABLE [dbo].[Entity_OrganisationServices] CHECK CONSTRAINT [FK_EnumOrganisationServices_id___EntityOrganisationServices_serviceID]
GO
ALTER TABLE [dbo].[Entity_Person]  WITH CHECK ADD  CONSTRAINT [FK_Entity_Person_Entity_Base] FOREIGN KEY([BaseID])
REFERENCES [dbo].[Entity_Base] ([ID])
GO
ALTER TABLE [dbo].[Entity_Person] CHECK CONSTRAINT [FK_Entity_Person_Entity_Base]
GO
ALTER TABLE [dbo].[Entity_Person]  WITH CHECK ADD  CONSTRAINT [FK_Entity_Person_Enum_Gender] FOREIGN KEY([Gender])
REFERENCES [dbo].[Enum_Gender] ([ID])
GO
ALTER TABLE [dbo].[Entity_Person] CHECK CONSTRAINT [FK_Entity_Person_Enum_Gender]
GO
ALTER TABLE [dbo].[Entity_PersonProfile]  WITH CHECK ADD  CONSTRAINT [FK_EntityPerson_ID__EntityPersonProfile_EntityPersonID] FOREIGN KEY([EntityPersonID])
REFERENCES [dbo].[Entity_Person] ([ID])
GO
ALTER TABLE [dbo].[Entity_PersonProfile] CHECK CONSTRAINT [FK_EntityPerson_ID__EntityPersonProfile_EntityPersonID]
GO
ALTER TABLE [dbo].[Entity_PersonSkills]  WITH CHECK ADD  CONSTRAINT [FK_EntityPerson_ID__EntityPersonSkills_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Entity_Person] ([ID])
GO
ALTER TABLE [dbo].[Entity_PersonSkills] CHECK CONSTRAINT [FK_EntityPerson_ID__EntityPersonSkills_PersonID]
GO
ALTER TABLE [dbo].[Entity_PersonSkills]  WITH CHECK ADD  CONSTRAINT [FK_EnumSkills_id___EntityPersonSkills_skillCode] FOREIGN KEY([SkillCode])
REFERENCES [dbo].[Enum_Skills] ([ID])
GO
ALTER TABLE [dbo].[Entity_PersonSkills] CHECK CONSTRAINT [FK_EnumSkills_id___EntityPersonSkills_skillCode]
GO
ALTER TABLE [dbo].[Entity_PhoneNumber]  WITH CHECK ADD  CONSTRAINT [Entity_PhoneNumbers] FOREIGN KEY([EntityID])
REFERENCES [dbo].[Entity_Base] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Entity_PhoneNumber] CHECK CONSTRAINT [Entity_PhoneNumbers]
GO
ALTER TABLE [dbo].[Entity_PhoneNumber]  WITH CHECK ADD  CONSTRAINT [FK_Entity_PhoneNumber_Enum_PhoneType] FOREIGN KEY([Type])
REFERENCES [dbo].[Enum_PhoneType] ([ID])
GO
ALTER TABLE [dbo].[Entity_PhoneNumber] CHECK CONSTRAINT [FK_Entity_PhoneNumber_Enum_PhoneType]
GO
ALTER TABLE [dbo].[Entity_Supplies]  WITH CHECK ADD  CONSTRAINT [FK_EntitySupplyType_ID__EntitySupplies_SupplyType] FOREIGN KEY([SupplyType])
REFERENCES [dbo].[Entity_SupplyType] ([ID])
GO
ALTER TABLE [dbo].[Entity_Supplies] CHECK CONSTRAINT [FK_EntitySupplyType_ID__EntitySupplies_SupplyType]
GO
ALTER TABLE [dbo].[Entity_SupplyPlacement]  WITH CHECK ADD  CONSTRAINT [FK_EntityBase_ID__EntitySupplyPlacement_LocationID] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Entity_Base] ([ID])
GO
ALTER TABLE [dbo].[Entity_SupplyPlacement] CHECK CONSTRAINT [FK_EntityBase_ID__EntitySupplyPlacement_LocationID]
GO
ALTER TABLE [dbo].[Entity_SupplyPlacement]  WITH CHECK ADD  CONSTRAINT [FK_EntitySupplies_ID__EntitySupplyPlacement_SupplyID] FOREIGN KEY([SupplyID])
REFERENCES [dbo].[Entity_Supplies] ([ID])
GO
ALTER TABLE [dbo].[Entity_SupplyPlacement] CHECK CONSTRAINT [FK_EntitySupplies_ID__EntitySupplyPlacement_SupplyID]
GO
ALTER TABLE [dbo].[Entity_SupplyPlacement]  WITH CHECK ADD  CONSTRAINT [FK_EnumSupplyPlacementType_ID__EntitySupplyPlacement_Status] FOREIGN KEY([Status])
REFERENCES [dbo].[Enum_SupplyPlacementType] ([ID])
GO
ALTER TABLE [dbo].[Entity_SupplyPlacement] CHECK CONSTRAINT [FK_EnumSupplyPlacementType_ID__EntitySupplyPlacement_Status]
GO
ALTER TABLE [dbo].[Event_Attendee]  WITH CHECK ADD  CONSTRAINT [FK_EntityPerson_ID__EventAttendee_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Entity_Person] ([ID])
GO
ALTER TABLE [dbo].[Event_Attendee] CHECK CONSTRAINT [FK_EntityPerson_ID__EventAttendee_PersonID]
GO
ALTER TABLE [dbo].[Event_Attendee]  WITH CHECK ADD  CONSTRAINT [FK_EnumEventAttendeeType_id___EventAttendee_attendeeType] FOREIGN KEY([AttendeeType])
REFERENCES [dbo].[Enum_EventAttendeeType] ([ID])
GO
ALTER TABLE [dbo].[Event_Attendee] CHECK CONSTRAINT [FK_EnumEventAttendeeType_id___EventAttendee_attendeeType]
GO
ALTER TABLE [dbo].[Event_Attendee]  WITH CHECK ADD  CONSTRAINT [FK_EventRegistration_id___EventAttendee_eventRegistrationID] FOREIGN KEY([EventRegistrationID])
REFERENCES [dbo].[Event_Registration] ([ID])
GO
ALTER TABLE [dbo].[Event_Attendee] CHECK CONSTRAINT [FK_EventRegistration_id___EventAttendee_eventRegistrationID]
GO
ALTER TABLE [dbo].[Event_Registration]  WITH CHECK ADD  CONSTRAINT [FK_Events_id___EventRegistration_eventID] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([ID])
GO
ALTER TABLE [dbo].[Event_Registration] CHECK CONSTRAINT [FK_Events_id___EventRegistration_eventID]
GO
ALTER TABLE [dbo].[Event_Sponsor]  WITH CHECK ADD  CONSTRAINT [FK_EntityOrganisation_ID___EventSponsor_OrganisationID] FOREIGN KEY([OrganisationID])
REFERENCES [dbo].[Entity_Organisation] ([ID])
GO
ALTER TABLE [dbo].[Event_Sponsor] CHECK CONSTRAINT [FK_EntityOrganisation_ID___EventSponsor_OrganisationID]
GO
ALTER TABLE [dbo].[Event_Sponsor]  WITH CHECK ADD  CONSTRAINT [FK_EntityPerson_ID__EventSponsor_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Entity_Person] ([ID])
GO
ALTER TABLE [dbo].[Event_Sponsor] CHECK CONSTRAINT [FK_EntityPerson_ID__EventSponsor_PersonID]
GO
ALTER TABLE [dbo].[Event_Sponsor]  WITH CHECK ADD  CONSTRAINT [FK_Events_ID___EventSponsor_EventID] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([ID])
GO
ALTER TABLE [dbo].[Event_Sponsor] CHECK CONSTRAINT [FK_Events_ID___EventSponsor_EventID]
GO
ALTER TABLE [dbo].[Event_SponsorshipLevel]  WITH CHECK ADD  CONSTRAINT [FK_EventSponsor_ID__EventSponsorshipLevel_SponsorID] FOREIGN KEY([SponsorID])
REFERENCES [dbo].[Event_Sponsor] ([ID])
GO
ALTER TABLE [dbo].[Event_SponsorshipLevel] CHECK CONSTRAINT [FK_EventSponsor_ID__EventSponsorshipLevel_SponsorID]
GO
ALTER TABLE [dbo].[Event_SponsorshipLevel]  WITH CHECK ADD  CONSTRAINT [FK_EventSponsorshipLevelTypes_ID__EventSponsorshipLevel_SponsorshipLevelType] FOREIGN KEY([SponsorshipLevelType])
REFERENCES [dbo].[Event_SponsorshipLevelTypes] ([ID])
GO
ALTER TABLE [dbo].[Event_SponsorshipLevel] CHECK CONSTRAINT [FK_EventSponsorshipLevelTypes_ID__EventSponsorshipLevel_SponsorshipLevelType]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_EntityOrg_id___Events_orgID] FOREIGN KEY([OrganisationID])
REFERENCES [dbo].[Entity_Organisation] ([ID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_EntityOrg_id___Events_orgID]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Event_type___EnumEventType_id] FOREIGN KEY([Type])
REFERENCES [dbo].[Enum_EventType] ([ID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Event_type___EnumEventType_id]
GO
ALTER TABLE [dbo].[LogUserActivity]  WITH CHECK ADD  CONSTRAINT [FK_EnumEntityType_ID__LogUserActivity_EntityTypeID] FOREIGN KEY([EntityTypeID])
REFERENCES [dbo].[Enum_EntityType] ([ID])
GO
ALTER TABLE [dbo].[LogUserActivity] CHECK CONSTRAINT [FK_EnumEntityType_ID__LogUserActivity_EntityTypeID]
GO
ALTER TABLE [dbo].[LogUserActivity]  WITH CHECK ADD  CONSTRAINT [FK_EnumLogActivityEventType_ID__LogUserActivity_EventTypeID] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[Enum_LogActivityEventType] ([ID])
GO
ALTER TABLE [dbo].[LogUserActivity] CHECK CONSTRAINT [FK_EnumLogActivityEventType_ID__LogUserActivity_EventTypeID]
GO
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipEntity_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipEntity_Application]
GO
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipEntity_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipEntity_User]
GO
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [ProfileEntity_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [ProfileEntity_User]
GO
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [RoleEntity_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [RoleEntity_Application]
GO
ALTER TABLE [dbo].[System_Config]  WITH CHECK ADD  CONSTRAINT [FK_ConfigCategory_Id___SystemConfigSystem_CategoryId] FOREIGN KEY([CategoryName])
REFERENCES [dbo].[System_ConfigCategory] ([Name])
GO
ALTER TABLE [dbo].[System_Config] CHECK CONSTRAINT [FK_ConfigCategory_Id___SystemConfigSystem_CategoryId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [User_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [User_Application]
GO
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRole_Role]
GO
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRole_User]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'image/jpeg, application/msword, etc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Entity_File', @level2type=N'COLUMN',@level2name=N'ContentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[6] 4[12] 2[63] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2[40] 3) )"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 5
   End
   Begin DiagramPane = 
      PaneHidden = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Event_RegistrationAttendees'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Event_RegistrationAttendees'
GO
ALTER DATABASE [HuskyRescue] SET  READ_WRITE 
GO
