CREATE TABLE [dbo].[Projects] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Category] NVARCHAR (50) NOT NULL,
    [Hours]    INT           NOT NULL,
    [Minutes]  INT           NOT NULL,
    [Seconds]  INT           NOT NULL,
    [Hundreds ] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

