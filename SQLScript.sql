Create database BasicApp

USE [BasicApp]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 03/08/2022 23:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserId] [nvarchar](20) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](20) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tblUser] ([UserId], [UserName], [Password]) VALUES (N'test@gmail.com', N'demo', N'1234')
/****** Object:  Table [dbo].[PageMetaDetail]    Script Date: 03/08/2022 23:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageMetaDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageUrl] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[MetaKeywords] [nvarchar](100) NULL,
	[MetaDescription] [nvarchar](100) NULL,
 CONSTRAINT [PK_PageMetaDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PageMetaDetail] ON
INSERT [dbo].[PageMetaDetail] ([ID], [PageUrl], [Title], [MetaKeywords], [MetaDescription]) VALUES (1, N'Home/Index', N'MVC Tutorials', N'mvc,tutorials,examples', N'High quality mvc tutorials and examples')
INSERT [dbo].[PageMetaDetail] ([ID], [PageUrl], [Title], [MetaKeywords], [MetaDescription]) VALUES (2, N'Home/About', N'About Our Company', N'about,about2,about3', N'All you need to know about our company')
INSERT [dbo].[PageMetaDetail] ([ID], [PageUrl], [Title], [MetaKeywords], [MetaDescription]) VALUES (3, N'Home/Contact', N'Need Help? Contact', N'contact,contact2,contact3', N'Any mvc realated question? contact us.')
INSERT [dbo].[PageMetaDetail] ([ID], [PageUrl], [Title], [MetaKeywords], [MetaDescription]) VALUES (4, N'Login/Index', N'Login Page', N'Login,signin', N'This is LogIn Page')
INSERT [dbo].[PageMetaDetail] ([ID], [PageUrl], [Title], [MetaKeywords], [MetaDescription]) VALUES (5, N'Login/ForgotPassword', N'ForgotPassword Page', N'ForgotPassword,forgot,password', N'This is ForgotPassword Page')
INSERT [dbo].[PageMetaDetail] ([ID], [PageUrl], [Title], [MetaKeywords], [MetaDescription]) VALUES (6, N'Login/Registration', N'Registration Page', N'Registration,Register,SignUp', N'This is Registration Page')
INSERT [dbo].[PageMetaDetail] ([ID], [PageUrl], [Title], [MetaKeywords], [MetaDescription]) VALUES (7, N'Education/Index', N'Education Page', N'Education,learn,books', N'This is Education Page')
SET IDENTITY_INSERT [dbo].[PageMetaDetail] OFF
/****** Object:  Table [dbo].[Advertisement]    Script Date: 03/08/2022 23:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Advertisement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Advertisement] ON
INSERT [dbo].[Advertisement] ([Id], [Description]) VALUES (1, N'On the first request to this action, the entire page is rendered dynamically and you’ll see both dates match. But when you refresh, only the lambda expression is called and is used to replace that portion of the cached view.')
INSERT [dbo].[Advertisement] ([Id], [Description]) VALUES (2, N'I have to thank Dmitry, our PUM and the first developer on ASP.NET way back in the day who pointed out this little known API method to me. :)')
INSERT [dbo].[Advertisement] ([Id], [Description]) VALUES (3, N'We will be looking into hopefully including this in v1 of ASP.NET MVC, but I make no guarantees.')
SET IDENTITY_INSERT [dbo].[Advertisement] OFF
