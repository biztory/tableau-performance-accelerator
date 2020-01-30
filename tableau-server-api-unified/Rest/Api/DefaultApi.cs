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
    public interface IDefaultApi
    {
        /// <summary>
        /// Signs you out of the current session. This call invalidates the authentication token that is created by a call to Sign In. ##### Permissions: Any user can call this method.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/auth/signout\&quot; -X POST -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <returns></returns>
        void AuthSignoutPost();
        /// <summary>
        /// Creates a new schedule on Tableau Server. Schedules are not specific to sites. For more information, see Scheduled Refresh Tasks and Subscriptions and Create or Modify a Schedule in the Tableau Server documentation.  Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.
        /// </summary>
        /// <param name="createScheduleRequest">CreateScheduleRequest</param>
        /// <returns></returns>
        void SchedulesPost(CreateScheduleRequest createScheduleRequest);
        /// <summary>
        /// Deletes the specified schedule. ##### Permissions: This method can only be called by server administrators.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="scheduleId">The ID of the schedule to delete. To determine what schedules are available, call Query Schedules.</param>
        /// <returns></returns>
        void SchedulesScheduleIdDelete(string scheduleId);
        /// <summary>
        /// Modifies settings for the specified schedule, including the name, priority, and frequency details. 
        /// </summary>
        /// <param name="scheduleId">The ID of the schedule to update. To determine what schedules are available, call Query Schedules.</param>
        /// <param name="updateScheduleRequest">UpdateScheduleRequest</param>
        /// <returns></returns>
        void SchedulesScheduleIdPut(string scheduleId, UpdateScheduleRequest updateScheduleRequest);
        /// <summary>
        /// Deletes the specified site. You can specify the site to delete by using the site ID, the site name, or the content URL. You use the key query string parameter to indicate how you are specifying the site, as shown in the URIs.  Note: You must have previously called Sign In and signed in to a site in order to delete the site. (When you call this method, you must include the authentication token that you got back when you signed into the site.)  ##### Permissions: This method can only be called by server administrators.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d5-e4f3-a2b1-c0d9-e8f7a6b5c4d\&quot; -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;curl \&quot;http://MY-SERVER/api/2.5/sites/marketing-site?key&#x3D;contentUrl\&quot; -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="contentUrlORSiteIdORSiteName">In case of content-url parameter: The URL of the site to delete. If you specify a content URL, you must also include the parameter key&#x3D;contentUrl.  In case of site-name parameter: The name of the site to delete. If you specify a site name, you must also include the parameter key&#x3D;name.  In case of site-id parameter: The ID of the site to delete.</param>
        /// <returns></returns>
        void SitesContentUrlORSiteIdORSiteNameDelete(string contentUrlORSiteIdORSiteName);
        /// <summary>
        /// Modifies settings for the specified site, including the content URL, administration mode, user quota, state (active or suspended), storage quota, whether subscriptions are enabled, and whether revisions are enabled. If you&#39;re working with Tableau Online, this method can also be used to upload a new logo image for the site. 
        /// </summary>
        /// <param name="contentUrlORSiteIdORSiteName">The ID of the site to update.</param>
        /// <param name="updateSiteRequest">UpdateSiteRequest</param>
        /// <returns></returns>
        void SitesContentUrlORSiteIdORSiteNamePut(string contentUrlORSiteIdORSiteName, UpdateSiteRequest updateSiteRequest);
        /// <summary>
        /// Creates a site on Tableau Server. To make changes to an existing site, call Update Site. For more information, see Work with Sites and Add or Edit Sites in the Tableau Server documentation.  Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.
        /// </summary>
        /// <param name="createSiteRequest">CreateSiteRequest</param>
        /// <returns></returns>
        void SitesPost(CreateSiteRequest createSiteRequest);
        /// <summary>
        /// Updates the server address, port, username, or password for the specified data source connection. Note Starting with Tableau Server 10.0, data sources can have multiple connections. This method can be used to update a specific connection in a data source. If the data source was created in Tableau 9.3 or earlier, the previous syntax for this method (without /connections/connection-id in the URI) will work. However, we recommend that you use the syntax documented here for all data sources.  ##### Permissions: Only Tableau Server users who are server administrators or site administrators can change the connection for a data source. Users who are not server administrators can update a data source only if they have Write (save) permission for the data source and if they have write permission for the project.  ##### Version: Version 2.3 and later. (A different version of this method was available in earlier versions of the REST API. For details, see Update Datasource Connection in the REST API version 9.3 documentation.) For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;connection      serverAddress&#x3D;\&quot;server-address\&quot; serverPort&#x3D;\&quot;port\&quot;      userName&#x3D;\&quot;connection-username\&quot; password&#x3D;\&quot;connection-password\&quot;       embedPassword&#x3D;\&quot;embed-password\&quot;  /&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;connection id&#x3D;\&quot;connection-id\&quot;      serverAddress&#x3D;\&quot;serverAddress\&quot; serverPort&#x3D;\&quot;port\&quot;      userName&#x3D;\&quot;connection-user-name\&quot; /&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param>
        /// <param name="datasourceId">The ID of the data source to update.</param>
        /// <param name="connectionId">The ID of the connection to update. To determine what connections are available for a data source, call Query Datasource Connections.</param>
        /// <param name="updateDatasourceConnectionRequest">UpdateDatasourceConnectionRequest</param>
        /// <returns></returns>
        void SitesSiteIdDatasourcesDatasourceIdConnectionsConnectionIdPut(string siteId, string datasourceId, string connectionId, UpdateDatasourceConnectionRequest updateDatasourceConnectionRequest);
        /// <summary>
        /// Returns a list of data connections for the specified data source. ##### Permissions: Tableau Server users who are not server administrators or site administrators can query a data source only if they have Read (view) permission for the data source (either explicitly or implicitly).  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;connections&gt;      &lt;connection id&#x3D;\&quot;connection-id\&quot; type&#x3D;\&quot;connection-type\&quot;        serverAddress&#x3D;\&quot;server-address\&quot; serverPort&#x3D;\&quot;port\&quot;        userName&#x3D;\&quot;connection-user-name\&quot; /&gt;      ... additional connections ...    &lt;/connections&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/datasources/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/connections\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;connections&gt;      &lt;connection id&#x3D;\&quot;12ab34cd-56ef-78ab-90cd-12ef34ab56cd\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;374371c0-ffe9-4e16-b48e-6b868e3026ca\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;08a7b6b5-b4ba-be3a-4d2d-1e9e59a8a7b6\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;    &lt;/connections&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param>
        /// <param name="datasourceId">The ID of the datasource to return connection information about.</param>
        /// <returns></returns>
        void SitesSiteIdDatasourcesDatasourceIdConnectionsGet(string siteId, string datasourceId);
        /// <summary>
        /// Downloads a data source in .tdsx format. ##### Permissions: Tableau Server users who are not server administrators or site administrators can download a data source only if they have ExportXml permission for the data source (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; .tdsxContent-Type:  application/octet-streamContent-Disposition: name&#x3D;\&quot;tableau_datasource\&quot;; filename&#x3D;\&quot;datasource-filename\&quot;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/datasources/1a2a3b4b-5c6c-7d8d-9e0e-1f2f3a4a5b6b/content\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot; &gt; my-datasource.tdsx  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param>
        /// <param name="datasourceId">The ID of the data source to download.</param>
        /// <param name="extractValue">(Optional) The extract-value is a Boolean value (False or True). When the data source specified for download has an extract, if you add the parameter ?includeExtract&#x3D;False, the extract is not included when you download the data source. You can use this parameter to improve performance if you are downloading workbooks or data sources that have large extracts.</param>
        /// <returns></returns>
        void SitesSiteIdDatasourcesDatasourceIdContentGet(string siteId, string datasourceId, string extractValue);
        /// <summary>
        /// Adds permissions to the specified data source for a Tableau Server user or group. You can specify multiple sets of permissions using one call. If a specified permission has already been granted or denied for a given user or group, the system ignores it. If the request body includes a child workbook or &lt;project&gt; element, the request is invalid. ##### Permissions: Tableau Server users who are not server administrators or site administrators can add permissions only to a data source for which they have ChangePermissions permission (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability-name\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability-name\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capability sets ...    &lt;/permissions&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capability sets ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param>
        /// <param name="datasourceId">The ID of the data source to set permissions for.</param>
        /// <param name="addDatasourcePermissionRequest">AddDatasourcePermissionRequest</param>
        /// <returns>AddDatasourcePermissionsResponse</returns>
        AddDatasourcePermissionsResponse SitesSiteIdDatasourcesDatasourceIdPermissionsPut(string siteId, string datasourceId, AddDatasourcePermissionRequest addDatasourcePermissionRequest);
        /// <summary>
        /// Updates the owner, or project of the specified data source. 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param>
        /// <param name="datasourceId">The ID of the data source to update.</param>
        /// <param name="updateDatasourceRequest">UpdateDatasourceRequest</param>
        /// <returns></returns>
        void SitesSiteIdDatasourcesDatasourceIdPut(string siteId, string datasourceId, UpdateDatasourceRequest updateDatasourceRequest);
        /// <summary>
        /// Downloads a specific version of a data source in .tdsx format. Note: This method is available only if version history is enabled for the specified site. For more information, see Maintain a History of Revisions in the Tableau Server Help.  ##### Permissions: Tableau Server users who are site administrators can download data source revisions on the site that they are administrators for. Users who are not server administrators or site administrators can get data source revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified data source. Save (write) permissions for the project that contains the data source.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; .tdsxContent-Type:  application/octet-streamContent-Disposition: name&#x3D;\&quot;tableau_datasource\&quot;; filename&#x3D;\&quot;datasource-filename\&quot;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param>
        /// <param name="datasourceId">The ID of the data source to download.</param>
        /// <param name="revisionNumber">The revision number of the data source to download. To determine what versions are available, call Get Datasource Revisions.</param>
        /// <param name="extractValue">(Optional) The extract-value is a Boolean value (False or True). When the data source specified for download has an extract, if you add the parameter ?includeExtract&#x3D;False, the extract is not included when you download the data source. You can use this parameter to improve performance if you are downloading workbooks or data sources that have large extracts.</param>
        /// <returns></returns>
        void SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberContentGet(string siteId, string datasourceId, string revisionNumber, string extractValue);
        /// <summary>
        /// Removes a specific version of a data source from the specified site. The content is removed, and the specified revision can no longer be downloaded using Download Datasource Revision. If you call Get Datasource Revisions, the revision that&#39;s been removed is listed with the attribute IsDeleted&#x3D;\&quot;true\&quot;.  Note: Calling this method permanently removes the specified datasource revision.  ##### Permissions: Tableau Server users who are site administrators can remove data source revisions on the site that they are administrators for. Users who are not server administrators or site administrators can remove data source revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified data source. Save (write) permissions for the project that contains the data source.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the group.</param>
        /// <param name="datasourceId">The ID of the data source to remove the revision for.</param>
        /// <param name="revisionNumber">The revision number of the data source to remove. To determine what versions are available, call Get Datasource Revisions.</param>
        /// <returns></returns>
        void SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberDelete(string siteId, string datasourceId, string revisionNumber);
        /// <summary>
        /// Returns a list of data sources on the specified site, with optional parameters for specifying the paging of large results. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can view a data source only if they have Connect permission for the data source (either explicitly or implicitly).  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot; pageSize&#x3D;\&quot;page-size\&quot;      totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;datasources&gt;      &lt;datasource id&#x3D;\&quot;datasource1-id\&quot;        name&#x3D;\&quot;datasource-name\&quot;        contentUrl&#x3D;\&quot;datasource-content-url\&quot;        type&#x3D;\&quot;datasource-type\&quot;         createdAt&#x3D;\&quot;datetime-created\&quot;        updatedAt&#x3D;\&quot;datetime-updated\&quot;&gt;        &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;        &lt;owner id&#x3D;\&quot;datasource-owner-id\&quot; /&gt;        &lt;tags&gt;         &lt;tag label&#x3D;\&quot;tag\&quot;/&gt;         ... additional tags ...        &lt;/tags&gt;      &lt;/datasource&gt;      ... additional datasources ...    &lt;/datasources&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/datasources\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot;/&gt;    &lt;datasources&gt;      &lt;datasource id&#x3D;\&quot;1a2a3b4b-5c6c-7d8d-9e0e-1f2f3a4a5b6b\&quot;           name&#x3D;\&quot;Sample - Coffee Chain (Access)\&quot; contentUrl&#x3D;\&quot;coffee-chain\&quot;  type&#x3D;\&quot;msaccess\&quot;            createdAt&#x3D;\&quot;2011-03-30T22:32:35Z\&quot; updatedAt&#x3D;\&quot;2016-01-13T01:00:02Z\&quot;&gt;        &lt;project id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; name&#x3D;\&quot;Default\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;        &lt;/tags&gt;      &lt;/datasource&gt;      &lt;datasource id&#x3D;\&quot;9f8e7d6c-5b4a-3f2e-1d0c-9b8a7f6e5d4c\&quot;            name&#x3D;\&quot;Activity rates and healthy living\&quot; contentUrl&#x3D;\&quot;activity-rates-and-healthy-living\&quot; type&#x3D;\&quot;excel-direct\&quot;            createdAt&#x3D;\&quot;2011-03-30T22:32:35Z\&quot; updatedAt&#x3D;\&quot;2016-01-13T01:00:02Z\&quot;&gt;        &lt;project id&#x3D;\&quot;12ab34cd-56ef-78ab-90cd-12ef34ab56cd\&quot; name&#x3D;\&quot;Default\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;        &lt;/tags&gt;      &lt;/datasource&gt;    &lt;/datasources&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data sources.</param>
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   type: eq   siteRole: eq   tags: eq, in </param>
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  type  siteRole  tags</param>
        /// <returns></returns>
        void SitesSiteIdDatasourcesGet(string siteId, string filter, string sort);
        /// <summary>
        /// Deletes the specified data source from the user&#39;s favorites. If the specified data source is not a favorite, the operation has no effect. ##### Permissions: Tableau Server users who are not server administrators or site administrators can call this method only if they have Read (view) permissions on the data source (either explicitly or implicitly).  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param>
        /// <param name="userId">The ID of the user to remove the favorite from.</param>
        /// <param name="datasourceId">The ID of the data source to remove from the user&#39;s favorites.</param>
        /// <returns></returns>
        void SitesSiteIdFavoritesUserIdDatasourcesDatasourceIdDelete(string siteId, string userId, string datasourceId);
        /// <summary>
        /// Adds the specified view/datasource/workbook to a user&#39;s favorites. If the user already has the view listed as a favorite with the same label, the operation has no effect. If the label differs, the original favorite is overwritten.
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the view.</param>
        /// <param name="userId">The ID of the user to add the favorite for.</param>
        /// <param name="addToFavoritesRequest">AddToFavoritesRequest</param>
        /// <returns></returns>
        void SitesSiteIdFavoritesUserIdPut(string siteId, string userId, AddToFavoritesRequest addToFavoritesRequest);
        /// <summary>
        /// Deletes the specified view from user&#39;s favorites. If the specified view is not a favorite, the operation has no effect. ##### Permissions: Tableau Server users who are not server administrators or site administrators can delete a view only from their own favorites.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the view.</param>
        /// <param name="userId">The ID of the user to remove the favorite from.</param>
        /// <param name="viewId">The ID of the view to remove from the user&#39;s favorites.</param>
        /// <returns></returns>
        void SitesSiteIdFavoritesUserIdViewsViewIdDelete(string siteId, string userId, string viewId);
        /// <summary>
        /// Deletes a workbook from a user&#39;s favorites. If the specified workbook is not a favorite of the specified user, this call has no effect. ##### Permissions: Tableau Server users who are not server administrators or site administrators can remove a workbook only from their own favorites.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the user.</param>
        /// <param name="userId">The ID of the user to remove the favorite from.</param>
        /// <param name="workbookId">The ID of the workbook to remove from the user&#39;s favorites.</param>
        /// <returns></returns>
        void SitesSiteIdFavoritesUserIdWorkbooksWorkbookIdDelete(string siteId, string userId, string workbookId);
        /// <summary>
        /// Uploads a block of data and appends it to the data that is already uploaded. This method is called after an upload has been initiated using Initiate File Upload. You call Append to File Upload as many times as needed in order to upload the complete contents of a file. When the final block of data has been uploaded, you call Publish Datasource or Publish Workbook to commit the file.  For more information, see Publishing Resources.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can call this method only if they have publishing rights on the site.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;fileUpload uploadSessionId&#x3D;upload-session-id                fileSize&#x3D;size-of-file-in-megabytes-after-append /&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site to upload the file to.</param>
        /// <param name="uploadSessionId">The ID of the upload session. You get this value when you start an upload session using Initiate File Upload.</param>
        /// <returns></returns>
        void SitesSiteIdFileUploadsUploadSessionIdPut(string siteId, string uploadSessionId);
        /// <summary>
        /// Deletes the group on a specific site. Deleting a group does not delete the users in group, but users are no longer members of the group. Any permissions that were previously assigned to the group no longer apply. Note: You cannot delete the All Users group.  ##### Permissions: This method can be called by site administrators.  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/groups/1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d\&quot;  -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="groupId">The ID of the group to delete.</param>
        /// <returns></returns>
        void SitesSiteIdGroupsGroupIdDelete(string siteId, string groupId);
        /// <summary>
        /// Gets a list of users in the specified group. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot;             pageSize&#x3D;\&quot;page-size\&quot;             totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;      &lt;users&gt;        &lt;user id&#x3D;\&quot;user-id\&quot;      name&#x3D;\&quot;user-name\&quot;      siteRole&#x3D;\&quot;site-role\&quot;      lastLogin&#x3D;\&quot;last-login-date-time\&quot;      externalAuthUserId&#x3D;\&quot;authentication-id-from-external-provider\&quot; /&gt;      ... additional user information ...     &lt;/users&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/groups/1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d/users\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot;/&gt;    &lt;users&gt;      &lt;user id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot; name&#x3D;\&quot;Adam\&quot; siteRole&#x3D;\&quot;Interactor\&quot; /&gt;      &lt;user id&#x3D;\&quot;59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba\&quot; name&#x3D;\&quot;Bob\&quot; siteRole&#x3D;\&quot;Publisher\&quot; /&gt;    &lt;/users&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the group.</param>
        /// <param name="groupId">The ID of the group to get the users for.</param>
        /// <param name="pageSize">(Optional) The number of items to return in one response. The minimum is 1. The maximum is 1000. The default is 100. For more information, see Paginating Results.</param>
        /// <param name="pageNumber">(Optional) The offset for paging. The default is 1. For more information, see Paginating Results.</param>
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   lastLogin: eq, gt, gte, lte   name: eq   siteRole: eq </param>
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: lastLogin  name  siteRole</param>
        /// <returns></returns>
        void SitesSiteIdGroupsGroupIdUsersGet(string siteId, string groupId, string pageSize, string pageNumber, string filter, string sort);
        /// <summary>
        /// Adds a user to the specified group. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the group.</param>
        /// <param name="groupId">The ID of the group to add the user to.</param>
        /// <param name="addUserToGroupRequest">AddUserToGroupRequest</param>
        /// <returns></returns>
        void SitesSiteIdGroupsGroupIdUsersPut(string siteId, string groupId, AddUserToGroupRequest addUserToGroupRequest);
        /// <summary>
        /// Removes a user from the specified group. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/groups/1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d/users/9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot; -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the group.</param>
        /// <param name="groupId">The ID of the group to remove the user from.</param>
        /// <param name="userId">The ID of the user to remove.</param>
        /// <returns></returns>
        void SitesSiteIdGroupsGroupIdUsersUserIdDelete(string siteId, string groupId, string userId);
        /// <summary>
        /// Creates a group in Tableau Server. If the server is configured to use Active Directory for authentication, this method can create a group in Tableau Server and then import users from an Active Directory group. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  To add users to a group, call Add User To Group. To make changes to an existing group, call Update Group.  If you use the method to import users from an Active Directory, the import process can be performed immediately (synchronously) or as a background job (asynchronously).  Note: If Active Directory contains a large number of users, you should import them asynchronously; otherwise, the process can time out.  The Create Group response returns information in two ways: in the response header and in the response body. The ID of the new group is always returned as the value of the Location header. If you create a local group or import an Active Directory group immediately, the response body contains the name and ID of the new group. If you import an Active Directory group using a background process, the response body contains a &lt;job&gt; element that includes a job ID. You can use the job ID to check the status of the operation by calling Query Job.
        /// </summary>
        /// <param name="siteId">The ID of the site to create the group in.</param>
        /// <param name="createGroupRequest">CreateGroupRequest</param>
        /// <returns></returns>
        void SitesSiteIdGroupsPost(string siteId, CreateGroupRequest createGroupRequest);
        /// <summary>
        /// Adds permissions to the specified project that will be applied by default to new workbooks and data sources as they are added to the project. You make separate requests to set default permissions for workbooks and for data sources. Content owners can override default permissions for their content, but only if project permissions have not been locked. Project permissions can be locked for a new project when you call Create Project or for an existing project by calling Update Project. For more information, see Lock Content Permissions to the Project.
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The ID of the project to set default permissions for.</param>
        /// <param name="addDefaultPermissionRequest">AddDefaultPermissionRequest</param>
        /// <returns></returns>
        void SitesSiteIdProjectProjectIdDefaultPermissionsDatasourcesPut(string siteId, string projectId, AddDefaultPermissionRequest addDefaultPermissionRequest);
        /// <summary>
        /// Adds permissions to the specified project that will be applied by default to new workbooks and data sources as they are added to the project. You make separate requests to set default permissions for workbooks and for data sources. Content owners can override default permissions for their content, but only if project permissions have not been locked. Project permissions can be locked for a new project when you call Create Project or for an existing project by calling Update Project. For more information, see Lock Content Permissions to the Project.
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The ID of the project to set default permissions for.</param>
        /// <param name="addDefaultPermissionRequest">AddDefaultPermissionRequest</param>
        /// <returns></returns>
        void SitesSiteIdProjectProjectIdDefaultPermissionsWorkbooksPut(string siteId, string projectId, AddDefaultPermissionRequest addDefaultPermissionRequest);
        /// <summary>
        /// Adds permissions to the specified project for a Tableau Server user or group. You can specify multiple sets of permissions using one call. If the request body includes a child datasource or &lt;project&gt; element, the request is invalid. 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The ID of the project to set permissions for.</param>
        /// <param name="addProjectPermissionRequest">AddProjectPermissionRequest</param>
        /// <returns></returns>
        void SitesSiteIdProjectProjectIdPermissionsPut(string siteId, string projectId, AddProjectPermissionRequest addProjectPermissionRequest);
        /// <summary>
        /// Returns a list of projects on the specified site, with optional parameters for specifying the paging of large results. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can call this method only if they have Read (view) permission for the project (either implicitly or explicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot;       pageSize&#x3D;\&quot;page-size\&quot;       totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;projects&gt;      &lt;project id&#x3D;\&quot;project1-id\&quot;         name&#x3D;\&quot;project1-name\&quot;         description&#x3D;\&quot;project1-description\&quot;         contentPermissions&#x3D;\&quot;content-permissions\&quot; /&gt;      &lt;project id&#x3D;\&quot;project2-id\&quot;         name&#x3D;\&quot;project2-name\&quot;         description&#x3D;\&quot;project2-description\&quot;         contentPermissions&#x3D;\&quot;content-permissions\&quot; /&gt;      ... additional projects ...    &lt;/projects&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/projects\&quot;  -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot; &lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot;/&gt;    &lt;projects&gt;      &lt;project id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; name&#x3D;\&quot;default\&quot;            description&#x3D;\&quot;The default project that was automatically created by Tableau.\&quot;            contentPermissions&#x3D;\&quot;LockedToProject\&quot;  /&gt;      &lt;project id&#x3D;\&quot;7b6b59a8-ac3c-4d1d-2e9e-0b5b4ba8a7b6\&quot; name&#x3D;\&quot;Tableau Samples\&quot;            description&#x3D;\&quot;A set of sample workbooks provided by Tableau Software.\&quot;            contentPermissions&#x3D;\&quot;ManagedByOwner\&quot; /&gt;    &lt;/projects&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the projects.</param>
        /// <param name="pageSize">(Optional) The number of items to return in one response. The minimum is 1. The maximum is 1000. The default is 100. For more information, see Paginating Results.</param>
        /// <param name="pageNumber">(Optional) The offset for paging. The default is 1. For more information, see Paginating Results.</param>
        /// <returns>QueryProjectsResponse</returns>
        QueryProjectsResponse SitesSiteIdProjectsGet(string siteId, string pageSize, string pageNumber);
        /// <summary>
        /// Creates a project on the specified site. To make changes to an existing project, call Update Project. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.
        /// </summary>
        /// <param name="siteId">The ID of the site to create the project in.</param>
        /// <param name="createProjectRequest">CreateProjectRequest</param>
        /// <returns></returns>
        void SitesSiteIdProjectsPost(string siteId, CreateProjectRequest createProjectRequest);
        /// <summary>
        /// Returns information about the default permissions for a project—that is, the permissions that will be set by default for workbooks and data sources that are added to the project. You make separate requests to query the default permissions for workbooks and for data sources. ##### Permissions: Tableau Server users who are not server administrators can query default permissions for a project only if they have the ProjectLeader permission for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;permissions&gt;      &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capabilities ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The project to get default permissions for.</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGet(string siteId, string projectId);
        /// <summary>
        /// Removes default permissions from a project. After the default permission has been removed, workbooks or data sources that are added to the project do not get the specified permission by default. You make separate requests to remove default permissions for workbooks and for data sources, and you make separate requests to remove default permissions for a specific group or user. ##### Permissions: Tableau Server users who are not server administrators can remove permissions for a project only if they have ProjectLeader permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The ID of the project to remove the default permission for.</param>
        /// <param name="groupId">The ID of the group to remove the default permission for.</param>
        /// <param name="capabilityName">The capability to remove the permissions for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. Valid capabilities for a data source are ChangePermissions, Connect, Delete, ExportXml, Read (view), and Write. For more information, see Permissions.</param>
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGroupsGroupIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string groupId, string capabilityName, string capabilityMode);
        /// <summary>
        /// Removes default permissions from a project. After the default permission has been removed, workbooks or data sources that are added to the project do not get the specified permission by default. You make separate requests to remove default permissions for workbooks and for data sources, and you make separate requests to remove default permissions for a specific group or user. ##### Permissions: Tableau Server users who are not server administrators can remove permissions for a project only if they have ProjectLeader permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The ID of the project to remove the default permission for.</param>
        /// <param name="userId">The ID of the user to remove default permission for.</param>
        /// <param name="capabilityName">The capability to remove the permissions for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. Valid capabilities for a data source are ChangePermissions, Connect, Delete, ExportXml, Read (view), and Write. For more information, see Permissions.</param>
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesUsersUserIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string userId, string capabilityName, string capabilityMode);
        /// <summary>
        /// Returns information about the default permissions for a project—that is, the permissions that will be set by default for workbooks and data sources that are added to the project. You make separate requests to query the default permissions for workbooks and for data sources. ##### Permissions: Tableau Server users who are not server administrators can query default permissions for a project only if they have the ProjectLeader permission for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;permissions&gt;      &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capabilities ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The project to get default permissions for.</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGet(string siteId, string projectId);
        /// <summary>
        /// Removes default permissions from a project. After the default permission has been removed, workbooks or data sources that are added to the project do not get the specified permission by default. You make separate requests to remove default permissions for workbooks and for data sources, and you make separate requests to remove default permissions for a specific group or user. ##### Permissions: Tableau Server users who are not server administrators can remove permissions for a project only if they have ProjectLeader permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The ID of the project to remove the default permission for.</param>
        /// <param name="groupId">The ID of the group to remove the default permission for.</param>
        /// <param name="capabilityName">The capability to remove the permissions for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. Valid capabilities for a data source are ChangePermissions, Connect, Delete, ExportXml, Read (view), and Write. For more information, see Permissions.</param>
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGroupsGroupIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string groupId, string capabilityName, string capabilityMode);
        /// <summary>
        /// Removes default permissions from a project. After the default permission has been removed, workbooks or data sources that are added to the project do not get the specified permission by default. You make separate requests to remove default permissions for workbooks and for data sources, and you make separate requests to remove default permissions for a specific group or user. ##### Permissions: Tableau Server users who are not server administrators can remove permissions for a project only if they have ProjectLeader permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The ID of the project to remove the default permission for.</param>
        /// <param name="userId">The ID of the user to remove default permission for.</param>
        /// <param name="capabilityName">The capability to remove the permissions for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. Valid capabilities for a data source are ChangePermissions, Connect, Delete, ExportXml, Read (view), and Write. For more information, see Permissions.</param>
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksUsersUserIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string userId, string capabilityName, string capabilityMode);
        /// <summary>
        /// Deletes the specified project on a specific site. When a project is deleted, all of its assets are also deleted: associated workbooks, data sources, project view options, and rights. Use this method with caution. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/projects/1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot;  -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The ID of the project to delete.</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdDelete(string siteId, string projectId);
        /// <summary>
        /// Returns information about the set of permissions allowed or denied for groups and users in a project. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;permissions&gt;      &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capabilities ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/projects/1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e/permissions\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;permissions&gt;      &lt;project id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; name&#x3D;\&quot;default\&quot;&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;      &lt;/project&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d\&quot;/&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;Read\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;Write\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The project to get permissions for.</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdPermissionsGet(string siteId, string projectId);
        /// <summary>
        /// Removes the specified project permission for the specified group or user. ##### Permissions: Tableau Server users who are not server administrators or site administrators can remove permissions for a project only if they have ChangePermissions (version 2.0) or ProjectLeader (version 2.1) permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The ID of the project to remove the permission for.</param>
        /// <param name="groupId">The ID of the group to remove the permission for.</param>
        /// <param name="capabilityName">The capability to remove the permission for. In Tableau Server 10.0, valid capabilities for a project are ProjectLeader, Read (view), and Write. For more information, see Permissions.</param>
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string groupId, string capabilityName, string capabilityMode);
        /// <summary>
        /// Removes the specified project permission for the specified group or user. ##### Permissions: Tableau Server users who are not server administrators or site administrators can remove permissions for a project only if they have ChangePermissions (version 2.0) or ProjectLeader (version 2.1) permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param>
        /// <param name="projectId">The ID of the project to remove the permission for.</param>
        /// <param name="userId">The ID of the user to remove project the permission for.</param>
        /// <param name="capabilityName">The capability to remove the permission for. In Tableau Server 10.0, valid capabilities for a project are ProjectLeader, Read (view), and Write. For more information, see Permissions.</param>
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string userId, string capabilityName, string capabilityMode);
        /// <summary>
        /// Modifies an existing subscription, allowing you to change the subject or schedule for the subscription. 
        /// </summary>
        /// <param name="siteId"> The ID of the site that contains the project.</param>
        /// <param name="projectId"> The ID of the project to update.</param>
        /// <param name="updateProjectRequest">UpdateProjectRequest</param>
        /// <returns></returns>
        void SitesSiteIdProjectsProjectIdPut(string siteId, string projectId, UpdateProjectRequest updateProjectRequest);
        /// <summary>
        /// Returns a list of the extract refresh tasks for a specified schedule on the specified site. To get the ID of a schedule, call the Query Schedules method. Note that the Query Schedules method is global to the server; schedules are not specific to a site. Therefore, the URI for the Query Schedules method does not include /sites/ or a site ID. However, individual scheduled tasks are specific to a site, and the URI for Query Extract Refresh Tasks must include the site information.  For more information about refresh tasks, see Manage Refresh Tasks.  ##### Permissions: This method can only be called by server administrators and site administrators. When a site administrator calls this method, the payload contains only the tasks that are associated with the site that the user is signed in to.  ##### Version: Version 2.2 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot;       pageSize&#x3D;\&quot;page-size\&quot;       totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;extracts&gt;       &lt;extract id&#x3D;\&quot;task-id\&quot;         priority&#x3D;\&quot;task-priority\&quot;        type&#x3D;\&quot;incremental-or-full\&quot; &gt;          &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;      &lt;/extract&gt;      &lt;extract id&#x3D;\&quot;task-id\&quot;         priority&#x3D;\&quot;task-priority\&quot;        type&#x3D;\&quot;incremental-or-full\&quot; &gt;          &lt;datasource id&#x3D;\&quot;datasource-id\&quot; /&gt;      &lt;/extract&gt;      ... additional extract refresh tasks ...     &lt;/extracts&gt;   &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/schedules/59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba/extracts\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &lt;tsResponse version-and-namespace-settings&gt;  &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot; /&gt;    &lt;extracts&gt;      &lt;extract id&#x3D;\&quot;639c7e80-0d11-44b2-9b5b-018ffc5eddb4\&quot; priority&#x3D;\&quot;60\&quot; type&#x3D;\&quot;FullRefresh\&quot;&gt;        &lt;datasource /&gt;      &lt;/extract&gt;      &lt;extract id&#x3D;\&quot;303f6c45-fb48-47aa-88d3-0dd87f5f5c74\&quot; priority&#x3D;\&quot;50\&quot; type&#x3D;\&quot;FullRefresh\&quot;&gt;        &lt;workbook /&gt;      &lt;/extract&gt;    &lt;/extracts&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the refresh tasks.</param>
        /// <param name="scheduleId">The ID of the schedule to get extract information for.</param>
        /// <param name="pageSize">(Optional) The number of items to return in one response. The minimum is 1. The maximum is 1000. The default is 100. For more information, see Paginating Results.</param>
        /// <param name="pageNumber">(Optional) The offset for paging. The default is 1. For more information, see Paginating Results.</param>
        /// <returns></returns>
        void SitesSiteIdSchedulesScheduleIdExtractsGet(string siteId, string scheduleId, string pageSize, string pageNumber);
        /// <summary>
        /// Creates a new subscription to a view or workbook for a specific user. When a user is subscribed to the content, Tableau Server sends the content to the user in email on the schedule that&#39;s defined in Tableau Server and specified in this call. For more information, see Quick Start: Subscribe to Favorite Views in the Tableau Server documentation.  Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.
        /// </summary>
        /// <param name="siteId">The ID of the site to create the subscription in.</param>
        /// <param name="createSubscriptionRequest">CreateSubscriptionRequest</param>
        /// <returns></returns>
        void SitesSiteIdSubscriptionsPost(string siteId, CreateSubscriptionRequest createSubscriptionRequest);
        /// <summary>
        /// Deletes the specified subscription. ##### Permissions: Tableau Server users can call this method to delete any subscription that they had permission to create. For details, see Create Subscription.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the subscription.</param>
        /// <param name="subscriptionId">The ID of the subscription to delete. To determine what subscriptions are available, call Query Subscriptions.</param>
        /// <returns></returns>
        void SitesSiteIdSubscriptionsSubscriptionIdDelete(string siteId, string subscriptionId);
        /// <summary>
        /// Modifies an existing subscription, allowing you to change the subject or schedule for the subscription. 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="subscriptionId">The ID of the subscription to update.</param>
        /// <param name="updateSubscriptionRequest">UpdateSubscriptionRequest</param>
        /// <returns></returns>
        void SitesSiteIdSubscriptionsSubscriptionIdPut(string siteId, string subscriptionId, UpdateSubscriptionRequest updateSubscriptionRequest);
        /// <summary>
        /// Returns the users associated with the specified site. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;pagination pageNumber&#x3D;\&quot;page-number\&quot;       pageSize&#x3D;\&quot;page-size\&quot;       totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;     &lt;users&gt;      &lt;user id&#x3D;\&quot;user-id\&quot;        name&#x3D;\&quot;user-name\&quot;        siteRole&#x3D;\&quot;site-role\&quot;        lastLogin&#x3D;\&quot;date-time\&quot;        externalAuthUserId&#x3D;\&quot;authentication-id-from-external-provider\&quot;        authSetting&#x3D;\&quot;auth-setting\&quot; /&gt;      &lt;user id&#x3D;\&quot;user-id\&quot;        name&#x3D;\&quot;user-name\&quot;        siteRole&#x3D;\&quot;site-role\&quot;        lastLogin&#x3D;\&quot;date-time\&quot;        externalAuthUserId&#x3D;\&quot;authentication-id-from-external-provider\&quot;        authSetting&#x3D;\&quot;auth-setting\&quot; /&gt;    ... additional users ...    &lt;/users&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/users\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;161\&quot;/&gt;    &lt;users&gt;      &lt;user id&#x3D;\&quot;9f9e9d9c8-b8a8-f8e7-d7c7-b7a6f6d6e6d\&quot; name&#x3D;\&quot;Ashley\&quot;          siteRole&#x3D;\&quot;Viewer\&quot; /&gt;      &lt;user id&#x3D;\&quot;1f1e1d1c2-b2a2-f2e3-d3c3-b3a4f4e4d4c\&quot; name&#x3D;\&quot;Fred\&quot;          siteRole&#x3D;\&quot;ViewerWithPublish\&quot; /&gt;      &lt;user id&#x3D;\&quot;12ab34cd5-6ef7-8ab9-0cd1-2ef34ab56cd\&quot; name&#x3D;\&quot;Laura\&quot;          siteRole&#x3D;\&quot;Unlicensed\&quot; /&gt;      &lt;user id&#x3D;\&quot;9a8a7b6b5-c4c3-d2d1-e0e9-a8a7b6b5b4b\&quot; name&#x3D;\&quot;Michelle\&quot;          siteRole&#x3D;\&quot;Publisher\&quot; /&gt;      &lt;user id&#x3D;\&quot;9f8e7d6c5-b4a3-f2e1-d0c9-b8a7f6e5d4c\&quot; name&#x3D;\&quot;Susan\&quot;          siteRole&#x3D;\&quot;PublisherInteractor\&quot; /&gt;      ... another 95 users listed here ...    &lt;/users&gt;  &lt;/tsResponse&gt;curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/users?filter&#x3D;siteRole:eq:Unlicensed&amp;sort&#x3D;name:asc\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the users.</param>
        /// <param name="fieldExpression">(Optional) An expression that lets you specify the set of available fields to return. You can qualify the return values based upon predefined keywords such as _all_ or _default_, and you can specify individual fields for the views or other supported resources. You can include multiple field expressions in a request. For more information, see Using Fields in the REST API.</param>
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   lastLogin: eq, gt, gte, lte   name: eq   siteRole: eq </param>
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: lastLogin  name  siteRole</param>
        /// <returns>GetUsersOnSiteResponse</returns>
        IEnumerable<GetUsersOnSiteResponseUsersUser> SitesSiteIdUsersGet(string siteId, string fieldExpression, string filter, string sort);
        /// <summary>
        /// Adds a user to Tableau Server and assigns the user to the specified site. If Tableau Server is configured to use local authentication, the information you specify is used to create a new user in Tableau Server. To set a full name, password, and email address for the user, call Update User after creating the user. If Tableau Server is configured to use Active Directory for authentication, the user you specify is imported from Active Directory into Tableau Server. When you add user to Tableau Online, the name of the user must be the email address that is used to sign in to Tableau Online. After you add a user, Tableau Online sends the user an email invitation. The user can click the link in the invitation to sign in and update their full name and password. If you try to add a user using a specific site role but you have already reached the limit on the number of licenses for your users, the user is added as an unlicensed user. In that case, the response code is 201 (which indicates success), but the siteRole value in the response body is set to Unlicensed.
        /// </summary>
        /// <param name="siteId">The ID of the site to add users to.</param>
        /// <param name="addUserToSiteRequest">AddUserToSiteRequest</param>
        /// <returns></returns>
        void SitesSiteIdUsersPost(string siteId, AddUserToSiteRequest addUserToSiteRequest);
        /// <summary>
        /// Removes a user from the specified site. If a user still owns content (assets) on Tableau Server, the user cannot be deleted unless the ownership is reassigned first. If a user is removed from all sites that the user is a member of, the user is deleted.  ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/users/9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot; -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the user.</param>
        /// <param name="userId">The ID of the user to remove.</param>
        /// <returns></returns>
        void SitesSiteIdUsersUserIdDelete(string siteId, string userId);
        /// <summary>
        /// Modifies information about the specified user. If Tableau Server is configured to use local authentication, you can update the user&#39;s name, email address, password, or site role.  If Tableau Server is configured to use Active Directory for authentication, you can change the user&#39;s display name (full name), email address, and site role. However, if you synchronize the user with Active Directory, the display name and email address will be overwritten with the information that&#39;s in Active Directory.  For Tableau Online, you can update the site role for a user, but you cannot update or change a user&#39;s password, user name (email address), or full name.
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the user.</param>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="updateUserRequest">UpdateUserRequest</param>
        /// <returns></returns>
        void SitesSiteIdUsersUserIdPut(string siteId, string userId, UpdateUserRequest updateUserRequest);
        /// <summary>
        /// Returns the workbooks that the specified user owns in addition to those that the user has Read (view) permissions for. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: All users can call this method, but the results of the call depend on the user&#39;s permissions. Server and site administrators see all workbooks for the specified user. If the isOwner parameter is true, users who are not server or site administrators see the workbooks that they own on the site. If isOwner parameter is false, users who are not server administrators see the workbooks that they have Read (view) permissions for.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot; pageSize&#x3D;\&quot;page-size\&quot;           totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;workbooks&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; name&#x3D;\&quot;name\&quot;        contentUrl&#x3D;\&quot;content-url\&quot;          showTabs&#x3D;\&quot;show-tabs-flag\&quot;        size&#x3D;\&quot;size-in-megabytes\&quot;        createdAt&#x3D;\&quot;datetime-created\&quot;        updatedAt&#x3D;\&quot;datetime-updated\&quot;  &gt;        &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;        &lt;owner id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;tags&gt;          &lt;tag label&#x3D;\&quot;tag\&quot;/&gt;          ... additional tags ...        &lt;/tags&gt;     &lt;/workbook&gt;     ... additional workbooks ...  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/users/9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d/workbooks\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot;/&gt;    &lt;workbooks&gt;      &lt;workbook id&#x3D;\&quot;1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d\&quot; name&#x3D;\&quot;Finance\&quot;           contentUrl&#x3D;\&quot;Finance\&quot; showTabs&#x3D;\&quot;true\&quot; size&#x3D;\&quot;2\&quot;           createdAt&#x3D;\&quot;2013-03-30T22:32:35Z\&quot; updatedAt&#x3D;\&quot;2016-01-13T01:00:02Z\&quot;&gt;        &lt;project id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; name&#x3D;\&quot;Tableau Samples\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;&lt;/tags&gt;      &lt;/workbook&gt;      &lt;workbook id&#x3D;\&quot;59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba\&quot; name&#x3D;\&quot;World Indicators\&quot;           contentUrl&#x3D;\&quot;WorldIndicators\&quot; showTabs&#x3D;\&quot;true\&quot; size&#x3D;\&quot;1\&quot;            createdAt&#x3D;\&quot;2014-02-19T10:19:23Z\&quot; updatedAt&#x3D;\&quot;2015-12-29T013:23:45Z\&quot;&gt;        &lt;project id&#x3D;\&quot;08a7b6b5-b4ba-be3a-4d2d-1e9e59a8a7b6\&quot; name&#x3D;\&quot;default\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;&lt;/tags&gt;      &lt;/workbook&gt;    &lt;/workbooks&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the user.</param>
        /// <param name="userId">The ID of the user to get workbooks for.</param>
        /// <param name="isOwner">(Optional) true to return workbooks that the specified user owns, or false to return workbooks that the specified user has read access to. The default is false.</param>
        /// <param name="pageSize">(Optional) The number of items to return in one response. The minimum is 1. The maximum is 1000. The default is 100. For more information, see Paginating Results.</param>
        /// <param name="pageNumber">(Optional) The offset for paging. The default is 1. For more information, see Paginating Results.</param>
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   ownerName: eq   tags: eq, in </param>
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  ownerName  tags</param>
        /// <returns></returns>
        void SitesSiteIdUsersUserIdWorkbooksGet(string siteId, string userId, string isOwner, string pageSize, string pageNumber, string filter, string sort);
        /// <summary>
        /// Returns all the views for the specified site, optionally including usage statistics. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: For Tableau Server users who are not server administrators or site administrators, the method returns only the views that the user owns or has Read permissions for (either explicitly or implicitly).  ##### Version: Version 2.2 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;views&gt;      &lt;view id&#x3D;\&quot;view-id\&quot;           name&#x3D;\&quot;view-name\&quot;           contentUrl&#x3D;\&quot;content-url\&quot; &gt;        &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;        &lt;owner id&#x3D;\&quot;owner-id\&quot; /&gt;        &lt;usage totalViewCount&#x3D;\&quot;total-count\&quot; /&gt;      &lt;/view&gt;       ... additional views ...    &lt;/views&gt;  &lt;/tsResponse&gt;includeUsageStatistics&#x3D;true  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/views\&quot; -X GET -H \&quot;X-Tableau-Auth:1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/views\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot; /&gt;    &lt;views&gt;      &lt;view id&#x3D;\&quot;1f1e1d1c-2b2a-2f2e-3d3c-3b3a4f4e4d4c\&quot; name&#x3D;\&quot;Economic Indicators\&quot;            contentUrl&#x3D;\&quot;Finance/sheets/EconomicIndicators\&quot;&gt;        &lt;workbook id&#x3D;\&quot;1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d\&quot; /&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot; /&gt;      &lt;/view&gt;      &lt;view id&#x3D;\&quot;9a8a7b6b-5c4c-3d2d-1e0e-9a8a7b6b5b4b\&quot; name&#x3D;\&quot;Investing in the Dow\&quot;             contentUrl&#x3D;\&quot;Finance/sheets/InvestingintheDow\&quot;&gt;        &lt;workbook id&#x3D;\&quot;59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba\&quot; /&gt;        &lt;owner id&#x3D;\&quot;9f8e7d6c5-b4a3-f2e1-d0c9-b8a7f6e5d4c\&quot; /&gt;    &lt;/view&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the views.</param>
        /// <param name="fieldExpression">(Optional) An expression that lets you specify the set of available fields to return. You can qualify the return values based upon predefined keywords such as _all_ or _default_, and you can specify individual fields for the workbooks or other supported resources. You can include multiple field expressions in a request. For more information, see Using Fields in the REST API.</param>
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   tags: eq, in </param>
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  tags</param>
        /// <returns></returns>
        IEnumerable<QueryViewsForSiteResponseViewsView> SitesSiteIdViewsGet(string siteId, string fieldExpression, string filter, string sort);
        /// <summary>
        /// Returns an image of the specified view. By default, the width of the returned image is 784 pixels. If you include the ?resolution&#x3D;high query parameter, the width of the returned image is 1568 pixels. For both resolutions, the height varies to preserve the aspect ratio of the view. If you make multiple requests for an image, subsequent calls return a cached version of the image. This means that the returned image might not include the latest changes to the view. To decrease the amount of time that an image is cached, use tabadmin to reduce the value of the vizportal.rest_api.view_image.max_age setting. For more information, see tabadmin set options in the Tableau Server help.  Note: If you want to disable this endpoint, use tabadmin to set the sheet_image.enabled setting to false. For more information, see tabadmin set options in the Tableau Server help.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can query workbook views only if they have Read (view) permission for the views (either explicitly or implicitly).  ##### Version: Version 2.5 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; image/png  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/views/9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d/image?resolution&#x3D;high\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the view.</param>
        /// <param name="viewId">The ID of the view to return an image for.</param>
        /// <returns></returns>
        void SitesSiteIdViewsViewIdImageGet(string siteId, string viewId, string filterExpression = null);
        /// <summary>
        /// Returns the workbooks on a site. If the user is not an administrator, the method returns just the workbooks that the user has permissions to view.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can get workbooks that they have Read (view) permissions for (either explicitly or implicitly).  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;page-number\&quot;       pageSize&#x3D;\&quot;page-size\&quot;       totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;workbooks&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; name&#x3D;\&quot;name\&quot;            contentUrl&#x3D;\&quot;content-url\&quot;              showTabs&#x3D;\&quot;show-tabs-flag\&quot;            size&#x3D;\&quot;size-in-megabytes\&quot;            createdAt&#x3D;\&quot;datetime-created\&quot;            updatedAt&#x3D;\&quot;datetime-updated\&quot;  &gt;        &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;        &lt;owner id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;tags&gt;          &lt;tag label&#x3D;\&quot;tag\&quot;/&gt;          ... additional tags ...       &lt;/tags&gt;     &lt;/workbook&gt;     ... additional workbooks ...    &lt;/workbooks&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;27\&quot;/&gt;    &lt;workbooks&gt;      &lt;workbook id&#x3D;\&quot;1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d\&quot; name&#x3D;\&quot;Finance\&quot;           contentUrl&#x3D;\&quot;Finance\&quot; showTabs&#x3D;\&quot;true\&quot; size&#x3D;\&quot;2\&quot;           createdAt&#x3D;\&quot;2013-03-30T22:32:35Z\&quot; updatedAt&#x3D;\&quot;2016-01-13T01:00:02Z\&quot;&gt;        &lt;project id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; name&#x3D;\&quot;Tableau Samples\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;&lt;/tags&gt;      &lt;/workbook&gt;      &lt;workbook id&#x3D;\&quot;59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba\&quot; name&#x3D;\&quot;World Indicators\&quot;           contentUrl&#x3D;\&quot;WorldIndicators\&quot; showTabs&#x3D;\&quot;true\&quot; size&#x3D;\&quot;1\&quot;            createdAt&#x3D;\&quot;2014-02-19T10:19:23Z\&quot; updatedAt&#x3D;\&quot;2015-12-29T013:23:45Z\&quot;&gt;        &lt;project id&#x3D;\&quot;08a7b6b5-b4ba-be3a-4d2d-1e9e59a8a7b6\&quot; name&#x3D;\&quot;default\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;            &lt;tag label&#x3D;\&quot;training\&quot; &gt;        &lt;/tags&gt;      &lt;/workbook&gt;    &lt;/workbooks&gt;    ... another 25 workbooks listed here ...    &lt;/tsResponse&gt;curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks?filter&#x3D;updatedAt:gte:2016-05-01T06:00:00Z&amp;sort&#x3D;name:asc\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbooks.</param>
        /// <param name="fieldExpression">(Optional) An expression that lets you specify the set of available fields to return. You can qualify the return values based upon predefined keywords such as _all_ or _default_, and you can specify individual fields for the workbooks or other supported resources. You can include multiple field expressions in a request. For more information, see Using Fields in the REST API.</param>
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   ownerName: eq   tags: eq, in </param>
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  ownerName  tags</param>
        /// <returns>QueryWorkbooksForSiteResponse</returns>
        QueryWorkbooksForSiteResponse SitesSiteIdWorkbooksGet(string siteId, string fieldExpression, string filter, string sort);
        /// <summary>
        /// Updates the server address, port, username, or password for the specified workbook connection. If the workbook contains multiple connections to the same data source type, all the connections are updated. For example, if the workbook contains three connections to the same PostgreSQL database, and you attempt to update the user name of one of the connections, the user name is updated for all three connections.  Any combination of the attributes inside the &lt;connection&gt; element is valid. If no attributes are included, no update is made.    ##### Permissions: Tableau Server users who are not server administrators or site administrators can update permissions only for a workbook for which they have the Write capability (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;connection      serverAddress&#x3D;\&quot;server-address\&quot; serverPort&#x3D;\&quot;port\&quot;      userName&#x3D;\&quot;connection-username\&quot; password&#x3D;\&quot;connection-password\&quot;       embedPassword&#x3D;\&quot;embed-password\&quot;  /&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;connection id&#x3D;\&quot;connection-id\&quot;      serverAddress&#x3D;\&quot;server-address\&quot; serverPort&#x3D;\&quot;port\&quot;      userName&#x3D;\&quot;connection-user-name\&quot; /&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to update.</param>
        /// <param name="connectionId">The ID of the connection to update.</param>
        /// <param name="updateWorkbookConnectionRequest">UpdateWorkbookConnectionRequest</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdConnectionsConnectionIdPut(string siteId, string workbookId, string connectionId, UpdateWorkbookConnectionRequest updateWorkbookConnectionRequest);
        /// <summary>
        /// Returns a list of data connections for the specific workbook. ##### Permissions: Tableau Server users who are not server administrators or site administrators can query a workbook only if they have Read (view) permission for the workbook (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;connections&gt;      &lt;connection id&#x3D;\&quot;connection-id\&quot; type&#x3D;\&quot;connection-type\&quot;        serverAddress&#x3D;\&quot;server-address\&quot; serverPort&#x3D;\&quot;port\&quot;        userName&#x3D;\&quot;connection-user-name\&quot; /&gt;      ... additional connections ...    &lt;/connections&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/connections\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;connections&gt;      &lt;connection id&#x3D;\&quot;12ab34cd-56ef-78ab-90cd-12ef34ab56cd\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;9a8a7b6b-5c4c-3d2d-1e0e-9a8a7b6b5b4b\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;7b6b59a8-ac3c-4d1d-2e9e-0b5b4ba8a7b6\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;374371c0-ffe9-4e16-b48e-6b868e3026ca\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;08a7b6b5-b4ba-be3a-4d2d-1e9e59a8a7b6\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;    &lt;/connections&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to return connection information about.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdConnectionsGet(string siteId, string workbookId);
        /// <summary>
        /// Downloads a workbook in .twb or .twbx format. ##### Permissions: Tableau Server users who are not server administrators or site administrators can download a workbook only if they have ExportXml permission for the workbook (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; .twbContent-Type: application/xml.twbxContent-Type:  application/octet-streamContent-Disposition: name&#x3D;\&quot;tableau_workbook\&quot;; filename&#x3D;\&quot;workbook-filename\&quot;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/content\&quot;  -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &gt; c:\\files\\my-workbook.twbx  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to download.</param>
        /// <param name="extractValue">(Optional) The extract-value is a Boolean value (False or True). When the workbook specified for download has an extract, if you add the parameter ?includeExtract&#x3D;False, the extract is not included when you download the workbook. You can use this option to improve performance if you are downloading workbooks or data sources that have large extracts.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdContentGet(string siteId, string workbookId, string extractValue);
        /// <summary>
        /// Deletes a workbook. When a workbook is deleted, all of its assets are also deleted, including associated views, data connections, and so on. ##### Permissions: Tableau Server users who are not server administrators or site administrators can delete a workbook for which they have Read (view) and Delete permissions (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to remove.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdDelete(string siteId, string workbookId);
        /// <summary>
        /// Returns a list of permissions for the specific workbook. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;parent type&#x3D;\&quot;Project\&quot; id&#x3D;\&quot;project-id\&quot; /&gt;    &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; name&#x3D;\&quot;workbook-name &gt;        &lt;owner&#x3D;\&quot;owner-user-id\&quot; /&gt;      &lt;/workbook&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;           ... additional capabilities for users ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;           ... additional capabilities for groups ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capability sets ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/permissions\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;parent type&#x3D;\&quot;Project\&quot; id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; /&gt;    &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d\&quot; name&#x3D;\&quot;Finance\&quot;&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;      &lt;/workbook&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d\&quot;/&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;Read\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;Filter\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;ViewUnderlyingData\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;ExportImage\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;ExportData\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;AddComment\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;ViewComments\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;ShareView\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to return permission information about.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdPermissionsGet(string siteId, string workbookId);
        /// <summary>
        /// Deletes the specified permission from the specified workbook for a group or user. ##### Permissions: Tableau Server users who are not server administrators or site administrators can delete permissions from a workbook only if they have ChangePermissions permission for workbook (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to remove the permission for.</param>
        /// <param name="groupId">The ID of the group to remove the permission for.</param>
        /// <param name="capabilityName">The capability to remove the permission for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. For more information, see Permissions.</param>
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete(string siteId, string workbookId, string groupId, string capabilityName, string capabilityMode);
        /// <summary>
        /// Adds permissions to the specified workbook for a Tableau Server user or group. You can specify multiple sets of permissions using one call. ##### Permissions: Tableau Server users who are not server administrators or site administrators can call this method only if the have permission to set permissions on the workbook (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability-name\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability-name\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capability sets ...    &lt;/permissions&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capability sets ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to set permissions for.</param>
        /// <param name="addWorkbookPermissionRequest">AddWorkbookPermissionRequest</param>
        /// <returns>AddWorkbookPermissionsResponse</returns>
        AddWorkbookPermissionsResponse SitesSiteIdWorkbooksWorkbookIdPermissionsPut(string siteId, string workbookId, AddWorkbookPermissionRequest addWorkbookPermissionRequest);
        /// <summary>
        /// Deletes the specified permission from the specified workbook for a group or user. ##### Permissions: Tableau Server users who are not server administrators or site administrators can delete permissions from a workbook only if they have ChangePermissions permission for workbook (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to remove the permission for.</param>
        /// <param name="userId">The ID of the user to remove the permission for.</param>
        /// <param name="capabilityName">The capability to remove the permission for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. For more information, see Permissions.</param>
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete(string siteId, string workbookId, string userId, string capabilityName, string capabilityMode);
        /// <summary>
        /// Returns the thumbnail image as a PNG file for the specified workbook. Usually the image that is returned is for the first sheet in the workbook. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can query a workbook preview image only if they have Read (view) permission for the workbook (either explicitly or implicitly) and also have Read (view) permission for the view that is used as the preview image. If the user doesn&#39;t have Read permissions to that view, the preview image for another view might be used. If the user doesn&#39;t have Read permissions to any views in the workbook, the user is not allowed to query a workbook query image.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; image/png  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/previewImage\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot; &gt; workbook-preview.png  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to return the thumbnail image for.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdPreviewImageGet(string siteId, string workbookId);
        /// <summary>
        /// Modifies an existing workbook, allowing you to change the owner or project that the workbook belongs to and whether the workbook shows views in tabs. 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to update.</param>
        /// <param name="updateWorkbookRequest">UpdateWorkbookRequest</param>
        /// <returns>UpdateWorkbookResponse</returns>
        UpdateWorkbookResponse SitesSiteIdWorkbooksWorkbookIdPut(string siteId, string workbookId, UpdateWorkbookRequest updateWorkbookRequest);
        /// <summary>
        /// Returns a list of revision information (history) for the specified workbook. Note: This method is available only if version history is enabled for the specified site.  To get a specific version of the workbook from revision history, use the Download Workbook Revision method. For more information, see Maintain a History of Revisions in the Tableau Server Help.  ##### Permissions: Tableau Server users who are site administrators can get workbook revisions on the site that they are administrators for. Users who are not server administrators or site administrators can get workbook revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified workbook. Save (write) permissions for the project that contains the workbook.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot; pageSize&#x3D;\&quot;page-size\&quot;         totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;revisions&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;1\&quot; isDeleted&#x3D;\&quot;false\&quot;&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; name&#x3D;\&quot;user-name\&quot;/&gt;      &lt;/revision&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;2\&quot; isDeleted&#x3D;\&quot;false\&quot;&gt;      &lt;/revision&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;3\&quot; isCurrent&#x3D;\&quot;true\&quot;&gt;          &lt;user id&#x3D;\&quot;user-id\&quot; name&#x3D;\&quot;user-name\&quot;/&gt;      &lt;/revision&gt;    &lt;/revisions&gt;  &lt;/tsResponse&gt;isDeleted&#x3D;\&quot;true\&quot;&lt;user&gt;&lt;revision&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook to get revisions for.</param>
        /// <param name="workbookId">The ID of the workbook to get revisions for.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdRevisionsGet(string siteId, string workbookId);
        /// <summary>
        /// Downloads a specific version of a workbook in .twb or .twbx format. Note: This method is available only if version history is enabled for the specified site. For more information, see Maintain a History of Revisions in the Tableau Server Help.  ##### Permissions: Tableau Server users who are site administrators can download workbook revisions on the site that they are administrators for. Users who are not server administrators or site administrators can download workbook revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified workbook. Save (write) permissions for the project that contains the workbook.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; .twbContent-Type: application/xml.twbxContent-Type:  application/octet-streamContent-Disposition: name&#x3D;\&quot;tableau_workbook\&quot;; filename&#x3D;\&quot;workbook-filename\&quot;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to download.</param>
        /// <param name="revisionNumber">The revision number of the workbook to download. To determine what versions are available, call Get Workbook Revisions. Note that the current revision of a workbook cannot be accessed by this call; use Download Workbook instead.</param>
        /// <param name="extractValue">(Optional) The extract-value is a Boolean value (False or True). When the workbook specified for download has an extract, if you add the parameter ?includeExtract&#x3D;False, the extract is not included when you download the workbook. You can use this option to improve performance if you are downloading workbooks or data sources that have large extracts.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberContentGet(string siteId, string workbookId, string revisionNumber, string extractValue);
        /// <summary>
        /// Removes a specific version of a workbook from the specified site. The content is removed, and the specified revision can no longer be downloaded using Download Workbook Revision. If you call Get Workbook Revisions, the revision that&#39;s been removed is listed with the attribute IsDeleted&#x3D;\&quot;true\&quot;.  Note: Calling this method permanently removes the specified workbook revision.  ##### Permissions: Tableau Server users who are site administrators can remove workbook revisions on the site that they are administrators for. Users who are not server administrators or site administrators can remove workbook revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified workbook. Save (write) permissions for the project that contains the workbook.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the group.</param>
        /// <param name="workbookId">The ID of the workbook to remove the revision for.</param>
        /// <param name="revisionNumber">The revision number of the workbook to remove. To determine what versions are available, call Get Workbook Revisions.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberDelete(string siteId, string workbookId, string revisionNumber);
        /// <summary>
        /// Adds one or more tags to the specified workbook. ##### Permissions: Tableau Server users who are not server administrators or site administrators can call this method only if they have Read permissions for the workbook (either explicitly or implicitly).  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;tags&gt;      &lt;tag label&#x3D;\&quot;tag\&quot; /&gt;      ... additional tags ...    &lt;/tags&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;workbook id&#x3D;\&quot;workbook-id\&quot;      name&#x3D;\&quot;workbook-name\&quot;&gt;      &lt;project id&#x3D;\&quot;project-id\&quot;        name&#x3D;\&quot;project-name\&quot; /&gt;      &lt;tags&gt;        &lt;tag label&#x3D;\&quot;tag\&quot;/&gt;        &lt;tag label&#x3D;\&quot;tag\&quot;/&gt;        ... additional tags ...      &lt;/tags&gt;      &lt;views&gt;        &lt;view id&#x3D;\&quot;view-id\&quot; /&gt;        &lt;view id&#x3D;\&quot;view-id\&quot; /&gt;        ... additional views ...      &lt;/views&gt;    &lt;/workbook&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/tags\&quot; -X PUT -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot; -d @add-tags-to-workbook.xml&lt;tsRequest&gt;      &lt;tags&gt;        &lt;tag label&#x3D;\&quot;GDP\&quot; /&gt;        &lt;tag label&#x3D;\&quot;Health\&quot; /&gt;      &lt;/tags&gt;  &lt;/tsRequest&gt;&lt;tsResponse version-and-namespace-settings&gt;    &lt;tags&gt;      &lt;tag label&#x3D;\&quot;GDP\&quot;/&gt;      &lt;tag label&#x3D;\&quot;Health\&quot;/&gt;      &lt;tag label&#x3D;\&quot;Spending\&quot;/&gt;    &lt;/tags&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to add tags to.</param>
        /// <param name="addTagsToWorkbook">AddTagsToWorkbook</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdTagsPut(string siteId, string workbookId, AddTagsToWorkbook addTagsToWorkbook);
        /// <summary>
        /// Deletes a tag from the specified workbook. ##### Permissions: Tableau Server users who are not server administrators, site administrators, or workbook owners can delete a tag from a workbook only if they are project leaders or if they originally added the tag.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to remove the tag from.</param>
        /// <param name="tagName">The name of the tag to remove from the workbook.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdTagsTagNameDelete(string siteId, string workbookId, string tagName);
        /// <summary>
        /// Returns all the views for the specified workbook, optionally including usage statistics. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can query workbook views only if they have Read (view) permission for the views (either explicitly or implicitly).  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;views&gt;      &lt;view id&#x3D;\&quot;view-id\&quot; name&#x3D;\&quot;view-name\&quot;          contentUrl&#x3D;\&quot;content-url\&quot; &gt;        &lt;usage totalViewCount&#x3D;\&quot;total-count\&quot; /&gt;      &lt;/view&gt;       ... additional views ...    &lt;/views&gt;  &lt;/tsResponse&gt;includeUsageStatistics&#x3D;true  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/views\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;views&gt;      &lt;view id&#x3D;\&quot;1f1e1d1c-2b2a-2f2e-3d3c-3b3a4f4e4d4c\&quot; name&#x3D;\&quot;Tale of 100 Start-ups\&quot;            contentUrl&#x3D;\&quot;Finance/sheets/Taleof100Start-ups\&quot;/&gt;      &lt;view id&#x3D;\&quot;9a8a7b6b-5c4c-3d2d-1e0e-9a8a7b6b5b4b\&quot; name&#x3D;\&quot;Economic Indicators\&quot;            contentUrl&#x3D;\&quot;Finance/sheets/EconomicIndicators\&quot;/&gt;      &lt;view id&#x3D;\&quot;7b6b59a8-ac3c-4d1d-2e9e-0b5b4ba8a7b6\&quot; name&#x3D;\&quot;Investing in the Dow\&quot;            contentUrl&#x3D;\&quot;Finance/sheets/InvestingintheDow\&quot;/&gt;    &lt;/views&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param>
        /// <param name="workbookId">The ID of the workbook to get the views for.</param>
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   tags: eq, in </param>
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  tags</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdViewsGet(string siteId, string workbookId, string filter, string sort);
        /// <summary>
        /// Returns the thumbnail image for the specified view. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can query workbook views only if they have Read (view) permission for the views (either explicitly or implicitly).  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; image/png  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the view.</param>
        /// <param name="workbookId">The ID of the workbook that contains the view to return a thumbnail image for.</param>
        /// <param name="viewId">The ID of the view to return a thumbnail image for.</param>
        /// <returns></returns>
        void SitesSiteIdWorkbooksWorkbookIdViewsViewIdPreviewImageGet(string siteId, string workbookId, string viewId);
        /// <summary>
        /// Returns all the views for the specified site, optionally including usage statistics. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: For Tableau Server users who are not server administrators or site administrators, the method returns only the views that the user owns or has Read permissions for (either explicitly or implicitly).  ##### Version: Version 2.2 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;views&gt;      &lt;view id&#x3D;\&quot;view-id\&quot;           name&#x3D;\&quot;view-name\&quot;           contentUrl&#x3D;\&quot;content-url\&quot; &gt;        &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;        &lt;owner id&#x3D;\&quot;owner-id\&quot; /&gt;        &lt;usage totalViewCount&#x3D;\&quot;total-count\&quot; /&gt;      &lt;/view&gt;       ... additional views ...    &lt;/views&gt;  &lt;/tsResponse&gt;includeUsageStatistics&#x3D;true  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/views\&quot; -X GET -H \&quot;X-Tableau-Auth:1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/views\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot; /&gt;    &lt;views&gt;      &lt;view id&#x3D;\&quot;1f1e1d1c-2b2a-2f2e-3d3c-3b3a4f4e4d4c\&quot; name&#x3D;\&quot;Economic Indicators\&quot;            contentUrl&#x3D;\&quot;Finance/sheets/EconomicIndicators\&quot;&gt;        &lt;workbook id&#x3D;\&quot;1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d\&quot; /&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot; /&gt;      &lt;/view&gt;      &lt;view id&#x3D;\&quot;9a8a7b6b-5c4c-3d2d-1e0e-9a8a7b6b5b4b\&quot; name&#x3D;\&quot;Investing in the Dow\&quot;             contentUrl&#x3D;\&quot;Finance/sheets/InvestingintheDow\&quot;&gt;        &lt;workbook id&#x3D;\&quot;59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba\&quot; /&gt;        &lt;owner id&#x3D;\&quot;9f8e7d6c5-b4a3-f2e1-d0c9-b8a7f6e5d4c\&quot; /&gt;    &lt;/view&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   tags: eq, in </param>
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  tags</param>
        /// <returns></returns>
        void SitesViewsGet(string filter, string sort);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DefaultApi : IDefaultApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DefaultApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi(String basePath, string authToken = null)
        {
            UriBuilder serverApiUri = new UriBuilder(basePath);
            serverApiUri.Path = "/api/2.8";

            this.ApiClient = new ApiClient(serverApiUri.ToString());
            if (authToken != null) this.ApiClient.TableauAuthToken = authToken;
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
        /// Signs you out of the current session. This call invalidates the authentication token that is created by a call to Sign In. ##### Permissions: Any user can call this method.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/auth/signout\&quot; -X POST -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <returns></returns>            
        public void AuthSignoutPost()
        {


            var path = "/auth/signout";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling AuthSignoutPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling AuthSignoutPost: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Creates a new schedule on Tableau Server. Schedules are not specific to sites. For more information, see Scheduled Refresh Tasks and Subscriptions and Create or Modify a Schedule in the Tableau Server documentation.  Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.
        /// </summary>
        /// <param name="createScheduleRequest">CreateScheduleRequest</param> 
        /// <returns></returns>            
        public void SchedulesPost(CreateScheduleRequest createScheduleRequest)
        {

            // verify the required parameter 'createScheduleRequest' is set
            if (createScheduleRequest == null) throw new ApiException(400, "Missing required parameter 'createScheduleRequest' when calling SchedulesPost");


            var path = "/schedules";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(createScheduleRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SchedulesPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SchedulesPost: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes the specified schedule. ##### Permissions: This method can only be called by server administrators.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="scheduleId">The ID of the schedule to delete. To determine what schedules are available, call Query Schedules.</param> 
        /// <returns></returns>            
        public void SchedulesScheduleIdDelete(string scheduleId)
        {

            // verify the required parameter 'scheduleId' is set
            if (scheduleId == null) throw new ApiException(400, "Missing required parameter 'scheduleId' when calling SchedulesScheduleIdDelete");


            var path = "/schedules/{schedule-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "schedule-id" + "}", ApiClient.ParameterToString(scheduleId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SchedulesScheduleIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SchedulesScheduleIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Modifies settings for the specified schedule, including the name, priority, and frequency details. 
        /// </summary>
        /// <param name="scheduleId">The ID of the schedule to update. To determine what schedules are available, call Query Schedules.</param> 
        /// <param name="updateScheduleRequest">UpdateScheduleRequest</param> 
        /// <returns></returns>            
        public void SchedulesScheduleIdPut(string scheduleId, UpdateScheduleRequest updateScheduleRequest)
        {

            // verify the required parameter 'scheduleId' is set
            if (scheduleId == null) throw new ApiException(400, "Missing required parameter 'scheduleId' when calling SchedulesScheduleIdPut");

            // verify the required parameter 'updateScheduleRequest' is set
            if (updateScheduleRequest == null) throw new ApiException(400, "Missing required parameter 'updateScheduleRequest' when calling SchedulesScheduleIdPut");


            var path = "/schedules/{schedule-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "schedule-id" + "}", ApiClient.ParameterToString(scheduleId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateScheduleRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SchedulesScheduleIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SchedulesScheduleIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes the specified site. You can specify the site to delete by using the site ID, the site name, or the content URL. You use the key query string parameter to indicate how you are specifying the site, as shown in the URIs.  Note: You must have previously called Sign In and signed in to a site in order to delete the site. (When you call this method, you must include the authentication token that you got back when you signed into the site.)  ##### Permissions: This method can only be called by server administrators.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d5-e4f3-a2b1-c0d9-e8f7a6b5c4d\&quot; -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;curl \&quot;http://MY-SERVER/api/2.5/sites/marketing-site?key&#x3D;contentUrl\&quot; -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="contentUrlORSiteIdORSiteName">In case of content-url parameter: The URL of the site to delete. If you specify a content URL, you must also include the parameter key&#x3D;contentUrl.  In case of site-name parameter: The name of the site to delete. If you specify a site name, you must also include the parameter key&#x3D;name.  In case of site-id parameter: The ID of the site to delete.</param> 
        /// <returns></returns>            
        public void SitesContentUrlORSiteIdORSiteNameDelete(string contentUrlORSiteIdORSiteName)
        {

            // verify the required parameter 'contentUrlORSiteIdORSiteName' is set
            if (contentUrlORSiteIdORSiteName == null) throw new ApiException(400, "Missing required parameter 'contentUrlORSiteIdORSiteName' when calling SitesContentUrlORSiteIdORSiteNameDelete");


            var path = "/sites/{content-url-OR-site-id-OR-site-name}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "content-url-OR-site-id-OR-site-name" + "}", ApiClient.ParameterToString(contentUrlORSiteIdORSiteName));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesContentUrlORSiteIdORSiteNameDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesContentUrlORSiteIdORSiteNameDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Modifies settings for the specified site, including the content URL, administration mode, user quota, state (active or suspended), storage quota, whether subscriptions are enabled, and whether revisions are enabled. If you&#39;re working with Tableau Online, this method can also be used to upload a new logo image for the site. 
        /// </summary>
        /// <param name="contentUrlORSiteIdORSiteName">The ID of the site to update.</param> 
        /// <param name="updateSiteRequest">UpdateSiteRequest</param> 
        /// <returns></returns>            
        public void SitesContentUrlORSiteIdORSiteNamePut(string contentUrlORSiteIdORSiteName, UpdateSiteRequest updateSiteRequest)
        {

            // verify the required parameter 'contentUrlORSiteIdORSiteName' is set
            if (contentUrlORSiteIdORSiteName == null) throw new ApiException(400, "Missing required parameter 'contentUrlORSiteIdORSiteName' when calling SitesContentUrlORSiteIdORSiteNamePut");

            // verify the required parameter 'updateSiteRequest' is set
            if (updateSiteRequest == null) throw new ApiException(400, "Missing required parameter 'updateSiteRequest' when calling SitesContentUrlORSiteIdORSiteNamePut");


            var path = "/sites/{content-url-OR-site-id-OR-site-name}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "content-url-OR-site-id-OR-site-name" + "}", ApiClient.ParameterToString(contentUrlORSiteIdORSiteName));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateSiteRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesContentUrlORSiteIdORSiteNamePut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesContentUrlORSiteIdORSiteNamePut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Creates a site on Tableau Server. To make changes to an existing site, call Update Site. For more information, see Work with Sites and Add or Edit Sites in the Tableau Server documentation.  Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.
        /// </summary>
        /// <param name="createSiteRequest">CreateSiteRequest</param> 
        /// <returns></returns>            
        public void SitesPost(CreateSiteRequest createSiteRequest)
        {

            // verify the required parameter 'createSiteRequest' is set
            if (createSiteRequest == null) throw new ApiException(400, "Missing required parameter 'createSiteRequest' when calling SitesPost");


            var path = "/sites";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(createSiteRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesPost: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Updates the server address, port, username, or password for the specified data source connection. Note Starting with Tableau Server 10.0, data sources can have multiple connections. This method can be used to update a specific connection in a data source. If the data source was created in Tableau 9.3 or earlier, the previous syntax for this method (without /connections/connection-id in the URI) will work. However, we recommend that you use the syntax documented here for all data sources.  ##### Permissions: Only Tableau Server users who are server administrators or site administrators can change the connection for a data source. Users who are not server administrators can update a data source only if they have Write (save) permission for the data source and if they have write permission for the project.  ##### Version: Version 2.3 and later. (A different version of this method was available in earlier versions of the REST API. For details, see Update Datasource Connection in the REST API version 9.3 documentation.) For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;connection      serverAddress&#x3D;\&quot;server-address\&quot; serverPort&#x3D;\&quot;port\&quot;      userName&#x3D;\&quot;connection-username\&quot; password&#x3D;\&quot;connection-password\&quot;       embedPassword&#x3D;\&quot;embed-password\&quot;  /&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;connection id&#x3D;\&quot;connection-id\&quot;      serverAddress&#x3D;\&quot;serverAddress\&quot; serverPort&#x3D;\&quot;port\&quot;      userName&#x3D;\&quot;connection-user-name\&quot; /&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param> 
        /// <param name="datasourceId">The ID of the data source to update.</param> 
        /// <param name="connectionId">The ID of the connection to update. To determine what connections are available for a data source, call Query Datasource Connections.</param> 
        /// <param name="updateDatasourceConnectionRequest">UpdateDatasourceConnectionRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdDatasourcesDatasourceIdConnectionsConnectionIdPut(string siteId, string datasourceId, string connectionId, UpdateDatasourceConnectionRequest updateDatasourceConnectionRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdDatasourcesDatasourceIdConnectionsConnectionIdPut");

            // verify the required parameter 'datasourceId' is set
            if (datasourceId == null) throw new ApiException(400, "Missing required parameter 'datasourceId' when calling SitesSiteIdDatasourcesDatasourceIdConnectionsConnectionIdPut");

            // verify the required parameter 'connectionId' is set
            if (connectionId == null) throw new ApiException(400, "Missing required parameter 'connectionId' when calling SitesSiteIdDatasourcesDatasourceIdConnectionsConnectionIdPut");

            // verify the required parameter 'updateDatasourceConnectionRequest' is set
            if (updateDatasourceConnectionRequest == null) throw new ApiException(400, "Missing required parameter 'updateDatasourceConnectionRequest' when calling SitesSiteIdDatasourcesDatasourceIdConnectionsConnectionIdPut");


            var path = "/sites/{site-id}/datasources/{datasource-id}/connections/{connection-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "datasource-id" + "}", ApiClient.ParameterToString(datasourceId));
            path = path.Replace("{" + "connection-id" + "}", ApiClient.ParameterToString(connectionId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateDatasourceConnectionRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdConnectionsConnectionIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdConnectionsConnectionIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns a list of data connections for the specified data source. ##### Permissions: Tableau Server users who are not server administrators or site administrators can query a data source only if they have Read (view) permission for the data source (either explicitly or implicitly).  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;connections&gt;      &lt;connection id&#x3D;\&quot;connection-id\&quot; type&#x3D;\&quot;connection-type\&quot;        serverAddress&#x3D;\&quot;server-address\&quot; serverPort&#x3D;\&quot;port\&quot;        userName&#x3D;\&quot;connection-user-name\&quot; /&gt;      ... additional connections ...    &lt;/connections&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/datasources/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/connections\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;connections&gt;      &lt;connection id&#x3D;\&quot;12ab34cd-56ef-78ab-90cd-12ef34ab56cd\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;374371c0-ffe9-4e16-b48e-6b868e3026ca\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;08a7b6b5-b4ba-be3a-4d2d-1e9e59a8a7b6\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;    &lt;/connections&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param> 
        /// <param name="datasourceId">The ID of the datasource to return connection information about.</param> 
        /// <returns></returns>            
        public void SitesSiteIdDatasourcesDatasourceIdConnectionsGet(string siteId, string datasourceId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdDatasourcesDatasourceIdConnectionsGet");

            // verify the required parameter 'datasourceId' is set
            if (datasourceId == null) throw new ApiException(400, "Missing required parameter 'datasourceId' when calling SitesSiteIdDatasourcesDatasourceIdConnectionsGet");


            var path = "/sites/{site-id}/datasources/{datasource-id}/connections";
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
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdConnectionsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdConnectionsGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Downloads a data source in .tdsx format. ##### Permissions: Tableau Server users who are not server administrators or site administrators can download a data source only if they have ExportXml permission for the data source (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; .tdsxContent-Type:  application/octet-streamContent-Disposition: name&#x3D;\&quot;tableau_datasource\&quot;; filename&#x3D;\&quot;datasource-filename\&quot;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/datasources/1a2a3b4b-5c6c-7d8d-9e0e-1f2f3a4a5b6b/content\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot; &gt; my-datasource.tdsx  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param> 
        /// <param name="datasourceId">The ID of the data source to download.</param> 
        /// <param name="extractValue">(Optional) The extract-value is a Boolean value (False or True). When the data source specified for download has an extract, if you add the parameter ?includeExtract&#x3D;False, the extract is not included when you download the data source. You can use this parameter to improve performance if you are downloading workbooks or data sources that have large extracts.</param> 
        /// <returns></returns>            
        public void SitesSiteIdDatasourcesDatasourceIdContentGet(string siteId, string datasourceId, string extractValue)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdDatasourcesDatasourceIdContentGet");

            // verify the required parameter 'datasourceId' is set
            if (datasourceId == null) throw new ApiException(400, "Missing required parameter 'datasourceId' when calling SitesSiteIdDatasourcesDatasourceIdContentGet");


            var path = "/sites/{site-id}/datasources/{datasource-id}/content";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "datasource-id" + "}", ApiClient.ParameterToString(datasourceId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (extractValue != null) queryParams.Add("extract-value", ApiClient.ParameterToString(extractValue)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdContentGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdContentGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Adds permissions to the specified data source for a Tableau Server user or group. You can specify multiple sets of permissions using one call. If a specified permission has already been granted or denied for a given user or group, the system ignores it. If the request body includes a child workbook or &lt;project&gt; element, the request is invalid. ##### Permissions: Tableau Server users who are not server administrators or site administrators can add permissions only to a data source for which they have ChangePermissions permission (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability-name\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability-name\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capability sets ...    &lt;/permissions&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capability sets ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param> 
        /// <param name="datasourceId">The ID of the data source to set permissions for.</param> 
        /// <param name="addDatasourcePermissionRequest">AddDatasourcePermissionRequest</param> 
        /// <returns>AddDatasourcePermissionsResponse</returns>            
        public AddDatasourcePermissionsResponse SitesSiteIdDatasourcesDatasourceIdPermissionsPut(string siteId, string datasourceId, AddDatasourcePermissionRequest addDatasourcePermissionRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdDatasourcesDatasourceIdPermissionsPut");

            // verify the required parameter 'datasourceId' is set
            if (datasourceId == null) throw new ApiException(400, "Missing required parameter 'datasourceId' when calling SitesSiteIdDatasourcesDatasourceIdPermissionsPut");

            // verify the required parameter 'addDatasourcePermissionRequest' is set
            if (addDatasourcePermissionRequest == null) throw new ApiException(400, "Missing required parameter 'addDatasourcePermissionRequest' when calling SitesSiteIdDatasourcesDatasourceIdPermissionsPut");


            var path = "/sites/{site-id}/datasources/{datasource-id}/permissions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "datasource-id" + "}", ApiClient.ParameterToString(datasourceId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addDatasourcePermissionRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdPermissionsPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdPermissionsPut: " + response.ErrorMessage, response.ErrorMessage);

            return (AddDatasourcePermissionsResponse)ApiClient.Deserialize(response.Content, typeof(AddDatasourcePermissionsResponse), response.Headers);
        }

        /// <summary>
        /// Updates the owner, or project of the specified data source. 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param> 
        /// <param name="datasourceId">The ID of the data source to update.</param> 
        /// <param name="updateDatasourceRequest">UpdateDatasourceRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdDatasourcesDatasourceIdPut(string siteId, string datasourceId, UpdateDatasourceRequest updateDatasourceRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdDatasourcesDatasourceIdPut");

            // verify the required parameter 'datasourceId' is set
            if (datasourceId == null) throw new ApiException(400, "Missing required parameter 'datasourceId' when calling SitesSiteIdDatasourcesDatasourceIdPut");

            // verify the required parameter 'updateDatasourceRequest' is set
            if (updateDatasourceRequest == null) throw new ApiException(400, "Missing required parameter 'updateDatasourceRequest' when calling SitesSiteIdDatasourcesDatasourceIdPut");


            var path = "/sites/{site-id}/datasources/{datasource-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "datasource-id" + "}", ApiClient.ParameterToString(datasourceId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateDatasourceRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Downloads a specific version of a data source in .tdsx format. Note: This method is available only if version history is enabled for the specified site. For more information, see Maintain a History of Revisions in the Tableau Server Help.  ##### Permissions: Tableau Server users who are site administrators can download data source revisions on the site that they are administrators for. Users who are not server administrators or site administrators can get data source revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified data source. Save (write) permissions for the project that contains the data source.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; .tdsxContent-Type:  application/octet-streamContent-Disposition: name&#x3D;\&quot;tableau_datasource\&quot;; filename&#x3D;\&quot;datasource-filename\&quot;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param> 
        /// <param name="datasourceId">The ID of the data source to download.</param> 
        /// <param name="revisionNumber">The revision number of the data source to download. To determine what versions are available, call Get Datasource Revisions.</param> 
        /// <param name="extractValue">(Optional) The extract-value is a Boolean value (False or True). When the data source specified for download has an extract, if you add the parameter ?includeExtract&#x3D;False, the extract is not included when you download the data source. You can use this parameter to improve performance if you are downloading workbooks or data sources that have large extracts.</param> 
        /// <returns></returns>            
        public void SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberContentGet(string siteId, string datasourceId, string revisionNumber, string extractValue)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberContentGet");

            // verify the required parameter 'datasourceId' is set
            if (datasourceId == null) throw new ApiException(400, "Missing required parameter 'datasourceId' when calling SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberContentGet");

            // verify the required parameter 'revisionNumber' is set
            if (revisionNumber == null) throw new ApiException(400, "Missing required parameter 'revisionNumber' when calling SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberContentGet");


            var path = "/sites/{site-id}/datasources/{datasource-id}/revisions/{revision-number}/content";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "datasource-id" + "}", ApiClient.ParameterToString(datasourceId));
            path = path.Replace("{" + "revision-number" + "}", ApiClient.ParameterToString(revisionNumber));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (extractValue != null) queryParams.Add("extract-value", ApiClient.ParameterToString(extractValue)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberContentGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberContentGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Removes a specific version of a data source from the specified site. The content is removed, and the specified revision can no longer be downloaded using Download Datasource Revision. If you call Get Datasource Revisions, the revision that&#39;s been removed is listed with the attribute IsDeleted&#x3D;\&quot;true\&quot;.  Note: Calling this method permanently removes the specified datasource revision.  ##### Permissions: Tableau Server users who are site administrators can remove data source revisions on the site that they are administrators for. Users who are not server administrators or site administrators can remove data source revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified data source. Save (write) permissions for the project that contains the data source.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the group.</param> 
        /// <param name="datasourceId">The ID of the data source to remove the revision for.</param> 
        /// <param name="revisionNumber">The revision number of the data source to remove. To determine what versions are available, call Get Datasource Revisions.</param> 
        /// <returns></returns>            
        public void SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberDelete(string siteId, string datasourceId, string revisionNumber)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberDelete");

            // verify the required parameter 'datasourceId' is set
            if (datasourceId == null) throw new ApiException(400, "Missing required parameter 'datasourceId' when calling SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberDelete");

            // verify the required parameter 'revisionNumber' is set
            if (revisionNumber == null) throw new ApiException(400, "Missing required parameter 'revisionNumber' when calling SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberDelete");


            var path = "/sites/{site-id}/datasources/{datasource-id}/revisions/{revision-number}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "datasource-id" + "}", ApiClient.ParameterToString(datasourceId));
            path = path.Replace("{" + "revision-number" + "}", ApiClient.ParameterToString(revisionNumber));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesDatasourceIdRevisionsRevisionNumberDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns a list of data sources on the specified site, with optional parameters for specifying the paging of large results. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can view a data source only if they have Connect permission for the data source (either explicitly or implicitly).  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot; pageSize&#x3D;\&quot;page-size\&quot;      totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;datasources&gt;      &lt;datasource id&#x3D;\&quot;datasource1-id\&quot;        name&#x3D;\&quot;datasource-name\&quot;        contentUrl&#x3D;\&quot;datasource-content-url\&quot;        type&#x3D;\&quot;datasource-type\&quot;         createdAt&#x3D;\&quot;datetime-created\&quot;        updatedAt&#x3D;\&quot;datetime-updated\&quot;&gt;        &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;        &lt;owner id&#x3D;\&quot;datasource-owner-id\&quot; /&gt;        &lt;tags&gt;         &lt;tag label&#x3D;\&quot;tag\&quot;/&gt;         ... additional tags ...        &lt;/tags&gt;      &lt;/datasource&gt;      ... additional datasources ...    &lt;/datasources&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/datasources\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot;/&gt;    &lt;datasources&gt;      &lt;datasource id&#x3D;\&quot;1a2a3b4b-5c6c-7d8d-9e0e-1f2f3a4a5b6b\&quot;           name&#x3D;\&quot;Sample - Coffee Chain (Access)\&quot; contentUrl&#x3D;\&quot;coffee-chain\&quot;  type&#x3D;\&quot;msaccess\&quot;            createdAt&#x3D;\&quot;2011-03-30T22:32:35Z\&quot; updatedAt&#x3D;\&quot;2016-01-13T01:00:02Z\&quot;&gt;        &lt;project id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; name&#x3D;\&quot;Default\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;        &lt;/tags&gt;      &lt;/datasource&gt;      &lt;datasource id&#x3D;\&quot;9f8e7d6c-5b4a-3f2e-1d0c-9b8a7f6e5d4c\&quot;            name&#x3D;\&quot;Activity rates and healthy living\&quot; contentUrl&#x3D;\&quot;activity-rates-and-healthy-living\&quot; type&#x3D;\&quot;excel-direct\&quot;            createdAt&#x3D;\&quot;2011-03-30T22:32:35Z\&quot; updatedAt&#x3D;\&quot;2016-01-13T01:00:02Z\&quot;&gt;        &lt;project id&#x3D;\&quot;12ab34cd-56ef-78ab-90cd-12ef34ab56cd\&quot; name&#x3D;\&quot;Default\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;        &lt;/tags&gt;      &lt;/datasource&gt;    &lt;/datasources&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data sources.</param> 
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   type: eq   siteRole: eq   tags: eq, in </param> 
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  type  siteRole  tags</param> 
        /// <returns></returns>            
        public void SitesSiteIdDatasourcesGet(string siteId, string filter, string sort)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdDatasourcesGet");


            var path = "/sites/{site-id}/datasources";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (filter != null) queryParams.Add("filter", ApiClient.ParameterToString(filter)); // query parameter
            if (sort != null) queryParams.Add("sort", ApiClient.ParameterToString(sort)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdDatasourcesGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes the specified data source from the user&#39;s favorites. If the specified data source is not a favorite, the operation has no effect. ##### Permissions: Tableau Server users who are not server administrators or site administrators can call this method only if they have Read (view) permissions on the data source (either explicitly or implicitly).  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the data source.</param> 
        /// <param name="userId">The ID of the user to remove the favorite from.</param> 
        /// <param name="datasourceId">The ID of the data source to remove from the user&#39;s favorites.</param> 
        /// <returns></returns>            
        public void SitesSiteIdFavoritesUserIdDatasourcesDatasourceIdDelete(string siteId, string userId, string datasourceId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdFavoritesUserIdDatasourcesDatasourceIdDelete");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdFavoritesUserIdDatasourcesDatasourceIdDelete");

            // verify the required parameter 'datasourceId' is set
            if (datasourceId == null) throw new ApiException(400, "Missing required parameter 'datasourceId' when calling SitesSiteIdFavoritesUserIdDatasourcesDatasourceIdDelete");


            var path = "/sites/{site-id}/favorites/{user-id}/datasources/{datasource-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));
            path = path.Replace("{" + "datasource-id" + "}", ApiClient.ParameterToString(datasourceId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdFavoritesUserIdDatasourcesDatasourceIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdFavoritesUserIdDatasourcesDatasourceIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Adds the specified view/datasource/workbook to a user&#39;s favorites. If the user already has the view listed as a favorite with the same label, the operation has no effect. If the label differs, the original favorite is overwritten.
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the view.</param> 
        /// <param name="userId">The ID of the user to add the favorite for.</param> 
        /// <param name="addToFavoritesRequest">AddToFavoritesRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdFavoritesUserIdPut(string siteId, string userId, AddToFavoritesRequest addToFavoritesRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdFavoritesUserIdPut");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdFavoritesUserIdPut");

            // verify the required parameter 'addToFavoritesRequest' is set
            if (addToFavoritesRequest == null) throw new ApiException(400, "Missing required parameter 'addToFavoritesRequest' when calling SitesSiteIdFavoritesUserIdPut");


            var path = "/sites/{site-id}/favorites/{user-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addToFavoritesRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdFavoritesUserIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdFavoritesUserIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes the specified view from user&#39;s favorites. If the specified view is not a favorite, the operation has no effect. ##### Permissions: Tableau Server users who are not server administrators or site administrators can delete a view only from their own favorites.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the view.</param> 
        /// <param name="userId">The ID of the user to remove the favorite from.</param> 
        /// <param name="viewId">The ID of the view to remove from the user&#39;s favorites.</param> 
        /// <returns></returns>            
        public void SitesSiteIdFavoritesUserIdViewsViewIdDelete(string siteId, string userId, string viewId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdFavoritesUserIdViewsViewIdDelete");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdFavoritesUserIdViewsViewIdDelete");

            // verify the required parameter 'viewId' is set
            if (viewId == null) throw new ApiException(400, "Missing required parameter 'viewId' when calling SitesSiteIdFavoritesUserIdViewsViewIdDelete");


            var path = "/sites/{site-id}/favorites/{user-id}/views/{view-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));
            path = path.Replace("{" + "view-id" + "}", ApiClient.ParameterToString(viewId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdFavoritesUserIdViewsViewIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdFavoritesUserIdViewsViewIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes a workbook from a user&#39;s favorites. If the specified workbook is not a favorite of the specified user, this call has no effect. ##### Permissions: Tableau Server users who are not server administrators or site administrators can remove a workbook only from their own favorites.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the user.</param> 
        /// <param name="userId">The ID of the user to remove the favorite from.</param> 
        /// <param name="workbookId">The ID of the workbook to remove from the user&#39;s favorites.</param> 
        /// <returns></returns>            
        public void SitesSiteIdFavoritesUserIdWorkbooksWorkbookIdDelete(string siteId, string userId, string workbookId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdFavoritesUserIdWorkbooksWorkbookIdDelete");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdFavoritesUserIdWorkbooksWorkbookIdDelete");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdFavoritesUserIdWorkbooksWorkbookIdDelete");


            var path = "/sites/{site-id}/favorites/{user-id}/workbooks/{workbook-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdFavoritesUserIdWorkbooksWorkbookIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdFavoritesUserIdWorkbooksWorkbookIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Uploads a block of data and appends it to the data that is already uploaded. This method is called after an upload has been initiated using Initiate File Upload. You call Append to File Upload as many times as needed in order to upload the complete contents of a file. When the final block of data has been uploaded, you call Publish Datasource or Publish Workbook to commit the file.  For more information, see Publishing Resources.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can call this method only if they have publishing rights on the site.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;fileUpload uploadSessionId&#x3D;upload-session-id                fileSize&#x3D;size-of-file-in-megabytes-after-append /&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site to upload the file to.</param> 
        /// <param name="uploadSessionId">The ID of the upload session. You get this value when you start an upload session using Initiate File Upload.</param> 
        /// <returns></returns>            
        public void SitesSiteIdFileUploadsUploadSessionIdPut(string siteId, string uploadSessionId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdFileUploadsUploadSessionIdPut");

            // verify the required parameter 'uploadSessionId' is set
            if (uploadSessionId == null) throw new ApiException(400, "Missing required parameter 'uploadSessionId' when calling SitesSiteIdFileUploadsUploadSessionIdPut");


            var path = "/sites/{site-id}/fileUploads/{upload-session-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "upload-session-id" + "}", ApiClient.ParameterToString(uploadSessionId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdFileUploadsUploadSessionIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdFileUploadsUploadSessionIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes the group on a specific site. Deleting a group does not delete the users in group, but users are no longer members of the group. Any permissions that were previously assigned to the group no longer apply. Note: You cannot delete the All Users group.  ##### Permissions: This method can be called by site administrators.  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/groups/1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d\&quot;  -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="groupId">The ID of the group to delete.</param> 
        /// <returns></returns>            
        public void SitesSiteIdGroupsGroupIdDelete(string siteId, string groupId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdGroupsGroupIdDelete");

            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling SitesSiteIdGroupsGroupIdDelete");


            var path = "/sites/{site-id}/groups/{group-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "group-id" + "}", ApiClient.ParameterToString(groupId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdGroupsGroupIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdGroupsGroupIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Gets a list of users in the specified group. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot;             pageSize&#x3D;\&quot;page-size\&quot;             totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;      &lt;users&gt;        &lt;user id&#x3D;\&quot;user-id\&quot;      name&#x3D;\&quot;user-name\&quot;      siteRole&#x3D;\&quot;site-role\&quot;      lastLogin&#x3D;\&quot;last-login-date-time\&quot;      externalAuthUserId&#x3D;\&quot;authentication-id-from-external-provider\&quot; /&gt;      ... additional user information ...     &lt;/users&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/groups/1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d/users\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot;/&gt;    &lt;users&gt;      &lt;user id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot; name&#x3D;\&quot;Adam\&quot; siteRole&#x3D;\&quot;Interactor\&quot; /&gt;      &lt;user id&#x3D;\&quot;59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba\&quot; name&#x3D;\&quot;Bob\&quot; siteRole&#x3D;\&quot;Publisher\&quot; /&gt;    &lt;/users&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the group.</param> 
        /// <param name="groupId">The ID of the group to get the users for.</param> 
        /// <param name="pageSize">(Optional) The number of items to return in one response. The minimum is 1. The maximum is 1000. The default is 100. For more information, see Paginating Results.</param> 
        /// <param name="pageNumber">(Optional) The offset for paging. The default is 1. For more information, see Paginating Results.</param> 
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   lastLogin: eq, gt, gte, lte   name: eq   siteRole: eq </param> 
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: lastLogin  name  siteRole</param> 
        /// <returns></returns>            
        public void SitesSiteIdGroupsGroupIdUsersGet(string siteId, string groupId, string pageSize, string pageNumber, string filter, string sort)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdGroupsGroupIdUsersGet");

            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling SitesSiteIdGroupsGroupIdUsersGet");


            var path = "/sites/{site-id}/groups/{group-id}/users";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "group-id" + "}", ApiClient.ParameterToString(groupId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (pageSize != null) queryParams.Add("page-size", ApiClient.ParameterToString(pageSize)); // query parameter
            if (pageNumber != null) queryParams.Add("page-number", ApiClient.ParameterToString(pageNumber)); // query parameter
            if (filter != null) queryParams.Add("filter", ApiClient.ParameterToString(filter)); // query parameter
            if (sort != null) queryParams.Add("sort", ApiClient.ParameterToString(sort)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdGroupsGroupIdUsersGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdGroupsGroupIdUsersGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Adds a user to the specified group. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the group.</param> 
        /// <param name="groupId">The ID of the group to add the user to.</param> 
        /// <param name="addUserToGroupRequest">AddUserToGroupRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdGroupsGroupIdUsersPut(string siteId, string groupId, AddUserToGroupRequest addUserToGroupRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdGroupsGroupIdUsersPut");

            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling SitesSiteIdGroupsGroupIdUsersPut");

            // verify the required parameter 'addUserToGroupRequest' is set
            if (addUserToGroupRequest == null) throw new ApiException(400, "Missing required parameter 'addUserToGroupRequest' when calling SitesSiteIdGroupsGroupIdUsersPut");


            var path = "/sites/{site-id}/groups/{group-id}/users";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "group-id" + "}", ApiClient.ParameterToString(groupId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addUserToGroupRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdGroupsGroupIdUsersPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdGroupsGroupIdUsersPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Removes a user from the specified group. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/groups/1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d/users/9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot; -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the group.</param> 
        /// <param name="groupId">The ID of the group to remove the user from.</param> 
        /// <param name="userId">The ID of the user to remove.</param> 
        /// <returns></returns>            
        public void SitesSiteIdGroupsGroupIdUsersUserIdDelete(string siteId, string groupId, string userId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdGroupsGroupIdUsersUserIdDelete");

            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling SitesSiteIdGroupsGroupIdUsersUserIdDelete");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdGroupsGroupIdUsersUserIdDelete");


            var path = "/sites/{site-id}/groups/{group-id}/users/{user-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "group-id" + "}", ApiClient.ParameterToString(groupId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdGroupsGroupIdUsersUserIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdGroupsGroupIdUsersUserIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Creates a group in Tableau Server. If the server is configured to use Active Directory for authentication, this method can create a group in Tableau Server and then import users from an Active Directory group. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  To add users to a group, call Add User To Group. To make changes to an existing group, call Update Group.  If you use the method to import users from an Active Directory, the import process can be performed immediately (synchronously) or as a background job (asynchronously).  Note: If Active Directory contains a large number of users, you should import them asynchronously; otherwise, the process can time out.  The Create Group response returns information in two ways: in the response header and in the response body. The ID of the new group is always returned as the value of the Location header. If you create a local group or import an Active Directory group immediately, the response body contains the name and ID of the new group. If you import an Active Directory group using a background process, the response body contains a &lt;job&gt; element that includes a job ID. You can use the job ID to check the status of the operation by calling Query Job.
        /// </summary>
        /// <param name="siteId">The ID of the site to create the group in.</param> 
        /// <param name="createGroupRequest">CreateGroupRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdGroupsPost(string siteId, CreateGroupRequest createGroupRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdGroupsPost");

            // verify the required parameter 'createGroupRequest' is set
            if (createGroupRequest == null) throw new ApiException(400, "Missing required parameter 'createGroupRequest' when calling SitesSiteIdGroupsPost");


            var path = "/sites/{site-id}/groups";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(createGroupRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdGroupsPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdGroupsPost: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Adds permissions to the specified project that will be applied by default to new workbooks and data sources as they are added to the project. You make separate requests to set default permissions for workbooks and for data sources. Content owners can override default permissions for their content, but only if project permissions have not been locked. Project permissions can be locked for a new project when you call Create Project or for an existing project by calling Update Project. For more information, see Lock Content Permissions to the Project.
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The ID of the project to set default permissions for.</param> 
        /// <param name="addDefaultPermissionRequest">AddDefaultPermissionRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectProjectIdDefaultPermissionsDatasourcesPut(string siteId, string projectId, AddDefaultPermissionRequest addDefaultPermissionRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectProjectIdDefaultPermissionsDatasourcesPut");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectProjectIdDefaultPermissionsDatasourcesPut");

            // verify the required parameter 'addDefaultPermissionRequest' is set
            if (addDefaultPermissionRequest == null) throw new ApiException(400, "Missing required parameter 'addDefaultPermissionRequest' when calling SitesSiteIdProjectProjectIdDefaultPermissionsDatasourcesPut");


            var path = "/sites/{site-id}/project/{project-id}/default-permissions/datasources";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addDefaultPermissionRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectProjectIdDefaultPermissionsDatasourcesPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectProjectIdDefaultPermissionsDatasourcesPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Adds permissions to the specified project that will be applied by default to new workbooks and data sources as they are added to the project. You make separate requests to set default permissions for workbooks and for data sources. Content owners can override default permissions for their content, but only if project permissions have not been locked. Project permissions can be locked for a new project when you call Create Project or for an existing project by calling Update Project. For more information, see Lock Content Permissions to the Project.
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The ID of the project to set default permissions for.</param> 
        /// <param name="addDefaultPermissionRequest">AddDefaultPermissionRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectProjectIdDefaultPermissionsWorkbooksPut(string siteId, string projectId, AddDefaultPermissionRequest addDefaultPermissionRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectProjectIdDefaultPermissionsWorkbooksPut");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectProjectIdDefaultPermissionsWorkbooksPut");

            // verify the required parameter 'addDefaultPermissionRequest' is set
            if (addDefaultPermissionRequest == null) throw new ApiException(400, "Missing required parameter 'addDefaultPermissionRequest' when calling SitesSiteIdProjectProjectIdDefaultPermissionsWorkbooksPut");


            var path = "/sites/{site-id}/project/{project-id}/default-permissions/workbooks";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addDefaultPermissionRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectProjectIdDefaultPermissionsWorkbooksPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectProjectIdDefaultPermissionsWorkbooksPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Adds permissions to the specified project for a Tableau Server user or group. You can specify multiple sets of permissions using one call. If the request body includes a child datasource or &lt;project&gt; element, the request is invalid. 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The ID of the project to set permissions for.</param> 
        /// <param name="addProjectPermissionRequest">AddProjectPermissionRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectProjectIdPermissionsPut(string siteId, string projectId, AddProjectPermissionRequest addProjectPermissionRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectProjectIdPermissionsPut");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectProjectIdPermissionsPut");

            // verify the required parameter 'addProjectPermissionRequest' is set
            if (addProjectPermissionRequest == null) throw new ApiException(400, "Missing required parameter 'addProjectPermissionRequest' when calling SitesSiteIdProjectProjectIdPermissionsPut");


            var path = "/sites/{site-id}/project/{project-id}/permissions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addProjectPermissionRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectProjectIdPermissionsPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectProjectIdPermissionsPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns a list of projects on the specified site, with optional parameters for specifying the paging of large results. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can call this method only if they have Read (view) permission for the project (either implicitly or explicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot;       pageSize&#x3D;\&quot;page-size\&quot;       totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;projects&gt;      &lt;project id&#x3D;\&quot;project1-id\&quot;         name&#x3D;\&quot;project1-name\&quot;         description&#x3D;\&quot;project1-description\&quot;         contentPermissions&#x3D;\&quot;content-permissions\&quot; /&gt;      &lt;project id&#x3D;\&quot;project2-id\&quot;         name&#x3D;\&quot;project2-name\&quot;         description&#x3D;\&quot;project2-description\&quot;         contentPermissions&#x3D;\&quot;content-permissions\&quot; /&gt;      ... additional projects ...    &lt;/projects&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/projects\&quot;  -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot; &lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot;/&gt;    &lt;projects&gt;      &lt;project id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; name&#x3D;\&quot;default\&quot;            description&#x3D;\&quot;The default project that was automatically created by Tableau.\&quot;            contentPermissions&#x3D;\&quot;LockedToProject\&quot;  /&gt;      &lt;project id&#x3D;\&quot;7b6b59a8-ac3c-4d1d-2e9e-0b5b4ba8a7b6\&quot; name&#x3D;\&quot;Tableau Samples\&quot;            description&#x3D;\&quot;A set of sample workbooks provided by Tableau Software.\&quot;            contentPermissions&#x3D;\&quot;ManagedByOwner\&quot; /&gt;    &lt;/projects&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the projects.</param> 
        /// <param name="pageSize">(Optional) The number of items to return in one response. The minimum is 1. The maximum is 1000. The default is 100. For more information, see Paginating Results.</param> 
        /// <param name="pageNumber">(Optional) The offset for paging. The default is 1. For more information, see Paginating Results.</param> 
        /// <returns>QueryProjectsResponse</returns>            
        public QueryProjectsResponse SitesSiteIdProjectsGet(string siteId, string pageSize, string pageNumber)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsGet");


            var path = "/sites/{site-id}/projects";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (pageSize != null) queryParams.Add("page-size", ApiClient.ParameterToString(pageSize)); // query parameter
            if (pageNumber != null) queryParams.Add("page-number", ApiClient.ParameterToString(pageNumber)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsGet: " + response.ErrorMessage, response.ErrorMessage);

            return (QueryProjectsResponse)ApiClient.Deserialize(response.Content, typeof(QueryProjectsResponse), response.Headers);
        }

        /// <summary>
        /// Creates a project on the specified site. To make changes to an existing project, call Update Project. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.
        /// </summary>
        /// <param name="siteId">The ID of the site to create the project in.</param> 
        /// <param name="createProjectRequest">CreateProjectRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsPost(string siteId, CreateProjectRequest createProjectRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsPost");

            // verify the required parameter 'createProjectRequest' is set
            if (createProjectRequest == null) throw new ApiException(400, "Missing required parameter 'createProjectRequest' when calling SitesSiteIdProjectsPost");


            var path = "/sites/{site-id}/projects";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(createProjectRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsPost: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns information about the default permissions for a project—that is, the permissions that will be set by default for workbooks and data sources that are added to the project. You make separate requests to query the default permissions for workbooks and for data sources. ##### Permissions: Tableau Server users who are not server administrators can query default permissions for a project only if they have the ProjectLeader permission for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;permissions&gt;      &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capabilities ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The project to get default permissions for.</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGet(string siteId, string projectId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGet");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGet");


            var path = "/sites/{site-id}/projects/{project-id}/default-permissions/datasources";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Removes default permissions from a project. After the default permission has been removed, workbooks or data sources that are added to the project do not get the specified permission by default. You make separate requests to remove default permissions for workbooks and for data sources, and you make separate requests to remove default permissions for a specific group or user. ##### Permissions: Tableau Server users who are not server administrators can remove permissions for a project only if they have ProjectLeader permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The ID of the project to remove the default permission for.</param> 
        /// <param name="groupId">The ID of the group to remove the default permission for.</param> 
        /// <param name="capabilityName">The capability to remove the permissions for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. Valid capabilities for a data source are ChangePermissions, Connect, Delete, ExportXml, Read (view), and Write. For more information, see Permissions.</param> 
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGroupsGroupIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string groupId, string capabilityName, string capabilityMode)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityName' is set
            if (capabilityName == null) throw new ApiException(400, "Missing required parameter 'capabilityName' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityMode' is set
            if (capabilityMode == null) throw new ApiException(400, "Missing required parameter 'capabilityMode' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGroupsGroupIdCapabilityNameCapabilityModeDelete");


            var path = "/sites/{site-id}/projects/{project-id}/default-permissions/datasources/groups/{group-id}/{capability-name}/{capability-mode}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));
            path = path.Replace("{" + "group-id" + "}", ApiClient.ParameterToString(groupId));
            path = path.Replace("{" + "capability-name" + "}", ApiClient.ParameterToString(capabilityName));
            path = path.Replace("{" + "capability-mode" + "}", ApiClient.ParameterToString(capabilityMode));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGroupsGroupIdCapabilityNameCapabilityModeDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesGroupsGroupIdCapabilityNameCapabilityModeDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Removes default permissions from a project. After the default permission has been removed, workbooks or data sources that are added to the project do not get the specified permission by default. You make separate requests to remove default permissions for workbooks and for data sources, and you make separate requests to remove default permissions for a specific group or user. ##### Permissions: Tableau Server users who are not server administrators can remove permissions for a project only if they have ProjectLeader permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The ID of the project to remove the default permission for.</param> 
        /// <param name="userId">The ID of the user to remove default permission for.</param> 
        /// <param name="capabilityName">The capability to remove the permissions for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. Valid capabilities for a data source are ChangePermissions, Connect, Delete, ExportXml, Read (view), and Write. For more information, see Permissions.</param> 
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesUsersUserIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string userId, string capabilityName, string capabilityMode)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityName' is set
            if (capabilityName == null) throw new ApiException(400, "Missing required parameter 'capabilityName' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityMode' is set
            if (capabilityMode == null) throw new ApiException(400, "Missing required parameter 'capabilityMode' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesUsersUserIdCapabilityNameCapabilityModeDelete");


            var path = "/sites/{site-id}/projects/{project-id}/default-permissions/datasources/users/{user-id}/{capability-name}/{capability-mode}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));
            path = path.Replace("{" + "capability-name" + "}", ApiClient.ParameterToString(capabilityName));
            path = path.Replace("{" + "capability-mode" + "}", ApiClient.ParameterToString(capabilityMode));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesUsersUserIdCapabilityNameCapabilityModeDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsDatasourcesUsersUserIdCapabilityNameCapabilityModeDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns information about the default permissions for a project—that is, the permissions that will be set by default for workbooks and data sources that are added to the project. You make separate requests to query the default permissions for workbooks and for data sources. ##### Permissions: Tableau Server users who are not server administrators can query default permissions for a project only if they have the ProjectLeader permission for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;permissions&gt;      &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capabilities ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The project to get default permissions for.</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGet(string siteId, string projectId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGet");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGet");


            var path = "/sites/{site-id}/projects/{project-id}/default-permissions/workbooks";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Removes default permissions from a project. After the default permission has been removed, workbooks or data sources that are added to the project do not get the specified permission by default. You make separate requests to remove default permissions for workbooks and for data sources, and you make separate requests to remove default permissions for a specific group or user. ##### Permissions: Tableau Server users who are not server administrators can remove permissions for a project only if they have ProjectLeader permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The ID of the project to remove the default permission for.</param> 
        /// <param name="groupId">The ID of the group to remove the default permission for.</param> 
        /// <param name="capabilityName">The capability to remove the permissions for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. Valid capabilities for a data source are ChangePermissions, Connect, Delete, ExportXml, Read (view), and Write. For more information, see Permissions.</param> 
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGroupsGroupIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string groupId, string capabilityName, string capabilityMode)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityName' is set
            if (capabilityName == null) throw new ApiException(400, "Missing required parameter 'capabilityName' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityMode' is set
            if (capabilityMode == null) throw new ApiException(400, "Missing required parameter 'capabilityMode' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGroupsGroupIdCapabilityNameCapabilityModeDelete");


            var path = "/sites/{site-id}/projects/{project-id}/default-permissions/workbooks/groups/{group-id}/{capability-name}/{capability-mode}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));
            path = path.Replace("{" + "group-id" + "}", ApiClient.ParameterToString(groupId));
            path = path.Replace("{" + "capability-name" + "}", ApiClient.ParameterToString(capabilityName));
            path = path.Replace("{" + "capability-mode" + "}", ApiClient.ParameterToString(capabilityMode));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGroupsGroupIdCapabilityNameCapabilityModeDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksGroupsGroupIdCapabilityNameCapabilityModeDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Removes default permissions from a project. After the default permission has been removed, workbooks or data sources that are added to the project do not get the specified permission by default. You make separate requests to remove default permissions for workbooks and for data sources, and you make separate requests to remove default permissions for a specific group or user. ##### Permissions: Tableau Server users who are not server administrators can remove permissions for a project only if they have ProjectLeader permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.1 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The ID of the project to remove the default permission for.</param> 
        /// <param name="userId">The ID of the user to remove default permission for.</param> 
        /// <param name="capabilityName">The capability to remove the permissions for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. Valid capabilities for a data source are ChangePermissions, Connect, Delete, ExportXml, Read (view), and Write. For more information, see Permissions.</param> 
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksUsersUserIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string userId, string capabilityName, string capabilityMode)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityName' is set
            if (capabilityName == null) throw new ApiException(400, "Missing required parameter 'capabilityName' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityMode' is set
            if (capabilityMode == null) throw new ApiException(400, "Missing required parameter 'capabilityMode' when calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksUsersUserIdCapabilityNameCapabilityModeDelete");


            var path = "/sites/{site-id}/projects/{project-id}/default-permissions/workbooks/users/{user-id}/{capability-name}/{capability-mode}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));
            path = path.Replace("{" + "capability-name" + "}", ApiClient.ParameterToString(capabilityName));
            path = path.Replace("{" + "capability-mode" + "}", ApiClient.ParameterToString(capabilityMode));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksUsersUserIdCapabilityNameCapabilityModeDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDefaultPermissionsWorkbooksUsersUserIdCapabilityNameCapabilityModeDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes the specified project on a specific site. When a project is deleted, all of its assets are also deleted: associated workbooks, data sources, project view options, and rights. Use this method with caution. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/projects/1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot;  -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The ID of the project to delete.</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdDelete(string siteId, string projectId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdDelete");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdDelete");


            var path = "/sites/{site-id}/projects/{project-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns information about the set of permissions allowed or denied for groups and users in a project. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;permissions&gt;      &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capabilities ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/projects/1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e/permissions\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;permissions&gt;      &lt;project id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; name&#x3D;\&quot;default\&quot;&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;      &lt;/project&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d\&quot;/&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;Read\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;Write\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The project to get permissions for.</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdPermissionsGet(string siteId, string projectId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdPermissionsGet");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdPermissionsGet");


            var path = "/sites/{site-id}/projects/{project-id}/permissions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdPermissionsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdPermissionsGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Removes the specified project permission for the specified group or user. ##### Permissions: Tableau Server users who are not server administrators or site administrators can remove permissions for a project only if they have ChangePermissions (version 2.0) or ProjectLeader (version 2.1) permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The ID of the project to remove the permission for.</param> 
        /// <param name="groupId">The ID of the group to remove the permission for.</param> 
        /// <param name="capabilityName">The capability to remove the permission for. In Tableau Server 10.0, valid capabilities for a project are ProjectLeader, Read (view), and Write. For more information, see Permissions.</param> 
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string groupId, string capabilityName, string capabilityMode)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling SitesSiteIdProjectsProjectIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityName' is set
            if (capabilityName == null) throw new ApiException(400, "Missing required parameter 'capabilityName' when calling SitesSiteIdProjectsProjectIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityMode' is set
            if (capabilityMode == null) throw new ApiException(400, "Missing required parameter 'capabilityMode' when calling SitesSiteIdProjectsProjectIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete");


            var path = "/sites/{site-id}/projects/{project-id}/permissions/groups/{group-id}/{capability-name}/{capability-mode}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));
            path = path.Replace("{" + "group-id" + "}", ApiClient.ParameterToString(groupId));
            path = path.Replace("{" + "capability-name" + "}", ApiClient.ParameterToString(capabilityName));
            path = path.Replace("{" + "capability-mode" + "}", ApiClient.ParameterToString(capabilityMode));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Removes the specified project permission for the specified group or user. ##### Permissions: Tableau Server users who are not server administrators or site administrators can remove permissions for a project only if they have ChangePermissions (version 2.0) or ProjectLeader (version 2.1) permissions for that project (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the project.</param> 
        /// <param name="projectId">The ID of the project to remove the permission for.</param> 
        /// <param name="userId">The ID of the user to remove project the permission for.</param> 
        /// <param name="capabilityName">The capability to remove the permission for. In Tableau Server 10.0, valid capabilities for a project are ProjectLeader, Read (view), and Write. For more information, see Permissions.</param> 
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete(string siteId, string projectId, string userId, string capabilityName, string capabilityMode)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdProjectsProjectIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityName' is set
            if (capabilityName == null) throw new ApiException(400, "Missing required parameter 'capabilityName' when calling SitesSiteIdProjectsProjectIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityMode' is set
            if (capabilityMode == null) throw new ApiException(400, "Missing required parameter 'capabilityMode' when calling SitesSiteIdProjectsProjectIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete");


            var path = "/sites/{site-id}/projects/{project-id}/permissions/users/{user-id}/{capability-name}/{capability-mode}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));
            path = path.Replace("{" + "capability-name" + "}", ApiClient.ParameterToString(capabilityName));
            path = path.Replace("{" + "capability-mode" + "}", ApiClient.ParameterToString(capabilityMode));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Modifies an existing subscription, allowing you to change the subject or schedule for the subscription. 
        /// </summary>
        /// <param name="siteId"> The ID of the site that contains the project.</param> 
        /// <param name="projectId"> The ID of the project to update.</param> 
        /// <param name="updateProjectRequest">UpdateProjectRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdProjectsProjectIdPut(string siteId, string projectId, UpdateProjectRequest updateProjectRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdProjectsProjectIdPut");

            // verify the required parameter 'projectId' is set
            if (projectId == null) throw new ApiException(400, "Missing required parameter 'projectId' when calling SitesSiteIdProjectsProjectIdPut");

            // verify the required parameter 'updateProjectRequest' is set
            if (updateProjectRequest == null) throw new ApiException(400, "Missing required parameter 'updateProjectRequest' when calling SitesSiteIdProjectsProjectIdPut");


            var path = "/sites/{site-id}/projects/{project-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "project-id" + "}", ApiClient.ParameterToString(projectId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateProjectRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdProjectsProjectIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns a list of the extract refresh tasks for a specified schedule on the specified site. To get the ID of a schedule, call the Query Schedules method. Note that the Query Schedules method is global to the server; schedules are not specific to a site. Therefore, the URI for the Query Schedules method does not include /sites/ or a site ID. However, individual scheduled tasks are specific to a site, and the URI for Query Extract Refresh Tasks must include the site information.  For more information about refresh tasks, see Manage Refresh Tasks.  ##### Permissions: This method can only be called by server administrators and site administrators. When a site administrator calls this method, the payload contains only the tasks that are associated with the site that the user is signed in to.  ##### Version: Version 2.2 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot;       pageSize&#x3D;\&quot;page-size\&quot;       totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;extracts&gt;       &lt;extract id&#x3D;\&quot;task-id\&quot;         priority&#x3D;\&quot;task-priority\&quot;        type&#x3D;\&quot;incremental-or-full\&quot; &gt;          &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;      &lt;/extract&gt;      &lt;extract id&#x3D;\&quot;task-id\&quot;         priority&#x3D;\&quot;task-priority\&quot;        type&#x3D;\&quot;incremental-or-full\&quot; &gt;          &lt;datasource id&#x3D;\&quot;datasource-id\&quot; /&gt;      &lt;/extract&gt;      ... additional extract refresh tasks ...     &lt;/extracts&gt;   &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/schedules/59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba/extracts\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &lt;tsResponse version-and-namespace-settings&gt;  &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot; /&gt;    &lt;extracts&gt;      &lt;extract id&#x3D;\&quot;639c7e80-0d11-44b2-9b5b-018ffc5eddb4\&quot; priority&#x3D;\&quot;60\&quot; type&#x3D;\&quot;FullRefresh\&quot;&gt;        &lt;datasource /&gt;      &lt;/extract&gt;      &lt;extract id&#x3D;\&quot;303f6c45-fb48-47aa-88d3-0dd87f5f5c74\&quot; priority&#x3D;\&quot;50\&quot; type&#x3D;\&quot;FullRefresh\&quot;&gt;        &lt;workbook /&gt;      &lt;/extract&gt;    &lt;/extracts&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the refresh tasks.</param> 
        /// <param name="scheduleId">The ID of the schedule to get extract information for.</param> 
        /// <param name="pageSize">(Optional) The number of items to return in one response. The minimum is 1. The maximum is 1000. The default is 100. For more information, see Paginating Results.</param> 
        /// <param name="pageNumber">(Optional) The offset for paging. The default is 1. For more information, see Paginating Results.</param> 
        /// <returns></returns>            
        public void SitesSiteIdSchedulesScheduleIdExtractsGet(string siteId, string scheduleId, string pageSize, string pageNumber)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdSchedulesScheduleIdExtractsGet");

            // verify the required parameter 'scheduleId' is set
            if (scheduleId == null) throw new ApiException(400, "Missing required parameter 'scheduleId' when calling SitesSiteIdSchedulesScheduleIdExtractsGet");


            var path = "/sites/{site-id}/schedules/{schedule-id}/extracts";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "schedule-id" + "}", ApiClient.ParameterToString(scheduleId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (pageSize != null) queryParams.Add("page-size", ApiClient.ParameterToString(pageSize)); // query parameter
            if (pageNumber != null) queryParams.Add("page-number", ApiClient.ParameterToString(pageNumber)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdSchedulesScheduleIdExtractsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdSchedulesScheduleIdExtractsGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Creates a new subscription to a view or workbook for a specific user. When a user is subscribed to the content, Tableau Server sends the content to the user in email on the schedule that&#39;s defined in Tableau Server and specified in this call. For more information, see Quick Start: Subscribe to Favorite Views in the Tableau Server documentation.  Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.
        /// </summary>
        /// <param name="siteId">The ID of the site to create the subscription in.</param> 
        /// <param name="createSubscriptionRequest">CreateSubscriptionRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdSubscriptionsPost(string siteId, CreateSubscriptionRequest createSubscriptionRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdSubscriptionsPost");

            // verify the required parameter 'createSubscriptionRequest' is set
            if (createSubscriptionRequest == null) throw new ApiException(400, "Missing required parameter 'createSubscriptionRequest' when calling SitesSiteIdSubscriptionsPost");


            var path = "/sites/{site-id}/subscriptions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(createSubscriptionRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdSubscriptionsPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdSubscriptionsPost: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes the specified subscription. ##### Permissions: Tableau Server users can call this method to delete any subscription that they had permission to create. For details, see Create Subscription.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the subscription.</param> 
        /// <param name="subscriptionId">The ID of the subscription to delete. To determine what subscriptions are available, call Query Subscriptions.</param> 
        /// <returns></returns>            
        public void SitesSiteIdSubscriptionsSubscriptionIdDelete(string siteId, string subscriptionId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdSubscriptionsSubscriptionIdDelete");

            // verify the required parameter 'subscriptionId' is set
            if (subscriptionId == null) throw new ApiException(400, "Missing required parameter 'subscriptionId' when calling SitesSiteIdSubscriptionsSubscriptionIdDelete");


            var path = "/sites/{site-id}/subscriptions/{subscription-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "subscription-id" + "}", ApiClient.ParameterToString(subscriptionId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdSubscriptionsSubscriptionIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdSubscriptionsSubscriptionIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Modifies an existing subscription, allowing you to change the subject or schedule for the subscription. 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="subscriptionId">The ID of the subscription to update.</param> 
        /// <param name="updateSubscriptionRequest">UpdateSubscriptionRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdSubscriptionsSubscriptionIdPut(string siteId, string subscriptionId, UpdateSubscriptionRequest updateSubscriptionRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdSubscriptionsSubscriptionIdPut");

            // verify the required parameter 'subscriptionId' is set
            if (subscriptionId == null) throw new ApiException(400, "Missing required parameter 'subscriptionId' when calling SitesSiteIdSubscriptionsSubscriptionIdPut");

            // verify the required parameter 'updateSubscriptionRequest' is set
            if (updateSubscriptionRequest == null) throw new ApiException(400, "Missing required parameter 'updateSubscriptionRequest' when calling SitesSiteIdSubscriptionsSubscriptionIdPut");


            var path = "/sites/{site-id}/subscriptions/{subscription-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "subscription-id" + "}", ApiClient.ParameterToString(subscriptionId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateSubscriptionRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdSubscriptionsSubscriptionIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdSubscriptionsSubscriptionIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns the users associated with the specified site. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;pagination pageNumber&#x3D;\&quot;page-number\&quot;       pageSize&#x3D;\&quot;page-size\&quot;       totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;     &lt;users&gt;      &lt;user id&#x3D;\&quot;user-id\&quot;        name&#x3D;\&quot;user-name\&quot;        siteRole&#x3D;\&quot;site-role\&quot;        lastLogin&#x3D;\&quot;date-time\&quot;        externalAuthUserId&#x3D;\&quot;authentication-id-from-external-provider\&quot;        authSetting&#x3D;\&quot;auth-setting\&quot; /&gt;      &lt;user id&#x3D;\&quot;user-id\&quot;        name&#x3D;\&quot;user-name\&quot;        siteRole&#x3D;\&quot;site-role\&quot;        lastLogin&#x3D;\&quot;date-time\&quot;        externalAuthUserId&#x3D;\&quot;authentication-id-from-external-provider\&quot;        authSetting&#x3D;\&quot;auth-setting\&quot; /&gt;    ... additional users ...    &lt;/users&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/users\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;161\&quot;/&gt;    &lt;users&gt;      &lt;user id&#x3D;\&quot;9f9e9d9c8-b8a8-f8e7-d7c7-b7a6f6d6e6d\&quot; name&#x3D;\&quot;Ashley\&quot;          siteRole&#x3D;\&quot;Viewer\&quot; /&gt;      &lt;user id&#x3D;\&quot;1f1e1d1c2-b2a2-f2e3-d3c3-b3a4f4e4d4c\&quot; name&#x3D;\&quot;Fred\&quot;          siteRole&#x3D;\&quot;ViewerWithPublish\&quot; /&gt;      &lt;user id&#x3D;\&quot;12ab34cd5-6ef7-8ab9-0cd1-2ef34ab56cd\&quot; name&#x3D;\&quot;Laura\&quot;          siteRole&#x3D;\&quot;Unlicensed\&quot; /&gt;      &lt;user id&#x3D;\&quot;9a8a7b6b5-c4c3-d2d1-e0e9-a8a7b6b5b4b\&quot; name&#x3D;\&quot;Michelle\&quot;          siteRole&#x3D;\&quot;Publisher\&quot; /&gt;      &lt;user id&#x3D;\&quot;9f8e7d6c5-b4a3-f2e1-d0c9-b8a7f6e5d4c\&quot; name&#x3D;\&quot;Susan\&quot;          siteRole&#x3D;\&quot;PublisherInteractor\&quot; /&gt;      ... another 95 users listed here ...    &lt;/users&gt;  &lt;/tsResponse&gt;curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/users?filter&#x3D;siteRole:eq:Unlicensed&amp;sort&#x3D;name:asc\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the users.</param> 
        /// <param name="fieldExpression">(Optional) An expression that lets you specify the set of available fields to return. You can qualify the return values based upon predefined keywords such as _all_ or _default_, and you can specify individual fields for the views or other supported resources. You can include multiple field expressions in a request. For more information, see Using Fields in the REST API.</param> 
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   lastLogin: eq, gt, gte, lte   name: eq   siteRole: eq </param> 
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: lastLogin  name  siteRole</param> 
        /// <returns>GetUsersOnSiteResponse</returns>            
        public IEnumerable<GetUsersOnSiteResponseUsersUser> SitesSiteIdUsersGet(string siteId, string fieldExpression, string filter, string sort)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdUsersGet");

            List<GetUsersOnSiteResponseUsersUser> users = new List<GetUsersOnSiteResponseUsersUser>();

            var path = "/sites/{site-id}/users";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (fieldExpression != null) queryParams.Add("field-expression", ApiClient.ParameterToString(fieldExpression)); // query parameter
            if (filter != null) queryParams.Add("filter", ApiClient.ParameterToString(filter)); // query parameter
            if (sort != null) queryParams.Add("sort", ApiClient.ParameterToString(sort)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersGet: " + response.ErrorMessage, response.ErrorMessage);

            var parsedResponse = (GetUsersOnSiteResponse)ApiClient.Deserialize(response.Content, typeof(GetUsersOnSiteResponse), response.Headers);
            users.AddRange(parsedResponse.Users.User);
            while (int.Parse(parsedResponse.Pagination.PageNumber) * int.Parse(parsedResponse.Pagination.PageSize) < int.Parse(parsedResponse.Pagination.TotalAvailable))
            {
                queryParams["pageSize"] = parsedResponse.Pagination.PageSize;
                queryParams["pageNumber"] = (int.Parse(parsedResponse.Pagination.PageNumber) + 1).ToString();

                response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

                if (((int)response.StatusCode) >= 400)
                    throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersGet: " + response.Content, response.Content);
                else if (((int)response.StatusCode) == 0)
                    throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersGet: " + response.ErrorMessage, response.ErrorMessage);

                parsedResponse = (GetUsersOnSiteResponse)ApiClient.Deserialize(response.Content, typeof(GetUsersOnSiteResponse), response.Headers);
                users.AddRange(parsedResponse.Users.User);
            }

            return users;
        }

        /// <summary>
        /// Adds a user to Tableau Server and assigns the user to the specified site. If Tableau Server is configured to use local authentication, the information you specify is used to create a new user in Tableau Server. To set a full name, password, and email address for the user, call Update User after creating the user. If Tableau Server is configured to use Active Directory for authentication, the user you specify is imported from Active Directory into Tableau Server. When you add user to Tableau Online, the name of the user must be the email address that is used to sign in to Tableau Online. After you add a user, Tableau Online sends the user an email invitation. The user can click the link in the invitation to sign in and update their full name and password. If you try to add a user using a specific site role but you have already reached the limit on the number of licenses for your users, the user is added as an unlicensed user. In that case, the response code is 201 (which indicates success), but the siteRole value in the response body is set to Unlicensed.
        /// </summary>
        /// <param name="siteId">The ID of the site to add users to.</param> 
        /// <param name="addUserToSiteRequest">AddUserToSiteRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdUsersPost(string siteId, AddUserToSiteRequest addUserToSiteRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdUsersPost");

            // verify the required parameter 'addUserToSiteRequest' is set
            if (addUserToSiteRequest == null) throw new ApiException(400, "Missing required parameter 'addUserToSiteRequest' when calling SitesSiteIdUsersPost");


            var path = "/sites/{site-id}/users";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addUserToSiteRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersPost: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Removes a user from the specified site. If a user still owns content (assets) on Tableau Server, the user cannot be deleted unless the ownership is reassigned first. If a user is removed from all sites that the user is a member of, the user is deleted.  ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/users/9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot; -X DELETE -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the user.</param> 
        /// <param name="userId">The ID of the user to remove.</param> 
        /// <returns></returns>            
        public void SitesSiteIdUsersUserIdDelete(string siteId, string userId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdUsersUserIdDelete");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdUsersUserIdDelete");


            var path = "/sites/{site-id}/users/{user-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersUserIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersUserIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Modifies information about the specified user. If Tableau Server is configured to use local authentication, you can update the user&#39;s name, email address, password, or site role.  If Tableau Server is configured to use Active Directory for authentication, you can change the user&#39;s display name (full name), email address, and site role. However, if you synchronize the user with Active Directory, the display name and email address will be overwritten with the information that&#39;s in Active Directory.  For Tableau Online, you can update the site role for a user, but you cannot update or change a user&#39;s password, user name (email address), or full name.
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the user.</param> 
        /// <param name="userId">The ID of the user to update.</param> 
        /// <param name="updateUserRequest">UpdateUserRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdUsersUserIdPut(string siteId, string userId, UpdateUserRequest updateUserRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdUsersUserIdPut");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdUsersUserIdPut");

            // verify the required parameter 'updateUserRequest' is set
            if (updateUserRequest == null) throw new ApiException(400, "Missing required parameter 'updateUserRequest' when calling SitesSiteIdUsersUserIdPut");


            var path = "/sites/{site-id}/users/{user-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateUserRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersUserIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersUserIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns the workbooks that the specified user owns in addition to those that the user has Read (view) permissions for. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: All users can call this method, but the results of the call depend on the user&#39;s permissions. Server and site administrators see all workbooks for the specified user. If the isOwner parameter is true, users who are not server or site administrators see the workbooks that they own on the site. If isOwner parameter is false, users who are not server administrators see the workbooks that they have Read (view) permissions for.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot; pageSize&#x3D;\&quot;page-size\&quot;           totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;workbooks&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; name&#x3D;\&quot;name\&quot;        contentUrl&#x3D;\&quot;content-url\&quot;          showTabs&#x3D;\&quot;show-tabs-flag\&quot;        size&#x3D;\&quot;size-in-megabytes\&quot;        createdAt&#x3D;\&quot;datetime-created\&quot;        updatedAt&#x3D;\&quot;datetime-updated\&quot;  &gt;        &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;        &lt;owner id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;tags&gt;          &lt;tag label&#x3D;\&quot;tag\&quot;/&gt;          ... additional tags ...        &lt;/tags&gt;     &lt;/workbook&gt;     ... additional workbooks ...  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/users/9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d/workbooks\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot;/&gt;    &lt;workbooks&gt;      &lt;workbook id&#x3D;\&quot;1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d\&quot; name&#x3D;\&quot;Finance\&quot;           contentUrl&#x3D;\&quot;Finance\&quot; showTabs&#x3D;\&quot;true\&quot; size&#x3D;\&quot;2\&quot;           createdAt&#x3D;\&quot;2013-03-30T22:32:35Z\&quot; updatedAt&#x3D;\&quot;2016-01-13T01:00:02Z\&quot;&gt;        &lt;project id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; name&#x3D;\&quot;Tableau Samples\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;&lt;/tags&gt;      &lt;/workbook&gt;      &lt;workbook id&#x3D;\&quot;59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba\&quot; name&#x3D;\&quot;World Indicators\&quot;           contentUrl&#x3D;\&quot;WorldIndicators\&quot; showTabs&#x3D;\&quot;true\&quot; size&#x3D;\&quot;1\&quot;            createdAt&#x3D;\&quot;2014-02-19T10:19:23Z\&quot; updatedAt&#x3D;\&quot;2015-12-29T013:23:45Z\&quot;&gt;        &lt;project id&#x3D;\&quot;08a7b6b5-b4ba-be3a-4d2d-1e9e59a8a7b6\&quot; name&#x3D;\&quot;default\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;&lt;/tags&gt;      &lt;/workbook&gt;    &lt;/workbooks&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the user.</param> 
        /// <param name="userId">The ID of the user to get workbooks for.</param> 
        /// <param name="isOwner">(Optional) true to return workbooks that the specified user owns, or false to return workbooks that the specified user has read access to. The default is false.</param> 
        /// <param name="pageSize">(Optional) The number of items to return in one response. The minimum is 1. The maximum is 1000. The default is 100. For more information, see Paginating Results.</param> 
        /// <param name="pageNumber">(Optional) The offset for paging. The default is 1. For more information, see Paginating Results.</param> 
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   ownerName: eq   tags: eq, in </param> 
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  ownerName  tags</param> 
        /// <returns></returns>            
        public void SitesSiteIdUsersUserIdWorkbooksGet(string siteId, string userId, string isOwner, string pageSize, string pageNumber, string filter, string sort)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdUsersUserIdWorkbooksGet");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdUsersUserIdWorkbooksGet");


            var path = "/sites/{site-id}/users/{user-id}/workbooks";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (isOwner != null) queryParams.Add("isOwner", ApiClient.ParameterToString(isOwner)); // query parameter
            if (pageSize != null) queryParams.Add("page-size", ApiClient.ParameterToString(pageSize)); // query parameter
            if (pageNumber != null) queryParams.Add("page-number", ApiClient.ParameterToString(pageNumber)); // query parameter
            if (filter != null) queryParams.Add("filter", ApiClient.ParameterToString(filter)); // query parameter
            if (sort != null) queryParams.Add("sort", ApiClient.ParameterToString(sort)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersUserIdWorkbooksGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdUsersUserIdWorkbooksGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns all the views for the specified site, optionally including usage statistics. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: For Tableau Server users who are not server administrators or site administrators, the method returns only the views that the user owns or has Read permissions for (either explicitly or implicitly).  ##### Version: Version 2.2 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;views&gt;      &lt;view id&#x3D;\&quot;view-id\&quot;           name&#x3D;\&quot;view-name\&quot;           contentUrl&#x3D;\&quot;content-url\&quot; &gt;        &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;        &lt;owner id&#x3D;\&quot;owner-id\&quot; /&gt;        &lt;usage totalViewCount&#x3D;\&quot;total-count\&quot; /&gt;      &lt;/view&gt;       ... additional views ...    &lt;/views&gt;  &lt;/tsResponse&gt;includeUsageStatistics&#x3D;true  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/views\&quot; -X GET -H \&quot;X-Tableau-Auth:1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/views\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot; /&gt;    &lt;views&gt;      &lt;view id&#x3D;\&quot;1f1e1d1c-2b2a-2f2e-3d3c-3b3a4f4e4d4c\&quot; name&#x3D;\&quot;Economic Indicators\&quot;            contentUrl&#x3D;\&quot;Finance/sheets/EconomicIndicators\&quot;&gt;        &lt;workbook id&#x3D;\&quot;1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d\&quot; /&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot; /&gt;      &lt;/view&gt;      &lt;view id&#x3D;\&quot;9a8a7b6b-5c4c-3d2d-1e0e-9a8a7b6b5b4b\&quot; name&#x3D;\&quot;Investing in the Dow\&quot;             contentUrl&#x3D;\&quot;Finance/sheets/InvestingintheDow\&quot;&gt;        &lt;workbook id&#x3D;\&quot;59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba\&quot; /&gt;        &lt;owner id&#x3D;\&quot;9f8e7d6c5-b4a3-f2e1-d0c9-b8a7f6e5d4c\&quot; /&gt;    &lt;/view&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the views.</param> 
        /// <param name="fieldExpression">(Optional) An expression that lets you specify the set of available fields to return. You can qualify the return values based upon predefined keywords such as _all_ or _default_, and you can specify individual fields for the workbooks or other supported resources. You can include multiple field expressions in a request. For more information, see Using Fields in the REST API.</param> 
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   tags: eq, in </param> 
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  tags</param> 
        /// <returns></returns>            
        public IEnumerable<QueryViewsForSiteResponseViewsView> SitesSiteIdViewsGet(string siteId, string fieldExpression, string filter, string sort)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdViewsGet");

            List<QueryViewsForSiteResponseViewsView> views = new List<QueryViewsForSiteResponseViewsView>();

            var path = "/sites/{site-id}/views";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (fieldExpression != null) queryParams.Add("fields", ApiClient.ParameterToString(fieldExpression)); // query parameter
            if (filter != null) queryParams.Add("filter", ApiClient.ParameterToString(filter)); // query parameter
            if (sort != null) queryParams.Add("sort", ApiClient.ParameterToString(sort)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdViewsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdViewsGet: " + response.ErrorMessage, response.ErrorMessage);


            var parsedResponse = (QueryViewsForSiteResponse)ApiClient.Deserialize(response.Content, typeof(QueryViewsForSiteResponse), response.Headers);
            if (parsedResponse.Views == null || parsedResponse.Views.Views == null || parsedResponse.Views.Views.Count == 0)
            {
                // TODO: add logging to note that we received a response which indiciated that this user has
                // access to no views 

                return views;
            } else views.AddRange(parsedResponse.Views.Views);
            while (int.Parse(parsedResponse.Pagination.PageNumber) * int.Parse(parsedResponse.Pagination.PageSize) <= int.Parse(parsedResponse.Pagination.TotalAvailable))
            {
                // TODO: Fix pagination bug 
                queryParams["pageSize"] = parsedResponse.Pagination.PageSize;
                queryParams["pageNumber"] = (int.Parse(parsedResponse.Pagination.PageNumber) + 1).ToString();

                response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

                if (((int)response.StatusCode) >= 400)
                {
                    dynamic errorResponse = (JsonObject)SimpleJson.DeserializeObject(response.Content);
                    if (errorResponse.ContainsKey("error") && errorResponse["error"].ContainsKey("code"))
                    {
                        throw new ApiException((int)errorResponse["error"].ContainsKey("code"), "Error calling SitesSiteIdViewsGet: " + response.Content, response.Content);
                    }
                    else
                    {
                        throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdViewsGet: " + response.Content, response.Content);
                    }
                }
                else if (((int)response.StatusCode) == 0)
                    throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdViewsGet: " + response.ErrorMessage, response.ErrorMessage);

                parsedResponse = (QueryViewsForSiteResponse)ApiClient.Deserialize(response.Content, typeof(QueryViewsForSiteResponse), response.Headers);
                if (parsedResponse.Views == null || parsedResponse.Views.Views == null || parsedResponse.Views.Views.Count == 0)
                {
                    // TODO: add logging to note that we received a response which indiciated that this user has
                    // access to no views 

                    return views;
                } else views.AddRange(parsedResponse.Views.Views);
            }

            return views;
        }

        /// <summary>
        /// Returns an image of the specified view. By default, the width of the returned image is 784 pixels. If you include the ?resolution&#x3D;high query parameter, the width of the returned image is 1568 pixels. For both resolutions, the height varies to preserve the aspect ratio of the view. If you make multiple requests for an image, subsequent calls return a cached version of the image. This means that the returned image might not include the latest changes to the view. To decrease the amount of time that an image is cached, use tabadmin to reduce the value of the vizportal.rest_api.view_image.max_age setting. For more information, see tabadmin set options in the Tableau Server help.  Note: If you want to disable this endpoint, use tabadmin to set the sheet_image.enabled setting to false. For more information, see tabadmin set options in the Tableau Server help.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can query workbook views only if they have Read (view) permission for the views (either explicitly or implicitly).  ##### Version: Version 2.5 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; image/png  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/views/9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d/image?resolution&#x3D;high\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the view.</param> 
        /// <param name="viewId">The ID of the view to return an image for.</param> 
        /// <returns></returns>            
        public void SitesSiteIdViewsViewIdImageGet(string siteId, string viewId, string filterExpression = null)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdViewsViewIdImageGet");

            // verify the required parameter 'viewId' is set
            if (viewId == null) throw new ApiException(400, "Missing required parameter 'viewId' when calling SitesSiteIdViewsViewIdImageGet");


            var path = $"/sites/{ApiClient.ParameterToString(siteId)}/views/{ApiClient.ParameterToString(viewId)}/image{(filterExpression != null ? $"?{filterExpression}" : "")}";
            //path = path.Replace("{format}", "json");
            //path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            //path = path.Replace("{" + "view-id" + "}", ApiClient.ParameterToString(viewId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdViewsViewIdImageGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdViewsViewIdImageGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns the workbooks on a site. If the user is not an administrator, the method returns just the workbooks that the user has permissions to view.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can get workbooks that they have Read (view) permissions for (either explicitly or implicitly).  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;page-number\&quot;       pageSize&#x3D;\&quot;page-size\&quot;       totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;workbooks&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; name&#x3D;\&quot;name\&quot;            contentUrl&#x3D;\&quot;content-url\&quot;              showTabs&#x3D;\&quot;show-tabs-flag\&quot;            size&#x3D;\&quot;size-in-megabytes\&quot;            createdAt&#x3D;\&quot;datetime-created\&quot;            updatedAt&#x3D;\&quot;datetime-updated\&quot;  &gt;        &lt;project id&#x3D;\&quot;project-id\&quot; name&#x3D;\&quot;project-name\&quot; /&gt;        &lt;owner id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;tags&gt;          &lt;tag label&#x3D;\&quot;tag\&quot;/&gt;          ... additional tags ...       &lt;/tags&gt;     &lt;/workbook&gt;     ... additional workbooks ...    &lt;/workbooks&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;27\&quot;/&gt;    &lt;workbooks&gt;      &lt;workbook id&#x3D;\&quot;1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d\&quot; name&#x3D;\&quot;Finance\&quot;           contentUrl&#x3D;\&quot;Finance\&quot; showTabs&#x3D;\&quot;true\&quot; size&#x3D;\&quot;2\&quot;           createdAt&#x3D;\&quot;2013-03-30T22:32:35Z\&quot; updatedAt&#x3D;\&quot;2016-01-13T01:00:02Z\&quot;&gt;        &lt;project id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; name&#x3D;\&quot;Tableau Samples\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;&lt;/tags&gt;      &lt;/workbook&gt;      &lt;workbook id&#x3D;\&quot;59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba\&quot; name&#x3D;\&quot;World Indicators\&quot;           contentUrl&#x3D;\&quot;WorldIndicators\&quot; showTabs&#x3D;\&quot;true\&quot; size&#x3D;\&quot;1\&quot;            createdAt&#x3D;\&quot;2014-02-19T10:19:23Z\&quot; updatedAt&#x3D;\&quot;2015-12-29T013:23:45Z\&quot;&gt;        &lt;project id&#x3D;\&quot;08a7b6b5-b4ba-be3a-4d2d-1e9e59a8a7b6\&quot; name&#x3D;\&quot;default\&quot;/&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;        &lt;tags&gt;            &lt;tag label&#x3D;\&quot;training\&quot; &gt;        &lt;/tags&gt;      &lt;/workbook&gt;    &lt;/workbooks&gt;    ... another 25 workbooks listed here ...    &lt;/tsResponse&gt;curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks?filter&#x3D;updatedAt:gte:2016-05-01T06:00:00Z&amp;sort&#x3D;name:asc\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbooks.</param> 
        /// <param name="fieldExpression">(Optional) An expression that lets you specify the set of available fields to return. You can qualify the return values based upon predefined keywords such as _all_ or _default_, and you can specify individual fields for the workbooks or other supported resources. You can include multiple field expressions in a request. For more information, see Using Fields in the REST API.</param> 
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   ownerName: eq   tags: eq, in </param> 
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  ownerName  tags</param> 
        /// <returns>QueryWorkbooksForSiteResponse</returns>            
        public QueryWorkbooksForSiteResponse SitesSiteIdWorkbooksGet(string siteId, string fieldExpression, string filter, string sort)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksGet");


            var path = "/sites/{site-id}/workbooks";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (fieldExpression != null) queryParams.Add("field-expression", ApiClient.ParameterToString(fieldExpression)); // query parameter
            if (filter != null) queryParams.Add("filter", ApiClient.ParameterToString(filter)); // query parameter
            if (sort != null) queryParams.Add("sort", ApiClient.ParameterToString(sort)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksGet: " + response.ErrorMessage, response.ErrorMessage);

            return (QueryWorkbooksForSiteResponse)ApiClient.Deserialize(response.Content, typeof(QueryWorkbooksForSiteResponse), response.Headers);
        }

        /// <summary>
        /// Updates the server address, port, username, or password for the specified workbook connection. If the workbook contains multiple connections to the same data source type, all the connections are updated. For example, if the workbook contains three connections to the same PostgreSQL database, and you attempt to update the user name of one of the connections, the user name is updated for all three connections.  Any combination of the attributes inside the &lt;connection&gt; element is valid. If no attributes are included, no update is made.    ##### Permissions: Tableau Server users who are not server administrators or site administrators can update permissions only for a workbook for which they have the Write capability (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;connection      serverAddress&#x3D;\&quot;server-address\&quot; serverPort&#x3D;\&quot;port\&quot;      userName&#x3D;\&quot;connection-username\&quot; password&#x3D;\&quot;connection-password\&quot;       embedPassword&#x3D;\&quot;embed-password\&quot;  /&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;connection id&#x3D;\&quot;connection-id\&quot;      serverAddress&#x3D;\&quot;server-address\&quot; serverPort&#x3D;\&quot;port\&quot;      userName&#x3D;\&quot;connection-user-name\&quot; /&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to update.</param> 
        /// <param name="connectionId">The ID of the connection to update.</param> 
        /// <param name="updateWorkbookConnectionRequest">UpdateWorkbookConnectionRequest</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdConnectionsConnectionIdPut(string siteId, string workbookId, string connectionId, UpdateWorkbookConnectionRequest updateWorkbookConnectionRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdConnectionsConnectionIdPut");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdConnectionsConnectionIdPut");

            // verify the required parameter 'connectionId' is set
            if (connectionId == null) throw new ApiException(400, "Missing required parameter 'connectionId' when calling SitesSiteIdWorkbooksWorkbookIdConnectionsConnectionIdPut");

            // verify the required parameter 'updateWorkbookConnectionRequest' is set
            if (updateWorkbookConnectionRequest == null) throw new ApiException(400, "Missing required parameter 'updateWorkbookConnectionRequest' when calling SitesSiteIdWorkbooksWorkbookIdConnectionsConnectionIdPut");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/connections/{connection-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));
            path = path.Replace("{" + "connection-id" + "}", ApiClient.ParameterToString(connectionId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateWorkbookConnectionRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdConnectionsConnectionIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdConnectionsConnectionIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns a list of data connections for the specific workbook. ##### Permissions: Tableau Server users who are not server administrators or site administrators can query a workbook only if they have Read (view) permission for the workbook (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;connections&gt;      &lt;connection id&#x3D;\&quot;connection-id\&quot; type&#x3D;\&quot;connection-type\&quot;        serverAddress&#x3D;\&quot;server-address\&quot; serverPort&#x3D;\&quot;port\&quot;        userName&#x3D;\&quot;connection-user-name\&quot; /&gt;      ... additional connections ...    &lt;/connections&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/connections\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;connections&gt;      &lt;connection id&#x3D;\&quot;12ab34cd-56ef-78ab-90cd-12ef34ab56cd\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;9a8a7b6b-5c4c-3d2d-1e0e-9a8a7b6b5b4b\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;7b6b59a8-ac3c-4d1d-2e9e-0b5b4ba8a7b6\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;374371c0-ffe9-4e16-b48e-6b868e3026ca\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;      &lt;connection id&#x3D;\&quot;08a7b6b5-b4ba-be3a-4d2d-1e9e59a8a7b6\&quot; type&#x3D;\&quot;dataengine\&quot; /&gt;    &lt;/connections&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to return connection information about.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdConnectionsGet(string siteId, string workbookId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdConnectionsGet");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdConnectionsGet");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/connections";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdConnectionsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdConnectionsGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Downloads a workbook in .twb or .twbx format. ##### Permissions: Tableau Server users who are not server administrators or site administrators can download a workbook only if they have ExportXml permission for the workbook (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; .twbContent-Type: application/xml.twbxContent-Type:  application/octet-streamContent-Disposition: name&#x3D;\&quot;tableau_workbook\&quot;; filename&#x3D;\&quot;workbook-filename\&quot;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/content\&quot;  -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;  &gt; c:\\files\\my-workbook.twbx  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to download.</param> 
        /// <param name="extractValue">(Optional) The extract-value is a Boolean value (False or True). When the workbook specified for download has an extract, if you add the parameter ?includeExtract&#x3D;False, the extract is not included when you download the workbook. You can use this option to improve performance if you are downloading workbooks or data sources that have large extracts.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdContentGet(string siteId, string workbookId, string extractValue)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdContentGet");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdContentGet");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/content";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (extractValue != null) queryParams.Add("extract-value", ApiClient.ParameterToString(extractValue)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdContentGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdContentGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes a workbook. When a workbook is deleted, all of its assets are also deleted, including associated views, data connections, and so on. ##### Permissions: Tableau Server users who are not server administrators or site administrators can delete a workbook for which they have Read (view) and Delete permissions (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to remove.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdDelete(string siteId, string workbookId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdDelete");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdDelete");


            var path = "/sites/{site-id}/workbooks/{workbook-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns a list of permissions for the specific workbook. ##### Permissions: This method can only be called by server administrators and site administrators.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;parent type&#x3D;\&quot;Project\&quot; id&#x3D;\&quot;project-id\&quot; /&gt;    &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; name&#x3D;\&quot;workbook-name &gt;        &lt;owner&#x3D;\&quot;owner-user-id\&quot; /&gt;      &lt;/workbook&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;           ... additional capabilities for users ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;           ... additional capabilities for groups ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capability sets ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/permissions\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;parent type&#x3D;\&quot;Project\&quot; id&#x3D;\&quot;1f2f3e4e-5d6d-7c8c-9b0b-1a2a3f4f5e6e\&quot; /&gt;    &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d\&quot; name&#x3D;\&quot;Finance\&quot;&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot;/&gt;      &lt;/workbook&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d\&quot;/&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;Read\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;Filter\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;ViewUnderlyingData\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;ExportImage\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;ExportData\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;AddComment\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;ViewComments\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;          &lt;capability name&#x3D;\&quot;ShareView\&quot; mode&#x3D;\&quot;Allow\&quot;/&gt;        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to return permission information about.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdPermissionsGet(string siteId, string workbookId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsGet");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsGet");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/permissions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPermissionsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPermissionsGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes the specified permission from the specified workbook for a group or user. ##### Permissions: Tableau Server users who are not server administrators or site administrators can delete permissions from a workbook only if they have ChangePermissions permission for workbook (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to remove the permission for.</param> 
        /// <param name="groupId">The ID of the group to remove the permission for.</param> 
        /// <param name="capabilityName">The capability to remove the permission for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. For more information, see Permissions.</param> 
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete(string siteId, string workbookId, string groupId, string capabilityName, string capabilityMode)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'groupId' is set
            if (groupId == null) throw new ApiException(400, "Missing required parameter 'groupId' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityName' is set
            if (capabilityName == null) throw new ApiException(400, "Missing required parameter 'capabilityName' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityMode' is set
            if (capabilityMode == null) throw new ApiException(400, "Missing required parameter 'capabilityMode' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/permissions/groups/{group-id}/{capability-name}/{capability-mode}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));
            path = path.Replace("{" + "group-id" + "}", ApiClient.ParameterToString(groupId));
            path = path.Replace("{" + "capability-name" + "}", ApiClient.ParameterToString(capabilityName));
            path = path.Replace("{" + "capability-mode" + "}", ApiClient.ParameterToString(capabilityMode));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPermissionsGroupsGroupIdCapabilityNameCapabilityModeDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Adds permissions to the specified workbook for a Tableau Server user or group. You can specify multiple sets of permissions using one call. ##### Permissions: Tableau Server users who are not server administrators or site administrators can call this method only if the have permission to set permissions on the workbook (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability-name\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability-name\&quot; mode&#x3D;\&quot;capability-mode\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capability sets ...    &lt;/permissions&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;permissions&gt;      &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;      &lt;granteeCapabilities&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      &lt;granteeCapabilities&gt;        &lt;group id&#x3D;\&quot;group-id\&quot; /&gt;        &lt;capabilities&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          &lt;capability name&#x3D;\&quot;capability\&quot; mode&#x3D;\&quot;Allow-or-Deny\&quot; /&gt;          ... additional capabilities ...        &lt;/capabilities&gt;      &lt;/granteeCapabilities&gt;      ... additional grantee capability sets ...    &lt;/permissions&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to set permissions for.</param> 
        /// <param name="addWorkbookPermissionRequest">AddWorkbookPermissionRequest</param> 
        /// <returns>AddWorkbookPermissionsResponse</returns>            
        public AddWorkbookPermissionsResponse SitesSiteIdWorkbooksWorkbookIdPermissionsPut(string siteId, string workbookId, AddWorkbookPermissionRequest addWorkbookPermissionRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsPut");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsPut");

            // verify the required parameter 'addWorkbookPermissionRequest' is set
            if (addWorkbookPermissionRequest == null) throw new ApiException(400, "Missing required parameter 'addWorkbookPermissionRequest' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsPut");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/permissions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addWorkbookPermissionRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPermissionsPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPermissionsPut: " + response.ErrorMessage, response.ErrorMessage);

            return (AddWorkbookPermissionsResponse)ApiClient.Deserialize(response.Content, typeof(AddWorkbookPermissionsResponse), response.Headers);
        }

        /// <summary>
        /// Deletes the specified permission from the specified workbook for a group or user. ##### Permissions: Tableau Server users who are not server administrators or site administrators can delete permissions from a workbook only if they have ChangePermissions permission for workbook (either explicitly or implicitly).  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to remove the permission for.</param> 
        /// <param name="userId">The ID of the user to remove the permission for.</param> 
        /// <param name="capabilityName">The capability to remove the permission for. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write. For more information, see Permissions.</param> 
        /// <param name="capabilityMode">Allow to remove the allow permission, or Deny to remove the deny permission. This value is case sensitive.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete(string siteId, string workbookId, string userId, string capabilityName, string capabilityMode)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityName' is set
            if (capabilityName == null) throw new ApiException(400, "Missing required parameter 'capabilityName' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete");

            // verify the required parameter 'capabilityMode' is set
            if (capabilityMode == null) throw new ApiException(400, "Missing required parameter 'capabilityMode' when calling SitesSiteIdWorkbooksWorkbookIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/permissions/users/{user-id}/{capability-name}/{capability-mode}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));
            path = path.Replace("{" + "user-id" + "}", ApiClient.ParameterToString(userId));
            path = path.Replace("{" + "capability-name" + "}", ApiClient.ParameterToString(capabilityName));
            path = path.Replace("{" + "capability-mode" + "}", ApiClient.ParameterToString(capabilityMode));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPermissionsUsersUserIdCapabilityNameCapabilityModeDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns the thumbnail image as a PNG file for the specified workbook. Usually the image that is returned is for the first sheet in the workbook. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can query a workbook preview image only if they have Read (view) permission for the workbook (either explicitly or implicitly) and also have Read (view) permission for the view that is used as the preview image. If the user doesn&#39;t have Read permissions to that view, the preview image for another view might be used. If the user doesn&#39;t have Read permissions to any views in the workbook, the user is not allowed to query a workbook query image.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; image/png  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/previewImage\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot; &gt; workbook-preview.png  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to return the thumbnail image for.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdPreviewImageGet(string siteId, string workbookId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdPreviewImageGet");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdPreviewImageGet");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/previewImage";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPreviewImageGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPreviewImageGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Modifies an existing workbook, allowing you to change the owner or project that the workbook belongs to and whether the workbook shows views in tabs. 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to update.</param> 
        /// <param name="updateWorkbookRequest">UpdateWorkbookRequest</param> 
        /// <returns>UpdateWorkbookResponse</returns>            
        public UpdateWorkbookResponse SitesSiteIdWorkbooksWorkbookIdPut(string siteId, string workbookId, UpdateWorkbookRequest updateWorkbookRequest)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdPut");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdPut");

            // verify the required parameter 'updateWorkbookRequest' is set
            if (updateWorkbookRequest == null) throw new ApiException(400, "Missing required parameter 'updateWorkbookRequest' when calling SitesSiteIdWorkbooksWorkbookIdPut");


            var path = "/sites/{site-id}/workbooks/{workbook-id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateWorkbookRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdPut: " + response.ErrorMessage, response.ErrorMessage);

            return (UpdateWorkbookResponse)ApiClient.Deserialize(response.Content, typeof(UpdateWorkbookResponse), response.Headers);
        }

        /// <summary>
        /// Returns a list of revision information (history) for the specified workbook. Note: This method is available only if version history is enabled for the specified site.  To get a specific version of the workbook from revision history, use the Download Workbook Revision method. For more information, see Maintain a History of Revisions in the Tableau Server Help.  ##### Permissions: Tableau Server users who are site administrators can get workbook revisions on the site that they are administrators for. Users who are not server administrators or site administrators can get workbook revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified workbook. Save (write) permissions for the project that contains the workbook.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;pagination pageNumber&#x3D;\&quot;pageNumber\&quot; pageSize&#x3D;\&quot;page-size\&quot;         totalAvailable&#x3D;\&quot;total-available\&quot; /&gt;    &lt;revisions&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;1\&quot; isDeleted&#x3D;\&quot;false\&quot;&gt;        &lt;user id&#x3D;\&quot;user-id\&quot; name&#x3D;\&quot;user-name\&quot;/&gt;      &lt;/revision&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;2\&quot; isDeleted&#x3D;\&quot;false\&quot;&gt;      &lt;/revision&gt;      &lt;revision createdAt&#x3D;\&quot;date\&quot; revisionNumber&#x3D;\&quot;3\&quot; isCurrent&#x3D;\&quot;true\&quot;&gt;          &lt;user id&#x3D;\&quot;user-id\&quot; name&#x3D;\&quot;user-name\&quot;/&gt;      &lt;/revision&gt;    &lt;/revisions&gt;  &lt;/tsResponse&gt;isDeleted&#x3D;\&quot;true\&quot;&lt;user&gt;&lt;revision&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook to get revisions for.</param> 
        /// <param name="workbookId">The ID of the workbook to get revisions for.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdRevisionsGet(string siteId, string workbookId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdRevisionsGet");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdRevisionsGet");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/revisions";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdRevisionsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdRevisionsGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Downloads a specific version of a workbook in .twb or .twbx format. Note: This method is available only if version history is enabled for the specified site. For more information, see Maintain a History of Revisions in the Tableau Server Help.  ##### Permissions: Tableau Server users who are site administrators can download workbook revisions on the site that they are administrators for. Users who are not server administrators or site administrators can download workbook revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified workbook. Save (write) permissions for the project that contains the workbook.  ##### Version: Version 2.3 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; .twbContent-Type: application/xml.twbxContent-Type:  application/octet-streamContent-Disposition: name&#x3D;\&quot;tableau_workbook\&quot;; filename&#x3D;\&quot;workbook-filename\&quot;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to download.</param> 
        /// <param name="revisionNumber">The revision number of the workbook to download. To determine what versions are available, call Get Workbook Revisions. Note that the current revision of a workbook cannot be accessed by this call; use Download Workbook instead.</param> 
        /// <param name="extractValue">(Optional) The extract-value is a Boolean value (False or True). When the workbook specified for download has an extract, if you add the parameter ?includeExtract&#x3D;False, the extract is not included when you download the workbook. You can use this option to improve performance if you are downloading workbooks or data sources that have large extracts.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberContentGet(string siteId, string workbookId, string revisionNumber, string extractValue)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberContentGet");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberContentGet");

            // verify the required parameter 'revisionNumber' is set
            if (revisionNumber == null) throw new ApiException(400, "Missing required parameter 'revisionNumber' when calling SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberContentGet");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/revisions/{revision-number}/content";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));
            path = path.Replace("{" + "revision-number" + "}", ApiClient.ParameterToString(revisionNumber));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (extractValue != null) queryParams.Add("extract-value", ApiClient.ParameterToString(extractValue)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberContentGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberContentGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Removes a specific version of a workbook from the specified site. The content is removed, and the specified revision can no longer be downloaded using Download Workbook Revision. If you call Get Workbook Revisions, the revision that&#39;s been removed is listed with the attribute IsDeleted&#x3D;\&quot;true\&quot;.  Note: Calling this method permanently removes the specified workbook revision.  ##### Permissions: Tableau Server users who are site administrators can remove workbook revisions on the site that they are administrators for. Users who are not server administrators or site administrators can remove workbook revisions if they have all of the following: A site role of Publisher. Read (view), Write (save), and Download (save as) permissions for the specified workbook. Save (write) permissions for the project that contains the workbook.  ##### Version: Version 2.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the group.</param> 
        /// <param name="workbookId">The ID of the workbook to remove the revision for.</param> 
        /// <param name="revisionNumber">The revision number of the workbook to remove. To determine what versions are available, call Get Workbook Revisions.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberDelete(string siteId, string workbookId, string revisionNumber)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberDelete");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberDelete");

            // verify the required parameter 'revisionNumber' is set
            if (revisionNumber == null) throw new ApiException(400, "Missing required parameter 'revisionNumber' when calling SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberDelete");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/revisions/{revision-number}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));
            path = path.Replace("{" + "revision-number" + "}", ApiClient.ParameterToString(revisionNumber));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdRevisionsRevisionNumberDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Adds one or more tags to the specified workbook. ##### Permissions: Tableau Server users who are not server administrators or site administrators can call this method only if they have Read permissions for the workbook (either explicitly or implicitly).  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60; &lt;tsRequest&gt;   &lt;tags&gt;      &lt;tag label&#x3D;\&quot;tag\&quot; /&gt;      ... additional tags ...    &lt;/tags&gt;  &lt;/tsRequest&gt;  &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;    &lt;workbook id&#x3D;\&quot;workbook-id\&quot;      name&#x3D;\&quot;workbook-name\&quot;&gt;      &lt;project id&#x3D;\&quot;project-id\&quot;        name&#x3D;\&quot;project-name\&quot; /&gt;      &lt;tags&gt;        &lt;tag label&#x3D;\&quot;tag\&quot;/&gt;        &lt;tag label&#x3D;\&quot;tag\&quot;/&gt;        ... additional tags ...      &lt;/tags&gt;      &lt;views&gt;        &lt;view id&#x3D;\&quot;view-id\&quot; /&gt;        &lt;view id&#x3D;\&quot;view-id\&quot; /&gt;        ... additional views ...      &lt;/views&gt;    &lt;/workbook&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/tags\&quot; -X PUT -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot; -d @add-tags-to-workbook.xml&lt;tsRequest&gt;      &lt;tags&gt;        &lt;tag label&#x3D;\&quot;GDP\&quot; /&gt;        &lt;tag label&#x3D;\&quot;Health\&quot; /&gt;      &lt;/tags&gt;  &lt;/tsRequest&gt;&lt;tsResponse version-and-namespace-settings&gt;    &lt;tags&gt;      &lt;tag label&#x3D;\&quot;GDP\&quot;/&gt;      &lt;tag label&#x3D;\&quot;Health\&quot;/&gt;      &lt;tag label&#x3D;\&quot;Spending\&quot;/&gt;    &lt;/tags&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to add tags to.</param> 
        /// <param name="addTagsToWorkbook">AddTagsToWorkbook</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdTagsPut(string siteId, string workbookId, AddTagsToWorkbook addTagsToWorkbook)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdTagsPut");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdTagsPut");

            // verify the required parameter 'addTagsToWorkbook' is set
            if (addTagsToWorkbook == null) throw new ApiException(400, "Missing required parameter 'addTagsToWorkbook' when calling SitesSiteIdWorkbooksWorkbookIdTagsPut");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/tags";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addTagsToWorkbook); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdTagsPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdTagsPut: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Deletes a tag from the specified workbook. ##### Permissions: Tableau Server users who are not server administrators, site administrators, or workbook owners can delete a tag from a workbook only if they are project leaders or if they originally added the tag.  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to remove the tag from.</param> 
        /// <param name="tagName">The name of the tag to remove from the workbook.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdTagsTagNameDelete(string siteId, string workbookId, string tagName)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdTagsTagNameDelete");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdTagsTagNameDelete");

            // verify the required parameter 'tagName' is set
            if (tagName == null) throw new ApiException(400, "Missing required parameter 'tagName' when calling SitesSiteIdWorkbooksWorkbookIdTagsTagNameDelete");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/tags/{tag-name}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));
            path = path.Replace("{" + "tag-name" + "}", ApiClient.ParameterToString(tagName));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdTagsTagNameDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdTagsTagNameDelete: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns all the views for the specified workbook, optionally including usage statistics. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can query workbook views only if they have Read (view) permission for the views (either explicitly or implicitly).  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;views&gt;      &lt;view id&#x3D;\&quot;view-id\&quot; name&#x3D;\&quot;view-name\&quot;          contentUrl&#x3D;\&quot;content-url\&quot; &gt;        &lt;usage totalViewCount&#x3D;\&quot;total-count\&quot; /&gt;      &lt;/view&gt;       ... additional views ...    &lt;/views&gt;  &lt;/tsResponse&gt;includeUsageStatistics&#x3D;true  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/workbooks/1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/views\&quot; -X GET -H \&quot;X-Tableau-Auth:12ab34cd56ef78ab90cd12ef34ab56cd\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;views&gt;      &lt;view id&#x3D;\&quot;1f1e1d1c-2b2a-2f2e-3d3c-3b3a4f4e4d4c\&quot; name&#x3D;\&quot;Tale of 100 Start-ups\&quot;            contentUrl&#x3D;\&quot;Finance/sheets/Taleof100Start-ups\&quot;/&gt;      &lt;view id&#x3D;\&quot;9a8a7b6b-5c4c-3d2d-1e0e-9a8a7b6b5b4b\&quot; name&#x3D;\&quot;Economic Indicators\&quot;            contentUrl&#x3D;\&quot;Finance/sheets/EconomicIndicators\&quot;/&gt;      &lt;view id&#x3D;\&quot;7b6b59a8-ac3c-4d1d-2e9e-0b5b4ba8a7b6\&quot; name&#x3D;\&quot;Investing in the Dow\&quot;            contentUrl&#x3D;\&quot;Finance/sheets/InvestingintheDow\&quot;/&gt;    &lt;/views&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the workbook.</param> 
        /// <param name="workbookId">The ID of the workbook to get the views for.</param> 
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   tags: eq, in </param> 
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  tags</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdViewsGet(string siteId, string workbookId, string filter, string sort)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdViewsGet");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdViewsGet");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/views";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (filter != null) queryParams.Add("filter", ApiClient.ParameterToString(filter)); // query parameter
            if (sort != null) queryParams.Add("sort", ApiClient.ParameterToString(sort)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdViewsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdViewsGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns the thumbnail image for the specified view. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: Tableau Server users who are not server administrators or site administrators can query workbook views only if they have Read (view) permission for the views (either explicitly or implicitly).  ##### Version: Version 1.0 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; image/png  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; undefined  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="siteId">The ID of the site that contains the view.</param> 
        /// <param name="workbookId">The ID of the workbook that contains the view to return a thumbnail image for.</param> 
        /// <param name="viewId">The ID of the view to return a thumbnail image for.</param> 
        /// <returns></returns>            
        public void SitesSiteIdWorkbooksWorkbookIdViewsViewIdPreviewImageGet(string siteId, string workbookId, string viewId)
        {

            // verify the required parameter 'siteId' is set
            if (siteId == null) throw new ApiException(400, "Missing required parameter 'siteId' when calling SitesSiteIdWorkbooksWorkbookIdViewsViewIdPreviewImageGet");

            // verify the required parameter 'workbookId' is set
            if (workbookId == null) throw new ApiException(400, "Missing required parameter 'workbookId' when calling SitesSiteIdWorkbooksWorkbookIdViewsViewIdPreviewImageGet");

            // verify the required parameter 'viewId' is set
            if (viewId == null) throw new ApiException(400, "Missing required parameter 'viewId' when calling SitesSiteIdWorkbooksWorkbookIdViewsViewIdPreviewImageGet");


            var path = "/sites/{site-id}/workbooks/{workbook-id}/views/{view-id}/previewImage";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "site-id" + "}", ApiClient.ParameterToString(siteId));
            path = path.Replace("{" + "workbook-id" + "}", ApiClient.ParameterToString(workbookId));
            path = path.Replace("{" + "view-id" + "}", ApiClient.ParameterToString(viewId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdViewsViewIdPreviewImageGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesSiteIdWorkbooksWorkbookIdViewsViewIdPreviewImageGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

        /// <summary>
        /// Returns all the views for the specified site, optionally including usage statistics. Note: After you create a resource, the server updates its search index. If you make a query immediately to see a new resource, the query results might not be up to date.  ##### Permissions: For Tableau Server users who are not server administrators or site administrators, the method returns only the views that the user owns or has Read permissions for (either explicitly or implicitly).  ##### Version: Version 2.2 and later. For more information, see REST API Versions.   ##### Request Body:  &#x60;&#x60;&#x60;   &#x60;&#x60;&#x60;    ##### Response Body:  &#x60;&#x60;&#x60; &lt;tsResponse&gt;   &lt;views&gt;      &lt;view id&#x3D;\&quot;view-id\&quot;           name&#x3D;\&quot;view-name\&quot;           contentUrl&#x3D;\&quot;content-url\&quot; &gt;        &lt;workbook id&#x3D;\&quot;workbook-id\&quot; /&gt;        &lt;owner id&#x3D;\&quot;owner-id\&quot; /&gt;        &lt;usage totalViewCount&#x3D;\&quot;total-count\&quot; /&gt;      &lt;/view&gt;       ... additional views ...    &lt;/views&gt;  &lt;/tsResponse&gt;includeUsageStatistics&#x3D;true  &#x60;&#x60;&#x60;    ##### Example:  &#x60;&#x60;&#x60; curl \&quot;http://MY-SERVER/api/2.5/sites/9a8b7c6d-5e4f-3a2b-1c0d-9e8f7a6b5c4d/views\&quot; -X GET -H \&quot;X-Tableau-Auth:1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d/views\&quot;&lt;tsResponse version-and-namespace-settings&gt;    &lt;pagination pageNumber&#x3D;\&quot;1\&quot; pageSize&#x3D;\&quot;100\&quot; totalAvailable&#x3D;\&quot;2\&quot; /&gt;    &lt;views&gt;      &lt;view id&#x3D;\&quot;1f1e1d1c-2b2a-2f2e-3d3c-3b3a4f4e4d4c\&quot; name&#x3D;\&quot;Economic Indicators\&quot;            contentUrl&#x3D;\&quot;Finance/sheets/EconomicIndicators\&quot;&gt;        &lt;workbook id&#x3D;\&quot;1a1b1c1d-2e2f-2a2b-3c3d-3e3f4a4b4c4d\&quot; /&gt;        &lt;owner id&#x3D;\&quot;9f9e9d9c-8b8a-8f8e-7d7c-7b7a6f6d6e6d\&quot; /&gt;      &lt;/view&gt;      &lt;view id&#x3D;\&quot;9a8a7b6b-5c4c-3d2d-1e0e-9a8a7b6b5b4b\&quot; name&#x3D;\&quot;Investing in the Dow\&quot;             contentUrl&#x3D;\&quot;Finance/sheets/InvestingintheDow\&quot;&gt;        &lt;workbook id&#x3D;\&quot;59a8a7b6-be3a-4d2d-1e9e-08a7b6b5b4ba\&quot; /&gt;        &lt;owner id&#x3D;\&quot;9f8e7d6c5-b4a3-f2e1-d0c9-b8a7f6e5d4c\&quot; /&gt;    &lt;/view&gt;  &lt;/tsResponse&gt;  &#x60;&#x60;&#x60; 
        /// </summary>
        /// <param name="filter">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value   updatedAt: eq, gt, gte, lte   createdAt: eq, gt, gte, lte   name: eq   tags: eq, in </param> 
        /// <param name="sort">(Optional) Filters the results.A filter expression using the following syntax:    filter&#x3D;field:operator:value  Potential fields: updatedAt  createdAt  name  tags</param> 
        /// <returns></returns>            
        public void SitesViewsGet(string filter, string sort)
        {


            var path = "/sites/views";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (filter != null) queryParams.Add("filter", ApiClient.ParameterToString(filter)); // query parameter
            if (sort != null) queryParams.Add("sort", ApiClient.ParameterToString(sort)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "TableauAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SitesViewsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SitesViewsGet: " + response.ErrorMessage, response.ErrorMessage);

            return;
        }

    }
}
