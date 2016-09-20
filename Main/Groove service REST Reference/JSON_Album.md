#Album(JSON)
A musical recording

##Album


The Album object has the following specification.

| **Member**        | **Type**                                                             | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
|-------------------|----------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Id                | String                                                               | Identifier for this piece of content. All IDs are of the form {namespace}.{actual identifier} and may be used in any API accepting an ID as input.                                                                                                                                                                                                                                                                                                                   |
| Name              | String                                                               | The name of this piece of content.                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| ImageUrl          | String                                                               | A direct link to the default image associated with this piece of content. See [Image Service](../Using the Groove RESTful Services/Image Service.md) for more information on how these links may be customized to produce different images.                                                                                                                                                                                                                                          |
| Link              | String                                                               | A music.xbox.com link that redirects to a contextual page for this piece of content on the relevant Groove client application depending on the user's device or operating system. See [Deep Link](../Using the Groove RESTful Services/Deep Link.md) for more information on how these links work and how they should be modified for revenue sharing.                                                                                                                           |
| OtherIds          | Dictionary&lt;*string*,*string*&gt;                                  | An optional collection of other IDs that identify this piece of content on top of the main ID. Each key is the namespace or subnamespace in which the ID belongs, and each value is a secondary ID for this piece of content.                                                                                                                                                                                                                                        |
| Source            | string                                                               | An indication of the data source for this piece of content. Possible values are **Collection** and **Catalog**.                                                                                                                                                                                                                                                                                                                                                      |
| CompatibleSources | string                                                               | An indication of the categories of APIs and actions that this piece of content can be used with. Comma-separated list of one or multiple values among "Catalog", "Collection". Most items are compatible with both Catalog and Collection actions, but playlists for example or some collection items are not valid in a Catalog context.                                                                                                                            |
| ReleaseDate       | DateTime                                                             | Nullable. The album release date.                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| Duration          | TimeSpan                                                             | Nullable. The album total duration.                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| TrackCount        | Integer.                                                             | Nullable. The number of tracks on the album.                                                                                                                                                                                                                                                                                                                                                                                                                         |
| IsExplicit        | Boolean                                                              | Nullable. True if the album contains explicit content.                                                                                                                                                                                                                                                                                                                                                                                                               |
| LabelName         | String                                                               | The name of the music label that produced this album.                                                                                                                                                                                                                                                                                                                                                                                                                |
| Genres            | List of String                                                       | The list of musical genres associated with this album.                                                                                                                                                                                                                                                                                                                                                                                                               |
| Subgenres         | List of String                                                       | The list of musical sub-genres associated with this album.                                                                                                                                                                                                                                                                                                                                                                                                           |
| AlbumType         | String                                                               | The type of album (for example, Album, Single, and so on).                                                                                                                                                                                                                                                                                                                                                                                                           |
| Subtitle          | String                                                               | The album subtitle.                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| Artists           | List of [Contributor](JSON_Contributor.md) | The list of contributors (artists and their roles) to the album.                                                                                                                                                                                                                                                                                                                                                                                                     |
| Tracks            | List of [Track](JSON_Track.md)             | A paginated list of the album's tracks. This list is null by default unless requested as extra information in a lookup request. If not null, it should most often be full without the need to use a continuation token; only a few cases of albums containing a very large number of tracks will use pagination. Tracks in this list contain only a few fields, including the ID that should be used in a lookup request in order to have the full track properties. |

##Sample JSON syntax


```json  
{
  "ReleaseDate": "2013-05-09T00:00:00Z",
  "Duration": "01:14:24",
  "TrackCount": 13,
  "IsExplicit": false,
  "LabelName": "Columbia",
  "Genres": [
    "Pop"
  ],
  "Subgenres": [
    "Contemporary Pop"
  ],
  "AlbumType": "Album",
  "Artists": [
    {
      "Role": "Main",
      "Artist": {
        "Id": "music.C61C0000-0200-11DB-89CA-0019B92A3933",
        "Name": "Daft Punk",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "Source": "Catalog"
        "CompatibleSources": "Catalog, Collection"
      }
    }
  ],
  "Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",
  "Name": "Random Access Memories",
  "ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
  "Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
  "OtherIds": {
    "music.amg": "R  2749955"
  },
  "Source": "Catalog"
  "CompatibleSources": "Catalog, Collection"
} 
```  

##See also


#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)
