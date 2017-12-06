CREATE TABLE [dbo].[ApplicantOwnedAnimals] (
    [ID]                    UNIQUEIDENTIFIER CONSTRAINT [DF_ApplicantOwnedAnimals_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [ApplicantID]           UNIQUEIDENTIFIER NOT NULL,
    [PersonID]              UNIQUEIDENTIFIER NOT NULL,
    [Name]                  NVARCHAR (50)    NOT NULL,
    [Breed]                 NVARCHAR (20)    NOT NULL,
    [Gender]                NVARCHAR (10)    NOT NULL,
    [AgeMonths]             NVARCHAR (100)   NULL,
    [OwnershipLengthMonths] NVARCHAR (100)   NULL,
    [IsAltered]             BIT              NOT NULL,
    [AlteredReason]         NVARCHAR (200)   NULL,
    [IsHwPrevention]        BIT              NOT NULL,
    [HwPreventionReason]    NVARCHAR (200)   NULL,
    [IsFullyVaccinated]     BIT              NOT NULL,
    [FullyVaccinatedReason] NVARCHAR (200)   NULL,
    [IsStillOwned]          BIT              NOT NULL,
    [IsStillOwnedReason]    NVARCHAR (200)   NULL,
    CONSTRAINT [PK_ApplicantOwnedAnimals] PRIMARY KEY CLUSTERED ([ID] ASC, [ApplicantID] ASC, [PersonID] ASC),
    CONSTRAINT [FK_ApplicantOwnedAnimals_AdoptionApplications] FOREIGN KEY ([ApplicantID], [PersonID]) REFERENCES [dbo].[Applicant] ([ID], [PersonID]),
    CONSTRAINT [FK_EntityPerson_ID__ApplicantOwnedAnimals_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Entity_Person] ([ID])
);



