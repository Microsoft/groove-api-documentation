# PlaylistActionResult (JSON) 

The object describing a playlist action result, used by add and delete. 

##PlaylistActionResult


The PlaylistActionResult object has the following specification.

| **Member**   | **Type**                                                                         | **Description**                                        |
|--------------|----------------------------------------------------------------------------------|--------------------------------------------------------|
| Id           | string                                                                           | Required. ID of the playlist.                          |
| Name         | string                                                                           | *Optional*. Name of the playlist.                        |
| IsReadOnly   | Boolean value                                                                    | *Optional*. Whether the playlist can be modified or not. |
| IsPublished  | Boolean value                                                                    | *Optional*. Whether the playlist is public or not.       |
| TrackActions | List of [TrackActionResult](JSON_TrackActionResult.md) | *Optional*. Details on the results of track actions.     |

##Sample JSON syntax
```json
{
  "Id": "music.playlist.56c99764-800a-00fe-552f-ee11db9370d1",
  "TrackActionResults": [
    {
      "InputId": "music.AQQfj2DtARB5ZkGFCMHea2k8Xge5PqgAAQ"
    },
    {
      "InputId": "music.2DEBEA07-0100-11DB-89CA-0019B92A3933",
      "Id": "music.AQQfJsmw6ICU5kmUw5dPSMsTLwfq6y0AAQ"
    }
  ]
}
```
##See also

#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)
