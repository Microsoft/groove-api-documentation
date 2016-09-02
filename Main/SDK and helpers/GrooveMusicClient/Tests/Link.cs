// Copyright (c) Microsoft Corporation
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xbox.Music.Platform.Contract.DataModel;
using Microsoft.Xbox.Music.Platform.Client;

namespace Tests
{
    [TestClass]
    public class Link : TestBase
    {
        [TestMethod, TestCategory("Anonymous")]
        public async Task TestLinks()
        {
            const string katyPerryId = "music.97e60200-0200-11db-89ca-0019b92a3933";

            // Lookup Katy Perry's information, including latest album releases
            ContentResponse lookupResponse = await Client.LookupAsync(katyPerryId, extras: ExtraDetails.Albums, country: "US").Log();
            Artist artist = lookupResponse.Artists.Items.First();

            // Create a link to Katy Perry's artist page in an Xbox Music client
            string artistPageDeepLink = artist.Link;
            Console.WriteLine("Artist page deep link: {0}", artistPageDeepLink);
            Assert.IsNotNull(artistPageDeepLink, "The artist page deep link should not be null");

            // Create a link which starts playback of Katy Perry's latest album in the US (exclude singles and EPs)
            Album album = artist.Albums.Items.First(a => a.AlbumType == "Album");
            string albumPlayDeepLink = album.GetLink(ContentExtensions.LinkAction.Play);
            Console.WriteLine("Album play deep link: {0}", albumPlayDeepLink);
            Assert.IsNotNull(albumPlayDeepLink, "The album play deep link should not be null");
        }
    }
}
