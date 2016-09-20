# ContentResponse (JSON)   

##ContentResponse


The ContentResponse object has the following specification.

| **Member** | **Type**                                                             | **Description**                                                                                                                                                                                                                                                                                                             |
|------------|----------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Error      | [Error](JSON_Error.md)                     | Optional error.                                                                                                                                                                                                                                                                                                             |
| Artists    | List of [Artist](JSON_Artist.md)           | A paginated list of Artists that matched the request criteria.                                                                                                                                                                                                                                                              |
| Albums     | List of [Album](JSON_Album.md)             | A paginated list of Albums that matched the request criteria.                                                                                                                                                                                                                                                               |
| Tracks     | List of [Track](JSON_Track.md)             | A paginated list of Tracks that matched the request criteria.                                                                                                                                                                                                                                                               |
| Playlists  | List of [Playlist](JSON_Playlist.md)       | A paginated list of Playlists that matched the request criteria.                                                                                                                                                                                                                                                            |
| Results    | List of [ContentItem](JSON_ContentItem.md) | A paginated list of ContentItems that matched the request criteria. These items are used for ordered lists mixing multiple types of content such as the [Spotlight](URI_ContentNamespaceSpotlightGET.md) and [NewReleases](URI_ContentNamespaceNewreleasesGET.md) APIs. |
| Genres     | GenreList                                                            | A list of string representing the different possible genres for a given locale. Used in the [Browse Genres](URI_ContentNamespaceCatalogGenresGET.md) API.                                                                                                                                         |
| Culture    | string                                                               | The culture used for processing the [Browse Genres](URI_ContentNamespaceCatalogGenresGET.md) request, computed from Country and Language parameters, user authentication and/or geolocation.                                                                                                      |

##Sample JSON syntax

```json
{
  "Artists": {
    "Items": [
      {
        "Genres": [
          "Electronic / Dance"
        ],
        "Subgenres": [
          "Dance"
        ],
        "Id": "music.C61C0000-0200-11DB-89CA-0019B92A3933",
        "Name": "Daft Punk",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "P   168791"
        },
        "Source": "Catalog"
      }
    ]
  }
}
```
##See also


#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)
