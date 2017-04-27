/****** Object:  Table [dbo].[Accounts]    Committed by VersionSQL https://www.versionsql.com ******/

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Accounts](
	[AccountUser_ID] [int] NOT NULL,
	[AccountGame_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountUser_ID] ASC,
	[AccountGame_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

CREATE NONCLUSTERED INDEX [fk_Users_has_Games_Games1_idx] ON [dbo].[Accounts]
(
	[AccountGame_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
CREATE NONCLUSTERED INDEX [fk_Users_has_Games_Users1_idx] ON [dbo].[Accounts]
(
	[AccountUser_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [fk_Users_has_Games_Games1] FOREIGN KEY([AccountGame_ID])
REFERENCES [dbo].[Games] ([Game_ID])
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [fk_Users_has_Games_Games1]
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [fk_Users_has_Games_Users1] FOREIGN KEY([AccountUser_ID])
REFERENCES [dbo].[Users] ([User_ID])
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [fk_Users_has_Games_Users1]
