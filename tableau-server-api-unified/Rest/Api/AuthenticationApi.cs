using System;
using System.Collections.Generic;
using RestSharp;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Client;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Model;

namespace Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAuthenticationApi
    {
        /// <summary>
        /// Signs you in as a user on the specified site on Tableau Server. This call returns an authentication token that you use in subsequent calls to the server. By default, the authentication token is good for 240 minutes. You can change this timeout by using the tabadmin set command and setting the wgserver.session.idle_limit option.  Note: The token is valid only for REST API calls. You cannot use the token as authentication for other operations with Tableau Server. In addition, the token is good only for operations in the site that you&#39;re signed in to. You cannot sign in to one site and then use the token you get back to send requests to a different site. If you do, the server returns an HTTP 403 (Forbidden) error.  You can sign in and impersonate a specific user. You might do this if you want manage sign in using a centralized delegation strategy.  Note: When you use the REST API, you cannot use SAML single sign-on (SSO), even if the server is configured to use SAML. To sign in, you must pass the user name and password of a user who has been created on the server. You will have the permissions of the Tableau Server user that you&#39;re signed in as.  ##### Permissions: Tableau Server users who are not server administrators can sign in. In that case, the user might have limited permissions to perform subsequent operations.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;credentials name&#x3D;\&quot;username\&quot; password&#x3D;\&quot;password\&quot; &gt;      &lt;site contentUrl&#x3D;\&quot;content-url\&quot; /&gt;    &lt;/credentials&gt;  &lt;/tsRequest&gt;&lt;tsRequest&gt;    &lt;credentials name&#x3D;\&quot;username\&quot; password&#x3D;\&quot;password\&quot; &gt;      &lt;site contentUrl&#x3D;\&quot;content-url\&quot; /&gt;      &lt;user id&#x3D;\&quot;user-to-impersonate\&quot; /&gt;    &lt;/credentials&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;credentials token&#x3D;\&quot;authentication-token\&quot; &gt;      &lt;site id&#x3D;\&quot;site-id\&quot; contentUrl&#x3D;\&quot;content-url\&quot; /&gt;      &lt;user id&#x3D;\&quot;user-id-of-signed-in-user\&quot; /&gt;    &lt;/credentials&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;https://MY-SERVER/api/2.5/auth/signin\&quot; -X POST -d @signin.xml&lt;tsRequest&gt;    &lt;credentials name&#x3D;\&quot;admin\&quot; password&#x3D;\&quot;admin\&quot; &gt;      &lt;site contentUrl&#x3D;\&quot;MarketingSite\&quot; /&gt;    &lt;/credentials&gt;  &lt;/tsRequest&gt;&lt;tsResponse version-and-namespace-settings&gt;    &lt;credentials token&#x3D;\&quot;12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&gt;      &lt;site id&#x3D;\&quot;9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d\&quot;            contentUrl&#x3D;\&quot;MarketingSite\&quot;/&gt;    &lt;/credentials&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="signInRequest">SignInRequest</param>
        /// <returns>SignInResponse</returns>
        SignInResponse AuthSigninPost(SignInRequest signInRequest);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthenticationApi : IAuthenticationApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AuthenticationApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthenticationApi(String basePath)
        {
            UriBuilder serverApiUri = new UriBuilder(basePath);
            serverApiUri.Path = "/api/2.8";

            this.ApiClient = new ApiClient(serverApiUri.ToString());
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Signs you in as a user on the specified site on Tableau Server. This call returns an authentication token that you use in subsequent calls to the server. By default, the authentication token is good for 240 minutes. You can change this timeout by using the tabadmin set command and setting the wgserver.session.idle_limit option.  Note: The token is valid only for REST API calls. You cannot use the token as authentication for other operations with Tableau Server. In addition, the token is good only for operations in the site that you&#39;re signed in to. You cannot sign in to one site and then use the token you get back to send requests to a different site. If you do, the server returns an HTTP 403 (Forbidden) error.  You can sign in and impersonate a specific user. You might do this if you want manage sign in using a centralized delegation strategy.  Note: When you use the REST API, you cannot use SAML single sign-on (SSO), even if the server is configured to use SAML. To sign in, you must pass the user name and password of a user who has been created on the server. You will have the permissions of the Tableau Server user that you&#39;re signed in as.  ##### Permissions: Tableau Server users who are not server administrators can sign in. In that case, the user might have limited permissions to perform subsequent operations.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;credentials name&#x3D;\&quot;username\&quot; password&#x3D;\&quot;password\&quot; &gt;      &lt;site contentUrl&#x3D;\&quot;content-url\&quot; /&gt;    &lt;/credentials&gt;  &lt;/tsRequest&gt;&lt;tsRequest&gt;    &lt;credentials name&#x3D;\&quot;username\&quot; password&#x3D;\&quot;password\&quot; &gt;      &lt;site contentUrl&#x3D;\&quot;content-url\&quot; /&gt;      &lt;user id&#x3D;\&quot;user-to-impersonate\&quot; /&gt;    &lt;/credentials&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;credentials token&#x3D;\&quot;authentication-token\&quot; &gt;      &lt;site id&#x3D;\&quot;site-id\&quot; contentUrl&#x3D;\&quot;content-url\&quot; /&gt;      &lt;user id&#x3D;\&quot;user-id-of-signed-in-user\&quot; /&gt;    &lt;/credentials&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;https://MY-SERVER/api/2.5/auth/signin\&quot; -X POST -d @signin.xml&lt;tsRequest&gt;    &lt;credentials name&#x3D;\&quot;admin\&quot; password&#x3D;\&quot;admin\&quot; &gt;      &lt;site contentUrl&#x3D;\&quot;MarketingSite\&quot; /&gt;    &lt;/credentials&gt;  &lt;/tsRequest&gt;&lt;tsResponse version-and-namespace-settings&gt;    &lt;credentials token&#x3D;\&quot;12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&gt;      &lt;site id&#x3D;\&quot;9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d\&quot;            contentUrl&#x3D;\&quot;MarketingSite\&quot;/&gt;    &lt;/credentials&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="signInRequest">SignInRequest</param> 
        /// <returns>SignInResponse</returns>            
        public SignInResponse AuthSigninPost(SignInRequest signInRequest)
        {
            // verify the required parameter 'signInRequest' is set
            if (signInRequest == null) throw new ApiException(400, "Missing required parameter 'signInRequest' when calling AuthSigninPost");

            var path = "/auth/signin";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(signInRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling AuthSigninPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling AuthSigninPost: " + response.ErrorMessage, response.ErrorMessage);

            // TODO: Figure out how to make the SwaggerBot generator inject this line automatically
            var token = (ApiClient.Deserialize(response.Content, typeof(SignInResponse), response.Headers) as SignInResponse).Credentials.Token;

            if (token != null)
            {
                // Static value, left in to avoid breaking stuff.
                Configuration.ApiKey["X-Tableau-Auth"] = token;
                // Instance value
                ApiClient.TableauAuthToken = token;

            } else
            {
                throw new NullReferenceException("No authentication token was included in the sign-in response.");
            }


            return (SignInResponse)ApiClient.Deserialize(response.Content, typeof(SignInResponse), response.Headers);
        }

    }
}
