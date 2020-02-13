# ArcanysGithubApi

ArcanysGitHubApi is an api project using .net core, it utilizes the built in memory cache that would store search results. When the records is in the memory, it would not fetch to github again. The end point uses app authentication from github to have 5000 requests per hour (unauthorized request is limited only to 60 requests per hour).

## Installation & Configuration

Clone the application or download as zip file.

```sh
https://github.com/ArcMarky/ArcanysGithubApi.git
```

Change the appsettings.json 

Modifiy the configration for the authentication of the github app and the error log location and the api endpoint to be accessed (if github changes the end point)
```sh
    "GitHubClientId": "e67b62c814d7d3bd188c",
    "GitHubClientSecret": "113c070c1a13688d07067dedef916bfbfe4be07b",
    "GitHubUsersUrl": "https://api.github.com/users/",
    "ErrorLogLocation": "D:\\ErrorLog"
```

Modifiy serilog configuration according to your needs but the default configration has been added, just modifiy the location of the error log to be generated 
```sh
    "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
    "MinimumLevel": {
      "Default": "Debug",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "Enrich": [ "FromLogContext" ],
    "WriteTo": [
      { "Name": "Console" },
      { "Name": "Debug" },
      {
        "Name": "File",
        "Args": {
          "path": "D:\\ErrorLog\\log.txt",
          "rollingInterval": "Day",
          "shared": true
        }
      }
    ],
    "Properties": {
      "Application": "sampleapp"
    }
  }
```

##Usage example

Open up your API testing tool like Postman, then create a request with a method of ``POST`` and access the end point

```sh
https://localhost:portnumberhere/api/github/GetGitHubUsers
```
Body of the request as raw json format
```sh
["quiters89","someotherusers"]
```

The endpoint should response a json object that contains information about the result of the request.

##Release history

* 0.0.1
    * First Deployment

##Meta

Mark Eulyses Yu –  m.yu@arcanys.com

Distributed under free community license. See ``LICENSE`` for more information.

[https://github.com/ArcMarky](https://github.com/ArcMarky) 


