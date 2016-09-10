using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransitSMS
{
    class Interpreter
    {
        string ConnectionString;

        public Interpreter()
        {
            ConnectionString = ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TransitDatabaseConnectionString"].ConnectionString;
        }

        public void Interpret(string Sender, string Query, out string StartPointName, out string EndPointName, out string Response)
        {
            //expected Query = <message>City: Karachi From: Dalmia To: Sadar</message>

            Query = "<startmessage>City: Hyderabad From: Tower To: Sadar<endmessage>";

            string VehiclesResponse = string.Empty;

            bool StartPointNameCorrect = false, EndPointNameCorrect = false;

            string City = Between(Query, "City: ", " From:");

            City = City.Replace(" ", "");

            StartPointName = Between(Query, "From: ", " To:") + ", " + City;
            EndPointName = Between(Query, "To: ", "<endmessage>") + ", " + City;

            int StartPointID = GetLocationID(StartPointName);
            int EndPointID = GetLocationID(EndPointName);

            if (ConfirmNameCorrection(StartPointID))
            {
                StartPointNameCorrect = true;
            }
            if (ConfirmNameCorrection(EndPointID))
            {
                EndPointNameCorrect = true;
            }

            if (City != "Karachi")
            {
                Response = "Sorry Either you did not write the correct city name or we dont provide services in your city.\nYour City : " + City;
            }
            else if (StartPointNameCorrect && EndPointNameCorrect)
            {
                foreach (int VehicleID in GetVehicleIDs(StartPointID, EndPointID))
                {
                    string VehicleName = GetVehicleName(VehicleID);
                    VehiclesResponse = VehiclesResponse + VehicleName + "\n";
                }

                Response = VehiclesResponse;
            }
            else if (!StartPointNameCorrect)
            {
                VehiclesResponse = "Your starting location name is incorrect";
                //now also add alternatives to this start point name 

                Response = VehiclesResponse;
            }
            else if (!EndPointNameCorrect)
            {
                VehiclesResponse = "Your destination location name is incorrect";
                //now also add alternatives to this end point name 

                Response = VehiclesResponse;
            }
            else Response = null;
        }

        public string Between(string Source, string StartingPoint, string EndingPoint)
        {
            int start = Source.IndexOf(StartingPoint);
            int to = Source.IndexOf(EndingPoint, start + StartingPoint.Length);
            if (start < 0 || to < 0) return "";
            string s = Source.Substring(
                           start + StartingPoint.Length,
                           to - start - StartingPoint.Length);
            return s;
        }

        public bool ConfirmNameCorrection(int LocationID)
        {
            if (LocationID > 0)
            {
                return true;
            }
            else return false;
        }

        public int GetLocationID(string LocationName)
        {
            int ID = 0;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Locations where Name='" + LocationName + "'", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //column 0 is ID, column1 is Name
                        ID = reader.GetInt32(0);
                    }
                }
                con.Close();
            }

            return ID;
        }

        private ArrayList GetVehicleIDs(int StartPointID, int EndPointID)
        {
            ArrayList VehicleIDs = new ArrayList();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("Select VehicleID from RouteCombinations where StartLocationID= '" + StartPointID + "' AND EndLocationID='" + EndPointID + "'", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VehicleIDs.Add(reader.GetInt32(0));
                        }
                    }
                    con.Close();
                }
            }

            return VehicleIDs;
        }

        public string GetVehicleName(int VehicleID)
        {
            string VehicleName = string.Empty;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("Select Name from Vehicles where ID= '" + VehicleID + "'", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VehicleName = reader.GetString(0);
                        }
                    }
                    con.Close();
                }
            }

            return VehicleName;
        }

        public string ReturnCityName(string Query)
        {
            string CityName = Between(Query, "City:", "From:");

            string CityNameFinal = string.Empty; 

            for (int i = 0; i < CityName.Length; i++)
            {
                if (i == 0)
                {
                    if (CityName[i] == ' ')
                    {
                        //do nothing
                    }
                    else CityNameFinal = CityNameFinal + CityName[i];
                }
                else if (i == CityName.Length-1)
                {
                    if (CityName[i] == ' ')
                    {
                        //do nothing
                    }
                    else CityNameFinal = CityNameFinal + CityName[i];
                }
                else CityNameFinal = CityNameFinal + CityName[i];
            }

            return CityNameFinal;
        }
        public string ReturnStartPointName(string Query)
        {
            /*
            string StartPointName = Between(Query, "From:", "To:");

            if (StartPointName[0] == ' ')
            {
                StartPointName = StartPointName.Remove(0);
            }
            if (StartPointName[StartPointName.Length - 1] == ' ')
            {
                StartPointName = StartPointName.Remove(StartPointName.Length - 1);
            }

            return StartPointName;
             */

            string StartPointName = Between(Query, "From:", "To:");

            string StartPointNameFinal = string.Empty;

            for (int i = 0; i < StartPointName.Length; i++)
            {
                if (i == 0)
                {
                    if (StartPointName[i] == ' ')
                    {
                        //do nothing
                    }
                    else StartPointNameFinal = StartPointNameFinal + StartPointName[i];
                }
                else if (i == StartPointName.Length - 1)
                {
                    if (StartPointName[i] == ' ')
                    {
                        //do nothing
                    }
                    else StartPointNameFinal = StartPointNameFinal + StartPointName[i];
                }
                else StartPointNameFinal = StartPointNameFinal + StartPointName[i];
            }

            return StartPointNameFinal;
        }
        public string ReturnEndPointName(string Query)
        {
            string EndPointName = Between(Query, "To:", "</message>");

            string EndPointNameFinal = string.Empty;

            for (int i = 0; i < EndPointName.Length; i++)
            {
                if (i == 0)
                {
                    if (EndPointName[i] == ' ')
                    {
                        //do nothing
                    }
                    else EndPointNameFinal = EndPointNameFinal + EndPointName[i];
                }
                else if (i == EndPointName.Length - 1)
                {
                    if (EndPointName[i] == ' ')
                    {
                        //do nothing
                    }
                    else EndPointNameFinal = EndPointNameFinal + EndPointName[i];
                }
                else EndPointNameFinal = EndPointNameFinal + EndPointName[i];
            }

            return EndPointNameFinal;
        }

        public bool ConfirmCity(string City)
        {
            //remove white spaces
            City = City.Replace(" ", "");

            //since we are only giving coverage in Karachi =, we need to make it hard coded
            if (City == "Karachi")
                return true;
            else return false;
        }

        public bool ConfirmLocationExist(string LocationName)
        {
            int LocationID = GetLocationID(LocationName);

            if (LocationID > 0)
                return true;
            else return false;
        }

        public string GetResponse(string StartPointName, string EndPointName)
        {
            string Response = string.Empty;

            int StartLocationID = GetLocationID(StartPointName);
            int EndLocationID = GetLocationID(EndPointName);

            foreach (int VehicleID in GetVehicleIDs(StartLocationID, EndLocationID))
            {
                string VehicleName = GetVehicleName(VehicleID);

                Response = Response + VehicleName + " - " + GetFair(VehicleName, StartLocationID, EndLocationID) + " Rs\n";
            }

            return Response;
        }

        public string GetSimilarSuggestions(string LocationName)
        {
            //I will only send 4 similar place suggestion name based on first four character of user inputted word

            string Location4Chars = string.Empty;

            if (LocationName.Length >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Location4Chars = Location4Chars + LocationName[i];
                }
            }
            else Location4Chars = LocationName;

            string LocationSuggestions = string.Empty;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT Name FROM Locations where Name Like '%" + Location4Chars + "%'", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //column 0 is ID, column1 is Name

                        string Name = reader.GetString(0);

                        //replace Karachi word from all suggestion to make space
                        Name = Name.Replace(", Karachi", "");

                        LocationSuggestions = LocationSuggestions + Name + "\n";
                    }
                }
                con.Close();
            }

            return LocationSuggestions;
        }

        public string ReturnShortMessage(string Message)
        {
            string ShortMessage = string.Empty;
            for (int i = 0; i < 159; i++)
            {
                ShortMessage = ShortMessage + Message[i];
            }

            return ShortMessage;
        }

        public string GetFair(string VehicleName, int StartLocationID, int EndLocationID)
        {
            int VehicleID = 0;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT ID FROM Vehicles where Name='" + VehicleName + "'", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //column 0 is ID, column1 is Name
                        VehicleID = reader.GetInt32(0);
                    }
                }
                con.Close();
            }

            string RouteData = string.Empty;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("Select RouteXML from RouteCombinations where StartLocationID= '" + StartLocationID + "' AND EndLocationID='" + EndLocationID + "'", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RouteData = reader.GetString(0);
                        }
                    }
                    con.Close();
                }
            }

            string StopFair = string.Empty;

            if (RouteData.Length > 5)
            {
                StopFair = Between(RouteData, "<StopFair>", "</StopFair>");
            }

            return StopFair;
        }
    }
}
