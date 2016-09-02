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

namespace Tests
{
    [TestClass]
    public class Stream : TestBase
    {
        [TestMethod, TestCategory("Anonymous")]
        public async Task TestPreview()
        {
            // Get popular tracks in Great Britain
            ContentResponse browseResults = await Client.BrowseAsync(Namespace.music, ContentSource.Catalog, ItemType.Tracks, country: "GB").Log();
            Assert.IsNotNull(browseResults, "The browse response should not be null");
            AssertPaginatedListIsValid(browseResults.Tracks, 25, 100);

            // Request a preview stream URL for the first one
            Track track = browseResults.Tracks.Items.First();
            StreamResponse streamResponse = await Client.PreviewAsync(track.Id, ClientInstanceId, country: "GB").Log();
            Assert.IsNotNull(streamResponse, "The preview stream URL response should not be null");
            Assert.IsNotNull(streamResponse.Url, "The preview stream URL should not be null");
            Assert.IsNotNull(streamResponse.ContentType, "The preview stream content type should not be null");
        }

        [TestMethod, TestCategory("Authenticated")]
        public async Task TestStream()
        {
            // Check that the user has an Xbox Music Pass subscription
            UserProfileResponse userProfileResponse = await AuthenticatedClient.GetUserProfileAsync(Namespace.music).Log();
            // Beware: HasSubscription is bool?. You want != true instead of == false
            if (userProfileResponse.HasSubscription != true)
            {
                Assert.Inconclusive("The user doesn't have an Xbox Music Pass subscription. Cannot stream from catalog.");
            }

            // Get popular tracks in the user's country
            ContentResponse browseResults = await AuthenticatedClient.BrowseAsync(Namespace.music, ContentSource.Catalog, ItemType.Tracks).Log();
            Assert.IsNotNull(browseResults, "The browse response should not be null");
            AssertPaginatedListIsValid(browseResults.Tracks, 25, 100);

            // Stream the first streamable track
            Track track = browseResults.Tracks.Items.First(t => t.Rights.Contains("Stream"));
            StreamResponse streamResponse = await AuthenticatedClient.StreamAsync(track.Id, ClientInstanceId).Log();
            Assert.IsNotNull(streamResponse, "The stream URL response should not be null");
            Assert.IsNotNull(streamResponse.Url, "The stream URL should not be null");
            Assert.IsNotNull(streamResponse.ContentType, "The stream content type should not be null");
            Assert.IsNotNull(streamResponse.ExpiresOn, "The stream expiry date should not be null");
        }
    }
}
