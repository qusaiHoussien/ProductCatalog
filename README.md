# ProductCatalog

how to start the project?

1-open project with visual studio
2-in Server folder open appsetting.json and sure is that connection string correspond with your sql server
3-open package manager console and change direct to "/ProductCatalog/Productcatalog/productCatalog/Server" then run this command <dotnet ef database update>
  4-set server as startup
  5-run the project
  6-open browser and open this site "https://localhost:7253/swagger"
  
  time:
  I developed this project in 7 days,I worked from 3 to 4 hours daily
  
  1-system analysis and designing data base and designing work flow take 2 days
  2-create data model and relationship and implement authentication and add authentication middleware
  and global error handling take 2 days
  3-create repository and controller and inject repository and create dtos and add auto mapper and validate data take 2 days
  4-testing take 1 day
