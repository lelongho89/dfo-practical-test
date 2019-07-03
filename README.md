# Simple User API with in-memory data.

1. Get All Users: /api/users
2. Get User by Id: /api/users/<id>
3. Create User (Method POST): /api/users
4. Update User (Method PUT): /api/users/<id>
5. Delete User: /api/users/<id>

# Prerequisites
  [NET Core SDK](https://dotnet.microsoft.com/download#/current)
  
  Visual Studio Code or Visual Studio 2017 or Above
  
  Docker if run in Docker container
  
# How to run
  
## Run with dotnet cli
1. git clone https://github.com/lelongho89/dfo-practical-test

2. dotnet restore

3. dotnet run

Open http://localhost:5000 and use Swagger UI.

## Run with Docker
1. git clone https://github.com/lelongho89/dfo-practical-test

2. docker-compose up -d

Open http://localhost:5000 and use Swagger UI.

## Run with Visual Studio
1. git clone https://github.com/lelongho89/dfo-practical-test
2. Open PracticalTest.Sln
3. Build and Run with IIS or IIS Express

# Test the API
Use Swagger UI or Postman or curl

## Test example with Curl
1. Get All Users: curl -X GET "http://localhost:5000/api/users"

2. Get User: curl -X GET "http://localhost:5000/api/users/1"

3. Create User: curl -X POST "http://localhost:5000/api/users" -H "Content-Type: application/json" -d "{\"name\":\"Joe\",\"age\":30,\"address\":\"123 ABC\"}"

4. Update User: curl -X PUT "http://localhost:5000/api/users/11" -H "Content-Type: application/json" -d "{\"name\":\"Test\",\"age\":33,\"address\":\"Testa add\"}"

5. Delete User: curl -X DELETE "http://localhost:5000/api/users/11"
