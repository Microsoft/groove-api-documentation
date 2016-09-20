# TrackActionRequest (JSON)  

The input element for every track action request: add and delete. 

##TrackActionRequest

The TrackActionRequest object has the following specification.

| **Member** | **Type**       | **Description**                                                                                                                                                                                                                                                       |
|------------|----------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| TrackIds   | List of string | List of track IDs to add to the user's collection. These IDs can be found through [/1/content/{id}/lookup](URI_ContentLookupGET.md) or [/1/content/{namespace}/search?q={query}](URI_ContentSearchGET.md), for example. |

##Sample JSON syntax
```json
{
  "TrackIds": [
    "music.873FB507-0100-11DB-89CA-0019B92A3933",
    "music.A83EB907-0100-11DB-89CA-0019B92A3933"
  ]
}
```
##See also


#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)
