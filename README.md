# TinyTools

A small suite of self-contained web utilities behind a shared account system.

**Stack** — VB.NET · ASP.NET WebForms · Entity Framework · SQL Server

## Account handling

`Users` and `PasswordResetTokens` — registration with hashed passwords, email verification tokens,
expiring single-use reset tokens, and last-login tracking. Written directly rather than pulled from
a membership provider, so the token lifecycle is visible in the code.

## Running it locally

**Requires** Visual Studio 2022, .NET Framework 4.x, and SQL Server LocalDB (ships with Visual Studio).

1. Create the database and schema:
   ```
   sqlcmd -S "(localdb)\MSSQLLocalDB" -Q "CREATE DATABASE TinyToolsIdea"
   sqlcmd -S "(localdb)\MSSQLLocalDB" -d TinyToolsIdea -I -i Database/schema.sql
   ```
2. Open the solution in Visual Studio and press F5.

The connection string in `Web.config` points at LocalDB using Integrated Security — there are no
credentials in this repository, and none are required.
