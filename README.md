# readme

the official training code

## command line

### git

- `git add <path> [<path>] .. [<path>]`, stage the changes to be committed
- `git commit -m '<message>'`, commit/save the staged changes
- `git clone <url> [<path>]`, copy remote repository locally with tracking
- `git status`, list the current changes
- `git log`, list the current commits

### dotnet

- `dotnet new sln -n <solution_name>`, create a new solution
- `dotnet new console -n <project_name>`, create a new console project, .exe assembly
- `dotnet new classlib -n <project_name>`, create a new class library project, .dll assembly
- `dotnet new xunit -n <project_name>`, create a new test library project, .exe assembly
- `dotnet tool install -g dotnet-ef`, install ef core cli tooling
- `dotnet ef migrations add`, create a migration for the current entity state
- `dotnet ef database update`, apply current migrations to database

### docker

- `docker container run -dit --rm --name sqlserver -p 1433:1433 -e 'ACCEPT_EULA=y' -e 'SA_PASSWORD=Password12345' mcr.microsoft.com/mssql/server:2017-latest`, launch a new sql server database
- `docker container ls [-a]`, list all running containers
- `docker container stop <container_id>`, stop the running container
- `docker container run --name <container_name>`, run a stopped container

## maintainer

- fred belotte

## license

[MIT License](https://github.com/2002-24-dotnet/training-code/blob/master/LICENSE)
