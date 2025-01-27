// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Administration
{
    /// <summary> The PurviewMetadataRoles service client. </summary>
    public partial class PurviewMetadataRolesClient
    {
        private static readonly string[] AuthorizationScopes = new string[] { "https://purview.azure.net/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PurviewMetadataRolesClient for mocking. </summary>
        protected PurviewMetadataRolesClient()
        {
        }

        /// <summary> Lists roles for Purview Account. </summary>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   values: [
        ///     {
        ///       id: string,
        ///       name: string,
        ///       type: string,
        ///       properties: {
        ///         provisioningState: string,
        ///         roleType: string,
        ///         friendlyName: string,
        ///         description: string,
        ///         cnfCondition: [AttributeMatcher[]],
        ///         dnfCondition: [AttributeMatcher[]],
        ///         version: number
        ///       }
        ///     }
        ///   ],
        ///   nextLink: string
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorModelAutoGenerated]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual AsyncPageable<BinaryData> GetMetadataRolesAsync(RequestContext context = null)
#pragma warning restore AZC0002
        {
            return PageableHelpers.CreateAsyncPageable(CreateEnumerableAsync, ClientDiagnostics, "PurviewMetadataRolesClient.GetMetadataRoles");
            async IAsyncEnumerable<Page<BinaryData>> CreateEnumerableAsync(string nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                do
                {
                    var message = string.IsNullOrEmpty(nextLink)
                        ? CreateGetMetadataRolesRequest(context)
                        : CreateGetMetadataRolesNextPageRequest(nextLink, context);
                    var page = await LowLevelPageableHelpers.ProcessMessageAsync(_pipeline, message, context, "value", "nextLink", cancellationToken).ConfigureAwait(false);
                    nextLink = page.ContinuationToken;
                    yield return page;
                } while (!string.IsNullOrEmpty(nextLink));
            }
        }

        /// <summary> Lists roles for Purview Account. </summary>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   values: [
        ///     {
        ///       id: string,
        ///       name: string,
        ///       type: string,
        ///       properties: {
        ///         provisioningState: string,
        ///         roleType: string,
        ///         friendlyName: string,
        ///         description: string,
        ///         cnfCondition: [AttributeMatcher[]],
        ///         dnfCondition: [AttributeMatcher[]],
        ///         version: number
        ///       }
        ///     }
        ///   ],
        ///   nextLink: string
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorModelAutoGenerated]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Pageable<BinaryData> GetMetadataRoles(RequestContext context = null)
#pragma warning restore AZC0002
        {
            return PageableHelpers.CreatePageable(CreateEnumerable, ClientDiagnostics, "PurviewMetadataRolesClient.GetMetadataRoles");
            IEnumerable<Page<BinaryData>> CreateEnumerable(string nextLink, int? pageSizeHint)
            {
                do
                {
                    var message = string.IsNullOrEmpty(nextLink)
                        ? CreateGetMetadataRolesRequest(context)
                        : CreateGetMetadataRolesNextPageRequest(nextLink, context);
                    var page = LowLevelPageableHelpers.ProcessMessage(_pipeline, message, context, "value", "nextLink");
                    nextLink = page.ContinuationToken;
                    yield return page;
                } while (!string.IsNullOrEmpty(nextLink));
            }
        }

        internal HttpMessage CreateGetMetadataRolesRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/policyStore", false);
            uri.AppendPath("/metadataRoles", false);
            uri.AppendQuery("api-version", "2021-07-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetMetadataRolesNextPageRequest(string nextLink, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/policyStore", false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        private sealed class ResponseClassifier200 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier200();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    200 => false,
                    _ => true
                };
            }
        }
    }
}
