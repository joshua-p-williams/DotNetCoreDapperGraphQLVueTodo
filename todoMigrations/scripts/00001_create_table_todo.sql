CREATE TABLE todo (
    id int PRIMARY KEY,
    item nvarchar(50),
    completed bit NOT NULL DEFAULT 0,
);
GO
