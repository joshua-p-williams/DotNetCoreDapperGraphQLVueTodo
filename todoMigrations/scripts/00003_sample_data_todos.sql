INSERT INTO Categories (CategoryName) VALUES ('Default');
INSERT INTO Categories (CategoryName) VALUES ('Home');
INSERT INTO Categories (CategoryName) VALUES ('Work');
GO
INSERT INTO Todos (Details, Completed, CategoryId) VALUES ('Feed the fish', 0, 2);
INSERT INTO Todos (Details, Completed, CategoryId) VALUES ('Change the oil', 1, 1);
INSERT INTO Todos (Details, Completed, CategoryId) VALUES ('Do some coding', 0, 3);
INSERT INTO Todos (Details, Completed, CategoryId) VALUES ('Go to the store', 0, 1);
GO
