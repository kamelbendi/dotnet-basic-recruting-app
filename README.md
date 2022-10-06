09.26.2022 : 

Approach to solve the problem :
first I followed the following two tutorials to get the basics of C# and .NET web API:

• C# tutorial : C# Full Course - Learn C# 10 and .NET 6 in 7 hours : https://www.youtube.com/watch?v=q_F4PyW8GTg

• .NET 6 web API tutorial : https://www.youtube.com/watch?v=Fbf_ua2t6v4

• setting up my machine : https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio-code
_____________

09.27.2022 :
adding validation, used link : 
https://learn.microsoft.com/pl-pl/dotnet/api/system.componentmodel.dataannotations.stringlengthattribute?view=net-6.0

_____________
09.28.2022 :
adding a database, used links :

https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio
https://www.youtube.com/watch?v=-yUsrUAUfHs

understand command tools to execute first code approach (old version of code, follow the first link for updated steps): https://www.youtube.com/watch?v=z-Hll4Xddjs

Linking Database with the API : 

full tutorial : https://www.youtube.com/watch?v=-yUsrUAUfHs

error handeling and testing working database : https://learn.microsoft.com/en-us/ef/core/cli/dotnet

_____________
10.06.2022 :
For Part two : 

in Order to make the code more sustainable, I would have made another folder in the main repository for *Services* where all the connections for the database will be specified there... it will contain all of the commands of the database, and have more of a SOLID architechture, since there is two responsibilities in the Controllers now. helpful link : https://enlabsoftware.com/development/how-to-apply-solid-principles-with-practical-examples-in-c-sharp.html


got the basics of unit testing from :

https://www.youtube.com/watch?v=uj0RWP3DdUo

https://www.youtube.com/watch?v=HYrXogLj7vg


# Prerequisites

This repository contains a code which you are supposed to work with. Please create a fork of this repo. As a result of your task please send us back a link to your github repository. While working with the code, please commit all changes to your repository, for us to check your progress.

- .NET 6.0 SDK installed.
- Visual Studio 2022/Visual Studio Code/JetBrains Rider

# Application

The application is a simple Web Api that is responsible for managing static sports data, such as teams, locations and so on.

## Challenge

The task will be divided into two parts:

1. Extending current solution with new required features.
2. Refactoring of current solution which is written in a non-testable way and doesn't follow proper development patterns.

### Part 1

1. Adding validation to the LocationController and TeamsController endpoints and based on that return proper HTTP Codes.

   1. Location
      1. Name is required and it's maximum length should be 255.
      2. City is required and it's maximum length should be 55.
      3. There can't be more than one location with the same name.
   2. Team
      1. Name is required and it's maximum length should be 255.
      2. CoachName is optional and it's maximum length should be 55.
      3. There can't be more than one team with the same name.

2. Integrating database to store Locations and Teams inside it. We suggest using SqlLiteDb, because it doesn't require any installation in the machine and can be integrated and run right away.
   1. Code first approach should be used.
   2. As a result all the data that api returns should come from the database.

### Part 2

1. As mentioned above, controllers and repositories aren't properly designed and don't follow general coding patterns such as SOLID, DRY, YAGNI. This part is all about you proposing how the code can be refactored in order to make it testable and more correct.
2. Writing unit tests for that would be additional benefit.

# How to run

You have two alternatives:

1. Build and run solution in your IDE.
2. Run `dotnet run --project .\MatchDataManager.Api` from project root directory.
