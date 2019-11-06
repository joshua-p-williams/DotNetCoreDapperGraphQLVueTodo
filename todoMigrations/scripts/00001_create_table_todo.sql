CREATE TABLE todo (
    id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    item nvarchar(50),
    completed bit NOT NULL DEFAULT 0,
);
GO
