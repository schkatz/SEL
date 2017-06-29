/****** Object:  Table [dbo].[TeamStats]    Committed by VersionSQL https://www.versionsql.com ******/

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[TeamStats](
	[TeamStats_ID] [int] NOT NULL,
	[TeamStatsWins] [int] NULL,
	[TeamStatsLoss] [int] NULL,
	[TeamStatsWinratio] [float] NULL,
	[TeamPoints] [int] NULL,
	[TeamStatsTeam_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TeamStats_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

CREATE NONCLUSTERED INDEX [fk_TeamStats_Teams1_idx] ON [dbo].[TeamStats]
(
	[TeamStatsTeam_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
CREATE NONCLUSTERED INDEX [TeamStats_ID_UNIQUE] ON [dbo].[TeamStats]
(
	[TeamStats_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
ALTER TABLE [dbo].[TeamStats]  WITH CHECK ADD  CONSTRAINT [fk_TeamStats_Teams1] FOREIGN KEY([TeamStatsTeam_ID])
REFERENCES [dbo].[Teams] ([Team_ID])
ALTER TABLE [dbo].[TeamStats] CHECK CONSTRAINT [fk_TeamStats_Teams1]
