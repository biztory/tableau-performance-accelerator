using System;
using System.Collections.Generic;
using RestSharp;
using Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Client;

namespace Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IJobsTasksAndSchedulesApi
    {
        /// <summary>
        /// Returns status information about an asynchronous process. Jobs can be used to import users from Active Directory (the result of a call to Create Group) or synchronize an existing Tableau Server group with Active Directory (the result of a call to Update Group). ##### Permissions: This method can only be called by server administrators.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;job id&#x3D;\&quot;job-id\&quot; mode&#x3D;\&quot;job-mode\&quot; type&#x3D;\&quot;job-type\&quot;      progress&#x3D;\&quot;percent-completed\&quot;      createdAt&#x3D;\&quot;time-job-created\&quot;      updatedAt&#x3D;\&quot;time-job-last-updated\&quot;      completedAt&#x3D;\&quot;time-job-completed\&quot; &gt;      &lt;statusNotes&gt;        &lt;statusNote type&#x3D;\&quot;classifier\&quot;          value&#x3D;\&quot;value\&quot;          text&#x3D;\&quot;note\&quot; /&gt;        &lt;statusNote type&#x3D;\&quot;classifier\&quot;          value&#x3D;\&quot;value\&quot;          text&#x3D;\&quot;note\&quot; /&gt;        ... additional job notes ...      &lt;/statusNotes&gt;    &lt;/job&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site where the job is running.</param>
        /// <param name="jobId">The ID of the job to get status information for.</param>
        /// <returns></returns>
        void SitesSiteIdJobsJobIdGet (string siteId, string jobId);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class JobsTasksAndSchedulesApi : IJobsTasksAndSchedulesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobsTasksAndSchedulesApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public JobsTasksAndSchedulesApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="JobsTasksAndSchedulesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public JobsTasksAndSchedulesApi(String basePath)
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
        /// Returns status information about an asynchronous process. Jobs can be used to import users from Active Directory (the result of a call to Create Group) or synchronize an existing Tableau Server group with Active Directory (the result of a call to Update Group). ##### Permissions: This method can only be called by server administrators.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;job id&#x3D;\&quot;job-id\&quot; mode&#x3D;\&quot;job-mode\&quot; type&#x3D;\&quot;job-type\&quot;      progress&#x3D;\&quot;percent-completed\&quot;      createdAt&#x3D;\&quot;time-job-created\&quot;      updatedAt&#x3D;\&quot;time-job-last-updated\&quot;      completedAt&#x3D;\&quot;time-job-completed\&quot; &gt;      &lt;statusNotes&gt;        &lt;statusNote type&#x3D;\&quot;classifier\&quot;          value&#x3D;\&quot;value\&quot;          text&#x3D;\&quot;note\&quot; /&gt;        &lt;statusNote type&#x3D;\&quot;classifier\&quot;          value&#x3D;\&quot;value\&quot;          text&#x3D;\&quot;note\&quot; /&gt;        ... additional job notes ...      &lt;/statusNotes&gt;    &lt;/job&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site where the job is running.</param> 
        /// <param name="jobId">The ID of the job to get status information for.</param> 
        /// <returns></returns>            
        public void SitesSiteIdJobsJobIdGet (string siteId, string jobId)
        {
            
            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdJobsJobIdGet");
            
            // verify the required parameter 'jobId' is set
            if (jobId == null) throw new ApiException(400, "Missing required parameter 'jobId' when calling SitesSiteIdJobsJobIdGet");
            
    
            var path = "/sites/{site-id}/jobs/{job-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
path = path.Replace("{" + "job-id" + "}", ApiClient.ParameterToString(jobId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling SitesSiteIdJobsJobIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SitesSiteIdJobsJobIdGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
