USE [Game]
GO

/****** Object: Table [dbo].[Users] Script Date: 8/12/2020 10:43:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Users];


GO
CREATE TABLE [dbo].[Users] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [username]  NVARCHAR (50)  NULL,
    [password]  NVARCHAR (50)  NULL,
    [firstname] NVARCHAR (50)  NULL,
    [lastname]  NVARCHAR (50)  NULL,
    [sex]       NVARCHAR (50)  NULL,
    [age]       INT            NULL,
    [email]     NVARCHAR (MAX) NULL
);


