/****** Object:  Table [dbo].[Users]    Committed by VersionSQL https://www.versionsql.com ******/

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Users](
	[User_ID] [int] NOT NULL,
	[UserRole_ID] [int] NOT NULL,
	[UserFirstName] [varchar](45) NULL,
	[UserLastName] [varchar](45) NULL,
	[UserNick] [varchar](45) NOT NULL,
	[UserAge] [int] NULL,
	[UserSchool] [varchar](45) NULL,
	[UserPassword] [varchar](20) NOT NULL,
	[UserEmailAdress] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

CREATE NONCLUSTERED INDEX [fk_Users_Roles1_idx] ON [dbo].[Users]
(
	[UserRole_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
CREATE NONCLUSTERED INDEX [id_u_UNIQUE] ON [dbo].[Users]
(
	[User_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
SET ANSI_PADDING ON

CREATE NONCLUSTERED INDEX [UserEmailAdress_UNIQUE] ON [dbo].[Users]
(
	[UserEmailAdress] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
SET ANSI_PADDING ON

CREATE NONCLUSTERED INDEX [UserNick_UNIQUE] ON [dbo].[Users]
(
	[UserNick] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [fk_Users_Roles1] FOREIGN KEY([UserRole_ID])
REFERENCES [dbo].[Roles] ([Role_ID])
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [fk_Users_Roles1]
