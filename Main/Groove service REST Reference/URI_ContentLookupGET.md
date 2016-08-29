|                              |
|------------------------------|
| GET (/1/content/{id}/lookup) |
| [See Also](#seeAlsoToggle)   |

|  Collapse All    Expand All     |
|---------------------------------|

Visual Basic (Usage)
Visual Basic (Declaration)
C\#
C++
JavaScript

Look up one or several items from a media catalog and/or user's collection.

-   [Remarks](#remarks)

-   [URI parameters](#uri-parameters)

-   [Response object](#response-object)

-   [Query string parameters](#query-string-parameters)

-   [Catalog lookup examples](#catalog-lookup-examples)

-   [Lookup by ISRC](#lookup-by-isrc)

-   [Lookup by ICPN](#lookup-by-icpn)

-   [Collection lookup examples](#collection-lookup-examples)

Remarks
=======

A lookup request is composed of mandatory and optional URL parts and query parameters, as described in the following table. A lookup request containing all parameters would look like the following string:

/1/content/{id1+id2+id3}/lookup?language={language}&country={country} &extras={extras}&source={source}&contentType={contentType}&continuationToken={continuationToken}&accessToken={accessToken}&jsonp={jsonp}

For parameters common to every Groove RESTful API, see [Parameters common to every Groove RESTful API](../Endpointdocumentation/CommonParameters.htm). For a table of error codes, see [Error (JSON)](../Endpointdocumentation/JSON_Error.htm). For HTTP status codes, see [Groove RESTful API HTTP Status Codes](../Endpointdocumentation/HTTPStatusCodes.htm).

| **Note **                                                                                               |
|---------------------------------------------------------------------------------------------------------|
| Using the **collection** source requires [user authentication](../Endpointdocumentation/user_auth.htm). |

URI parameters
==============

| **Parameter** | **Type** | **Description**                                                                                                                                                                                   |
|---------------|----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ids           | string   | Required. The ID or IDs to be looked up. Each ID is prefixed by a namespace and ".". Multiple IDs are separated by "+". The total length of all IDs must be less than or equal to 250 characters. 
                                                                                                                                                                                                                               
                            | **Note **                                                                                                                                                                     |                  
                            |-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|                  
                            | ISRC and ICPN external IDs are accepted as input by the Lookup API (see [Namespaces supported](../Endpointdocumentation/Namespace.htm)), but only when the source is Catalog. |                  |

Response object
===============

[ContentResponse (JSON)](../Endpointdocumentation/JSON_ContentResponse.htm)

Query string parameters
=======================

| **Parameter** | **Type** | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
|---------------|----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| source        | string   | Optional. One or more data source(s), in case the client is interested in lookup up data in specific sources. Multiple sources may be passed in this parameter by separating them with "+". Possible values for the "music" namespace are "catalog", "collection", and "collection+catalog". The use of the "collection" source requires passing a valid user authentication token. If this parameter is not provided, the lookup will be performed in the "catalog" if no user authentication token is provided and "collection+catalog" if one is provided. |
| extras        | string   | Optional. List of extra fields that can be optionally requested (at the cost of performance). Multiple values must be separated with "+".                                                                                                                                                                                                                                                                                                                                                                                                                     |

Catalog lookup examples
=======================

Artist lookup
-------------

#### Request

GET /1/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/lookup?accessToken=Bearer+http%253a%252f%252fschemas.xmlsoap.org

252fws%252f2005%252f05%252fidentity%252fclaims%252fnameidentifier%3dAwesomePartner

%26http%253a%252f%252fschemas.microsoft.com%252faccesscontrolservice%252f2010%252f07%252fclaims%252fidentityprovider

%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26Audience%3dhttp%253a%252f%252fmusic.xboxlive.com%252f%26ExpiresOn

%3d1609459199%26Issuer%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26HMACSHA256%3d0pVJ3

%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1

#### Response

{

"Artists": {

"Items": \[

{

"Genres": \[

"Electronic / Dance"

\],

"Subgenres": \[

"Dance"

\],

"Id": "music.C61C0000-0200-11DB-89CA-0019B92A3933",

"Name": "Daft Punk",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "P 168791"

},

"Source": "Catalog"

}

\]

}

}

Album lookup
------------

#### Request

GET /1/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/lookup?accessToken=Bearer+http%253a

%252f%252fschemas.xmlsoap.org%252fws%252f2005%252f05%252fidentity%252fclaims%252fnameidentifier

%3dAwesomePartner%26http%253a%252f%252fschemas.microsoft.com%252faccesscontrolservice%252f2010

%252f07%252fclaims%252fidentityprovider%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26Audience%3dhttp

%253a%252f%252fmusic.xboxlive.com%252f%26ExpiresOn%3d1609459199%26Issuer%3dhttps%253a%252f

%252fdatamarket.accesscontrol.windows.net%26HMACSHA256%3d0pVJ3%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1

#### Response

{

"Albums": {

"Items": \[

{

"ReleaseDate": "2013-05-09T00:00:00Z",

"Duration": "01:14:26",

"TrackCount": 13,

"IsExplicit": false,

"LabelName": "Columbia",

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"AlbumType": "Album",

"Artists": \[

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

\],

"Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",

"Name": "Random Access Memories",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "R 2749955"

},

"Source": "Catalog"

}

\]

}

}

Track lookup
------------

#### Request

GET /1/content/music.A83EB907-0100-11DB-89CA-0019B92A3933/lookup?accessToken=Bearer+http%253a%252f

%252fschemas.xmlsoap.org%252fws%252f2005%252f05%252fidentity%252fclaims%252fnameidentifier

%3dAwesomePartner%26http%253a%252f%252fschemas.microsoft.com%252faccesscontrolservice%252f2010

%252f07%252fclaims%252fidentityprovider%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26Audience

%3dhttp%253a%252f%252fmusic.xboxlive.com%252f%26ExpiresOn%3d1609459199%26Issuer

%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26HMACSHA256%3d0pVJ3

%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1

#### Response

{

"Tracks": {

"Items": \[

{

"ReleaseDate": "2013-05-09T00:00:00Z",

"Duration": "00:06:09",

"TrackNumber": 8,

"IsExplicit": false,

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"Rights": \[

"Purchase",

"Stream",

"FreeStream"

\],

"Subtitle": "feat. Pharrell Williams",

"Album": {

"Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",

"Name": "Random Access Memories",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"Source": "Catalog"

},

"Artists": \[

{

"Role": "Main",

"Artist": {

"Id": "music.CFDD6300-0200-11DB-89CA-0019B92A3933",

"Name": "Daft Punk feat. Pharrell Williams and Nile Rodgers",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.CFDD6300-0200-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Artist/CFDD6300-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"Source": "Catalog"

}

}

\],

"Id": "music.A83EB907-0100-11DB-89CA-0019B92A3933",

"Name": "Get Lucky",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.A83EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Track/A83EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "T 29381286"

},

"Source": "Catalog"

}

\]

}

}

Lookup of a nonexistent ID
--------------------------

#### Request

GET /1/content/music.00000000-0000-0000-0000-000000000000/lookup?accessToken=Bearer+http%253a%252f%252fschemas.xmlsoap.org

%252fws%252f2005%252f05%252fidentity%252fclaims%252fnameidentifier%3dAwesomePartner%26http%253a

%252f%252fschemas.microsoft.com%252faccesscontrolservice%252f2010%252f07%252fclaims%252fidentityprovider

%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26Audience%3dhttp%253a%252f%252fmusic.xboxlive.com%252f%26ExpiresOn

%3d1609459199%26Issuer%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26HMACSHA256%3d0pVJ3

%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1

#### Response

HTTP/1.1 404 Not Found

{

"Error": {

"ErrorCode": "CATALOG\_NO\_RESULT",

"Description": "Item does not exist"

}

}

More complex example
--------------------

The following examples use the following optional features:

-   Batching: requests three music IDs at the same time

-   Choosing XML content-type instead of JSON

-   Passing the developer authentication token as a header instead of query parameter

#### Request

GET /1/content/music.A83EB907-0100-11DB-89CA-0019B92A3933+music.B13EB907-0100-11DB-89CA-0019B92A3933

+music.C61C0000-0200-11DB-89CA-0019B92A3933/lookup HTTP/1.1

Accept: application/xml

Authorization: Bearer http%3a%2f%2fschemas.xmlsoap.org%2fws%2f2005%2f05%2fidentity%2fclaims%2fnameidentifier=AwesomePartner

&http%3a%2f%2fschemas.microsoft.com%2faccesscontrolservice%2f2010%2f07%2fclaims%2fidentityprovider=

https%3a%2f%2fdatamarket.accesscontrol.windows.net&Audience=http%3a%2f%2fmusic.xboxlive.com%2f&ExpiresOn=1609459199

&Issuer=https%3a%2f%2fdatamarket.accesscontrol.windows.net&HMACSHA256=0pVJ3%2fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%3d

#### Response

&lt;ContentResponse xmlns="http://schemas.microsoft.com/xboxmusic/2013/10/platform" xmlns:i="http://www.w3.org/2001/XMLSchema-instance"&gt;

&lt;Albums&gt;

&lt;Items&gt;

&lt;Album&gt;

&lt;Id&gt;music.B13EB907-0100-11DB-89CA-0019B92A3933&lt;/Id&gt;

&lt;ImageUrl&gt;http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US&lt;/ImageUrl&gt;

&lt;Link&gt;http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner&lt;/Link&gt;

&lt;Name&gt;Random Access Memories&lt;/Name&gt;

&lt;OtherIds&gt;

&lt;OtherId&gt;

&lt;Namespace&gt;music.amg&lt;/Namespace&gt;

&lt;Id&gt;R 2749955&lt;/Id&gt;

&lt;/OtherId&gt;

&lt;/OtherIds&gt;

&lt;Source&gt;Catalog&lt;/Source&gt;

&lt;AlbumType&gt;Album&lt;/AlbumType&gt;

&lt;Artists&gt;

&lt;Contributor&gt;

&lt;Artist&gt;

&lt;Id&gt;music.C61C0000-0200-11DB-89CA-0019B92A3933&lt;/Id&gt;

&lt;ImageUrl&gt;http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US&lt;/ImageUrl&gt;

&lt;Link&gt;http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner&lt;/Link&gt;

&lt;Name&gt;Daft Punk&lt;/Name&gt;

&lt;Source&gt;Catalog&lt;/Source&gt;

&lt;/Artist&gt;

&lt;Role&gt;Main&lt;/Role&gt;

&lt;/Contributor&gt;

&lt;/Artists&gt;

&lt;Duration&gt;PT1H14M24S&lt;/Duration&gt;

&lt;Genres&gt;

&lt;Genre&gt;Pop&lt;/Genre&gt;

&lt;/Genres&gt;

&lt;IsExplicit&gt;false&lt;/IsExplicit&gt;

&lt;LabelName&gt;Columbia&lt;/LabelName&gt;

&lt;ReleaseDate&gt;2013-05-09T00:00:00Z&lt;/ReleaseDate&gt;

&lt;Subgenres&gt;

&lt;Genre&gt;Contemporary Pop&lt;/Genre&gt;

&lt;/Subgenres&gt;

&lt;TrackCount&gt;13&lt;/TrackCount&gt;

&lt;/Album&gt;

&lt;/Items&gt;

&lt;/Albums&gt;

&lt;Artists&gt;

&lt;Items&gt;

&lt;Artist&gt;

&lt;Id&gt;music.C61C0000-0200-11DB-89CA-0019B92A3933&lt;/Id&gt;

&lt;ImageUrl&gt;http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US&lt;/ImageUrl&gt;

&lt;Link&gt;http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner&lt;/Link&gt;

&lt;Name&gt;Daft Punk&lt;/Name&gt;

&lt;OtherIds&gt;

&lt;OtherId&gt;

&lt;Namespace&gt;music.amg&lt;/Namespace&gt;

&lt;Id&gt;P 168791&lt;/Id&gt;

&lt;/OtherId&gt;

&lt;/OtherIds&gt;

&lt;Source&gt;Catalog&lt;/Source&gt;

&lt;Genres&gt;

&lt;Genre&gt;Electronic / Dance&lt;/Genre&gt;

&lt;/Genres&gt;

&lt;Subgenres&gt;

&lt;Genre&gt;Dance&lt;/Genre&gt;

&lt;/Subgenres&gt;

&lt;/Artist&gt;

&lt;/Items&gt;

&lt;/Artists&gt;

&lt;Tracks&gt;

&lt;Items&gt;

&lt;Track&gt;

&lt;Id&gt;music.A83EB907-0100-11DB-89CA-0019B92A3933&lt;/Id&gt;

&lt;ImageUrl&gt;http://musicimage.xboxlive.com/content/music.A83EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US&lt;/ImageUrl&gt;

&lt;Link&gt;http://music.xbox.com/Track/A83EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner&lt;/Link&gt;

&lt;Name&gt;Get Lucky&lt;/Name&gt;

&lt;OtherIds&gt;

&lt;OtherId&gt;

&lt;Namespace&gt;music.amg&lt;/Namespace&gt;

&lt;Id&gt;T 29381286&lt;/Id&gt;

&lt;/OtherId&gt;

&lt;/OtherIds&gt;

&lt;Source&gt;Catalog&lt;/Source&gt;

&lt;Album&gt;

&lt;Id&gt;music.B13EB907-0100-11DB-89CA-0019B92A3933&lt;/Id&gt;

&lt;ImageUrl&gt;http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US&lt;/ImageUrl&gt;

&lt;Link&gt;http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner&lt;/Link&gt;

&lt;Name&gt;Random Access Memories&lt;/Name&gt;

&lt;Source&gt;Catalog&lt;/Source&gt;

&lt;/Album&gt;

&lt;Artists&gt;

&lt;Contributor&gt;

&lt;Artist&gt;

&lt;Id&gt;music.C61C0000-0200-11DB-89CA-0019B92A3933&lt;/Id&gt;

&lt;ImageUrl&gt;http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US&lt;/ImageUrl&gt;

&lt;Link&gt;http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner&lt;/Link&gt;

&lt;Name&gt;Daft Punk&lt;/Name&gt;

&lt;Source&gt;Catalog&lt;/Source&gt;

&lt;/Artist&gt;

&lt;Role&gt;Main&lt;/Role&gt;

&lt;/Contributor&gt;

&lt;/Artists&gt;

&lt;Duration&gt;PT6M7S&lt;/Duration&gt;

&lt;Genres&gt;

&lt;Genre&gt;Pop&lt;/Genre&gt;

&lt;/Genres&gt;

&lt;IsExplicit&gt;false&lt;/IsExplicit&gt;

&lt;ReleaseDate&gt;2013-05-09T00:00:00Z&lt;/ReleaseDate&gt;

&lt;Rights&gt;

&lt;Right&gt;Purchase&lt;/Right&gt;

&lt;Right&gt;Stream&lt;/Right&gt;

&lt;Right&gt;FreeStream&lt;/Right&gt;

&lt;/Rights&gt;

&lt;Subgenres&gt;

&lt;Genre&gt;Contemporary Pop&lt;/Genre&gt;

&lt;/Subgenres&gt;

&lt;Subtitle&gt;feat. Pharrell Williams&lt;/Subtitle&gt;

&lt;TrackNumber&gt;8&lt;/TrackNumber&gt;

&lt;/Track&gt;

&lt;/Items&gt;

&lt;/Tracks&gt;

&lt;/ContentResponse&gt;

Batch lookup with extra details
-------------------------------

#### Request

GET /1/content/music.A83EB907-0100-11DB-89CA-0019B92A3933+

music.B13EB907-0100-11DB-89CA-0019B92A3933+music.C61C0000-0200-11DB-89CA-0019B92A3933/lookup?

**extras=Albums+TopTracks+ArtistDetails+Tracks+AlbumDetails**

&accessToken=Bearer+http%253a%252f%252fschemas.xmlsoap.org%252fws%252f2005%252f05%252fidentity%252fclaims

%252fnameidentifier%3dAwesomePartner%26http%253a%252f%252fschemas.microsoft.com%252faccesscontrolservice%252f2010

%252f07%252fclaims%252fidentityprovider%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26Audience%3dhttp%253a%252f

%252fmusic.xboxlive.com%252f%26ExpiresOn%3d1609459199%26Issuer%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26HMACSHA256

%3d0pVJ3%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1

#### Response

{

"Artists": {

"Items": \[

{

"Genres": \[

"Electronic / Dance"

\],

"Subgenres": \[

"Dance"

\],

"Albums": {

"Items": \[

{

"ReleaseDate": "2013-07-03T00:00:00Z",

"Duration": "00:10:31",

"TrackCount": 1,

"IsExplicit": false,

"LabelName": "Columbia",

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"AlbumType": "Single",

"Subtitle": "Daft Punk Remix",

"Artists": \[

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

\],

"Id": "music.E368C707-0100-11DB-89CA-0019B92A3933",

"Name": "Get Lucky",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.E368C707-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/E368C707-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"Source": "Catalog"

},

{

"ReleaseDate": "2013-05-09T00:00:00Z",

"Duration": "01:14:24",

"TrackCount": 13,

"IsExplicit": false,

"LabelName": "Columbia",

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"AlbumType": "Album",

"Artists": \[

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

\],

"Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",

"Name": "Random Access Memories",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "R 2749955"

},

"Source": "Catalog"

},

{

\[...\]

}

\],

"ContinuationToken": "AYEDERwACQQBCAcCAQAAHMYAAtsRicoAGbkqOTMBAAIyNQ",

"TotalItemCount": 37

},

"TopTracks": {

"Items": \[

{

"ReleaseDate": "2013-05-09T00:00:00Z",

"Duration": "00:06:09",

"TrackNumber": 8,

"IsExplicit": false,

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"Rights": \[

"Purchase",

"Stream",

"FreeStream"

\],

"Subtitle": "feat. Pharrell Williams",

"Album": {

"Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",

"Name": "Random Access Memories",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"Source": "Catalog"

},

"Artists": \[

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

\],

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

"Genres": \[

"Electronic / Dance"

\],

"Subgenres": \[

"Dance"

\],

"Rights": \[

"Purchase",

"Stream",

"FreeStream"

\],

"Album": {

"Id": "music.F2E82706-0100-11DB-89CA-0019B92A3933",

"Name": "Musique",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.F2E82706-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/F2E82706-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"Source": "Catalog"

},

"Artists": \[

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

\],

"Id": "music.5BAF3206-0100-11DB-89CA-0019B92A3933",

"Name": "Harder, Better, Faster, Stronger",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.5BAF3206-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Track/5BAF3206-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"Source": "Catalog"

},

{

\[...\]

}

\],

"ContinuationToken": "AYEDERwACQQCAQcCAQAAHMYAAtsRicoAGbkqOTMBAAIyNQ",

"TotalItemCount": 194

},

"Id": "music.C61C0000-0200-11DB-89CA-0019B92A3933",

"Name": "Daft Punk",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "P 168791"

},

"Source": "Catalog"

}

\]

},

"Albums": {

"Items": \[

{

"ReleaseDate": "2013-05-09T00:00:00Z",

"Duration": "01:14:24",

"TrackCount": 13,

"IsExplicit": false,

"LabelName": "Columbia",

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"AlbumType": "Album",

"Artists": \[

{

"Role": "Main",

"Artist": {

"Genres": \[

"Electronic / Dance"

\],

"Subgenres": \[

"Dance"

\],

"Id": "music.C61C0000-0200-11DB-89CA-0019B92A3933",

"Name": "Daft Punk",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "P 168791"

},

"Source": "Catalog"

}

}

\],

"Tracks": {

"Items": \[

{

"ReleaseDate": "2013-05-09T00:00:00Z",

"Duration": "00:04:34",

"TrackNumber": 1,

"IsExplicit": false,

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"Rights": \[

"Purchase",

"Stream",

"FreeStream"

\],

"Artists": \[

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

\],

"Id": "music.AA3EB907-0100-11DB-89CA-0019B92A3933",

"Name": "Give Life Back to Music",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.AA3EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Track/AA3EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "T 29381293"

},

"Source": "Catalog"

},

{

"ReleaseDate": "2013-05-09T00:00:00Z",

"Duration": "00:05:21",

"TrackNumber": 2,

"IsExplicit": false,

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"Rights": \[

"Purchase",

"Stream",

"FreeStream"

\],

"Artists": \[

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

\],

"Id": "music.AB3EB907-0100-11DB-89CA-0019B92A3933",

"Name": "The Game of Love",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.AB3EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Track/AB3EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "T 29381292"

},

"Source": "Catalog"

},

{

\[...\]

}

\],

"TotalItemCount": 13

},

"Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",

"Name": "Random Access Memories",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "R 2749955"

},

"Source": "Catalog"

}

\]

},

"Tracks": {

"Items": \[

{

"ReleaseDate": "2013-05-09T00:00:00Z",

"Duration": "00:06:09",

"TrackNumber": 8,

"IsExplicit": false,

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"Rights": \[

"Purchase",

"Stream",

"FreeStream"

\],

"Subtitle": "feat. Pharrell Williams",

"Album": {

"ReleaseDate": "2013-05-09T00:00:00Z",

"Duration": "01:14:24",

"TrackCount": 13,

"IsExplicit": false,

"LabelName": "Columbia",

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"AlbumType": "Album",

"Artists": \[

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

\],

"Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",

"Name": "Random Access Memories",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "R 2749955"

},

"Source": "Catalog"

},

"Artists": \[

{

"Role": "Main",

"Artist": {

"Genres": \[

"Electronic / Dance"

\],

"Subgenres": \[

"Dance"

\],

"Id": "music.C61C0000-0200-11DB-89CA-0019B92A3933",

"Name": "Daft Punk",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.C61C0000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Artist/C61C0000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "P 168791"

},

"Source": "Catalog"

}

}

\],

"Id": "music.A83EB907-0100-11DB-89CA-0019B92A3933",

"Name": "Get Lucky",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.A83EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Track/A83EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "T 29381286"

},

"Source": "Catalog"

}

\]

}

}

Lookup by ISRC
==============

ISRC is a standard music identifier that can be used as input to the Lookup API by prefixing it with the namespace music.isrc.

Request
-------

GET /1/content/music.isrc.GBDJQ8800006/lookup?accessToken=Bearer+http%253a%252f%252f

schemas.xmlsoap.org%252fws%252f2005%252f05%252fidentity%252fclaims%252fnameidentifier

%3dAwesomePartner%26http%253a%252f%252fschemas.microsoft.com%252faccesscontrolservice

%252f2010%252f07%252fclaims%252fidentityprovider%3dhttps%253a%252f%252fdatamarket.

accesscontrol.windows.net%26Audience%3dhttp%253a%252f%252fmusic.xboxlive.com%252f

%26ExpiresOn%3d1609459199%26Issuer%3dhttps%253a%252f%252fdatamarket.accesscontrol.

windows.net%26HMACSHA256%3d0pVJ3%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1

Response
--------

{

"Tracks": {

"Items": \[

{

"ReleaseDate": "1988-11-21T00:00:00Z",

"Duration": "00:11:54",

"TrackNumber": 1,

"IsExplicit": false,

"Genres": \[

"Rock"

\],

"Subgenres": \[

"Classic Rock"

\],

"Rights": \[

"Purchase",

"Stream"

\],

"Album": {

"Id": "music.51025806-0100-11DB-89CA-0019B92A3933",

"Name": "Delicate Sound Of Thunder",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.51025806-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/51025806-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"Source": "Catalog"

},

"Artists": \[

{

"Role": "Main",

"Artist": {

"Id": "music.D6670000-0200-11DB-89CA-0019B92A3933",

"Name": "Pink Floyd",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.D6670000-0200-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Artist/D6670000-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"Source": "Catalog"

}

}

\],

"Id": "music.0EE73B06-0100-11DB-89CA-0019B92A3933",

"Name": "Shine On You Crazy Diamond (Parts 1-5)",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.0EE73B06-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Track/0EE73B06-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "T 1530616",

"music.isrc": "GBDJQ8800006"

},

"Source": "Catalog"

}

\]

}

}

Lookup by ICPN
==============

ICPN is a standard music identifier that can be used as input to the Lookup API by prefixing it with the namespace music.icpn.

Request
-------

GET /1/content/music.icpn.886443927087/lookup?accessToken=Bearer+http%253a%252f%252fschemas.xmlsoap.org

%252fws%252f2005%252f05%252fidentity%252fclaims%252fnameidentifier%3dAwesomePartner%26http%253a%252f

%252fschemas.microsoft.com%252faccesscontrolservice%252f2010%252f07%252fclaims%252fidentityprovider

%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net%26Audience%3dhttp%253a%252f

%252fmusic.xboxlive.com%252f%26ExpiresOn%3d1609459199%26Issuer%3dhttps%253a%252f%252fdatamarket.

accesscontrol.windows.net%26HMACSHA256%3d0pVJ3%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1

Response
--------

{

"Albums": {

"Items": \[

{

"ReleaseDate": "2013-05-09T00:00:00Z",

"TrackCount": 13,

"IsExplicit": false,

"LabelName": "Columbia",

"Genres": \[

"Pop"

\],

"Subgenres": \[

"Contemporary Pop"

\],

"AlbumType": "Album",

"Artists": \[

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

\],

"Id": "music.B13EB907-0100-11DB-89CA-0019B92A3933",

"Name": "Random Access Memories",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/B13EB907-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "R 2749955",

"music.icpn": "886443927087"

},

"Source": "Catalog"

}

\]

}

}

Collection lookup examples
==========================

Collection album lookup
-----------------------

#### Request

GET /1/content/music.B13EB907-0100-11DB-89CA-0019B92A3933/lookup?**source=collection**&

accessToken=Bearer+http%253a%252f%252fschemas.xmlsoap.org%252fws%252f2005%252f05%252fidentity

%252fclaims%252fnameidentifier%3dAwesomePartner%26http%253a%252f%252fschemas.microsoft.com

%252faccesscontrolservice%252f2010%252f07%252fclaims%252fidentityprovider%3dhttps%253a%252f%252f

datamarket.accesscontrol.windows.net%26Audience%3dhttp%253a%252f%252fmusic.xboxlive.com%252f

%26ExpiresOn%3d1609459199%26Issuer%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net

%26HMACSHA256%3d0pVJ3%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1

Authorization: XBL3.0 x=1047956662;eyJlbmMiOiJBMTI4Q0JDK0hTMjU2IiwiYWxnIjoiUlNBLU9\[...\]

#### Response

{

"Albums": {

"Items": \[

{

"ReleaseDate": "2013-05-09T02:00:00+02:00",

"Genres": \[

"Pop"

\],

"Id": "music.AQEPB7k-sQABsrFst-olnIY",

"Name": "Random Access Memories",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.b13eb907-0100-11db-89ca-0019b92a3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/b13eb907-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",

"Source": "Collection"

}

\]

}

}

Collection playlist lookup
--------------------------

#### Request

GET /1/content/music.AQM2egu7ioD-AI-GF3usCeHQ/lookup?**source=collection**&

accessToken=Bearer+http%253a%252f%252fschemas.xmlsoap.org%252fws%252f2005%252f05%252fidentity

%252fclaims%252fnameidentifier%3dAwesomePartner%26http%253a%252f%252fschemas.microsoft.com

%252faccesscontrolservice%252f2010%252f07%252fclaims%252fidentityprovider%3dhttps%253a%252f%252f

datamarket.accesscontrol.windows.net%26Audience%3dhttp%253a%252f%252fmusic.xboxlive.com%252f

%26ExpiresOn%3d1609459199%26Issuer%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net

%26HMACSHA256%3d0pVJ3%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1

Authorization: XBL3.0 x=1047956662;eyJlbmMiOiJBMTI4Q0JDK0hTMjU2IiwiYWxnIjoiUlNBLU9\[...\]

#### Response

{

"Playlists": {

"Items": \[

{

"TrackCount": 2,

"UserIsOwner": true,

"Tracks": {

"Items": \[

{

"ReleaseDate": "2013-05-09T02:00:00+02:00",

"Duration": "00:06:07",

"TrackNumber": 8,

"IsExplicit": false,

"Genres": \[

"Pop"

\],

"Rights": \[

"Purchase",

"FreeStream"

\],

"Subtitle": "feat. Pharrell Williams",

"Album": {

"ReleaseDate": "2013-05-09T02:00:00+02:00",

"Genres": \[

"Pop"

\],

"Subtitle": "",

"Id": "music.AQEDB7k-sQABAA",

"Name": "Random Access Memories",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.b13eb907-0100-11db-89ca-0019b92a3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/b13eb907-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",

"Source": "Collection"

},

"Artists": \[

{

"Role": "PrimaryArtist",

"Artist": {

"Id": "music.AQIDAAAcxgACAA",

"Name": "Daft Punk",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.c61c0000-0200-11db-89ca-0019b92a3933/image?locale=en-US",

"Link": "http://music.xbox.com/Artist/c61c0000-0200-11db-89ca-0019b92a3933?partnerID=AwesomePartner",

"Source": "Collection"

}

},

{

"Role": "ContributingArtist",

"Artist": {

"Id": "music.AQIDAABnCAACAA",

"Name": "Pharrell Williams",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.08670000-0200-11db-89ca-0019b92a3933/image?locale=en-US",

"Link": "http://music.xbox.com/Artist/08670000-0200-11db-89ca-0019b92a3933?partnerID=AwesomePartner",

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

\],

"Id": "music.AQQfHgTT3DD6Vkyk1Tk-HDsRBQe5PqgAAQ",

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

"Genres": \[

"Electronic / Dance"

\],

"Subtitle": "",

"Album": {

"ReleaseDate": "2013-09-27T02:00:00+02:00",

"Genres": \[

"Electronic / Dance"

\],

"Subtitle": "",

"Id": "music.AQEDB-rrJgABAA",

"Name": "Aleph",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.26ebea07-0100-11db-89ca-0019b92a3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/26ebea07-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",

"Source": "Collection"

},

"Artists": \[

{

"Role": "PrimaryArtist",

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

\],

"Id": "music.AQQf3-wXiuSFS0yqPmC\_ZUazfgfq6y0AAQ",

"Name": "Aleph",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.2debea07-0100-11db-89ca-0019b92a3933/image?locale=en-US",

"Link": "http://music.xbox.com/Track/2debea07-0100-11db-89ca-0019b92a3933?partnerID=AwesomePartner",

"Source": "Collection"

}

\]

},

"Id": "music.AQM2egu7ioD-AI-GF3usCeHQ",

"Name": "Playlist1",

"Link": "http://music.xbox.com/Playlist/bb0b7a36-808a-00fe-8f86-177bac09e1d0?partnerID=AwesomePartner",

"Source": "Collection"

}

\]

}

}

Collection+Catalog batch lookup
-------------------------------

Each of the input IDs is looked up in the collection first, and then in the catalog if not found in the collection. The "Source" field of each returned item indicates whether the item comes from the Collection or the Catalog.

#### Request

GET /1/content/music.3770F306-0100-11DB-89CA-0019B92A3933+music.AQIPAAAcxgAC3GpkUPzr8EQ/lookup?**source=**

**collection+catalog**&accessToken=Bearer+http%253a%252f%252fschemas.xmlsoap.org%252fws%252f2005

%252f05%252fidentity%252fclaims%252fnameidentifier%3dAwesomePartner%26http%253a%252f%252fschemas.

microsoft.com%252faccesscontrolservice%252f2010%252f07%252fclaims%252fidentityprovider%3dhttps%253a

%252f%252fdatamarket.accesscontrol.windows.net%26Audience%3dhttp%253a%252f%252fmusic.xboxlive.com

%252f%26ExpiresOn%3d1609459199%26Issuer%3dhttps%253a%252f%252fdatamarket.accesscontrol.windows.net

%26HMACSHA256%3d0pVJ3%252fUig7mgeMtlM2wI27SmQItFOQXTzSEbEmmDFG4%253d HTTP/1.1

Authorization: XBL3.0 x=1047956662;eyJlbmMiOiJBMTI4Q0JDK0hTMjU2IiwiYWxnIjoiUlNBLU9\[...\]

#### Response

{

"Artists": {

"Items": \[

{

"Id": "music.AQIPAAAcxgAC3GpkUPzr8EQ",

"Name": "Daft Punk",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.c61c0000-0200-11db-89ca-0019b92a3933/image?locale=en-US",

"Link": "http://music.xbox.com/Artist/c61c0000-0200-11db-89ca-0019b92a3933?partnerID=AwesomePartner",

"Source": "Collection"

}

\]

},

"Tracks": {

"Items": \[

{

"ReleaseDate": "2011-09-20T00:00:00Z",

"Duration": "00:03:26",

"TrackNumber": 1,

"IsExplicit": false,

"Genres": \[

"Electronic / Dance"

\],

"Subgenres": \[

"Dance"

\],

"Subtitle": "Radio Edit",

"Album": {

"Id": "music.3370F306-0100-11DB-89CA-0019B92A3933",

"Name": "Trust You Again",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.3370F306-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Album/3370F306-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"Source": "Catalog"

},

"Artists": \[

{

"Role": "Main",

"Artist": {

"Id": "music.2E860300-0200-11DB-89CA-0019B92A3933",

"Name": "Muttonheads",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.2E860300-0200-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Artist/2E860300-0200-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"Source": "Catalog"

}

}

\],

"Id": "music.3770F306-0100-11DB-89CA-0019B92A3933",

"Name": "Trust You Again",

"ImageUrl": "http://musicimage.xboxlive.com/content/music.3770F306-0100-11DB-89CA-0019B92A3933/image?locale=en-US",

"Link": "http://music.xbox.com/Track/3770F306-0100-11DB-89CA-0019B92A3933?partnerID=AwesomePartner",

"OtherIds": {

"music.amg": "T 23642758"

},

"Source": "Catalog"

}

\]

}

}

See also
========

#### Parent

[/1/content/{id}/lookup](../Endpointdocumentation/URI_ContentLookup.htm)

© 2016 Microsoft Corporation. All rights reserved.
Submit feedback on <https://forums.xboxlive.com/>.
Version: 2.0.100825.0 \[private build\]