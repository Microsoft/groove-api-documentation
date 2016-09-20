# GET (/1/content/{id}/{source}/{browseType}/{extra}/browse) 
Browse specific sub-items of a given ID (for example, the albums of an artist or the tracks of a playlist).

-   [Remarks](#remarks)
-   [URI parameters](#uri-parameters)
-   [Response object](#response-object)
-   [Examples](#examples)

##Remarks


A Sub-Browse API call is equivalent to a Lookup call on the parent item with one extra and will produce the same response, but the Sub-Browse API offers extra features: pagination (the Lookup API only offers continuation) and [customizing the ordering](OrderBy.md).

The Sub-Browse request is composed of mandatory and optional URL parts and query parameters, described in the table below. A Sub-Browse request containing all parameters would resemble the following:

```http  
/1/content/{id}/{source}/{browseType}/{extra}/browse?orderBy={orderBy}&maxItems={maxItems}&page={page}
&language={language}&country={country}&continuationToken={continuationToken}&accessToken={accessToken}
&contentType={contentType}&jsonp={jsonp}
```  

Please note that pagination is zero-based (the first page is found at page=0).

For parameters common to every Groove RESTful API, see [Parameters common to every Groove RESTful API](CommonParameters.md). For a table of error codes, see [Error (JSON)](JSON_Error.md). For HTTP status codes, see [Groove RESTful API HTTP Status Codes](HTTPStatusCodes.md).

##URI parameters

| **Parameter**     | **Type**              | **Description**                                                                                                                                                                                                                |
|-------------------|-----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id                | string                | Required. The identifier of the parent element whose sub-items are being browsed.                                                                                                                                              |
| source            | string                | Required. The source where the data should be looked up. Possible values are "catalog" and "collection". Collections require [user authentication](../Using the Groove RESTful Services/User Authentication.md) on top of developer authentication. |
| browseType        | string                | Required. The type of the parent element ([Album](JSON_Album.md), [Artist](JSON_Artist.md) or [Playlist](JSON_Playlist.md)).                     |
| extra             | string                | Required. The type of the requested sub-elements (for example, "Tracks" or "Albums"). See [Extras](Extras.md).                                                                                       |
| orderBy           | string                | Optional. Ordering chosen for that content ([orderBy](OrderBy.md) field). If incompatible, an HTTP 400 error will be emitted.                                                                        |
| maxItems          | 32-bit signed integer | Optional. The number of items to browse per page. The default value is 25, and it's the maximum value allowed as well.                                                                                                         |
| page              | 32-bit signed integer | Optional. The page to browse (will skip **page**\***maxItems** items). The first (and default) page is page 0.                                                                                                                 |
| continuationToken | string                | Optional. A token provided by an earlier service response and optionally returned to the service to request continuation of an incomplete list of content.                                                                     |

##Response object


[ContentResponse (JSON)](JSON_ContentResponse.md)

##Examples


###Browse Avicii's albums


This call obtains the exact same result as /1/content/music.2F531400-0200-11DB-89CA-0019B92A3933/lookup?extras=albums.

#### Request
```http
GET /1/content/music.2F531400-0200-11DB-89CA-0019B92A3933/catalog/artist/albums/browse?
accessToken=Bearer+[...]
```

#### Response
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
        "Albums": {
          "Items": [
            {
              "ReleaseDate": "2014-03-20T00:00:00Z",
              "Duration": "00:05:04",
              "TrackCount": 1,
              "IsExplicit": false,
              "LabelName": "Walt Disney Records",
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Dance"
              ],
              "AlbumType": "Single",
              "Subtitle": "(From TRON: Legacy) [Avicii \"So Amazing Mix\"] [Feat. Negin]",
              "Artists": [
                {
                  "Role": "Main",
                  "Artist": {
                    "Id": "music.2F531400-0200-11DB-89CA-0019B92A3933",
                    "Name": "Avicii",
                    "ImageUrl": "http://musicimage.xboxlive.com/content/music.2F531400-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
                    "Link": "http://music.xbox.com/Artist/2F531400-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                    "Source": "Catalog"
                  }
                }
              ],
              "Id": "music.86303B08-0100-11DB-89CA-0019B92A3933",
              "Name": "Derezzed",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.86303B08-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Album/86303B08-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            },
            {
              "ReleaseDate": "2014-03-04T00:00:00Z",
              "Duration": "00:32:13",
              "TrackCount": 6,
              "IsExplicit": false,
              "LabelName": "Island Records",
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Dance"
              ],
              "AlbumType": "Single",
              "Subtitle": "Remixes",
              "Artists": [
                {
                  "Role": "Main",
                  "Artist": {
                    "Id": "music.2F531400-0200-11DB-89CA-0019B92A3933",
                    "Name": "Avicii",
                    "ImageUrl": "http://musicimage.xboxlive.com/content/music.2F531400-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
                    "Link": "http://music.xbox.com/Artist/2F531400-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                    "Source": "Catalog"
                  }
                }
              ],
              "Id": "music.50913308-0100-11DB-89CA-0019B92A3933",
              "Name": "Addicted To You",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.50913308-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Album/50913308-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            },
            {
              [...]
            }
          ],
          "ContinuationToken": "AapohyUZCQQBCAACAQAUUy8AAtsRicoAGbkqOTMBAAIyNQ",
          "TotalItemCount": 33
        },
        "Id": "music.2F531400-0200-11DB-89CA-0019B92A3933",
        "Name": "Avicii",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.2F531400-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Artist/2F531400-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "Source": "Catalog"
      }
    ]
  }
}
``` 

### Get the first 3 tracks of the album "Discovery"


#### Request
```http
GET /1/content/music.3E362806-0100-11DB-89CA-0019B92A3933/catalog/album/tracks/browse?maxItems=3
&accessToken=Bearer+[...]
```
#### Response
```json
{
  "Albums": {
    "Items": [
      {
        "ReleaseDate": "2001-01-01T00:00:00Z",
        "Duration": "01:01:08",
        "TrackCount": 14,
        "IsExplicit": false,
        "LabelName": "Parlophone France",
        "Genres": [
          "Electronic / Dance"
        ],
        "Subgenres": [
          "Dance"
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
            }
          }
        ],
        "Tracks": {
          "Items": [
            {
              "ReleaseDate": "2001-01-01T00:00:00Z",
              "Duration": "00:05:20",
              "TrackNumber": 1,
              "IsExplicit": false,
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Dance"
              ],
              "Rights": [
                "Purchase",
                "Stream",
                "FreeStream"
              ],
              "Artists": [
                {
                  "Role": "Main",
                  "Artist": {
                    "Id": "music.C61C0000-0200-11DB-89CA-0019B92A3933",
                    "Name": "Daft Punk",
                    "ImageUrl": "http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
                    "Link": "http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                    "Source": "Catalog"
                  }
                }
              ],
              "Id": "music.F1D83106-0100-11DB-89CA-0019B92A3933",
              "Name": "One More Time",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.F1D83106-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/F1D83106-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "OtherIds": {
                "music.amg": "T  4567806"
              },
              "Source": "Catalog"
            },
            {
              "ReleaseDate": "2001-01-01T00:00:00Z",
              "Duration": "00:03:32",
              "TrackNumber": 2,
              "IsExplicit": false,
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Dance"
              ],
              "Rights": [
                "Purchase",
                "FreeStream",
                "Stream"
              ],
              "Artists": [
                {
                  "Role": "Main",
                  "Artist": {
                    "Id": "music.C61C0000-0200-11DB-89CA-0019B92A3933",
                    "Name": "Daft Punk",
                    "ImageUrl": "http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
                    "Link": "http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                    "Source": "Catalog"
                  }
                }
              ],
              "Id": "music.EC983206-0100-11DB-89CA-0019B92A3933",
              "Name": "Aerodynamic",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.EC983206-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/EC983206-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "OtherIds": {
                "music.amg": "T  4567807"
              },
              "Source": "Catalog"
            },
            {
              "ReleaseDate": "2001-01-01T00:00:00Z",
              "Duration": "00:05:01",
              "TrackNumber": 3,
              "IsExplicit": false,
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Dance"
              ],
              "Rights": [
                "Purchase",
                "Stream",
                "FreeStream"
              ],
              "Artists": [
                {
                  "Role": "Main",
                  "Artist": {
                    "Id": "music.C61C0000-0200-11DB-89CA-0019B92A3933",
                    "Name": "Daft Punk",
                    "ImageUrl": "http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
                    "Link": "http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                    "Source": "Catalog"
                  }
                }
              ],
              "Id": "music.ADBF2D06-0100-11DB-89CA-0019B92A3933",
              "Name": "Digital Love",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.ADBF2D06-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/ADBF2D06-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "OtherIds": {
                "music.amg": "T  4567808"
              },
              "Source": "Catalog"
            }
          ],
          "ContinuationToken": "AUszoQEDCQQIAAACBig2PgAB2xGJygAZuSo5MwEAATM",
          "TotalItemCount": 14
        },
        "Id": "music.3E362806-0100-11DB-89CA-0019B92A3933",
        "Name": "Discovery",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.3E362806-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Album/3E362806-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "R   522606"
        },
        "Source": "Catalog"
      }
    ]
  }
}
```

### Browse the tracks of one of my playlists


#### Request
```http
GET /1/content/music.AQPRiQGUVID-ANj02JdwYA\_R/collection/playlist/tracks/browse?
accessToken=Bearer+http%253a%252f%252fschemas.xmlsoap.org%252fws%252f2005%252f05%252fidentity
%252fclaims%252fnameidentifier%3dAwesomePartner%26http%253a%252f%252fschemas.microsoft.com
%252faccesscontrolservice%252f2010%252f07%252fclaims%252fidentityprovider%3dhttps%253a%252f
%252fdatamarket.accesscontrol.windows.net%26Audience%3dhttp%253a%252f%252fmusic.xboxlive.com
%252f%26ExpiresOn%3d1609459199%26Issuer%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net
%26HMACSHA256%3d0pVJ3%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1
Authorization: XBL3.0 x=218686063;eyJlbmMiOiJB\[...\]
```
#### Response
```json
{
  "Playlists": {
    "Items": [
      {
        "TrackCount": 2,
        "UserIsOwner": true,
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
              "Subtitle": "feat. Pharrell Williams",
              "Album": {
                "ReleaseDate": "2013-05-09T02:00:00+02:00",
                "Genres": [
                  "Pop"
                ],
                "Subtitle": "",
                "Id": "music.AQEDB7k-sQABAA",
                "Name": "Random Access Memories",
                "ImageUrl": "http://musicimage.xboxlive.com/content/music.b13eb907-0100-11db-89ca-0019b92a3933/image?locale=en-US",
                "Link": "http://music.xbox.com/Album/b13eb907-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
                "Source": "Collection"
              },
              "Artists": [
                {
                  "Role": "Main",
                  "Artist": {
                    "Id": "music.AQIDAGPdzwACAA",
                    "Name": "Daft Punk feat. Pharrell Williams and Nile Rodgers",
                    "ImageUrl": "http://musicimage.xboxlive.com/content/music.cfdd6300-0200-11db-89ca-0019b92a3933/image?locale=en-US",
                    "Link": "http://music.xbox.com/Artist/cfdd6300-0200-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
                    "Source": "Collection"
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
                  }
                }
              ],
              "Id": "music.AQQfj5Lz_MSn2025RlcuS6VkDge5PqgAAQ",
              "Name": "Get Lucky (feat. Pharrell Williams)",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.a83eb907-0100-11db-89ca-0019b92a3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/a83eb907-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
              "Source": "Collection"
            },
            {
              "ReleaseDate": "2013-09-27T02:00:00+02:00",
              "Duration": "00:04:46",
              "TrackNumber": 7,
              "IsExplicit": false,
              "Genres": [
                "Electronic / Dance"
              ],
              "Subtitle": "",
              "Album": {
                "ReleaseDate": "2013-09-27T02:00:00+02:00",
                "Genres": [
                  "Electronic / Dance"
                ],
                "Subtitle": "",
                "Id": "music.AQEDB-rrJgABAA",
                "Name": "Aleph",
                "ImageUrl": "http://musicimage.xboxlive.com/content/music.26ebea07-0100-11db-89ca-0019b92a3933/image?locale=en-US",
                "Link": "http://music.xbox.com/Album/26ebea07-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
                "Source": "Collection"
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
                  }
                }
              ],
              "Id": "music.AQQfKGA4cyOaQkWmqPAGkGeJ5wfq6y0AAQ",
              "Name": "Aleph",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.2debea07-0100-11db-89ca-0019b92a3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/2debea07-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",
              "Source": "Collection"
            }
          ],
          "TotalItemCount": 2
        },
        "Id": "music.AQPRiQGUVID-ANj02JdwYA_R",
        "Name": "Playlist1",
        "Link": "http://music.xbox.com/Playlist/940189d1-8054-00fe-d8f4-d89770600fd1?partnerID=AwesomePartner",
        "Source": "Collection"
      }
    ]
  }
}
```

###Browse Daft Punk's top tracks 5 by 5


#### Request
```http
GET /1/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/catalog/artist/toptracks/browse
?maxItems=5&accessToken=Bearer+http%253a%252f%252fschemas.xmlsoap.org%252fws%252f2005
%252f05%252fidentity%252fclaims%252fnameidentifier%3dAwesomePartner%26http%253a%252f
%252fschemas.microsoft.com%252faccesscontrolservice%252f2010%252f07%252fclaims%252fidentityprovider
%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26Audience%3dhttp%253a%252f
%252fmusic.xboxlive.com%252f%26ExpiresOn%3d1609459199%26Issuer%3dhttps%253a%252f
%252fdatamarket.accesscontrol.windows.net%26HMACSHA256%3d0pVJ3%252fUig7mgeMtlM2wI27Sm
QItFOQXTzSEbEmmDFG4%253d HTTP/1.1
```


#### Response
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
        "TopTracks": {
          "Items": [
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
            },
            {
              "ReleaseDate": "2006-03-31T00:00:00Z",
              "Duration": "00:03:44",
              "TrackNumber": 8,
              "IsExplicit": false,
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Dance"
              ],
              "Rights": [
                "Purchase",
                "Stream",
                "FreeStream"
              ],
              "Album": {
                "Id": "music.F2E82706-0100-11DB-89CA-0019B92A3933",
                "Name": "Musique",
                "ImageUrl": "http://musicimage.xboxlive.com/content/music.F2E82706-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
                "Link": "http://music.xbox.com/Album/F2E82706-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                "Source": "Catalog"
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
                  }
                }
              ],
              "Id": "music.5BAF3206-0100-11DB-89CA-0019B92A3933",
              "Name": "Harder, Better, Faster, Stronger",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.5BAF3206-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/5BAF3206-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            },
            {
              [...]
            }
          ],
          "ContinuationToken": "AWWwZHYFCQQCAQACAQAAHMYAAtsRicoAGbkqOTMBAAE1",
          "TotalItemCount": 194
        },
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

#### Continuation Request
```http
GET /1/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/catalog/artist/toptracks/browse
?maxItems=5&page=1&accessToken=Bearer+[...]
```

#### Continuation Response
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
        "TopTracks": {
          "Items": [
            {
              "ReleaseDate": "2013-05-09T00:00:00Z",
              "Duration": "00:05:37",
              "TrackNumber": 5,
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
              "Subtitle": "feat. Julian Casablancas",
              "Album": {
                "Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",
                "Name": "Random Access Memories",
                "ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
                "Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                "Source": "Catalog"
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
                  }
                }
              ],
              "Id": "music.A63EB907-0100-11DB-89CA-0019B92A3933",
              "Name": "Instant Crush",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.A63EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/A63EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "OtherIds": {
                "music.amg": "T 29380859"
              },
              "Source": "Catalog"
            },
            {
              "ReleaseDate": "2013-05-09T00:00:00Z",
              "Duration": "00:05:21",
              "TrackNumber": 2,
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
              "Album": {
                "Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",
                "Name": "Random Access Memories",
                "ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
                "Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                "Source": "Catalog"
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
                  }
                }
              ],
              "Id": "music.AB3EB907-0100-11DB-89CA-0019B92A3933",
              "Name": "The Game of Love",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.AB3EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/AB3EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            },
            {
              "ReleaseDate": "2013-05-09T00:00:00Z",
              "Duration": "00:09:04",
              "TrackNumber": 3,
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
              "Album": {
                "Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",
                "Name": "Random Access Memories",
                "ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
                "Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                "Source": "Catalog"
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
                  }
                }
              ],
              "Id": "music.A93EB907-0100-11DB-89CA-0019B92A3933",
              "Name": "Giorgio by Moroder",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.A93EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/A93EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "OtherIds": {
                "music.amg": "T 29380861"
              },
              "Source": "Catalog"
            },
            {
              "ReleaseDate": "2001-01-01T00:00:00Z",
              "Duration": "00:05:20",
              "TrackNumber": 1,
              "IsExplicit": false,
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Dance"
              ],
              "Rights": [
                "Purchase",
                "Stream",
                "FreeStream"
              ],
              "Album": {
                "Id": "music.3E362806-0100-11DB-89CA-0019B92A3933",
                "Name": "Discovery",
                "ImageUrl": "http://musicimage.xboxlive.com/content/music.3E362806-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
                "Link": "http://music.xbox.com/Album/3E362806-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                "Source": "Catalog"
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
                  }
                }
              ],
              "Id": "music.F1D83106-0100-11DB-89CA-0019B92A3933",
              "Name": "One More Time",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.F1D83106-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/F1D83106-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "OtherIds": {
                "music.amg": "T  4567806"
              },
              "Source": "Catalog"
            },
            {
              "ReleaseDate": "2013-05-09T00:00:00Z",
              "Duration": "00:04:11",
              "TrackNumber": 12,
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
              "Subtitle": "feat. Panda Bear",
              "Album": {
                "Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",
                "Name": "Random Access Memories",
                "ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
                "Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                "Source": "Catalog"
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
                  }
                }
              ],
              "Id": "music.AF3EB907-0100-11DB-89CA-0019B92A3933",
              "Name": "Doin' it Right",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.AF3EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/AF3EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "OtherIds": {
                "music.amg": "T 29380852"
              },
              "Source": "Catalog"
            }
          ],
          "ContinuationToken": "AWWwZHYFCQQCAQACAAAcxgAC2xGJygAZuSo5MwEAAjEw",
          "TotalItemCount": 193
        },
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

###See also


#### Parent

