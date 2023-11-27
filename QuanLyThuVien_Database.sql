Use [QuanLyThuVien]

-- -------------------------------
-- Table 1: structure for Reader
-- -------------------------------
create table Reader (
	[Id] varchar(10) not null primary key,
	[LName] nvarchar(100) not null,
	[FName] nvarchar(20) not null,
	[boF] DateTime not null,
	[ReaderType] bit not null,
	[Status] bit not null default(1),
	[CreatedAt] DateTime not null,
	[ModifiedAt] DateTime not null,
)

-- ----------------------------
-- Records of Reader
-- ----------------------------
insert into [Reader] ([Id], [LName], [FName], [boF], [ReaderType], [CreatedAt], [ModifiedAt])
values
('R01', N'Trần Văn' , N'A', '1970-12-11', 1, '2023-09-12', '2023-09-12'),
('R02', N'Nguyễn Thị', N'Hà', '1970-1-11', 1, '2023-09-10', '2023-09-10'),
('R03', N'Nguyễn Văn', N'Bưởi', '1970-2-11', 1, '2023-09-12', '2023-09-12'),
('R04', N'Nguyễn Thúc Hà', N'Tiên', '2010-4-11', 0, '2023-09-14', '2023-09-14'),
('R05', N'Lê Văn', N'Lực', '2010-07-11', 0, '2023-09-12', '2023-09-12'),
('R06', N'Lê Văn', N'Bảy', '2010-07-11', 0, '2023-09-12', '2023-09-12')

-- -------------------------------
-- Table 2: structure for Adult
-- -------------------------------
create table Adult (
	[IdReader] varchar(10) not null primary key,
	[Identify] varchar(12),
	[Address] nvarchar(100) not null,
	[City] nvarchar(100) not null,
	[Phone] varchar(12) not null,
	[ExpireDate] DateTime not null,
	[Status] bit not null default(1),
	[CreatedAt] DateTime not null,
	[ModifiedAt] DateTime not null,
	
	foreign key ([IdReader]) references Reader([Id])
)

-- ----------------------------
-- Records of Adult
-- ----------------------------
insert into [Adult] ([IdReader], [Identify], [Address], [City], [Phone], [ExpireDate], [CreatedAt], [ModifiedAt])
values
('R01', '123456789012', N'Số 2, Lê Thắng Tôn', N'Khánh Hòa', '0935768249', '2024-09-12', '2023-09-12', '2023-09-12'),
('R02', '234567890123', N'Số 10 Trần Quý Cáp', N'Khánh Hòa', '0123222111', '2024-09-10', '2023-09-10', '2023-09-10'),
('R03', '345678901234', N'Số 3 Trần Nhân Tông', N'Khánh Hòa','0145333111', '2024-09-12', '2023-09-12', '2023-09-12')

-- -------------------------------
-- Table 3: structure for Child
-- -------------------------------
create table Child (
	[IdReader] varchar(10) not null primary key,
	[IdAdult] varchar(10) not null,
	[Status] bit not null default(1),
	[CreatedAt] DateTime not null,
	[ModifiedAt] DateTime not null,
	
	foreign key ([IdReader]) references Reader([ID]),
	foreign key ([IdAdult]) references Adult([IdReader])
)

-- ----------------------------
-- Records of Child
-- ----------------------------
insert into [Child] ([IdReader], [IdAdult], [CreatedAt], [ModifiedAt])
values
	('R04', 'R01', '2023-09-14', '2023-09-14'),
	('R05', 'R01', '2023-09-12', '2023-09-12'),
	('R06', 'R02', '2023-09-12', '2023-09-12')

-- -------------------------------
-- Table 4: structure for Publisher
-- -------------------------------
create table Publisher (
	[Id] varchar(10) not null primary key,
	[Name] nvarchar(100) not null,
	[Phone] varchar(12) not null,
	[Address] nvarchar(100) not null,
)

-- ----------------------------
-- Records of Publisher
-- ----------------------------
insert into [Publisher]
values
('P01', N'NXB Kim Đồng', '0901931765', '79 Hoàng Hoa Thám'),
('P02', N'NXB Kim Lân', '0901000765', '79 Hoàng Hoa Thụ'),
('P03', N'NXB Hải Quân', '0101000765', '79 Hoàng Hoa Hái')

-- -------------------------------
-- Table 5: structure for Category
-- -------------------------------
create table Category (
	[Id] varchar(10) not null primary key,
	[Name] nvarchar(50) not null,
	[Status] bit not null default(1),
	[CreatedAt] DateTime not null,
	[ModifiedAt] DateTime not null,
)

-- ----------------------------
-- Records of Category
-- ----------------------------
insert into [Category] ([Id], [Name], [CreatedAt], [ModifiedAt])
values
	('C01', N'Truyện tranh', '2023-09-14', '2023-09-14'),
	('C02', N'Tiểu thuyết', '2023-09-15', '2023-09-15'),
	('C03', N'Luật Pháp', '2023-09-16', '2023-09-16')

-- -------------------------------
-- Table 6: structure for Author
-- -------------------------------
create table Author (
	[Id] varchar(10) not null primary key,
	[Name] nvarchar(50) not null,
	[Description] ntext not null,
	[boF] DateTime not null,
	[Summary] ntext not null,
	[Status] bit not null default(1),
	[CreatedAt] DateTime not null,
	[ModifiedAt] DateTime not null,
)

-- ----------------------------
-- Records of Author
-- ----------------------------
insert into [Author] ([Id], [Name], [Description], [boF], [Summary], [CreatedAt], [ModifiedAt])
values
	('A01', N'Nguyễn Nhật Ánh', N'Tác giả của nhiều tác phẩm văn học nổi tiếng như "Cho tôi xin một vé đi tuổi thơ", "Kính vạn hoa", "Tôi thấy hoa vàng trên cỏ xanh"', '1980-11-05', N'Tác giả nổi tiếng Việt Nam', '2020-02-02', '2020-02-02'),
	('A02', N'Ngô Thị Thúy Vân', N'Tác giả của cuốn sách "Bí mật của tôi" được đánh giá cao về nội dung và phong cách viết', '1999-07-02', N'Tác giả triển vọng', '2020-01-01', '2020-01-01'),
	('A03', N'Lê Minh Tú', N'Tác giả của cuốn sách "Sống thật lòng" đã gây được tiếng vang lớn trong giới trẻ', '1994-11-02', N'Tác giả trẻ có tầm ảnh hưởng', '2021-01-01', '2021-01-01'),
	('A04', N'Fujiko Fujio', N'Tác giả của bộ truyện tranh nổi tiếng "Doraemon" đã trở thành một biểu tượng văn hóa của Nhật Bản', '1933-12-01', N'Tác giả truyện tranh nổi tiếng', '2021-05-05', '2021-05-05'),
	('A05', N'Nguyễn Thị Hà', N'Tác giả của cuốn sách "Đi tìm giấc mơ" được đánh giá cao về tính nhân văn và sự tinh tế trong cách diễn đạt', '2001-01-02', N'Tác giả trẻ triển vọng', '2022-10-01', '2022-10-01')

-- -------------------------------
-- Table 7: structure for BookTitle
-- -------------------------------
create table BookTitle (
	[Id] varchar(10) not null primary key,
	[IdCategory] varchar(10) not null,
	[Name] nvarchar(100) not null,
	[IdAuthor] varchar(10) not null,
	[Summary] ntext not null,
	
	foreign key ([IdCategory]) references Category([ID]),
	foreign key ([IdAuthor]) references Author([ID])
)

-- ----------------------------
-- Records of BookTitle
-- ----------------------------
insert into [BookTitle] ([Id], [IdCategory], [Name], [IdAuthor], [Summary])
values
	('BT01', 'C03', N'Tự truyện của 1 luật sư', 'A05', N'Nội dung hấp dẫn'),
	('BT02', 'C01', N'Doraemon', 'A04', N'Cuốn sách rất thú vị và đáng đọc'),
	('BT03', 'C02', N'Giết con chim nhại', 'A02', N'Một cuốn sách tuyệt vời cho những người yêu thích thể loại tiểu thuyết'),
	('BT04', 'C01', N'Trò Chơi Thế Thân', 'A01', N'Tác phẩm đầy cảm hứng'),
	('BT05', 'C02', N'Con chim xanh biếc bay về', 'A03', N'Tác giả đã tạo ra một câu chuyện đầy cảm hứng và ý nghĩa')
	
-- -------------------------------
-- Table 7: structure for BookISBN
-- -------------------------------
create table BookISBN (
	[ISBN] varchar(10) not null primary key,
	[IdBookTitle] varchar(10) not null,
	[IdAuthor] varchar(10) not null,
	[PublishDate] DateTime not null,
	[Language] nvarchar(50) not null,
	[Status] bit not null default(1),
	[BookPrice] decimal(12,3) not null,
	[IdPublisher] varchar(10) not null,
	
	foreign key ([IdBookTitle]) references BookTitle([ID]),
	foreign key ([IdAuthor]) references Author([ID]),
	foreign key ([IdPublisher]) references Publisher([Id])
)

-- ----------------------------
-- Records of BookISBN
-- ----------------------------
insert into [BookISBN] ([ISBN], [IdBookTitle], [IdAuthor], [PublishDate], [Language], [Status], [BookPrice], [IdPublisher])
values
	('ISBN01', 'BT01', 'A03', '2019-02-11', N'Tiếng Việt', 1, 99.000, 'P01'),
	('ISBN02', 'BT01', 'A01', '2021-05-15', N'Tiếng Nhật', 1, 78.000, 'P02'),
	('ISBN03', 'BT01', 'A02', '2019-11-12', N'Tiếng Pháp', 0, 60.000, 'P01'),
	('ISBN04', 'BT02', 'A02', '2019-10-01', N'Tiếng Việt', 0, 89.000, 'P03'),
	('ISBN05', 'BT02', 'A05', '2020-11-11', N'Tiếng Pháp', 0, 50.000, 'P01')

-- -------------------------------
-- Table 8: structure for Book
-- -------------------------------
create table Book (
	[Id] int not null primary key,
	[ISBN] varchar(10) not null,
	[Status] bit not null default(1),
	[CreatedAt] DateTime not null,
	[ModifiedAt] DateTime not null,
	[DonGia] decimal(12,3) not null,
	[DonGiaHienTai] decimal(12,3) not null,
	
	foreign key ([ISBN]) references BookISBN([ISBN])
)

-- ----------------------------
-- Records of Book
-- ----------------------------
insert into [Book] ([Id], [ISBN], [Status], [CreatedAt], [ModifiedAt], [DonGia], [DonGiaHienTai])
values
	(1,  'ISBN01', 0, '2023-04-02 12:00', '2023-04-02 12:00', 120.000, 120.000),
	(2,  'ISBN01', 1, '2023-05-02 14:00', '2023-05-02 14:00', 120.000, 120.000),
	(3,  'ISBN01', 1, '2023-06-02 15:30', '2023-06-02 15:30', 120.000, 120.000),
	(4,  'ISBN02', 0, '2023-07-02 13:20', '2023-07-02 13:20', 98.000, 98.000),
	(5,  'ISBN02', 1, '2023-08-02 12:10', '2023-08-02 12:10', 98.000, 98.000),
	(6,  'ISBN02', 1, '2023-09-02 15:10', '2023-09-02 15:10', 98.000, 98.000),
	(7,  'ISBN02', 1, '2023-10-02 05:30', '2023-10-02 05:30', 98.000, 98.000),
	(8,  'ISBN02', 1, '2023-02-01 06:20', '2023-02-01 06:20', 98.000, 98.000),
	(9,  'ISBN02', 1, '2023-03-10 06:30', '2023-03-10 06:30', 98.000, 98.000),
	(10, 'ISBN02', 1, '2023-02-05 14:14', '2023-02-05 14:14', 98.000, 98.000),
	(11, 'ISBN03', 0, '2023-04-02 12:00', '2023-04-02 12:00', 80.000, 80.000)

-- -------------------------------
-- Table 9: structure for Parameter
-- -------------------------------
create table Parameter (
	[Id] varchar(10) not null primary key,
	[Name] nvarchar(100) not null,
	[Description] ntext not null default(''),
	[Value] varchar(100) not null,
	[Status] bit not null default(1),
)

-- ----------------------------
-- Records of Parameter
-- ----------------------------
insert into [Parameter] ([Id], [Name], [Description], [Value])
values
	('QD1', N'Trẻ em được người lớn bảo lãnh', N'Mỗi độc giả người lớn chỉ có thể bảo lãnh tối đa cho số trẻ em là', '2'),
	('QD2', N'Số quyển sách cho phép mượn của người lớn', N'Một độc giả người lớn cùng 1 lúc chỉ được mượn tối đa ? quyển sách thuộc ? đầu sách khác nhau', '5:5'),
	('QD3', N'Số quyển sách cho phép mượn của trẻ em', N'Một độc giả trẻ em cùng 1 lúc chỉ được mượn ? quyển sách', '1'),
	('QD4', N'Số quyển sách đã mượn của người lớn', N'Nếu độc giả người lớn có bảo lãnh trẻ em thì số sách của trẻ em đang mượn sẽ được tính vào số lượng sách đang mượn của độc giả người lớn này', ''),
	('QD5', N'Tình trạng quyển sách trong thư viện', N'Nếu độc giả mượn những đầu sách không còn trong thư viện thì hệ thống sẽ chuyển qua bảng dữ liệu đăng ký', ''),
	('QD6', N'Quá trình mượn của 1 quyển sách', N'Nếu độc giả trả sách thì thông tin mượn sẽ chuyển sang quá trình mượn', ''),
	('QD7', N'Quy định số tuổi tối thiểu của người lớn', N'', '18'),
	('QD8', N'Thời hạn thẻ độc giả', N'', '12'),
	('QD9', N'Số ngày mượn sách', N'', '7'),
	('QD10', N'Số ngày lấy sách đã đăng kí mượn', N'Khi sách đã có trong thư viện thì độc giả đăng ký mượn sẽ lên lấy sách trong thời gian được quy định, nếu không lấy thì phiếu đăng kí tự động hủy', '1')

-- --------------------------------
-- Table 10: structure for Province
-- -------------------------------=
create table Province (
	[Id] int not null primary key,
	[Name] nvarchar(50) not null,
	[Status] bit not null,
)

-- ----------------------------
-- Records of Province
-- ----------------------------
INSERT INTO Province (Id, Name, Status)
VALUES 
	(1, N'Hà Nội', 1),
	(2, N'Hồ Chí Minh', 1),
	(3, N'Đà Nẵng', 1),
	(4, N'Hải Phòng', 1),
	(5, N'Cần Thơ', 1),
	(6, N'An Giang', 1),
	(7, N'Bà Rịa - Vũng Tàu', 1),
	(8, N'Bắc Giang', 1),
	(9, N'Bắc Kạn', 1),
	(10, N'Bạc Liêu', 1),
	(11, N'Bắc Ninh', 1),
	(12, N'Bến Tre', 1),
	(13, N'Bình Định', 1),
	(14, N'Bình Dương', 1),
	(15, N'Bình Phước', 1),
	(16, N'Bình Thuận', 1),
	(17, N'Cà Mau', 1),
	(18, N'Cao Bằng', 1),
	(19, N'Đắk Lắk', 1),
	(20, N'Đắk Nông', 1),
	(21, N'Điện Biên', 1),
	(22, N'Đồng Nai', 1),
	(23, N'Đồng Tháp', 1),
	(24, N'Gia Lai', 1),
	(25, N'Hà Giang', 1),
	(26, N'Hà Nam', 1),
	(27, N'Hà Tĩnh', 1),
	(28, N'Hải Dương', 1),
	(29, N'Hậu Giang', 1),
	(30, N'Hòa Bình', 1),
	(31, N'Hưng Yên', 1),
	(32, N'Khánh Hòa', 1),
	(33, N'Kiên Giang', 1),
	(34, N'Kon Tum', 1),
	(35, N'Lai Châu', 1),
	(36, N'Lâm Đồng', 1),
	(37, N'Lạng Sơn', 1),
	(38, N'Lào Cai', 1),
	(39, N'Long An', 1),
	(40, N'Nam Định', 1),
	(41, N'Nghệ An', 1),
	(42, N'Ninh Bình', 1),
	(43, N'Ninh Thuận', 1),
	(44, N'Phú Thọ', 1),
	(45, N'Quảng Bình', 1),
	(46, N'Quảng Nam', 1),
	(47, N'Quảng Ngãi', 1),
	(48, N'Quảng Ninh', 1),
	(49, N'Quảng Trị', 1),
	(50, N'Sóc Trăng', 1),
	(51, N'Sơn La', 1),
	(52, N'Tây Ninh', 1),
	(53, N'Thái Bình', 1),
	(54, N'Thái Nguyên', 1),
	(55, N'Thanh Hóa', 1),
	(56, N'Thừa Thiên Huế', 1),
	(57, N'Tiền Giang', 1),
	(58, N'Trà Vinh', 1),
	(59, N'Tuyên Quang', 1),
	(60, N'Vĩnh Long', 1),
	(61, N'Vĩnh Phúc', 1),
	(62, N'Yên Bái', 1),
	(63, N'Phú Yên', 1);
	
-- -------------------------------
-- Table 11: structure for User
-- -------------------------------
create table [User] (
	[Id] varchar(10) not null primary key,
	[Username] varchar(60) not null,
	[Password] varchar(60) not null,
	[Status] bit not null default(1),
	[CreatedAt] DateTime not null,
	[ModifiedAt] DateTime not null,
)

-- ----------------------------
-- Records of User
-- ----------------------------
insert into [User] ([Id], [Username], [Password], [Status], [CreatedAt], [ModifiedAt])
values
	('U1', 'nhatminh', 'nhatminh', 1, '2023-10-20 18:20', '2023-10-20 18:20'),
	('U2', 'hungvuong', 'hungvuong', 1, '2023-10-20 18:25', '2023-10-20 18:25'),
	('U3', 'anhquoc', 'anhquoc', 1, '2023-10-20 18:30', '2023-10-20 18:30')


-- -------------------------------
-- Table 12: structure for UserInfo
-- -------------------------------
create table [UserInfo] (
	[IdUser] varchar(10) not null primary key,
	[LName] nvarchar(60) not null,
	[FName] nvarchar(60) not null,
	[Phone] varchar(12) not null,
	[Address] nvarchar(100) not null,
	
	foreign key ([IdUser]) references [User]([Id]),
)

-- ----------------------------
-- Records of UserInfo
-- ----------------------------
insert into [UserInfo] ([IdUser], [LName], [FName], [Phone], [Address])
values
	('U1', N'Dương Nhật', N'Minh', '0935768249', N'Số 2, Lê Thắng Tôn'),
	('U2', N'Nghiêm Hùng', N'Vương', '0123222111', N'Số 10 Trần Quý Cáp'),
	('U3', N'Lê Anh', N'Quốc', '0901931765', N'Số 9 Lư Giang')

-- -------------------------------
-- Table 13: structure for Role
-- -------------------------------
create table [Role] (
	[Id] varchar(10) not null primary key,
	[Name] nvarchar(60) not null,
	[Group] nvarchar(60) not null,
	[Status] bit not null default(1),
)

-- ----------------------------
-- Records of Role
-- ----------------------------
insert into [Role] ([Id], [Name], [Group], [Status])
values
	('R1', N'admin', N'administration', 1),
	('R2', N'librarian 1', N'librarian', 1),
	('R3', N'librarian 2', N'librarian', 1)
	
-- -------------------------------
-- Table 14: structure for UserRole
-- -------------------------------
create table [UserRole] (
	[Id] varchar(10) not null primary key,
	[IdUser] varchar(10) not null,
	[IdRole] varchar(10) not null,
	
	foreign key ([IdUser]) references [User]([Id]),
	foreign key ([IdRole]) references [Role]([Id]),
)

-- ----------------------------
-- Records of UserRole
-- ----------------------------
insert into [UserRole] ([Id], [IdUser], [IdRole])
values
	('UR1', 'U1', 'R1'),
	('UR2', 'U2', 'R2'),
	('UR3', 'U3', 'R3')

-- -------------------------------
-- Table 15: structure for Function
-- -------------------------------
create table [Function] (
	[Id] varchar(10) not null primary key,
	[Name] nvarchar(60) not null,
	[Description] ntext not null,
	[IdParent] varchar(10),
	[UrlImage] text,
	[IsAdmin] bit not null default(1),
	[Status] bit not null default(1),
	
	foreign key ([IdParent]) references [Function]([Id]),
)

-- ----------------------------
-- Records of Function
-- ----------------------------
insert into [Function] ([Id], [Name], [Description], [IdParent], [UrlImage], [IsAdmin], [Status])
values
	('F1', N'User Management', '', NULL, '/Images/13.png', 1, 1),
	('F2', N'View user information', '', 'F1', '/Images/6.png', 1, 1),
	('F3', N'Add User', '', 'F1', '/Images/7.png', 1, 1),
	('F4', N'Update User', '', 'F1', '/Images/14.png', 1, 1),
	('F5', N'Delete User', '', 'F1', '/Images/8.png', 1, 1),
	('F6', N'Restore User', '', 'F1', '/Images/9.png', 1, 1),
	
	('F7', N'Feature Management', '', NULL, '/Images/18.png', 1, 1),
	('F8', N'View feature information', '', 'F7', '/Images/6.png', 1, 1),
	('F10', N'Delete feature', '', 'F7', '/Images/8.png', 1, 1),
	('F11', N'Restore feature', '', 'F7', '/Images/9.png', 1, 1),
	
	('F12', N'Role Management', '', NULL, '/Images/19.png', 1, 1),
	('F13', N'View role information', '', 'F12', '/Images/6.png', 1, 1),
	('F14', N'Add Role', '', 'F12', '/Images/7.png', 1, 1),
	('F18', N'Divide roles according to users', '', 'F12', '/Images/15.png', 1, 1),
	('F19', N'Divide roles according to features', '', 'F12', '/Images/16.png', 1, 1),
	('F20', N'Switch user roles', '', 'F12', '/Images/17.png', 1, 1),
	
	('F21', N'Reader Management', '', NULL, '/Images/3.png', 0, 1),
	('F22', N'View reader information', '', 'F21', '/Images/6.png', 0, 1),
	('F23', N'Add Reader', '', 'F21', '/Images/7.png', 0, 1),
	('F24', N'Delete reader', '', 'F21', '/Images/8.png', 0, 1),
	('F25', N'Restore reader', '', 'F21', '/Images/9.png', 0, 1),
	('F26', N'Search reader by identify number', '', 'F21', '/Images/10.png', 0, 1),
	('F27', N'Search reader by name', '', 'F21', '/Images/10.png', 0, 1),
	('F28', N'Transfer children to guardians', '', 'F21', '/Images/12.png', 0, 1),
	
	('F29', N'Book Title Management', '', NULL, '/Images/4.png', 0, 1),
	('F30', N'View Book Title Information', '', 'F29', '/Images/6.png', 0, 1),
	('F31', N'Add Book Title', '', 'F29', '/Images/7.png', 0, 1),
	
	('F32', N'Book ISBN Management', '', NULL, '/Images/4.png', 0, 1),
	('F33', N'View Book ISBN Information', '', 'F32', '/Images/6.png', 0, 1),
	('F34', N'Add Book ISBN', '', 'F32', '/Images/7.png', 0, 1),
	('F35', N'Update book ISBN status (Automatically)', '', 'F32', '/Images/10.png', 0, 1),
	
	('F36', N'Book Management', '', NULL, '/Images/4.png', 0, 1),
	('F37', N'View Book Information', '', 'F36', '/Images/6.png', 0, 1),
	('F38', N'Add Book', '', 'F36', '/Images/7.png', 0, 1),
	('F39', N'Search book by ISBN', '', 'F36', '/Images/10.png', 0, 1),
	('F40', N'Search book by name', '', 'F36', '/Images/10.png', 0, 1)
	
-- -------------------------------
-- Table 16: structure for RoleFunction
-- -------------------------------
create table [RoleFunction] (
	[Id] varchar(10) not null primary key,
	[IdRole] varchar(10) not null,
	[IdFunction] varchar(10) not null,
	
	foreign key ([IdRole]) references [Role]([Id]),
	foreign key ([IdFunction]) references [Function]([Id]),
)

-- ----------------------------
-- Records of RoleFunction
-- ----------------------------
insert into [RoleFunction] ([Id], [IdRole], [IdFunction])
values
	('RF1', 'R1', 'F1'),
	('RF2', 'R1', 'F2'),
	('RF3', 'R1', 'F3'),
	('RF4', 'R1', 'F4'),
	('RF5', 'R1', 'F5'),
	('RF6', 'R1', 'F6'),
	('RF7', 'R1', 'F7'),
	('RF8', 'R1', 'F8'),
	('RF10', 'R1', 'F10'),
	('RF11', 'R1', 'F11'),
	('RF12', 'R1', 'F12'),
	('RF13', 'R1', 'F13'),
	('RF14', 'R1', 'F14'),
	('RF18', 'R1', 'F18'),
	('RF19', 'R1', 'F19'),
	('RF20', 'R1', 'F20'),
	('RF21', 'R2', 'F21'),
	('RF22', 'R2', 'F22'),
	('RF23', 'R2', 'F23'),
	('RF24', 'R2', 'F24'),
	('RF25', 'R2', 'F25'),
	('RF26', 'R2', 'F26'),
	('RF27', 'R2', 'F27'),
	('RF28', 'R2', 'F28'),
	('RF29', 'R2', 'F29'),
	('RF30', 'R2', 'F30'),
	('RF31', 'R2', 'F31'),
	('RF32', 'R2', 'F32'),
	('RF33', 'R2', 'F33'),
	('RF34', 'R2', 'F34'),
	('RF35', 'R2', 'F35'),
	('RF36', 'R2', 'F36'),
	('RF37', 'R2', 'F37'),
	('RF38', 'R2', 'F38'),
	('RF39', 'R2', 'F39'),
	('RF40', 'R2', 'F40')

-- -------------------------------
-- Table 18: structure for Enroll
-- -------------------------------
create table Enroll (
	[Id] varchar(10) not null primary key,
	[ISBN] varchar(10) not null,
	[IdReader] varchar(10) not null,
	[EnrolDate] DateTime not null,
	[ExpiryDate] DateTime,
	[Note] nvarchar(50),
	[IdBook] int,
	
	foreign key ([ISBN]) references [BookISBN]([ISBN]),
	foreign key ([IdReader]) references [Reader]([Id]),
	foreign key ([IdBook]) references [Book]([Id])
)

-- ----------------------------
-- Records of Enroll
-- ----------------------------
insert into [Enroll]
values
('E01', 'ISBN03', 'R03', '2023-11-26 17:00', NULL,'', NULL)

-- -------------------------------
-- Table 19: structure for LoanSlip
-- -------------------------------
create table LoanSlip (
	[Id] varchar(10) not null primary key,
	[IdReader] varchar(10) not null,
	[Quantity] int not null,
	[LoanDate] DateTime not null,	
	[ExpDate] DateTime not null,
	[LoanPaid] decimal(12,3) not null,
	[Deposit] decimal(12,3) not null,
	
	foreign key ([IdReader]) references [Reader]([Id])
)

-- ----------------------------
-- Records of LoanSlip
-- ----------------------------
insert into [LoanSlip]
values
('L01', 'R01', 2, '2023-11-22 17:00', '2023-11-29 17:00', 218.000, 300.000),
('L02', 'R02', 1, '2023-11-24 15:00', '2023-12-01 15:00', 80.000, 100.000)

-- -------------------------------
-- Table 20: structure for LoanDetail
-- -------------------------------
create table LoanDetail (
	[Id] varchar(10) not null primary key,
	[IdLoan] varchar(10) not null,
	[IdBook] int not null,
	[ExpDate] DateTime not null,
	
	foreign key ([IdLoan]) references [LoanSlip]([Id]),
	foreign key ([IdBook]) references [Book]([Id])
)

-- ----------------------------
-- Records of LoanDetail
-- ----------------------------
insert into [LoanDetail]
values
('LDT01', 'L01', 1, '2023-11-29 17:00'),
('LDT02', 'L01', 4, '2023-11-29 17:00'),
('LDT03', 'L02', 11, '2023-12-01 15:00')

-- -------------------------------
-- Table 21: structure for LoanHistory
-- -------------------------------
create table LoanHistory (
	[Id] varchar(10) not null primary key,
	[IdReader] varchar(10) not null,
	[Quantity] int not null,
	[LoanDate] DateTime not null,
	[ExpDate] DateTime not null,
	
	[LoanPaid] decimal(12,3) not null,
	[Deposit] decimal(12,3) not null,
	[RemainPaid] decimal(12,3) not null,
	[FineMoney] decimal(12,3) not null, -- tiền phạt tổng
	[Total] decimal(12,3) not null,
	
	[Note] nvarchar(50),				-- ghi chú
	[CreateAt] DateTime not null,		-- Ngày độc giả trả sách
	
	foreign key ([IdReader]) references [Reader]([Id])
)

-- ----------------------------
-- Records of LoanHistory
-- ----------------------------
--insert into [LoanHistory]
--values

-- -------------------------------
-- Table 22: structure for LoanDetailHistory
-- -------------------------------
create table LoanDetailHistory (
	[Id] varchar(10) not null primary key,
	[IdLoanHistory] varchar(10) not null,
	[IdBook] int not null,
	[ExpDate] DateTime not null,
	[Note] nvarchar(50),				-- Ghi chú: Tình trạng sách
	[PaidMoney] decimal(12,3) not null,	-- Tiền phạt
	
	foreign key ([IdLoanHistory]) references [LoanHistory]([Id]),
	foreign key ([IdBook]) references [Book]([Id])
)

-- ----------------------------
-- Records of LoanDetailHistory
-- ----------------------------
--insert into [LoanDetailHistory]
--values
