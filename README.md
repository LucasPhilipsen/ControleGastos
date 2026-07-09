# Home Expenses Control System

A Full-Stack application developed to manage household financial transactions (incomes and expenses), calculate net balances per person, and enforce specific business rules regarding minors.

## Technologies Used

**Back-end:**
* **C# / .NET 10:** Robust API development.
* **Entity Framework Core:** ORM for database mapping and LINQ queries.
* **SQLite:** Lightweight, file-based relational database.
* **Swagger / OpenAPI:** Interactive API documentation and testing.

**Front-end:**
* **React:** Component-based UI rendering.
* **TypeScript:** Static typing for safer frontend data handling.
* **Vite:** High-performance local development server and bundler.
* **Axios:** HTTP client for API communication.

## Core Business Rules Implemented
1. **Cascade Deletion:** Deleting a person automatically removes all their associated financial transactions from the database.
2. **Age Restriction Validation:** Minors (under 18 years old) are strictly forbidden from registering "Income" transactions. The API intercepts this and returns a `400 Bad Request`.
3. **Consolidated Dashboard:** The system dynamically calculates total incomes, total expenses, and the net balance per person, alongside a grand total for the household.

## Task Management
The development process was strictly organized using a **Backlog** (documented in `BACKLOG.md`). All project requirements were broken down into technical issues and systematically resolved using isolated Git branches and standard semantic commits.

# Future Improvements (Architecture Considerations)
* **Natural Keys for User Identification:** Implement a unique string identifier (e.g., a "username" or "apelido")
for public-facing operations like frontend relationships and deletions. 
This enhances security by preventing the exposure of sequential database IDs in the UI, while maintaining integer IDs internally for query performance.

## How to Run the Project Locally

### Prerequisites
* [.NET 10 SDK](https://dotnet.microsoft.com/download)
* [Node.js](https://nodejs.org/) (v18+ recommended)
* Git

### 1. Back-end Setup (API & Database)
Open your terminal and clone the repository, then navigate to the root folder.

```
bash
# Update the local SQLite database to create the schema and tables
dotnet ef database update

# Run the API
dotnet run
```
The API will start running. You can access the Swagger documentation at [https://localhost:7007/swagger](https://localhost:7007/swagger) to inspect the endpoints.

### 2. Front-end Setup (React UI)
Open a second terminal window, navigate to the frontend folder, and install the dependencies.

```
cd frontend

# Install Node modules

npm install

# Start the Vite development server

npm run dev
````
Note: The React application will be available at [http://localhost:5173](http://localhost:5173). Open this URL in your browser to interact with the system.

## Project Structure Highlights
`Controllers/:` Contains the entry points for the API (People, Transactions, and Dashboard).

`DTOs/:` Data Transfer Objects used to shape the data between the client and the server, avoiding exposing pure database entities.

`Models/:` Domain entities mapped directly to the SQLite database via Entity Framework.

`frontend/src/components/:` Reusable React components (Forms) that interact with the C# backend via Axios.