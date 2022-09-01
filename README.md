# word-predictor

#Prerequisite:
- Node 16.x
- .Net 6 SDK

Or
- Docker Desktop


#How to Install and Run the Project with Node and .Net
Backend(CLI)
- dotnet restore backend/
- dotnet run --project backend/Wizkids.Api -- (swagger can be accessed on this url: http://localhost:5054/swagger)
Frontend(CLI)
- Go to frontend folder
- npm install
- npm run start
Open browser and go to this URL: http://localhost:4200/


#How to Install and Run the Project with Docker Desktop
Backend and Frontend(CLI)
- Go to root folder
- docker-compose up --build
Open browser and go to this URL: http://localhost:8080
