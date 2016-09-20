<<<<<<< HEAD
#Obtaining a Developer Access Token
Developer authentication is mandatory for all functions in the Groove API. All the functions share a common mandatory query parameter, accessToken, in which a valid authentication token must be passed.   
 [SignIn]: https://i-msdn.sec.s-msft.com/dynimg/IC702605.png
 [Registration]: https://i-msdn.sec.s-msft.com/dynimg/IC702606.png
 [Accept ToU]: https://i-msdn.sec.s-msft.com/dynimg/IC702607.png
 [Login Azure]: https://i-msdn.sec.s-msft.com/dynimg/IC702608.png
 [my account]: https://i-msdn.sec.s-msft.com/dynimg/IC702611.png
 [Registered applications]: https://i-msdn.sec.s-msft.com/dynimg/IC702609.png
 [Register your app]: https://i-msdn.sec.s-msft.com/dynimg/IC702612.png
 [Registeredapp2]: https://i-msdn.sec.s-msft.com/dynimg/IC702613.png  
 
+ [Authentication token](#authentication-token)
+ [Using valid tokens from Azure Marketplace](#using-valid-tokens-from-azure-marketplace)
+ [Create a developer account on Azure Marketplace](#create-a-developer-account-on-azure-marketplace)
+ [Register your application with Azure Marketplace](#register)
+ [Sign up](#sign-up)
+ [Make an HTTP POST request to the token service](#httppost)
+ [Using the access token](#accesstoken)
+ [Protecting the client's secret value](#protectclient)
+ [Calling the Groove RESTful API with the token](#callapi)
+ [Renewing the token before it expires](#renew)
+ [Sample code](#sample-code)

##Authentication token 
The authentication token is based on the Simple Web Token (SWT) format. It contains a list of name-value claims that identify the client application and validity period of the token; it also contains a signature to prevent malicious users from modifying the contents of the token. For more information about SWT, see Simple Web Token on MSDN.  

This authentication token is obtained from the Azure Marketplace authentication endpoint, and it should be considered opaque and be passed as-is in requests to the Groove Service; the only change necessary is to prefix the token with "Bearer", a standard prefix for OAuth tokens.   

The tokens have a validity period of 10 minutes, and there is a mechanism for renewing tokens described in Renewing the token before it expires, later in this topic.   

##Using valid tokens from Azure Marketplace
In order to be able to use the Groove RESTful API, a third-party developer must first create a developer account on Azure Marketplace and then subscribe to the Groove Platform offer (for free).   

Once properly subscribed, the third-party app should obtain authentication tokens from the ADM service by using the procedure in this section; the scope to use is ``` http://music.xboxlive.com/``` . The tokens have a validity   
period of 10 minutes and must be renewed after they expire—or ideally, before they expire.   

You must obtain an access token to use the Groove RESTful API. The access token is passed with each API call and is used to authenticate your access to the Groove RESTful API. It provides a secure access to the Groove RESTful API and allows the API to associate your application's requests to the Groove Service with your account on Azure Marketplace.   
  
Microsoft provides methods to obtain access tokens safely, repeatedly, and easily. To obtain an access token, complete the steps in the following procedure; each step links to a subsection in this topic that describes the step in more detail.

###To obtain an access token
1. Subscribe to the Groove RESTful API on Azure Marketplace . 
2. Register your application with Azure Marketplace. 
3. Make an HTTP POST request to the token service. 


## Create a developer account on Azure Marketplace
Subscribe to the Groove RESTful API on Azure Marketplace. Subscriptions are free.  

###To subscribe to the Groove RESTful API  

1. Visit <https://datamarket.azure.com>.  
2. Click **Sign In** in the upper right corner.   
 ![SignIn]
 
3. Register with the Microsoft account of your choice.  
If you don't have a Microsoft Account, you'll need to create a new one.  

 ![Registration]  
4. Accept the Terms of Use.  
 ![Accept ToU]
 
 <a name="register">
##Register your application with Azure Marketplace
</a>
After subscribing to the Groove RESTful API, you must register your application with Azure Marketplace.
###To register your application with Azure Marketplace
1. To register your application, sign in with the Microsoft account you used above.  
 ![Login Azure]
2. Click **My account** and then **Developers** in the menu on the left side of the screen.   
 ![my account]
3. Click the **Register** button, or go directly to <https://datamarket.azure.com/developer/applications>.    
![Registered applications]
4. Fill in the form with the required information.  
You can define your own client ID and application name. You must supply a URI for redirection to obtain the access code. A description is optional.    
![Register your app]   

    >Note  
      The client secret value is not shown in the preceding screenshot.

5. Take a note of the client ID and the client secret value.  
The secret value should be hidden from the client. The secret value should be used only on the server side for Azure Marketplace server authentication, to prevent it from being stolen and used by someone else.  

![Registeredapp2]     

  >**Note** 
These are the credentials that you will use to authenticate with the Groove RESTful API. Do not confuse  these client ID and secret with the customer ID and account key you received in the earlier step [Create a developer account on Azure Marketplace]. 

##Sign up
Sign up to the Groove RESTful API in the Azure Marketplace by visiting [the final page](https://datamarket.azure.com/dataset/xboxmusic/XboxMusicPlatform) and clicking **SIGN UP**.
![Sign up] 
 
  <a name="httppost">
## Make an HTTP POST request to the token service  
</a>
After you register your application with Azure Marketplace, make a POST request to the token service to obtain the access token. The parameters for the token request are URL-encoded and passed in the HTTP request body. Table 1 lists the mandatory input parameters and their descriptions.   

**Table 1. Token request input parameters**  

|Parameter|Description |
|:------------|:---------------|
|client_id|Required. The client ID that you specified when you registered your application with Azure Data Market.|
|client_secret|Required. The client secret value that you obtained when you registered your application with Azure Marketplace.|
|scope|Required. Use the URL *http://music.xboxlive.com* as the scope value for the Groove RESTful API.|
|grant_type|Required. Use "client_credentials" as the grant_type value for the Groove RESTful API.|

The response for the token request contains the access token that you can use to access the Groove RESTful API. The response is JSON-encoded and includes the output properties shown in Table 2.   

**Table 2. Token request output properties**  

|Property|Description|
|:------|:------|
|accessToken|The access token that you can use to authenticate you access to the Groove RESTful API.|
|token_type|The data type of the token. Currently, Azure Marketplace returns *http://schemas.xmlsoap.org/ws/2009/11/swt-token-profile-1.0*, which indicates that a Simple Web Token will be returned.|
|expires_in|The number of seconds for which the access token is valid.|
|scope|The domain for which this token is valid. For the Groove RESTful API, the domain is *http://music.xboxlive.com*.  |
  <a name="accesstoken">
##Using the access token
</a>
As mentioned earlier in this topic, you must obtain an access token to use the Groove RESTful API. The access token is secure, OAuth standard compliant, and flexible. The value of access token can be used for subsequent calls to the Groove RESTful API. The access token expires after 10 minutes.  

It is always better to check elapsed time between the time at which the token was issued and the current time. If the elapsed time exceeds 10 minutes, renew the access token by following the procedure for obtaining the access token.  

Remember the following points about using the access token:   

+ Either pass the 10-minute token you obtain as the parameter accessToken, or use the value of the accessToken property as the Authorization header to the calls to the Groove RESTful API. In either case, use the prefix "Bearer ". 
+ The access token is valid for 10 minutes. If the access token expires, you need to generate a new access token. The sample code in C#, linked at the end of this topic , can generate a new access token prior to exceeding the 10-minute period.
  <a name="protectclient">
##Protecting the client's secret value
</a>
The tokens are obtained from Azure Marketplace in exchange for a client ID and secret value, obtained during the subscription. If possible, these should be secured and used in such a way that cannot be intercepted on the client machine.  

If the application has a server component, then the server should be responsible for storing the client ID and secret value, and the server should obtain the tokens on behalf of the client component so that the secret value cannot be intercepted on the client machines.
  <a name="callapi">
##Calling the Groove RESTful API with the token
</a>
Once it is in possession of a valid authentication token, a third-party application may call the Groove RESTful API and provide the OAuth token in one of the following two ways:  

+ As the value of the URI query parameter, accessToken; be sure to encode the token for incorporation into a URL.
+ As the value of the **Authorization** HTTP header; however, we discourage the use of the **Authorization** header for developer authentication in favor of the query parameter instead, because the **Authorization** header will be used for user authentication in the future functions that will require it.  

  >**Note** 
The standard OAuth prefix "Bearer " must be prepended to the contents of the actual token retrieved from Azure.  


<a name="renew">
##Renewing the token before it expires
</a>
Because the access tokens are only valid for 10 minutes, they must be refreshed by sending a second request to the Azure Data Market service (located at <https://datamarket.accesscontrol.windows.net/v2/OAuth2-13>). We recommended that your code refresh them proactively before the end of the 10 minutes in order to avoid having a period of time when the Groove Service can't be used.  

This 10-minute duration may change in the future. You should not hardcode it, but rather rely on the validity duration returned in the response by Azure Datamarket along with the access token.   
##Sample code
+  [Getting Started with the Groove SDK](../Getting%20Started.md)
=======
#Obtaining a Developer Access Token
Developer authentication is mandatory for all functions in the Groove API. All the functions share a common mandatory query parameter, accessToken, in which a valid authentication token must be passed.   
 [SignIn]: https://i-msdn.sec.s-msft.com/dynimg/IC702605.png
 [Registration]: https://i-msdn.sec.s-msft.com/dynimg/IC702606.png
 [Accept ToU]: https://i-msdn.sec.s-msft.com/dynimg/IC702607.png
 [Login Azure]: https://i-msdn.sec.s-msft.com/dynimg/IC702608.png
 [my account]: https://i-msdn.sec.s-msft.com/dynimg/IC702611.png
 [Registered applications]: https://i-msdn.sec.s-msft.com/dynimg/IC702609.png
 [Register your app]: https://i-msdn.sec.s-msft.com/dynimg/IC702612.png
 [Registeredapp2]: https://i-msdn.sec.s-msft.com/dynimg/IC702613.png  
 
+ [Authentication token](#authentication-token)
+ [Using valid tokens from Azure Marketplace](#using-valid-tokens-from-azure-marketplace)
+ [Create a developer account on Azure Marketplace](#create-a-developer-account-on-azure-marketplace)
+ [Register your application with Azure Marketplace](#register)
+ [Sign up](#sign-up)
+ [Make an HTTP POST request to the token service](#httppost)
+ [Using the access token](#accesstoken)
+ [Protecting the client's secret value](#protectclient)
+ [Calling the Groove RESTful API with the token](#callapi)
+ [Renewing the token before it expires](#renew)
+ [Sample code](#sample-code)

##Authentication token 
The authentication token is based on the Simple Web Token (SWT) format. It contains a list of name-value claims that identify the client application and validity period of the token; it also contains a signature to prevent malicious users from modifying the contents of the token. For more information about SWT, see Simple Web Token on MSDN.  

This authentication token is obtained from the Azure Marketplace authentication endpoint, and it should be considered opaque and be passed as-is in requests to the Groove Service; the only change necessary is to prefix the token with "Bearer", a standard prefix for OAuth tokens.   

The tokens have a validity period of 10 minutes, and there is a mechanism for renewing tokens described in Renewing the token before it expires, later in this topic.   

##Using valid tokens from Azure Marketplace
In order to be able to use the Groove RESTful API, a third-party developer must first create a developer account on Azure Marketplace and then subscribe to the Groove Platform offer (for free).   

Once properly subscribed, the third-party app should obtain authentication tokens from the ADM service by using the procedure in this section; the scope to use is ``` http://music.xboxlive.com/``` . The tokens have a validity   
period of 10 minutes and must be renewed after they expire—or ideally, before they expire.   

You must obtain an access token to use the Groove RESTful API. The access token is passed with each API call and is used to authenticate your access to the Groove RESTful API. It provides a secure access to the Groove RESTful API and allows the API to associate your application's requests to the Groove Service with your account on Azure Marketplace.   
  
Microsoft provides methods to obtain access tokens safely, repeatedly, and easily. To obtain an access token, complete the steps in the following procedure; each step links to a subsection in this topic that describes the step in more detail.

###To obtain an access token
1. Subscribe to the Groove RESTful API on Azure Marketplace . 
2. Register your application with Azure Marketplace. 
3. Make an HTTP POST request to the token service. 


## Create a developer account on Azure Marketplace
Subscribe to the Groove RESTful API on Azure Marketplace. Subscriptions are free.  

###To subscribe to the Groove RESTful API  

1. Visit <https://datamarket.azure.com>.  
2. Click **Sign In** in the upper right corner.   
 ![SignIn]
 
3. Register with the Microsoft account of your choice.  
If you don't have a Microsoft Account, you'll need to create a new one.  

 ![Registration]  
4. Accept the Terms of Use.  
 ![Accept ToU]
 
 <a name="register">
##Register your application with Azure Marketplace
</a>
After subscribing to the Groove RESTful API, you must register your application with Azure Marketplace.
###To register your application with Azure Marketplace
1. To register your application, sign in with the Microsoft account you used above.  
 ![Login Azure]
2. Click **My account** and then **Developers** in the menu on the left side of the screen.   
 ![my account]
3. Click the **Register** button, or go directly to <https://datamarket.azure.com/developer/applications>.    
![Registered applications]
4. Fill in the form with the required information.  
You can define your own client ID and application name. You must supply a URI for redirection to obtain the access code. A description is optional.    
![Register your app]   

    >Note  
      The client secret value is not shown in the preceding screenshot.

5. Take a note of the client ID and the client secret value.  
The secret value should be hidden from the client. The secret value should be used only on the server side for Azure Marketplace server authentication, to prevent it from being stolen and used by someone else.  

![Registeredapp2]     

  >**Note** 
These are the credentials that you will use to authenticate with the Groove RESTful API. Do not confuse  these client ID and secret with the customer ID and account key you received in the earlier step [Create a developer account on Azure Marketplace]. 

##Sign up
Sign up to the Groove RESTful API in the Azure Marketplace by visiting [the final page](https://datamarket.azure.com/dataset/xboxmusic/XboxMusicPlatform) and clicking **SIGN UP**.
![Sign up] 
 
  <a name="httppost">
## Make an HTTP POST request to the token service  
</a>
After you register your application with Azure Marketplace, make a POST request to the token service to obtain the access token. The parameters for the token request are URL-encoded and passed in the HTTP request body. Table 1 lists the mandatory input parameters and their descriptions.   

**Table 1. Token request input parameters**  

|Parameter|Description |
|:------------|:---------------|
|client_id|Required. The client ID that you specified when you registered your application with Azure Data Market.|
|client_secret|Required. The client secret value that you obtained when you registered your application with Azure Marketplace.|
|scope|Required. Use the URL *http://music.xboxlive.com* as the scope value for the Groove RESTful API.|
|grant_type|Required. Use "client_credentials" as the grant_type value for the Groove RESTful API.|

The response for the token request contains the access token that you can use to access the Groove RESTful API. The response is JSON-encoded and includes the output properties shown in Table 2.   

**Table 2. Token request output properties**  

|Property|Description|
|:------|:------|
|accessToken|The access token that you can use to authenticate you access to the Groove RESTful API.|
|token_type|The data type of the token. Currently, Azure Marketplace returns *http://schemas.xmlsoap.org/ws/2009/11/swt-token-profile-1.0*, which indicates that a Simple Web Token will be returned.|
|expires_in|The number of seconds for which the access token is valid.|
|scope|The domain for which this token is valid. For the Groove RESTful API, the domain is *http://music.xboxlive.com*.  |
  <a name="accesstoken">
##Using the access token
</a>
As mentioned earlier in this topic, you must obtain an access token to use the Groove RESTful API. The access token is secure, OAuth standard compliant, and flexible. The value of access token can be used for subsequent calls to the Groove RESTful API. The access token expires after 10 minutes.  

It is always better to check elapsed time between the time at which the token was issued and the current time. If the elapsed time exceeds 10 minutes, renew the access token by following the procedure for obtaining the access token.  

Remember the following points about using the access token:   

+ Either pass the 10-minute token you obtain as the parameter accessToken, or use the value of the accessToken property as the Authorization header to the calls to the Groove RESTful API. In either case, use the prefix "Bearer ". 
+ The access token is valid for 10 minutes. If the access token expires, you need to generate a new access token. The sample code in C#, linked at the end of this topic , can generate a new access token prior to exceeding the 10-minute period.
  <a name="protectclient">
##Protecting the client's secret value
</a>
The tokens are obtained from Azure Marketplace in exchange for a client ID and secret value, obtained during the subscription. If possible, these should be secured and used in such a way that cannot be intercepted on the client machine.  

If the application has a server component, then the server should be responsible for storing the client ID and secret value, and the server should obtain the tokens on behalf of the client component so that the secret value cannot be intercepted on the client machines.
  <a name="callapi">
##Calling the Groove RESTful API with the token
</a>
Once it is in possession of a valid authentication token, a third-party application may call the Groove RESTful API and provide the OAuth token in one of the following two ways:  

+ As the value of the URI query parameter, accessToken; be sure to encode the token for incorporation into a URL.
+ As the value of the **Authorization** HTTP header; however, we discourage the use of the **Authorization** header for developer authentication in favor of the query parameter instead, because the **Authorization** header will be used for user authentication in the future functions that will require it.  

  >**Note** 
The standard OAuth prefix "Bearer " must be prepended to the contents of the actual token retrieved from Azure.  


<a name="renew">
##Renewing the token before it expires
</a>
Because the access tokens are only valid for 10 minutes, they must be refreshed by sending a second request to the Azure Data Market service (located at <https://datamarket.accesscontrol.windows.net/v2/OAuth2-13>). We recommended that your code refresh them proactively before the end of the 10 minutes in order to avoid having a period of time when the Groove Service can't be used.  

This 10-minute duration may change in the future. You should not hardcode it, but rather rely on the validity duration returned in the response by Azure Datamarket along with the access token.   
##Sample code
+  [Getting Started with the Groove SDK](../Getting Started.md)
>>>>>>> refs/remotes/origin/master
