# Azure Monitor

## Overview

Azure Monitor delivers a comprehensive solution for collecting, analyzing, and acting on telemetry from your cloud and on-premises environments.

![Azure Monitor Diagram](./assets/azure-monitor-overview.png)

Azure Monitor can collect data from a variety of sources:

- applications,
- guest OS,
- Azure resource,
- Azure subscription,
- Azure tenant.

All data collected by Azure Monitor fits into one of two fundamental types:

- **metrics**: numerical values that describe some aspect of a system at a particular point of time. They are lightweight and capable of supporting near real-time scenarios.
- **logs**: data organized into records with different sets of properties for each type. Telemetry such as events and traces are stored as logs in addition to performance data so that it can all be combined for analysis.

## Insights and Curated Visualizations

Some Azure resources providers have a **curated visualization** which gives a customized monitoring experience for that particular service or set of services. Larger scalable curated visualizations are known as **insights** and marked with that name in the documentation and Azure portal.

Some examples:

- Application Insights,
- Container Insights,
- VM Insights.

## Application Insights

Application Insights is an extensible Application Performance Management (APM) service for monitoring live applications.

Application Insights works by installing a small instrumentation package (SDK) in an application or enabled using the Application Insights Agent when supported. Telemetry data is directed to an Azure Application Insights Resource using a unique GUID that is referred as an Instrumentation Key.

![Application Insights Overview](./assets/application-insights-overview.png)

In addition, telemetry can be pulled form the host environments such as performance counters, Azure diagnostics, or Docker logs.

All these telemetry streams are integrated into Azure Monitor.

Application Insights monitors the following:

- Requests rates, response times, and failure rates.
- Dependency rates, response times, and failure rates.
- Exceptions.
- Page views and load performance.
- AJAX calls.
- User and session counts.
- Performance counters.
- Host diagnostics.
- Diagnostic trace logs.
- Custom events and metrics.

There are several ways to get started monitoring and analyzing app performance:

- **At run time**: instrument web app on the server. Ideal for applications already deployed. Avoids any update to the code.
- **At development time**: add Application Insights to the code. Allows to customize telemetry collection and send additional telemetry.
- **Instrument web pages**: for page view, AJAX, and other client-side telemetry.
- **Analyze mobile app usage**: by integrating with Visual Studio App Center.
- **Availability tests**: ping website regularly from Azure servers.
