# PlaylistActionResponse (JSON) 

The output element for every playlist action request: create, update, and delete.

Contains an optional Error field if the operation or some sub-operations failed, and an object describing which sub-operations failed and which succeeded.

##PlaylistActionResponse

The PlaylistActionResponse object has the following specification.

| **Member**           | **Type**                                                                       | **Description**                                                 |
|----------------------|--------------------------------------------------------------------------------|-----------------------------------------------------------------|
| Error                | [Error](JSON_Error.md)                               | Optional. Error if the operation or some sub-operations failed. |
| PlaylistActionResult | [PlaylistActionResult](JSON_PlaylistActionResult.md) | Details on the playlist action.                                 |

##Sample JSON syntax
```json
{
  "PlaylistActionResult": {
    "Id": "music.playlist.56c99764-800a-00fe-552f-ee11db9370d1",
    "TrackActionResults": [
      {
        "InputId": "music.AQQfj2DtARB5ZkGFCMHea2k8Xge5PqgAAQ"
      },
      {
        "InputId": "music.2DEBEA07-0100-11DB-89CA-0019B92A3933",
        "Id": "music.AQQfDfTrflAB2k60n3MOVkAyXQfq6y0AAQ"
      }
    ]
  }
}
```
##See also


#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)

#### Reference

[/1/content/{namespace}/collection/playlists/create](URI_ContentNamespaceCollectionPlaylistsCreatePOST.md)  
[/1/content/{namespace}/collection/playlists/delete](URI_ContentNamespaceCollectionPlaylistsDeletePOST.md)  
[/1/content/{namespace}/collection/playlists/update](URI_ContentNamespaceCollectionPlaylistsUpdatePOST.md)
