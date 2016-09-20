# ContentItem (JSON)         


An item of content (either an [**Album**](JSON_Album.md) or an [**Artist**](JSON_Artist.md)).

##ContentItem


The ContentItem object has the following specification.

| **Member** | **Type**                                           | **Description**                                        |
|------------|----------------------------------------------------|--------------------------------------------------------|
| Type       | ItemType                                           | The type of the content element wrapped in this item.  |
| Album      | [Album](JSON_Album.md)   | Album item if **Type** is **Albums**, null otherwise   |
| Artist     | [Artist](JSON_Artist.md) | Artist item if **Type** is **Artists**, null otherwise |

##Sample JSON syntax

```json 
{
  "Type": "Artists",
  "Artist": {
    "Genres": [
      "Pop"
    ],
    "Subgenres": [
      "Dance Pop"
    ],
    "Id": "music.26BA0500-0200-11DB-89CA-0019B92A3933",
    "Name": "Miley Cyrus",
    "ImageUrl": "http://musicimage.xboxlive.com/content/music.26BA0500-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
    "Link": "http://music.xbox.com/Artist/26BA0500-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
    "OtherIds": {
      "music.amg": "P   823418"
    },
    "Source": "Catalog"
  }
}
``` 
##See also


#### Parent  

[Groove Service REST Reference](Groove Service REST Reference.md)
