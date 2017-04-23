/****** Object:  Table [dbo].[PlayerStats]    Committed by VersionSQL https://www.versionsql.com ******/

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[PlayerStats](
	[PlayerStat_ID] [int] NOT NULL,
	[PlayerStatKills] [int] NULL,
	[PlayerStatAssists] [int] NULL,
	[PlayerStatDeaths] [int] NULL,
	[PlayerStatKDA] [float] NULL,
	[PlayerStatWins] [int] NULL,
	[PlayerStatLoss] [int] NULL,
	[PlayerStatWinratio] [float] NULL,
	[PlayerStatAccountUser_ID] [int] NOT NULL,
	[PlayerStatAccountGame_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PlayerStat_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

CREATE NONCLUSTERED INDEX [fk_PlayerStats_Accounts1_idx] ON [dbo].[PlayerStats]
(
	[PlayerStatAccountUser_ID] ASC,
	[PlayerStatAccountGame_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
CREATE NONCLUSTERED INDEX [PlayerStat_ID_UNIQUE] ON [dbo].[PlayerStats]
(
	[PlayerStat_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
ALTER TABLE [dbo].[PlayerStats]  WITH CHECK ADD  CONSTRAINT [fk_PlayerStats_Accounts1] FOREIGN KEY([PlayerStatAccountUser_ID], [PlayerStatAccountGame_ID])
REFERENCES [dbo].[Accounts] ([AccountUser_ID], [AccountGame_ID])
ALTER TABLE [dbo].[PlayerStats] CHECK CONSTRAINT [fk_PlayerStats_Accounts1]
