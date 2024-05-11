
# Expense Management App
**_Expense Management_** app is an `ASP.NET` application designed to simplify and automate the process of managing personal and business expenses. It provides a user-friendly interface for tracking, categorizing, and analyzing expenses in Graphical representation to help maintain financial discipline and budgeting.

## Table of Contents
- [Overview & Description](#overview--description)
- [Features](#features)
- [Usage](#usage)
  - [Screenshots](#screenshots)  
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
- [Versioning & Change log](#versioning--Change-log)
  - [V1.1](#v11)
  - [V1.0](#v10)
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

### Screenshots
- [Add Record Image](https://github.com/JicoDotNet/Expense-Management-Bucket/assets/54305438/1d5c8bc6-5998-4510-997b-4c19b1b4e8d3)
- [Report Image](https://github.com/JicoDotNet/Expense-Management-Bucket/assets/54305438/e1447810-488c-4df4-8697-95636b86dfc8)
- [Intuitive Graphs Image](https://github.com/JicoDotNet/Expense-Management-Bucket/assets/54305438/7d2d503a-d4b0-4350-9ffc-e03dc58745ee)
![Intuitive Graphs Image](https://github.com/JicoDotNet/Expense-Management-Bucket/assets/54305438/7d2d503a-d4b0-4350-9ffc-e03dc58745ee)

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
- **Soubhik Nandy** - _Initial work_ - [@JicoDotNet](https://github.com/JicoDotNet) - Code Owner
- See also the list of [contributors](#contributors) who participated in this project.

### Contributors
- **Tuhin Paul** - _Architecture_ - [@codewithtuhin](#https://github.com/codewithtuhin)

## Contributing
This project is a collaborative effort that can involve various forms of participation. Here’s a guide on how you can contribute:
**Submitting Bug Reports**
- **Identify the Bug:** Clearly describe the issue you’ve encountered. Include details such as the context in which the bug occurred, steps to reproduce it, and the expected vs. actual results.
- **Check Existing Issues:** Before submitting a new bug report, search the project’s issues to ensure it hasn’t been reported already.
- **Use the Template:** Follow any issue template provided by the project. This often includes specific details the maintainers need.
- **Include Logs and Screenshots:** If applicable, add logs and screenshots to help maintainers understand the problem.

**Feature Requests**
- **Suggesting Enhancements**: Propose new features or improvements to existing ones. Explain the benefits and potential impact on the project.
- **Discuss in Issues:** Use the project’s issues section to discuss ideas with maintainers and other contributors.
- **Be Patient:** Remember that maintainers are often volunteers. It may take time for them to respond to your request.

**Pull Requests**
- **Fork the Repository:** Create your own copy of the project to work on.
- **Create a Branch:** Make a new branch in your fork for your changes.
- **Make Changes:** Implement your bug fix or feature, adhering to the project's coding standards.
- **Write Tests:** If the project has tests, add tests for your changes to ensure they work as expected.
- **Pull Request:** Submit a pull request to the original repository. Fill in the provided PR template with details of your changes.
- **Code Review:** Be open to feedback and make requested changes during the code review process.
Remember to always read the project’s CONTRIBUTING.md file, if one exists, as it will contain specific guidelines tailored for the project’s needs. You are open to contribute. Happy contributing! 🚀

## Versioning & Change log
We use SemVer for versioning. For the versions available, see the [tags on this repository](https://github.com/JicoDotNet/Expense-Management-Bucket).

#### V1.1
##### New/Changed/Removed features
N/A
##### Fixed defects
N/A
##### Maintenance/Miscellaneous
- Add `JsonMetaData.json` to handel master data

#### V1.0
##### New/Changed/Removed features
Initial implementation of this app
##### Features
- Login Page
- Tranction Record add page
- Report Page
- Intuitive Graphs

##### Maintenance/Miscellaneous
N/A

## License
This project is licensed under the MIT License - see the [`LICENSE`](https://github.com/JicoDotNet/Expense-Management-Bucket/blob/master/LICENSE) file for details.
- [MIT License Details](https://choosealicense.com/licenses/mit/)

## Contact
Contact information for the project maintainers.

## Project Status
The project is currently in the `alpha` stage; active development is in progress.

### Note
This project was built and develop in early 2021. In January 2024 it is migrated from Azure DevOps to Github.