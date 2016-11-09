# Registering your application or service for the Groove API

To use the Groove API, you need to first register your application or
service and receive a Client ID to represent your application or service
in API calls.

## Agreeing to terms of use

TODO: stuff goes here for dev center integration steps

## Register your application or service

If your API calls are user authenticated, follow instructions on
[Groove User Authentication](User-Authentication.md)

To register an application for non-user authenticated calls:
1. Go to the [Microsoft Application Registration Portal](https://account.live.com/developers/applications)
2. When prompted, sign in with your Microsoft account credentials.
3. Find My applications and click Add an app.
4. Enter your app's name and click Create application.
5. Ensure that "Restrict token issuing to this app" is unchecked.

Once changes are saved you will be able to use the Application Id and
Application Secrets to authenticate your application or service.

TODO: INCLUDE SCREENSHOT HERE

TODO: stuff goes here for dev center integration steps

**Important** Treat the value of the application secret the same
as you would a user's password. The secret represents the key to your
application and, if made available, can be used to impersonate your application.

## Authenticating your application or service

IN CASE WE WANT MORE DETAILS: https://msdn.microsoft.com/library/windows/apps/hh465435

If your API calls are user authenticated, follow instructions on
[Groove User Authentication](User-Authentication.md)

For non-user authenticated API calls, you need to request an application
access token for the app.music.xboxlive.com scope.

The request consists of a form encoded POST call to
https://login.live.com/access.srf with parameters:

| Parameter name  | Value  | Description                                                                              |
|:---------------:|:------:|:-----------------------------------------------------------------------------------------|
| *grant_type*    | string | Use "client" as value for application token authentication. |
| *client_id*     | string | Your Application ID as displayed on your application page on the [Microsoft Application Registration Portal](https://account.live.com/developers/applications) |
| *client_secret* | string | Your Application Secret as displayed on your application page on the [Microsoft Application Registration Portal](https://account.live.com/developers/applications). The value needs to be URL encoded. |
| *scope*         | string | The scope your application requires. For application access to the Groove API the scope is "app.music.xboxlive.com" |

```
POST https://login.live.com/accesstoken.srf HTTP/1.1
Content-Type: application/x-www-form-urlencoded
Host: login.live.com
Content-Length: 123

grant_type=client_credentials&client_id={APP ID HERE...}&client_secret={CLIENT SECRET HERE...}&scope=app.music.xboxlive.com
```

If the application id and secret values are correct, the service will
reply with a JSON object containing the token type, the access token's
value and an expiry delay.

```
HTTP/1.1 200 OK
Content-Type: application/json
Content-Length: 524

{"token_type":"bearer","access_token":"Eg...==","expires_in":86400}
```

The resulting application access token can then be used in application
calls using the OAuth 2.0 bearer authorization method.

Note that tokens expire. Applications should take token expiry into
account and reauthenticate before access token expiry.

**Important:** Treat the value of `access_token` in this response as
securely as you would a user's password.


For example:
```
GET https://music.xboxlive.com/1/content/music/search?q=hello HTTP/1.1
Accept: application/json
Authorization: Bearer Eg...==
Host: music.xboxlive.com
```

TODO: Move this to the dev center application registration section somewhere higher up in the document

If you need to quickly get the an application access token, you can use the following PowerShell command on Windows:
```
> Invoke-WebRequest -Uri https://login.live.com/accesstoken.srf -Method Post -Body "grant
_type=client_credentials&client_id={APP ID HERE...}&client_secret={CLIENT SECRET HERE...}&scope=app.music.xboxlive.com"|ConvertFrom-Json|Format-List

token_type   : bearer
access_token : Eg...
expires_in   : 86400
```

Using curl:
```
% curl https://login.live.com/accesstoken.srf -d "grant_type=client_credentials&client_id={APP ID HERE...}&client_secret={CLIENT SECRET HERE...}&scope=app.music.xboxlive.com"
{"token_type":"bearer","access_token":"Eg...","expires_in":86400}
```

Using wget:
```
% wget https://login.live.com/accesstoken.srf --post-data "grant_type=client_credentials&client_id={APP ID HERE...}&client_secret={CLIENT SECRET HERE...}&scope=app.music.xboxlive.com" -q -O -
{"token_type":"bearer","access_token":"Eg...","expires_in":86400}
```
