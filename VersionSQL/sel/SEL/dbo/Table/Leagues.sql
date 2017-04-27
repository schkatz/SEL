/****** Object:  Table [dbo].[Leagues]    Committed by VersionSQL https://www.versionsql.com ******/

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Leagues](
	[League_ID] [int] NOT NULL,
	[LeagueName] [varchar](45) NOT NULL,
	[LeagueReferee] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[League_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

CREATE NONCLUSTERED INDEX [League_ID_UNIQUE] ON [dbo].[Leagues]
(
	[League_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
