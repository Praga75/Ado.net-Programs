use TicketBookingDatabase
----------Creating Data Base
CREATE TABLE TRAIN (
TrainNumber varchar(10) primary key,
TrainName varchar(15),
SourceCity varchar(20),
DestinationCity varchar(20),
TicketPrice float,
TicketAvailable int
);

Insert into TRAIN(TrainNumber,TrainName,SourceCity,DestinationCity,TicketPrice,TicketAvailable)
Values('12022','Kovai Express','Coimbatore','Chennai',450.35,120);

select * from TRAIN

----Insertion
Create Procedure sp_GetTrainDetail
@TrainNumber varchar(10),
@TrainName varchar(15),
@SourceCity varchar(20),
@DestinationCity varchar(20),
@TicketPrice float,
@TicketAvailable int
as
begin
Insert into TRAIN(TrainNumber,TrainName,SourceCity,DestinationCity,TicketPrice,TicketAvailable)
Values(@TrainNumber,@TrainName,@SourceCity,@DestinationCity,@TicketPrice,@TicketAvailable);
end	

----Execute insertion
exec sp_GetTrainDetail
@TrainNumber = '15011',
@TrainName = 'Shadapthi Express',
@SourceCity = 'Coimbatore',
@DestinationCity = 'mumbai',
@TicketPrice = 960.45,
@TicketAvailable = 232;



---sp for Display
Create Procedure sp_ShowTrainDetail
as
Begin
	Select TrainNumber,TrainName,SourceCity,DestinationCity,TicketPrice,TicketAvailable from TRAIN
end
---Execute display
exec sp_ShowTrainDetail


---show by TrainNumber	
Create Procedure sp_ShowTrainByNumber
@TrainNumber varchar(10)
as
Begin
	Select TrainNumber,TrainName,SourceCity,DestinationCity,TicketPrice,TicketAvailable from TRAIN
	where @TrainNumber = TrainNumber;
end

---execution
exec sp_ShowTrainByNumber @TrainNumber = '12022'

---Update Detail

---update Train name
Create Procedure sp_UpdateTrainName
@TrainNumber varchar(10),
@TrainName varchar(15)
as
begin
	UPDATE Train SET TrainName = @TrainName WHERE TrainNumber = @TrainNumber
end

---------------update src city
Create Procedure sp_UpdateSourceCity
@TrainNumber varchar(10),
@SourceCity varchar(20)
as
begin
	UPDATE Train SET sourceCity = @SourceCity WHERE TrainNumber = @TrainNumber
end
---------------update destination city
Create Procedure sp_UpdateDestinationCity
@TrainNumber varchar(10),
@DestinationCity varchar(20)
as
begin
	UPDATE Train SET DestinationCity =@DestinationCity WHERE TrainNumber = @TrainNumber
end
------------------update Ticket price
Create Procedure sp_UpdateTicketPrice
@TrainNumber varchar(10),
@TicketPrice float
as
begin
UPDATE Train SET TicketPrice = @TicketPrice WHERE TrainNumber = @TrainNumber
end
---------------------update ticket availablity
Create Procedure sp_UpdateTicketAvailable
@TrainNumber varchar(10),
@TicketAvailable int
as
begin
 UPDATE Train SET TicketAvailable = @TicketAvailable WHERE TrainNumber = @TrainNumber
end
--------------Delete train detail
Create Procedure sp_DeleteTrainDetail
@TrainNumber varchar(10)
as
begin 
Delete from TRAIN where TrainNumber = @TrainNumber
end

exec sp_DeleteTrainDetail @TrainNumber = '13345'
