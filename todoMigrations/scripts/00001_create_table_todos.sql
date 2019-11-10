CREATE TABLE Todos (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Details nvarchar(50),
    Completed bit NOT NULL DEFAULT 0,
);
GO
