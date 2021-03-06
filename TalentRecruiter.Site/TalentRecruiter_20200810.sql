USE [TalentRecruiter]
GO
/****** Object:  StoredProcedure [dbo].[TalentRecruiter_TechnologyDetailFromById]    Script Date: 10/08/2020 1:05:36 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TalentRecruiter_TechnologyDetailFromById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TalentRecruiter_TechnologyDetailFromById]
GO
/****** Object:  StoredProcedure [dbo].[TalentRecruiter_SP_GenerateClassByTableName]    Script Date: 10/08/2020 1:05:36 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TalentRecruiter_SP_GenerateClassByTableName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TalentRecruiter_SP_GenerateClassByTableName]
GO
/****** Object:  StoredProcedure [dbo].[TalentRecruiter_InterviewSearch]    Script Date: 10/08/2020 1:05:36 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TalentRecruiter_InterviewSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TalentRecruiter_InterviewSearch]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TecnologyDetail_Tecnology]') AND parent_object_id = OBJECT_ID(N'[dbo].[TechnologyDetail]'))
ALTER TABLE [dbo].[TechnologyDetail] DROP CONSTRAINT [FK_TecnologyDetail_Tecnology]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Interview_TechnologyDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[Interview]'))
ALTER TABLE [dbo].[Interview] DROP CONSTRAINT [FK_Interview_TechnologyDetail]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Interview_InterviewType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Interview]'))
ALTER TABLE [dbo].[Interview] DROP CONSTRAINT [FK_Interview_InterviewType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Interview_Interview]') AND parent_object_id = OBJECT_ID(N'[dbo].[Interview]'))
ALTER TABLE [dbo].[Interview] DROP CONSTRAINT [FK_Interview_Interview]
GO
/****** Object:  Table [dbo].[TechnologyDetail]    Script Date: 10/08/2020 1:05:36 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TechnologyDetail]') AND type in (N'U'))
DROP TABLE [dbo].[TechnologyDetail]
GO
/****** Object:  Table [dbo].[Technology ]    Script Date: 10/08/2020 1:05:36 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Technology ]') AND type in (N'U'))
DROP TABLE [dbo].[Technology ]
GO
/****** Object:  Table [dbo].[InterviewType]    Script Date: 10/08/2020 1:05:36 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterviewType]') AND type in (N'U'))
DROP TABLE [dbo].[InterviewType]
GO
/****** Object:  Table [dbo].[Interview]    Script Date: 10/08/2020 1:05:36 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Interview]') AND type in (N'U'))
DROP TABLE [dbo].[Interview]
GO
/****** Object:  Table [dbo].[Candidate]    Script Date: 10/08/2020 1:05:36 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Candidate]') AND type in (N'U'))
DROP TABLE [dbo].[Candidate]
GO
/****** Object:  Table [dbo].[Candidate]    Script Date: 10/08/2020 1:05:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Candidate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Candidate](
	[CandidateId] [int] NOT NULL,
	[CandidateName] [nvarchar](500) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[CandidateEmail] [nvarchar](500) NOT NULL,
	[Street] [nvarchar](100) NULL,
	[Suite] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[ZipCode] [nvarchar](100) NULL,
	[GeoLat] [nvarchar](100) NULL,
	[GeoIng] [nvarchar](100) NULL,
	[Phone] [nvarchar](100) NOT NULL,
	[Website] [nvarchar](100) NULL,
	[CompanyName] [nvarchar](100) NULL,
	[CompanyCatchPhrase] [nvarchar](100) NULL,
	[CompanyBs] [nvarchar](100) NULL,
 CONSTRAINT [PK_Candidate] PRIMARY KEY CLUSTERED 
(
	[CandidateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Interview]    Script Date: 10/08/2020 1:05:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Interview]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Interview](
	[InterviewId] [int] IDENTITY(1,1) NOT NULL,
	[CandidateId] [int] NOT NULL,
	[TechnologyDetailId] [int] NOT NULL,
	[InterviewStartTime] [datetime] NOT NULL,
	[InterviewFinalTime] [datetime] NULL,
	[TypeInterviewId] [int] NOT NULL,
	[Observation] [nvarchar](500) NULL,
	[DateCreation] [datetime] NULL CONSTRAINT [DF_Interview_DateCreation]  DEFAULT (getdate()),
	[DateUpdate] [datetime] NULL,
 CONSTRAINT [PK_Interview] PRIMARY KEY CLUSTERED 
(
	[InterviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[InterviewType]    Script Date: 10/08/2020 1:05:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterviewType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[InterviewType](
	[TypeInterviewId] [int] IDENTITY(1,1) NOT NULL,
	[TypeInterviewDescripction] [nvarchar](50) NULL,
 CONSTRAINT [PK_InterviewType] PRIMARY KEY CLUSTERED 
(
	[TypeInterviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Technology ]    Script Date: 10/08/2020 1:05:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Technology ]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Technology ](
	[TechnologyId] [int] IDENTITY(1,1) NOT NULL,
	[TechnologyDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tecnology] PRIMARY KEY CLUSTERED 
(
	[TechnologyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TechnologyDetail]    Script Date: 10/08/2020 1:05:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TechnologyDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TechnologyDetail](
	[TechnologyDetailId] [int] IDENTITY(1,1) NOT NULL,
	[TechnologyId] [int] NULL,
	[TechnologyDescription] [nvarchar](50) NULL,
	[TechnologyOrderId] [int] NULL,
 CONSTRAINT [PK_TecnologyDetail] PRIMARY KEY CLUSTERED 
(
	[TechnologyDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[Candidate] ([CandidateId], [CandidateName], [UserName], [CandidateEmail], [Street], [Suite], [City], [ZipCode], [GeoLat], [GeoIng], [Phone], [Website], [CompanyName], [CompanyCatchPhrase], [CompanyBs]) VALUES (1, N'Leanne Graham', N'Bret', N'Sincere@april.biz', N'Kulas Light', N'Apt. 556', N'Gwenborough', N'92998-3874', N'-37.3159', N'81.1496', N'1-770-736-8031 x56442', N'hildegard.org', N'Romaguera-Crona', N'Multi-layered client-server neural-net', N'harness real-time e-markets')
GO
INSERT [dbo].[Candidate] ([CandidateId], [CandidateName], [UserName], [CandidateEmail], [Street], [Suite], [City], [ZipCode], [GeoLat], [GeoIng], [Phone], [Website], [CompanyName], [CompanyCatchPhrase], [CompanyBs]) VALUES (5, N'Chelsey Dietrich', N'Kamren', N'Lucio_Hettinger@annie.ca', N'Skiles Walks', N'Suite 351', N'Roscoeview', N'33263', N'-31.8129', N'62.5342', N'(254)954-1289', N'demarco.info', N'Keebler LLC', N'User-centric fault-tolerant solution', N'revolutionize end-to-end systems')
GO
INSERT [dbo].[Candidate] ([CandidateId], [CandidateName], [UserName], [CandidateEmail], [Street], [Suite], [City], [ZipCode], [GeoLat], [GeoIng], [Phone], [Website], [CompanyName], [CompanyCatchPhrase], [CompanyBs]) VALUES (7, N'Kurtis Weissnat', N'Elwyn.Skiles', N'Telly.Hoeger@billy.biz', N'Rex Trail', N'Suite 280', N'Howemouth', N'58804-1099', N'24.8918', N'21.8984', N'210.067.6132', N'elvis.io', N'Johns Group', N'Configurable multimedia task-force', N'generate enterprise e-tailers')
GO
SET IDENTITY_INSERT [dbo].[Interview] ON 

GO
INSERT [dbo].[Interview] ([InterviewId], [CandidateId], [TechnologyDetailId], [InterviewStartTime], [InterviewFinalTime], [TypeInterviewId], [Observation], [DateCreation], [DateUpdate]) VALUES (1, 5, 1, CAST(N'2020-08-10 11:10:00.000' AS DateTime), CAST(N'2020-08-10 12:00:00.000' AS DateTime), 1, NULL, CAST(N'2020-08-10 11:10:49.337' AS DateTime), NULL)
GO
INSERT [dbo].[Interview] ([InterviewId], [CandidateId], [TechnologyDetailId], [InterviewStartTime], [InterviewFinalTime], [TypeInterviewId], [Observation], [DateCreation], [DateUpdate]) VALUES (2, 7, 1, CAST(N'2020-08-10 12:01:00.000' AS DateTime), CAST(N'2020-08-10 13:00:00.000' AS DateTime), 1, NULL, CAST(N'2020-08-10 11:11:18.700' AS DateTime), NULL)
GO
INSERT [dbo].[Interview] ([InterviewId], [CandidateId], [TechnologyDetailId], [InterviewStartTime], [InterviewFinalTime], [TypeInterviewId], [Observation], [DateCreation], [DateUpdate]) VALUES (3, 1, 1, CAST(N'2020-08-10 13:01:00.000' AS DateTime), CAST(N'2020-08-10 14:00:00.000' AS DateTime), 3, N'conectarse por teams', CAST(N'2020-08-10 12:55:23.143' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Interview] OFF
GO
SET IDENTITY_INSERT [dbo].[InterviewType] ON 

GO
INSERT [dbo].[InterviewType] ([TypeInterviewId], [TypeInterviewDescripction]) VALUES (1, N'Presencial')
GO
INSERT [dbo].[InterviewType] ([TypeInterviewId], [TypeInterviewDescripction]) VALUES (2, N'Telefónica')
GO
INSERT [dbo].[InterviewType] ([TypeInterviewId], [TypeInterviewDescripction]) VALUES (3, N'Remota')
GO
SET IDENTITY_INSERT [dbo].[InterviewType] OFF
GO
SET IDENTITY_INSERT [dbo].[Technology ] ON 

GO
INSERT [dbo].[Technology ] ([TechnologyId], [TechnologyDescription]) VALUES (1, N'.NET')
GO
INSERT [dbo].[Technology ] ([TechnologyId], [TechnologyDescription]) VALUES (2, N'JAVA')
GO
SET IDENTITY_INSERT [dbo].[Technology ] OFF
GO
SET IDENTITY_INSERT [dbo].[TechnologyDetail] ON 

GO
INSERT [dbo].[TechnologyDetail] ([TechnologyDetailId], [TechnologyId], [TechnologyDescription], [TechnologyOrderId]) VALUES (1, 1, N'Asp.Net', 1)
GO
INSERT [dbo].[TechnologyDetail] ([TechnologyDetailId], [TechnologyId], [TechnologyDescription], [TechnologyOrderId]) VALUES (2, 1, N'MVVM', 2)
GO
INSERT [dbo].[TechnologyDetail] ([TechnologyDetailId], [TechnologyId], [TechnologyDescription], [TechnologyOrderId]) VALUES (3, 1, N'Ado.Net', 3)
GO
INSERT [dbo].[TechnologyDetail] ([TechnologyDetailId], [TechnologyId], [TechnologyDescription], [TechnologyOrderId]) VALUES (4, 1, N'Entity FrameWork', 4)
GO
INSERT [dbo].[TechnologyDetail] ([TechnologyDetailId], [TechnologyId], [TechnologyDescription], [TechnologyOrderId]) VALUES (5, 1, N'LinQ', 5)
GO
INSERT [dbo].[TechnologyDetail] ([TechnologyDetailId], [TechnologyId], [TechnologyDescription], [TechnologyOrderId]) VALUES (6, 2, N'Java Server Pages', 1)
GO
INSERT [dbo].[TechnologyDetail] ([TechnologyDetailId], [TechnologyId], [TechnologyDescription], [TechnologyOrderId]) VALUES (7, 2, N'Java Server Faces', 2)
GO
INSERT [dbo].[TechnologyDetail] ([TechnologyDetailId], [TechnologyId], [TechnologyDescription], [TechnologyOrderId]) VALUES (8, 2, N'Enterprise Java Beans', 3)
GO
INSERT [dbo].[TechnologyDetail] ([TechnologyDetailId], [TechnologyId], [TechnologyDescription], [TechnologyOrderId]) VALUES (9, 2, N'Java Persistence Api', 4)
GO
INSERT [dbo].[TechnologyDetail] ([TechnologyDetailId], [TechnologyId], [TechnologyDescription], [TechnologyOrderId]) VALUES (10, 2, N'Java Messaging Services', 5)
GO
SET IDENTITY_INSERT [dbo].[TechnologyDetail] OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Interview_Interview]') AND parent_object_id = OBJECT_ID(N'[dbo].[Interview]'))
ALTER TABLE [dbo].[Interview]  WITH CHECK ADD  CONSTRAINT [FK_Interview_Interview] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[Candidate] ([CandidateId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Interview_Interview]') AND parent_object_id = OBJECT_ID(N'[dbo].[Interview]'))
ALTER TABLE [dbo].[Interview] CHECK CONSTRAINT [FK_Interview_Interview]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Interview_InterviewType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Interview]'))
ALTER TABLE [dbo].[Interview]  WITH CHECK ADD  CONSTRAINT [FK_Interview_InterviewType] FOREIGN KEY([TypeInterviewId])
REFERENCES [dbo].[InterviewType] ([TypeInterviewId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Interview_InterviewType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Interview]'))
ALTER TABLE [dbo].[Interview] CHECK CONSTRAINT [FK_Interview_InterviewType]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Interview_TechnologyDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[Interview]'))
ALTER TABLE [dbo].[Interview]  WITH CHECK ADD  CONSTRAINT [FK_Interview_TechnologyDetail] FOREIGN KEY([TechnologyDetailId])
REFERENCES [dbo].[TechnologyDetail] ([TechnologyDetailId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Interview_TechnologyDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[Interview]'))
ALTER TABLE [dbo].[Interview] CHECK CONSTRAINT [FK_Interview_TechnologyDetail]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TecnologyDetail_Tecnology]') AND parent_object_id = OBJECT_ID(N'[dbo].[TechnologyDetail]'))
ALTER TABLE [dbo].[TechnologyDetail]  WITH CHECK ADD  CONSTRAINT [FK_TecnologyDetail_Tecnology] FOREIGN KEY([TechnologyId])
REFERENCES [dbo].[Technology ] ([TechnologyId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TecnologyDetail_Tecnology]') AND parent_object_id = OBJECT_ID(N'[dbo].[TechnologyDetail]'))
ALTER TABLE [dbo].[TechnologyDetail] CHECK CONSTRAINT [FK_TecnologyDetail_Tecnology]
GO
/****** Object:  StoredProcedure [dbo].[TalentRecruiter_InterviewSearch]    Script Date: 10/08/2020 1:05:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TalentRecruiter_InterviewSearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TalentRecruiter_InterviewSearch] AS' 
END
GO
-- ==========================================================================================
-- Author:		JUAN RICARDO DIAZ S
-- Create date: 2020-08-08
-- Description:	CONSULTA LA INFORMACION DE LA TABLA Interview POR FECHA DE ENTREVISTA Y TIPO DE ENTREVISTA
-- EJEMPLOS:
-- EXEC TalentRecruiter_InterviewSearch -- ALL
-- ==========================================================================================
ALTER PROCEDURE [dbo].[TalentRecruiter_InterviewSearch] @InterviewTime   DATE = NULL, 
                                                        @TypeInterviewId INT  = NULL, 
                                                        @InterviewId     INT  = NULL
AS
    BEGIN
        -- ==========================================================================================
        SELECT i.InterviewId, 
               i.CandidateId, 
               i.InterviewStartTime, 
               i.InterviewFinalTime, 
               i.TechnologyDetailId, 
               i.TypeInterviewId, 
               i.DateCreation, 
               i.DateUpdate, 
               i.Observation, 
               split = NULL, 
               c.CandidateId, 
               c.CandidateName, 
               c.UserName, 
               c.CandidateEmail, 
               c.Street, 
               c.Suite, 
               c.City, 
               c.ZipCode, 
               c.GeoLat, 
               c.GeoIng, 
               c.Phone, 
               c.Website, 
               c.CompanyName, 
               c.CompanyCatchPhrase, 
               c.CompanyBs, 
               split = NULL, 
               it.TypeInterviewId, 
               it.TypeInterviewDescripction, 
               split = NULL, 
               td.TechnologyDetailId, 
               td.TechnologyId, 
               td.TechnologyDescription, 
               td.TechnologyOrderId, 
               split = NULL, 
               t.TechnologyId, 
               t.TechnologyDescription
        FROM Interview i
             JOIN Candidate c ON i.CandidateId = c.CandidateId
             JOIN InterviewType it ON i.TypeInterviewId = it.TypeInterviewId
             JOIN TechnologyDetail td ON i.TechnologyDetailId = td.TechnologyDetailId
             JOIN [Technology] t ON td.TechnologyId = t.TechnologyId
        WHERE((CAST(i.InterviewStartTime AS DATE) = @InterviewTime
               OR @InterviewTime IS NULL)
              OR (CAST(i.InterviewFinalTime AS DATE) = @InterviewTime
                  OR @InterviewTime IS NULL))
             AND (i.TypeInterviewId = @TypeInterviewId
                  OR @TypeInterviewId IS NULL)
             AND (i.InterviewId = @InterviewId
                  OR @InterviewId IS NULL);

        -- ==========================================================================================
    END;
GO
/****** Object:  StoredProcedure [dbo].[TalentRecruiter_SP_GenerateClassByTableName]    Script Date: 10/08/2020 1:05:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TalentRecruiter_SP_GenerateClassByTableName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TalentRecruiter_SP_GenerateClassByTableName] AS' 
END
GO
-- ==============================================================================================
-- Author:		JUAN RICARDO DIAZ S
-- Create date: 2020-03-08
-- Description:	FUNCION PARA IMPRIMIR LAS PROPIEDADES DE UNA TABLA
-- EJEMPLOS:
-- EXEC TalentRecruiter_SP_GenerateClassByTableName @TableName='Customer'
-- ==============================================================================================
ALTER PROCEDURE [dbo].[TalentRecruiter_SP_GenerateClassByTableName] @TableName VARCHAR(100), 
                                                                     @NameSpace VARCHAR(100) = NULL
AS
    BEGIN
        -- ==============================================================================================
        SET NOCOUNT ON;
        DECLARE @Result VARCHAR(MAX)= 'using Dapper;' + CHAR(10);
        SELECT @Result = @result + 'using System;' + CHAR(10) + CHAR(10);
        IF @NameSpace IS NOT NULL
            BEGIN
                SELECT @Result = @Result + 'namespace ' + @NameSpace + CHAR(10) + '{' + CHAR(10) + CHAR(10);
        END;
        SELECT @result = @result + '[Table("' + @TableName + '")]' + CHAR(10);
        SELECT @Result = @result + 'public class ' + @TableName + '
{' + CHAR(10);
        -- ==============================================================================================
        SELECT @Result = @Result + '    [Column("' + ColumnName + '")]  
    public ' + ColumnType + NullableSign + ' ' + ColumnName + ' { get; set; }
' + CHAR(10)
        FROM
        (
            SELECT replace(col.name, ' ', '_') ColumnName, 
                   column_id ColumnId,
                   CASE typ.name
                       WHEN 'bigint'
                       THEN 'long'
                       WHEN 'binary'
                       THEN 'byte[]'
                       WHEN 'bit'
                       THEN 'bool'
                       WHEN 'char'
                       THEN 'string'
                       WHEN 'date'
                       THEN 'DateTime'
                       WHEN 'datetime'
                       THEN 'DateTime'
                       WHEN 'datetime2'
                       THEN 'DateTime'
                       WHEN 'datetimeoffset'
                       THEN 'DateTimeOffset'
                       WHEN 'decimal'
                       THEN 'decimal'
                       WHEN 'float'
                       THEN 'double'
                       WHEN 'image'
                       THEN 'byte[]'
                       WHEN 'int'
                       THEN 'int'
                       WHEN 'money'
                       THEN 'decimal'
                       WHEN 'nchar'
                       THEN 'string'
                       WHEN 'ntext'
                       THEN 'string'
                       WHEN 'numeric'
                       THEN 'decimal'
                       WHEN 'nvarchar'
                       THEN 'string'
                       WHEN 'real'
                       THEN 'float'
                       WHEN 'smalldatetime'
                       THEN 'DateTime'
                       WHEN 'smallint'
                       THEN 'short'
                       WHEN 'smallmoney'
                       THEN 'decimal'
                       WHEN 'text'
                       THEN 'string'
                       WHEN 'time'
                       THEN 'TimeSpan'
                       WHEN 'timestamp'
                       THEN 'long'
                       WHEN 'tinyint'
                       THEN 'byte'
                       WHEN 'uniqueidentifier'
                       THEN 'Guid'
                       WHEN 'varbinary'
                       THEN 'byte[]'
                       WHEN 'varchar'
                       THEN 'string'
                       ELSE 'UNKNOWN_' + typ.name
                   END ColumnType,
                   CASE
                       WHEN col.is_nullable = 1
                            AND typ.name IN('bigint', 'bit', 'date', 'datetime', 'datetime2', 'datetimeoffset', 'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime', 'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier')
                       THEN '?'
                       ELSE ''
                   END NullableSign
            FROM sys.columns col
                 JOIN sys.types typ ON col.system_type_id = typ.system_type_id
                                       AND col.user_type_id = typ.user_type_id
            WHERE object_id = OBJECT_ID(@TableName)
        ) t
        ORDER BY ColumnId;
        SET @Result = @Result + '
}';
        IF @NameSpace IS NOT NULL
            BEGIN
                SELECT @Result = @Result + CHAR(10) + '}';
        END;
        -- ==============================================================================================
        PRINT @Result;
    END;
GO
/****** Object:  StoredProcedure [dbo].[TalentRecruiter_TechnologyDetailFromById]    Script Date: 10/08/2020 1:05:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TalentRecruiter_TechnologyDetailFromById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TalentRecruiter_TechnologyDetailFromById] AS' 
END
GO
-- =============================================
-- Author:		JUAN RICARDO DIAZ S
-- Create date: 2020-08-08
-- Description:	CONSULTA EL DETALLE DE TECNOLOGIA Y SU TECNOLOGIA ASOCIADA
-- EJEMPLOS:
-- EXEC TalentRecruiter_TechnologyDetailFromById @TechnologyDetailId = 1
-- =============================================
ALTER PROCEDURE [dbo].[TalentRecruiter_TechnologyDetailFromById] @TechnologyDetailId INT = NULL
AS
    BEGIN
        SELECT td.TechnologyDetailId, 
               td.TechnologyId, 
               td.TechnologyDescription, 
               td.TechnologyOrderId, 
               split = NULL, 
               t.TechnologyId, 
               t.TechnologyDescription
        FROM TechnologyDetail td
             JOIN [Technology] t ON td.TechnologyId = t.TechnologyId
        WHERE(td.TechnologyDetailId = @TechnologyDetailId
              OR @TechnologyDetailId IS NULL);
    END;

GO
