# Party Manager
Party Manager Coding Task

Made with Blazor Server App, .NET 5 and SQL Server DB Project

----------

Uses a CQRS Pattern to pipeline all application requests through a single route. Validation, Constraint Checks and logging etc can be performed in the pipeline leading to tidier code in the handlers.

Blazor was learnt as I wrote this so probably not the best use of things like re-useable components.

The task was supposed to take 4 hours so with learning Blazor and tuning the CQRS infrastructure, some corners cut due to time constraints; Unit Testing has only been done on the Drink section, and web ui layer of models was missed out so the web ui directly uses Application models. Not ideal, however this does mean the Blazor Services are really clean and minimilist!
