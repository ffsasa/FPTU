Create database NET1720_PRN231_PRJ_G1_SchoolPsychologicalHealthSupportSystem
use NET1720_PRN231_PRJ_G1_SchoolPsychologicalHealthSupportSystem
CREATE TABLE [Category] (
  [Id] int primary key,
  [Name] varchar,
  [CreateAt] datetime,
  [UpdateAt] datetime
);

CREATE TABLE [User] (
  [Id] int primary key,
  [Username] varchar,
  [PasswordHash] varchar,
  [Full Name] varchar,
  [Email] varchar,
  [Phone] varchar,
  [Gender] bigint,
  [Avatar] varchar,
  [Role] varchar,
  [Status] bit,
  [CreateAt] datetime,
  [UpdateAt] datetime
);

CREATE TABLE [Blog] (
  [Id] int primary key,
  [CategoryId] int,
  [Name] varchar,
  [Title] varchar,
  [Content] varchar,
  [TopicImages] varchar,
  [LikeCount] int,
  [Hashtag] varchar,
  [Dislike] int,
  [StarAverage] float,
  [ReviewCount] int,
  [Status] bit,
  [CreateBy] int,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_Blog.Id]
    FOREIGN KEY ([Id])
      REFERENCES [Category]([Id]),
  CONSTRAINT [FK_Blog.CreateBy]
    FOREIGN KEY ([CreateBy])
      REFERENCES [User]([Id])
);

CREATE TABLE [Appointment] (
  [Id] int primary key,
  [ProfessorId] int,
  [UserId] int,
  [Title] nvarchar,
  [Date] datetime,
  [LinkMeet] varchar,
  [Status] nvarchar,
  [isBooked] bit,
  [Star] int,
  [Comment] nvarchar,
  [Note] nvarchar,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_Appointment.UserId]
    FOREIGN KEY ([UserId])
      REFERENCES [User]([Id])
);

CREATE TABLE [AppointmentReports] (
  [Id] int primary key,
  [UserId] int,
  [AppointmentId] int,
  [Star] int,
  [Description] varchar,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_AppointmentReports.UserId]
    FOREIGN KEY ([UserId])
      REFERENCES [User]([Id])
);

CREATE TABLE [ProgramsCategory] (
  [Id] int primary key,
  [Name] varchar,
  [CreateAt] datetime,
  [UpdateAt] datetime
);

CREATE TABLE [SupportPrograms] (
  [Id] int primary key,
  [CategoryId] int,
  [ProfessorId] int,
  [Title] varchar,
  [Description] varchar,
  [PosterUrl] varchar,
  [LinkMeet] varchar,
  [Number] int,
  [Host] int,
  [StartDate] datetime,
  [EndDate] datetime,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_SupportPrograms.CategoryId]
    FOREIGN KEY ([CategoryId])
      REFERENCES [ProgramsCategory]([Id])
);

CREATE TABLE [UserPrograms] (
  [Id] int primary key,
  [UserId] int,
  [ProgramId] int,
  [StartDate] datetime,
  [EndDate] datetime,
  CONSTRAINT [FK_UserPrograms.ProgramId]
    FOREIGN KEY ([ProgramId])
      REFERENCES [SupportPrograms]([Id]),
  CONSTRAINT [FK_UserPrograms.UserId]
    FOREIGN KEY ([UserId])
      REFERENCES [User]([Id])
);

CREATE TABLE [ServeyCategory] (
  [Id] int primary key,
  [Name] varchar,
  [CreateAt] datetime,
  [UpdateAt] datetime
);

CREATE TABLE [Surveys] (
  [Id] int primary key,
  [CategoryId] int,
  [Description] nvarchar,
  [Number] int,
  [PointAverage] float,
  [Verygood] int,
  [Good] int,
  [Medium] int,
  [Bad] int,
  [VeryBad] int,
  [CreateBy] int,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_Surveys.CategoryId]
    FOREIGN KEY ([CategoryId])
      REFERENCES [ServeyCategory]([Id]),
  CONSTRAINT [FK_Surveys.CreateBy]
    FOREIGN KEY ([CreateBy])
      REFERENCES [User]([Id])
);

CREATE TABLE [Question] (
  [Id] int primary key,
  [SurveyId] int,
  [Content] nvarchar,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_Question.Id]
    FOREIGN KEY ([Id])
      REFERENCES [Surveys]([Id])
);

CREATE TABLE [Answer] (
  [Id] int primary key,
  [QuestionId] int,
  [Content] nvarchar,
  [Point] int,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_Answer.Id]
    FOREIGN KEY ([Id])
      REFERENCES [Question]([Id])
);

CREATE TABLE [Result] (
  [Id] int primary key,
  [SurveyId] int,
  [UserId] int,
  [Point] int,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_Result.UserId]
    FOREIGN KEY ([UserId])
      REFERENCES [User]([Id]),
  CONSTRAINT [FK_Result.SurveyId]
    FOREIGN KEY ([SurveyId])
      REFERENCES [Surveys]([Id])
);

CREATE TABLE [StudentInfo] (
  [Id] int primary key,
  [UserId] varchar,
  [Grade] int,
  [Group] varchar,
  [CreateAt] datetime,
  [UpdateAt] datetime
);

CREATE TABLE [ScheduleTest] (
  [Id] int primary key,
  [SurveyId] int,
  [Grade] varchar,
  [Group] varchar,
  [Date] datetime,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_ScheduleTest.SurveyId]
    FOREIGN KEY ([SurveyId])
      REFERENCES [Surveys]([Id])
);

CREATE TABLE [Rate] (
  [Id] int primary key,
  [Name] varchar,
  [CreateAt] datetime,
  [UpdateAt] datetime
);

CREATE TABLE [User_Progress] (
  [Id] int primary key,
  [UserId] int,
  [RateId] int,
  [TotalSurvey] int,
  [TotalAppointment] int,
  [CompleteAppointment] int,
  [ProgramCount] int,
  [VeryGoodCount] int,
  [GoodCount] int,
  [MediumCount] int,
  [BadCount] int,
  [VeryBadCount] int,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_User_Progress.RateId]
    FOREIGN KEY ([RateId])
      REFERENCES [Rate]([Id])
);

CREATE TABLE [DashboardReport] (
  [Id] int primary key,
  [Title] nvarchar,
  [Content] nvarchar,
  [StartTime] datetime,
  [EndTime] datetime,
  [CreateAt] datetime,
  [UpdateAt] datetime
);

CREATE TABLE [DashboardInfo] (
  [Id] int primary key,
  [DashboarReportId] int,
  [TotalUsers] int,
  [ActiveUsers] int,
  [NewUsers] int,
  [CompletedSurveys] int,
  [AverageSurveyScore] float,
  [SupportProgramsUsed] int,
  [SurveySuccessRate] float,
  [SurveyFailRate] float,
  [ReportCount] int,
  [TotalAppointments] int,
  [CreateAt] datetime,
  [UpdateAt] datetime,
  CONSTRAINT [FK_DashboardInfo.DashboarReportId]
    FOREIGN KEY ([DashboarReportId])
      REFERENCES [DashboardReport]([Id])
);

