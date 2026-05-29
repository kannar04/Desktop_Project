-- DEV-ONLY DESTRUCTIVE RESET SCRIPT.
-- Drops the local QuanLyLopIELTS database and then reruns Schema.sql.
-- Run this script with SQLCMD mode enabled so the :r include command is executed.

USE master;
GO

IF DB_ID(N'QuanLyLopIELTS') IS NOT NULL
BEGIN
    ALTER DATABASE QuanLyLopIELTS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyLopIELTS;
END
GO

:r .\Schema.sql
GO
