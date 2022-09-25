
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/19/2021 15:48:18
-- Generated from EDMX file: E:\Projects VIsual Studio\Inventory\Inventory.Web\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [stock-control];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__city__id_provinc__40F9A68C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[city] DROP CONSTRAINT [FK__city__id_provinc__40F9A68C];
GO
IF OBJECT_ID(N'[dbo].[FK__entry_pro__id_pr__54CB950F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[entry_product] DROP CONSTRAINT [FK__entry_pro__id_pr__54CB950F];
GO
IF OBJECT_ID(N'[dbo].[FK__entry_pro__id_pr__7869D707]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[entry_product] DROP CONSTRAINT [FK__entry_pro__id_pr__7869D707];
GO
IF OBJECT_ID(N'[dbo].[FK__inventory__id_pr__7DCDAAA2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[inventory_stock] DROP CONSTRAINT [FK__inventory__id_pr__7DCDAAA2];
GO
IF OBJECT_ID(N'[dbo].[FK__product__id_bran__1E6F845E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[product] DROP CONSTRAINT [FK__product__id_bran__1E6F845E];
GO
IF OBJECT_ID(N'[dbo].[FK__product__id_grou__1C873BEC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[product] DROP CONSTRAINT [FK__product__id_grou__1C873BEC];
GO
IF OBJECT_ID(N'[dbo].[FK__product__id_prov__1B9317B3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[product] DROP CONSTRAINT [FK__product__id_prov__1B9317B3];
GO
IF OBJECT_ID(N'[dbo].[FK__product__id_stor__1D7B6025]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[product] DROP CONSTRAINT [FK__product__id_stor__1D7B6025];
GO
IF OBJECT_ID(N'[dbo].[FK__product__id_unit__1F63A897]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[product] DROP CONSTRAINT [FK__product__id_unit__1F63A897];
GO
IF OBJECT_ID(N'[dbo].[FK__product_o__id_pr__407A839F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[product_output] DROP CONSTRAINT [FK__product_o__id_pr__407A839F];
GO
IF OBJECT_ID(N'[dbo].[FK__product_o__id_pr__67DE6983]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[product_output] DROP CONSTRAINT [FK__product_o__id_pr__67DE6983];
GO
IF OBJECT_ID(N'[dbo].[FK__provider__id_cit__7755B73D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[provider] DROP CONSTRAINT [FK__provider__id_cit__7755B73D];
GO
IF OBJECT_ID(N'[dbo].[FK__provider__id_cou__756D6ECB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[provider] DROP CONSTRAINT [FK__provider__id_cou__756D6ECB];
GO
IF OBJECT_ID(N'[dbo].[FK__provider__id_pro__76619304]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[provider] DROP CONSTRAINT [FK__provider__id_pro__76619304];
GO
IF OBJECT_ID(N'[dbo].[FK__province__id_cou__3E1D39E1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[province] DROP CONSTRAINT [FK__province__id_cou__3E1D39E1];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_role_users_dbo_role_id_role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[role_users] DROP CONSTRAINT [FK_dbo_role_users_dbo_role_id_role];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_role_users_dbo_user_id_users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[role_users] DROP CONSTRAINT [FK_dbo_role_users_dbo_user_id_users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[city]', 'U') IS NOT NULL
    DROP TABLE [dbo].[city];
GO
IF OBJECT_ID(N'[dbo].[country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[country];
GO
IF OBJECT_ID(N'[dbo].[employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[employee];
GO
IF OBJECT_ID(N'[dbo].[entry_product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[entry_product];
GO
IF OBJECT_ID(N'[dbo].[inventory_stock]', 'U') IS NOT NULL
    DROP TABLE [dbo].[inventory_stock];
GO
IF OBJECT_ID(N'[dbo].[product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[product];
GO
IF OBJECT_ID(N'[dbo].[product_brand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[product_brand];
GO
IF OBJECT_ID(N'[dbo].[product_group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[product_group];
GO
IF OBJECT_ID(N'[dbo].[product_output]', 'U') IS NOT NULL
    DROP TABLE [dbo].[product_output];
GO
IF OBJECT_ID(N'[dbo].[provider]', 'U') IS NOT NULL
    DROP TABLE [dbo].[provider];
GO
IF OBJECT_ID(N'[dbo].[province]', 'U') IS NOT NULL
    DROP TABLE [dbo].[province];
GO
IF OBJECT_ID(N'[dbo].[role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[role];
GO
IF OBJECT_ID(N'[dbo].[role_users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[role_users];
GO
IF OBJECT_ID(N'[dbo].[storage_location]', 'U') IS NOT NULL
    DROP TABLE [dbo].[storage_location];
GO
IF OBJECT_ID(N'[dbo].[unit_measure]', 'U') IS NOT NULL
    DROP TABLE [dbo].[unit_measure];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'city'
CREATE TABLE [dbo].[city] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(30)  NOT NULL,
    [active] bit  NOT NULL,
    [id_province] int  NOT NULL
);
GO

-- Creating table 'country'
CREATE TABLE [dbo].[country] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(30)  NOT NULL,
    [code] varchar(3)  NOT NULL,
    [active] bit  NOT NULL
);
GO

-- Creating table 'employee'
CREATE TABLE [dbo].[employee] (
    [id] int IDENTITY(1,1) NOT NULL,
    [legal_name] nvarchar(50)  NOT NULL,
    [legal_surname] varchar(50)  NOT NULL,
    [print_name] nvarchar(50)  NOT NULL,
    [ssn] int  NOT NULL,
    [gender] nvarchar(50)  NOT NULL,
    [date_birth] datetime NULL,
    [marital_status] nvarchar(50)  NOT NULL,
    [us_citizen] int  NOT NULL,
    [ethnicity] nvarchar(50)  NOT NULL,
    [active] bit  NOT NULL,
    [disability] int  NOT NULL,
    [disability_description] nvarchar(50)  NOT NULL,
    [i9_form] int  NOT NULL,
    [work_expires] datetime NULL,
    [us_veteran] int  NOT NULL,
    [veteran_status] nvarchar(50)  NOT NULL,
    [address_1] nvarchar(50)  NOT NULL,
    [address_2] nvarchar(50)  NOT NULL,
    [e_city] nvarchar(50)  NOT NULL,
    [e_state_province] nvarchar(50)  NOT NULL,
    [e_postal_code] nchar(10)  NOT NULL,
    [e_phone_number] nchar(10)  NOT NULL,
    [e_mobile_number] nchar(10)  NULL,
    [e_email] nvarchar(50)  NOT NULL,
    [e_contact_name1] nchar(10)  NULL,
    [e_contact_phone1] nchar(10)  NULL,
    [e_contact_relation1] nchar(10)  NULL,
    [e_contact_name2] nchar(10)  NULL,
    [e_contact_phone2] nchar(10)  NULL,
    [e_contact_relation2] nchar(10)  NULL,
    [type] int  NULL
);
GO

-- Creating table 'entry_product'
CREATE TABLE [dbo].[entry_product] (
    [id] int IDENTITY(1,1) NOT NULL,
    [number] varchar(10)  NOT NULL,
    [date] datetime  NOT NULL,
    [id_product] int  NOT NULL,
    [quant] int  NOT NULL,
    [id_provider] int  NULL,
    [user_name] nvarchar(50)  NULL
);
GO

-- Creating table 'inventory_stock'
CREATE TABLE [dbo].[inventory_stock] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NOT NULL,
    [id_product] int  NOT NULL,
    [storage_quant] int  NOT NULL,
    [quant_inventory] int  NOT NULL,
    [reason] varchar(100)  NULL
);
GO

-- Creating table 'product'
CREATE TABLE [dbo].[product] (
    [id] int IDENTITY(1,1) NOT NULL,
    [code] varchar(10)  NOT NULL,
    [name] varchar(50)  NOT NULL,
    [cost_value] decimal(7,2)  NOT NULL,
    [price] decimal(7,2)  NOT NULL,
    [storage_quant] int  NOT NULL,
    [id_unit_measure] int  NOT NULL,
    [id_group] int  NOT NULL,
    [id_brand] int  NOT NULL,
    [id_provider] int  NOT NULL,
    [id_storage_location] int  NOT NULL,
    [active] bit  NOT NULL,
    [image] varchar(100)  NOT NULL
);
GO

-- Creating table 'product_brand'
CREATE TABLE [dbo].[product_brand] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nchar(50)  NOT NULL,
    [active] bit  NOT NULL
);
GO

-- Creating table 'product_group'
CREATE TABLE [dbo].[product_group] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [active] bit  NOT NULL
);
GO

-- Creating table 'product_output'
CREATE TABLE [dbo].[product_output] (
    [id] int IDENTITY(1,1) NOT NULL,
    [number] varchar(10)  NOT NULL,
    [date] datetime  NOT NULL,
    [id_product] int  NOT NULL,
    [quant] int  NOT NULL,
    [id_provider] int  NULL,
    [user_name] nvarchar(50)  NULL
);
GO

-- Creating table 'provider'
CREATE TABLE [dbo].[provider] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(60)  NOT NULL,
    [corporate_name] varchar(100)  NULL,
    [doc_num] varchar(20)  NULL,
    [type] int  NOT NULL,
    [phone] varchar(20)  NOT NULL,
    [contact] varchar(60)  NOT NULL,
    [address] varchar(100)  NOT NULL,
    [number] varchar(20)  NOT NULL,
    [instruction] varchar(100)  NULL,
    [postal_code] varchar(10)  NULL,
    [id_country] int  NOT NULL,
    [id_province] int  NOT NULL,
    [id_city] int  NOT NULL,
    [active] bit  NOT NULL
);
GO

-- Creating table 'province'
CREATE TABLE [dbo].[province] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(30)  NOT NULL,
    [pcode] varchar(2)  NOT NULL,
    [active] bit  NOT NULL,
    [id_country] int  NOT NULL
);
GO

-- Creating table 'role'
CREATE TABLE [dbo].[role] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(20)  NOT NULL,
    [active] bit  NOT NULL
);
GO

-- Creating table 'storage_location'
CREATE TABLE [dbo].[storage_location] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nchar(50)  NOT NULL,
    [active] bit  NOT NULL
);
GO

-- Creating table 'unit_measure'
CREATE TABLE [dbo].[unit_measure] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(30)  NOT NULL,
    [initials] varchar(3)  NOT NULL,
    [active] bit  NOT NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id] int  NOT NULL,
    [login] nvarchar(50)  NOT NULL,
    [password] nvarchar(32)  NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [email] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'role_users'
CREATE TABLE [dbo].[role_users] (
    [role_id] int  NOT NULL,
    [users_id] int  NOT NULL
);
GO

-- Creating table 'role_users1'
CREATE TABLE [dbo].[role_users1] (
    [role1_id] int  NOT NULL,
    [users1_id] int  NOT NULL
);
GO

-- Creating table 'role_users2'
CREATE TABLE [dbo].[role_users2] (
    [role2_id] int  NOT NULL,
    [users2_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [id] in table 'city'
ALTER TABLE [dbo].[city]
ADD CONSTRAINT [PK_city]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'country'
ALTER TABLE [dbo].[country]
ADD CONSTRAINT [PK_country]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'employee'
ALTER TABLE [dbo].[employee]
ADD CONSTRAINT [PK_employee]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'entry_product'
ALTER TABLE [dbo].[entry_product]
ADD CONSTRAINT [PK_entry_product]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'inventory_stock'
ALTER TABLE [dbo].[inventory_stock]
ADD CONSTRAINT [PK_inventory_stock]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'product'
ALTER TABLE [dbo].[product]
ADD CONSTRAINT [PK_product]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'product_brand'
ALTER TABLE [dbo].[product_brand]
ADD CONSTRAINT [PK_product_brand]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'product_group'
ALTER TABLE [dbo].[product_group]
ADD CONSTRAINT [PK_product_group]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'product_output'
ALTER TABLE [dbo].[product_output]
ADD CONSTRAINT [PK_product_output]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'provider'
ALTER TABLE [dbo].[provider]
ADD CONSTRAINT [PK_provider]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'province'
ALTER TABLE [dbo].[province]
ADD CONSTRAINT [PK_province]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'role'
ALTER TABLE [dbo].[role]
ADD CONSTRAINT [PK_role]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'storage_location'
ALTER TABLE [dbo].[storage_location]
ADD CONSTRAINT [PK_storage_location]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'unit_measure'
ALTER TABLE [dbo].[unit_measure]
ADD CONSTRAINT [PK_unit_measure]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [role_id], [users_id] in table 'role_users'
ALTER TABLE [dbo].[role_users]
ADD CONSTRAINT [PK_role_users]
    PRIMARY KEY CLUSTERED ([role_id], [users_id] ASC);
GO

-- Creating primary key on [role1_id], [users1_id] in table 'role_users1'
ALTER TABLE [dbo].[role_users1]
ADD CONSTRAINT [PK_role_users1]
    PRIMARY KEY CLUSTERED ([role1_id], [users1_id] ASC);
GO

-- Creating primary key on [role2_id], [users2_id] in table 'role_users2'
ALTER TABLE [dbo].[role_users2]
ADD CONSTRAINT [PK_role_users2]
    PRIMARY KEY CLUSTERED ([role2_id], [users2_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_province] in table 'city'
ALTER TABLE [dbo].[city]
ADD CONSTRAINT [FK__city__id_provinc__40F9A68C]
    FOREIGN KEY ([id_province])
    REFERENCES [dbo].[province]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__city__id_provinc__40F9A68C'
CREATE INDEX [IX_FK__city__id_provinc__40F9A68C]
ON [dbo].[city]
    ([id_province]);
GO

-- Creating foreign key on [id_city] in table 'provider'
ALTER TABLE [dbo].[provider]
ADD CONSTRAINT [FK__provider__id_cit__7755B73D]
    FOREIGN KEY ([id_city])
    REFERENCES [dbo].[city]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__provider__id_cit__7755B73D'
CREATE INDEX [IX_FK__provider__id_cit__7755B73D]
ON [dbo].[provider]
    ([id_city]);
GO

-- Creating foreign key on [id_country] in table 'provider'
ALTER TABLE [dbo].[provider]
ADD CONSTRAINT [FK__provider__id_cou__756D6ECB]
    FOREIGN KEY ([id_country])
    REFERENCES [dbo].[country]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__provider__id_cou__756D6ECB'
CREATE INDEX [IX_FK__provider__id_cou__756D6ECB]
ON [dbo].[provider]
    ([id_country]);
GO

-- Creating foreign key on [id_country] in table 'province'
ALTER TABLE [dbo].[province]
ADD CONSTRAINT [FK__province__id_cou__3E1D39E1]
    FOREIGN KEY ([id_country])
    REFERENCES [dbo].[country]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__province__id_cou__3E1D39E1'
CREATE INDEX [IX_FK__province__id_cou__3E1D39E1]
ON [dbo].[province]
    ([id_country]);
GO

-- Creating foreign key on [id_product] in table 'entry_product'
ALTER TABLE [dbo].[entry_product]
ADD CONSTRAINT [FK__entry_pro__id_pr__54CB950F]
    FOREIGN KEY ([id_product])
    REFERENCES [dbo].[product]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__entry_pro__id_pr__54CB950F'
CREATE INDEX [IX_FK__entry_pro__id_pr__54CB950F]
ON [dbo].[entry_product]
    ([id_product]);
GO

-- Creating foreign key on [id_provider] in table 'entry_product'
ALTER TABLE [dbo].[entry_product]
ADD CONSTRAINT [FK__entry_pro__id_pr__7869D707]
    FOREIGN KEY ([id_provider])
    REFERENCES [dbo].[provider]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__entry_pro__id_pr__7869D707'
CREATE INDEX [IX_FK__entry_pro__id_pr__7869D707]
ON [dbo].[entry_product]
    ([id_provider]);
GO

-- Creating foreign key on [id_product] in table 'inventory_stock'
ALTER TABLE [dbo].[inventory_stock]
ADD CONSTRAINT [FK__inventory__id_pr__7DCDAAA2]
    FOREIGN KEY ([id_product])
    REFERENCES [dbo].[product]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__inventory__id_pr__7DCDAAA2'
CREATE INDEX [IX_FK__inventory__id_pr__7DCDAAA2]
ON [dbo].[inventory_stock]
    ([id_product]);
GO

-- Creating foreign key on [id_brand] in table 'product'
ALTER TABLE [dbo].[product]
ADD CONSTRAINT [FK__product__id_bran__1E6F845E]
    FOREIGN KEY ([id_brand])
    REFERENCES [dbo].[product_brand]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__product__id_bran__1E6F845E'
CREATE INDEX [IX_FK__product__id_bran__1E6F845E]
ON [dbo].[product]
    ([id_brand]);
GO

-- Creating foreign key on [id_group] in table 'product'
ALTER TABLE [dbo].[product]
ADD CONSTRAINT [FK__product__id_grou__1C873BEC]
    FOREIGN KEY ([id_group])
    REFERENCES [dbo].[product_group]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__product__id_grou__1C873BEC'
CREATE INDEX [IX_FK__product__id_grou__1C873BEC]
ON [dbo].[product]
    ([id_group]);
GO

-- Creating foreign key on [id_provider] in table 'product'
ALTER TABLE [dbo].[product]
ADD CONSTRAINT [FK__product__id_prov__1B9317B3]
    FOREIGN KEY ([id_provider])
    REFERENCES [dbo].[provider]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__product__id_prov__1B9317B3'
CREATE INDEX [IX_FK__product__id_prov__1B9317B3]
ON [dbo].[product]
    ([id_provider]);
GO

-- Creating foreign key on [id_storage_location] in table 'product'
ALTER TABLE [dbo].[product]
ADD CONSTRAINT [FK__product__id_stor__1D7B6025]
    FOREIGN KEY ([id_storage_location])
    REFERENCES [dbo].[storage_location]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__product__id_stor__1D7B6025'
CREATE INDEX [IX_FK__product__id_stor__1D7B6025]
ON [dbo].[product]
    ([id_storage_location]);
GO

-- Creating foreign key on [id_unit_measure] in table 'product'
ALTER TABLE [dbo].[product]
ADD CONSTRAINT [FK__product__id_unit__1F63A897]
    FOREIGN KEY ([id_unit_measure])
    REFERENCES [dbo].[unit_measure]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__product__id_unit__1F63A897'
CREATE INDEX [IX_FK__product__id_unit__1F63A897]
ON [dbo].[product]
    ([id_unit_measure]);
GO

-- Creating foreign key on [id_product] in table 'product_output'
ALTER TABLE [dbo].[product_output]
ADD CONSTRAINT [FK__product_o__id_pr__67DE6983]
    FOREIGN KEY ([id_product])
    REFERENCES [dbo].[product]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__product_o__id_pr__67DE6983'
CREATE INDEX [IX_FK__product_o__id_pr__67DE6983]
ON [dbo].[product_output]
    ([id_product]);
GO

-- Creating foreign key on [id_provider] in table 'product_output'
ALTER TABLE [dbo].[product_output]
ADD CONSTRAINT [FK__product_o__id_pr__407A839F]
    FOREIGN KEY ([id_provider])
    REFERENCES [dbo].[provider]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__product_o__id_pr__407A839F'
CREATE INDEX [IX_FK__product_o__id_pr__407A839F]
ON [dbo].[product_output]
    ([id_provider]);
GO

-- Creating foreign key on [id_province] in table 'provider'
ALTER TABLE [dbo].[provider]
ADD CONSTRAINT [FK__provider__id_pro__76619304]
    FOREIGN KEY ([id_province])
    REFERENCES [dbo].[province]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__provider__id_pro__76619304'
CREATE INDEX [IX_FK__provider__id_pro__76619304]
ON [dbo].[provider]
    ([id_province]);
GO

-- Creating foreign key on [role_id] in table 'role_users'
ALTER TABLE [dbo].[role_users]
ADD CONSTRAINT [FK_role_users_role]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[role]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [users_id] in table 'role_users'
ALTER TABLE [dbo].[role_users]
ADD CONSTRAINT [FK_role_users_users]
    FOREIGN KEY ([users_id])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_role_users_users'
CREATE INDEX [IX_FK_role_users_users]
ON [dbo].[role_users]
    ([users_id]);
GO

-- Creating foreign key on [role1_id] in table 'role_users1'
ALTER TABLE [dbo].[role_users1]
ADD CONSTRAINT [FK_role_users1_role]
    FOREIGN KEY ([role1_id])
    REFERENCES [dbo].[role]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [users1_id] in table 'role_users1'
ALTER TABLE [dbo].[role_users1]
ADD CONSTRAINT [FK_role_users1_users]
    FOREIGN KEY ([users1_id])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_role_users1_users'
CREATE INDEX [IX_FK_role_users1_users]
ON [dbo].[role_users1]
    ([users1_id]);
GO

-- Creating foreign key on [role2_id] in table 'role_users2'
ALTER TABLE [dbo].[role_users2]
ADD CONSTRAINT [FK_role_users2_role]
    FOREIGN KEY ([role2_id])
    REFERENCES [dbo].[role]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [users2_id] in table 'role_users2'
ALTER TABLE [dbo].[role_users2]
ADD CONSTRAINT [FK_role_users2_users]
    FOREIGN KEY ([users2_id])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_role_users2_users'
CREATE INDEX [IX_FK_role_users2_users]
ON [dbo].[role_users2]
    ([users2_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------