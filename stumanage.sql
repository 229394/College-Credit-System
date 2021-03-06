USE [db_stumanage]
GO
/****** Object:  Table [dbo].[info]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[info](
	[权限] [nvarchar](50) NULL,
	[用户名] [nvarchar](50) NULL,
	[密码] [nvarchar](50) NULL,
	[学号] [nvarchar](50) NULL,
	[姓名] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[infoma]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[infoma](
	[权限] [nvarchar](50) NULL,
	[用户名] [nvarchar](50) NULL,
	[密码] [nvarchar](50) NULL,
	[学号] [nvarchar](50) NULL,
	[姓名] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[infomation]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[infomation](
	[权限] [nvarchar](50) NULL,
	[用户名] [nvarchar](50) NULL,
	[密码] [nvarchar](50) NULL,
	[学号] [nvarchar](50) NULL,
	[姓名] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_academy]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_academy](
	[AcademyID] [int] IDENTITY(1,1) NOT NULL,
	[AcademyName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tb_academy] PRIMARY KEY CLUSTERED 
(
	[AcademyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_admin]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AdminNumber] [varchar](20) NOT NULL,
	[AdminPwd] [varchar](20) NOT NULL,
	[AdminName] [varchar](20) NOT NULL,
	[AdminSex] [char](2) NULL,
 CONSTRAINT [PK_tb_admin] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_class]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](20) NULL,
	[AcademyID] [int] NOT NULL,
 CONSTRAINT [PK_tb_class] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_course]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseNum] [varchar](20) NOT NULL,
	[CourseName] [varchar](30) NOT NULL,
	[CourseCredit] [int] NULL,
	[CourseHour] [int] NULL,
	[NatureID] [int] NOT NULL,
	[AcademyID] [int] NOT NULL,
 CONSTRAINT [PK_tb_course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_coursetable]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_coursetable](
	[CouTableID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[Location] [varchar](30) NULL,
	[Period] [varchar](30) NULL,
	[TeacherID] [int] NOT NULL,
	[GradeID] [int] NULL,
 CONSTRAINT [PK_tb_coursetable] PRIMARY KEY CLUSTERED 
(
	[CouTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_electcourse]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_electcourse](
	[ElectID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
 CONSTRAINT [PK_tb_electcourse] PRIMARY KEY CLUSTERED 
(
	[ElectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_grade]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_grade](
	[GradeID] [int] IDENTITY(1,1) NOT NULL,
	[GradeName] [int] NOT NULL,
 CONSTRAINT [PK_tb_grade] PRIMARY KEY CLUSTERED 
(
	[GradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_nature]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_nature](
	[NatureID] [int] IDENTITY(1,1) NOT NULL,
	[NatureName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tb_nature] PRIMARY KEY CLUSTERED 
(
	[NatureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_notice]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_notice](
	[NoticeID] [int] IDENTITY(1,1) NOT NULL,
	[NoticeTitle] [varchar](20) NOT NULL,
	[NoticeContent] [varchar](100) NULL,
	[NoticeDate] [date] NOT NULL,
 CONSTRAINT [PK_tb_notice] PRIMARY KEY CLUSTERED 
(
	[NoticeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_student]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[StuNumber] [varchar](20) NOT NULL,
	[StuPwd] [varchar](20) NOT NULL,
	[StuName] [varchar](20) NULL,
	[StuSex] [char](2) NULL,
	[StuBirthday] [date] NULL,
	[AcademyID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[GradeID] [int] NOT NULL,
 CONSTRAINT [PK_tb_student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_stuscore]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_stuscore](
	[StuScoreID] [int] IDENTITY(1,1) NOT NULL,
	[GradeID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[Score] [int] NULL,
 CONSTRAINT [PK_tb_stuscore] PRIMARY KEY CLUSTERED 
(
	[StuScoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_teacher]    Script Date: 2019/4/28 20:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_teacher](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherNum] [varchar](20) NOT NULL,
	[TeacherPwd] [varchar](20) NOT NULL,
	[TeacherName] [varchar](20) NULL,
	[TeacherSex] [char](2) NULL,
	[AcademyID] [int] NOT NULL,
 CONSTRAINT [PK_tb_teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[info] ([权限], [用户名], [密码], [学号], [姓名]) VALUES (N'学生', N'6', N'1', N'2015110512', N'小明')
INSERT [dbo].[info] ([权限], [用户名], [密码], [学号], [姓名]) VALUES (N'教师', N'5', N'1', N'2015110513', N'老王')
SET IDENTITY_INSERT [dbo].[tb_academy] ON 

INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (1, N'大气科学学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (2, N'大气物理学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (3, N'电子与信息工程学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (4, N'地理与遥感学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (5, N'环境科学与工程学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (6, N'计算机与软件学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (7, N'经济管理学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (8, N'雷丁学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (9, N'滨江学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (10, N'文学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (11, N'商学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (12, N'应用气象学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (13, N'水文与气象学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (14, N'马克思主义学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (15, N'数学与统计学院')
INSERT [dbo].[tb_academy] ([AcademyID], [AcademyName]) VALUES (16, N'物理与光电工程学院')
SET IDENTITY_INSERT [dbo].[tb_academy] OFF
SET IDENTITY_INSERT [dbo].[tb_admin] ON 

INSERT [dbo].[tb_admin] ([AdminID], [AdminNumber], [AdminPwd], [AdminName], [AdminSex]) VALUES (1, N'admin', N'1234', N'夏雪', N'女')
SET IDENTITY_INSERT [dbo].[tb_admin] OFF
SET IDENTITY_INSERT [dbo].[tb_class] ON 

INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (1, N'气科1班', 1)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (2, N'气科2班', 1)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (3, N'气科3班', 1)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (4, N'软嵌1班', 6)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (5, N'软工1班', 6)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (6, N'软工2班', 6)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (7, N'软工3班', 6)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (8, N'计科1班', 6)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (9, N'计科2班', 6)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (10, N'计科3班', 6)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (11, N'网工1班', 6)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (12, N'网工2班', 6)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (13, N'气科4班', 1)
INSERT [dbo].[tb_class] ([ClassID], [ClassName], [AcademyID]) VALUES (14, N'气科5班', 1)
SET IDENTITY_INSERT [dbo].[tb_class] OFF
SET IDENTITY_INSERT [dbo].[tb_course] ON 

INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (1, N'850001', N'计算机组成原理', 5, 64, 3, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (2, N'850002', N'操作系统', 4, 64, 4, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (3, N'850003', N'专业英语', 2, 32, 5, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (4, N'850004', N'软件测试技术', 3, 48, 7, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (5, N'850005', N'马克思主义基本原理', 3, 48, 1, 14)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (6, N'850006', N'操作系统课程设计', 1, 16, 2, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (7, N'850007', N'气象信息系统工程', 2, 32, 5, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (8, N'850008', N'软件项目管理', 3, 48, 4, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (9, N'850009', N'Web技术与应用', 3, 48, 5, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (10, N'850010', N'J2EE架构(组件技术)', 2, 32, 5, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (11, N'850011', N'移动平台项目开发', 1, 16, 6, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (12, N'850012', N'计算机网络', 3, 48, 3, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (13, N'850013', N'数据库系统', 3, 48, 3, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (14, N'850014', N'软件需求分析', 3, 48, 7, 6)
INSERT [dbo].[tb_course] ([CourseID], [CourseNum], [CourseName], [CourseCredit], [CourseHour], [NatureID], [AcademyID]) VALUES (15, N'850015', N'.net平台开发', 2, 32, 5, 6)
SET IDENTITY_INSERT [dbo].[tb_course] OFF
SET IDENTITY_INSERT [dbo].[tb_coursetable] ON 

INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (1, 4, 9, N'西阶', N'周一1,2节', 1, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (2, 4, 3, N'明德N615', N'周一3,4节', 4, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (3, 4, 10, N'明德N615', N'周二5,6节', 5, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (4, 4, 7, N'明德S201', N'周三1,2节', 6, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (5, 4, 1, N'明德N605', N'周三3,4节', 9, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (6, 4, 5, N'明德N315', N'周三7,8节', 11, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (7, 4, 4, N'明德N215', N'周四1,2节', 15, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (8, 4, 8, N'明德N701', N'周四5,6节', 15, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (9, 4, 1, N'明德N605', N'周五1,2节', 9, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (10, 4, 2, N'明德N505', N'周五3,4节', 17, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (11, 4, 5, N'明德N515', N'周五5,6节', 11, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (13, 4, 3, N'西阶', N'周五7,8节', 4, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (14, 5, 9, N'西阶', N'周一1,2节', 1, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (15, 6, 9, N'西阶', N'周一1,2节', 1, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (16, 7, 9, N'西阶', N'周一1,2节', 1, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (17, 11, 9, N'明德S301', N'周四3,4节', 1, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (18, 12, 9, N'明德S301', N'周四3,4节', 1, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (19, 5, 7, N'明德S201', N'周三1,2节', 6, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (20, 6, 7, N'明德S201', N'周三1,2节', 6, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (21, 7, 7, N'明德S201', N'周三1,2节', 6, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (22, 8, 7, N'明德N415', N'周三7,8节', 6, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (23, 9, 7, N'明德N415', N'周三7,8节', 6, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (25, 10, 7, N'明德N415', N'周三7,8节', 6, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (29, 11, 7, N'明德N309', N'周一5,6节', 6, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (30, 12, 7, N'明德N309', N'周一5,6节', 6, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (31, 4, 15, N'明德N504', N'周二3,4节', 1, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (32, 5, 15, N'明德N504', N'周二3,4节', 1, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (33, 6, 15, N'明德N504', N'周二3,4节', 1, 2)
INSERT [dbo].[tb_coursetable] ([CouTableID], [ClassID], [CourseID], [Location], [Period], [TeacherID], [GradeID]) VALUES (34, 7, 15, N'明德N504', N'周二3,4节', 1, 2)
SET IDENTITY_INSERT [dbo].[tb_coursetable] OFF
SET IDENTITY_INSERT [dbo].[tb_electcourse] ON 

INSERT [dbo].[tb_electcourse] ([ElectID], [StudentID], [CourseID]) VALUES (1, 4, 1)
INSERT [dbo].[tb_electcourse] ([ElectID], [StudentID], [CourseID]) VALUES (2, 4, 2)
INSERT [dbo].[tb_electcourse] ([ElectID], [StudentID], [CourseID]) VALUES (4, 4, 4)
INSERT [dbo].[tb_electcourse] ([ElectID], [StudentID], [CourseID]) VALUES (5, 4, 5)
INSERT [dbo].[tb_electcourse] ([ElectID], [StudentID], [CourseID]) VALUES (7, 4, 10)
INSERT [dbo].[tb_electcourse] ([ElectID], [StudentID], [CourseID]) VALUES (1005, 4, 9)
INSERT [dbo].[tb_electcourse] ([ElectID], [StudentID], [CourseID]) VALUES (1006, 1, 3)
INSERT [dbo].[tb_electcourse] ([ElectID], [StudentID], [CourseID]) VALUES (1007, 1, 12)
SET IDENTITY_INSERT [dbo].[tb_electcourse] OFF
SET IDENTITY_INSERT [dbo].[tb_grade] ON 

INSERT [dbo].[tb_grade] ([GradeID], [GradeName]) VALUES (1, 2015)
INSERT [dbo].[tb_grade] ([GradeID], [GradeName]) VALUES (2, 2016)
INSERT [dbo].[tb_grade] ([GradeID], [GradeName]) VALUES (3, 2017)
INSERT [dbo].[tb_grade] ([GradeID], [GradeName]) VALUES (4, 2018)
SET IDENTITY_INSERT [dbo].[tb_grade] OFF
SET IDENTITY_INSERT [dbo].[tb_nature] ON 

INSERT [dbo].[tb_nature] ([NatureID], [NatureName]) VALUES (1, N'公共(必)')
INSERT [dbo].[tb_nature] ([NatureID], [NatureName]) VALUES (2, N'实践(必)')
INSERT [dbo].[tb_nature] ([NatureID], [NatureName]) VALUES (3, N'学科(必)')
INSERT [dbo].[tb_nature] ([NatureID], [NatureName]) VALUES (4, N'专业(必)')
INSERT [dbo].[tb_nature] ([NatureID], [NatureName]) VALUES (5, N'专业(选)')
INSERT [dbo].[tb_nature] ([NatureID], [NatureName]) VALUES (6, N'实践(选)')
INSERT [dbo].[tb_nature] ([NatureID], [NatureName]) VALUES (7, N'方向(选)')
SET IDENTITY_INSERT [dbo].[tb_nature] OFF
SET IDENTITY_INSERT [dbo].[tb_notice] ON 

INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (1, N'考研通知', N'12月22,23日两天考研，考研的同学提前熟悉考场！', CAST(0x193F0B00 AS Date))
INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (2, N'元旦放假通知', N'元旦放假安排为周日，周一，周二，周六正常上课！', CAST(0x193F0B00 AS Date))
INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (3, N'期末考试通知', N'期末将近，本学期期末考试计划已经安排，详见信息公告！', CAST(0x193F0B00 AS Date))
INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (4, N'寒假放假通知', N'本学期寒假预计从1月12日开始算起，放假到2月25日开学！', CAST(0x193F0B00 AS Date))
INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (5, N'下学期购书通知', N'下学期的教材开始预订了，大家可查看各自专业需要的教材！', CAST(0x193F0B00 AS Date))
INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (6, N'关于期末诚信考试通知', N'临近期末，希望同学们认真复习，严守考试纪律，杜绝作弊！', CAST(0x193F0B00 AS Date))
INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (7, N'图书馆开闭馆通知', N'临近期末，图书馆将于早上7:30开放，晚上10:00闭馆！', CAST(0x193F0B00 AS Date))
INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (8, N'教职工医疗报销通知', N'本学期统一安排教职工医疗报销，地点安排在学工处。', CAST(0x193F0B00 AS Date))
INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (9, N'关于学校食堂开放通知', N'本学期拟定在1月16日关闭各个食堂，仅保留教工食堂！', CAST(0x193F0B00 AS Date))
INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (10, N'英语4、6级考试提醒', N'本周末将进行英语4,6级考试，届时将封闭交通！', CAST(0x113F0B00 AS Date))
INSERT [dbo].[tb_notice] ([NoticeID], [NoticeTitle], [NoticeContent], [NoticeDate]) VALUES (1002, N'元旦节假', N'元旦假期3天！', CAST(0x263F0B00 AS Date))
SET IDENTITY_INSERT [dbo].[tb_notice] OFF
SET IDENTITY_INSERT [dbo].[tb_student] ON 

INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (1, N'20161398004', N'123456', N'大钱哥', N'男', CAST(0x59210B00 AS Date), 6, 4, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (2, N'20141398026', N'123456', N'涛涛', N'男', CAST(0x521E0B00 AS Date), 6, 4, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (3, N'20161398003', N'123456', N'阿盛', N'男', CAST(0x86220B00 AS Date), 6, 4, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (4, N'20161398013', N'123456', N'叶子', N'女', CAST(0x1C210B00 AS Date), 6, 4, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (5, N'20161344001', N'123456', N'浩浩', N'女', CAST(0x5F210B00 AS Date), 6, 5, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (6, N'20161344007', N'123456', N'小刘', N'男', CAST(0xEB210B00 AS Date), 6, 5, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (7, N'20161344044', N'123456', N'小洁', N'女', CAST(0xFA200B00 AS Date), 6, 6, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (8, N'20161344100', N'123456', N'小舒', N'男', CAST(0x5D220B00 AS Date), 6, 7, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (9, N'20171326012', N'123456', N'小草莓', N'女', CAST(0x571F0B00 AS Date), 6, 9, 3)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (10, N'20151398002', N'123456', N'小月', N'女', CAST(0x8D1F0B00 AS Date), 6, 4, 1)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (11, N'20151344004', N'123456', N'小肥猫', N'男', CAST(0x3B200B00 AS Date), 6, 5, 1)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (12, N'20151344028', N'123456', N'李建', N'男', CAST(0xDA200B00 AS Date), 6, 5, 1)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (13, N'20151344050', N'123456', N'小蜗牛', N'男', CAST(0x3B210B00 AS Date), 6, 6, 1)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (15, N'20151344100', N'123456', N'咖啡毛', N'女', CAST(0x7C200B00 AS Date), 6, 7, 1)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (17, N'20171234001', N'123456', N'阿毛', N'女', CAST(0x4F210B00 AS Date), 1, 1, 3)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (18, N'20171234038', N'123456', N'李达', N'男', CAST(0x15230B00 AS Date), 1, 2, 3)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (19, N'20171234078', N'123456', N'王思聪', N'男', CAST(0xD9220B00 AS Date), 1, 3, 3)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (20, N'20181234122', N'123456', N'崔彩蝶', N'女', CAST(0x22250B00 AS Date), 1, 13, 4)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (22, N'20181234158', N'123456', N'李如同', N'女', CAST(0xC4240B00 AS Date), 1, 14, 4)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (25, N'20161338001', N'123456', N'理想', N'男', CAST(0xA7210B00 AS Date), 6, 11, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (26, N'20161338048', N'123456', N'顾顾', N'女', CAST(0x21210B00 AS Date), 6, 12, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (28, N'20161326046', N'123456', N'张姿', N'女', CAST(0xE9210B00 AS Date), 6, 8, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (29, N'20161326005', N'123456', N'李军', N'男', CAST(0xFB200B00 AS Date), 6, 9, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (30, N'20161326098', N'123456', N'赵雷', N'男', CAST(0x32210B00 AS Date), 6, 10, 2)
INSERT [dbo].[tb_student] ([StudentID], [StuNumber], [StuPwd], [StuName], [StuSex], [StuBirthday], [AcademyID], [ClassID], [GradeID]) VALUES (31, N'20161338004', N'123456', N'赵蕾', N'女', CAST(0x1F210B00 AS Date), 6, 11, 2)
SET IDENTITY_INSERT [dbo].[tb_student] OFF
SET IDENTITY_INSERT [dbo].[tb_stuscore] ON 

INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (1, 2, 4, 4, 1, 87)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (2, 2, 4, 4, 2, 92)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (4, 2, 4, 4, 3, 65)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (5, 2, 4, 4, 4, 75)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (6, 2, 4, 4, 5, 85)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (7, 2, 4, 4, 6, 75)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (8, 2, 4, 4, 7, 78)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (9, 2, 4, 4, 8, 55)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (10, 2, 4, 4, 10, 95)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (11, 2, 4, 4, 12, 54)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (12, 2, 4, 4, 13, 67)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (13, 2, 4, 4, 14, 95)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (15, 2, 4, 4, 9, 78)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (16, 2, 4, 4, 11, 91)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (18, 2, 4, 1, 9, 78)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (22, 2, 4, 2, 9, 40)
INSERT [dbo].[tb_stuscore] ([StuScoreID], [GradeID], [ClassID], [StudentID], [CourseID], [Score]) VALUES (23, 2, 4, 3, 9, 44)
SET IDENTITY_INSERT [dbo].[tb_stuscore] OFF
SET IDENTITY_INSERT [dbo].[tb_teacher] ON 

INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (1, N'951001', N'1234', N'田心', N'男', 6)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (4, N'951002', N'123456', N'赵罗龙', N'男', 6)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (5, N'951003', N'123456', N'王先胜', N'男', 6)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (6, N'951004', N'123456', N'陈美华', N'女', 6)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (7, N'951005', N'123456', N'张美丽', N'女', 6)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (9, N'951008', N'123456', N'杨启明', N'男', 3)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (10, N'541001', N'123456', N'陈东升', N'男', 1)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (11, N'541002', N'123456', N'陈晓', N'女', 1)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (13, N'541003', N'123456', N'毛飞燕', N'女', 1)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (15, N'541004', N'123456', N'李丽', N'女', 1)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (16, N'541005', N'123456', N'张丽', N'女', 1)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (17, N'541006', N'123456', N'赵成功', N'男', 1)
INSERT [dbo].[tb_teacher] ([TeacherID], [TeacherNum], [TeacherPwd], [TeacherName], [TeacherSex], [AcademyID]) VALUES (18, N'531002', N'123456', N'阿汤哥', N'男', 2)
SET IDENTITY_INSERT [dbo].[tb_teacher] OFF
ALTER TABLE [dbo].[tb_notice] ADD  CONSTRAINT [DF_tb_notice_NoticeDate]  DEFAULT (getdate()) FOR [NoticeDate]
GO
ALTER TABLE [dbo].[tb_stuscore] ADD  CONSTRAINT [DF_tb_stuscore_Score]  DEFAULT ((0)) FOR [Score]
GO
