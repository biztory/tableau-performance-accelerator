using System;
using System.Collections.Generic;
using RestSharp;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Client;

namespace Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IPublishingApi
    {
        /// <summary>
        /// Initiates the upload process for a file. After the upload has been initiated, you call Append to File Upload to send individual blocks of the file to the server. When the complete file has been sent to the server, you call Publish Datasource or Publish Workbook to commit the upload. Initiate File Upload returns an upload session ID that you pass to Append to File Upload or one of the publishing methods in order to identify the upload session.  The file size that is returned in the response is initialized to zero (0) megabytes, because no data has yet been loaded. Subsequent calls to Append to File Upload or the publishing APIs update this value.  For more information, see Publishing Resources.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can initiate a file upload only if they have publishing rights on the site.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;fileUpload uploadSessionId&#x3D;new-upload-session-id       fileSize&#x3D;0 /&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site to upload the file to.</param>
        /// <returns></returns>
        void SitesSiteIdFileUploadsPost (string siteId);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PublishingApi : IPublishingApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublishingApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public PublishingApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="PublishingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PublishingApi(String basePath)
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
        /// Initiates the upload process for a file. After the upload has been initiated, you call Append to File Upload to send individual blocks of the file to the server. When the complete file has been sent to the server, you call Publish Datasource or Publish Workbook to commit the upload. Initiate File Upload returns an upload session ID that you pass to Append to File Upload or one of the publishing methods in order to identify the upload session.  The file size that is returned in the response is initialized to zero (0) megabytes, because no data has yet been loaded. Subsequent calls to Append to File Upload or the publishing APIs update this value.  For more information, see Publishing Resources.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can initiate a file upload only if they have publishing rights on the site.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;fileUpload uploadSessionId&#x3D;new-upload-session-id       fileSize&#x3D;0 /&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site to upload the file to.</param> 
        /// <returns></returns>            
        public void SitesSiteIdFileUploadsPost (string siteId)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdFileUploadsPost");
            
    
            var path = "/sites/{site-id}/fileUploads";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SitesSiteIdFileUploadsPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SitesSiteIdFileUploadsPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
