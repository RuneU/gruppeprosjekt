# -bacit_dotnet
Base project for IS202 in dotnet
Text provided by Trym (https://github.com/Nosp1) - Modified slightly to fit this project. 

## Notice
Please read and understand how the dockerfile works. 
I recommend getting familiar with executing docker commands in the terminal before using the scripts.

## How to use
### Prerequisites:
To make this work, you need to have
- [ ] [Docker](https://www.docker.com/) installed and running on your system.
- [ ] Code editor or IDE such as [Micorsoft Visual sutdio](https://visualstudio.microsoft.com/downloads/) or [Rider](https://www.jetbrains.com/rider/download/#section=windows)
- [ ] Have [Node.js](https://nodejs.org/en/download) installed

### Via commandline with docker (Recommended):
> Note: On Unix and Unix-like systems (Mac and Linux) you might need to run the commands with `sudo` to make them work.

### Building of docker container
##### 1. Build then start the docker container with the web application:
`docker image build -t webapp .`

`docker container run --rm -it -d --name webapp --publish 80:80 webapp`

##### 2. Start a mariadb container using the localdirectory "database" to store the data:    

|Bash (Mac and Linux)|Powershell (Windows)|
|--------------------|--------------------|
|`docker run --name NoestedDatabase -p 3306:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=Gruppe4! -d mariadb:10.5.11`|`docker run --name NoestedDatabase -p 3306:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=Gruppe4! -d mariadb:10.5.11`|

##### 3. Enter the database and create the database and table for this skeleton:    
`docker exec -it NoestedDatabase mysql -p`

When prompted enter the password (`Gruppe4!`), then type or copy in the SQL from [this file](CreateDb.sql). 
First write the first line, thereafter you can write or copy the rest of the script.


### Building the project
#### 4. Open the project in the editor or IDE of choise
After opening the project run `npm install` in the terminal of directory of the project.

#### 5. Before running the project
Comment out all of the `[Authorize]` tags in `UserController.cs` & `AccountController.cs`.

#### 7. Run project and create the first admin user
Run and build the project. After successfully building the project, go to `https://localhost:00000/Account/Register` 
to register the first admin user. Login with an email account and create a strong password, and check off the `Sett 
som administrator` button. Then click the create button.

#### 8. After running the project
Remove the comments of the `[Authorize]` tags in `UserController.cs` & `AccountController.cs`.

#### 9. Done
Now you can use the program freely and use it as you please.

#### PS
Have fun and experiment :)

Code can be copied freely
