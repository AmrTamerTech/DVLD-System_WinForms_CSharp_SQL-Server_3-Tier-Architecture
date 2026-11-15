
CREATE DATABASE DVLD;
GO

USE DVLD;
GO

/*===========================================
					Countries
===========================================*/
Create Table Countries (
CountryID int primary Key identity(1,1),
CountryName nvarchar(50) Unique not null
)

/*===========================================
					People
===========================================*/
Create Table People(
PersonID int primary key identity(1,1),
FirstName nvarchar(50) not null,
SecondName nvarchar(50) not null,
ThirdName nvarchar(50) not null,
LastName nvarchar(50) not null,
NationalNo nvarchar(20) not null unique,
DateOfBirth Date not null,
Gender tinyint not null,
Phone nvarchar(20) not null,
Email nvarchar(20) not null,
NationalityCountryID int not null,
Address nvarchar(250) not null,
ImagePath nvarchar(250) not null,

Constraint FK_People_Countries
	Foreign key (NationalityCountryID)
	References Countries(CountryID),

Constraint FK_People_Gender
	check (Gender IN (0,1))
)

/*===========================================
					Users
===========================================*/
Create Table Users
(
UserID int primary key identity(1,1),
UserName nvarchar(50) not null unique,
Password nvarchar(255) not null,
IsActive bit not null Default 1,
PersonID int not null,

Constraint FK_Users_People
	Foreign key (PersonID)
	References People(PersonID)
)

/*===========================================
				ApplicationTypes
===========================================*/
Create Table ApplicationTypes
(
ApplicationTypeID int primary key identity(1,1),
ApplicationTypeTitle nvarchar(100) not null unique,
ApplicationFees decimal(10, 2) not null unique,

Constraint CK_ApplicationTypes_Fees
	check (ApplicationFees >= 0)
)

/*===========================================
				Applications
===========================================*/
Create Table Applications
(
ApplicationID int primary key identity(1,1),
ApplicationDate date not null,
PaidFees decimal(10,2) not null,
ApplicationStatus tinyint not null,
LastStatusDate DateTime not null Default GetDate(),
ApplicantPersonID int not null,
CreatedByUserID int not null,
ApplicationTypeID int not null,

Constraint FK_Applications_People
	FOREIGN KEY (ApplicantPersonID)
	References People(PersonID),

Constraint FK_Applications_CreatedUsers
	FOREIGN KEY (CreatedByUserID)
	References Users(UserID),

Constraint FK_Applications_ApplicationTypes
	FOREIGN KEY (ApplicationTypeID)
	References ApplicationTypes(ApplicationTypeID),

Constraint CK_Applications_PaidFees
	check (PaidFees >= 0),

Constraint CK_Applications_ApplicationStatus
	check (ApplicationStatus in (1,2,3))
	
)

/*===========================================
				LicenseClasses
===========================================*/
create table LicenseClasses
(
LicenseClassID int primary key identity(1,1),
ClassName nvarchar(100) not null,
ClassDescription nvarchar(500) not null,
ClassFees Decimal(10, 2) not null,
DefaultValidityLength int not null,
MinimumAllowedAge int not null,

Constraint CK_LicenseClasses_Fees
	check (ClassFees >= 0),

Constraint CK_LicenseClasses_DefaultValidityLength
	check (DefaultValidityLength > 0),

Constraint CK_LicenseClasses_MinimumAllowedAge
	check (MinimumAllowedAge >= 18)
)

/*===========================================
		LocalDrivingLicenseApplications
===========================================*/
Create Table LocalDrivingLicenseApplications
(
LocalDrivingLicenseApplicationID int primary key identity(1,1),
ApplicationID int not null,
LicenseClassID int not null,

Constraint FK_LocalDrivingLicenseApplications_Application
	Foreign key (ApplicationID)
	References Applications(ApplicationID),

Constraint FK_LocalDrivingLicenseApplications_LicenseClasses
	Foreign key (LicenseClassID)
	References LicenseClasses(LicenseClassID)

)

/*===========================================
				  TestTypes
===========================================*/
Create Table TestTypes
(
TestTypeID int primary key identity(1,1),
TestTypeTitle nvarchar(100) not null,
TypeTypeDescription nvarchar(500) not null,
TestTypeFees decimal(10, 2) not null,
Constraint CK_TestTypes_Fees
	check (TestTypeFees >= 0)
)

/*===========================================
			  TestAppointments
===========================================*/
Create Table TestAppointments
(
TestAppointmentID int primary key identity(1,1),
PaidFees decimal(10,2) not null,
AppointmentDate datetime not null,
IsLocked bit not null,
TestTypeID int not null,
CreatedByUserID int not null,
RetakeTestApplicationID int null,
LocalDrivingLicenseApplicationID int not null,
Constraint FK_TestAppointments_TestTypes
	Foreign key (TestTypeID)
	References TestTypes(TestTypeID),
Constraint FK_TestAppointments_CreatedUsers
	Foreign key (CreatedByUserID)
	References Users(UserID),
Constraint FK_TestAppointments_RetakeTestApplication
	Foreign key (RetakeTestApplicationID)
	References Applications(ApplicationID),
Constraint FK_TestAppointments_LocalDrivingLicenseApplication
	Foreign key (LocalDrivingLicenseApplicationID)
	References LocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID),
Constraint CK_TestAppointments_PaidFees
	Check (PaidFees >= 0)
)

/*===========================================
					Tests
===========================================*/
Create Table Tests
(
TestID int primary key identity(1,1),
TestResult bit not null,
Notes nvarchar(500) not null,
CreatedByUserID int not null,
TestAppointmentID int not null,
CONSTRAINT FK_Tests_CreatedUsers
	Foreign key (CreatedByUserID)
	References Users(UserID),
CONSTRAINT FK_Tests_TestAppointments
	Foreign key (TestAppointmentID)
	References TestAppointments(TestAppointmentID)
)

/*===========================================
					Drivers
===========================================*/
Create Table Drivers
(
DriverID int primary key identity(1,1),
CreatedDate Datetime not null Default GetDate(),
PersonID int not null unique,
CreatedByUserID int not null,
Constraint FK_Drivers_People
	Foreign key (PersonID)
	References People(PersonID),
Constraint FK_Drivers_CreatedUsers
	Foreign key (CreatedByUserID)
	References Users(UserID),
)

/*===========================================
					Licenses
===========================================*/
Create Table Licenses
(
LicenseID int primary key identity(1,1),
ApplicationID int not null,
CreatedByUserID int not null,
LicenseClassID int not null,
DriverID int not null,
IssueDate Date not null,
IssueReason Tinyint not null,
Notes nvarchar(500) not null,
IsActive bit not null default 1,
ExpirationDate date not null,
PaidFees decimal(10,2) not null,
Constraint FK_Licenses_Applications
	Foreign key (ApplicationID)
	References Applications(ApplicationID),
Constraint FK_Licenses_Users
	Foreign key (LicenseClassID)
	References Users(UserID),
Constraint FK_Licenses_LicenseClasses
	Foreign key (LicenseClassID)
	References LicenseClasses(LicenseClassID),
Constraint FK_Licenses_Drivers
	Foreign key (DriverID)
	References Drivers(DriverID),
Constraint CK_Licenses_Fees
	check (PaidFees >= 0),
Constraint CK_Licenses_Dates
	check (ExpirationDate >= IssueDate)
)

/*===========================================
			InternationalLicenses
===========================================*/
Create Table InternationalLicenses
(
InternationalLicenseID int primary key identity(1,1),
IssueDate Date not null,
ExpirationDate Date not null,
IsActive bit not null Default 1,
CreatedByUserID int not null,
ApplicationID int not null,
DriverID int not null,
IssuedUsingLocalLicenseID int not null,
Constraint FK_InternationalLicenses_CreatedUsers
	Foreign key (CreatedByUserID)
	References Users(UserID),
Constraint FK_InternationalLicenses_Applications
	Foreign key (ApplicationID)
	References Applications(ApplicationID),
Constraint FK_InternationalLicenses_Drivers
	Foreign key (DriverID)
	References Drivers(DriverID),
Constraint FK_InternationalLicenses_Licenses
	Foreign key (IssuedUsingLocalLicenseID)
	References Licenses(LicenseID),
Constraint CK_InternationalLicenses_Dates
	check (ExpirationDate >= IssueDate)
)

/*===========================================
			DetaintedLicenses
===========================================*/
Create Table DetaintedLicenses
(
DetainID int primary key identity(1,1),
DetainDate date not null,
FineFees Decimal(10,2) not null,
IsReleased bit not null default 0,
ReleaseDate date null,
CreatedByUserID int not null,
ReleasedByUserID int null,
ReleaseApplicationID int null,
LicenseID int not null,
Constraint FK_DetaintedLicenses_CreatedUsers
	Foreign key (CreatedByUserID)
	References Users(UserID),
Constraint FK_DetaintedLicenses_ReleasedUsers
	Foreign key (CreatedByUserID)
	References Users(UserID),
Constraint FK_DetaintedLicenses_ReleaseApplication
	Foreign key (ReleaseApplicationID)
	References Applications(ApplicationID),
Constraint FK_DetaintedLicenses_Licenses
	Foreign key (LicenseID)
	References Licenses(LicenseID),
Constraint CK_DetaintedLicenses_Fine
	check (FineFees >= 0),
Constraint CK_DetaintedLicenses_Release
	Check (
		(IsReleased = 0 And ReleaseDate is null)
		OR
		(IsReleased = 1 And ReleaseDate is not null)
	)
)


