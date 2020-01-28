using System;
using System.Data;
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

           SqlCommand sqlCommand = new SqlCommand("sp_GetTrainDetail", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@TrainNumber", trainNumber);
            sqlCommand.Parameters.AddWithValue("@TrainName", trainName );
            sqlCommand.Parameters.AddWithValue("@SourceCity", sourceCity);
            sqlCommand.Parameters.AddWithValue("@DestinationCity", destinationCity);
            sqlCommand.Parameters.AddWithValue("@TicketPrice", ticketPrice);
            sqlCommand.Parameters.AddWithValue("@TicketAvailable", ticketCount);
            int numRes = sqlCommand.ExecuteNonQuery();
            if (numRes > 0)
            {
                Console.WriteLine("Record Deleted Successfully !!!");
              
            }
            else
            {
                Console.WriteLine("Please Try Again !!!");
            }
        
    }
        public void DisplayTrainInfo(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand("sp_ShowTrainDetail", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
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
                            SqlCommand commandforName = new SqlCommand("sp_UpdateTrainName", connection);
                            commandforName.CommandType = CommandType.StoredProcedure;
                            commandforName.Parameters.AddWithValue("@TrainNumber", trainNumber);
                            commandforName.Parameters.AddWithValue("@TrainName", trainName);
                            int numRes = commandforName.ExecuteNonQuery();
                            if (numRes > 0)
                            {
                                Console.WriteLine("Record Deleted Successfully !!!");

                            }
                            else
                            {
                                Console.WriteLine("Please Try Again !!!");
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter the Source City to Update:");
                            string sourceCity = Console.ReadLine();
                            SqlCommand commandforsrcCity = new SqlCommand("sp_UpdateSourceCity", connection);
                            commandforsrcCity.CommandType = CommandType.StoredProcedure;
                            commandforsrcCity.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
                            commandforsrcCity.Parameters.Add("@SourceCity", System.Data.SqlDbType.VarChar);
                            commandforsrcCity.Parameters["@TrainNumber"].Value = trainNumber;
                            commandforsrcCity.Parameters["@SourceCity"].Value = sourceCity;
                            int numRes = commandforsrcCity.ExecuteNonQuery();
                            if (numRes > 0)
                            {
                                Console.WriteLine("Record Deleted Successfully !!!");

                            }
                            else
                            {
                                Console.WriteLine("Please Try Again !!!");
                            }

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter the Destination City to Update:");
                            string destCity = Console.ReadLine();
                            SqlCommand commandforDestCity = new SqlCommand("sp_UpdateDestinationCity", connection);
                            commandforDestCity.CommandType = CommandType.StoredProcedure;
                            commandforDestCity.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
                            commandforDestCity.Parameters.Add("@DestinationCity", System.Data.SqlDbType.VarChar);
                            commandforDestCity.Parameters["@TrainNumber"].Value = trainNumber;
                            commandforDestCity.Parameters["@DestinationCity"].Value = destCity;
                            int numRes = commandforDestCity.ExecuteNonQuery();
                            if (numRes > 0)
                            {
                                Console.WriteLine("Record Deleted Successfully !!!");

                            }
                            else
                            {
                                Console.WriteLine("Please Try Again !!!");
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Enter the Ticket Price to Update:");
                            string ticketPrice = Console.ReadLine();
                            SqlCommand commandforPrice = new SqlCommand("sp_UpdateTicketPrice", connection);
                            commandforPrice.CommandType = CommandType.StoredProcedure;
                            commandforPrice.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
                            commandforPrice.Parameters.Add("@TicketPrice", System.Data.SqlDbType.Float);
                            commandforPrice.Parameters["@TrainNumber"].Value = trainNumber;
                            commandforPrice.Parameters["@TicketPrice"].Value = ticketPrice;
                            int numRes = commandforPrice.ExecuteNonQuery();
                            if (numRes > 0)
                            {
                                Console.WriteLine("Record Deleted Successfully !!!");

                            }
                            else
                            {
                                Console.WriteLine("Please Try Again !!!");
                            }
                        }
                        break;

                    case 5:
                        {
                            Console.WriteLine("Enter the Ticket Count to Update:");
                            string ticketCount = Console.ReadLine();
                            SqlCommand commandforCount = new SqlCommand("sp_UpdateTicketAvailable", connection);
                            commandforCount.CommandType = CommandType.StoredProcedure;
                            commandforCount.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
                            commandforCount.Parameters.Add("@TicketAvailable", System.Data.SqlDbType.Int);
                            commandforCount.Parameters["@TrainNumber"].Value = trainNumber;
                            commandforCount.Parameters["@TicketAvailable"].Value = ticketCount;
                            int numRes = commandforCount.ExecuteNonQuery();
                            if (numRes > 0)
                            {
                                Console.WriteLine("Record Deleted Successfully !!!");

                            }
                            else
                            {
                                Console.WriteLine("Please Try Again !!!");
                            }
                        }
                        break;
                    case 6:
                        status = false;
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
            SqlCommand command = new SqlCommand("sp_DeleteTrainDetail", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@TrainNumber", System.Data.SqlDbType.VarChar);
            command.Parameters["@TrainNumber"].Value = trainNumber;
            int numRes = command.ExecuteNonQuery();
            if (numRes > 0)
            {
                Console.WriteLine("Record Deleted Successfully !!!");
            }
            else
            {
                Console.WriteLine("Please Try Again !!!");
            }
        }
    }

}
