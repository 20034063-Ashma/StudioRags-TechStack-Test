# Deployment (Azure)
Owner: Nishan Pathak. Status as of 15 Nov 2026.

## Live test site
https://studiorags-group1-aff0fse5eranhvgf.eastasia-01.azurewebsites.net
Currently Azure's default page. The full site is deployed once the frontend, backend and payment code are integrated.

## Azure resources (resource group: Studiorags-rg)
- Subscription: Azure for Students ($100 credit, no card)
- Azure SQL server: studio-rags-group1 (Australia East)
- Azure SQL database: studiorags-db, Basic tier (5 DTUs, 2 GB), about US$5.39 per month, automatic backups
- Web app: studiorags-group1 on plan studiorags-plan, Free (F1), Linux, .NET 10 (LTS), East Asia

## Configuration
- The database connection string is stored in the web app's environment variables as DefaultConnection (type SQLAzure). It is never stored in GitHub.
- The SQL firewall allows Azure services, plus developer computers added on request.
- HTTPS is on by default.

## Limits found on the student account
- The Free web app plan had a quota of 0 in Australia East and New Zealand North. Basic B1 also had 0 in Australia East.
- The subscription only allows these regions: Australia East, New Zealand North, Indonesia Central, East Asia, Korea Central.
- Indonesia Central had no free capacity. East Asia worked.
- So the web app is in East Asia and the database is in Australia East. Fine for testing, slower than the same region.

## Costs (Azure portal estimates, 14 Nov 2026)
- Test setup: Azure SQL Basic about US$5.39 per month, web app free.
- Production later: Basic B1 web app about US$13.87 per month plus the database, about US$19.26 per month in total.

## Deployment plan
1. Frontend (frontend/, Vite + React + Tailwind) builds into frontend/dist.
2. Backend (backend/, ASP.NET Core) connects to Azure SQL.
3. A GitHub Actions workflow publishes the integrated main branch to the web app (to be added to this branch).
4. Production: Rehana's own Azure account in Australia East, with her own domain and Stripe account.

## Rules
- No passwords, keys or connection strings in this repository.
