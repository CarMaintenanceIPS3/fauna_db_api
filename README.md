# FaunaDB API

FaunaDB API is a RESTful API developed with ASP.NET Core 7 and FaunaDB for robust and scalable data management.

## Project Structure

The project contains the following main components:

- **Controllers**: Handles the client requests and manages the flow of data.
- **FaunaDB**: Contains the logic for interacting with the FaunaDB database.
- **Models**: Defines the structure of the data objects.
- **Properties**: Contains properties for the application, like database connection settings.
- **Repositories**: Contains the logic for data storage, retrieval, and manipulation.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET Core 7

### Installation

1. Clone the repo:
```
git clone https://github.com/CarMaintenanceIPS3/fauna_db_api.git
```
Navigate to the project directory:
```
cd fauna_db_api
```
Install the required packages:
```
dotnet restore
```
Run the application:
```
dotnet run
```
## Usage
Provide information on how to use the API, detailing endpoints, request/response formats, and examples.

## Quality Control with SonarCloud
This project is set up with SonarCloud for continuous inspection of code quality. SonarCloud automatically analyzes and decorates pull requests in GitHub on commit. To analyze the project locally, follow the instructions on the SonarCloud website.

The build.yml GitHub workflow triggers SonarCloud analysis on every push to master and on every pull request.
