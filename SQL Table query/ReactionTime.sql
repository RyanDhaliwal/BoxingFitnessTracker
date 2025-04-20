DROP TABLE ReactionTime
CREATE TABLE ReactionTime(
	UserName varchar(20),
	punchtime FLOAT,
	speed FLOAT,
	RecievedTime varchar(30),
	 /*CONSTRAINT FK_ReactionTime_UserName FOREIGN KEY (UserName) REFERENCES PunchPower(UserName)*/
	)