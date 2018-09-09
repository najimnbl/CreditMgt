Create Database MerchantBank

--Drop table  tblCountry
Create table tblCountry (
CountryID  int identity (1,1),
CountryName nvarchar(75),
PRIMARY KEY(CountryID) 
)


--Drop table  tblBank

Create table tblBank(
Bankid int identity(1,1),
BankName nvarchar(75),
BankRemarks nvarchar(75),
primary key(Bankid),
)


--Drop table tblBankBranch

Create table tblBankBranch (
BranchID  int identity (1,1),
Bankid  int,
BranchCode nvarchar(15),
BranchName nvarchar(50),
BranchAddress nvarchar(150),
BranchRoutingCode nvarchar(15),
BranchRemarks nvarchar(75),
BranchCreateBy nvarchar(75),
BranchLastModifieddBy nvarchar(15),
PRIMARY KEY(BranchID),
UNIQUE(Bankid,BranchID,BranchCode),
FOREIGN KEY (Bankid) REFERENCES tblBank(Bankid),
)

--Drop table  tblChargeItem

Create table tblChargeItem(
ChargeID int identity(1,1),
ChargeCode nvarchar(25) ,
ChargeDetails nvarchar(75),
ChargeAmount float ,
CApplyLowerLimit float,
CApplyHigherLimit float,
ChargePercentage float,
ChargeItemType bit,
ChargeRemarks nvarchar(75),
ChargeCreatedBy nvarchar(75),
ChargeLastModifiedBy nvarchar(75),
primary key(ChargeCode),
Unique(ChargeCode,ChargeID)

)


--Drop table tbleChargeCategory

Create table tbleChargeCategory (
ChargeCategoryID int identity(1,1),
ChargeCategoryCode  nvarchar(15),
ChargeCategoryName  nvarchar(50),
ChargeCategoryRemarks nvarchar(50),
ChargeCategoryCreatedBy nvarchar(75),
ChargeCategoryLastModifiedBy nvarchar(75),
primary key(ChargeCategoryCode)

)

--Drop table  tblChargeConfiguration

Create table tblChargeConfiguration(
ChargeConfigurationID int identity(1,1),
ChargeCategoryCode NvarChar(15),
ChargeConfigurationDetails NvarChar(75),
ChargeCode nvarchar(25),
ChargeCRemarks nvarchar(75),
ChargeCCreatedBy nvarchar(75),
ChargeCLastModifiedBy nvarchar(75),

PRIMARY KEY (ChargeConfigurationID),
FOREIGN KEY (ChargeCategoryCode) REFERENCES tbleChargeCategory(ChargeCategoryCode),
FOREIGN KEY (ChargeCode) REFERENCES tblChargeItem(ChargeCode),

UNIQUE(ChargeCategoryCode,ChargeCode)

)

--drop table tblClientType

Create Table tblClientType(
ClientTypeID int identity (1,1),
ClientTypeCode nvarchar(25),
ClientTypeDetais nvarchar(75),
ClientTypeRemarks nvarchar(75),
ClientTypeChargePercentage float,
ClientTypeCreateBy  nvarchar(75),
ClientTypeLastModifiedBy nvarchar(75),
PRIMARY KEY (ClientTypeCode)

)


--drop table tblRole

Create table tblRole(
RoleId int identity(1,1),
RoleCode nvarchar(25),
RoleDetails nvarchar(75),
RoleRemarks nvarchar(75),
RoleCreateBy nvarchar(25),
RoleLastModifiedBy nvarchar(25)
PRIMARY KEY (RoleCode)

)

--Drop table tblClient

Create table tblClient (
ClSL bigint identity(1,1),
ClientID nvarchar(25),
ClientBIO nvarchar(20),
MBHouseCode nvarchar(15),
ClientIntroducer  nvarchar(20),
RoleCode  nvarchar(25),
ClientTypeCode nvarchar(25),
ChargeCategoryCode NvarChar(15),
ClientPowerAtonyDetais Nvarchar(150),
ClientSpecialComissionRate Nvarchar(150),
ClientTransactionAccount Nvarchar(50),
AccountType NvarChar(25),
ClientCreateBy  nvarchar(50),
ClientLastModified  nvarchar(50),

PRIMARY KEY (ClientID),
unique (ClientBIO),
FOREIGN KEY (RoleCode) REFERENCES tblRole(RoleCode),
--FOREIGN KEY (ClientIntroducer) REFERENCES tblCustomer(CustomerID),
FOREIGN KEY (ClientTypeCode) REFERENCES tblClientType(ClientTypeCode),
FOREIGN KEY (ChargeCategoryCode) REFERENCES tbleChargeCategory(ChargeCategoryCode)
)




--drop table tblCustomer

Create Table tblCustomer(
CuSL bigint identity(1,1),
CustomerID nvarchar(20),
CustomerName nvarchar(75),
CustomerFatherName nvarchar(75),
CustomerMotherName nvarchar(75),
CustomerSex nvarchar(10),
CustomerDOB Date ,
CustomerReligion nvarchar(50),
CountryID int,
CustomerNID nvarchar(50),
CustomerTIN nvarchar(50),
CustomerPassportNO nvarchar(50),
CustomerMeritalStatus nvarchar(20),
CustomerEmail nvarchar(75),
CustomerPermanentAddress nvarchar(150),
CustomerPermanentContact nvarchar(50),
CustomerPresentAddress nvarchar(150),
CustomerPresentContact nvarchar(50),
CustomerMailingAddress nvarchar(150),
CustomerMailingContact nvarchar(50),
CustomerNo int ,
Bankid int,
BranchID int,
CustomerBankAccount nvarchar(50),
CustommerCreateBY  nvarchar(50),
CustomerApprovedby  nvarchar(50),
CustomerLastModified  nvarchar(50),
CustomerCleintID  nvarchar(25),
CustomerIsCompany bit,

PRIMARY KEY (CustomerID),
FOREIGN KEY (CountryID) REFERENCES tblCountry(CountryID),
FOREIGN KEY (Bankid) REFERENCES tblBank(Bankid),
FOREIGN KEY (BranchID) REFERENCES tblBankBranch(BranchID),
FOREIGN KEY (CustomerCleintID) REFERENCES tblClient(ClientID),
UNIQUE(CustomerID,CustomerBankAccount)

)


--Drop table tblNominee
Create Table tblNominee(
NomSL bigint identity(1,1),
NomineeID nvarchar(20),
NomineeRightPercentage float,
NomineeName nvarchar(75),
NomineeFatherName nvarchar(75),
NomineeRelationWithC nvarchar(75),
NomineeSex nvarchar(10),
NomineeDOB Date ,
NomineeReligion nvarchar(50),
NomineeCountryID int,
NomineeNID nvarchar(50),
NomineeTIN nvarchar(50),
NomineePermanentAddress nvarchar(150),
NomineePermanentContact nvarchar(50),
NomineePresentAddress nvarchar(150),
NomineePresentContact nvarchar(50),
ClientID nvarchar(25),
NomineeIsMature nvarchar(1),
NomineeCreateBy  nvarchar(50),
NomineeLastModified  nvarchar(50),



Primary Key(NomineeID),
FOREIGN KEY (NomineeCountryID) REFERENCES tblCountry(CountryID),
FOREIGN KEY (ClientID) REFERENCES tblClient(ClientID),
unique(NomineeID,ClientID)
)


--Drop table tblGuardian

Create Table tblGuardian(
GurSL bigint identity(1,1),
GuardianID nvarchar(20),
GuardianRightPercentage float,
GuardianName nvarchar(75),
GuardianFatherName nvarchar(75),
GuardianRelationWithN nvarchar(75),
GuardianSex nvarchar(10),
GuardianDOB Date ,
GuardianReligion nvarchar(50),
GuardianCountryID int,
GuardianNID nvarchar(50),
GuardianTIN nvarchar(50),
GuardianPermanentAddress nvarchar(150),
GuardianPermanentContact nvarchar(50),
GuardianPresentAddress nvarchar(150),
GuardianPresentContact nvarchar(50),
GuardianCreateBy  nvarchar(50),
GuardianLastModified  nvarchar(50),
NomineeID nvarchar(20),
Primary Key(GuardianID),
FOREIGN KEY (GuardianCountryID) REFERENCES tblCountry(CountryID),
FOREIGN KEY (NomineeID) REFERENCES tblNominee(NomineeID),
unique(NomineeID,GuardianID)
)




--Drop table tblGuardian
--Drop table tblNominee
--drop table tblCustomer
--Drop table tblClient
--drop table tblRole
--drop table tblClientType
--Drop table  tblChargeConfiguration
--Drop table tbleChargeCategory
--Drop table  tblChargeItem
--Drop table tblBankBranch
--Drop table  tblBank
--Drop table  tblCountry
ALTER TABLE tblCustomer ADD CustomerMobileNo nvarchar(25)
CREATE TABLE tblCustomerImage(
	ID int NOT NULL,
	Image image NULL,
	Signature image NULL,
	CustomerCode varchar(50) NULL,
	Primary Key(ID),
 )
 --drop table tblMenuItem
 CREATE TABLE tblMenuItem(
	ID int identity(1,1) NOT NULL,
	MenuNo int,
	MenuName nvarchar(75),
	CreateBy nvarchar(50),
	LastModifiedBy nvarchar(50),
	Primary Key(MenuNo)
 )
 --drop table tblSubMenuItem
 CREATE TABLE tblSubMenuItem(
	ID int identity(1,1) NOT NULL,
	SubMenuNo int,
	SubMenuName nvarchar(75),
	MenuNo int,
	CreateBy nvarchar(50),
	LastModifiedBy nvarchar(50),
	Primary Key(MenuNo,SubMenuNo)
 )
 --drop table tblUserAssignRights
 CREATE TABLE tblUserAssignRights(
	ID int identity(1,1) NOT NULL,
	UserID nvarchar(50),
	MenuNo int,
	MenuRights bit,
	SubMenuNo int,
	SubMenuRights bit,
	CreateBy nvarchar(50),
	LastModifiedBy nvarchar(50),
	
 )
 --drop table tblUserInfo
 CREATE TABLE tblUserInfo(
	ID int identity(1,1) NOT NULL,
	UserID nvarchar(50),
	UserType nvarchar(20),
	Password nvarchar(20),
	ConfirmPassword nvarchar(20),
	Active bit,
	EmployeeID nvarchar(50),
	CreateBy nvarchar(50),
	LastModifiedBy nvarchar(50),
	Primary Key(UserID)
 )
  --drop table tblEmployeeInfo
 CREATE TABLE tblEmployeeInfo(
	ID int identity(1,1) NOT NULL,
	EmployeeID nvarchar(50),
	EmployeeName nvarchar(50),
	Designation nvarchar(20),
	RegistrationNo nvarchar(20),
	BranchCode nvarchar(20),
	MobileNo nvarchar(15),
	CreateBy nvarchar(50),
	LastModifiedBy nvarchar(50),
	Primary Key(EmployeeID)
 )
 
 
 Create  PROCEDURE [dbo].[getLogInInfo]
	@userid AS varchar(30)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT     a.USERID, a.UserType, a.PASSWORD, a.EmployeeID, a.Active
	FROM         tblUserInfo AS a
	WHERE     (a.USERID = @userid) AND (a.Active='true')

END



Create PROCEDURE [dbo].[LogInUser]
	@userid AS varchar(30)
AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE tblUserInfo SET    LOGINSTATUS='True'
	WHERE UserId=@userid and Active='true'

END

GO


--mina asaduzzaman
--drop table tblAccountType
 CREATE TABLE tblAccountType(
	AccTypeSL int identity(1,1) NOT NULL,
	AccTypeCode nvarchar(5),
	AccTypeName nvarchar(10),
	Primary Key(AccTypeSL)
 )
 --drop table tblAccountGroupType
 CREATE TABLE tblAccountGroupType(
	AccGTSL int identity(1,1) NOT NULL,
	AccGTCode nvarchar(20),
	AccGTName nvarchar(50),
	Primary Key(AccGTSL)
 )
 --drop table tblGroupAccount
 CREATE TABLE tblGroupAccount(
	GrpAccSL int identity(1,1) NOT NULL,
	GrpAccNo nvarchar(20),
	AccGTSL int,
	GrpAccName nvarchar(50),
	Remarks nvarchar(50),
	CrateBy nvarchar(50),
	LastModifiedBy nvarchar(50),
	Primary Key(GrpAccSL),
	FOREIGN KEY (AccGTSL) REFERENCES tblAccountGroupType(AccGTSL)
 )
  --drop Table tblAccountGroupReport
  CREATE TABLE tblAccountGroupReport(
	AccGrpSLR int identity(1,1),
	AccGrpCodeR nvarchar(20),
	AccGrpNameR nvarchar(50),
	Primary Key(AccGrpSLR)
 )
  --drop table tblSubGroupAccount
 CREATE TABLE tblSubGroupAccount(
	SGrpAccSL int identity(1,1) NOT NULL,
	SGrpAccNo nvarchar(20),
	GrpAccSL int,
	SGrpAccName nvarchar(50),
	Remarks nvarchar(50),
	CrateBy nvarchar(50),
	LastModifiedBy nvarchar(50),
	Primary Key(SGrpAccSL),
	FOREIGN KEY (GrpAccSL) REFERENCES tblGroupAccount(GrpAccSL)
 )
 --drop table tblChartOfAccount

 CREATE TABLE tblChartOfAccount(
	CoAccSL int identity(1,1) NOT NULL,
	CoAccNo nvarchar(20),
	CoAccName nvarchar(50),
	OpenDate DateTime,
	
	GrpAccSL int,
	AccGrpSLR int,
	AccTypeSL int,
	SGrpAccSL int,
	
	Posted bit,
	OpenDayBalance decimal(18,2),
	ClossingBalance decimal(18,2),
	AvailableBalance decimal(18,2),
	CurrentBalance decimal(18,2),
	CreateBy nvarchar(50),
	LastModifiedBy nvarchar(50)
	Primary Key(CoAccSL)
	
	FOREIGN KEY (GrpAccSL) REFERENCES tblGroupAccount(GrpAccSL),
	FOREIGN KEY (AccGrpSLR) REFERENCES tblAccountGroupReport(AccGrpSLR),
	FOREIGN KEY (AccTypeSL) REFERENCES tblAccountType(AccTypeSL),
	FOREIGN KEY (SGrpAccSL) REFERENCES tblSubGroupAccount(SGrpAccSL)
	
 )
 
 ----Drop table tblChartOfAccountEndedHistory
 Create table tblChartOfAccountEndedHistory(
 CoAccSLEH int identity(1,1),
 CoAccSL int,
 MonthEndCBalance decimal(18,2),
 MonthEndCBalancenDate DateTime,
 YearEndCBalance decimal(18,2),
 YearEndCBalancenDate DateTime,
 Remarks Nvarchar(50),
 FOREIGN KEY (CoAccSL) REFERENCES tblChartOfAccount(CoAccSL)
 )
 
 --Drop table tblChartOfAccountDetailsHistory
 CREATE TABLE tblChartOfAccountDetailsHistory(
	CoAccSLDH int identity(1,1) NOT NULL,
	CoAccSL int ,
	CDate DateTime,
	OpenDayBalance decimal(18,2),
	ClossingBalance decimal(18,2),
	AvailableBalance decimal(18,2),
	CurrentBalance decimal(18,2),
	Primary Key(CoAccSLDH),
	FOREIGN KEY (CoAccSL) REFERENCES tblChartOfAccount(CoAccSL),
	
	
 )
 --drop table tblTransaction
Create table tblTransaction (
TranSL bigint identity (1,1),
VoucherNo nvarchar(20) ,
VoucherDate DateTime,
BrSL int,
TranTypeSL int,
PartiCulars varchar(150),
Posted bit,
Approved bit,
BillSL int,
RevTranSL bigint,
CreateBy varchar(50),
LastModifiedBy varchar(50)
PRIMARY KEY(VoucherNo)
FOREIGN KEY (TranTypeSL) REFERENCES tblTransactionType(TranTypeSL),
)
--drop table tblTransactionAcc
Create table tblTransactionAcc (
TranAccSL bigint identity (1,1),
VoucherNo  nvarchar(20),
CoAccNo nvarchar(20),
IsClient bit,
TMode nvarchar(20),
BankName nvarchar(50),
BranchName nvarchar(50),
ChequeNo nvarchar(50),
ChequeDate DateTime,
Tref varchar(50),
BQty decimal(18,2),
SQty decimal(18,2),
Debit decimal(18,2),
Credit decimal(18,2),
Balance decimal(18,2),
Matured bit,
CreateBy varchar(50),
LastModifiedBy varchar(50)
FOREIGN KEY (VoucherNo) REFERENCES tblTransaction(VoucherNo))
--drop table tblTransactionType
 Create table tblTransactionType (
TranTypeSL int identity (1,1),
TypeCode varchar(2) ,
TypeName varchar(20),
CreateBy varchar(50),
LastModifiedBy varchar(50)
PRIMARY KEY(TranTypeSL)

)

Create Table LoanAplicationFinancial(
SL bigint identity(1,1),
AcountNo Nvarchar(25),
LimitAmount numeric(18,2),
ProposedAmount numeric(18,2),
ReNewAmount  numeric(18,2),
SanctionAmount numeric(18,2),

Tenor1  numeric(18,2),
RevisedTenor numeric(18,2),

LC_Comission1 numeric(18,2),
LC_Comission2 numeric(18,2),

AcceptedComision1 numeric(18,2),
AcceptedComision2 numeric(18,2),

SanctionDate date,

InttRate1 numeric(18,2), 
InttRateRevised numeric(18,2),

MODofRepayment1 numeric(18,2),
MODofRepayment2 numeric(18,2),

InstalmentAmount numeric(18,2),
RevisedInstalmentAmount numeric(18,2),

GrascePriod  numeric(18,2),
Margin nvarchar(500),
Cdate Date,
ModifYDate Date,
FOREIGN KEY (AcountNo) REFERENCES LoanAplication(AcountNo)

)


Create table GroupInfo(
GroupSL int identity(1,1),
GroupName nvarchar(100),
Primary key (GroupSL)
)

Create table SubGroupInfo(
SubGroupSL int identity(1,1),
GroupSL int ,
SubGroupName nvarchar(100),
foreign key (GroupSL) REFERENCES GroupInfo(GroupSL)
)
