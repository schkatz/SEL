/****** Object:  Table [dbo].[Matchups]    Committed by VersionSQL https://www.versionsql.com ******/

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Matchups](
	[Matchup_ID] [int] NOT NULL,
	[MatchupTeam_ID1] [int] NOT NULL,
	[MatchupTeam_ID2] [int] NOT NULL,
	[MatchupDate] [date] NOT NULL,
	[MatchupTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Matchup_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

CREATE NONCLUSTERED INDEX [fk_Matchups_Teams1_idx] ON [dbo].[Matchups]
(
	[MatchupTeam_ID1] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
CREATE NONCLUSTERED INDEX [fk_Matchups_Teams2_idx] ON [dbo].[Matchups]
(
	[MatchupTeam_ID2] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
CREATE NONCLUSTERED INDEX [Matchup_ID_UNIQUE] ON [dbo].[Matchups]
(
	[Matchup_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
ALTER TABLE [dbo].[Matchups]  WITH CHECK ADD  CONSTRAINT [fk_Matchups_Teams1] FOREIGN KEY([MatchupTeam_ID1])
REFERENCES [dbo].[Teams] ([Team_ID])
ALTER TABLE [dbo].[Matchups] CHECK CONSTRAINT [fk_Matchups_Teams1]
ALTER TABLE [dbo].[Matchups]  WITH CHECK ADD  CONSTRAINT [fk_Matchups_Teams2] FOREIGN KEY([MatchupTeam_ID2])
REFERENCES [dbo].[Teams] ([Team_ID])
ALTER TABLE [dbo].[Matchups] CHECK CONSTRAINT [fk_Matchups_Teams2]
