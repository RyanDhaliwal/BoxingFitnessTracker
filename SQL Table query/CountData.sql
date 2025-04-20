DROP TABLE CountData
CREATE TABLE CountData(
	UserName varchar(20),
	rhand INT,
	lhand INT,
	bothhands INT,
	RecievedTime varchar(30),
	/*CONSTRAINT FK_CountData_UserName FOREIGN KEY (UserName) REFERENCES PunchPower(UserName)*/
	)