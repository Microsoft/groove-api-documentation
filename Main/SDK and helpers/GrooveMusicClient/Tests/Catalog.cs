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
    public class Catalog : TestBase
    {
        [TestMethod, TestCategory("Anonymous")]
        public async Task TestSearchAndLookup()
        {
            // Search for "Daft Punk"
            ContentResponse searchResults = await Client.SearchAsync(Namespace.music, "Daft Punk", country: "US").Log();
            Assert.IsNotNull(searchResults, "The search response should not be null");
            AssertPaginatedListIsValid(searchResults.Artists, 1, 1);
            AssertPaginatedListIsValid(searchResults.Albums, 10, 20);
            AssertPaginatedListIsValid(searchResults.Tracks, 25, 100);
            Assert.IsNotNull(searchResults.Tracks.ContinuationToken, "Search results should contain continuation for tracks");

            // Get the 2nd page of track results
            ContentResponse continuedSearchResults =
                await Client.SearchContinuationAsync(Namespace.music, searchResults.Tracks.ContinuationToken).Log();
            Assert.IsNotNull(continuedSearchResults, "The continued search response should not be null");
            Assert.IsNull(continuedSearchResults.Artists, "The continued search response should not contain artists");
            Assert.IsNull(continuedSearchResults.Albums, "The continued search response should not contain albums");
            AssertPaginatedListIsValid(continuedSearchResults.Tracks, 25, 100);

            // List tracks in the first album
            Album firstAlbum = searchResults.Albums.Items.First();
            ContentResponse albumTrackResults = await Client.LookupAsync(firstAlbum.Id, extras: ExtraDetails.Tracks, country: "US").Log();
            AssertPaginatedListIsValid(albumTrackResults.Albums, 1);
            Album firstAlbumLookup = albumTrackResults.Albums.Items.First();
            Assert.AreEqual(firstAlbum.Id, firstAlbumLookup.Id, "Album ids should be the same");
            Assert.IsNotNull(firstAlbumLookup.Tracks, "Album should have tracks");
            Assert.IsNotNull(firstAlbumLookup.Tracks.Items, "Album should have tracks");
        }

        [TestMethod, TestCategory("Anonymous")]
        public async Task TestBrowseTopTracks()
        {
            // Get popular tracks in France
            ContentResponse browseResults = await Client.BrowseAsync(Namespace.music, ContentSource.Catalog, ItemType.Tracks, country: "FR").Log();
            Assert.IsNotNull(browseResults, "The browse response should not be null");
            AssertPaginatedListIsValid(browseResults.Tracks, 25, 100);

            // Get popular pop tracks in the US
            ContentResponse browsePopResults = await Client.BrowseAsync(Namespace.music, ContentSource.Catalog, ItemType.Tracks, genre: "Pop", country: "US").Log();
            Assert.IsNotNull(browsePopResults, "The browse response should not be null");
            AssertPaginatedListIsValid(browsePopResults.Tracks, 25, 100);
        }

        [TestMethod, TestCategory("Anonymous")]
        public async Task TestBrowseArtistTopTracks()
        {
            const string daftPunkId = "music.C61C0000-0200-11DB-89CA-0019B92A3933";

            // Get Daft Punk's top 5 tracks in Germany
            ContentResponse browseResults =
                await
                    Client.SubBrowseAsync(daftPunkId, ContentSource.Catalog, BrowseItemType.Artist,
                    ExtraDetails.TopTracks, maxItems: 5, country: "DE").Log();
            Assert.IsNotNull(browseResults, "The browse response should not be null");
            AssertPaginatedListIsValid(browseResults.Artists.Items.First().TopTracks, 5, 50);
        }

        [TestMethod, TestCategory("Anonymous")]
        public async Task TestBrowseGenres()
        {
            // This test will fail if this computer's current geography is not valid for Xbox Music catalog content or
            // if the geography could not be determined by the service. Provide the "country" parameter if that is the case.

            // Get available genres in this computer's current geography
            ContentResponse genreResults = await Client.BrowseGenresAsync(Namespace.music).Log();
            Assert.IsNotNull(genreResults, "The browse response should not be null");
            Console.WriteLine("Culture: {0}", genreResults.Culture);
            Assert.IsNotNull(genreResults.Genres, "The browse response should contain genres");
            Assert.IsTrue(0 < genreResults.Genres.Count, "The browse response should contain at least one genre");
            Assert.IsNotNull(genreResults.Culture, "The genre response should contain the applicable culture");
        }
    }
}
