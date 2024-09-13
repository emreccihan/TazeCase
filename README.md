
# Taze Backend Case

This Repo contains the backend of the Form Project that Taze sends as a task. 

It contains two microservices. FormService and ReportService. 
FormService is created for adding data and ReportService is created for reporting the added data.

## Getting Started with the Project

Clone the Project

```bash 
git clone https://github.com/emreccihan/TazeCase.git
```
    
## Environment Variables

To run this project you will need to add the following environment variables to your appsetting.json file

`ConnectionStrings`


  
## Properties

- Add Form
- Add Dynamic Form Field
- Add Form Data
- Get Form Report
- Get Form Data Report

  
## Technologies Used

 EntityFramework, Automapper, MSSQL, NewtonSoft.Json



  ## Folder Structure

```bash 
├── src
│   ├── Services
│   │   ├── Form
│   │   │   ├── TazeCase.Form.Api
│   │   │   ├── TazeCase.Form.Business
│   │   │   ├── TazeCase.Form.Core
│   │   │   ├── TazeCase.Form.Data
│   │   ├── Report
│   │   │   ├── TazeCase.Report.Api
│   │   │   ├── TazeCase.Report.Business
│   │   │   ├── TazeCase.Report.Core
```
