-- ****************************************************
-- *                       Tasks                      *
-- ****************************************************
create table Tasks (
   Id          TEXT not null,
   Description TEXT,
   isCompleted INTEGER,
   constraint PK_Tasks primary key (Id)
);


-- ****************************************************
-- *                      Version                     *
-- ****************************************************
create table Version (
   VersionNumber integer not null,
   Description   text,
   constraint PK_Version primary key (VersionNumber)
);


