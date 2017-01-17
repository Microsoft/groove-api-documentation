---
title: Browse the Groove Music catalog| Groove Services
description:  Learn how to browse the Groove Music catalog with our API.
keywords: groove music, groove api, groove catalog browse
author: sakley
ms.assetid: 
---

# GET (/1/content/{namespace}/catalog/{type}/browse)
Browse the music catalog.

-   [Remarks](#remarks)
-   [Response object](#response-object)
-   [Query string parameters](#query-string-parameters)
-   [Examples](#examples)

## Remarks
The Browse Catalog request is composed of mandatory and optional URL parts and query parameters. A request containing all parameters would resemble the following string:

```
/1/content/{namespace}/catalog/{type}/browse?orderBy={orderBy}&genre={genre}&mood={mood}&activity={activity}&maxItems={maxItems}&page={page}
&continuationToken={continuationToken}&country={country}&language={language}&contentType={contentType}&jsonp={jsonp}
```

| Note                                                                                                                     |
|------------------------------------------------------------------------------------------------------------------------------|
| Pagination is zero-based (the first page is found at page 0), and catalog browse will not return more than 1000 total items. |
| You cannot combine the following filters together in the same request: <b>genre, mood, activity</b>.

For parameters common to every Groove RESTful API, see [Parameters common to every Groove RESTful API](common-parameters.md). For a table of error codes, see [Error (JSON)](JSON-Error.md). For HTTP status codes, see [Groove RESTful API HTTP Status Codes](http-status-codes.md).

## Response object
[ContentResponse (JSON)](JSON-ContentResponse.md)

## Query string parameters
The following parameters are not available on the Common Parameters page.

| **Parameter**     | **Type**              | **Description**                                                                                                                                                                                                                                                 |
|-------------------|-----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| namespace         | string                | The [namespace](Namespace.md) to browse.                                                                                                                                                                                              |
| type              | string                | Required. The type of item to browse. The following values are supported: "albums", "artists", "tracks".                                                                                                                                                        |
| orderBy           | string                | *Optional*. Ordering chosen for that content (**orderBy** field). If incompatible, an HTTP 400 error will be emitted.                                                                                                                                             |
| genre             | string                | *Optional*. Genre name; filters browsing to return only items in a specific genre of content. Possible values can be obtained using the [browse genres API](uri-get-genres.md), and must be properly URL-encoded. |
| mood              | string                | *Optional*. Mood name; filters  browsing to return only playlists in a specific mood category. Possible values can be obtained using the [browse moods API](uri-get-moods.md), and must be properly URL-encoded. |
| activity          | string                | *Optional*. Activity name; filters  browsing to return only playlists in a specific activity category. Possible values can be obtained using the [browse activities API](uri-get-activities.md), and must be properly URL-encoded. |
| maxItems          | 32-bit signed integer | *Optional*. The number of items to browse per page. The default value is 25, and it's the maximum value allowed as well.                                                                                                                                          |
| page              | 32-bit signed integer | *Optional*. The page to browse (will skip **page**\***maxItems** items). The first (and default) page is page 0.                                                                                                                                                  |
| continuationToken | string                | A [continuation token](JSON-PaginatedList.md) provided in an earlier service response and optionally passed back to the service to request the continuation of an incomplete list of content.                                         |
| extra             | string                | Required. The type of the requested sub-elements (for example, "Tracks" or "Albums"). See [Extras](Extras.md).                                                                                                                        |

## Examples
### Browse the most popular catalog artists in your region
#### Request
```http
GET /1/content/music/catalog/artists/browse?orderBy=MostPopular

Authorization: Bearer [...]
```      

#### Response
```json
{
  "Artists": {
    "Items": [
      {
        "Genres": [
          "R&B / Soul"
        ],
        "Subgenres": [
          "R&B"
        ],
        "Id": "music.E6950200-0200-11DB-89CA-0019B92A3933",
        "Name": "Trey Songz",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.E6950200-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "https://music.microsoft.com/Artist/E6950200-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "P   686292"
        },
        "Source": "Catalog"
      },
      {
        "Genres": [
          "Hip Hop"
        ],
        "Subgenres": [
          "Contemporary Hip Hop"
        ],
        "Id": "music.1F154700-0200-11DB-89CA-0019B92A3933",
        "Name": "Iggy Azalea",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.1F154700-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "https://music.microsoft.com/Artist/1F154700-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "OtherIds": {
          "music.amg": "P  2703496"
        },
        "Source": "Catalog"
      },
      {
        [...]
      }
    ],
    "ContinuationToken": "AZYULjMZCQQADwcDAQACMjU",
    "TotalItemCount": 200
  }
}
```

### Browse the playlists in the "Sleepy" mood category
#### Request
```http
GET /1/content/music/Catalog/Playlists/browse?country=US&language=en&mood=Sleepy

Authorization: Bearer [...]
```      

#### Response
```json
{
  "Playlists": {
    "Items": [
      {
        "Description": "Quiet indie for soothing purposes",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.b1d950d1-a733-00fe-fc93-3c51f3c78fd3",
        "Name": "The Wind Down",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.b1d950d1-a733-00fe-fc93-3c51f3c78fd3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/the-wind-down/b1d950d1-a733-00fe-fc93-3c51f3c78fd3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "Calming sounds to keep you centered",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.8421336c-2d1c-00fe-cfb1-56000bac67d3",
        "Name": "Meditation Music",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.8421336c-2d1c-00fe-cfb1-56000bac67d3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/meditation-music/8421336c-2d1c-00fe-cfb1-56000bac67d3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "Music to relax the body and mind",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.7ee9bf15-ce68-00fe-2f42-2a0650b32ed4",
        "Name": "Meditation Music 2",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.7ee9bf15-ce68-00fe-2f42-2a0650b32ed4/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/meditation-music-2/7ee9bf15-ce68-00fe-2f42-2a0650b32ed4?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "New chill tracks with calming effects",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.066a9dfe-8916-00fe-a91f-a6f10c2e75d3",
        "Name": "Upbeat Downtempo",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.066a9dfe-8916-00fe-a91f-a6f10c2e75d3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/upbeat-downtempo/066a9dfe-8916-00fe-a91f-a6f10c2e75d3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "Keep calm and chill with r&b/soul",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.2e7e51d9-9e60-00fe-35c1-c4b8c6a467d3",
        "Name": "Soul Cool Down",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.2e7e51d9-9e60-00fe-35c1-c4b8c6a467d3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/soul-cool-down/2e7e51d9-9e60-00fe-35c1-c4b8c6a467d3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "Rootsy sounds to start or end your day",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.e1a3fa77-3884-00fe-c1b7-b1ffca265cd3",
        "Name": "Quiet Campfire",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.e1a3fa77-3884-00fe-c1b7-b1ffca265cd3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/quiet-campfire/e1a3fa77-3884-00fe-c1b7-b1ffca265cd3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "Songs to stay in bed for",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.2ad2857e-808f-00fe-11bb-be6d38a972d3",
        "Name": "Snooze Alarm",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.2ad2857e-808f-00fe-11bb-be6d38a972d3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/snooze-alarm/2ad2857e-808f-00fe-11bb-be6d38a972d3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "Drift off to downtempo Electronica",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.a7d039e1-9ee4-00fe-fc2a-08b62daa67d3",
        "Name": "Sleepy Time Chill",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.a7d039e1-9ee4-00fe-fc2a-08b62daa67d3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/sleepy-time-chill/a7d039e1-9ee4-00fe-fc2a-08b62daa67d3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "Fall asleep sophisticated",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.ba003590-863c-00fe-4548-9efb7aaf7dd3",
        "Name": "Sleepy Time Classical",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.ba003590-863c-00fe-4548-9efb7aaf7dd3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/sleepy-time-classical/ba003590-863c-00fe-4548-9efb7aaf7dd3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "Smooth Jazz to fall asleep to",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.bb413c91-dbd3-00fe-30d9-f0729fe975d3",
        "Name": "Sleepy Time Jazz",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.bb413c91-dbd3-00fe-30d9-f0729fe975d3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/sleepy-time-jazz/bb413c91-dbd3-00fe-30d9-f0729fe975d3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "Time to tune out that chatty neighbor and snooze",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.fffead3a-8284-00fe-5051-a351b6e9f2d3",
        "Name": "Time To Recline",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.fffead3a-8284-00fe-5051-a351b6e9f2d3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/time-to-recline/fffead3a-8284-00fe-5051-a351b6e9f2d3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "More songs to fall asleep to",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.59d0459c-51e6-00fe-2158-1e554fb17dd3",
        "Name": "Sleepy Time Chill 2",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.59d0459c-51e6-00fe-2158-1e554fb17dd3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/sleepy-time-chill-2/59d0459c-51e6-00fe-2158-1e554fb17dd3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "More Smooth Jazz to fall asleep to",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.9651acf6-9f73-00fe-448c-dc6d03eb75d3",
        "Name": "Sleepy Time Jazz 2",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.9651acf6-9f73-00fe-448c-dc6d03eb75d3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/sleepy-time-jazz-2/9651acf6-9f73-00fe-448c-dc6d03eb75d3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      },
      {
        "Description": "Put baby to sleep with these interpretations of popular hits",
        "IsReadOnly": true,
        "IsPublished": true,
        "Provider": "Groove Editors",
        "Id": "music.playlist.4c5223a0-836f-00fe-4a93-e0a8e7cf6ed3",
        "Name": "Rockabye Baby Style",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.playlist.4c5223a0-836f-00fe-4a93-e0a8e7cf6ed3/image?locale=en-US",
        "Link": "https://music.microsoft.com/playlist/rockabye-baby-style/4c5223a0-836f-00fe-4a93-e0a8e7cf6ed3?partnerID=AppId:00000000401C1787",
        "Source": "Catalog",
        "CompatibleSources": "Catalog"
      }
    ],
    "TotalItemCount": 14
  },
  "Culture": "en-US"
}
```

### Browse the 5 most played albums in your region
#### Request
```http
GET /1/content/music/catalog/albums/browse?orderBy=AllTimePlayCount&maxItems=5

Authorization: Bearer [...]
```

#### Response
```json
{
  "Albums": {
    "Items": [
      {
        "ReleaseDate": "2014-06-19T00:00:00Z",
        "Duration": "01:13:20",
        "TrackCount": 17,
        "IsExplicit": true,
        "LabelName": "Atlantic Records",
        "Genres": [
          "R&B / Soul"
        ],
        "Subgenres": [
          "R&B"
        ],
        "AlbumType": "Album",
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.E6950200-0200-11DB-89CA-0019B92A3933",
              "Name": "Trey Songz",
              "ImageUrl": "https://musicimage.xboxlive.com/content/music.E6950200-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "https://music.microsoft.com/Artist/E6950200-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Id": "music.73CC6408-0100-11DB-89CA-0019B92A3933",
        "Name": "Trigga (Deluxe)",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.73CC6408-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "https://music.microsoft.com/Album/73CC6408-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "Source": "Catalog"
      },
      {
        "ReleaseDate": "2014-04-09T00:00:00Z",
        "Duration": "00:51:19",
        "TrackCount": 15,
        "IsExplicit": true,
        "LabelName": "Island Records",
        "Genres": [
          "Hip Hop"
        ],
        "Subgenres": [
          "Contemporary Hip Hop"
        ],
        "AlbumType": "Album",
        "Subtitle": "Deluxe Version",
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.1F154700-0200-11DB-89CA-0019B92A3933",
              "Name": "Iggy Azalea",
              "ImageUrl": "https://musicimage.xboxlive.com/content/music.1F154700-0200-11DB-89CA-0019B92A3933/image?locale=en-US",
              "Link": "https://music.microsoft.com/Artist/1F154700-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Id": "music.5C314608-0100-11DB-89CA-0019B92A3933",
        "Name": "The New Classic",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.5C314608-0100-11DB-89CA-0019B92A3933/image?locale=en-US",
        "Link": "https://music.microsoft.com/Album/5C314608-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "Source": "Catalog"
      },
      {
        [...]
      }
    ],
    "ContinuationToken": "AUDg68QFCQQAAQcDAQABNQ",
    "TotalItemCount": 200
  }
}
```

### Browse the 50 most played tracks in France
#### Request
```http
GET /1/content/music/catalog/tracks/browse?orderBy=AllTimePlayCount&country=FR

Authorization: Bearer [...]
```

#### Response
```json
{
  "Tracks": {
    "Items": [
      {
        "ReleaseDate": "2014-03-25T00:00:00Z",
        "Duration": "00:04:12",
        "TrackNumber": 19,
        "IsExplicit": false,
        "Genres": [
          "Hip Hop / Rap"
        ],
        "Subgenres": [
          "Hip Hop US & Intl."
        ],
        "Rights": [
          "Purchase",
          "Stream",
          "FreeStream"
        ],
        "Album": {
          "Id": "music.9D9D3D08-0100-11DB-89CA-0019B92A3933",
          "Name": "Les yeux plus gros que le monde",
          "ImageUrl": "https://musicimage.xboxlive.com/content/music.9D9D3D08-0100-11DB-89CA-0019B92A3933/image?locale=fr-FR",
          "Link": "https://music.microsoft.com/Album/9D9D3D08-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
          "Source": "Catalog"
        },
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.359D2700-0200-11DB-89CA-0019B92A3933",
              "Name": "Black M",
              "ImageUrl": "https://musicimage.xboxlive.com/content/music.359D2700-0200-11DB-89CA-0019B92A3933/image?locale=fr-FR",
              "Link": "https://music.microsoft.com/Artist/359D2700-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Id": "music.B09D3D08-0100-11DB-89CA-0019B92A3933",
        "Name": "Sur ma route",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.B09D3D08-0100-11DB-89CA-0019B92A3933/image?locale=fr-FR",
        "Link": "https://music.microsoft.com/Track/B09D3D08-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "Source": "Catalog"
      },
      {
        "ReleaseDate": "2014-01-22T00:00:00Z",
        "Duration": "00:03:33",
        "TrackNumber": 1,
        "IsExplicit": false,
        "Genres": [
          "Chanson Fran�aise"
        ],
        "Subgenres": [
          "Pop Fran�aise"
        ],
        "Rights": [
          "Purchase",
          "Stream",
          "FreeStream"
        ],
        "Album": {
          "Id": "music.97A21B08-0100-11DB-89CA-0019B92A3933",
          "Name": "Mini World",
          "ImageUrl": "https://musicimage.xboxlive.com/content/music.97A21B08-0100-11DB-89CA-0019B92A3933/image?locale=fr-FR",
          "Link": "https://music.microsoft.com/Album/97A21B08-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
          "Source": "Catalog"
        },
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.F3FC2A00-0200-11DB-89CA-0019B92A3933",
              "Name": "Indila",
              "ImageUrl": "https://musicimage.xboxlive.com/content/music.F3FC2A00-0200-11DB-89CA-0019B92A3933/image?locale=fr-FR",
              "Link": "https://music.microsoft.com/Artist/F3FC2A00-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Id": "music.98A21B08-0100-11DB-89CA-0019B92A3933",
        "Name": "Derni�re Danse",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.98A21B08-0100-11DB-89CA-0019B92A3933/image?locale=fr-FR",
        "Link": "https://music.microsoft.com/Track/98A21B08-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "Source": "Catalog"
      },
      {
        [...]
      }
    ],
    "ContinuationToken": "AShFeFoZDAQAAQcDAQACMjU",
    "TotalItemCount": 1000
  }
}
```

#### Continuation Request (using "page=1", but it could also have used the ContinuationToken from the first response instead)
```http
GET /1/content/music/catalog/tracks/browse?orderBy=AllTimePlayCount&country=FR&page=1

Authorization: Bearer [...]
```

#### Response
```json
{
  "Tracks": {
    "Items": [
      {
        "ReleaseDate": "2014-06-10T00:00:00Z",
        "Duration": "00:04:45",
        "TrackNumber": 23,
        "IsExplicit": false,
        "Genres": [
          "Alternative"
        ],
        "Subgenres": [
          "Pop Alternative"
        ],
        "Rights": [
          "Purchase",
          "Stream",
          "FreeStream"
        ],
        "Album": {
          "Id": "music.FE5A6008-0100-11DB-89CA-0019B92A3933",
          "Name": "NRJ Summer Hits Only 2014",
          "ImageUrl": "https://musicimage.xboxlive.com/content/music.FE5A6008-0100-11DB-89CA-0019B92A3933/image?locale=fr-FR",
          "Link": "https://music.microsoft.com/Album/FE5A6008-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
          "Source": "Catalog"
        },
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.0A190000-0200-11DB-89CA-0019B92A3933",
              "Name": "Coldplay",
              "ImageUrl": "https://musicimage.xboxlive.com/content/music.0A190000-0200-11DB-89CA-0019B92A3933/image?locale=fr-FR",
              "Link": "https://music.microsoft.com/Artist/0A190000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Id": "music.1A5B6008-0100-11DB-89CA-0019B92A3933",
        "Name": "Magic",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.1A5B6008-0100-11DB-89CA-0019B92A3933/image?locale=fr-FR",
        "Link": "https://music.microsoft.com/Track/1A5B6008-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "Source": "Catalog"
      },
      {
        "ReleaseDate": "2014-04-02T00:00:00Z",
        "Duration": "00:03:42",
        "TrackNumber": 1,
        "IsExplicit": false,
        "Genres": [
          "Pop"
        ],
        "Subgenres": [
          "Pop Contemporaine"
        ],
        "Rights": [
          "Purchase",
          "Stream",
          "FreeStream"
        ],
        "Album": {
          "Id": "music.1D474208-0100-11DB-89CA-0019B92A3933",
          "Name": "We Are One (Ole Ola) [The Official 2014 FIFA World Cup Song]",
          "ImageUrl": "https://musicimage.xboxlive.com/content/music.1D474208-0100-11DB-89CA-0019B92A3933/image?locale=fr-FR",
          "Link": "https://music.microsoft.com/Album/1D474208-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
          "Source": "Catalog"
        },
        "Artists": [
          {
            "Role": "Main",
            "Artist": {
              "Id": "music.F48A0400-0200-11DB-89CA-0019B92A3933",
              "Name": "Pitbull",
              "ImageUrl": "https://musicimage.xboxlive.com/content/music.F48A0400-0200-11DB-89CA-0019B92A3933/image?locale=fr-FR",
              "Link": "https://music.microsoft.com/Artist/F48A0400-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
              "Source": "Catalog"
            }
          }
        ],
        "Id": "music.1E474208-0100-11DB-89CA-0019B92A3933",
        "Name": "We Are One (Ole Ola) [The Official 2014 FIFA World Cup Song]",
        "ImageUrl": "https://musicimage.xboxlive.com/content/music.1E474208-0100-11DB-89CA-0019B92A3933/image?locale=fr-FR",
        "Link": "https://music.microsoft.com/Track/1E474208-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",
        "Source": "Catalog"
      },
      {
        [...]
      }
    ],
    "ContinuationToken": "AShFeFoZDAQAAQcDAQACNTA",
    "TotalItemCount": 1000
  }
}
```

#### Parent
[Groove Service REST Reference](overview.md)
