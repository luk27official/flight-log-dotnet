# FlightLog
Tento repozitář obsahuje zdrojové kódy k aplikaci FlightLog.

## Instalace
1. Pro spuštění aplikace je nutné si nainstalovat Docker podle instrukcí na adrese https://docs.docker.com/get-docker/.

## Spuštění
1. Pro build Docker image je nutné použít příkaz `docker build . -t flightlog` v příkazové řádce.
2. Pro běh serveru stačí použít příkaz `docker run -p 44313:44313 --name flightlog flightlog:latest` v příkazové řádce.
3. Aplikace běží a v prohlížeči je dostupná na adrese `http://localhost:44313`.

Alternativně je možné použít pro spuštění předpřipravený skript `run_server.ps1`.

Aplikace byla testována v prostředí `Docker version 25.0.3` na systému `Windows 11 21H2`.
