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
    public class Collection : TestBase
    {
        [TestMethod, TestCategory("Anonymous")]
        public async Task TestLookupPublicPlaylist()
        {
            // Tip: You get your own playlistId by opening your playlist on http://music.xbox.com
            //      If the page is http://music.xbox.com/playlist/great-music/66cd8e9d-802a-00fe-364d-3ead4f82facf
            //      the id is music.playlist.66cd8e9d-802a-00fe-364d-3ead4f82facf .
            const string playlistId = "music.playlist.0016e20b-80c0-00fe-fac0-1a47365516d1";

            // Get playlist contents as viewed from the US
            ContentResponse playlistUsResponse =
                await Client.LookupAsync(playlistId, ContentSource.Collection, country: "US").Log();
            foreach (var track in playlistUsResponse.Playlists.Items.First().Tracks.Items)
            {
                Console.WriteLine("  Track {0} can be {1} in the US", track.Id, String.Join(" and ", track.Rights));
            }

            // Get playlist contents as viewed from Brasil
            // Note that rights (such as Stream, FreeStream and Purchase) and collection item ids can be country specific
            ContentResponse playlistBrResponse =
                await Client.LookupAsync(playlistId, ContentSource.Collection, country: "BR").Log();
            foreach (var track in playlistBrResponse.Playlists.Items.First().Tracks.Items)
            {
                Console.WriteLine("  Track {0} can be {1} in Brasil", track.Id, String.Join(" and ", track.Rights));
            }
        }

        [TestMethod, TestCategory("Authenticated")]
        public async Task TestBrowsePlaylists()
        {
            // Get all the user's playlists
            ContentResponse browseResults =
                await AuthenticatedClient.BrowseAsync(Namespace.music, ContentSource.Collection, ItemType.Playlists).Log();
            Assert.IsNotNull(browseResults, "The browse response should not be null");
            AssertPaginatedListIsValid(browseResults.Playlists, 1);
        }
    }
}
