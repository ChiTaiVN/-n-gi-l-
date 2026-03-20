CREATE DATABASE QuanLyEnventCLB
GO
-- Table Phan quyen
CREATE TABLE Role (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL
);
GO
-- Users Table
create table [User](
	UserID int primary key identity(1,1),
    RoleID int foreign key references Role(RoleID),
    StudentID nvarchar(20),
    FullName nvarchar(100) not null,
    Email nvarchar(100) not null unique,
    PasswordHash varchar(255) not null,
    IsActive BIT DEFAULT 1
);
GO
-- Event Table
CREATE TABLE Event (
    EventID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Location NVARCHAR(255),
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    MaxAttendees INT,
    Status NVARCHAR(50) DEFAULT 'Upcoming', 
    CreatedBy INT FOREIGN KEY REFERENCES [User](UserID)
);
GO
-- EventRegistration Table
CREATE TABLE EventRegistration (
    RegistrationID INT PRIMARY KEY IDENTITY(1,1),
    EventID INT FOREIGN KEY REFERENCES Event(EventID),
    UserID INT FOREIGN KEY REFERENCES [User](UserID),
    RegistrationDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'Registered', 
    QRCodeString VARCHAR(255) UNIQUE,
    IsCheckedIn BIT DEFAULT 0,
    CheckInTime DATETIME NULL,
    CheckInMethod NVARCHAR(50) NULL 
);
GO
-- Task Table
CREATE TABLE EventTask (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    EventID INT FOREIGN KEY REFERENCES Event(EventID),
    AssignedTo INT FOREIGN KEY REFERENCES [User](UserID),
    TaskName NVARCHAR(255) NOT NULL,
    Status NVARCHAR(50) DEFAULT 'To Do' 
);
GO
-- Budget Table
CREATE TABLE EventBudget (
    BudgetID INT PRIMARY KEY IDENTITY(1,1),
    EventID INT FOREIGN KEY REFERENCES Event(EventID),
    ItemName NVARCHAR(255) NOT NULL,
    Amount DECIMAL(15, 2) NOT NULL,
    Type NVARCHAR(50) 
);
GO
-- Equipment Table
CREATE TABLE EventEquipment (
    EquipmentID INT PRIMARY KEY IDENTITY(1,1),
    EventID INT FOREIGN KEY REFERENCES Event(EventID),
    ItemName NVARCHAR(255) NOT NULL,
    Quantity INT DEFAULT 1,
    Status NVARCHAR(50) DEFAULT 'Preparing' 
);
GO
-- Document Table
CREATE TABLE EventDocument (
    DocumentID INT PRIMARY KEY IDENTITY(1,1),
    EventID INT FOREIGN KEY REFERENCES Event(EventID),
    FileName NVARCHAR(255) NOT NULL,
    FileURL NVARCHAR(500) NOT NULL,
    FileType NVARCHAR(50)
);
GO
-- Certificate Table
CREATE TABLE Certificate (
    CertificateID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES [User](UserID),
    EventID INT FOREIGN KEY REFERENCES Event(EventID),
    IssuedDate DATETIME DEFAULT GETDATE(),
    CertificateURL NVARCHAR(500) NOT NULL
);
GO
-- Feedback Table
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    EventID INT FOREIGN KEY REFERENCES Event(EventID),
    UserID INT FOREIGN KEY REFERENCES [User](UserID),
    Rating INT CHECK (Rating >= 1 AND Rating <= 5),
    Comment NVARCHAR(MAX),
    SubmittedAt DATETIME DEFAULT GETDATE()
);

-- *****
-- Add Data 
-- *****


-- Add Data table Role
INSERT INTO Role (RoleName) 
VALUES 
    (N'Admin CLB'), (N'Ban Tổ Chức'), (N'Sinh Viên'), (N'Khách Mời'), (N'Cố Vấn Học Tập');

-- Add Data table Users
INSERT INTO [User] (RoleID, StudentID, FullName, Email, PasswordHash, IsActive) 
VALUES 
    (1, 'ADMIN001', N'Nguyễn Văn Trưởng', 'admin@clb.edu.vn', 'hash_1', 1),
    (2, 'BTC001', N'Trần Thị Hậu Cần', 'haucan@clb.edu.vn', 'hash_2', 1),
    (3, '490101001', N'Lê Minh Sinh', 'minhsinh@student.edu.vn', 'hash_3', 1),
    (3, '490101002', N'Phạm Thu Thảo', 'thuthao@student.edu.vn', 'hash_4', 1),
    (5, NULL, N'Th.S Nguyễn Cố Vấn', 'covan@clb.edu.vn', 'hash_5', 1);

-- Add Data table event
INSERT INTO Event (Title, Description, Location, StartTime, EndTime, MaxAttendees, Status, CreatedBy) 
VALUES 
    (N'Cuộc thi Capture The Flag (CTF) Mở rộng 2026', N'Giải đấu an toàn thông tin, giải các challenge về web, crypto', N'Phòng Máy A1', '2026-04-10 08:00:00', '2026-04-10 17:00:00', 50, 'Upcoming', 1),
    (N'Workshop: Lập trình Game cơ bản với C#', N'Hướng dẫn xây dựng game 2D cơ bản từ con số 0', N'Hội trường B', '2026-04-15 14:00:00', '2026-04-15 17:00:00', 100, 'Upcoming', 1),
    (N'Giải Đấu Cờ Vua Sinh Viên 2026', N'Giao lưu cờ vua hệ Thụy Sĩ 7 ván', N'Nhà thi đấu', '2026-04-20 07:30:00', '2026-04-20 18:00:00', 64, 'Upcoming', 1),
    (N'Triển lãm Dự án Vi điều khiển Arduino', N'Trưng bày các dự án IoT, mạch điện tử của sinh viên', N'Sảnh chính', '2026-05-05 08:00:00', '2026-05-05 11:30:00', 200, 'Upcoming', 1),
    (N'Hội thảo: Ứng dụng Tâm lý học trong học tập', N'Khám phá các nguyên lý học tập hiệu quả, cách ghi nhớ lâu', N'Hội trường A', '2026-03-10 18:00:00', '2026-03-10 20:30:00', 150, 'Completed', 1);

-- Add Data table Registration
INSERT INTO EventRegistration (EventID, UserID, RegistrationDate, Status, QRCodeString, IsCheckedIn, CheckInMethod) 
VALUES 
    (1, 3, GETDATE(), 'Registered', 'QR_EV1_US3_12345', 0, NULL),
    (2, 3, GETDATE(), 'Registered', 'QR_EV2_US3_54321', 0, NULL),
    (3, 4, GETDATE(), 'Registered', 'QR_EV3_US4_99999', 0, NULL),
    (4, 4, GETDATE(), 'Cancelled', 'QR_EV4_US4_88888', 0, NULL),
    (5, 3, '2026-03-01 10:00:00', 'Registered', 'QR_EV5_US3_11111', 1, 'Scan QR');

-- Add Data table Task
INSERT INTO EventTask (EventID, AssignedTo, TaskName, Status) 
VALUES 
    (1, 2, N'Thiết lập Server cho các bài thi CTF', 'To Do'),
    (2, 2, N'In ấn slide tài liệu hướng dẫn Game Dev', 'In Progress'),
    (3, 2, N'Thuê 30 bộ bàn cờ vua và đồng hồ bấm giờ', 'Done'),
    (4, 2, N'Chuẩn bị cáp nối, ổ điện cho các đội Arduino', 'To Do'),
    (5, 2, N'Gửi thư mời cho Diễn giả Tâm lý học', 'Done');

-- Add Data table budget
INSERT INTO EventBudget (EventID, ItemName, Amount, Type) 
VALUES 
    (1, N'Tiền thưởng giải Nhất CTF', 2000000.00, 'Expense'),
    (2, N'Tài trợ từ công ty phần mềm', 5000000.00, 'Income'),
    (3, N'Lệ phí tham gia giải cờ vua', 1280000.00, 'Income'),
    (4, N'Chi phí mua linh kiện dự phòng', 800000.00, 'Expense'),
    (5, N'Tiền nước uống cho người tham dự', 300000.00, 'Expense');

-- Add Data table Equipment
INSERT INTO EventEquipment (EventID, ItemName, Quantity, Status) 
VALUES 
    (1, N'Laptop làm Server nội bộ', 2, 'Preparing'),
    (2, N'Micro không dây', 4, 'Preparing'),
    (3, N'Đồng hồ thi đấu cờ', 20, 'Borrowed'),
    (4, N'Dây cáp mạng', 10, 'Preparing'),
    (5, N'Màn chiếu dự phòng', 1, 'Returned');

-- Add Data table Document
INSERT INTO EventDocument (EventID, FileName, FileURL, FileType) 
VALUES 
    (1, N'Luật_Thi_Đấu_CTF.pdf', 'https://link.doc/luat_ctf', 'PDF'),
    (2, N'SourceCode_Game_Mau.zip', 'https://link.doc/source_game', 'ZIP'),
    (3, N'Danh_Sach_Bang_Dau.xlsx', 'https://link.doc/bang_dau', 'Excel'),
    (4, N'So_Do_Mach_Arduino.png', 'https://link.doc/sodo', 'Image'),
    (5, N'Slide_TamLyHoc_HocTap.pptx', 'https://link.doc/slide_tamly', 'PowerPoint');

-- Add Data table Certificate
INSERT INTO Certificate (UserID, EventID, IssuedDate, CertificateURL) 
VALUES 
    (3, 5, '2026-03-12 00:00:00', 'https://link.cert/us3_ev5.pdf'),
    (4, 5, '2026-03-12 00:00:00', 'https://link.cert/us4_ev5.pdf'),
    (2, 5, '2026-03-12 00:00:00', 'https://link.cert/us2_ev5.pdf'),
    (3, 1, '2026-04-12 00:00:00', 'https://link.cert/us3_ev1.pdf'),
    (4, 3, '2026-04-22 00:00:00', 'https://link.cert/us4_ev3.pdf');

-- Add Data table FeedBack
INSERT INTO Feedback (EventID, UserID, Rating, Comment, SubmittedAt) 
VALUES 
    (5, 3, 5, N'Diễn giả chia sẻ cách phân bổ thời gian học rất hay.', '2026-03-11 08:00:00'),
    (5, 4, 4, N'Nội dung hữu ích nhưng hội trường hơi nóng.', '2026-03-11 09:30:00'),
    (1, 3, 5, N'Các challenge rất thú vị và bám sát thực tế.', '2026-04-11 10:00:00'),
    (2, 3, 4, N'Tốc độ hướng dẫn code hơi nhanh với người mới.', '2026-04-16 14:00:00'),
    (3, 4, 5, N'Công tác tổ chức bốc thăm ván đấu rất chuyên nghiệp.', '2026-04-21 07:00:00');