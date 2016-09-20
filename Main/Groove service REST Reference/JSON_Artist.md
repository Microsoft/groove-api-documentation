# Artist (JSON)              



The creator or creators of a musical recording. 

##Artist


The Artist object has the following specification.

| **Member**        | **Type**                                                 | **Description**                                                                                                                                                                                                                                                                                                                                            |
|-------------------|----------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Id                | String                                                   | Identifier for this piece of content. All IDs are of the form {namespace}.{actual identifier} and may be used in any API accepting an ID as input.                                                                                                                                                                                                         |
| Name              | String                                                   | The name of this piece of content.                                                                                                                                                                                                                                                                                                                         |
| ImageUrl          | String                                                   | A direct link to the default image associated with this piece of content. See [Image Service](../Using the Groove RESTful Services/Image Service.md) for more information on how these links may be customized to produce different images.                                                                                                                                |
| Link              | String                                                   | A music.xbox.com link that redirects to a contextual page for this piece of content on the relevant Groove client application depending on the user's device or operating system. See [Deep Link](../Using the Groove RESTful Services/Deep Link.md) for more informatoin on how these links work and how they should be modified for revenue sharing.                 |
| OtherIds          | Dictionary&lt;*string*,*string*&gt;                      | An optional collection of other IDs that identify this piece of content on top of the main ID. Each key is the namespace or subnamespace in which the ID belongs, and each value is a secondary ID for this piece of content.                                                                                                                              |
| Source            | string                                                   | An indication of the data source for this piece of content. Possible values are **Collection** and **Catalog**.                                                                                                                                                                                                                                            |
| CompatibleSources | string                                                   | An indication of the categories of APIs and actions that this piece of content can be used with. Comma-separated list of one or multiple values among "Catalog", "Collection". Most items are compatible with both Catalog and Collection actions, but playlists for example or some collection items are not valid in a Catalog context.                  |
| Genres            | List of String                                           | A list of musical genres associated with the artist.                                                                                                                                                                                                                                                                                                       |
| Subgenres         | List of String                                           | A list of musical sub-genres associated with the artist.                                                                                                                                                                                                                                                                                                   |
| Albums            | List of [Album](JSON_Album.md) | An optional paginated list of the artist's albums, ordered by decreasing order of release date (latest first). This list is null by default unless requested as extra information in a lookup request. Albums in this list contain only a few fields, including the ID that should be used in a lookup request in order to have the full album properties. |
| TopTracks         | List of [Track](JSON_Track.md) | A paginated list of the artist's top tracks, ordered by decreasing order of popularity. This list is null by default unless requested as extra information in a lookup request. Tracks in this list contain only a few fields, including the ID that should be used in a lookup request in order to have the full track properties.                        |
| Biography         | string                                                   | The artist's biography, if available.                                                                                                                                                                                                                                                                                                                      |

##Sample JSON syntax
```json  
{
  "Biography": "Daft Punk is a French house music group consisting [...]",
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
  "Compatible Sources": "Catalog, Collection"
} 
``` 
##See also


#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)
