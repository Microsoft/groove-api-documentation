# Playlist (JSON)           

A list of tracks and their metadata. 

##Playlist

The Playlist object has the following specification.

| **Member**           | **Type**                                                                                                              | **Description**                                                                                                                                                                                                                                                                                                                                                             |
|----------------------|-----------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Id                   | string                                                                                                                | Identifier for this piece of content. All Ids are of the form {namespace}.{actual identifier} and may be used in any API accepting an ID as input.                                                                                                                                                                                                                          |
| Name                 | string                                                                                                                | The name of this piece of content.                                                                                                                                                                                                                                                                                                                                          |
| ImageUrl             | string                                                                                                                | A direct link to the default image associated with this piece of content. See [Image Service](../Using the Groove RESTful Services/Image Service.md) for details about how these links may be customized to produce different images.                                                                                                                                                       |
| Link                 | string                                                                                                                | An HTTP link that redirects to a contextual page for this piece of content on the relevant Groove client application, depending on the user's device or operating system. See [DeepLink](../Using%20the%20Groove%20RESTful%20Services/Deep%20Link.md) for details about how these links work and how they should be modified for [revenue-sharing](http://www.microsoftaffiliates.com/). |
| OtherIds             | Dictionary&lt;*string*,*string*&gt;                                                                                   | An optional collection of IDs on top of the main ID, which identify this piece of content. Each key is the namespace or sub-namespace in which the ID belongs, and each value is a secondary ID for this piece of content                                                                                                                                                   |
| Source               | string                                                                                                                | An indication of the data source for this piece of content. Possible values are **Collection** and **Catalog**.                                                                                                                                                                                                                                                             |
| CompatibleSources    | string                                                                                                                | An indication of the categories of APIs and actions that this piece of content can be used with. Comma-separated list of one or multiple values among "Catalog", "Collection". Most items are compatible with both Catalog and Collection actions, but playlists for example or some collection items are not valid in a Catalog context.                                   |
| TrackCount           | 32-bit signed integer                                                                                                 | Number of tracks currently in the playlist.                                                                                                                                                                                                                                                                                                                                 |
| Description          | string                                                                                                                | A short description of the playlist.                                                                                                                                                                                                                                                                                                                                        |
| Owner                | string                                                                                                                | Gamertag of the owner of the playlist.                                                                                                                                                                                                                                                                                                                                      |
| IsReadOnly           | Boolean value                                                                                                         | Whether the playlist can be edited or not.                                                                                                                                                                                                                                                                                                                                  |
| IsPublished          | Boolean value                                                                                                         | Whether the playlist is publicly visible or not.                                                                                                                                                                                                                                                                                                                            |
| UserIsOwner          | Boolean value                                                                                                         | Whether the current user is the actual owner of the playlist.                                                                                                                                                                                                                                                                                                               |
| CollectionStateToken | string                                                                                                                | Token indicating the current version of the collection.                                                                                                                                                                                                                                                                                                                     |
| Tracks               | [Paginated list](JSON_PaginatedList.md) of [Track](JSON_Track.md) | A paginated list of the tracks in the playlist. In case of a browse, this list is null, and you'll need a lookup on that playlist to get its tracks.                                                                                                                                                                                                                        |

##Sample JSON syntax

```json
{
  "TrackCount": 2,
  "UserIsOwner": true,
  "CollectionStateToken": "3.0.1.1.7.7.7",
  "Tracks": {
    "Items": [
      {
        "ReleaseDate": "2013-05-09T02:00:00+02:00",
        "Duration": "00:06:07",
        "TrackNumber": 8,
        "IsExplicit": false,
        "Genres": [
          "Pop"
        ],
        "Rights": [
          "Purchase",
          "FreeStream"
        ],
        "Album": {
          "ReleaseDate": "2013-05-09T02:00:00+02:00",
          "Genres": [
            "Pop"
          ],
          "Id": "music.AQEDB7k-sQABAA",
          "Name": "Random Access Memories",
          "ImageUrl": "http://musicimage.xboxlive.com/content/music.b13eb907-0100-11db-89ca-0019b92a3933/image?locale=en-US",
          "Link": "http://music.xbox.com/Album/b13eb907-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
          "Source": "Collection"
          "CompatibleSources": "Catalog, Collection"
        },
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.AQIDAAAcxgACAA",
              "Name": "Daft Punk",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.c61c0000-0200-11db-89ca-0019b92a3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Artist/c61c0000-0200-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
              "Source": "Collection"
              "CompatibleSources": "Catalog, Collection"
            }
          },
          {
            "Role": "AlbumArtist",
            "Artist": {
              "Id": "music.AQIDAAAcxgACAA",
              "Name": "Daft Punk",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.c61c0000-0200-11db-89ca-0019b92a3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Artist/c61c0000-0200-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
              "Source": "Collection"
              "CompatibleSources": "Catalog, Collection"
            }
          }
        ],
        "Id": "music.AQQfN4uJ9UrnJkGWQ1G9KcPOkwe5PqgAAQ",
        "Name": "Get Lucky (feat. Pharrell Williams)",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.a83eb907-0100-11db-89ca-0019b92a3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Track/a83eb907-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
        "Source": "Collection"
        "CompatibleSources": "Catalog, Collection"
      },
      {
        "ReleaseDate": "2013-09-27T02:00:00+02:00",
        "Duration": "00:04:46",
        "TrackNumber": 7,
        "IsExplicit": false,
        "Genres": [
          "Electronic / Dance"
        ],
        "Album": {
          "ReleaseDate": "2013-09-27T02:00:00+02:00",
          "Genres": [
            "Electronic / Dance"
          ],
          "Id": "music.AQEDB-rrJgABAA",
          "Name": "Aleph",
          "ImageUrl": "http://musicimage.xboxlive.com/content/music.26ebea07-0100-11db-89ca-0019b92a3933/image?locale=en-US",
          "Link": "http://music.xbox.com/Album/26ebea07-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
          "Source": "Collection"
          "CompatibleSources": "Catalog, Collection"
        },
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.AQIDAAdbyQACAA",
              "Name": "Gesaffelstein",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.c95b0700-0200-11db-89ca-0019b92a3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Artist/c95b0700-0200-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
              "Source": "Collection"
              "CompatibleSources": "Catalog, Collection"
            }
          },
          {
            "Role": "AlbumArtist",
            "Artist": {
              "Id": "music.AQIDAAdbyQACAA",
              "Name": "Gesaffelstein",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.c95b0700-0200-11db-89ca-0019b92a3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Artist/c95b0700-0200-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
              "Source": "Collection"
              "CompatibleSources": "Catalog, Collection"
            }
          }
        ],
        "Id": "music.AQQfObc7JPSYfEi_EiGVYbdyHAfq6y0AAQ",
        "Name": "Aleph",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.2debea07-0100-11db-89ca-0019b92a3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Track/2debea07-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
        "Source": "Collection"
        "CompatibleSources": "Catalog, Collection"
      }
    ],
    "TotalItemCount": 2
  },
  "Id": "music.playlist.56c99764-800a-00fe-552f-ee11db9370d1",
  "Name": "Playlist1",
  "ImageUrl": "http://musicimage.xboxlive.com/content/music.playlist.56c99764-800a-00fe-552f-ee11db9370d1/image?locale=en-US",
  "Link": "http://music.xbox.com/Playlist/56c99764-800a-00fe-552f-ee11db9370d1?partnerID=AwesomePartner",
  "Source": "Collection"
  "Compatible Sources": "Catalog, Collection"
}
```
##See also


#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)
