
CREATE SCHEMA [HangFire]
GO


CREATE TABLE HangFire.Counter(
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Counter_Id PRIMARY KEY,
	[Key] nvarchar(100) NOT NULL,
	Value smallint NOT NULL,
	ExpireAt datetime NULL
)
GO

CREATE NONCLUSTERED INDEX IX_HangFire_Counter_Key ON HangFire.Counter
(
	[Key] ASC
)
INCLUDE (Value)


CREATE TABLE HangFire.[Hash](
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Hash_Id PRIMARY KEY,
	[Key] nvarchar(100) NOT NULL,
	Field nvarchar(100) NOT NULL,
	Value nvarchar(max) NULL,
	ExpireAt datetime2(7) NULL
)
GO

CREATE UNIQUE NONCLUSTERED INDEX UX_HangFire_Hash_Key_Field ON HangFire.[Hash]
(
	[Key] ASC,
	Field ASC
)

CREATE TABLE HangFire.Job(
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Job_Id PRIMARY KEY,
	StateId int NULL,
	StateName nvarchar(20) NULL,
	InvocationData nvarchar(max) NOT NULL,
	Arguments nvarchar(max) NOT NULL,
	CreatedAt datetime NOT NULL,
	ExpireAt datetime NULL
)
GO

CREATE NONCLUSTERED INDEX IX_HangFire_Job_StateName ON HangFire.Job
(
	StateName ASC
)


CREATE TABLE HangFire.JobParameter(
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_JobParameter_Id PRIMARY KEY,
	JobId int NOT NULL CONSTRAINT FK_JobParameter_Job_JobId_Id FOREIGN KEY REFERENCES HangFire.Job (Id) ON UPDATE CASCADE ON DELETE CASCADE,
	Name nvarchar(40) NOT NULL,
	Value nvarchar(max) NULL
)
GO
CREATE NONCLUSTERED INDEX IX_HangFire_JobParameter_JobIdAndName ON HangFire.JobParameter
(
	JobId ASC,
	Name ASC
)
GO

CREATE TABLE HangFire.JobQueue(
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_JobQueue_Id PRIMARY KEY,
	JobId int NOT NULL,
	Queue nvarchar(20) NOT NULL,
	FetchedAt datetime NULL
)
GO

CREATE NONCLUSTERED INDEX IX_HangFire_JobQueue_QueueAndFetchedAt ON HangFire.JobQueue
(
	[Queue] ASC,
	FetchedAt ASC
)


CREATE TABLE HangFire.List(
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_List_Id PRIMARY KEY,
	[Key] nvarchar(100) NOT NULL,
	Value nvarchar(max) NULL,
	ExpireAt datetime NULL
)

CREATE TABLE HangFire.[Schema](
	[Version] int NOT NULL CONSTRAINT PK_Schema_Version PRIMARY KEY
)


CREATE TABLE HangFire.[Server](
	Id nvarchar(50) NOT NULL CONSTRAINT PK_Server_Id PRIMARY KEY ,
	Data nvarchar(max) NULL,
	LastHeartbeat datetime NOT NULL
)

CREATE TABLE HangFire.[Set](
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Set_Id PRIMARY KEY,
	[Key] nvarchar(100) NOT NULL,
	Score float NOT NULL,
	Value nvarchar(256) NOT NULL,
	ExpireAt datetime NULL
)

GO

CREATE UNIQUE NONCLUSTERED INDEX UX_HangFire_Set_KeyAndValue ON HangFire.[Set]
(
	[Key] ASC,
	Value ASC
)


CREATE TABLE HangFire.[State](
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_State_Id PRIMARY KEY,
	JobId int NOT NULL CONSTRAINT FK_State_Job_JobId_Id REFERENCES HangFire.Job (Id) ON UPDATE CASCADE ON DELETE CASCADE,
	Name nvarchar(20) NOT NULL,
	Reason nvarchar(100) NULL,
	CreatedAt datetime NOT NULL,
	Data nvarchar(max) NULL
)
GO
CREATE NONCLUSTERED INDEX IX_HangFire_State_JobId ON HangFire.[State]
(
	JobId ASC
)
GO

CREATE TABLE HangFire.AggregatedCounter(
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_AggregatedCounter_Id PRIMARY KEY,
	[Key] nvarchar(100) NOT NULL,
	Value bigint NOT NULL,
	ExpireAt datetime NULL
)

GO
CREATE UNIQUE NONCLUSTERED INDEX UX_HangFire_CounterAggregated_Key ON HangFire.AggregatedCounter
(
	[Key] ASC
)
INCLUDE (Value)