INSERT INTO [PETCDb].[dbo].[UserRole] (RoleName, [Description], CreatedBy, ModifiedBy, [Status], CreatedAt, ModifiedAt)
VALUES
    ('Admin', 'Description1', 'Sys', 'Sys', 1, GETDATE(), GETDATE()),
    ('Test', 'Description2', 'Sys', 'Sys', 1, GETDATE(), GETDATE());



INSERT INTO [PETCDb].[dbo].[User] ([Name], [UserId], [Password], [Photo], [PhotoFileName], [Designation], [RoleName], [Age], [EmailId], [MobileNo], [LandlineNo],
    [PermanentAddress], [PresentAddress], [CreatedBy], [ModifiedBy], [Status], [CreatedAt], [ModifiedAt])
VALUES
    ('Admin', 'Admin', 'Admin@123', null, null, 'Manager', 'Admin', null, null, 1234567890, null,
     null, null, 'Sys', 'Sys', 1, GETDATE(), GETDATE());
  

INSERT INTO [PETCDb].[dbo].[Institute] ([Name], [Description], [Longitude], [Latitude], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [Status])
VALUES
  ('M/s. Akka IAS Academy', 'Description 1', null, null, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  ('M/s. Sambojar Education and Multipurpose Association (Samruddhi Coaching Academy)', 'Description 2', null, null, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  ('M/s. Dr.Rajkumar Academy for Civil Services', 'Description 2', null, null, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  ('M/s. Grace IAS', 'Description 2', null, null, 'Sys', GETDATE(), 'Sys', GETDATE(), 1);


INSERT INTO [PETCDb].[dbo].[Training] ([Name] ,[Description] ,[CreatedBy] ,[CreatedAt] ,[ModifiedBy] ,[ModifiedAt] ,[Status])
VALUES
  ('UPSC', 'Description 1', 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  ('KAS', 'Description 2', 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  ('RRB', 'Description 2', 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  ('M/s. Grace IAS', 'Description 2', 'Sys', GETDATE(), 'Sys', GETDATE(), 1);

  
INSERT INTO [PETCDb].[dbo].[QuestionType] ([Name] ,[Description] ,[CreatedBy] ,[CreatedAt] ,[ModifiedBy] ,[ModifiedAt] ,[Status])
VALUES
  ('Generic', 'Description 1', 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  ('Moderate', 'Description 2', 'Sys', GETDATE(), 'Sys', GETDATE(), 1);


INSERT INTO [PETCDb].[dbo].[Student] ([StudentCode] ,[Name] ,[Password] ,[PhotoFileName] ,[EmailId] ,[MobileNo] ,[FinancialYear] ,[Education] ,
[College] ,[University] ,[PermanentAddress] ,[PresentAddress] ,[CreatedBy] ,[ModifiedBy] ,[Status] ,[CreatedAt] ,[ModifiedAt])
VALUES
  ('2223PCTW002071', 'M Pradeep', 'Admin@123', null, null, 1234567890, 2023-2024, 'BE', null, 'M/s. Spardha Mithra Coaching Centre', 'Bijapur', null, 'Sys', 'Sys', 1,  GETDATE(), GETDATE()),
  ('2223PCSW022053', 'BHEEMRAO', 'Admin@123', null, null, 1234567890, 2022-2023, 'BA', null, 'M/s. Sahara', 'Bidar', null, 'Sys', 'Sys', 1,  GETDATE(), GETDATE()),
  ('2223PCTW001389', 'PAVAN', 'Admin@123', null, null, 1234567890, 2021-2022, 'BSC', null, 'M/s. Karnataka Classic Education Private Ltd', 'Belgaum', null, 'Sys', 'Sys', 1,  GETDATE(), GETDATE()),
  ('2223PCTW002182', 'AMRUT', 'Admin@123', null, null, 1234567890, 2020-2021, 'MSC', null, 'M/s. Margadarshi Tarabethi Kendra', 'Gulbarga', null, 'Sys', 'Sys', 1,  GETDATE(), GETDATE());


INSERT INTO [PETCDb].[dbo].[Question] ([TrainingId], [QuestionText], [Description], [QuestionType], [Position], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [Status])
VALUES
  (1, 'How would you rate the overall quality of this course?', null, 'Generic', 1, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (1, 'On a scale from 0 to 10, how satisfied are you with the teaching methods used in this course?', null, 'Generic', 1, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (1, 'How clear were the learning objectives for each module or class?', null, 'Moderate', 1, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (2, 'How well did the assessments (quizzes, exams, projects) align with the course content?', null, 'Generic', 1, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (3, 'Rate the technology used in the course (e.g., online platforms, multimedia presentations).', null, 'Moderate', 1, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (4, 'On a scale from 0 to 10, how likely are you to recommend this course to a friend?', null, 'Moderate', 1, 'Sys', GETDATE(), 'Sys', GETDATE(), 1);


INSERT INTO [PETCDb].[dbo].[TrainingInstitute] ([TrainingId], [InstituteId] ,[CreatedBy] ,[CreatedAt] ,[ModifiedBy] ,[ModifiedAt] ,[Status])
VALUES
  (1, 2, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (1, 4, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (2, 1, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (2, 3, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (3, 2, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (3, 3, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (4, 1, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (4, 4, 'Sys', GETDATE(), 'Sys', GETDATE(), 1);


  
INSERT INTO [PETCDb].[dbo].[StudentTrainingInstitute] ([StudentId], [TrainingInstituteId] ,[CreatedBy] ,[CreatedAt] ,[ModifiedBy] ,[ModifiedAt] ,[Status])
VALUES
  (1, 8, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (2, 8, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (3, 4, 'Sys', GETDATE(), 'Sys', GETDATE(), 1),
  (4, 6, 'Sys', GETDATE(), 'Sys', GETDATE(), 1);

