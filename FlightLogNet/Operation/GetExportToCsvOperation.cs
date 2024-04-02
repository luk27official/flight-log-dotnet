namespace FlightLogNet.Operation
{
    using System.Text;
    using Microsoft.Extensions.Primitives;
    using Repositories.Interfaces;

    public class GetExportToCsvOperation(IFlightRepository flightRepository)
    {
        public byte[] Execute()
        {
            // DONE 5.1: Naimplementujte export do CSV
            // TIP: CSV soubor je pouze string, který se dá vytvořit pomocí třídy StringBuilder
            // TIP: Do bytové reprezentace je možné jej převést například pomocí metody: Encoding.UTF8.GetBytes(..)

            StringBuilder sb = new();

            sb.Append("Id,TakeoffTime,LandingTime,Airplane,Pilot,Copilot,Task\n");

            foreach (var flight in flightRepository.GetAllFlights())
            {
                var PilotName = flight.Pilot.FirstName + " " + flight.Pilot.LastName;
                var CopilotName = "";

                if (flight.Copilot != null)
                {
                    CopilotName = flight.Copilot.FirstName + " " + flight.Copilot.LastName;
                }

                sb.Append(flight.Id + "," + flight.TakeoffTime + "," + flight.LandingTime + "," + flight.Airplane.Immatriculation + "," + PilotName + "," +
                    CopilotName + "," + flight.Task + "\n");
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
