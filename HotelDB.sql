use HotelDB;
INSERT INTO RoomTypes (Name, Description, BasePricePerNight, MaximumCapacity)
VALUES 
(N'Standard Single', N'Phòng tiêu chuẩn, 1 giường đơn vừa, phù hợp cho 1 người.', 250000, 1),
(N'Superior Single', N'Phòng nâng cấp, 1 giường đơn lớn, có cửa sổ.', 350000, 2),
(N'Standard Couple', N'Phòng tiêu chuẩn, 1 giường đôi lớn, có cửa sổ', 400000, 2),
(N'Superior Couple', N'Phòng nâng cấp, 1 giường đôi lớn, có ban công và bếp.', 500000, 3),
(N'Standard Family', N'Phòng tiêu chuẩn, 2 giường đôi lớn, có cửa sổ.', 600000, 4),
(N'Superior Family', N'Phòng gia đình, 2 giường đôi lớn, có ban công, tủ lạnh.', 750000, 4),
(N'Standard Suite', N'Phòng tiêu chuẩn, nội thất cao cấp, phục vụ riêng.', 2000000, 5);

INSERT INTO Rooms
(RoomNumber, RoomTypeId, Status, IsDeleted, Description, DefaultPrice, CreatedAt, UpdatedAt, MaximumCapacity)
VALUES
-- Standard Single (RoomTypeId = 1)
('101', 1, 1, 0, N'Phòng đơn tiêu chuẩn tầng 1', 250000, GETDATE(), GETDATE(), 1),
('102', 1, 1, 0, N'Phòng đơn tiêu chuẩn tầng 1', 250000, GETDATE(), GETDATE(), 1),

-- Superior Single (RoomTypeId = 2)
('201', 2, 1, 0, N'Phòng đơn nâng cấp có cửa sổ', 350000, GETDATE(), GETDATE(), 2),
('202', 2, 1, 0, N'Phòng đơn nâng cấp có cửa sổ', 350000, GETDATE(), GETDATE(), 2),

-- Standard Couple (RoomTypeId = 3)
('301', 3, 1, 0, N'Phòng đôi tiêu chuẩn tầng 3', 400000, GETDATE(), GETDATE(), 2),
('302', 3, 1, 0, N'Phòng đôi tiêu chuẩn tầng 3', 400000, GETDATE(), GETDATE(), 2),

-- Superior Couple (RoomTypeId = 4)
('401', 4, 1, 0, N'Phòng đôi nâng cấp có ban công', 500000, GETDATE(), GETDATE(), 3),
('402', 4, 1, 0, N'Phòng đôi nâng cấp có ban công', 500000, GETDATE(), GETDATE(), 3),

-- Standard Family (RoomTypeId = 5)
('501', 5, 1, 0, N'Phòng gia đình tiêu chuẩn', 600000, GETDATE(), GETDATE(), 4),
('502', 5, 1, 0, N'Phòng gia đình tiêu chuẩn', 600000, GETDATE(), GETDATE(), 4),

-- Superior Family (RoomTypeId = 6)
('601', 6, 1, 0, N'Phòng gia đình nâng cấp có ban công', 750000, GETDATE(), GETDATE(), 4),
('602', 6, 1, 0, N'Phòng gia đình nâng cấp có ban công', 750000, GETDATE(), GETDATE(), 4),

-- Standard Suite (RoomTypeId = 7)
('701', 7, 1, 0, N'Suite tiêu chuẩn nội thất cao cấp', 2000000, GETDATE(), GETDATE(), 5),
('702', 7, 1, 0, N'Suite tiêu chuẩn nội thất cao cấp', 2000000, GETDATE(), GETDATE(), 5);




INSERT INTO ServiceTypes (Name, Description, CreatedAt, UpdatedAt, ServiceCount)
VALUES
(N'Minibar', N'Sử dụng thức ăn và đồ uống trong minibar của phòng.', GETDATE(), GETDATE(), 0),
(N'Giặt ủi', N'Dịch vụ giặt và ủi quần áo cho khách.', GETDATE(), GETDATE(), 0),
(N'Đưa đón sân bay', N'Dịch vụ đưa đón sân bay bằng xe riêng.', GETDATE(), GETDATE(), 0),
(N'Thuê xe máy / ô tô', N'Dịch vụ cho thuê xe để khách tự di chuyển.', GETDATE(), GETDATE(), 0),
(N'Spa & Massage', N'Dịch vụ chăm sóc sức khỏe và thư giãn.', GETDATE(), GETDATE(), 0),
(N'Room Service', N'Gọi món ăn và đồ uống phục vụ tại phòng.', GETDATE(), GETDATE(), 0),
(N'Bữa sáng', N'Cung cấp bữa sáng buffet hoặc phục vụ tận phòng.', GETDATE(), GETDATE(), 0),
(N'Làm sạch phòng', N'Dịch vụ dọn phòng theo yêu cầu.', GETDATE(), GETDATE(), 0),
(N'Karaoke', N'Dịch vụ hát karaoke tại khách sạn.', GETDATE(), GETDATE(), 0),
(N'Hồ bơi', N'Sử dụng hồ bơi và tiện ích đi kèm.', GETDATE(), GETDATE(), 0);

select * from ServiceTypes;

INSERT INTO Services (ServiceTypeId, ServiceName, Description, UnitPrice, CreatedAt, UpdatedAt, IsAvailable)
VALUES
-- 1. Minibar
(3, N'Nước suối', N'Nước suối 500ml trong minibar.', 20000, GETDATE(), GETDATE(), 1),
(3, N'Coca Cola', N'Nước ngọt Coca Cola lon 330ml.', 30000, GETDATE(), GETDATE(), 1),
(3, N'Snack', N'Bim bim, snack khoai tây các loại.', 25000, GETDATE(), GETDATE(), 1),

-- 2. Giặt ủi
(4, N'Giặt áo quần', N'Giặt và sấy quần áo thường.', 30000, GETDATE(), GETDATE(), 1),
(4, N'Ủi quần áo', N'Ủi sơ mi, quần tây.', 20000, GETDATE(), GETDATE(), 1),
(4, N'Giặt nhanh 2 giờ', N'Giặt gấp và trả trong vòng 2 giờ.', 60000, GETDATE(), GETDATE(), 1),

-- 3. Đưa đón sân bay
(5, N'Đưa sân bay', N'Xe đưa khách từ khách sạn đến sân bay.', 200000, GETDATE(), GETDATE(), 1),
(5, N'Đón sân bay', N'Xe đón khách từ sân bay về khách sạn.', 250000, GETDATE(), GETDATE(), 1),

-- 4. Thuê xe
(6, N'Thuê xe máy', N'Thuê xe máy theo ngày (24h).', 150000, GETDATE(), GETDATE(), 1),
(6, N'Thuê ô tô 4 chỗ', N'Thuê xe ô tô nhỏ theo ngày.', 800000, GETDATE(), GETDATE(), 1),
(6, N'Thuê ô tô 7 chỗ', N'Thuê xe 7 chỗ theo ngày.', 1000000, GETDATE(), GETDATE(), 1),

-- 5. Spa & Massage
(7, N'Massage chân', N'Massage foot 45 phút.', 250000, GETDATE(), GETDATE(), 1),
(7, N'Massage toàn thân', N'Thư giãn full body 60 phút.', 400000, GETDATE(), GETDATE(), 1),
(7, N'Sauna', N'Sử dụng phòng xông hơi.', 150000, GETDATE(), GETDATE(), 1),

-- 6. Room Service
(8, N'Cơm chiên hải sản', N'Gọi món phục vụ tại phòng.', 90000, GETDATE(), GETDATE(), 1),
(8, N'Mì xào bò', N'Phục vụ tại phòng.', 80000, GETDATE(), GETDATE(), 1),
(8, N'Canh chua cá', N'Món ăn Việt truyền thống.', 120000, GETDATE(), GETDATE(), 1),

-- 7. Bữa sáng
(9, N'Buffet sáng', N'Sử dụng buffet sáng tại nhà hàng.', 150000, GETDATE(), GETDATE(), 1),
(9, N'Set menu sáng', N'Bữa sáng đơn giản với trứng và bánh mì.', 80000, GETDATE(), GETDATE(), 1),

-- 8. Làm sạch phòng
(10, N'Dọn phòng', N'Dọn dẹp tiêu chuẩn theo yêu cầu.', 50000, GETDATE(), GETDATE(), 1),
(10, N'Thay drap giường', N'Thay khăn trải và chăn mới.', 70000, GETDATE(), GETDATE(), 1),

-- 9. Karaoke
(11, N'Karaoke phòng nhỏ', N'Thuê phòng karaoke 1 giờ.', 200000, GETDATE(), GETDATE(), 1),
(11, N'Karaoke phòng lớn', N'Thuê phòng lớn 1 giờ.', 350000, GETDATE(), GETDATE(), 1),

-- 10. Hồ bơi
(12, N'Ve vào hồ bơi', N'Sử dụng hồ bơi trong ngày.', 80000, GETDATE(), GETDATE(), 1),
(12, N'Thuê khăn tắm', N'Thuê khăn bơi.', 20000, GETDATE(), GETDATE(), 1);

select * from Rooms;
Update Rooms SET CreatedAt = GETDATE(), UpdatedAt = GETDATE() WHERE 1=1;

select * from Services;

INSERT INTO Customers (FullName, Phone, IdNumber, Address, Email, CreatedAt, UpdatedAt)
VALUES
(N'Nguyễn Văn An', '0905123456', '079123456789', N'123 Nguyễn Trãi, Hà Nội', 'an.nguyen@example.com', GETDATE(), GETDATE()),

(N'Trần Thị Bích', '0912345678', '014987654321', N'45 Lê Lợi, TP. Hồ Chí Minh', 'bich.tran@example.com', GETDATE(), GETDATE()),

(N'Lê Hoàng Nam', '0988111222', '083112233445', N'30 Trần Hưng Đạo, Đà Nẵng', 'nam.le@example.com', GETDATE(), GETDATE()),

(N'Phạm Hồng Phúc', '0933445566', '086556677889', N'12 Hai Bà Trưng, Hải Phòng', 'phuc.pham@example.com', GETDATE(), GETDATE()),

(N'Hoàng Ngọc Anh', '0977553322', '025443322110', N'89 Nguyễn Huệ, Cần Thơ', 'anh.hoang@example.com', GETDATE(), GETDATE());

INSERT INTO Users(FullName, Username, Gender, Phone, Role, IsActive, Address, Email, IdNumber, PasswordHash, CreatedAt, UpdatedAt) VALUES
(N'Trần Nhân Phát', 'tnf2025', N'Nam', '0928520938', 1, 1, N'Hà Nội', 'tnf2025@example.com', '029292975205', 'i2Bv7pmnzKTEKVTA1SzsxwkR1b2yLrjXK/9g1iucCogA+ygx', GETDATE(), GETDATE()),
(N'Vũ Xuân Nin', 'vxn2025', N'Nam', '0982572954', 2, 1, N'Hà Nội', 'vxn2025@example.com', '029499373086', 'i2Bv7pmnzKTEKVTA1SzsxwkR1b2yLrjXK/9g1iucCogA+ygx', GETDATE(), GETDATE());

select * from users;
INSERT INTO Bookings
(FullName, Phone, IdNumber, RoomId, BookedPrice, BookingDate, CancelDate, 
 CheckInDate, CheckOutDate, Status, UpdatedAt, UserId)
VALUES
-- 1. Khách đặt phòng 101 (Standard Single, giá 500k)
(N'Nguyễn Văn An', '0905123456', '079123456789',
 2, 500000, GETDATE(), NULL,
 '2025-01-03', '2025-01-05', 0, GETDATE(), 1),   -- Pending

-- 2. Khách đặt phòng 102 (Standard Single, giá 500k)
(N'Trần Thị Bích', '0912345678', '014987654321',
 3, 500000, GETDATE(), NULL,
 '2025-01-10', '2025-01-12', 1, GETDATE(), 2),   -- Confirmed

-- 3. Khách đặt phòng 104 (Standard Twin, bảo trì – vẫn gán ví dụ)
(N'Lê Hoàng Nam', '0988111222', '083112233445',
 5, 600000, GETDATE(), NULL,
 '2025-02-01', '2025-02-03', 0, GETDATE(), 1),   -- Pending

-- 4. Khách đặt phòng 201 (Superior Single, giá 700k)
(N'Phạm Hồng Phúc', '0933445566', '086556677889',
 7, 700000, GETDATE(), NULL,
 '2025-01-20', '2025-01-22', 2, GETDATE(), 2),   -- CheckedIn

-- 5. Khách đặt phòng 204 (Superior Twin, view tốt – 1,2 triệu)
(N'Hoàng Ngọc Anh', '0977553322', '025443322110',
 10, 1200000, GETDATE(), NULL,
 '2025-03-02', '2025-03-05', 1, GETDATE(), 1),    -- Confirmed

-- 6. Khách đặt phòng 303 (Standard Triple, giá 900k)
(N'Đặng Minh Khôi', '0917001122', '066998877665',
 14, 900000, GETDATE(), NULL,
 '2025-04-01', '2025-04-04', 0, GETDATE(), 2),     -- Pending

-- 7. Khách đặt phòng 304 (Standard Triple, giá 900k)
(N'Lưu Thị Hà', '0987665544', '051556677889',
 15, 900000, GETDATE(), NULL,
 '2025-05-10', '2025-05-13', 3, GETDATE(), 2);     -- CheckedOut


