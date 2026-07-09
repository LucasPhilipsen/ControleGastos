# GitHub Issues Backlog & Professional Task Board
**Project:** Home Expenses Control System
**Developer:** Lucas Philipsen Borges

This document serves as the official project backlog. Every *Issue* must be developed in its respective isolated branch and, upon completion, the commit must use the indicated pre-formatted message following the *Conventional Commits* standard.

---

## SPRINT 1: Database Foundation & Core Domain Modeling

### [ISSUE #1] [DB] Initial Setup and Domain Modeling
- **Status:**  **DONE**
- **Assignee:** Lucas Philipsen 
- **Labels:** `setup`, `model`, `sprint-1`, `backend`
- **Branch Name:** `chore/initial-setup`
- **Description:**
  Create the ASP.NET Core Web API project structure and define the domain classes (`Person` and `Transaction`). Apply encapsulation and navigation properties.
- **Acceptance Criteria / Tasks:**
  - [x] Generate solution and `.csproj`.
  - [x] Implement `Person` class.
  - [x] Implement `Transaction` class and `TransactionType` enum.
  - [x] Add `.gitignore`.
- **Pre-formatted Commit Message:**
  `chore: initial project setup and domain models`

### [ISSUE #2] [DB] Entity Framework Core & SQLite Configuration
- **Status:**  **DONE**
- **Assignee:** Lucas Philipsen
- **Labels:** `database`, `ef-core`, `sprint-1`, `backend`
- **Branch Name:** `feature/db-configuration`
- **Description:**
  Configure the `AppDbContext`, the SQLite connection string, and map the database ensuring the cascade delete rule is enforced.
- **Acceptance Criteria / Tasks:**
  - [x] Create `AppDbContext` inheriting from `DbContext`.
  - [x] Configure dependency injection in `Program.cs`.
  - [x] Generate initial migration and database update.
- **Pre-formatted Commit Message:**
  `feat(db): implement AppDbContext and SQLite database configuration`

---

## SPRINT 2: Business Logic & API Endpoints

### [ISSUE #3 & #4] [API] People/Transactions CRUD & Age Validation Rule
- **Status:** **DONE**
- **Assignee:** Lucas Philipsen
- **Labels:** `api`, `business-rule`, `sprint-2`, `backend`
- **Branch Name:** `feature/business-endpoints`
- **Description:**
  Implement HTTP routes for People and Transactions using DTOs. Enforce the core business rule: minors (under 18) cannot register income transactions.
- **Acceptance Criteria / Tasks:**
  - [x] Create DTOs for data transfer.
  - [x] Implement `PeopleController` (POST, GET, DELETE).
  - [x] Implement `TransactionsController` (POST, GET).
  - [x] Validate age before saving income; return HTTP 400 (Bad Request) if minor.
- **Pre-formatted Commit Message:**
  `feat(api): implement people and transaction endpoints with age validation`

---

## SPRINT 3: Data Consolidation & Totals

### [ISSUE #5] [API] Dashboard Endpoint and Balance Calculation
- **Status:**  **DONE**
- **Assignee:** Lucas Philipsen
- **Labels:** `api`, `dashboard`, `sprint-3`, `backend`
- **Branch Name:** `feature/dashboard-totals`
- **Description:**
  Create an endpoint to group and calculate data for the Front-end. Must calculate total incomes, expenses, and net balance per person, plus the application's grand totals.
- **Acceptance Criteria / Tasks:**
  - [x] Create `DashboardResponseDTO` and `PersonTotalDTO`.
  - [x] Implement `DashboardController`.
  - [x] Optimize calculations using LINQ `.Sum()` and `.Include()`.
- **Pre-formatted Commit Message:**
  `feat(api): implement dashboard endpoint with totals and net balance calculation`

---

## SPRINT 4: Front-end React & API Integration

### [ISSUE #6] [UI] React + TypeScript + Vite Initial Setup
- **Status:**  **DONE**
- **Assignee:** Lucas Philipsen
- **Labels:** `frontend`, `setup`, `sprint-4`
- **Branch Name:** `chore/setup-frontend`
- **Description:**
  Generate the Front-end foundation using Vite for maximum performance, configure TypeScript, and install HTTP client.
- **Acceptance Criteria / Tasks:**
  - [x] Create project with Vite (`npm create vite@latest`).
  - [x] Configure ESLint.
  - [x] Install Axios for API requests.
  - [x] Clean up template boilerplate files.
- **Pre-formatted Commit Message:**
  `chore(web): initial setup for react with vite and typescript`

### [ISSUE #7] [UI] Forms, Tables, and Dashboard Integration
- **Status:** **TO DO** (Current Focus)
- **Assignee:** Lucas Philipsen
- **Labels:** `frontend`, `components`, `sprint-4`
- **Branch Name:** `feature/ui-integration`
- **Description:**
  Develop visual components to interact with the C# API. Create forms for user input and dynamic tables to display the calculated financial dashboard.
- **Acceptance Criteria / Tasks:**
  - [ ] Create `PersonForm` and `TransactionForm` components.
  - [ ] Display API error alerts (e.g., minor age restriction).
  - [ ] Fetch data via Axios and render the Dashboard tables.
  - [ ] Add basic CSS/styling for a professional look.
- **Pre-formatted Commit Message:**
  `feat(web): implement UI components and API integration for dashboard`