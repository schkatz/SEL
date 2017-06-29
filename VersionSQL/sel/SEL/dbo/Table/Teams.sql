/****** Object:  Table [dbo].[Teams]    Committed by VersionSQL https://www.versionsql.com ******/

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Teams](
	[Team_ID] [int] NOT NULL,
	[TeamLeague_ID] [int] NOT NULL,
	[TeamUser] [int] NOT NULL,
	[TeamName] [varchar](45) NULL,
	[TeamGame] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[Team_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

CREATE NONCLUSTERED INDEX [fk_Teams_Leagues1_idx] ON [dbo].[Teams]
(
	[TeamLeague_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
CREATE NONCLUSTERED INDEX [fk_Teams_Users1_idx] ON [dbo].[Teams]
(
	[TeamUser] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
CREATE NONCLUSTERED INDEX [id_t_UNIQUE] ON [dbo].[Teams]
(
	[Team_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [fk_Teams_Leagues1] FOREIGN KEY([TeamLeague_ID])
REFERENCES [dbo].[Leagues] ([League_ID])
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [fk_Teams_Leagues1]
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [fk_Teams_Users1] FOREIGN KEY([TeamUser])
REFERENCES [dbo].[Users] ([User_ID])
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [fk_Teams_Users1]
