docker build . -t flightlog
docker run -p 44313:44313 --name flightlog flightlog:latest