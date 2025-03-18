
/****** Object:  Database [PE_PRN_24FallB1]    Script Date: 10/24/2024 9:06:31 AM ******/
CREATE DATABASE [PE_PRN_24FallB1]
go 
USE [PE_PRN_24FallB1]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 10/24/2024 9:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Bio] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthors]    Script Date: 10/24/2024 9:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthors](
	[BookID] [int] NOT NULL,
	[AuthorID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC,
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCopies]    Script Date: 10/24/2024 9:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCopies](
	[CopyID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NULL,
	[ISBN] [nvarchar](13) NULL,
	[EditionNumber] [int] NULL,
	[PrintYear] [int] NULL,
	[Condition] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CopyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 10/24/2024 9:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Publisher] [nvarchar](255) NULL,
	[PublicationYear] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowTransactions]    Script Date: 10/24/2024 9:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowTransactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[CopyID] [int] NOT NULL,
	[BorrowDate] [date] NOT NULL,
	[ReturnDate] [date] NULL,
 CONSTRAINT [PK__BorrowTr__55433A4B2AFD950C] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/24/2024 9:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[MembershipDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 
GO
INSERT [dbo].[Authors] ([AuthorID], [Name], [Bio]) VALUES (1, N'George Orwell', N'English novelist and essayist, journalist and critic.')
GO
INSERT [dbo].[Authors] ([AuthorID], [Name], [Bio]) VALUES (2, N'J.K. Rowling', N'British author, best known for the Harry Potter series.')
GO
INSERT [dbo].[Authors] ([AuthorID], [Name], [Bio]) VALUES (3, N'J.R.R. Tolkien', N'English writer, poet, philologist, and academic.')
GO
INSERT [dbo].[Authors] ([AuthorID], [Name], [Bio]) VALUES (4, N'Agatha Christie', N'English writer known for her sixty-six detective novels.')
GO
INSERT [dbo].[Authors] ([AuthorID], [Name], [Bio]) VALUES (5, N'Isaac Asimov', N'American writer and professor of biochemistry at Boston University.')
GO
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (1, 1)
GO
INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (1, 3)
GO
INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (2, 2)
GO
INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (2, 3)
GO
INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (3, 3)
GO
INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (4, 4)
GO
INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (5, 5)
GO
INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (6, 1)
GO
INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (7, 2)
GO
INSERT [dbo].[BookAuthors] ([BookID], [AuthorID]) VALUES (7, 5)
GO
SET IDENTITY_INSERT [dbo].[BookCopies] ON 
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (1, 1, N'9780451524935', 1, 1950, N'New')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (2, 1, N'9780451524936', 2, 1984, N'Slightly worn')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (3, 1, N'9780451524937', 3, 2003, N'Annotated')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (4, 2, N'9780747532743', 1, 1997, N'New')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (5, 2, N'9780747532744', 2, 2000, N'Good')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (6, 2, N'9780747532745', 3, 2003, N'Worn')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (7, 3, N'9780345339683', 1, 1937, N'New')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (8, 3, N'9780345339684', 2, 1954, N'Slightly worn')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (9, 3, N'9780345339685', 3, 2001, N'Annotated')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (10, 4, N'9780062073501', 1, 1934, N'New')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (11, 4, N'9780062073502', 2, 1945, N'Good')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (12, 4, N'9780062073503', 3, 1980, N'Slightly worn')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (13, 5, N'9780553293357', 1, 1951, N'New')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (14, 5, N'9780553293358', 2, 1985, N'Slightly worn')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (15, 5, N'9780553293359', 3, 2004, N'Annotated')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (16, 6, N'9780451526342', 1, 1945, N'New')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (17, 6, N'9780451526343', 2, 1961, N'Good')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (18, 6, N'9780451526344', 3, 2008, N'Slightly worn')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (19, 7, N'9780747538486', 1, 1998, N'New')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (20, 7, N'9780747538487', 2, 2002, N'Good')
GO
INSERT [dbo].[BookCopies] ([CopyID], [BookID], [ISBN], [EditionNumber], [PrintYear], [Condition]) VALUES (21, 7, N'9780747538488', 3, 2010, N'Annotated')
GO
SET IDENTITY_INSERT [dbo].[BookCopies] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([BookID], [Title], [Publisher], [PublicationYear]) VALUES (1, N'1984', N'Secker & Warburg', 1949)
GO
INSERT [dbo].[Books] ([BookID], [Title], [Publisher], [PublicationYear]) VALUES (2, N'Harry Potter and the Philosopher''s Stone', N'Bloomsbury', 1997)
GO
INSERT [dbo].[Books] ([BookID], [Title], [Publisher], [PublicationYear]) VALUES (3, N'The Hobbit', N'George Allen & Unwin', 1937)
GO
INSERT [dbo].[Books] ([BookID], [Title], [Publisher], [PublicationYear]) VALUES (4, N'Murder on the Orient Express', N'Collins Crime Club', 1934)
GO
INSERT [dbo].[Books] ([BookID], [Title], [Publisher], [PublicationYear]) VALUES (5, N'Foundation', N'Gnome Press', 1951)
GO
INSERT [dbo].[Books] ([BookID], [Title], [Publisher], [PublicationYear]) VALUES (6, N'Animal Farm', N'Secker & Warburg', 1945)
GO
INSERT [dbo].[Books] ([BookID], [Title], [Publisher], [PublicationYear]) VALUES (7, N'Harry Potter and the Chamber of Secrets', N'Bloomsbury', 1998)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[BorrowTransactions] ON 
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (13, 1, 1, CAST(N'2023-07-01' AS Date), CAST(N'2023-07-15' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (14, 1, 4, CAST(N'2023-08-01' AS Date), CAST(N'2023-08-10' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (15, 1, 7, CAST(N'2023-09-01' AS Date), CAST(N'2024-10-17' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (16, 2, 10, CAST(N'2023-06-01' AS Date), CAST(N'2023-06-20' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (17, 2, 11, CAST(N'2023-07-01' AS Date), CAST(N'2023-07-15' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (18, 2, 14, CAST(N'2023-08-01' AS Date), NULL)
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (19, 3, 15, CAST(N'2023-06-15' AS Date), CAST(N'2023-07-01' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (20, 3, 17, CAST(N'2023-08-15' AS Date), CAST(N'2023-09-01' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (21, 4, 18, CAST(N'2023-05-01' AS Date), CAST(N'2023-05-15' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (22, 4, 21, CAST(N'2023-06-01' AS Date), CAST(N'2023-06-15' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (23, 5, 2, CAST(N'2023-04-01' AS Date), CAST(N'2023-04-15' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (24, 5, 6, CAST(N'2023-05-01' AS Date), CAST(N'2023-05-15' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (25, 6, 9, CAST(N'2023-04-20' AS Date), CAST(N'2023-05-05' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (26, 6, 12, CAST(N'2023-05-25' AS Date), CAST(N'2023-06-10' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (27, 7, 13, CAST(N'2023-06-15' AS Date), CAST(N'2023-06-30' AS Date))
GO
INSERT [dbo].[BorrowTransactions] ([TransactionID], [UserID], [CopyID], [BorrowDate], [ReturnDate]) VALUES (28, 7, 16, CAST(N'2023-07-20' AS Date), CAST(N'2023-08-05' AS Date))
GO
SET IDENTITY_INSERT [dbo].[BorrowTransactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [MembershipDate]) VALUES (1, N'John Doe', N'john.doe@example.com', CAST(N'2021-01-10' AS Date))
GO
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [MembershipDate]) VALUES (2, N'Jane Smith', N'jane.smith@example.com', CAST(N'2021-02-15' AS Date))
GO
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [MembershipDate]) VALUES (3, N'Alice Johnson', N'alice.johnson@example.com', CAST(N'2021-03-20' AS Date))
GO
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [MembershipDate]) VALUES (4, N'Robert Brown', N'robert.brown@example.com', CAST(N'2021-04-25' AS Date))
GO
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [MembershipDate]) VALUES (5, N'Emily Davis', N'emily.davis@example.com', CAST(N'2021-05-30' AS Date))
GO
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [MembershipDate]) VALUES (6, N'Michael Wilson', N'michael.wilson@example.com', CAST(N'2021-06-05' AS Date))
GO
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [MembershipDate]) VALUES (7, N'Sophia Garcia', N'sophia.garcia@example.com', CAST(N'2021-07-10' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__BookCopi__447D36EA4432FD3F]    Script Date: 10/24/2024 9:06:31 AM ******/
ALTER TABLE [dbo].[BookCopies] ADD UNIQUE NONCLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534018726F9]    Script Date: 10/24/2024 9:06:31 AM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthors_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
GO
ALTER TABLE [dbo].[BookAuthors] CHECK CONSTRAINT [FK_BookAuthors_Authors]
GO
ALTER TABLE [dbo].[BookAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthors_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[BookAuthors] CHECK CONSTRAINT [FK_BookAuthors_Books]
GO
ALTER TABLE [dbo].[BookCopies]  WITH CHECK ADD  CONSTRAINT [FK_BookCopies_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[BookCopies] CHECK CONSTRAINT [FK_BookCopies_Books]
GO
ALTER TABLE [dbo].[BorrowTransactions]  WITH CHECK ADD  CONSTRAINT [FK_BorrowTransactions_BookCopies] FOREIGN KEY([CopyID])
REFERENCES [dbo].[BookCopies] ([CopyID])
GO
ALTER TABLE [dbo].[BorrowTransactions] CHECK CONSTRAINT [FK_BorrowTransactions_BookCopies]
GO
ALTER TABLE [dbo].[BorrowTransactions]  WITH CHECK ADD  CONSTRAINT [FK_BorrowTransactions_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[BorrowTransactions] CHECK CONSTRAINT [FK_BorrowTransactions_Users]
GO
USE [master]
GO
ALTER DATABASE [PE_PRN_24FallB1] SET  READ_WRITE 
GO
