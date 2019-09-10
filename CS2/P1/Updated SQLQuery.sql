use ChatbotDB;
create table Monitors(
monitors_no int primary key,
measurment nvarchar(255),
touchscreen nvarchar(255),
category nvarchar(255),
portablity_1 nvarchar(255),
feature_1 nvarchar(255),
size_1 nvarchar(255),
feature_2 nvarchar(255),
feature_3 nvarchar(255),
portablity_2 nvarchar(255),
[ante/intrapartum] nvarchar(255),
display_mode nvarchar(255),
weights nvarchar(255),
feature_4 nvarchar(255),
invasive_bp nvarchar(255),
co2_measurment nvarchar(255),
nbp_measurment nvarchar(255),
speed nvarchar(255),
storage_size nvarchar(255),
monitors_name nvarchar(255)
);
insert into Monitors
select * from ChatbotTable$ order by(monitors_no)
create table Customer
(
 customer_name nvarchar(255),
 customer_email nvarchar(255) primary key,
 customer_phone varchar(10)
)

create table MonitorsPreference
(
customer_email nvarchar(255),
monitors_no int,
check_in datetime,
primary key(customer_email,monitors_no,check_in),
 foreign key(customer_email) references Customer(customer_email),
 foreign key(monitors_no) references Monitors(monitors_no)
)