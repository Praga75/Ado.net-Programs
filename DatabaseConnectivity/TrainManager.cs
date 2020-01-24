using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    class TrainManagerUsingDataAdapter
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

            string insertValue = "Insert Into Train(TrainNumber, TrainName, SourceCity, DestinationCity, TicketPrice, TicketAvailable)"+
                "Values('"+trainNumber+ "', ' " +trainName+ "', ' " +sourceCity + "', ' " +destinationCity + "', " +ticketPrice+"," +ticketCount+")";

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = new SqlCommand(insertValue,connection);
            dataAdapter.InsertCommand.ExecuteNonQuery();
        }
        public void DisplayTrainInfo(SqlConnection connection)
        {
            string sqlSelect = "select * from Train";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlSelect, connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write(row[column] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void UpdateTrainInfo(string trainNumber,SqlConnection connection)
        {

            string updateValue;
            bool status = true;
            SqlDataAdapter adapter = new SqlDataAdapter();
            while (status)
            {
                Console.WriteLine("Select the field you want to Update?\n1)Train Name\n2)Source City\n3)Destination City\n4)Ticket Price\n5)Ticket Count\n6)Exit");
                byte choice = Byte.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the Train Name to Update:");
                            string trainName = Console.ReadLine();
                            updateValue = "UPDATE Train SET TrainName = '"+trainName+"' WHERE TrainNumber = '" + trainNumber + "';";
                            adapter.UpdateCommand = connection.CreateCommand();
                            adapter.UpdateCommand.CommandText = updateValue;
                            adapter.UpdateCommand.ExecuteNonQuery();

                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter the Source City to Update:");
                            string sourceCity = Console.ReadLine();
                            updateValue = "UPDATE Train SET sourceCity = '" + sourceCity + "' WHERE TrainNumber = '" + trainNumber + "';";
                            adapter.UpdateCommand = connection.CreateCommand();
                            adapter.UpdateCommand.CommandText = updateValue;
                            adapter.UpdateCommand.ExecuteNonQuery();

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter the Destination City to Update:");
                            string destCity = Console.ReadLine();
                            updateValue = "UPDATE Train SET DestinationCity = '" + destCity + "' WHERE TrainNumber = '" + trainNumber + "';";
                            adapter.UpdateCommand = connection.CreateCommand();
                            adapter.UpdateCommand.CommandText = updateValue;
                            adapter.UpdateCommand.ExecuteNonQuery();

                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Enter the Ticket Price to Update:");
                            string ticketPrice = Console.ReadLine();
                            updateValue = "UPDATE Train SET TicketPrice = " + ticketPrice + " WHERE TrainNumber = '" + trainNumber + "';";
                            adapter.UpdateCommand = connection.CreateCommand();
                            adapter.UpdateCommand.CommandText = updateValue;
                            adapter.UpdateCommand.ExecuteNonQuery();

                        }
                        break;

                    case 5:
                        {
                            Console.WriteLine("Enter the Ticket Count to Update:");
                            string ticketCount = Console.ReadLine();
                            updateValue = "UPDATE Train SET TicketAvailable = " + ticketCount + " WHERE TrainNumber = '" + trainNumber + "';";
                            adapter.UpdateCommand = connection.CreateCommand();
                            adapter.UpdateCommand.CommandText = updateValue;
                            adapter.UpdateCommand.ExecuteNonQuery();

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
            SqlDataAdapter adapter = new SqlDataAdapter();
            Console.WriteLine("Enter the Train Number to delete : ");
            string trainNumber = Console.ReadLine();
            string deleteUser = "DELETE FROM Train where TrainNumber = '"+trainNumber+" ' ";
            adapter.DeleteCommand = connection.CreateCommand();
            adapter.DeleteCommand.CommandText = deleteUser;
            adapter.DeleteCommand.ExecuteNonQuery();

        }
    }
}
