# PaginatedList (JSON)       

Describes paginated lists, a type of response from the Groove Service that can be continued by using a token.

Some of the methods in the Groove RESTful API return lists of elements in their responses (for example, search results, albums of an artist, tracks of an album, and so on). These lists can potentially be very large, so we have put in place a mechanism to paginate these lists by using a *continuation token*. These lists and tokens are returned in a **PaginatedList** object.

This topic describes the **PaginatedList** object and provides examples of its use in the following sections:

-   [PaginatedList](#paginatedlist)
-   [Sample JSON syntax](#sample-json-syntax)
-   [Search and continue (artists)](#search-and-continue-artists)
-   [Artists continuation](#artists-continuation)
-   [Continuation response (artists only)](#continuation-response-artists-only)

##PaginatedList

All the paginated lists in responses from the Groove Service use the same data structure, a **PaginatedList** object, which is described in the following table.

| **Member**            | **Type** | **Description**                                                                                                                                                                                                                                                                                                                 |
|-----------------------|----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Items**             | list     | The items composing the paginated list. When a list is of relatively small size, **Items** will contain the full list and **ContinuationToken** will be null. However, the list may be incomplete, which is indicated by the value of **ContinuationToken**.                                                                    |
| **ContinuationToken** | string   | An opaque string that may be provided in a subsequent request to the same URL in order to continue the list. If **ContinuationToken** is not null, then the list is not complete, and the token may be used to retrieve the remaining elements. A null value indicates that the list has no remaining items yet to be returned. |
| **TotalItemCount**    | integer  | An estimated count of the total number of items available in the list.                                                                                                                                                                                                                                                          |

A continuation token is an opaque string that should never be modified by the client, only passed as-is in subsequent requests. To obtain the continuation of a particular paginated list, the client should call the exact same URL as in the original request whose response produced the continuation token, except that it should add that continuation token in the optional **continuationToken** query parameter that those APIs support and remove all the other optional API parameters. The response from that call respects the same data structure as the original response, but most of the fields are null to avoid repeating the same information. Only the few fields critical for identification of the item (such as ID) are populated, as is the paginated list that the continuation token applies to. This paginated list contains the elements that immediately follow the ones from the original request. This second paginated list may also itself be incomplete and come with its own continuation token, so the same concept can be applied to more than two pages.

## Sample JSON syntax

-   [Lookup with tracks on an album that has more than 25 tracks](#lookup-with-tracks-on-an-album-that-has-more-than-25-tracks)

-   [Continuation request (same URL, "extras" optional parameter removed, "continuationToken" from initial track list passed instead)](#continuation-request-same-url-extras-optional-parameter-removed-continuationtoken-from-initial-track-list-passed-instead)

-   [Continuation response (contains the rest of the tracks)](#continuation-response-contains-the-rest-of-the-tracks)

### Lookup with tracks on an album that has more than 25 tracks


##### First Request
```http
GET /1/content/music.833FB507-0100-11DB-89CA-0019B92A3933/lookup?
extras=Tracks&accessToken=Bearer+[...]
``` 
#### First response
```json
{
  "Albums": {
    "Items": [
      {
        "ReleaseDate": "2013-04-30T00:00:00Z",
        "Duration": "01:25:22",
        "TrackCount": 32,
        "IsExplicit": true,
        "LabelName": "La Cile",
        "Genres": [
          "Electronic / Dance"
        ],
        "Subgenres": [
          "Breakbeat / Electro"
        ],
        "AlbumType": "Album",
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.5EB90600-0200-11DB-89CA-0019B92A3933",
              "Name": "Sexy Sushi",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.5EB90600-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Artist/5EB90600-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Tracks": {
          "Items": [
            {
              "ReleaseDate": "2013-04-30T00:00:00Z",
              "Duration": "00:00:05",
              "TrackNumber": 1,
              "IsExplicit": true,
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Breakbeat / Electro"
              ],
              "Rights": [
                "Purchase",
                "Stream",
                "FreeStream"
              ],
              "Subtitle": "Fraulein Warrior Version",
              "Artists": [
                {
                  "Role": "Main",
                  "Artist": {
                    "Id": "music.5EB90600-0200-11DB-89CA-0019B92A3933",
                    "Name": "Sexy Sushi",
                    "ImageUrl": "http://musicimage.xboxlive.com/content/music.5EB90600-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
                    "Link": "http://music.xbox.com/Artist/5EB90600-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                    "Source": "Catalog"
                  }
                }
              ],
              "Id": "music.843FB507-0100-11DB-89CA-0019B92A3933",
              "Name": "Le prenom",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.843FB507-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/843FB507-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            },
            {
              "ReleaseDate": "2013-04-30T00:00:00Z",
              "Duration": "00:03:28",
              "TrackNumber": 2,
              "IsExplicit": true,
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Breakbeat / Electro"
              ],
              "Rights": [
                "Purchase",
                "Stream",
                "FreeStream"
              ],
              "Subtitle": "Fraulein Warrior Version",
              "Artists": [
                {
                  "Role": "Main",
                  "Artist": {
                    "Id": "music.5EB90600-0200-11DB-89CA-0019B92A3933",
                    "Name": "Sexy Sushi",
                    "ImageUrl": "http://musicimage.xboxlive.com/content/music.5EB90600-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
                    "Link": "http://music.xbox.com/Artist/5EB90600-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                    "Source": "Catalog"
                  }
                }
              ],
              "Id": "music.853FB507-0100-11DB-89CA-0019B92A3933",
              "Name": "Mendiante (Version longue)",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.853FB507-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/853FB507-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            },
            {
              [...]
            }
          ],
          "ContinuationToken": "AXHsdfMACQQIAAcCAQe1P4MAAdsRicoAGbkqOTMBAAIyNQ",
          "TotalItemCount": 32
        },
        "Id": "music.833FB507-0100-11DB-89CA-0019B92A3933",
        "Name": "Vous n'allez pas repartir les mains vides?",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.833FB507-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Album/833FB507-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "Source": "Catalog"
      }
    ]
  }
} 
```
### Continuation request (same URL, "extras" optional parameter removed, "continuationToken" from initial track list passed instead)

```html
GET /1/content/music.833FB507-0100-11DB-89CA-0019B92A3933/lookup?

continuationToken=AXHsdfMACQQIAAcCB7U_gwAB2xGJygAZuSo5MwEAAjI1

&accessToken=Bearer+../Using the Groove RESTful Services
``` 
###Continuation response (contains the rest of the tracks)

```json
{
  "Albums": {
    "Items": [
      {
        "ReleaseDate": "2013-04-30T00:00:00Z",
        "Duration": "01:25:22",
        "TrackCount": 32,
        "IsExplicit": true,
        "LabelName": "La Cile",
        "Genres": [
          "Electronic / Dance"
        ],
        "Subgenres": [
          "Breakbeat / Electro"
        ],
        "AlbumType": "Album",
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.5EB90600-0200-11DB-89CA-0019B92A3933",
              "Name": "Sexy Sushi",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.5EB90600-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Artist/5EB90600-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Tracks": {
          "Items": [
            {
              "ReleaseDate": "2013-04-30T00:00:00Z",
              "Duration": "00:02:46",
              "TrackNumber": 26,
              "IsExplicit": true,
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Breakbeat / Electro"
              ],
              "Rights": [
                "Purchase",
                "Stream",
                "FreeStream"
              ],
              "Subtitle": "Herr Silver Version",
              "Artists": [
                {
                  "Role": "Main",
                  "Artist": {
                    "Id": "music.5EB90600-0200-11DB-89CA-0019B92A3933",
                    "Name": "Sexy Sushi",
                    "ImageUrl": "http://musicimage.xboxlive.com/content/music.5EB90600-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
                    "Link": "http://music.xbox.com/Artist/5EB90600-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                    "Source": "Catalog"
                  }
                }
              ],
              "Id": "music.9D3FB507-0100-11DB-89CA-0019B92A3933",
              "Name": "Les pommes (Ms Mix)",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.9D3FB507-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/9D3FB507-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            },
            {
              "ReleaseDate": "2013-04-30T00:00:00Z",
              "Duration": "00:00:34",
              "TrackNumber": 27,
              "IsExplicit": true,
              "Genres": [
                "Electronic / Dance"
              ],
              "Subgenres": [
                "Breakbeat / Electro"
              ],
              "Rights": [
                "Purchase",
                "Stream",
                "FreeStream"
              ],
              "Subtitle": "Herr Silver Version",
              "Artists": [
                {
                  "Role": "Main",
                  "Artist": {
                    "Id": "music.5EB90600-0200-11DB-89CA-0019B92A3933",
                    "Name": "Sexy Sushi",
                    "ImageUrl": "http://musicimage.xboxlive.com/content/music.5EB90600-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
                    "Link": "http://music.xbox.com/Artist/5EB90600-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
                    "Source": "Catalog"
                  }
                }
              ],
              "Id": "music.9E3FB507-0100-11DB-89CA-0019B92A3933",
              "Name": "XXX03XXX",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.9E3FB507-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Track/9E3FB507-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            },
            {
              [...]
            }
          ],
          "TotalItemCount": 32
        },
        "Id": "music.833FB507-0100-11DB-89CA-0019B92A3933",
        "Name": "Vous n'allez pas repartir les mains vides?",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.833FB507-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Album/833FB507-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "Source": "Catalog"
      }
    ]
  }
}
``` 
##Search and continue (artists)


### Initial search request

```html
GET /1/content/music/search?q=bob&accessToken=Bearer+[...]
```
### First response

```json
{
  "Artists": {
    "Items": [
      {
        "Genres": [
          "Hip Hop"
        ],
        "Subgenres": [
          "Contemporary Hip Hop"
        ],
        "Id": "music.8E2C0300-0200-11DB-89CA-0019B92A3933",
        "Name": "B.o.B",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.8E2C0300-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Artist/8E2C0300-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "P   926413"
        },
        "Source": "Catalog"
      },
      {
        "Genres": [
          "Rock"
        ],
        "Subgenres": [
          "Indie / Alternative"
        ],
        "Id": "music.AC660A00-0200-11DB-89CA-0019B92A3933",
        "Name": "Bob",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.AC660A00-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Artist/AC660A00-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "P   586594"
        },
        "Source": "Catalog"
      },
      {
        [...]
      }
    ],
    "ContinuationToken": "AYdrKUUZCQRAAAcAA2JvYgEAAjI1",
    "TotalItemCount": 504
  },
  "Albums": {
    "Items": [
      {
        "ReleaseDate": "2010-04-14T00:00:00Z",
        "Duration": "00:48:02",
        "TrackCount": 12,
        "IsExplicit": true,
        "LabelName": "Rebel Rock/Grand Hustle/Atlantic",
        "Genres": [
          "Hip Hop"
        ],
        "Subgenres": [
          "Contemporary Hip Hop"
        ],
        "AlbumType": "Album",
        "Subtitle": "Parental Advisory",
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.8E2C0300-0200-11DB-89CA-0019B92A3933",
              "Name": "B.o.B",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.8E2C0300-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Artist/8E2C0300-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Id": "music.7BE31706-0100-11DB-89CA-0019B92A3933",
        "Name": "B.o.B Presents: The Adventures of Bobby Ray",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.7BE31706-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Album/7BE31706-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "R  1766891"
        },
        "Source": "Catalog"
      },
      {
        "ReleaseDate": "2013-11-22T00:00:00Z",
        "Duration": "00:57:30",
        "TrackCount": 15,
        "IsExplicit": true,
        "LabelName": "Rebel Rock/Grand Hustle/Atlantic",
        "Genres": [
          "Hip Hop"
        ],
        "Subgenres": [
          "Contemporary Hip Hop"
        ],
        "AlbumType": "Album",
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.8E2C0300-0200-11DB-89CA-0019B92A3933",
              "Name": "B.o.B",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.8E2C0300-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Artist/8E2C0300-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Id": "music.D491FF07-0100-11DB-89CA-0019B92A3933",
        "Name": "Underground Luxury",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.D491FF07-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Album/D491FF07-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "R  2857962"
        },
        "Source": "Catalog"
      },
      {
        [...]
      }
    ],
    "ContinuationToken": "AYdrKUUZCQQBAAcAA2JvYgEAAjI1",
    "TotalItemCount": 513
  },
  "Tracks": {
    "Items": [
      {
        "ReleaseDate": "1999-11-01T00:00:00Z",
        "Duration": "00:05:04",
        "TrackNumber": 11,
        "IsExplicit": true,
        "Genres": [
          "Hip Hop"
        ],
        "Subgenres": [
          "Contemporary Hip Hop"
        ],
        "Rights": [
          "Purchase",
          "Stream",
          "FreeStream"
        ],
        "Album": {
          "Id": "music.C1BE0400-0100-11DB-89CA-0019B92A3933",
          "Name": "Stankonia",
          "ImageUrl": "http://musicimage.xboxlive.com/content/music.C1BE0400-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
          "Link": "http://music.xbox.com/Album/C1BE0400-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
          "Source": "Catalog"
        },
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.DF620000-0200-11DB-89CA-0019B92A3933",
              "Name": "OutKast",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.DF620000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Artist/DF620000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Id": "music.D7BE0400-0100-11DB-89CA-0019B92A3933",
        "Name": "B.O.B.",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.D7BE0400-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Track/D7BE0400-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "T  4227380"
        },
        "Source": "Catalog"
      },
      {
        "ReleaseDate": "2010-04-14T00:00:00Z",
        "Duration": "00:03:00",
        "TrackNumber": 4,
        "IsExplicit": true,
        "Genres": [
          "Hip Hop"
        ],
        "Subgenres": [
          "Contemporary Hip Hop"
        ],
        "Rights": [
          "Purchase",
          "Stream",
          "FreeStream"
        ],
        "Subtitle": "feat. Hayley Williams of Paramore",
        "Album": {
          "Id": "music.7BE31706-0100-11DB-89CA-0019B92A3933",
          "Name": "B.o.B Presents: The Adventures of Bobby Ray",
          "ImageUrl": "http://musicimage.xboxlive.com/content/music.7BE31706-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
          "Link": "http://music.xbox.com/Album/7BE31706-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
          "Source": "Catalog"
        },
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.8E2C0300-0200-11DB-89CA-0019B92A3933",
              "Name": "B.o.B",
              "ImageUrl": "http://musicimage.xboxlive.com/content/music.8E2C0300-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "http://music.xbox.com/Artist/8E2C0300-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Id": "music.C2E11706-0100-11DB-89CA-0019B92A3933",
        "Name": "Airplanes",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.C2E11706-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Track/C2E11706-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "T 19335955"
        },
        "Source": "Catalog"
      },
      {
        [...]
      }
    ],
    "ContinuationToken": "AYdrKUUZCQQIAAcAA2JvYgEAAjI1",
    "TotalItemCount": 515
  }
}
```
## Artists continuation

```http
GET /1/content/music/search?continuationToken=AYdrKUUZQAAHAANib2IBAAIyNQ
&accessToken=Bearer+[...]
```
## Continuation response (artists only)
```json  

{
  "Artists": {
    "Items": [
      {
        "Genres": [
          "Country"
        ],
        "Subgenres": [
          "Traditional Country"
        ],
        "Id": "music.A8CE1000-0200-11DB-89CA-0019B92A3933",
        "Name": "Bob DiPiero",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.A8CE1000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Artist/A8CE1000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "P    70787"
        },
        "Source": "Catalog"
      },
      {
        "Genres": [
          "Jazz"
        ],
        "Subgenres": [
          "Smooth Jazz"
        ],
        "Id": "music.DE0E0000-0200-11DB-89CA-0019B92A3933",
        "Name": "Bob James",
        "ImageUrl": "http://musicimage.xboxlive.com/content/music.DE0E0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "http://music.xbox.com/Artist/DE0E0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "P     6800"
        },
        "Source": "Catalog"
      },
      {
        [...]
      }
    ],
    "ContinuationToken": "AYdrKUUZCQRAAAcAA2JvYgEAAjUw",
    "TotalItemCount": 504
  }
}
``` 
##See also


#### Parent

[Groove Service REST Reference](Groove Service REST Reference.md)
