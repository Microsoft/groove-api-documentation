# Contributor (JSON)        
An artist and the artist's role.

## Contributor
The Contributor object has the following specification.

| **Member** | **Type**                                           | **Description**                                         |
|------------|----------------------------------------------------|---------------------------------------------------------|
| Artist     | [Artist](JSON-Artist.md) | The contributing artist.                                |
| Role       | string                                             | The type of contribution, such as "Main" or "Featured". |

## Sample JSON syntax
```json
{
  "Role": "Main",
  "Artist": {
    "Id": "music.C61C0000-0200-11DB-89CA-0019B92A3933",
    "Name": "Daft Punk",
    "ImageUrl": "https://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
    "Link": "https://music.microsoft.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
    "Source": "Catalog",
    "CompatibleSources": "Catalog, Collection"
  }
}
```

#### Parent
[Groove Service REST Reference](overview.md)