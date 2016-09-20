# GET (/1/content/{id}/stream)
Request streaming.

-   [Remarks](#remarks)
-   [Query string parameters](#query-string-parameters)
-   [Response object](#response-object)
-   [Examples](#examples)

##Remarks


| Important                                                                        |
|------------------------------------------------------------------------------------------|
| [User authentication](../Using the Groove RESTful Services/User Authentication.md) is mandatory for this API. |

The full streaming request is composed of mandatory and optional URL parts and query parameters. A streaming request containing all parameters would resemble the following string:

```
/1/content/{id}/stream?clientInstanceId={clientInstanceId} &contentType={contentType}&accessToken={accessToken}
```

For parameters common to every Groove RESTful API, see [Parameters common to every Groove RESTful API](CommonParameters.md). For a table of error codes, see [Error (JSON)](JSON_Error.md). For HTTP status codes, see [Groove RESTful API HTTP Status Codes](HTTPStatusCodes.md).

Please make sure your usage of the streaming API follows the [guidelines](../Using the Groove RESTful Services/Guidelines.md).

For playing streams from your application on windows versions prior to Windows 10, you can use the [Microsoft HLS SDK](http://github.com/MicrosoftDX/MicrosoftHLSSDK).

##Query string parameters


| **Parameter**    | **Type** | **Description**                                                                                             |
|------------------|----------|-------------------------------------------------------------------------------------------------------------|
| clientInstanceId | string   | Required. Unique client identifier. Should be persisted client-side. Can be from 32 to 128 characters long. |

##Response object


[StreamResponse (JSON)](JSON_StreamResponse.md)

##Examples


###Unauthorized stream

Only Groove Pass subscribers may play full streams.

#### Request
```http
GET /1/content/music.A83EB907-0100-11DB-89CA-0019B92A3933/stream
?clientInstanceId=5b559245-96ed-4cf2-a4de-e0a13d66609c&accessToken=Bearer
+[...]

Authorization: XBL3.0 x=218686063;eyJlbmMiOiJB[...]
```
#### Response
```json
403 Forbidden 

{
  "Error": {
    "ErrorCode": "NO_MUSIC_PASS_SUBSCRIPTION",
    "Description": "The user does not have an Groove subscription"
  }
}
```

###Authorized stream


The user authentication token identifies a user who has a Music Pass.

#### Request
```http
GET /1/content/music.A83EB907-0100-11DB-89CA-0019B92A3933/stream?clientInstanceId=
5b559245-96ed-4cf2-a4de-e0a13d66609c&accessToken=Bearer+[...]

Authorization: XBL3.0 x=218686063;eyJlbmMiOiJB[...]
```
#### Response
```json
{
  "Url": "https://webstream-vh.akamaihd.net/i/129/580/712/155/audio.mp4/master.m3u8?
rid=40117aff-3edc-432a-a81d-1967a61e826d_i2_fr-FR_music_asset_location&hdnea=exp=1398443951~
acl=/i/129/580/712/155/audio.mp4*~hmac=22d99f90d60f28e9c12e618027dc611f973c9ba614ad04c7210570d807e6398c",
  "ContentType": "application/vnd.apple.mpegurl",
  "ExpiresOn": "2014-04-25T16:39:11.132Z"
}
```
##See also


#### Parent
