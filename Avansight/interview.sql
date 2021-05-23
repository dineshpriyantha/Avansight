--1.
create database PatientDB


CREATE TABLE Patient(
	PatientId INT IDENTITY(1,1) PRIMARY KEY,
	Age INT CHECK(20 < Age AND Age < 100 ),
	Gender VARCHAR(10)
)

CREATE TABLE TreatmentReading(
	TreatmentReadingId INT IDENTITY(1,1) PRIMARY KEY,
	VisitWeek VARCHAR(10),
	Reading DECIMAL(10,2),
	PatientId INT,
	CONSTRAINT FK_PatientTreatmentReading FOREIGN KEY(PatientId)
	REFERENCES Patient(PatientId)
)

select * from Patient

insert into Patient values(21,'Male')


--2. Create User-Defined Table Type

CREATE TYPE PatientTableType AS TABLE
(
	Age INT CHECK(20 < Age AND Age < 100 ),
	Gender VARCHAR(10)
)

CREATE TYPE TreatmentReadingTableType AS TABLE
(
	VisitWeek VARCHAR(10),
	Reading DECIMAL(10,2),
	PatientId INT
)

--3.1 create a proc PatientSet

CREATE PROCEDURE PatientSet
(
	@Patients AS PatientTableType READONLY
)
AS
BEGIN
	INSERT INTO Patient(Age, Gender)
	SELECT * FROM @Patients
	
	SELECT SCOPE_IDENTITY() 
END

--3.2  PatientGet

CREATE PROCEDURE PatientGet
AS
BEGIN
	SELECT * FROM Patient
END

--3.3 TreatmentReadingSet
CREATE PROCEDURE TreatmentReadingSet
(
	@TreatmentReadings AS TreatmentReadingTableType READONLY
)
AS
BEGIN
	INSERT INTO TreatmentReading(VisitWeek, Reading, PatientId)
	SELECT * FROM @TreatmentReadings

	SELECT SCOPE_IDENTITY() 
END	

--3.4 TreatmentReadingsGet

CREATE PROCEDURE TreatmentReadingsGet
AS
BEGIN
	SELECT * FROM TreatmentReading
END