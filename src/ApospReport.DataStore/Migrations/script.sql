﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20211115140758_InitialCreate') THEN
    CREATE TABLE accounts (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        username character varying(12) NOT NULL,
        base64encoded_screenshot text NULL,
        updated_at timestamp without time zone NOT NULL,
        attack_current_level integer NOT NULL,
        attack_base_level integer NOT NULL,
        defense_current_level integer NOT NULL,
        defense_base_level integer NOT NULL,
        strength_current_level integer NOT NULL,
        strength_base_level integer NOT NULL,
        hits_current_level integer NOT NULL,
        hits_base_level integer NOT NULL,
        ranged_current_level integer NOT NULL,
        ranged_base_level integer NOT NULL,
        prayer_current_level integer NOT NULL,
        prayer_base_level integer NOT NULL,
        magic_current_level integer NOT NULL,
        magic_base_level integer NOT NULL,
        cooking_current_level integer NOT NULL,
        cooking_base_level integer NOT NULL,
        woodcut_current_level integer NOT NULL,
        woodcut_base_level integer NOT NULL,
        fletching_current_level integer NOT NULL,
        fletching_base_level integer NOT NULL,
        fishing_current_level integer NOT NULL,
        fishing_base_level integer NOT NULL,
        firemaking_current_level integer NOT NULL,
        firemaking_base_level integer NOT NULL,
        crafting_current_level integer NOT NULL,
        crafting_base_level integer NOT NULL,
        smithing_current_level integer NOT NULL,
        smithing_base_level integer NOT NULL,
        mining_current_level integer NOT NULL,
        mining_base_level integer NOT NULL,
        herblaw_current_level integer NOT NULL,
        herblaw_base_level integer NOT NULL,
        agility_current_level integer NOT NULL,
        agility_base_level integer NOT NULL,
        thieving_current_level integer NOT NULL,
        thieving_base_level integer NOT NULL,
        bank_view_timestamp timestamp without time zone NULL,
        CONSTRAINT pk_accounts PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20211115140758_InitialCreate') THEN
    CREATE TABLE item_definitions (
        id integer NOT NULL,
        name character varying(100) NOT NULL,
        is_stackable boolean NOT NULL,
        CONSTRAINT pk_item_definitions PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20211115140758_InitialCreate') THEN
    CREATE TABLE bank_items (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        item_definition_id integer NOT NULL,
        count integer NOT NULL,
        account_id integer NOT NULL,
        position integer NOT NULL,
        CONSTRAINT pk_bank_items PRIMARY KEY (id),
        CONSTRAINT fk_bank_items_accounts_account_id FOREIGN KEY (account_id) REFERENCES accounts (id) ON DELETE CASCADE,
        CONSTRAINT fk_bank_items_item_definitions_item_definition_id FOREIGN KEY (item_definition_id) REFERENCES item_definitions (id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20211115140758_InitialCreate') THEN
    CREATE TABLE inventory_items (
        id integer GENERATED BY DEFAULT AS IDENTITY,
        item_definition_id integer NOT NULL,
        count integer NOT NULL,
        account_id integer NOT NULL,
        position integer NOT NULL,
        CONSTRAINT pk_inventory_items PRIMARY KEY (id),
        CONSTRAINT fk_inventory_items_accounts_account_id FOREIGN KEY (account_id) REFERENCES accounts (id) ON DELETE CASCADE,
        CONSTRAINT fk_inventory_items_item_definitions_item_definition_id FOREIGN KEY (item_definition_id) REFERENCES item_definitions (id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20211115140758_InitialCreate') THEN
    CREATE INDEX ix_bank_items_account_id ON bank_items (account_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20211115140758_InitialCreate') THEN
    CREATE INDEX ix_bank_items_item_definition_id ON bank_items (item_definition_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20211115140758_InitialCreate') THEN
    CREATE INDEX ix_inventory_items_account_id ON inventory_items (account_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20211115140758_InitialCreate') THEN
    CREATE INDEX ix_inventory_items_item_definition_id ON inventory_items (item_definition_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20211115140758_InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
    VALUES ('20211115140758_InitialCreate', '5.0.10');
    END IF;
END $EF$;
COMMIT;

