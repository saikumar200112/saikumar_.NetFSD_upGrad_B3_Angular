
CREATE DATABASE EventDb

USE EventDb

CREATE TABLE UserInfo
(
   EmailId VARCHAR(50) PRIMARY KEY,
   UserName VARCHAR(50) NOT NULL CHECK(LEN(UserName) BETWEEN 1 AND 50),
  [Role] VARCHAR(20) NOT NULL CHECK (Role IN ('Admin','Participant')),
   [Password] VARCHAR(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20)
   );

   INSERT INTO UserInfo VALUES('Sai@123.COM','Saikumar','Admin','Sai@1206');
   INSERT INTO UserInfo VALUES('Kumar@123.COM','Kumar','Participant','kumar@1206');
   INSERT INTO UserInfo VALUES('Saswanth@123.COM','Jaswanth','Participant','Jaswanth@1002');
    INSERT INTO UserInfo VALUES('Sunny@123.COM','Sunny','Participant','Sunny@306');
   
CREATE TABLE EventDetails
(
   EventId INT PRIMARY KEY,
   EventName VARCHAR(50) NOT NULL CHECK (LEN(EventName) BETWEEN 1 AND 50),
   EventCategory VARCHAR(50) NOT NULL CHECK(LEN(EventCategory) BETWEEN 1 AND 50),
   EventDate DATETIME NOT NULL,
   [Description] VARCHAR(MAX) NULL,
   [Status] VARCHAR(10) NOT NULL CHECK(Status IN ('Active','In-Active'))
   );
 INSERT INTO EventDetails VALUES('100','Tech Summit 2026','Conference','2026-05-20 09:00:00','Annual Technology Innovation','Active');
 INSERT INTO EventDetails VALUES('101','Art And Culture','Expo','2026-05-20 10:00:00','Showing Loacal Talent','Active');
 INSERT INTO EventDetails VALUES('102','Global Coding','Workshop','2026-05-20 11:00:00','Hacthon','In-Active');


CREATE TABLE SpeakersDetails
(
   SpeakerId INT PRIMARY KEY,
   SpeakerName VARCHAR(50) NOT NULL CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
   );
INSERT INTO SpeakersDetails VALUES(1,'Saikumar');
INSERT INTO SpeakersDetails VALUES(2,'Jaswanth');
INSERT INTO SpeakersDetails VALUES(3,'Sunny');
INSERT INTO SpeakersDetails VALUES(4,'Vinod');


CREATE TABLE SessionInfo
(
   SessionId INT PRIMARY KEY,
   EventId INT NOT NULL,
   SessionTitle VARCHAR(50) NOT NULL CHECK(LEN(SessionTitle)BETWEEN 1 AND 50),
   SpeakerId INT NOT NULL,
   [Description] VARCHAR(MAX) NULL,
   SessionStart DATETIME NOT NULL,
   SessionEnd DATETIME NOT NULL,
   SessionUrl VARCHAR(2048) NULL,
   FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
   FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId),
);
CREATE TABLE ParticipantEventDetails
(
   Id INT PRIMARY KEY,
   ParticipantEmailId VARCHAR(50) NOT NULL,
   EventId INT NOT NULL,
   SessionId INT NOT NULL,
   IsAttended BIT NOT NULL,
   FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
   FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
   FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
   );

SELECT* FROM UserInfo;
SELECT *FROM EventDetails;
SELECT * FROM SpeakersDetails;




























