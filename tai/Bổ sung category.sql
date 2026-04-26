USE QuanLyEnventCLB;
GO

-- Thêm cột Category (Danh mục) vào bảng Event
ALTER TABLE [Event] ADD Category NVARCHAR(100);
GO

-- Cập nhật danh mục mẫu cho các sự kiện hiện có để lát nữa test bộ lọc
UPDATE [Event] SET Category = N'Học thuật' WHERE EventID IN (1, 5); -- CTF, Tâm lý học
UPDATE [Event] SET Category = N'Kỹ năng' WHERE EventID = 2; -- Lập trình Game
UPDATE [Event] SET Category = N'Thể thao' WHERE EventID = 3; -- Cờ vua
UPDATE [Event] SET Category = N'Triển lãm' WHERE EventID = 4; -- Arduino
GO