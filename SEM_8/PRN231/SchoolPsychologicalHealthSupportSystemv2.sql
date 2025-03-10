USE [NET1720_PRN231_PRJ_G1_SchoolPsychologicalHealthSupportSystem]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] NOT NULL,
	[QuestionId] [int] NULL,
	[Content] [nvarchar](1) NULL,
	[Point] [int] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[Id] [int] NOT NULL,
	[ProfessorId] [int] NULL,
	[UserId] [int] NULL,
	[Title] [nvarchar](1) NULL,
	[Date] [datetime] NULL,
	[LinkMeet] [varchar](1) NULL,
	[Status] [nvarchar](1) NULL,
	[isBooked] [bit] NULL,
	[Star] [int] NULL,
	[Comment] [nvarchar](1) NULL,
	[Note] [nvarchar](1) NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppointmentReports]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentReports](
	[Id] [int] NOT NULL,
	[UserId] [int] NULL,
	[AppointmentId] [int] NULL,
	[Star] [int] NULL,
	[Description] [varchar](1) NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[Id] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[Name] [varchar](1) NULL,
	[Title] [varchar](1) NULL,
	[Content] [varchar](1) NULL,
	[TopicImages] [varchar](1) NULL,
	[LikeCount] [int] NULL,
	[Hashtag] [varchar](1) NULL,
	[Dislike] [int] NULL,
	[StarAverage] [float] NULL,
	[ReviewCount] [int] NULL,
	[Status] [bit] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] NOT NULL,
	[Name] [varchar](1) NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DashboardInfo]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DashboardInfo](
	[Id] [int] NOT NULL,
	[DashboarReportId] [int] NULL,
	[TotalUsers] [int] NULL,
	[ActiveUsers] [int] NULL,
	[NewUsers] [int] NULL,
	[CompletedSurveys] [int] NULL,
	[AverageSurveyScore] [float] NULL,
	[SupportProgramsUsed] [int] NULL,
	[SurveySuccessRate] [float] NULL,
	[SurveyFailRate] [float] NULL,
	[ReportCount] [int] NULL,
	[TotalAppointments] [int] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DashboardReport]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DashboardReport](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](1) NULL,
	[Content] [nvarchar](1) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramsCategory]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramsCategory](
	[Id] [int] NOT NULL,
	[Name] [varchar](1) NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] NOT NULL,
	[SurveyId] [int] NULL,
	[Content] [nvarchar](1) NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rate]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate](
	[Id] [int] NOT NULL,
	[Name] [varchar](1) NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[Id] [int] NOT NULL,
	[SurveyId] [int] NULL,
	[UserId] [int] NULL,
	[Point] [int] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleTest]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleTest](
	[Id] [int] NOT NULL,
	[SurveyId] [int] NULL,
	[Grade] [varchar](1) NULL,
	[Group] [varchar](1) NULL,
	[Date] [datetime] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServeyCategory]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServeyCategory](
	[Id] [int] NOT NULL,
	[Name] [varchar](1) NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentInfo]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentInfo](
	[Id] [int] NOT NULL,
	[UserId] [int] NULL,
	[Grade] [int] NULL,
	[Group] [varchar](1) NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
 CONSTRAINT [PK__StudentI__3214EC07558FED9B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupportPrograms]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupportPrograms](
	[Id] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[ProfessorId] [int] NULL,
	[Title] [varchar](1) NULL,
	[Description] [varchar](1) NULL,
	[PosterUrl] [varchar](1) NULL,
	[LinkMeet] [varchar](1) NULL,
	[Number] [int] NULL,
	[Host] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Surveys]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Surveys](
	[Id] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[Description] [nvarchar](1) NULL,
	[Number] [int] NULL,
	[PointAverage] [float] NULL,
	[Verygood] [int] NULL,
	[Good] [int] NULL,
	[Medium] [int] NULL,
	[Bad] [int] NULL,
	[VeryBad] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[EmployeeCode] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ApplicationCode] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__User__3214EC075D4CDF04] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Progress]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Progress](
	[Id] [int] NOT NULL,
	[UserId] [int] NULL,
	[RateId] [int] NULL,
	[TotalSurvey] [int] NULL,
	[TotalAppointment] [int] NULL,
	[CompleteAppointment] [int] NULL,
	[ProgramCount] [int] NULL,
	[VeryGoodCount] [int] NULL,
	[GoodCount] [int] NULL,
	[MediumCount] [int] NULL,
	[BadCount] [int] NULL,
	[VeryBadCount] [int] NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[UserAccountID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[EmployeeCode] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[RequestCode] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ApplicationCode] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPrograms]    Script Date: 1/10/2025 10:02:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPrograms](
	[Id] [int] NOT NULL,
	[UserId] [int] NULL,
	[ProgramId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([UserAccountID], [UserName], [Password], [FullName], [Email], [Phone], [EmployeeCode], [RoleId], [RequestCode], [CreatedDate], [ApplicationCode], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'manager', N'@a', N'Accountant', N'Accountant@', N'0913652742', N'000001', 2, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserAccount] ([UserAccountID], [UserName], [Password], [FullName], [Email], [Phone], [EmployeeCode], [RoleId], [RequestCode], [CreatedDate], [ApplicationCode], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, N'staff', N'@a', N'Internal Auditor', N'InternalAuditor@', N'0972224568', N'000002', 3, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserAccount] ([UserAccountID], [UserName], [Password], [FullName], [Email], [Phone], [EmployeeCode], [RoleId], [RequestCode], [CreatedDate], [ApplicationCode], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, N'admin', N'@a', N'Chief Accountant', N'ChiefAccountant@', N'0902927373', N'000003', 1, NULL, NULL, NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer.Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer.Id]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment.UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment.UserId]
GO
ALTER TABLE [dbo].[AppointmentReports]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentReports.UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[AppointmentReports] CHECK CONSTRAINT [FK_AppointmentReports.UserId]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog.CreateBy] FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog.CreateBy]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog_Category]
GO
ALTER TABLE [dbo].[DashboardInfo]  WITH CHECK ADD  CONSTRAINT [FK_DashboardInfo.DashboarReportId] FOREIGN KEY([DashboarReportId])
REFERENCES [dbo].[DashboardReport] ([Id])
GO
ALTER TABLE [dbo].[DashboardInfo] CHECK CONSTRAINT [FK_DashboardInfo.DashboarReportId]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question.Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Surveys] ([Id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question.Id]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result.SurveyId] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Surveys] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result.SurveyId]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result.UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result.UserId]
GO
ALTER TABLE [dbo].[ScheduleTest]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleTest.SurveyId] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Surveys] ([Id])
GO
ALTER TABLE [dbo].[ScheduleTest] CHECK CONSTRAINT [FK_ScheduleTest.SurveyId]
GO
ALTER TABLE [dbo].[StudentInfo]  WITH CHECK ADD  CONSTRAINT [FK_StudentInfo_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[StudentInfo] CHECK CONSTRAINT [FK_StudentInfo_User]
GO
ALTER TABLE [dbo].[SupportPrograms]  WITH CHECK ADD  CONSTRAINT [FK_SupportPrograms.CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProgramsCategory] ([Id])
GO
ALTER TABLE [dbo].[SupportPrograms] CHECK CONSTRAINT [FK_SupportPrograms.CategoryId]
GO
ALTER TABLE [dbo].[Surveys]  WITH CHECK ADD  CONSTRAINT [FK_Surveys.CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ServeyCategory] ([Id])
GO
ALTER TABLE [dbo].[Surveys] CHECK CONSTRAINT [FK_Surveys.CategoryId]
GO
ALTER TABLE [dbo].[Surveys]  WITH CHECK ADD  CONSTRAINT [FK_Surveys.CreateBy] FOREIGN KEY([CreateBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Surveys] CHECK CONSTRAINT [FK_Surveys.CreateBy]
GO
ALTER TABLE [dbo].[User_Progress]  WITH CHECK ADD  CONSTRAINT [FK_User_Progress.RateId] FOREIGN KEY([RateId])
REFERENCES [dbo].[Rate] ([Id])
GO
ALTER TABLE [dbo].[User_Progress] CHECK CONSTRAINT [FK_User_Progress.RateId]
GO
ALTER TABLE [dbo].[User_Progress]  WITH CHECK ADD  CONSTRAINT [FK_User_Progress_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_Progress] CHECK CONSTRAINT [FK_User_Progress_User]
GO
ALTER TABLE [dbo].[UserPrograms]  WITH CHECK ADD  CONSTRAINT [FK_UserPrograms.ProgramId] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[SupportPrograms] ([Id])
GO
ALTER TABLE [dbo].[UserPrograms] CHECK CONSTRAINT [FK_UserPrograms.ProgramId]
GO
ALTER TABLE [dbo].[UserPrograms]  WITH CHECK ADD  CONSTRAINT [FK_UserPrograms.UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserPrograms] CHECK CONSTRAINT [FK_UserPrograms.UserId]
GO
