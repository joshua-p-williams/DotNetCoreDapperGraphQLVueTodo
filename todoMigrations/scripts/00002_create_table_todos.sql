CREATE TABLE Todos (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Details nvarchar(50),
    CategoryId int,
    Completed bit NOT NULL DEFAULT 0,
);
GO
ALTER TABLE Todos 
ADD FOREIGN KEY (CategoryId)
REFERENCES Categories (Id);
GO
