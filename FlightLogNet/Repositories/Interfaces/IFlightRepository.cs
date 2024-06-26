﻿namespace FlightLogNet.Repositories.Interfaces
{
    using System.Collections.Generic;

    using Models;

    public interface IFlightRepository
    {
        IList<ReportModel> GetReport();

        void LandFlight(FlightLandingModel landingModel);

        void TakeoffFlight(long? gliderFlightId, long? towplaneFlightId);

        long CreateFlight(CreateFlightModel model);

        IList<FlightModel> GetAllFlights();

        IList<FlightModel> GetFlightByType(FlightType type);

        IList<FlightModel> GetAirplanesInAir();
    }
}
