Good Morning,

Please use develop branch.

There is a docker-compose file,its composing the two apis,rabbitMQ and postgresdb.

the projects are as follows:
1. TrafficMonitor.API : provides endpoints to create and get traffic data,started with separate project for each concern,wanted to go and create business objects for a richer domain but started on other stuff so could not finish it.    
2. EagleBot.API : create endpoint for EagleBot,idea was to use the EagleBotCreatedEvent in EagleBot Domain and consume it in the TrafficMonitor Domain to populate the EagleBot table,using RabbitMq and MassTransit.Have most of the things in EagleApi project for this.
3. Have written Unittests and Integartion tests in separate projects
4.I have to configure certs in the containers,totally missed that,the container shows as running,but cannot connect via the browser.Will finish that part and see how it behaves.
5. I have two seed files 
  a.TrafficMonitor.Common.Migrations.SeedEagleBot
  b.TrafficMonitor.Common.Migrations.SeedTrafficData
  was planning to use these ids to populae getTrafficDataResponses.

Also implemented In memory redis cache,its use can be seen in the TrafficMonitorService,it's getting the paged response.
Also i have commented the volume for postgres,so i can apply migrations everytime when the app runs.


Apologies could not finish the compose,so you won't see anything running.
It was a really good test,wish could have been a fit faster.
Thankyou so much for your time.
