#TrackActionResponse (JSON) 


The output element for every track action request: add and delete. <span id="ID4EN" class="anchor"></span>

##TrackActionResponse


The TrackActionResponse object has the following specification.

| **Member**         | **Type**                                                                         | **Description**                                                                                                                                                       |
|--------------------|----------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Error              | [Error](JSON_Error.md)                                 | *Optional.* Error object. If some of the operations failed, this object will not be null, but the result might be HTTP 200 if the operation succeeded only partially.   |
| TrackActionResults | List of [TrackActionResult](JSON_TrackActionResult.md) | Required. List of action results, with an optional Error field if the action failed, and two IDs to match the request input to the generated ID (if one is returned). |

##Sample JSON syntax
```json
{
  "TrackActionResults": [
    {
      "InputId": "music.873FB507-0100-11DB-89CA-0019B92A3933",
      "Id": "music.AQQfLejCjRp0CUSXL6Ksx2WU6Ae1P4cAAQ"
    },
    {
      "InputId": "music.A83EB907-0100-11DB-89CA-0019B92A3933",
      "Id": "music.AQQfnOQ4L9wx0ESVhqqExHAdSge5PqgAAQ"
    }
  ]
}
```
##See also


#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)
