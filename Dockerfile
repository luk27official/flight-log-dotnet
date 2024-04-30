FROM mcr.microsoft.com/dotnet/sdk:8.0

# runs at localhost:44313
ENV ASPNETCORE_URLS=http://+:44313

RUN apt-get update \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app

COPY ./FlightLogNet ./FlightLogNet
COPY ./FlightLogNet.Tests ./FlightLogNet.Tests
COPY ./frontend ./frontend

WORKDIR /app/FlightLogNet
RUN dotnet restore && dotnet build

CMD ["dotnet", "run"]
EXPOSE 44313
