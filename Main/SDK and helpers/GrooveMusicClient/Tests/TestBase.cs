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
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xbox.Music.Platform.Client;
using Microsoft.Xbox.Music.Platform.Contract.AuthenticationDataModel;
using Microsoft.Xbox.Music.Platform.Contract.DataModel;

namespace Tests
{
    public abstract class TestBase
    {
        protected static IXboxMusicClient Client { get; private set; }

        protected static IXboxMusicClient AuthenticatedClient
        {
            get
            {
                string xtoken = ConfigurationManager.AppSettings["xtoken"];
                if (String.IsNullOrEmpty(xtoken) || xtoken.Length < 20)
                {
                    Assert.Inconclusive("The XToken header value should be set in App.config for user authenticated tests");
                }
                return Client.CreateUserAuthenticatedClient(new TestXToken {AuthorizationHeaderValue = xtoken});
            }
        }

        // When implementing real calls, use a unique stable client instance id per client id.
        // See XboxMusicClientRtExtensions for an example when using Windows Runtime.
        protected static string ClientInstanceId { get { return "XboxMusicClientTests12345678901234567890"; } }

        static TestBase()
        {
            string clientid = ConfigurationManager.AppSettings["clientid"];
            string clientsecret = ConfigurationManager.AppSettings["clientsecret"];
            Assert.IsNotNull(clientid, "The client id should be set in App.config");
            Assert.IsNotNull(clientsecret, "The client secret should be set in App.config");
            Assert.IsFalse(clientsecret.Contains("%"), "The client secret should not be URL encoded");
            Client = XboxMusicClientFactory.CreateXboxMusicClient(clientid, clientsecret);
        }

        protected void AssertPaginatedListIsValid<TContent>(PaginatedList<TContent> list, int minItems,
            int? minTotalItems = null)
        {
            Assert.IsNotNull(list, "Results should contain " + typeof (TContent));
            Assert.IsNotNull(list.Items, "Results should contain " + typeof (TContent) + " items");
            Assert.IsTrue(minItems <= list.Items.Count,
                "Results should contain more than " + minItems + " " + typeof (TContent) + " items");
            if (minTotalItems != null)
                Assert.IsTrue(minTotalItems <= list.TotalItemCount,
                    "The total number of  " + typeof (TContent) + " should be greater than " + minTotalItems);
        }

        private class TestXToken : IXToken
        {
            public string AuthorizationHeaderValue { get; set; }
            public DateTime NotAfter { get; set; }
            public DateTime IssueInstant { get; set; }

            public Task<bool> RefreshAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(false);
            }
        }
    }
}
