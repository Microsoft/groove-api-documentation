# Track (JSON)              
Describes a *track*, an individual piece of musical content from an album.

This topic describes *track*, an individual piece of musical content from an album.

-   [Specification of **Track**](#specification-of-track)
-   [Sample JSON syntax](#sample-json-syntax)

##Specification of Track


The **Track** object has the following specification.

| **Member**            | **Type**                                                             | **Description**                                                                                                                                                                                                                                                                                                                                |
|-----------------------|----------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Id**                | String                                                               | Identifier for this piece of content. All IDs are of the form {namespace}.{actual identifier} and may be used in any API accepting an ID as input.                                                                                                                                                                                             |
| **Name**              | String                                                               | The name of this piece of content.                                                                                                                                                                                                                                                                                                             |
| **ImageUrl**          | String                                                               | A direct link to the default image associated with this piece of content. For more information about how these links may be customized to produce different images, see [Image Service](../Using the Groove RESTful Services/Image Service.md).                                                                                                                |
| **Link**              | String                                                               | A music.xbox.com link that redirects to a contextual page for this piece of content on the relevant Groove client application depending on the user's device or operating system. For more informatoin about how these links work and how they should be modified for revenue sharing, see [Deep Link](../Using the Groove RESTful Services/Deep Link.md).. |
| **OtherIds**          | Dictionary&lt;*string*,*string*&gt;                                  | An optional collection of other IDs that identify this piece of content on top of the main ID. Each key is the namespace or subnamespace in which the ID belongs, and each value is a secondary ID for this piece of content.                                                                                                                  |
| **Source**            | string                                                               | An indication of the data source for this piece of content. Possible values are **Collection** and **Catalog**.                                                                                                                                                                                                                                |
| **CompatibleSources** | string                                                               | An indication of the categories of APIs and actions that this piece of content can be used with. Comma-separated list of one or multiple values among "Catalog", "Collection". Most items are compatible with both Catalog and Collection actions, but playlists for example or some collection items are not valid in a Catalog context.      |
| **ReleaseDate**       | DateTime                                                             | Nullable. The track release date.                                                                                                                                                                                                                                                                                                              |
| **Duration**          | TimeSpan                                                             | Nullable. The track duration.                                                                                                                                                                                                                                                                                                                  |
| **TrackNumber**       | Integer                                                              | Nullable. The position of the track in the album.                                                                                                                                                                                                                                                                                              |
| **IsExplicit**        | Boolean                                                              | Nullable. True if the track contains explicit content.                                                                                                                                                                                                                                                                                         |
| **Genres**            | List of String                                                       | The list of musical genres associated with this track.                                                                                                                                                                                                                                                                                         |
| **Subgenres**         | List of String                                                       | The list of musical sub-genres associated with this track.                                                                                                                                                                                                                                                                                     |
| **Rights**            | List of String                                                       | The list of distribution rights associated with this track in Groove (for example, Stream, Purchase, and so on).                                                                                                                                                                                                                               |
| **Subtitle**          | string                                                               | The track's subtitle.                                                                                                                                                                                                                                                                                                                          |
| **Album**             | Album                                                                | The album this track belongs to. Only a few fields are populated in this Album element, including the ID that should be used in a lookup request in order to have the full album properties.                                                                                                                                                   |
| **Artists**           | List of [Contributor](JSON_Contributor.md) | The list of contributors (artists and their roles) to the album.                                                                                                                                                                                                                                                                               |

##Sample JSON syntax

```json
{
  "ReleaseDate": "2013-05-09T00:00:00Z",
  "Duration": "00:06:09",
  "TrackNumber": 8,
  "IsExplicit": false,
  "Genres": [
    "Pop"
  ],
  "Subgenres": [
    "Contemporary Pop"
  ],
  "Rights": [
    "Purchase",
    "Stream",
    "FreeStream"
  ],
  "Subtitle": "feat. Pharrell Williams",
  "Album": {
    "Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",
    "Name": "Random Access Memories",
    "ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
    "Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
    "Source": "Catalog"
    "CompatibleSources": "Catalog, Collection"
  },
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
  "Id": "music.A83EB907-0100-11DB-89CA-0019B92A3933",
  "Name": "Get Lucky",
  "ImageUrl": "http://musicimage.xboxlive.com/content/music.A83EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
  "Link": "http://music.xbox.com/Track/A83EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
  "OtherIds": {
    "music.amg": "T 29381286"
  },
  "Source": "Catalog"
  "CompatibleSources": "Catalog, Collection"
}
```
##See Also


#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)
