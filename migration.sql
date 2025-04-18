﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250129130502_InitialCreate') THEN
    CREATE TABLE education (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        date_range character varying(20) NOT NULL,
        title character varying(255) NOT NULL,
        subtitle character varying(255) NOT NULL,
        order_index integer,
        CONSTRAINT education_pkey PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250129130502_InitialCreate') THEN
    CREATE TABLE experience (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        date_range character varying(20) NOT NULL,
        title character varying(255) NOT NULL,
        company character varying(255) NOT NULL,
        order_index integer,
        CONSTRAINT experience_pkey PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250129130502_InitialCreate') THEN
    CREATE TABLE personal_info (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        name character varying(100) NOT NULL,
        email character varying(255) NOT NULL,
        phone character varying(20),
        description text,
        projects_count integer,
        CONSTRAINT personal_info_pkey PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250129130502_InitialCreate') THEN
    CREATE TABLE services (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        title character varying(50) NOT NULL,
        icon_path character varying(255) NOT NULL,
        order_index integer,
        CONSTRAINT services_pkey PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250129130502_InitialCreate') THEN
    CREATE TABLE skills (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        name character varying(100) NOT NULL,
        percentage integer NOT NULL,
        last_week integer,
        last_month integer,
        is_main_skill boolean DEFAULT FALSE,
        order_index integer,
        CONSTRAINT skills_pkey PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250129130502_InitialCreate') THEN
    CREATE TABLE tech_stack (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        name character varying(100) NOT NULL,
        url character varying(255) NOT NULL,
        icon_path character varying(255) NOT NULL,
        order_index integer,
        CONSTRAINT tech_stack_pkey PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250129130502_InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250129130502_InitialCreate', '9.0.1');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250214005644_AddGitHubRepoTable') THEN
    CREATE TABLE "GitHubRepos" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Name" text NOT NULL,
        "FullName" text NOT NULL,
        "HtmlUrl" text NOT NULL,
        "Description" text,
        "Language" text,
        "Topics" text[] NOT NULL,
        CONSTRAINT "PK_GitHubRepos" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250214005644_AddGitHubRepoTable') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250214005644_AddGitHubRepoTable', '9.0.1');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250312174844_AddReadmeAndLiveUrlToGitHubRepo') THEN
    ALTER TABLE "GitHubRepos" ADD "LiveUrl" text;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250312174844_AddReadmeAndLiveUrlToGitHubRepo') THEN
    ALTER TABLE "GitHubRepos" ADD "Readme" text;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250312174844_AddReadmeAndLiveUrlToGitHubRepo') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250312174844_AddReadmeAndLiveUrlToGitHubRepo', '9.0.1');
    END IF;
END $EF$;
COMMIT;

