#Guidelines
Following are some important rules you must respect when using the Groove Service. This list is not meant to be exhaustive:   

+ Users of the Groove Service must comply with the [Groove API TERMS OF USE].    

+ Every time data from the Groove Service is used in your application or web site, you must display a deep link to the relevant content.  
 
	   For more information about deep links, see [Deep Link].  

+ You may only display an item of album art in connection with an opportunity to purchase the corresponding track in Groove or to promote the availability of the track in Groove Pass.    
 
	These can be created using action deep links (play, buy, view, addtocollection) and/or text and images as described in the [Badges].

+ For images, you must use the exact URLs returned by the Groove RESTful API.  
 
	You may customize them only by using the parameters described in [Image Service]. Any other change that is not documented in [Image Service] will be considered a breach of the terms of use of the Groove Service.

+ Affiliate sites and applications must comply with the [Badges].  

	These branding guidelines provide detailed information about how Groove assets, naming, references, and linking must be integrated in your application.

+ The application or website may neither integrate nor redistribute the content obtained from the Groove Service to other services similar to Xbox, such as radio services and other music services.

+ The application or website may cache the content retrieved through the Groove RESTful API for a limited period of time—a maximum of 24 hours.  
 After 24 hours, the application must update the data by querying the Groove RESTful API again.

+ If Microsoft provides you with an authentication token, your application may enable users to sign in to their Groove Pass premium subscription accounts and stream audio content. Your application must not enable download of audio content from the Groove Pass service, or any other form of unauthorized reproduction such as stream capture.  

## Pilot Program
The Pilot Program is a limited beta for developers who wish to stream content from Groove Pass through an authorized application.   

Please visit <http://go.microsoft.com/fwlink/p/?LinkID=396801> if you are interested in learning more about the requirements to participate in one of the limited slots. The following guidelines apply to all Pilot Program applications in addition to the guidelines above.   

+ You must authenticate each user as a premium Groove Pass subscriber before streaming content from the Groove Pass catalog as further described in the documentation provided by Microsoft.
+ Your application must list the artist name, song title and album title prior to each stream, and if technically possible, contemporaneously with playback.
+ You must not pre-load (pre-download) more than three songs in advance for streaming, and you may do so only when the currently playing song is 20 seconds or fewer from reaching the end.

[Groove API TERMS OF USE]: ../Groove%20API%20Terms%20of%20Use.md
[Deep Link]: Deep%20Link.md
[Badges]: Badges.md
[Image Service]: Image%20Service.md
refs/remotes/origin/live:Main/Using the Groove RESTful Services/Guidelines.md
