<<<<<<< HEAD
#Getting Started with the Groove SDK

##Subscribe to the Groove API on Azure Marketplace

The following are the minimal steps you need to complete to start experimenting with the API (for more detailed instructions, visit [Obtaining a Developer Access Token]).

[Obtaining a Developer Access Token]: Using%20the%20Groove%20RESTful%20Services/Obtaining%20a%20Developer%20Access%20Token.md
[Azure registration image]: https://i-msdn.sec.s-msft.com/dynimg/IC702606.png
[Windows Azure Marketplace]: https://datamarket.azure.com/developer/applications
[Register your app]: https://i-msdn.sec.s-msft.com/dynimg/IC702612.png

1. Visit <https://datamarket.azure.com>. 
2. Sign in with your Microsoft account and register to Datamarket by providing the required details.    
![Azure registration image]

3. Go to [Windows Azure Marketplace] to register your application that will make use of the API.    
  ![Register your app]
4. Fill in the correct details about your application (or website) carefully.
5. When done, take note of the provided **ClientID** and the **Secret**. They will be required to authenticate against the API in your code. These are different from the customer ID and account key you got from step 2.
 
6. Now subscribe to the free plan of the Groove API [here](http://go.microsoft.com/fwlink/?LinkID=389224).
7. Copy and paste your preferred sample code from below (C#, Windows Runtime or PHP) to start querying the API for Music data.

###C\# 
```csharp
 //datamarket authentication endpoint, must be https
string service = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";

 //the clientId from step 5
string clientId = "myClient";

 //the secret from step 5
string clientSecret = "REDACTED";
string clientSecretEnc = System.Uri.EscapeDataString(clientSecret);

 //will be used to store the authentication token
string token = null;
string tokenEnc = null;
HttpWebRequest request = null;
HttpWebResponse response = null;

 // scope used for authentication. NOTE: http. not https here!
string scope = "http://music.xboxlive.com";
string scopeEnc = System.Uri.EscapeDataString(scope);

string grantType = "client_credentials";

 //preparing the data for authentication
string postData = "client_id=" + clientId + "&client_secret=" + clientSecretEnc + "&scope=" + scopeEnc + "&grant_type=" + grantType;

  static string SendRequest(string method, string service, string postData)
  {

      string responseString = null;
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(service);

      UTF8Encoding encoding = new UTF8Encoding();
      byte[] data = encoding.GetBytes(postData);

      request.Method = method;
      request.ContentType = "application/x-www-form-urlencoded";
      request.ContentLength = data.Length;

      using (Stream stream = request.GetRequestStream())
      {
          stream.Write(data, 0, data.Length);
      }

      using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
      {
          responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
      }

      return responseString;
  }

 //send the authentication request
string responseString = SendRequest("POST", service, postData);

static string ExtractTokenFromJson(string json)
  {
      string token = null;
      Match match = Regex.Match(json, ".*\"access_token\":\"(?<token>.*?)\".*", RegexOptions.IgnoreCase);
      if (match.Success)
      {
          token = match.Groups["token"].Value;
      }
      return token;
  }

 //token to use to authenticate aginst the Groove API
token = ExtractTokenFromJson(responseString);
            
 //token will be used in the REST call, it hsould be encoded
tokenEnc = HttpUtility.UrlEncode(token);

 //and the request to the API (Note: the API endpoint is https)
  request = (HttpWebRequest)WebRequest.Create("https://music.xboxlive.com/1/content/music/search?q=daft+punk&accessToken=Bearer+" + tokenEnc);
  request.Method = WebRequestMethods.Http.Get;
  request.Accept = "application/json";
  using (response = (HttpWebResponse)request.GetResponse())
  {
      using (var sr = new StreamReader(response.GetResponseStream()))
      {
          responseString = sr.ReadToEnd();
      }
  }
Console.WriteLine(responseString);
```
###Windows Runtime 

    using System;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Windows.Web.Http;

    namespace RestTest
    {
      public class Test
      {
          public static async void Go()
          {
              var client = new HttpClient();
              
              // Define the data needed to request an authorization token.
              var service = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
              var clientId = "myClient";
              var clientSecret = "REDACTED";
              var scope = "http://music.xboxlive.com";
              var grantType = "client_credentials";

              // Create the request data.
              var requestData = new Dictionary<string, string>();
              requestData["client_id"] = clientId;
              requestData["client_secret"] = clientSecret;
              requestData["scope"] = scope;
              requestData["grant_type"] = grantType;

              // Post the request and retrieve the response.
              var response = await client.PostAsync(new Uri(service), new HttpFormUrlEncodedContent(requestData));
              var responseString = await response.Content.ReadAsStringAsync();
              var token = Regex.Match(responseString, ".*\"access_token\":\"(.*?)\".*", RegexOptions.IgnoreCase).Groups[1].Value;

              // Use the token in a new request.
              service = "https://music.xboxlive.com/1/content/music/search?q=daft+punk&accessToken=Bearer+";
              response = await client.GetAsync(new Uri(service + WebUtility.UrlEncode(token)));
              responseString = await response.Content.ReadAsStringAsync();
              Debug.WriteLine(responseString);
          }
       }
    }
 
  
###PHP

```php
class Xboxmusic {
      var $serviceauth = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
      var $serviceapi = "https://music.xboxlive.com/1/content";
      var $clientId = "yourclientID";
      var $clientSecret = "yourapplicationclientsecret";
      var $scope = "http://music.xboxlive.com";
      var $grantType = "client_credentials";

      public function auth() {
          $requestData = array("client_id" => $this->clientId, "client_secret" => $this->clientSecret, "scope" => $this->scope, "grant_type" => $this->grantType);
          $options = array(
              'http' => array(
                  'header'  => "Content-type: application/x-www-form-urlencoded\r\n",
                  'method'  => 'POST',
                  'content' => http_build_query($requestData),
              ),
          );
          $context  = stream_context_create($options);
          $response = json_decode(@file_get_contents($this->serviceauth, false, $context),true);
          $token = $response['access_token'];
          return $token;
      }

      public function search($string,$token) {
          $url = $this->serviceapi.'/music/search?q='.urlencode($string).'&accessToken=Bearer+'.urlencode($token);
          $response = @file_get_contents($url);
          return $response;
      }

      public function lookup($ids_array,$token, $extras = '') {
          $string = '';
          foreach($ids_array as $value) {
              $string .= $value.'+';
          }
          $string = rtrim($string, '+');
          if(!empty($extras)) $url = $this->serviceapi.'/'.$string.'/lookup?accessToken=Bearer+'.urlencode($token).'&extras='.$extras;
          else $url = $this->serviceapi.'/'.$string.'/lookup?accessToken=Bearer+'.urlencode($token);
          $response = @file_get_contents($url,true);
          return $response;
      }

  }

//using the class
$MusicAPI = new Xboxmusic;
$token = $MusicAPI->auth();
$json_response = $MusicAPI->search("madonna", $token);
```
=======
#Getting Started with the Groove SDK

##Subscribe to the Groove API on Azure Marketplace

The following are the minimal steps you need to complete to start experimenting with the API (for more detailed instructions, visit [Obtaining a Developer Access Token](Using the Groove RESTful Services/Obtaining a Developer Access Token.md)).

[Azure registration image]: https://i-msdn.sec.s-msft.com/dynimg/IC702606.png
[Windows Azure Marketplace]: https://datamarket.azure.com/developer/applications
[Register your app]: https://i-msdn.sec.s-msft.com/dynimg/IC702612.png

1. Visit <https://datamarket.azure.com>. 
2. Sign in with your Microsoft account and register to Datamarket by providing the required details.    
![Azure registration image]

3. Go to [Windows Azure Marketplace] to register your application that will make use of the API.    
  ![Register your app]
4. Fill in the correct details about your application (or website) carefully.
5. When done, take note of the provided **ClientID** and the **Secret**. They will be required to authenticate against the API in your code. These are different from the customer ID and account key you got from step 2.
 
6. Now subscribe to the free plan of the Groove API [here](http://go.microsoft.com/fwlink/?LinkID=389224).
7. Copy and paste your preferred sample code from below (C#, Windows Runtime or PHP) to start querying the API for Music data.

###C\# 
```csharp
 //datamarket authentication endpoint, must be https
string service = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";

 //the clientId from step 5
string clientId = "myClient";

 //the secret from step 5
string clientSecret = "REDACTED";
string clientSecretEnc = System.Uri.EscapeDataString(clientSecret);

 //will be used to store the authentication token
string token = null;
string tokenEnc = null;
HttpWebRequest request = null;
HttpWebResponse response = null;

 // scope used for authentication. NOTE: http. not https here!
string scope = "http://music.xboxlive.com";
string scopeEnc = System.Uri.EscapeDataString(scope);

string grantType = "client_credentials";

 //preparing the data for authentication
string postData = "client_id=" + clientId + "&client_secret=" + clientSecretEnc + "&scope=" + scopeEnc + "&grant_type=" + grantType;

  static string SendRequest(string method, string service, string postData)
  {

      string responseString = null;
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(service);

      UTF8Encoding encoding = new UTF8Encoding();
      byte[] data = encoding.GetBytes(postData);

      request.Method = method;
      request.ContentType = "application/x-www-form-urlencoded";
      request.ContentLength = data.Length;

      using (Stream stream = request.GetRequestStream())
      {
          stream.Write(data, 0, data.Length);
      }

      using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
      {
          responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
      }

      return responseString;
  }

 //send the authentication request
string responseString = SendRequest("POST", service, postData);

static string ExtractTokenFromJson(string json)
  {
      string token = null;
      Match match = Regex.Match(json, ".*\"access_token\":\"(?<token>.*?)\".*", RegexOptions.IgnoreCase);
      if (match.Success)
      {
          token = match.Groups["token"].Value;
      }
      return token;
  }

 //token to use to authenticate aginst the Groove API
token = ExtractTokenFromJson(responseString);
            
 //token will be used in the REST call, it hsould be encoded
tokenEnc = HttpUtility.UrlEncode(token);

 //and the request to the API (Note: the API endpoint is https)
  request = (HttpWebRequest)WebRequest.Create("https://music.xboxlive.com/1/content/music/search?q=daft+punk&accessToken=Bearer+" + tokenEnc);
  request.Method = WebRequestMethods.Http.Get;
  request.Accept = "application/json";
  using (response = (HttpWebResponse)request.GetResponse())
  {
      using (var sr = new StreamReader(response.GetResponseStream()))
      {
          responseString = sr.ReadToEnd();
      }
  }
Console.WriteLine(responseString);
```
###Windows Runtime 

    using System;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Windows.Web.Http;

    namespace RestTest
    {
      public class Test
      {
          public static async void Go()
          {
              var client = new HttpClient();
              
              // Define the data needed to request an authorization token.
              var service = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
              var clientId = "myClient";
              var clientSecret = "REDACTED";
              var scope = "http://music.xboxlive.com";
              var grantType = "client_credentials";

              // Create the request data.
              var requestData = new Dictionary<string, string>();
              requestData["client_id"] = clientId;
              requestData["client_secret"] = clientSecret;
              requestData["scope"] = scope;
              requestData["grant_type"] = grantType;

              // Post the request and retrieve the response.
              var response = await client.PostAsync(new Uri(service), new HttpFormUrlEncodedContent(requestData));
              var responseString = await response.Content.ReadAsStringAsync();
              var token = Regex.Match(responseString, ".*\"access_token\":\"(.*?)\".*", RegexOptions.IgnoreCase).Groups[1].Value;

              // Use the token in a new request.
              service = "https://music.xboxlive.com/1/content/music/search?q=daft+punk&accessToken=Bearer+";
              response = await client.GetAsync(new Uri(service + WebUtility.UrlEncode(token)));
              responseString = await response.Content.ReadAsStringAsync();
              Debug.WriteLine(responseString);
          }
       }
    }
 
  
###PHP

```php
class Xboxmusic {
      var $serviceauth = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
      var $serviceapi = "https://music.xboxlive.com/1/content";
      var $clientId = "yourclientID";
      var $clientSecret = "yourapplicationclientsecret";
      var $scope = "http://music.xboxlive.com";
      var $grantType = "client_credentials";

      public function auth() {
          $requestData = array("client_id" => $this->clientId, "client_secret" => $this->clientSecret, "scope" => $this->scope, "grant_type" => $this->grantType);
          $options = array(
              'http' => array(
                  'header'  => "Content-type: application/x-www-form-urlencoded\r\n",
                  'method'  => 'POST',
                  'content' => http_build_query($requestData),
              ),
          );
          $context  = stream_context_create($options);
          $response = json_decode(@file_get_contents($this->serviceauth, false, $context),true);
          $token = $response['access_token'];
          return $token;
      }

      public function search($string,$token) {
          $url = $this->serviceapi.'/music/search?q='.urlencode($string).'&accessToken=Bearer+'.urlencode($token);
          $response = @file_get_contents($url);
          return $response;
      }

      public function lookup($ids_array,$token, $extras = '') {
          $string = '';
          foreach($ids_array as $value) {
              $string .= $value.'+';
          }
          $string = rtrim($string, '+');
          if(!empty($extras)) $url = $this->serviceapi.'/'.$string.'/lookup?accessToken=Bearer+'.urlencode($token).'&extras='.$extras;
          else $url = $this->serviceapi.'/'.$string.'/lookup?accessToken=Bearer+'.urlencode($token);
          $response = @file_get_contents($url,true);
          return $response;
      }

  }

//using the class
$MusicAPI = new Xboxmusic;
$token = $MusicAPI->auth();
$json_response = $MusicAPI->search("madonna", $token);
```
>>>>>>> refs/remotes/origin/master
