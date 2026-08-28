# TinyTools

A small suite of self-contained web utilities behind a shared account system.

**Stack** — VB.NET · ASP.NET WebForms · Entity Framework · SQL Server


## Status

*Verified 28 Aug 2026 — builds with 0 errors; `Default.aspx` served HTTP 200 under IIS Express.*

**Working**
- Landing page renders
- `Users` and `PasswordResetTokens` schema applies cleanly — hashed passwords, verification tokens,
  expiring single-use reset tokens, last-login tracking

**Not built**
- This is the least complete project here. The account schema and data layer are in place, but the
  tools the app is named for are not built out, and the landing page is close to empty.

Kept public because the token lifecycle in the data layer is worth reading. Treat it as an
early sketch, not a working product.

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
