using System;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    class TrainDetail
    {
        public void ConnectDB()
        {
            TrainManager trainManager = new TrainManager();
            string connectionString = "Data source = .; Database = TicketBookingDatabase; Integrated Security = SSPI";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                bool status = true;

                while(status)
                {
                    Console.WriteLine("\n[Select a option]\n1)Add Train\n2)Update Train Detail\n3)Delete Train\n4)Display\n5)Exit");
                    byte choice = Byte.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            trainManager.AddTrainInfo(sqlConnection);
                            break;
                        case 2:
                            Console.WriteLine("Enter the Train Number you want to Update");
                            string trainNumber = Console.ReadLine();
                            trainManager.UpdateTrainInfo(trainNumber,sqlConnection);
                            break;
                        case 3:
                            trainManager.DeleteTrainInfo(sqlConnection);
                            break;
                        case 4:
                            trainManager.DisplayTrainInfo(sqlConnection);
                            break;
                        case 5:
                            status = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice");
                            break;
                    }
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
