USE [ArticleDB]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 13.08.2020 17:26:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[Tags] [nvarchar](max) NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdateBy] [int] NULL,
	[LastUpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 13.08.2020 17:26:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13.08.2020 17:26:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdateBy] [int] NULL,
	[LastUpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [Title], [Body], [Image], [Tags], [Status], [CreatedBy], [CreatedDate], [LastUpdateBy], [LastUpdateDate]) VALUES (1, N'Front-end frameworks', N'body', N'link', N'#react, #angular', 1, 1, CAST(N'2020-04-23T18:25:43.510' AS DateTime), 0, NULL)
SET IDENTITY_INSERT [dbo].[Articles] OFF
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [Text], [ArticleId], [Status], [CreatedBy], [CreatedDate]) VALUES (1, N'Thank you!', 1, 1, 1, CAST(N'2020-04-23T18:25:43.510' AS DateTime))
INSERT [dbo].[Comments] ([Id], [Text], [ArticleId], [Status], [CreatedBy], [CreatedDate]) VALUES (2, N'Nice work', 1, 1, 1, CAST(N'2020-04-23T18:25:43.510' AS DateTime))
INSERT [dbo].[Comments] ([Id], [Text], [ArticleId], [Status], [CreatedBy], [CreatedDate]) VALUES (3, N'Helpfull', 1, 1, 1, CAST(N'2020-04-23T18:25:43.510' AS DateTime))
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Name], [Surname], [Email], [Status], [CreatedBy], [CreatedDate], [LastUpdateBy], [LastUpdateDate]) VALUES (1, N'hasan.yilmaz', N'Hasan Sefa', N'Yılmaz', N'hasansefayilmaz@gmail.com', 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
