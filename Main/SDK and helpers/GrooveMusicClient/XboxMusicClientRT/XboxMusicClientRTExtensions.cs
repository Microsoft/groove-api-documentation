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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.System.Profile;
using Microsoft.Xbox.Music.Platform.Client;
using Microsoft.Xbox.Music.Platform.Contract.DataModel;

namespace Microsoft.Xbox.Music.Platform.ClientRT
{
    /// <summary>
    /// Useful Windows Runtime specific extensions for the IXboxMusicClient
    /// </summary>
    public static class XboxMusicClientRtExtensions
    {
        private static readonly Lazy<string> clientInstanceId = new Lazy<string>(ComputeClientInstanceId);

        /// <summary>
        /// A valid clientInstanceId string. This string is specific to the current machine, user and application.
        /// </summary>
        public static string ClientInstanceId
        {
            get { return clientInstanceId.Value; }
        }

        /// <summary>
        /// Stream a media
        /// Access to this API is restricted under the terms of the Xbox Music API Pilot program (http://music.xbox.com/developer/pilot).
        /// </summary>
        /// <param name="client">An IXboxMusicClient instance to extend</param>
        /// <param name="id">Id of the media to be streamed</param>
        /// <returns>Stream response containing the url, expiration date and content type</returns>
        static public Task<StreamResponse> StreamAsync(this IXboxMusicClient client, string id)
        {
            return client.StreamAsync(id, ClientInstanceId);
        }

        /// <summary>
        /// Get a 30s preview of a media
        /// </summary>
        /// <param name="client">An IXboxMusicClient instance to extend</param>
        /// <param name="id">Id of the media to be streamed</param>
        /// <param name="country">ISO 2 letter code.</param>
        /// <returns>Stream response containing the url, expiration date and content type</returns>
        static public Task<StreamResponse> PreviewAsync(this IXboxMusicClient client, string id, string country = null)
        {
            return client.PreviewAsync(id, ClientInstanceId, country);
        }

        /// <summary>
        /// Compute a stable application specific client instance id string for use as "clientInstanceId" parameters in IXboxMusicClient
        /// </summary>
        /// <returns>A valid clientInstanceId string. This string is specific to the current machine, user and application.</returns>
        private static string ComputeClientInstanceId()
        {
            // Generate a somewhat stable application instance id
            HardwareToken ashwid = HardwareIdentification.GetPackageSpecificToken(null);
            byte[] id = ashwid.Id.ToArray();
            string idstring = Package.Current.Id.Name + ":";
            for (int i = 0; i < id.Length; i += 4)
            {
                short what = BitConverter.ToInt16(id, i);
                short value = BitConverter.ToInt16(id, i + 2);
                // Only include stable components in the id
                // http://msdn.microsoft.com/en-us/library/windows/apps/jj553431.aspx
                const int cpuId = 1;
                const int memorySize = 2;
                const int diskSerial = 3;
                const int bios = 9;
                if (what == cpuId || what == memorySize || what == diskSerial || what == bios)
                {
                    idstring += value.ToString("X4");
                }
            }
            return idstring.PadRight(32, 'X');
        }
    }
}
