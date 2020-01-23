using System;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    class TrainManager
    {
        public void AddTrainInfo(SqlConnection connection)
        {

            Console.WriteLine("Enter Train Number :");
            string trainNumber = Console.ReadLine();
            Console.WriteLine("Enter Train Name  :");
            string trainName = Console.ReadLine();
            Console.WriteLine("Enter Source City :");
            string sourceCity = Console.ReadLine();
            Console.WriteLine("Enter Destination City :");
            string destinationCity = Console.ReadLine();
            Console.WriteLine("Enter Ticket Price :");
            double ticketPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ticket Count");
            int ticketCount = int.Parse(Console.ReadLine());

            //string insertValue = "Insert Into Train(TrainNumber, TrainName, SourceCity, DestinationCity, TicketPrice, TicketAvailable)"+
            //    "Values('12022', 'Chennai Express', 'Coimbatore', 'Chennai', 150.34, 120)";

            string insertValue = "Insert Into Train(TrainNumber, TrainName, SourceCity, DestinationCity, TicketPrice, TicketAvailable)" +
                "Values(@trainNumber, @trainName, @SourceCity, @DestinationCity, @ticketPrice, @ticketCount)";
            SqlCommand sqlCommand = new SqlCommand(insertValue, connection);

            sqlCommand.Parameters.AddWithValue("@trainNumber", trainNumber);
            sqlCommand.Parameters.AddWithValue("@trainName", trainName );
            sqlCommand.Parameters.AddWithValue("@sourceCity", sourceCity);
            sqlCommand.Parameters.AddWithValue("@destinationCity", destinationCity);
            sqlCommand.Parameters.AddWithValue("@ticketPrice", ticketPrice);
            sqlCommand.Parameters.AddWithValue("@ticketCount", ticketCount);
            sqlCommand.ExecuteNonQuery();
        }
        public void DisplayTrainInfo(SqlConnection connection)
        {
            string display = "Select TrainNumber, TrainName, SourceCity, DestinationCity, TicketPrice, TicketAvailable from Train";
            SqlCommand sqlCommand = new SqlCommand(display, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("\nTrainNumber\tTrainName\tSource\tDestination\tTicketPrice\tTicketsAvailable");

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + "\t" + reader.GetString(1)
                           + "\t" + reader.GetString(2) + "\t" + reader.GetString(3) + "\t" + reader.GetValue(4) + "\t" + reader.GetValue(5));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
        }
        public void UpdateTrainInfo(string trainNumber,SqlConnection connection)
        {

            string updateValue;
            bool status = true;
            while(status)
            {
                Console.WriteLine("Select the field you want to Update?\n1)Train Name\n2)Source City\n3)Destination City\n4)Ticket Price\n5)Ticket Count\n6)Exit");
                byte choice = Byte.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the Train Name to Update:");
                            string trainName = Console.ReadLine();
                            updateValue = "UPDATE Train SET TrainName = @trainName WHERE TrainNumber = @trainNumber";
                            SqlCommand commandforName = new SqlCommand(updateValue, connection);
                            commandforName.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
                            commandforName.Parameters.Add("@TrainName", System.Data.SqlDbType.VarChar);
                            commandforName.Parameters["@TrainNumber"].Value = trainNumber;
                            commandforName.Parameters["@TrainName"].Value = trainName;
                            commandforName.ExecuteNonQuery();
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter the Source City to Update:");
                            string sourceCity = Console.ReadLine();
                            updateValue = "UPDATE Train SET SourceCity = @sourceCity WHERE TrainNumber = @trainNumber";
                            SqlCommand commandforsrcCity = new SqlCommand(updateValue, connection);
                            commandforsrcCity.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
                            commandforsrcCity.Parameters.Add("@SourceCity", System.Data.SqlDbType.VarChar);
                            commandforsrcCity.Parameters["@TrainNumber"].Value = trainNumber;
                            commandforsrcCity.Parameters["@SourceCity"].Value = sourceCity;
                            commandforsrcCity.ExecuteNonQuery();

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter the Destination City to Update:");
                            string destCity = Console.ReadLine();
                            updateValue = "UPDATE Train SET DestinationCity = @destinationCity WHERE TrainNumber = @trainNumber";
                            SqlCommand commandforDestCity = new SqlCommand(updateValue, connection);
                            commandforDestCity.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
                            commandforDestCity.Parameters.Add("@DestinationCity", System.Data.SqlDbType.VarChar);
                            commandforDestCity.Parameters["@TrainNumber"].Value = trainNumber;
                            commandforDestCity.Parameters["@DestinationCity"].Value = destCity;
                            commandforDestCity.ExecuteNonQuery();
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Enter the Ticket Price to Update:");
                            string ticketPrice = Console.ReadLine();
                            updateValue = "UPDATE Train SET TicketPrice = @ticketPrice WHERE TrainNumber = @trainNumber";
                            SqlCommand commandforPrice = new SqlCommand(updateValue, connection);
                            commandforPrice.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
                            commandforPrice.Parameters.Add("@TicketPrice", System.Data.SqlDbType.Float);
                            commandforPrice.Parameters["@TrainNumber"].Value = trainNumber;
                            commandforPrice.Parameters["@TicketPrice"].Value = ticketPrice;
                            commandforPrice.ExecuteNonQuery();
                        }
                        break;

                    case 5:
                        {
                            Console.WriteLine("Enter the Ticket Count to Update:");
                            string ticketCount = Console.ReadLine();
                            updateValue = "UPDATE Train SET TicketAvailable = @ticketCount WHERE TrainNumber = @trainNumber";
                            SqlCommand commandforCount = new SqlCommand(updateValue, connection);
                            commandforCount.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
                            commandforCount.Parameters.Add("@TicketAvailable", System.Data.SqlDbType.Int);
                            commandforCount.Parameters["@TrainNumber"].Value = trainNumber;
                            commandforCount.Parameters["@TicketAvailable"].Value = ticketCount;
                            commandforCount.ExecuteNonQuery();
                        }
                        break;
                    default:
                        Console.WriteLine("Select a valid choice");
                        break;
                }
            }
        }
        public void DeleteTrainInfo(SqlConnection connection)
        {
            Console.WriteLine("Enter the Train Number to delete : ");
            string trainNumber = Console.ReadLine();
            string deleteUser = "DELETE FROM Train where TrainNumber = @trainNumber";
            SqlCommand command = new SqlCommand(deleteUser, connection);
            command.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
            command.Parameters["@TrainNumber"].Value = trainNumber;
            command.ExecuteNonQuery();
        }
    }
}
