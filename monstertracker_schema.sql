-- Monster Tracker Database Schema - STARTMALL
-- SQLite 3.x compatible
-- Database normalization: 3NF (Third Normal Form)
-- Created for Campus Mölndal - Databashantering och design

-- ==================================================
-- VIKTIGT: Foreign Key support i SQLite
-- ==================================================
-- SQLite har FK support AVSTÄNGD som standard!
-- Du måste aktivera det när du öppnar connection:
--   PRAGMA foreign_keys = ON;
-- Gör detta i din C#-kod vid varje connection.
-- ==================================================

-- ==================================================
-- Skapa dina tabeller här
-- ==================================================

-- Tips för att komma igång:
-- 1. Börja med Monster-tabellen (den har inga dependencies)
-- 2. Skapa Location och Hunter (de har heller inga dependencies)
-- 3. Skapa Observation sist (den beror på de andra tre)

-- ==================================================
-- Exempel på CREATE TABLE-syntax:
-- ==================================================
-- CREATE TABLE TableName (
--     Id INTEGER PRIMARY KEY AUTOINCREMENT,
--     ColumnName TEXT NOT NULL,
--     AnotherColumn TEXT
-- );

-- ==================================================
-- Monster-tabellen
-- ==================================================
-- Ska innehålla:
-- - Id (INTEGER, PRIMARY KEY, AUTOINCREMENT)
-- - Name (TEXT, NOT NULL)
-- - Type (TEXT, NOT NULL)
-- - DangerLevel (TEXT, NOT NULL)
--
-- Tips: Använd CHECK constraint för DangerLevel
-- CHECK(DangerLevel IN ('Low', 'Medium', 'High', 'Extreme'))

-- Din kod här:
CREATE TABLE Monster (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Type TEXT NOT NULL,
    DangerLevel TEXT NOT NULL CHECK(DangerLevel IN ('Low', 'Medium', 'High', 'Extreme'))
);

-- ==================================================
-- Location-tabellen
-- ==================================================
-- Ska innehålla:
-- - Id (INTEGER, PRIMARY KEY, AUTOINCREMENT)
-- - Name (TEXT, NOT NULL, UNIQUE)
-- - Region (TEXT, NOT NULL)
-- - Coordinates (TEXT, nullable)

-- Din kod här:
CREATE TABLE Location (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL UNIQUE,
    Region TEXT NOT NULL,
    Coordinates TEXT nullable
);

-- ==================================================
-- Hunter-tabellen
-- ==================================================
-- Ska innehålla:
-- - Id (INTEGER, PRIMARY KEY, AUTOINCREMENT)
-- - Name (TEXT, NOT NULL, UNIQUE)
-- - ExperienceLevel (TEXT, NOT NULL)
--
-- Tips: Använd CHECK constraint för ExperienceLevel
-- CHECK(ExperienceLevel IN ('Rookie', 'Intermediate', 'Expert', 'Master'))

-- Din kod här:
CREATE TABLE Hunter (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL UNIQUE,
    ExperienceLevel TEXT NOT NULL,
    Coordinates TEXT, nullable CHECK(ExperienceLevel IN ('Rookie', 'Intermediate', 'Expert', 'Master'))
);



-- ==================================================
-- Observation-tabellen (VIKTIGAST - kopplingsstabell!)
-- ==================================================
-- Ska innehålla:
-- - Id (INTEGER, PRIMARY KEY, AUTOINCREMENT)
-- - MonsterId (INTEGER, NOT NULL)
-- - LocationId (INTEGER, NOT NULL)
-- - HunterId (INTEGER, NOT NULL)
-- - Description (TEXT, nullable)
-- - DateSeen (TEXT, NOT NULL) -- ISO 8601: YYYY-MM-DD
--
-- FOREIGN KEY constraints krävs här!
-- FOREIGN KEY(MonsterId) REFERENCES Monster(Id)
-- FOREIGN KEY(LocationId) REFERENCES Location(Id)
-- FOREIGN KEY(HunterId) REFERENCES Hunter(Id)
--
-- Tips: Använd ON DELETE RESTRICT för att förhindra
-- radering av monster/location/hunter som har observationer

-- Din kod här:
-- mall från https://campusmolndaleducation.github.io/csharp_cmyh/C-Sharp/databases/sql/constraints/
CREATE TABLE Observation (
    Id      INTEGER PRIMARY KEY AUTOINCREMENT,
    MonsterId   INTEGER NOT NULL,
    LocationId   INTEGER NOT NULL,
    HunterId   INTEGER NOT NULL,
    Description  TEXT, nullable,
    DateSeen  TEXT NOT NULL,
    FOREIGN KEY (MonsterId)
        REFERENCES Monster(Id)
        ON DELETE RESTRICT
    FOREIGN KEY (LocationId)
        REFERENCES Location(Id)
        ON DELETE RESTRICT
    FOREIGN KEY (HunterId)
        REFERENCES Hunter(Id)
        ON DELETE RESTRICT
);


-- ==================================================
-- VG: Indexes för bättre performance (frivilligt)
-- ==================================================
-- Om du vill optimera din databas kan du lägga till indexes
-- för kolumner som ofta används i WHERE-klausuler eller JOINs:
--
-- CREATE INDEX idx_monster_type ON Monster(Type);
-- CREATE INDEX idx_observation_dateseen ON Observation(DateSeen);
-- etc.

-- ==================================================
-- Testa ditt schema
-- ==================================================
-- När du kört detta script, testa att:
-- 1. Alla tabeller finns: SELECT name FROM sqlite_master WHERE type='table';
-- 2. FK-constraints fungerar: Försök skapa observation med ogiltigt MonsterId
-- 3. 3NF-efterlevnad: Finns någon duplicerad information mellan tabeller?

-- ==================================================
-- 3NF Checklista
-- ==================================================
-- [ ] 1NF: Alla kolumner innehåller atomära värden (inga kommaseparerade listor)
-- [ ] 2NF: Inga partiella beroenden (alla attribut beror på HELA primärnyckeln)
-- [ ] 3NF: Inga transitiva beroenden
--     (Monster-info finns ENDAST i Monster, inte duplicerad i Observation)
--
-- Exempel på FEL design (bryter mot 3NF):
-- CREATE TABLE Observation (
--     Id INTEGER PRIMARY KEY,
--     MonsterId INTEGER,
--     MonsterName TEXT,  -- FEL! Detta beror på MonsterId, inte Observation.Id
--     MonsterType TEXT   -- FEL! Detta beror på MonsterId, inte Observation.Id
-- );
--
-- RÄTT design:
-- - Monster-info finns ENDAST i Monster-tabellen
-- - Observation har bara MonsterId (FK)
-- - Använd JOIN när du behöver visa monstrets namn
-- ==================================================

-- Lycka till! 🦇
