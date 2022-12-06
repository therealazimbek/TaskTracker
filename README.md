
# TaskTracker Web Api

This is TaskTracker Web Api using ASP.NET Core Web API. Main feature is to manage projects and tasks within a project.


## API Reference

### Projects
| Request | Parameter | Body     | Description                |
| :------ | :-------- | :------- | :------------------------- |
| `GET /api/Projects` | `none` | `none` | Return a list of projects |
| `GET /api/Projects/{id}` | `int:id` | `none` | Returns a project |
| `POST /api/Projects` | `none` | `json:project` | Creates new project |
| `PUT /api/Projects/{id}` | `int:id` | `json:project` | Updates a project |
| `DELETE /api/Projects/{id}` | `int:id` | `none` | Deletes a project |

### Tasks

| Request | Parameter | Body     | Description                |
| :------ | :-------- | :------- | :------------------------- |
| `GET /api/Projects/{id}/Tasks/` | `int:id` | `none` | Return a list of tasks of a project |
| `GET /api/Projects/{id}/Tasks/{taskId}` | `int:id, int:taskId` | `none` | Return a task of project |
| `POST /api/Projects/{id}/Tasks/` | `int:id` | `json:task` | Create a new task in a project |
| `PUT /api/Projects/{id}/Tasks/{taskId}` | `int:id, int:taskId` | `json:task` | Update a task |
| `DELETE /api/Projects/{id}/Tasks/{taskId}` | `int:id, int:taskId` | `none` | Delete a task |

## Features

- create / view / edit / delete information about projects
- create / view / edit / delete task information
- add and remove tasks from a project (one project can contain several tasks)
- view all tasks in the project



## Installation

1. Clone this repository

```bash
  git clone https://github.com/therealazimbek/TaskTracker.git
```

2. In the main project directory run
```bash
    dotnet build
```
```bash
    dotnet run
```
## Dependencies
### SDK and Runtime
1. .NET Core SDK (v6)
2. ASP.NET Core Runtime (v6)

### Packages
1. Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore (v-6.0.11)
2. Microsoft.EntityFrameworkCore.Tools (v-7.0.0)
3. Microsoft.VisualStudio.Web.CodeGeneration.Design (v-6.0.10)
4. Npgsql.EntityFrameworkCore.PostgreSQL (v-7.0.0)
5   . Swashbuckle.AspNetCore (v-6.2.3)

### Database
Local PostgreSQL 14 DB was used




## Authors

- [@therealazimbek](https://www.github.com/therealazimbek)
