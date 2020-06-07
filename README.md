# SSLPinning

Goal : Enable SSL Pinning in WPF client 

Design Specification: 
For this problem i have setup very basic design having one API server and one wpf client
1)  API server hosted on IIS express with Url (https://localhost:44305) . This API server exposes a dummy post collection database. API server has installed self signed 
certificate for localhost server. Certificate Pinning is done on this certificate which is configured in app config file

Public API's 
https://localhost:44305/post/v1/{id}  , HTTP GET request to fecth given Post ID
https://localhost:44305/post/v1/all  , HTTP GET request to fetch all the posts.

2) A simple WPF client having a grid control which renders all the posts collection retrieved from API server. As mentioned above 
while making a REST call to API certificate pinning is done on http client handler callback.


Code Structure 

1) SSLPinningClient -- this solution contains WPF client
2) SSLPinningServer --- this solution contains Web API


Package Dependency
 Newtonsoft -- latest version
 
Framework 
.net core 3.1
