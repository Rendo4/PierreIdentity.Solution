# Pierre Identity#

#### _A MVC application in C# to show my early learning of mysql database and Authentication. The application keeps track of a cafe and the treats they can make while adding flavors to those existing treats._ a

#### By _**Ryan Rendon**_

## Technologies Used

* _C#_
* _Entity Framework_
* _MySQL_
* _ASP.Net Core MVC_
* _Razor_
* _NET 5.0_

## Description

_Hello and thank you for viewing my 'PierreIdentity.Solution' application! This project uses concepts learned in my early weeks of study C# at epicodus. It practices creating MVC applications and connecting them with MySQL work bench using many to many relationships. It uses two models of Treats for a cafe owner to manage their treats while having options of flavors to add to said Treats. It allows users to register for an account to access the application._
## Setup/Installation Requirements

* You can visit my github Rendo4 or you can copy this link to my repository https://github.com/Rendo4/PierreIdentity.Solution_
* _open your terminal_
* _use the command "cd desktop"_
* _use the command "git clone https://github.com/Rendo4/PierreIdentity.solution_
* _It should now be on your desktop!_ 
* _If you haven't already downloand and set up MySQL workbench
* _In your terminal cd desktop/PierreIdentity.Solution/PierreIdentity_
* _In your termninal touch appsettings.json (This will create a file for you to connect to MySQL work bench)_
* _In the appsetting.json file copy the following code and replace the username and password with your MySQL username and password._
* _{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=ryan_rendon;uid=[username];pwd=[password];"
  }
}_
* _Run the command "dotnet restore" followed by "dotnet build"._
* _Run the command  "dotnet ef database update" to build the database after logging into your MYSWL Workbench.
* _ Run the command "dotnet run" and your application should be running!
## Known Bugs

* _No known bugs._

## License

Copyright 2022 Ryan Rendon

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

## Contact Information
_{Rendon.S.Ryan@gmail.com}_