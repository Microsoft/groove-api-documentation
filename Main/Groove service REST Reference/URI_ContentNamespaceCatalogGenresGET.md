#GET (/1/content/{namespace}/catalog/genres) 

Get a list of genres available for a locale.

-   [Remarks](#remarks)
-   [Response object](#response-object)
-   [Examples](#examples)

##Remarks


The BrowseGenres request is composed of mandatory and optional URL parts and query parameters. A request containing all parameters would resemble the following string:
```
/1/content/{namespace}/catalog/genres?language={language}&country={country}&accessToken={accessToken}
```
For parameters common to every Groove RESTful API, see [Parameters common to every Groove RESTful API](CommonParameters.md). For a table of error codes, see [Error (JSON)](JSON_Error.md). For HTTP status codes, see [Groove RESTful API HTTP Status Codes](HTTPStatusCodes.md).

##Response object


[ContentResponse (JSON)](JSON_ContentResponse.md)

##Examples

###Browse genres


#### Request
```http
GET /1/content/music/catalog/genres?accessToken=Bearer+[...]
```
#### Response
```json   
{
"Genres": \[  
"Blues / Folk",  
"Christian / Gospel",
"Classical",
"Comedy / Spoken Word",
"Country",
"Electronic / Dance",
"Hip Hop",
"Jazz",
"Kids",
"Latin",
"Pop",
"R&B / Soul",
"Reggae / Dancehall",
"Rock",
"Soundtracks",
"World",
"More"
\],
"Culture": "en-US"
}
```
####Browse genres for a specific locale


#### Request
```http
GET /1/content/music/catalog/genres?country=tr&language=tr&accessToken=Bearer+[...]
```
#### Response
```json
{
"Genres": \[
"Alternatif",
"Caz",
"Elektronik / Dans",
"Film müzikleri",
"Hip Hop / Soul",
"Klasik",
"Pop",
"Rock",
"Daha fazla müzik türü"
\],
"Culture": "tr-TR"
}
``` 
##See also
