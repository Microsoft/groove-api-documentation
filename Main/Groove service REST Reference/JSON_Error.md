# Error (JSON)               

The error structure is the same across all APIs. Noteworthy elements are as follows.

##Error


The Error object has the following specification.

| **Member**  | **Type** | **Description**                                                     |
|-------------|----------|---------------------------------------------------------------------|
| ErrorCode   | String   | The error code, as described in the following table of error codes. |
| Description | String   | A user-friendly description of the error code.                      |
| Message     | String   | A more contextual message describing what may have gone wrong.      |

These error structures can be optionally embedded in any Groove Platform service response. If an error is reported, the Error.ErrorCode and Error.Description elements will always be provided.

##Error codes

 Error code table                                
                                                  
| **Name**                                         | **Default HTTP code**     | **Description**                                                                |
|-------------------------------------------------|---------------------------|--------------------------------------------------------------------------------|
| CATALOG\_UNAVAILABLE                            | 502 Bad Gateway           | No response from catalog.                                                      |
| CATALOG\_NO\_RESULT                             | 404 Not Found             | Item does not exist.                                                           |
| CATALOG\_INVALID\_DATA                          |                           | Error while reading catalog data; some results may be missing.                 |
| COLLECTION\_CONCURRENT\_UPDATE                  | 409 Conflict              | Concurrent update of the collection.                                           |
| COLLECTION\_NO\_RESULT                          | 404 NotFound              | No result from Collection                                                      |
| COLLECTION\_INVALID\_RESPONSE                   | 502 BadGateway            | Invalid response from Cloud Collection                                         |
| COLLECTION\_INVALID\_DATA                       | 200 OK                    | Error while reading collection data, some results may be missing or incomplete |
| COLLECTION\_INVALID\_PLAYLIST\_REORDER          | 400 Bad Request           | Invalid playlist reorder operation                                             |
| COLLECTION\_FULL                                | 400 BadRequest            | Your collection is full                                                        |
| COLLECTION\_PLAYLIST\_FULL                      | 400 BadRequest            | This playlist is full                                                          |
| COLLECTION\_INVALID\_OPERATION                  | 400 BadRequest            | This operation is not supported                                                |
| COLLECTION\_INVALID\_ID                         | 400 BadRequest            | Invalid collection id for this operation                                       |
| COLLECTION\_INVALID\_PLAYLIST\_INFO             | 400 BadRequest            | Required playlist information is missing                                       |
| COLLECTION\_OPERATION\_UNKNOWN\_ERROR           | 502 BadGateway            | The operation failed                                                           |
| COLLECTION\_SOME\_OPERATIONS\_FAILED            | 200 OK                    | Some of the operations failed                                                  |
| DELIVERY\_3RD\_PARTY\_CANNOT\_STREAM\_PURCHASES | 403 Forbidden             | Purchases are not available for streaming through the Groove Developer APIs.   |
| DISCOVERY\_NO\_RESULT                           | 404 NotFound              | No result from Discovery                                                       |
| DISCOVERY\_INVALID\_GENRE                       | 404 NotFound              | No result from Discovery, you might want to check if genre is well formatted   |
| DISCOVERY\_INVALID\_RESPONSE                    | 502 BadGateway            | Invalid response from Discovery                                                |
| DISCOVERY\_INVALID\_DATA                        | 200 OK                    | Error while reading discovery data, some results may be missing or incomplete  |
| DELIVERY\_INVALID\_RESPONSE                     | 502 BadGateway            | Invalid response from the Music Delivery Service                               |
| DELIVERY\_UNAVAILABLE\_CONTENT                  | 404 NotFound              | Content is not available for streaming                                         |
| DELIVERY\_CONCURRENT\_STREAMING                 | 409 Conflict              | The user is already streaming on another device                                |
| DELIVERY\_ERROR                                 | 404 NotFound              | Unknown delivery error                                                         |
| ACCESS\_TOKEN\_MISSING                          | 401 Unauthorized          | Azure Marketplace access token required.                                       |
| ACCESS\_TOKEN\_INVALID                          | 401 Unauthorized          | Invalid Azure Marketplace token.                                               |
| ACCESS\_TOKEN\_EXPIRED                          | 401 Unauthorized          | Expired Azure Marketplace token.                                               |
| ACCESS\_TOKEN\_VALIDATION\_ERROR                | 500 Internal Server Error | Unexpected error while validating Azure Marketplace token.                     |
| ACCESS\_TOKEN\_INVALID\_SUBSCRIPTION            | 401 Unauthorized          | Azure Marketplace client ID is not a subscriber to the Groove data offer.      |
| ACCESS\_TOKEN\_SUBSCRIPTION\_VALIDATION\_ERROR  | 500 Internal Server Error | Unexpected error while validating Azure Marketplace subscription status.       |
| CONTINUATION\_TOKEN\_INVALID\_ERROR             | 400 Bad Request           | The continuation token provided is incorrect.                                  |
| INVALID\_AUTHORIZATION\_HEADER                  | 401 Unauthorized          | Missing or invalid authorization header                                        |
| NO\_MUSIC\_PASS\_SUBSCRIPTION                   | 403 Forbidden             | The user does not have an Groove subscription                                  |
| MISSING\_INPUT\_PARAMETER                       | 400 Bad Request           | Missing or empty mandatory parameter.                                          |
| INVALID\_INPUT\_PARAMETER                       | 400 Bad Request           | Invalid parameter value.                                                       |
| INCOMPATIBLE\_INPUT\_PARAMETERS                 | 400 Bad Request           | Incompatible parameters.                                                       |
| UNAUTHORIZED\_INPUT\_PARAMETER                  | 200 OK                    | Unauthorized input parameter                                                   |
| UNAUTHORIZED\_API\_METHOD                       | 403 Forbidden             | Unauthorized API method                                                        |
| INVALID\_COUNTRY                                | 400 BadRequest            | The requested functionality is not available in this region                    |
| INTERNAL\_SERVER\_ERROR                         | 500 Internal Server Error | Oops, something went seriously wrong.                                          |
| TOO\_MANY\_REQUESTS                             | 429 TooManyRequests       | Too Many Requests                                                              |

##Sample JSON syntax
```json
{
   "ErrorCode": "CATALOG_NO_RESULT",
   "Description": "Item does not exist"
}
```
##See also


#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)
