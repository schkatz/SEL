/****** Object:  Table [dbo].[Games]    Committed by VersionSQL https://www.versionsql.com ******/

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Games](
	[Game_ID] [int] NOT NULL,
	[GameName] [varchar](45) NULL,
	[GameNick] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[Game_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

CREATE NONCLUSTERED INDEX [GameAccount_ID_UNIQUE] ON [dbo].[Games]
(
	[Game_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
SET ANSI_PADDING ON

CREATE NONCLUSTERED INDEX [GameNick_UNIQUE] ON [dbo].[Games]
(
	[GameNick] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
