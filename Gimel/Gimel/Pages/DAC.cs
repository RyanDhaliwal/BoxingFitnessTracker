using System.Data.SqlClient;
using System.Drawing;
using static Gimel.Pages.LeaderBoardsModel;

namespace Gimel.Pages
{
    public class DAC
    {
        static string connection = "Server=tcp:gimel.database.windows.net,1433; Database=Gimel; User Id = rdhaliwal19; Password=cmpe_200442669; Encrypt=False";
        
        public static void AddCount(string name, int rhand, int lhand, int bothhands)
        {
            
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                var query = $"INSERT INTO CountData (UserName, rhand, lhand, bothhands, RecievedTime) VALUES (@Name, @Rhand, @Lhand, @Bothhands, @Time)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Rhand", rhand);
                    command.Parameters.AddWithValue("@Lhand", lhand);
                    command.Parameters.AddWithValue("@Bothhands", bothhands);
                    command.Parameters.AddWithValue("@Time", formattedTime);
                    // Execute the insert command
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void AddPower(string name, int ppower, double speed)
        {
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                var query = $"INSERT INTO PunchPower (UserName, ppower, speed, RecievedTime) VALUES (@Name, @Ppower, @Speed, @Time)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Ppower", ppower);
                    command.Parameters.AddWithValue("@Speed", speed);
                    command.Parameters.AddWithValue("@Time", formattedTime);
                    // Execute the insert command
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void AddReactTime(string name, double punchtime, double speed)
        {
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                var query = $"INSERT INTO ReactionTime (UserName, punchtime, speed, RecievedTime) VALUES (@Name, @Punchtime, @Speed, @Time)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Punchtime", punchtime);
                    command.Parameters.AddWithValue("@Speed", speed);
                    command.Parameters.AddWithValue("@Time", formattedTime);

                    // Execute the insert command
                    command.ExecuteNonQuery();
                }
            }
        }

        public static string GetPunchPower()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            string data = "";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                //var query = $"SELECT ppower FROM PunchPower";
                var query = @"
                            SELECT TOP 1 ppower 
                            FROM PunchPower 
                            ORDER BY RecievedTime DESC"; // Orders by latest timestamp

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data = reader["ppower"].ToString();

                        }
                        reader.Close();
                    }

                }
            }
            return data;
        }
        public static string GetPunchCount()
        {
            string data = "";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                //var query = $"SELECT ppower FROM PunchPower";
                var query = @"
                            SELECT TOP 1 bothhands 
                            FROM CountData 
                            ORDER BY RecievedTime DESC"; // Orders by latest timestamp

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data = reader["bothhands"].ToString();

                        }
                        reader.Close();
                    }

                }
            }
            return data;
        }
        public static string GetReactTime()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            string data = "";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                //var query = $"SELECT ppower FROM PunchPower";
                var query = @"
                            SELECT TOP 1 punchtime 
                            FROM ReactionTime 
                            ORDER BY RecievedTime DESC"; // Orders by latest timestamp

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data = reader["punchtime"].ToString();

                        }
                        reader.Close();
                    }

                }
            }
            return data;
        }
        public static List<LeaderBoardsModel.PowerL> GetPowerLeaders()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            List<LeaderBoardsModel.PowerL> data = new List<LeaderBoardsModel.PowerL>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                var query = $"SELECT * FROM PunchPower ORDER BY ppower DESC";
                //var query = @"
                //            SELECT TOP 1 punchtime 
                //            FROM ReactionTime 
                //            ORDER BY RecievedTime DESC"; // Orders by latest timestamp

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entry = new PowerL
                            {
                                Name = reader["UserName"].ToString(),
                                Power = reader["ppower"].ToString(),
                                Speed = reader["speed"].ToString(),
                                RecievedTime = reader["RecievedTime"].ToString()
                            };
                            data.Add(entry);

                        }
                        reader.Close();
                    }

                }
            }
            return data;
        }
        public static List<LeaderBoardsModel.CountL> GetCountLeaders()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            List<LeaderBoardsModel.CountL> data = new List<LeaderBoardsModel.CountL>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                var query = $"SELECT * FROM CountData ORDER BY bothhands DESC";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entry = new CountL
                            {
                                Name = reader["UserName"].ToString(),
                                RHand = reader["rhand"].ToString(),
                                LHand = reader["lhand"].ToString(),
                                Both = reader["bothhands"].ToString(),
                                RecievedTime = reader["RecievedTime"].ToString()
                            };
                            data.Add(entry);

                        }
                        reader.Close();
                    }

                }
            }
            return data;
        }
        public static List<LeaderBoardsModel.ReactionL> GetRTimeLeaders()
        {
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            List<LeaderBoardsModel.ReactionL> data = new List<LeaderBoardsModel.ReactionL>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                var query = $"SELECT * FROM ReactionTime ORDER BY punchtime ASC";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entry = new ReactionL
                            {
                                Name = reader["UserName"].ToString(),
                                PunchTime = reader["punchtime"].ToString(),
                                Speed = reader["speed"].ToString(),
                                RecievedTime = reader["RecievedTime"].ToString()
                            };
                            data.Add(entry);

                        }
                        reader.Close();
                    }

                }
            }
            return data;
        }

        public static List<SearchModel.PowerL> SearchPower(string user)
        {
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            List<SearchModel.PowerL> data = new List<SearchModel.PowerL>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                var query = $"SELECT * FROM PunchPower WHERE UserName = '{user}' ORDER BY ppower DESC";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entry = new SearchModel.PowerL
                            {
                                Name = reader["UserName"].ToString(),
                                Power = reader["ppower"].ToString(),
                                Speed = reader["speed"].ToString(),
                                RecievedTime = reader["RecievedTime"].ToString()
                            };
                            data.Add(entry);

                        }
                        reader.Close();
                    }

                }
            }
            return data;
        }
        public static List<SearchModel.CountL> SearchCount(string user)
        {
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            List<SearchModel.CountL> data = new List<SearchModel.CountL>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                var query = $"SELECT * FROM CountData WHERE UserName = '{user}' ORDER BY bothhands DESC";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entry = new SearchModel.CountL
                            {
                                Name = reader["UserName"].ToString(),
                                RHand = reader["rhand"].ToString(),
                                LHand = reader["lhand"].ToString(),
                                Both = reader["bothhands"].ToString(),
                                RecievedTime = reader["RecievedTime"].ToString()
                            };
                            data.Add(entry);

                        }
                        reader.Close();
                    }

                }
            }
            return data;
        }
        public static List<SearchModel.ReactionL> SearchRTime(string user)
        {
            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            List<SearchModel.ReactionL> data = new List<SearchModel.ReactionL>();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                var query = $"SELECT * FROM ReactionTime WHERE UserName = '{user}' ORDER BY punchtime ASC";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entry = new SearchModel.ReactionL
                            {
                                Name = reader["UserName"].ToString(),
                                PunchTime = reader["punchtime"].ToString(),
                                Speed = reader["speed"].ToString(),
                                RecievedTime = reader["RecievedTime"].ToString()
                            };
                            data.Add(entry);

                        }
                        reader.Close();
                    }

                }
            }
            return data;
        }
       
    }
}
