# Groove User Authentication

To use the user-authenticated APIs, you need to have an access token that authenticates
your app to a particular set of permissions for a user. In this section, you'll learn how to:

1. Sign your user in to Groove with the specified [scopes](#authentication-scopes) using the token flow or code flow.
2. Sign the user out (optional).

The Groove API uses the standard [OAuth 2.0](http://oauth.net/2/) authentication scheme to authenticate users and generate access tokens. You must provide an access token for every user-authenticated API call via the following header:

* `Authorization: Bearer {token}`

Note that you'll still need to provide a [developer access token](Obtaining a Developer Access Token.md) in the *accessToken* query parameter.

## Register a Microsoft Account application

To register your app to connect with Groove, you'll need a Microsoft account.

1. Go to the [Microsoft Application Registration Portal](https://account.live.com/developers/applications)
2. When prompted, sign in with your Microsoft account credentials.
3. Find My applications and click Add an app.
4. Enter your app's name and click Create application.
5. Scroll to the bottom of the page and check the Live SDK support box.

After you've completed these steps, an application ID and application secret are created for your app and displayed on your new app's properties page.

**Important** Treat the value of client secret the same as you would a user's password. The secret represents the key to your application and, if made available, can be used to impersonate your application.

Under the Platforms header, configure details about your app. By default a new app is created as a web app and needs one or more redirect URIs. To enable native client flows for your app as well, click the Add Platform button and choose Mobile.

## Sign users in

Your app must initiate the sign-in process by contacting the
Microsoft account authorization web service with a specified scope, and receive
an access token. The flow follows standard OAuth 2.0 authentication flows and
requires calls from a web browser or web-browser control.

## Authentication scopes

Scopes determine what type of access the app is granted when the user is signed
in.


| Scope name         | Description                                                                                                                                                                                                                   | Required |
|:-------------------|:------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:---------|
| MicrosoftMediaServices.GrooveApiAccess  | Grants read and write permission to a user's music collection and playlists along with other user-authenticated scenarios.                                                                                                                       | Yes      |
| offline_access     | Enables your app to work offline even when the user isn't active. This provides your app with a refresh_token that can be used to generate additional access tokens as necessary. This scope is not available for token flow. | No       |

As an example, a typical application might request the following scopes:

```
MicrosoftMediaServices.GrooveApiAccess offline_access
```

## Supported Authentication flows

There are two supported authentication flows to choose from:

* [Token flow](#token-flow)
* [Code flow](#code-flow)

## Token flow
The easiest authentication flow is the token flow. This flow is useful for quickly
obtaining an access token to use the Groove API in an interactive fashion. This flow
does not provide a refresh token, so it can't be used for long term access to the
Groove API.

![Token Flow Diagram](/Main/site-images/msa-implicit-grant-flow.PNG)

To start the sign-in process with the token flow, use a web browser or web-browser
control to load a URL request.

```
GET https://login.live.com/oauth20_authorize.srf?client_id={client_id}&scope={scope}
    &response_type=token&redirect_uri={redirect_uri}
```

### Required query string parameters
| Parameter name  | Value  | Description                                                                              |
|:----------------|:-------|:-----------------------------------------------------------------------------------------|
| *client_id*     | string | The client ID value created for your application.                                        |
| *redirect_uri*  | string | The redirect URL that the browser is sent to when authentication is complete.            |
| *response_type* | string | The type of response expected from the authorization flow. For this flow, the value must be **token**. |
| *scope*         | string | A space-separated list of scopes your application requires.                              |

Use this redirect URL for mobile and desktop applications `https://login.live.com/oauth20_desktop.srf`.

### Response

Upon successful authentication and authorization of your application, the web browser
will be redirected to your redirect URL with additional parameters added to the URL.

```
https://login.live.com/oauth20_authorize.srf#access_token=EwC...EB
  &authentication_token=eyJ...3EM&token_type=bearer&expires_in=3600
  &scope=MicrosoftMediaServices.GrooveApiAccess&user_id=3626...1d
```

Values for `access_token`, `authentication_token`, and `user_id` are truncated
in the previous example. The values for `access_token` and `authentication_token`
are quite long.

You can use the value of `access_token` to make requests to the Groove API.

## Code flow

The code flow for authentication is a three-step process with separate calls to authenticate and authorize
the application and to generate an access token to use the Groove API. This also
allows your application to receive a refresh token that will enable long-term
use of the API in some scenarios, to allow access when the user isn't actively using your application.

![Authorization Code Flow Diagram](/Main/site-images/msa-authorization-code-flow.PNG)

### Step 1. Get an authorization code
To start the sign-in process with the code flow, use a web browser or web-browser
control to load this URL request.

```
GET https://login.live.com/oauth20_authorize.srf?client_id={client_id}&scope={scope}
  &response_type=code&redirect_uri={redirect_uri}
```

#### Required query string parameters
| Parameter name | Value  | Description                                                                   |
|:---------------|:-------|:------------------------------------------------------------------------------|
| *client_id*    | string | The client ID created for your app.                                           |
| *scope*        | string | A space-separated list of scopes that your app requires.                      |
| *redirect_uri* | string | The redirect URL that the browser is sent to when authentication is complete. |
| *response_type* | string | The type of response expected from the authorization flow. For this flow, the value must be **code**. |

#### Response

Upon successful authentication and authorization of your application, the web browser
will be redirected to your redirect URL with additional parameters added to the URL.

```
https://login.live.com/oauth20_authorize.srf?code=df6aa589-1080-b241-b410-c4dff65dbf7c
```

### Step 2. Redeem the code for access tokens
After you have received the `code` value, you can redeem this code for a set of
tokens that allow you to authenticate with the Groove API. To redeem the code, make the following request:

```
POST https://login.live.com/oauth20_token.srf
Content-Type: application/x-www-form-urlencoded

client_id={client_id}&redirect_uri={redirect_uri}&client_secret={client_secret}
&code={code}&grant_type=authorization_code
```

#### Required request body parameters
The request body is a properly encoded URL string, with some required parameters.

| Parameter name  | Value  | Description                                                                                                                              |
|:----------------|:-------|:-----------------------------------------------------------------------------------------------------------------------------------------|
| *client_id*     | string | The client ID value created for your application.                                                                                        |
| *redirect_uri*  | string | The redirect URL that the browser is sent to when authentication is complete. This should match the *redirect_uri* in the first request. |
| *client_secret* | string | The client secret created for your application.                                                                                          |
| *code*          | string | The authorization code you received in the first authentication request.                                                                 |

**Note**  For web apps, the domain portion of the redirect URI must match the
domain portion of the redirect URI that you specified in the
[Microsoft account Developer Center][app-portal].

#### Response
If the call is successful, the response for the POST request contains a JSON string
that includes several properties, including `access_token`, `token_type`, and
`refresh_token` (if you requested the **offline_access** scope).

```json
{
  "token_type":"bearer",
  "expires_in": 3600,
  "scope":"offline_access MicrosoftMediaServices.GrooveApiAccess",
  "access_token":"EwCo...AA==",
  "refresh_token":"eyJh...9323"
}
```

You can now store and use the `access_token` provided to make authenticated
requests to the Groove API.

**Important:** Treat the values of `access_token` and `refresh_token` in this response as securely as you would a user's password.

The access token is valid for only the number of seconds that is
specified in the **expires_in** property. You can request a new access token
by using the refresh token (if available), or by repeating the authentication
request from the beginning.

### Step 3. Get a new access token or refresh token
If your app has requested access to **offline_access** this step will
return a **refresh_token** that can be used to generate additional access
tokens after the initial token has expired.

To redeem the refresh token for a new access token, make the following request:

```http
POST https://login.live.com/oauth20_token.srf
Content-Type: application/x-www-form-urlencoded

client_id={client_id}&redirect_uri={redirect_uri}&client_secret={client_secret}
&refresh_token={refresh_token}&grant_type=refresh_token
```

#### Required request body parameters
The request body is a properly encoded URL string, with some required parameters.

| Parameter name  | Value  | Description                                                                                                                                         |
|:----------------|:-------|:----------------------------------------------------------------------------------------------------------------------------------------------------|
| *client_id*     | string | The client ID created for your application.                                                                                                         |
| *redirect_uri*  | string | The redirect URL that the browser is sent to when authentication is complete. This should match the *redirect_uri* value used in the first request. |
| *client_secret* | string | The client secret created for your application.                                                                                                     |
| *refresh_token* | string | The refresh token you received previously.                                                                                                          |

**Note**  For web apps, the domain portion of the redirect URI must match the
domain portion of the redirect URI that you specified in the
[Live SDK app management site][app-portal].

#### Response
If the call is successful, the response for the POST request contains a JSON string
that includes several properties including `access_token`, `authentication_token` and
`refresh_token` if you requested the **offline_access** scope.

```json
{
  "token_type":"bearer",
  "expires_in": 3600,
  "scope": "MicrosoftMediaServices.GrooveApiAccess offline_access",
  "access_token":"EwCo...AA==",
  "refresh_token":"eyJh...9323"
}
```

You can now store and use the `access_token` to make authenticated
requests to the Groove API.

**Important:** Treat the values of `access_token` and `refresh_token` in this
response as securely as you would a user's password.

The access token is valid for only the number of seconds that is
specified in the **expires_in** property. You can request a new access token
by using the refresh token (if available) or by repeating the authentication
request from the beginning.

## Sign the user out
To sign a user out, perform the following steps:

1. Delete any cached `access_token` or `refresh_token` values you've previously
   received from the OAuth flow.
2. Perform any sign out actions in your application (for example, cleaning up local state,
   removing any cached items, etc.).
3. Make a call to the authorization web service using this URL:

```
GET https://login.live.com/oauth20_logout.srf?client_id={client_id}&redirect_uri={redirect_uri}
```

This call will remove any cookies that enable single sign-on to occur and ensure
that next time your app launches the sign in experience, the user will be requested to
enter a username and password to continue.

### Required query string parameters

| Parameter name | Value  | Description                                                                                                                                                 |
|:---------------|:-------|:------------------------------------------------------------------------------------------------------------------------------------------------------------|
| *client_id*    | string | The client ID value created for your application.                                                                                                           |
| *redirect_uri* | string | The redirect URL that the browser is sent to when authentication is complete. This must match exactly the redirect_uri value used in the get token request. |

After removing the cookie, the browser will be redirected to the redirect URL
you provided. When the browser loads your redirect page, no authentication query
string parameters will be set, and you can infer the user has been logged out.

## Revoking Access

Users can revoke an app's access to their account by visiting the
[Microsoft account manage consent](https://account.live.com/consent/Manage) page.

When consent for your app is revoked, any refresh token previously provided to your application
will no longer be valid. You will need to repeat the authentication flow to
request a new access and refresh token from scratch.

## Errors

If there are errors with authentication, the web browser will be redirected to
an error page. While the error page always presents an end-user friendly message
the URL for the error page includes additional information that may help you
debug what happened. This information is not always shown in the content of the
error page displayed in the browser.

```
https://login.live.com/err.srf?lc=1033#error={error_code}&error_description={message}
```

The URL includes query parameters that you can use to parse the error and respond
accordingly. These parameters are always included as a bookmark (after the `#`
character). The page content will always display a generic error message for
the user.

If the user selects not to provide consent to your application, the flow will
redirect to your redirect_uri and include the same error parameters.

### Error parameters

| Parameter name      | Value  | Description                                     |
|:--------------------|:-------|:------------------------------------------------|
| *error*             | string | Error code identifying the error that occurred. |
| *error_description* | string | A description of the error.                     |

[app-portal]: http://go.microsoft.com/fwlink/p/?LinkId=193157

## Related topics

The following topics contain high-level overviews of other concepts that apply
to the Groove API.

* [Develop with the Groove API](../Groove service.md)
