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
    public interface IServerApi
    {
        /// <summary>
        /// Returns the version of Tableau Server and the supported version of the REST API. ##### Permissions: This method can be called by all users and does not require authentication.  ##### Version: Version 2.4 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;     &lt;serverInfo&gt;          &lt;productVersion build&#x3D;\&quot;build-number\&quot;&gt;product-version&lt;/productVersion&gt;          &lt;restApiVersion&gt;api-version&lt;/restApiVersion&gt;      &lt;/serverInfo&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <returns>ServerInfoResponse</returns>
        ServerInfoResponse ServerinfoGet ();
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ServerApi : IServerApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public ServerApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ServerApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
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
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// Returns the version of Tableau Server and the supported version of the REST API. ##### Permissions: This method can be called by all users and does not require authentication.  ##### Version: Version 2.4 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;     &lt;serverInfo&gt;          &lt;productVersion build&#x3D;\&quot;build-number\&quot;&gt;product-version&lt;/productVersion&gt;          &lt;restApiVersion&gt;api-version&lt;/restApiVersion&gt;      &lt;/serverInfo&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <returns>ServerInfoResponse</returns>            
        public ServerInfoResponse ServerinfoGet ()
        {
            
    
            var path = "/serverinfo";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ServerinfoGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ServerinfoGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ServerInfoResponse) ApiClient.Deserialize(response.Content, typeof(ServerInfoResponse), response.Headers);
        }
    
    }
}
