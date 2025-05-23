USE [master]
GO
/****** Object:  Database [AccountingForSupplies]    Script Date: 05.05.2025 16:26:28 ******/
CREATE DATABASE [AccountingForSupplies]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AccountingForSupplies', FILENAME = N'D:\SQL\MSSQL16.SQLEXPRESS\MSSQL\DATA\AccountingForSupplies.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AccountingForSupplies_log', FILENAME = N'D:\SQL\MSSQL16.SQLEXPRESS\MSSQL\DATA\AccountingForSupplies_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AccountingForSupplies] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AccountingForSupplies].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AccountingForSupplies] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET ARITHABORT OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AccountingForSupplies] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AccountingForSupplies] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AccountingForSupplies] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AccountingForSupplies] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AccountingForSupplies] SET  MULTI_USER 
GO
ALTER DATABASE [AccountingForSupplies] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AccountingForSupplies] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AccountingForSupplies] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AccountingForSupplies] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AccountingForSupplies] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AccountingForSupplies] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AccountingForSupplies] SET QUERY_STORE = ON
GO
ALTER DATABASE [AccountingForSupplies] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AccountingForSupplies]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 05.05.2025 16:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 05.05.2025 16:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 05.05.2025 16:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[CompanyId] [int] NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 05.05.2025 16:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 05.05.2025 16:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[PositionId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 05.05.2025 16:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[OrderStatusId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 05.05.2025 16:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalCost] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 05.05.2025 16:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 05.05.2025 16:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 05.05.2025 16:26:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Cost] [decimal](10, 2) NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Легкая')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Средняя')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'Тяжелая')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [Name]) VALUES (1, N'Москва')
INSERT [dbo].[City] ([Id], [Name]) VALUES (2, N'Санкт-Петербург')
INSERT [dbo].[City] ([Id], [Name]) VALUES (3, N'Новосибирск')
INSERT [dbo].[City] ([Id], [Name]) VALUES (4, N'Екатеринбург')
INSERT [dbo].[City] ([Id], [Name]) VALUES (5, N'Казань')
INSERT [dbo].[City] ([Id], [Name]) VALUES (6, N'Нижний Новгород')
INSERT [dbo].[City] ([Id], [Name]) VALUES (7, N'Челябинск')
INSERT [dbo].[City] ([Id], [Name]) VALUES (8, N'Самара')
INSERT [dbo].[City] ([Id], [Name]) VALUES (9, N'Омск')
INSERT [dbo].[City] ([Id], [Name]) VALUES (10, N'Ростов-на-Дону')
INSERT [dbo].[City] ([Id], [Name]) VALUES (11, N'Уфа')
INSERT [dbo].[City] ([Id], [Name]) VALUES (12, N'Красноярск')
INSERT [dbo].[City] ([Id], [Name]) VALUES (13, N'Воронеж')
INSERT [dbo].[City] ([Id], [Name]) VALUES (14, N'Пермь')
INSERT [dbo].[City] ([Id], [Name]) VALUES (15, N'Волгоград')
INSERT [dbo].[City] ([Id], [Name]) VALUES (16, N'Краснодар')
INSERT [dbo].[City] ([Id], [Name]) VALUES (17, N'Тюмень')
INSERT [dbo].[City] ([Id], [Name]) VALUES (18, N'Иркутск')
INSERT [dbo].[City] ([Id], [Name]) VALUES (19, N'Владивосток')
INSERT [dbo].[City] ([Id], [Name]) VALUES (20, N'Ярославль')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (1, N'Иванов', N'Иван', N'Иванович', 1, N'79161234567', N'ivanov@mail.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (2, N'Петров', N'Петр', N'Петрович', 2, N'79261234568', N'petrov@gmail.com')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (3, N'Сидоров', N'Алексей', N'Сергеевич', 3, N'79361234569', N'sidorov@yandex.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (4, N'Кузнецов', N'Дмитрий', N'Владимирович', 4, N'79461234570', N'kuznetsov@mail.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (5, N'Смирнов', N'Андрей', N'Николаевич', 5, N'79561234571', N'smirnov@gmail.com')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (6, N'Попов', N'Сергей', N'Александрович', 6, N'79661234572', N'popov@yandex.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (7, N'Васильев', N'Владимир', N'Игоревич', 7, N'79761234573', N'vasiliev@mail.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (8, N'Павлов', N'Николай', N'Павлович', 8, N'79861234574', N'pavlov@gmail.com')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (9, N'Семенов', N'Михаил', N'Дмитриевич', 9, N'79961234575', N'semenov@yandex.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (10, N'Голубев', N'Александр', N'Алексеевич', 10, N'79171234576', N'golubev@mail.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (11, N'Виноградов', N'Виктор', N'Викторович', 11, N'79271234577', N'vinogradov@gmail.com')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (12, N'Борисов', N'Олег', N'Борисович', 12, N'79371234578', N'borisov@yandex.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (13, N'Киселев', N'Артем', N'Артемович', 13, N'79471234579', N'kiselev@mail.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (14, N'Макаров', N'Евгений', N'Евгеньевич', 14, N'79571234580', N'makarov@gmail.com')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (15, N'Орлов', N'Константин', N'Константинович', 15, N'79671234581', N'orlov@yandex.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (16, N'Алексеев', N'Павел', N'Алексеевич', 16, N'79771234582', N'alekseev@mail.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (17, N'Николаев', N'Григорий', N'Николаевич', 17, N'79871234583', N'nikolaev@gmail.com')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (18, N'Захаров', N'Антон', N'Захарович', 18, N'79971234584', N'zaharov@yandex.ru')
INSERT [dbo].[Client] ([Id], [Surname], [FirstName], [MiddleName], [CompanyId], [PhoneNumber], [Email]) VALUES (19, N'Соловьев', N'Денис', N'Денисович', 19, N'79181234585', N'soloviev@mail.ru')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (1, N'ДомоГрад', 1)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (2, N'УютМаркет', 2)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (3, N'Бытовая Лавка', 3)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (4, N'Домашний Очаг', 4)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (5, N'ВсеДляДома', 5)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (6, N'Уютный Мир', 6)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (7, N'Дом и Уют', 7)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (8, N'БытТехника', 8)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (9, N'Домашний Комфорт', 9)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (10, N'Мир Уюта', 10)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (11, N'ДомоСфера', 11)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (12, N'Уютные Решения', 12)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (13, N'Домашний Рай', 13)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (14, N'Бытовая Планета', 14)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (15, N'Дом и Стиль', 15)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (16, N'Уютный Дом', 16)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (17, N'Домашний Стандарт', 17)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (18, N'Бытовая Гавань', 18)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (19, N'ДомоЛюкс', 19)
INSERT [dbo].[Company] ([Id], [Name], [CityId]) VALUES (20, N'Уют и Практичность', 20)
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (1, N'Козлов', N'Александр', N'Викторович', N'kozlov_a', N'123', 1)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (2, N'Новиков', N'Дмитрий', N'Анатольевич', N'novikov_d', N'123', 2)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (3, N'Медведев', N'Игорь', N'Олегович', N'medvedev_i', N'123', 3)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (4, N'Лебедев', N'Владислав', N'Сергеевич', N'lebedev_v', N'123', 4)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (5, N'Соколов', N'Роман', N'Дмитриевич', N'sokolov_r', N'123', 5)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (6, N'Волков', N'Артем', N'Ильич', N'volkov_a', N'123', 6)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (7, N'Зайцев', N'Евгений', N'Васильевич', N'zaitsev_e', N'123', 7)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (8, N'Егоров', N'Станислав', N'Геннадьевич', N'egorov_s', N'123', 8)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (9, N'Тимофеев', N'Глеб', N'Андреевич', N'timofeev_g', N'123', 9)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (10, N'Федоров', N'Кирилл', N'Павлович', N'fedorov_k', N'123', 10)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (11, N'Данилов', N'Антон', N'Владимирович', N'danilov_a', N'123', 11)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (12, N'Жуков', N'Максим', N'Алексеевич', N'zhukov_m', N'123', 12)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (13, N'Крылов', N'Никита', N'Иванович', N'krylov_n', N'123', 13)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (14, N'Савельев', N'Вадим', N'Сергеевич', N'savelyev_v', N'123', 14)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (15, N'Тихонов', N'Георгий', N'Николаевич', N'tikhonov_g', N'123', 15)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (16, N'Устинов', N'Олег', N'Денисович', N'ustinov_o', N'123', 16)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (17, N'Хохлов', N'Юрий', N'Викторович', N'khokhlov_y', N'123', 17)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (18, N'Цветков', N'Арсений', N'Анатольевич', N'tsvetkov_a', N'123', 18)
INSERT [dbo].[Employee] ([Id], [Surname], [FirstName], [MiddleName], [Login], [Password], [PositionId]) VALUES (19, N'Широков', N'Денис', N'Олегович', N'shirokov_d', N'123', 19)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 

INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (1, N'В очереди')
INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (2, N'В работе')
INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (3, N'Собран')
INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (4, N'Отправлен')
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([Id], [Name]) VALUES (1, N'Администратор склада')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (2, N'Директор склада')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (3, N'Администратор системы')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (4, N'Менеджер по поставкам')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (5, N'Складской работник')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (6, N'Бухгалтер')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (7, N'Аналитик')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (8, N'Технический специалист (IT-поддержка)')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (9, N'Руководитель отдела логистики')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (10, N'Кладовщик')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (11, N'Менеджер по работе с клиентами')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (12, N'Аудитор')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (13, N'Разработчик системы')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (14, N'Сотрудник отдела закупок')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (15, N'Сотрудник отдела качества')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (16, N'Логист')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (17, N'Сотрудник службы безопасности')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (18, N'Сотрудник отдела кадров')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (19, N'Менеджер по маркетингу')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (20, N'Сотрудник отдела документации')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (21, N'Оператор call-центра')
INSERT [dbo].[Position] ([Id], [Name]) VALUES (22, N'Сотрудник отдела развития')
SET IDENTITY_INSERT [dbo].[Position] OFF
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Company]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_City]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Position]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY([OrderStatusId])
REFERENCES [dbo].[OrderStatus] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_OrderStatus]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Order]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [AccountingForSupplies] SET  READ_WRITE 
GO
