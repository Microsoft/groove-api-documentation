---
title: Namespaces supported by Groove Music APIs| Groove Services
description:  Learn about the namespaces used by Groove Music APIs to indicate type of content delivered.
keywords: groove music, groove api, groove userprofileresponse json
author: sakley
ms.assetid: 
---

# Namespaces supported
The Groove APIs use namespaces to indicate the type of content that is being referenced or asked for, and to separate ID spaces. All of the content IDs returned in content API responses are always prefixed with their namespace. For example, ``` music.{ID} ```identifies a particular piece of music content. The namespaces should be considered as part of the ID when passing a specific ID in a request.

Some namespaces have associated sub-namespaces that can identify other secondary or third-party IDs for the same content types. For example, the ```music``` namespace is used to prefix Groove IDs, but some of the Groove pieces of content can also be referenced by third-party IDs such as AMG IDs (using the sub-namespace ```music.amg```). Some of those sub-namespaces can be used as input in a limited set of scenarios (see table below).

## Supported Namespaces

| **Namespace**  | **Description**     | **Content identified**    | **Case sensitive** | **Found in**   | **Usable in** |
|:----------------|:---------------------------|-------------------------------|-----------------|---------------------|---------|--------------------------------------------------------------------------------------------------|
| music          | Primary namespace to identify all Groove content across all Music APIs.    | Music artists, albums, tracks  | yes                 | the ID property of all pieces of music content returned by content APIs  | all APIs that accept a music ID or just a namespace as input                                     |
| music.playlist | Sub-namespace to identify Groove playlists                                 | Music playlists                     | no                  | the ID property of all music playlists returned by content APIs                                                                                             | all APIs that accept a music playlist ID as input (lookup, sub-browse, playlist edit, and so on) |
| music.playlistforyou | Sub-namespace to identify Groove playlists for you                   | Music playlists                     | no                  | the ID property of all music playlists for you returned by content APIs                                                                                     | all APIs that accept a music playlist for you ID as input (lookup, sub-browse and browse)        |
| music.amg      | Sub-namespace that references music content via its public AMG identifier  | Music tracks, albums, artists  | no                  | the property **OtherIds** of Groove pieces of content which have an associated AMG ID    | none of our APIs |
| music.isrc     | Sub-namespace that references music content via its public ISRC identifier | Music albums, tracks                                                   | no                  | the property **OtherIds** of Groove pieces of content which have an associated ISRC ID, and only when accessed through the Lookup API on the Catalog source | the Lookup API when the source is Catalog|
| music.icpn     | Sub-namespace that references music content via its public ICPN identifier | Music albums, tracks                                                                 | no                  | the property **OtherIds** of Groove pieces of content which have an associated ICPN ID, and only when accessed through the Lookup API on the Catalog source | the Lookup API when the source is Catalog                                                        |
| music.onedrive | Sub-namespace that references music content in OneDrive storage            | Music albums, tracks                                     | no                  | the property **OtherIds** of Groove pieces of content which come from OneDrive storage, and only when accessed through the Lookup API on the Collection source | the Lookup API when the source is Collection                                                        |

## Examples

### music
```
music.A83EB907-0100-11DB-89CA-0019B92A3933,        music.AQQfoAnP2FoMuUGhob9VNyDIRAe5PqgAAQ
```

### music.playlist
```
music.playlist.ef30cdb7-2ad1-404b-9478-8fdc89ad35f0 
```

### music.playlistforyou
```
music.playlistforyou.d0b76565-64cf-42a8-bdba-3f8678392f99 
```

### music.amg

```
music.amg.T29381286 
``` 

### music.isrc
```
music.isrc.GBDJQ8800006  
``` 

### music.icpn
```
music.icpn.886443927087  
```

### music.onedrive
```
music.onedrive.9af8228f-1d2a-4002-862d-67fe8f97d289  
```

#### Parent
[Groove Service REST Reference](overview.md)
