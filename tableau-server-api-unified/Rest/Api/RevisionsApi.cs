using System;
using System.Collections.Generic;
using RestSharp;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Client;

namespace Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRevisionsApi
    {
        /// <summary>
        /// Returns a list of revision information (history) for the specified data source. Note: This method is available only if version history is enabled for the specified site. For more information, see Maintain a History of Revisions in the Tableau Server Help.  To get a specific version of the data source from revision history, use the Download Datasource Revision method.  ##### Permissions: Tableau Server users who are site administrators can get data source revisions on the site that they are administrators for. Users who are not server administrators or site administrators can get data source revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified data source. Save (write) permissions for the project that contains the data source.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot; pageSize&#x3D;\&quot;page-size\&quot;         totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;revisions&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;1\&quot; isDeleted&#x3D;\&quot;false\&quot;&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; name&#x3D;\&quot;user-name\&quot;/&gt;      &lt;/revision&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;2\&quot; isDeleted&#x3D;\&quot;false\&quot;&gt;      &lt;/revision&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;3\&quot; isCurrent&#x3D;\&quot;true\&quot;&gt;          &lt;user id&#x3D;\&quot;user-id\&quot; name&#x3D;\&quot;user-name\&quot;/&gt;      &lt;/revision&gt;    &lt;/revisions&gt;  &lt;/tsResponse&gt;isDeleted&#x3D;\&quot;true\&quot;&lt;user&gt;&lt;revision&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source to get revisions for.</param>
        /// <param name="datasourceId">The ID of the data source to get revisions for.</param>
        /// <returns></returns>
        void SitesSiteIdDatasourcesDatasourceIdRevisionsGet (string siteId, string datasourceId);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class RevisionsApi : IRevisionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RevisionsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public RevisionsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="RevisionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RevisionsApi(String basePath)
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
        /// Returns a list of revision information (history) for the specified data source. Note: This method is available only if version history is enabled for the specified site. For more information, see Maintain a History of Revisions in the Tableau Server Help.  To get a specific version of the data source from revision history, use the Download Datasource Revision method.  ##### Permissions: Tableau Server users who are site administrators can get data source revisions on the site that they are administrators for. Users who are not server administrators or site administrators can get data source revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified data source. Save (write) permissions for the project that contains the data source.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot; pageSize&#x3D;\&quot;page-size\&quot;         totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;revisions&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;1\&quot; isDeleted&#x3D;\&quot;false\&quot;&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; name&#x3D;\&quot;user-name\&quot;/&gt;      &lt;/revision&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;2\&quot; isDeleted&#x3D;\&quot;false\&quot;&gt;      &lt;/revision&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;3\&quot; isCurrent&#x3D;\&quot;true\&quot;&gt;          &lt;user id&#x3D;\&quot;user-id\&quot; name&#x3D;\&quot;user-name\&quot;/&gt;      &lt;/revision&gt;    &lt;/revisions&gt;  &lt;/tsResponse&gt;isDeleted&#x3D;\&quot;true\&quot;&lt;user&gt;&lt;revision&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source to get revisions for.</param> 
        /// <param name="datasourceId">The ID of the data source to get revisions for.</param> 
        /// <returns></returns>            
        public void SitesSiteIdDatasourcesDatasourceIdRevisionsGet (string siteId, string datasourceId)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdDatasourcesDatasourceIdRevisionsGet");
            
            // verify the required parameter 'datasourceId' is set
            if (datasourceId == null) throw new ApiException(400, "Missing required parameter 'datasourceId' when calling SitesSiteIdDatasourcesDatasourceIdRevisionsGet");
            
    
            var path = "/sites/{site-id}/datasources/{datasource-id}/revisions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
path = path.Replace("{" + "datasource-id" + "}", ApiClient.ParameterToString(datasourceId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdRevisionsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdRevisionsGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
