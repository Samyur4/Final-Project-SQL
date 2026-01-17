INSERT INTO Genres (Name) VALUES 
('Fiction'), ('Science Fiction'), ('Mystery'), ('Biography'), ('History'), 
('Fantasy'), ('Romance'), ('Horror'), ('Self-Help'), ('Children');

INSERT INTO Publishers (Name, Address) VALUES 
('Penguin Random House', 'New York'), ('HarperCollins', 'London'), 
('Simon & Schuster', 'New York'), ('Macmillan Publishers', 'London'), 
('Hachette Book Group', 'Paris'), ('Oxford University Press', 'Oxford');

INSERT INTO Authors (FullName) VALUES 
('George Orwell'), ('J.K. Rowling'), ('Stephen King'), ('Agatha Christie'), 
('J.R.R. Tolkien'), ('Ernest Hemingway'), ('Mark Twain'), ('Leo Tolstoy'), 
('Jane Austen'), ('Virginia Woolf'), ('F. Scott Fitzgerald'), ('Charles Dickens');

INSERT INTO Books (Title, ISBN, GenreID, PublisherID) VALUES 
('1984', '9780451524935', 2, 1), ('Harry Potter', '9780439708180', 6, 2), 
('The Shining', '9780307743657', 8, 3), ('Murder on the Orient Express', '9780062073501', 3, 4), 
('The Hobbit', '9780547928227', 6, 5), ('The Old Man and the Sea', '9780684801223', 1, 3), 
('Tom Sawyer', '9780143039563', 1, 1), ('War and Peace', '9780140447934', 5, 6), 
('Pride and Prejudice', '9780141439518', 7, 1), ('To the Lighthouse', '9780156907392', 1, 2), 
('The Great Gatsby', '9780743273565', 1, 3), ('Oliver Twist', '9780141439747', 1, 4), 
('Animal Farm', '9780451526342', 1, 1), ('It', '9781501142970', 8, 3), 
('Dune', '9780441172719', 2, 5);

INSERT INTO BookAuthors (BookID, AuthorID) VALUES 
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7), (8, 8), (9, 9), (10, 10);

INSERT INTO Members (FirstName, LastName, Email) VALUES 
('John', 'Doe', 'john@example.com'), ('Jane', 'Smith', 'jane@example.com'), 
('Alice', 'Johnson', 'alice@example.com'), ('Bob', 'Brown', 'bob@example.com'), 
('Charlie', 'Davis', 'charlie@example.com'), ('David', 'Wilson', 'david@example.com'), 
('Eva', 'Miller', 'eva@example.com'), ('Frank', 'Moore', 'frank@example.com'), 
('Grace', 'Taylor', 'grace@example.com'), ('Henry', 'Anderson', 'henry@example.com'), 
('Ivy', 'Thomas', 'ivy@example.com'), ('Jack', 'Jackson', 'jack@example.com'), 
('Karl', 'White', 'karl@example.com'), ('Lily', 'Harris', 'lily@example.com'), 
('Mike', 'Martin', 'mike@example.com');

INSERT INTO Staff (FullName, Position) VALUES 
('Alice Manager', 'Director'), ('Bob Librarian', 'Head Librarian'), 
('Charlie Staff', 'Assistant'), ('Daisy Staff', 'Assistant'), 
('Edward Clerk', 'Clerk');

INSERT INTO Branches (BranchName, Location) VALUES 
('Central Library', 'Downtown'), ('West Branch', 'Suburbia'), 
('East Branch', 'University District');

INSERT INTO Loans (BookID, MemberID, LoanDate, ReturnDate) VALUES 
(1, 1, '2023-01-01', '2023-01-15'), (2, 2, '2023-01-05', '2023-01-20'), 
(3, 3, '2023-02-01', NULL), (4, 4, '2023-02-10', '2023-02-25'), 
(5, 5, '2023-03-01', NULL), (6, 6, '2023-03-15', '2023-03-30'), 
(7, 7, '2023-04-01', NULL), (8, 8, '2023-04-05', '2023-04-20'), 
(9, 9, '2023-05-01', NULL), (10, 10, '2023-05-10', '2023-05-25');

INSERT INTO Fines (LoanID, Amount, IsPaid) VALUES 
(1, 5.00, 1), (2, 2.50, 0), (4, 10.00, 1), (6, 0.00, 1), (8, 3.75, 0);

GO

SELECT b.Title, a.FullName, g.Name
FROM Books b
JOIN BookAuthors ba ON b.BookID = ba.BookID
JOIN Authors a ON ba.AuthorID = a.AuthorID
JOIN Genres g ON b.GenreID = g.GenreID;

SELECT m.FirstName, m.LastName, l.LoanDate
FROM Members m
LEFT JOIN Loans l ON m.MemberID = l.MemberID;

SELECT g.Name, COUNT(b.BookID) AS TotalBooks
FROM Genres g
LEFT JOIN Books b ON g.GenreID = b.GenreID
GROUP BY g.Name;

SELECT l.MemberID, SUM(f.Amount) AS TotalFines
FROM Fines f
JOIN Loans l ON f.LoanID = l.LoanID
GROUP BY l.MemberID;