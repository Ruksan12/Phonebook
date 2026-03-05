# 📒 Phonebook

A C# console application for managing contacts

## Features

- Add, update, and delete contacts
- View all contacts in a formatted table
- Persistent storage via a SQL Server database using Entity Framework Core

## Tech Stack

- **Language:** C# (.NET)
- **ORM:** Entity Framework Core (Code-First with Migrations)
- **Database:** SQL Server / LocalDB
- **Testing:** xUnit (via `Phonebook.Tests` project)

## Project Structure

```
Phonebook/
├── Data/               # DbContext and database configuration
├── Migrations/         # EF Core migration files
├── Models/             # Entity models
├── Services/           # Business logic layer
├── View/               # Console UI and menu rendering
├── Phonebook.Tests/    # Unit tests
├── Program.cs          # Entry point
└── PhoneBook.Ruksan12.csproj
```

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) or later
- SQL Server or SQL Server LocalDB

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Ruksan12/Phonebook.git
   cd Phonebook
   ```

2. **Set up the database connection string**

   Update the connection string in `Data/` (or `appsettings.json` if present) to point to your SQL Server instance.

3. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

### Running Tests

```bash
dotnet test
```

## Usage

Once launched, the application presents a console menu. Use the keyboard to navigate options such as:

- **View Contacts** — list all saved contacts
- **Add Contact** — create a new contact with name, phone number, and email
- **Update Contact** — edit an existing contact's details
- **Delete Contact** — remove a contact from the phonebook


## 🧠 My Thought Process

Overall, this project was a fairly smooth experience. Setting up the database with Entity Framework Core felt natural — defining the models, configuring the `DbContext`, and running migrations to get the schema in place was straightforward. The CRUD operations followed logically from there; once the data layer was wired up, implementing create, read, update, and delete through the service layer didn't present many surprises.

The part that was newer territory for me was **unit testing**. Writing tests for the `Phonebook.Tests` project required thinking about the code differently — isolating units of logic, mocking dependencies, and structuring tests in a way that's both meaningful and maintainable. It was a good challenge and a valuable exercise in writing more testable code overall.

This project was a solid opportunity to practice a full-stack console app architecture and to get more comfortable with the testing side of C# development.
