# AzureDemo Feedback Analysis System

## Overview

**AzureDemo** is a scalable feedback analysis system built with ASP.NET Core Razor Pages (.NET 9) and Azure serverless technologies. The application enables users to submit feedback via a web interface, which is then ingested, processed, and analyzed using Azure Functions, Azure Storage Queues, and optionally Azure Event Hub and Azure SQL Database. The architecture is designed for high scalability, reliability, and real-time or batch analytics.

---

## Features

- **User Feedback Submission:**  
  Users can submit feedback through a Razor Pages web interface.

- **Serverless Data Ingestion:**  
  Feedback is sent to an Azure Function (HTTP trigger), which enqueues the data for processing.

- **Asynchronous Processing:**  
  A queue-triggered Azure Function processes feedback, enabling scalable and decoupled workloads.

- **Real-Time Analytics (Optional):**  
  Feedback can be forwarded to Azure Event Hub for real-time stream processing and analytics.

- **Data Storage:**  
  Processed feedback is stored in Azure SQL Database for persistence and further analysis.

- **Scheduled Analysis:**  
  A timer-triggered Azure Function can periodically analyze stored feedback and generate reports or insights.

---

## Architecture


---

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- Azure Subscription
- Azure Storage Account
- Azure SQL Database
- (Optional) Azure Event Hub

---

## Getting Started

### 1. Clone the Repository


### 2. Configure Application Settings

Update `appsettings.json` with your Azure SQL Database and Event Hub connection strings:

### 3. Deploy Azure Functions

- Deploy the Azure Functions in `AzureDemo/Services/` to your Azure Function App.
- Ensure the required Azure Storage Queue (`datainput-queue`) exists.

### 4. Run the Razor Pages App

Visit `https://localhost:<port>/Feedback` to submit feedback.

---

## Key Files

- `Pages/Feedback.cshtml` & `Feedback.cshtml.cs` — Feedback submission UI and logic
- `Services/DataIngestFunction.cs` — HTTP-triggered Azure Function for ingestion
- `Services/DataProcessFunction.cs` — Queue-triggered Azure Function for processing
- `Services/DataAnalysisFunction.cs` — Timer-triggered Azure Function for analysis
- `Services/EventHubService.cs` — Service for sending data to Azure Event Hub
- `Models/Feedback.cs` — Feedback data model

---

## Scaling & Monitoring

- **Auto-Scaling:** Azure Functions and App Service scale automatically based on demand.
- **Monitoring:** Integrate with Azure Application Insights for logging and telemetry.

---

## Security

- Secure Azure Functions with function keys or Azure AD.
- Sanitize and validate all user input.

---

## License

MIT

---

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

---

## Contact

For questions or support, please open an issue in the repository.
