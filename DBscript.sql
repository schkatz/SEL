-- MySQL Script generated by MySQL Workbench
-- 04/03/17 16:13:15
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS [mydb] DEFAULT CHARACTER SET utf8 ;
USE [mydb] ;

-- -----------------------------------------------------
-- Table [mydb].[Leagues]
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS [mydb].[Leagues] (
  [League_ID] INT NOT NULL,
  [LeagueName] VARCHAR(45) NOT NULL,
  [LeagueReferee] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([League_ID]),
  UNIQUE INDEX [League_ID_UNIQUE] ([League_ID] ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table [mydb].[Teams]
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS [mydb].[Teams] (
  [Team_ID] INT NOT NULL,
  [TeamLeague_ID] INT NOT NULL,
  [TeamCaptain] INT NOT NULL,
  [TeamName] VARCHAR(45) NULL,
  [TeamGame] VARCHAR(45) NULL,
  PRIMARY KEY ([Team_ID]),
  UNIQUE INDEX [id_t_UNIQUE] ([Team_ID] ASC),
  INDEX [fk_Teams_Users1_idx] ([TeamCaptain] ASC),
  INDEX [fk_Teams_Leagues1_idx] ([TeamLeague_ID] ASC),
  CONSTRAINT [fk_Teams_Users1]
    FOREIGN KEY ([TeamCaptain])
    REFERENCES [mydb].[Users] ([User_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Teams_Leagues1]
    FOREIGN KEY ([TeamLeague_ID])
    REFERENCES [mydb].[Leagues] ([League_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table [mydb].[Roles]
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS [mydb].[Roles] (
  [Role_ID] INT NOT NULL,
  [RoleName] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([Role_ID]),
  UNIQUE INDEX [Role_ID_UNIQUE] ([Role_ID] ASC),
  UNIQUE INDEX [RoleName_UNIQUE] ([RoleName] ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table [mydb].[Users]
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS [mydb].[Users] (
  [User_ID] INT NOT NULL,
  [UserTeam_ID] INT NULL,
  [UserRole_ID] INT NOT NULL,
  [UserFirstName] VARCHAR(45) NULL,
  [UserLastName] VARCHAR(45) NULL,
  [UserNick] VARCHAR(45) NOT NULL,
  [UserAge] INT NULL,
  [UserSchool] VARCHAR(45) NULL,
  [UserPassword] VARCHAR(20) NOT NULL,
  [UserEmailAdress] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([User_ID]),
  UNIQUE INDEX [id_u_UNIQUE] ([User_ID] ASC),
  INDEX [fk_Users_Teams_idx] ([UserTeam_ID] ASC),
  INDEX [fk_Users_Roles1_idx[ ([UserRole_ID] ASC),
  UNIQUE INDEX [UserNick_UNIQUE] ([UserNick[ ASC),
  UNIQUE INDEX [UserEmailAdress_UNIQUE] ([UserEmailAdress] ASC),
  CONSTRAINT [fk_Users_Teams]
    FOREIGN KEY ([UserTeam_ID])
    REFERENCES [mydb].[Teams] ([Team_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Users_Roles1]
    FOREIGN KEY ([UserRole_ID])
    REFERENCES [mydb].[Roles] ([Role_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table [mydb].[Matchups]
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS [mydb].[Matchups] (
  [Matchup_ID] INT NOT NULL,
  [MatchupTeam_ID1] INT NOT NULL,
  [MatchupTeam_ID2] INT NOT NULL,
  [MatchupDate] DATE NOT NULL,
  [MatchupTime] DATETIME NOT NULL,
  PRIMARY KEY ([Matchup_ID]),
  INDEX [fk_Matchups_Teams1_idx] ([MatchupTeam_ID1] ASC),
  INDEX [fk_Matchups_Teams2_idx] ([MatchupTeam_ID2] ASC),
  UNIQUE INDEX [Matchup_ID_UNIQUE] ([Matchup_ID] ASC),
  CONSTRAINT [fk_Matchups_Teams1]
    FOREIGN KEY ([MatchupTeam_ID1])
    REFERENCES [mydb].[Teams] ([Team_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Matchups_Teams2]
    FOREIGN KEY ([MatchupTeam_ID2])
    REFERENCES [mydb].[Teams] ([Team_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table [mydb].[Games]
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS [mydb].[Games] (
  [Game_ID] INT NOT NULL,
  [GameName] VARCHAR(45) NULL,
  [GameNick] VARCHAR(45) NULL,
  PRIMARY KEY ([Game_ID]),
  UNIQUE INDEX [GameAccount_ID_UNIQUE] ([Game_ID] ASC),
  UNIQUE INDEX [GameNick_UNIQUE] ([GameNick] ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table [mydb].[Accounts]
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS [mydb].[Accounts] (
  [AccountUser_ID] INT NOT NULL,
  [AccountGame_ID] INT NOT NULL,
  PRIMARY KEY ([AccountUser_ID], [AccountGame_ID]),
  INDEX [fk_Users_has_Games_Games1_idx] ([AccountGame_ID] ASC),
  INDEX [fk_Users_has_Games_Users1_idx] ([AccountUser_ID] ASC),
  CONSTRAINT [fk_Users_has_Games_Users1]
    FOREIGN KEY ([AccountUser_ID])
    REFERENCES [mydb].[Users] ([User_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_Users_has_Games_Games1]
    FOREIGN KEY ([AccountGame_ID])
    REFERENCES [mydb].[Games] ([Game_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table [mydb].[PlayerStats]
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS [mydb].[PlayerStats] (
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
  UNIQUE INDEX [PlayerStat_ID_UNIQUE] ([PlayerStat_ID] ASC),
  CONSTRAINT [fk_PlayerStats_Accounts1]
    FOREIGN KEY ([PlayerStatAccountUser_ID] , [PlayerStatAccountGame_ID])
    REFERENCES [mydb].[Accounts] ([AccountUser_ID] , [AccountGame_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table [mydb].[TeamStats]
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS [mydb].[TeamStats] (
  [TeamStats_ID] INT NOT NULL,
  [TeamStatsWins] INT NULL,
  [TeamStatsLoss] INT NULL,
  [TeamStatsWinratio] FLOAT NULL,
  [TeamPoints] INT NULL,
  [TeamStatsTeam_ID] INT NOT NULL,
  PRIMARY KEY ([TeamStats_ID]),
  UNIQUE INDEX [TeamStats_ID_UNIQUE] ([TeamStats_ID] ASC),
  INDEX [fk_TeamStats_Teams1_idx] ([TeamStatsTeam_ID] ASC),
  CONSTRAINT [fk_TeamStats_Teams1]
    FOREIGN KEY ([TeamStatsTeam_ID])
    REFERENCES [mydb].[Teams] ([Team_ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
