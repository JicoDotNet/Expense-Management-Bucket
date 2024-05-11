
# Expense Management App
**_Expense Management_** app is an `ASP.NET` application designed to simplify and automate the process of managing personal and business expenses. It provides a user-friendly interface for tracking, categorizing, and analyzing expenses in Graphical representation to help maintain financial discipline and budgeting.

## Table of Contents
- [Overview & Description](#overview--description)
- [Features](#features)
- [Usage](#usage)
  - [Screenshot](#screenshot)  
- [Demo](#demo)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Tech Stack](#tech-stack)
  - [Installation](#installation)
  - [Deployment](#deployment)
    - [Azure Table Storage](#azure-table-storage)
- [Authors and Acknowledgment](#authors-and-acknowledgment)
  - [Contributors](#contributors)
- [Contributing](#contributing)
- [Versioning](#versioning)
- [License](#license)
- [Contact](#contact)
- [Project Status](#project-status)
- [Note](#note)

## Overview & Description
This web-based expense manager app serves as a pivotal financial tool designed to track and manage your daily expenses. It’s engineered to offer a seamless interface for **logging transactions**, **organizing expenses** into categories, and **visually presenting** data through **intuitive graphs**. It provides a convenient way to record transactions, categorize spending with real-time insights into your financial habits. 
By delivering real-time insights into your spending behavior, our app empowers you to make well-informed choices that align with your financial objectives and aspirations.

_• It helps you make informed decisions to achieve your personal finance expense and goals._

## Features
Whether you’re looking to track daily expenditures, manage household budgets, or simply gain better control over your finances, an expense manager app is an essential tool for modern financial wellbeing.

- **Transaction Tracking:** Log every expense with a few clicks. Add details like amount, category, date, and notes.
- **Budget Planning:** Set monthly or custom period budgets for different categories and monitor your progress.
- **Reports and Insights:** Visualize your financial data with charts and graphs to identify spending trends and potential savings.
- **Data Export:** Generate and export detailed reports through intuitive graphs in various formats for personal record-keeping.
- **Accessibility:** Access your financial data across multiple devices with cloud synchronization.
- **Convenience:** Manage your finances on-the-go and keep your financial life organized in one place.

## Usage
An expense management app is a versatile tool designed to cater to a wide range of users who wish to track and manage their finances. Here’s a brief note on who can benefit from using such an app:

- **Individuals and Families:** For personal budgeting, tracking daily expenses, and planning for savings and investments.
- **Freelancers and Self-Employed Professionals:** To monitor project costs, manage invoices.
- **Small Business Owners:** To oversee operational expenses, employee reimbursements, and financial reporting.
- **Corporate Employees:** To submit work-related expenses for approval and reimbursement.
- **Travelers:** To keep track of travel expenses and stay within budget.
- **Students:** To manage limited budgets, track spending, and save for future expenses.

_In essence, anyone looking to gain better control over their financial situation can utilize this app to simplify and streamline the process of financial tracking._

### Screenshot
- [Add Record Image](https://github.com/JicoDotNet/Expense-Management-Bucket/assets/54305438/1d5c8bc6-5998-4510-997b-4c19b1b4e8d3)
- [Report Image](https://github.com/JicoDotNet/Expense-Management-Bucket/assets/54305438/e1447810-488c-4df4-8697-95636b86dfc8)

![Graph Image](https://github.com/JicoDotNet/Expense-Management-Bucket/assets/54305438/7d2d503a-d4b0-4350-9ffc-e03dc58745ee)

## Demo 
- URL - https://expensemanage-dotnet48.azurewebsites.net/
- You have to authenticate your identity by your email OTP.
> _This OTP authentication is only demo purpose._ ✨

## Getting Started
Let's start with development & deployment at your own system & server. 
> _It's required some software development knowledge._
### Prerequisites
What things you need to install the software and how to install them.
-  Windows 10 or 11 with [Visual Studio 2022](https://visualstudio.microsoft.com/vs/community) >= v.17.9.* `community edition`
- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net48-developer-pack-offline-installer) SDK `dev` `build`
- Azure Portal Account (https://portal.azure.com/)

### Tech Stack
- [Asp.Net Framework v4.8.*](https://dotnet.microsoft.com/en-us/learn/aspnet/what-is-aspnet)
- [Azure Table Storage](https://learn.microsoft.com/en-us/azure/storage/tables/table-storage-overview)
- [C#](https://dotnet.microsoft.com/en-us/languages/csharp)

### Installation
A step-by-step series of examples that tell you how to get a development environment running.

1. Get the project
    - Clone the repository using `git clone https://github.com/JicoDotNet/Expense-Management-Bucket.git`.
    - Or download the project from Github `https://github.com/JicoDotNet/Expense-Management-Bucket`
2. Open the solution in Visual Studio.
3. Restore the NuGet packages.
4. Update the connection string in `web.config`
5. (Optional) If required, update muster data in `JsonMetaData.json`
6. Run the application.

### Deployment
Notes about how to deploy this on a live system.

#### Azure Table Storage 
Need to add here how to get connection string of AZ Table Storage

## Authors and Acknowledgment
- **Soubhik Nandy** - _Initial work_ - [JicoDotNet](https://github.com/JicoDotNet)
- See also the list of [contributors](#contributors) who participated in this project.

### Contributors
- **Tuhin Paul** - _Architecture_ - [Tuhin](#)

## Contributing
Explain how others can contribute to the project. This may include guidelines for submitting bug reports, feature requests, or pull requests.

## Versioning
We use SemVer for versioning. For the versions available, see the [tags on this repository](https://github.com/JicoDotNet/Expense-Management-Bucket).

## License
This project is licensed under the MIT License - see the [`LICENSE`](https://github.com/JicoDotNet/Expense-Management-Bucket/blob/master/LICENSE) file for details.
- [MIT License](https://choosealicense.com/licenses/mit/)

## Contact
Contact information for the project maintainers.

## Project Status
The project is currently in the alpha stage; active development is in progress.