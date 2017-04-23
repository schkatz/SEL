
  -- -----------------------------------------------------
-- Podstawowa tabela ROLES
-- -----------------------------------------------------
CREATE TABLE [Roles] (
  [Role_ID] INT NOT NULL,
  [RoleName] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([Role_ID]),
  INDEX [Role_ID_UNIQUE] ([Role_ID] ASC),
  INDEX [RoleName_UNIQUE] ([RoleName] ASC))

-- -----------------------------------------------------
-- Podstawowa Tabela GAMES
-- -----------------------------------------------------
CREATE TABLE [Games] (
  [Game_ID] INT NOT NULL,
  [GameName] VARCHAR(45) NULL,
  [GameNick] VARCHAR(45) NULL,
  PRIMARY KEY ([Game_ID]),
  INDEX [GameAccount_ID_UNIQUE] ([Game_ID] ASC),
INDEX [GameNick_UNIQUE] ([GameNick] ASC))

-- -----------------------------------------------------
-- Podstawowa Tabela USERS
-- -----------------------------------------------------

CREATE TABLE [Users] (
  [User_ID] INT NOT NULL,
  [UserRole_ID] INT NOT NULL,
  [UserFirstName] VARCHAR(45) NULL,
  [UserLastName] VARCHAR(45) NULL,
  [UserNick] VARCHAR(45) NOT NULL,
  [UserAge] INT NULL,
  [UserSchool] VARCHAR(45) NULL,
  [UserPassword] VARCHAR(20) NOT NULL,
  [UserEmailAdress] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([User_ID]),
  INDEX [id_u_UNIQUE] ([User_ID] ASC),
  INDEX [fk_Users_Roles1_idx] ([UserRole_ID] ASC),
  INDEX [UserNick_UNIQUE] ([UserNick] ASC),
  INDEX [UserEmailAdress_UNIQUE] ([UserEmailAdress] ASC),
  CONSTRAINT [fk_Users_Roles1]
    FOREIGN KEY ([UserRole_ID])
    REFERENCES [Roles] ([Role_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)

-- -----------------------------------------------------
-- Podstawowa Tabela Ligi
-- -----------------------------------------------------

CREATE TABLE [Leagues] (
  [League_ID] INT NOT NULL,
  [LeagueName] VARCHAR(45) NOT NULL,
  [LeagueReferee] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([League_ID]),
  INDEX [League_ID_UNIQUE] ([League_ID] ASC))

CREATE TABLE [Teams] (
  [Team_ID] INT NOT NULL,
  [TeamLeague_ID] INT NOT NULL,
  [TeamUser] INT NOT NULL,
  [TeamName] VARCHAR(45) NULL,
  [TeamGame] VARCHAR(45) NULL,
  PRIMARY KEY ([Team_ID]),
  INDEX [id_t_UNIQUE] ([Team_ID] ASC),
  INDEX [fk_Teams_Users1_idx] ([TeamUser] ASC),
  INDEX [fk_Teams_Leagues1_idx] ([TeamLeague_ID] ASC),
  CONSTRAINT [fk_Teams_Users1]
    FOREIGN KEY ([TeamUser])
    REFERENCES [Users] ([User_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Teams_Leagues1]
    FOREIGN KEY ([TeamLeague_ID])
    REFERENCES [Leagues] ([League_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)

-- -----------------------------------------------------
-- Table [SEL].[Matchups]
-- -----------------------------------------------------
CREATE TABLE [Matchups] (
  [Matchup_ID] INT NOT NULL,
  [MatchupTeam_ID1] INT NOT NULL,
  [MatchupTeam_ID2] INT NOT NULL,
  [MatchupDate] DATE NOT NULL,
  [MatchupTime] DATETIME NOT NULL,
  PRIMARY KEY ([Matchup_ID]),
  INDEX [fk_Matchups_Teams1_idx] ([MatchupTeam_ID1] ASC),
  INDEX [fk_Matchups_Teams2_idx] ([MatchupTeam_ID2] ASC),
  INDEX [Matchup_ID_UNIQUE] ([Matchup_ID] ASC),
  CONSTRAINT [fk_Matchups_Teams1]
    FOREIGN KEY ([MatchupTeam_ID1])
    REFERENCES [Teams] ([Team_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Matchups_Teams2]
    FOREIGN KEY ([MatchupTeam_ID2])
    REFERENCES [Teams] ([Team_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)


-- -----------------------------------------------------
-- Table [SEL].[Accounts]
-- -----------------------------------------------------
CREATE TABLE [Accounts] (
  [AccountUser_ID] INT NOT NULL,
  [AccountGame_ID] INT NOT NULL,
  PRIMARY KEY ([AccountUser_ID], [AccountGame_ID]),
  INDEX [fk_Users_has_Games_Games1_idx] ([AccountGame_ID] ASC),
  INDEX [fk_Users_has_Games_Users1_idx] ([AccountUser_ID] ASC),
  CONSTRAINT [fk_Users_has_Games_Users1]
    FOREIGN KEY ([AccountUser_ID])
    REFERENCES [Users] ([User_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Users_has_Games_Games1]
    FOREIGN KEY ([AccountGame_ID])
    REFERENCES [Games] ([Game_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)



-- -----------------------------------------------------
-- Table [SEL].[PlayerStats]
-- -----------------------------------------------------
CREATE TABLE [PlayerStats] (
  [PlayerStat_ID] INT NOT NULL,
  [PlayerStatKills] INT NULL,
  [PlayerStatAssists] INT NULL,
  [PlayerStatDeaths] INT NULL,
  [PlayerStatKDA] FLOAT NULL,
  [PlayerStatWins] INT NULL,
  [PlayerStatLoss] INT NULL,
  [PlayerStatWinratio] FLOAT NULL,
  [PlayerStatAccountUser_ID] INT NOT NULL,
  [PlayerStatAccountGame_ID] INT NOT NULL,
  PRIMARY KEY ([PlayerStat_ID]),
  INDEX [fk_PlayerStats_Accounts1_idx] ([PlayerStatAccountUser_ID] ASC, [PlayerStatAccountGame_ID] ASC),
  INDEX [PlayerStat_ID_UNIQUE] ([PlayerStat_ID] ASC),
  CONSTRAINT [fk_PlayerStats_Accounts1]
    FOREIGN KEY ([PlayerStatAccountUser_ID] , [PlayerStatAccountGame_ID])
    REFERENCES [Accounts] ([AccountUser_ID] , [AccountGame_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)


-- -----------------------------------------------------
-- Table [SEL].[TeamStats]
-- -----------------------------------------------------
CREATE TABLE [TeamStats] (
  [TeamStats_ID] INT NOT NULL,
  [TeamStatsWins] INT NULL,
  [TeamStatsLoss] INT NULL,
  [TeamStatsWinratio] FLOAT NULL,
  [TeamPoints] INT NULL,
  [TeamStatsTeam_ID] INT NOT NULL,
  PRIMARY KEY ([TeamStats_ID]),
  INDEX [TeamStats_ID_UNIQUE] ([TeamStats_ID] ASC),
  INDEX [fk_TeamStats_Teams1_idx] ([TeamStatsTeam_ID] ASC),
  CONSTRAINT [fk_TeamStats_Teams1]
    FOREIGN KEY ([TeamStatsTeam_ID])
    REFERENCES [Teams] ([Team_ID])
    ON DELETE NO ACTION
ON UPDATE NO ACTION)
