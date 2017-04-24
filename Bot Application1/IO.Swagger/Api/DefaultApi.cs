/* 
 * Bisnode Consumer Intelligence
 *
 * A JSON REST API for searching Bisnode's consumer databases for the nordic countries (Denmark, Finland, Norway and Sweden). The schema is recomended to view with swagger ui - e.g. by pasting it into [Swagger Editor](http://editor.swagger.io/) # API usage     ## Search    The purpose of search is to deliver a list of Consumer candidates, where one of them a the target customer.    The data provided in the result set aims to be sufficient for a human being to identify the customer.     At this point, we recommend users to request data set parameter \"basic\" and \"extended\".    This is subject of change in the near future.     ## Get by ID    The purpose of get by ID is to deliver all data required by the Client to perform smart marketing campaigns.    The data returned here is typically a larger set than what is returned from a search request.     At this point, we recommend users to request data set parameter \"basic\", \"extended\".    This is subject of change in the near future.     ## Bisnode Consumer ID    A Bisnode Consumer ID is the official way to identify a Consumer in Bisnode system.    Since we are in a very early phase of Bisnode Customer Intelligence evolution    * Clients shall not assume that Bisnode Consumer ID is unique - in the search result many entries will contain the same ID, i.e. \"unknown\"    * The Bisnode Consumer ID can change over time, using the same mechanism for changes as other Consumer meta data.      In the early phases, the Bisnode Consumer ID will be used in conjunction with the Memento to identify the Consumer data.     ## Client Expectations    Clients are expected to store the Bisnode Consumer ID, the Memento and a timestamp - associated to the corresponding customer. # API access   Bisnode provides API access for client developers by means of a `CLIENTID` and a `SECRET`.   The client developer uses the `CLIENTID` and `SECRET` to get an access token from Bisnode's authentication endpoint   at `https://login.bisnode.com/as/token.oauth2`. The access token is then passed along in the Authorization   header to all API requests.   ## Step 1. Get the access token   To get an access token you need to make a POST request to `https://login.bisnode.com/as/token.oauth2`   using the following HTTP header: `Content-Type: application/x-www-form-urlencoded`   and the following request body: `grant_type=client_credentials&scope=consumer`.   The request must be authenticated using HTTP Basic authentication and your `CLIENTID` and `SECRET`.    *Example in cURL*        curl -H \"Content-Type: application/x-www-form-urlencoded\"\\            -X POST -d 'grant_type=client_credentials&scope=consumer'\\            - -user $CLIENTID:$SECRET\\            https://login.bisnode.com/as/token.oauth2   *Example response*        {         \"access_token\": \"eyJhb....seAtPCCQ\",         \"token_type\": \"Bearer\",         \"expires_in\": 7199       }   ## Step 2. Use the access token   Supply your access token with all requests to the API using the HTTP Authorization header:   `Authorization: Bearer <your access token here>`. You should reuse the access token   for multiple calls to the API. See the next section on recommended usage.    *Example in cURL - search for phone number +46731585248*        curl -H \"Authorization: Bearer eyJhb...seAtPCCQ\"\\            https://api.bisnode.com/people/consumer/v1/?phoneNumber=%2B46731585248   ### Reusing the access token   After you have fetched an access token you should save it and use it for subsequent calls   to the API. There is no limit on the number of calls this token can be used for (however,   rate limiting may apply) but it will expire after a certain time.   We recommend that you disregard the value of the `expires_in` field and that you simply   keep using the same access token until it expires, at which point the API will return an HTTP status of 401 Unauthorized.   When that happens you should retrieve a new access token from the authentication endpoint and retry the operation.   Care should be taken to not introduce an endless loop of failed API requests and getting new access tokens.   The following pseudo code illustrates how to use the authentication endpoint and the API.         function make_authorized_api_request():           if not has_cached_access_token():               retrieve_new_access_token()           try:               make_api_call()           except api_error_status_401_unauthorized:               retrieve_new_access_token()               make_api_call()   # API Versioning    ## What constitutes an API version   API versions are raised only on breaking (i.e. backwards incompatible) changes in the API. Fields MAY be added but will never be removed during an API version lifecycle. Client developers should thus prepare their client app's for the possibility of added fields (in which case the schemas will also be updated to reflect this).    ## Providing API version   API version is provided in the base of the requested URL in the form of \"v1\", \"v2\" etc. Only major version numbers are used. 
 *
 * OpenAPI spec version: 0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Retrieve a single consumer entity by ID (bisnodeConsumerId). 
        /// </summary>
        /// <remarks>
        /// This endpoint returns single consumer data entry as identified by its *bisnodeConsumerId* or *memento*. If there is no bisnodeConsumerId then the placeholder id &#39;UNKNOWN&#39; should be used. Should the bisnodeConsumerId and memento point to different entities due to updated consumer data then the entity pointed to by bisnodeConsumerId will be returned. Bisnode recommends that you replace any stored instances of an entity with the most current one and update relations and/or indexes with any new bisnodeConsumerId and mementos that belong to the updated document. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bisnodeConsumerId">The bisnodeConsumerId of the consumer entity to retrieve. If no id has previously been associated with the requested entity then the placeholder id &#39;UNKNOWN&#39; will be used in its place. </param>
        /// <param name="memento">A key for uniquely identifying this customer record in Bisnode&#39;s databases. **Should not be parsed as format is subject to change.** </param>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the returned entity with. Multiple data sets can be specified. </param>
        /// <returns>ConsumerResponse</returns>
        ConsumerResponse GetConsumer (string bisnodeConsumerId, string memento, List<string> dataSet);

        /// <summary>
        /// Retrieve a single consumer entity by ID (bisnodeConsumerId). 
        /// </summary>
        /// <remarks>
        /// This endpoint returns single consumer data entry as identified by its *bisnodeConsumerId* or *memento*. If there is no bisnodeConsumerId then the placeholder id &#39;UNKNOWN&#39; should be used. Should the bisnodeConsumerId and memento point to different entities due to updated consumer data then the entity pointed to by bisnodeConsumerId will be returned. Bisnode recommends that you replace any stored instances of an entity with the most current one and update relations and/or indexes with any new bisnodeConsumerId and mementos that belong to the updated document. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bisnodeConsumerId">The bisnodeConsumerId of the consumer entity to retrieve. If no id has previously been associated with the requested entity then the placeholder id &#39;UNKNOWN&#39; will be used in its place. </param>
        /// <param name="memento">A key for uniquely identifying this customer record in Bisnode&#39;s databases. **Should not be parsed as format is subject to change.** </param>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the returned entity with. Multiple data sets can be specified. </param>
        /// <returns>ApiResponse of ConsumerResponse</returns>
        ApiResponse<ConsumerResponse> GetConsumerWithHttpInfo (string bisnodeConsumerId, string memento, List<string> dataSet);
        /// <summary>
        /// Search for consumers. 
        /// </summary>
        /// <remarks>
        /// Returns a list of search hits. The data fields returned are determined by what is specified in the dataSet parameter. In order to get any usable result either phoneNumber or country must be specified. At the moment the search hits cannot be ordered by relevance but this feature will be part of a future release. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the search results with. Multiple data sets can be specified. </param>
        /// <param name="country">The country in which to search for consumers. Use [ISO 3166-1 Alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country codes. E.g. &#39;DK&#39;, &#39;FI&#39;, &#39;NO&#39; or &#39;SE&#39; </param>
        /// <param name="familyName">The family name (last name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="givenName">The given name (first name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="dateOfBirth">The Date of birth to search for. Must be in format yyyy-mm-dd at the moment. (optional)</param>
        /// <param name="phoneNumber">The phone number to search for. At the moment it must be an exact match in the [E.164](https://en.wikipedia.org/wiki/E.164) format. At the moment this must include the country prefix. E.g. +46855805900  (optional)</param>
        /// <returns>ConsumerSearchResultListResponse</returns>
        ConsumerSearchResultListResponse SearchConsumers (List<string> dataSet, string country, string familyName = null, string givenName = null, string dateOfBirth = null, string phoneNumber = null);

        /// <summary>
        /// Search for consumers. 
        /// </summary>
        /// <remarks>
        /// Returns a list of search hits. The data fields returned are determined by what is specified in the dataSet parameter. In order to get any usable result either phoneNumber or country must be specified. At the moment the search hits cannot be ordered by relevance but this feature will be part of a future release. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the search results with. Multiple data sets can be specified. </param>
        /// <param name="country">The country in which to search for consumers. Use [ISO 3166-1 Alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country codes. E.g. &#39;DK&#39;, &#39;FI&#39;, &#39;NO&#39; or &#39;SE&#39; </param>
        /// <param name="familyName">The family name (last name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="givenName">The given name (first name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="dateOfBirth">The Date of birth to search for. Must be in format yyyy-mm-dd at the moment. (optional)</param>
        /// <param name="phoneNumber">The phone number to search for. At the moment it must be an exact match in the [E.164](https://en.wikipedia.org/wiki/E.164) format. At the moment this must include the country prefix. E.g. +46855805900  (optional)</param>
        /// <returns>ApiResponse of ConsumerSearchResultListResponse</returns>
        ApiResponse<ConsumerSearchResultListResponse> SearchConsumersWithHttpInfo (List<string> dataSet, string country, string familyName = null, string givenName = null, string dateOfBirth = null, string phoneNumber = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Retrieve a single consumer entity by ID (bisnodeConsumerId). 
        /// </summary>
        /// <remarks>
        /// This endpoint returns single consumer data entry as identified by its *bisnodeConsumerId* or *memento*. If there is no bisnodeConsumerId then the placeholder id &#39;UNKNOWN&#39; should be used. Should the bisnodeConsumerId and memento point to different entities due to updated consumer data then the entity pointed to by bisnodeConsumerId will be returned. Bisnode recommends that you replace any stored instances of an entity with the most current one and update relations and/or indexes with any new bisnodeConsumerId and mementos that belong to the updated document. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bisnodeConsumerId">The bisnodeConsumerId of the consumer entity to retrieve. If no id has previously been associated with the requested entity then the placeholder id &#39;UNKNOWN&#39; will be used in its place. </param>
        /// <param name="memento">A key for uniquely identifying this customer record in Bisnode&#39;s databases. **Should not be parsed as format is subject to change.** </param>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the returned entity with. Multiple data sets can be specified. </param>
        /// <returns>Task of ConsumerResponse</returns>
        System.Threading.Tasks.Task<ConsumerResponse> GetConsumerAsync (string bisnodeConsumerId, string memento, List<string> dataSet);

        /// <summary>
        /// Retrieve a single consumer entity by ID (bisnodeConsumerId). 
        /// </summary>
        /// <remarks>
        /// This endpoint returns single consumer data entry as identified by its *bisnodeConsumerId* or *memento*. If there is no bisnodeConsumerId then the placeholder id &#39;UNKNOWN&#39; should be used. Should the bisnodeConsumerId and memento point to different entities due to updated consumer data then the entity pointed to by bisnodeConsumerId will be returned. Bisnode recommends that you replace any stored instances of an entity with the most current one and update relations and/or indexes with any new bisnodeConsumerId and mementos that belong to the updated document. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bisnodeConsumerId">The bisnodeConsumerId of the consumer entity to retrieve. If no id has previously been associated with the requested entity then the placeholder id &#39;UNKNOWN&#39; will be used in its place. </param>
        /// <param name="memento">A key for uniquely identifying this customer record in Bisnode&#39;s databases. **Should not be parsed as format is subject to change.** </param>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the returned entity with. Multiple data sets can be specified. </param>
        /// <returns>Task of ApiResponse (ConsumerResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ConsumerResponse>> GetConsumerAsyncWithHttpInfo (string bisnodeConsumerId, string memento, List<string> dataSet);
        /// <summary>
        /// Search for consumers. 
        /// </summary>
        /// <remarks>
        /// Returns a list of search hits. The data fields returned are determined by what is specified in the dataSet parameter. In order to get any usable result either phoneNumber or country must be specified. At the moment the search hits cannot be ordered by relevance but this feature will be part of a future release. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the search results with. Multiple data sets can be specified. </param>
        /// <param name="country">The country in which to search for consumers. Use [ISO 3166-1 Alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country codes. E.g. &#39;DK&#39;, &#39;FI&#39;, &#39;NO&#39; or &#39;SE&#39; </param>
        /// <param name="familyName">The family name (last name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="givenName">The given name (first name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="dateOfBirth">The Date of birth to search for. Must be in format yyyy-mm-dd at the moment. (optional)</param>
        /// <param name="phoneNumber">The phone number to search for. At the moment it must be an exact match in the [E.164](https://en.wikipedia.org/wiki/E.164) format. At the moment this must include the country prefix. E.g. +46855805900  (optional)</param>
        /// <returns>Task of ConsumerSearchResultListResponse</returns>
        System.Threading.Tasks.Task<ConsumerSearchResultListResponse> SearchConsumersAsync (List<string> dataSet, string country, string familyName = null, string givenName = null, string dateOfBirth = null, string phoneNumber = null);

        /// <summary>
        /// Search for consumers. 
        /// </summary>
        /// <remarks>
        /// Returns a list of search hits. The data fields returned are determined by what is specified in the dataSet parameter. In order to get any usable result either phoneNumber or country must be specified. At the moment the search hits cannot be ordered by relevance but this feature will be part of a future release. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the search results with. Multiple data sets can be specified. </param>
        /// <param name="country">The country in which to search for consumers. Use [ISO 3166-1 Alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country codes. E.g. &#39;DK&#39;, &#39;FI&#39;, &#39;NO&#39; or &#39;SE&#39; </param>
        /// <param name="familyName">The family name (last name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="givenName">The given name (first name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="dateOfBirth">The Date of birth to search for. Must be in format yyyy-mm-dd at the moment. (optional)</param>
        /// <param name="phoneNumber">The phone number to search for. At the moment it must be an exact match in the [E.164](https://en.wikipedia.org/wiki/E.164) format. At the moment this must include the country prefix. E.g. +46855805900  (optional)</param>
        /// <returns>Task of ApiResponse (ConsumerSearchResultListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ConsumerSearchResultListResponse>> SearchConsumersAsyncWithHttpInfo (List<string> dataSet, string country, string familyName = null, string givenName = null, string dateOfBirth = null, string phoneNumber = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class DefaultApi : IDefaultApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DefaultApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Retrieve a single consumer entity by ID (bisnodeConsumerId).  This endpoint returns single consumer data entry as identified by its *bisnodeConsumerId* or *memento*. If there is no bisnodeConsumerId then the placeholder id &#39;UNKNOWN&#39; should be used. Should the bisnodeConsumerId and memento point to different entities due to updated consumer data then the entity pointed to by bisnodeConsumerId will be returned. Bisnode recommends that you replace any stored instances of an entity with the most current one and update relations and/or indexes with any new bisnodeConsumerId and mementos that belong to the updated document. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bisnodeConsumerId">The bisnodeConsumerId of the consumer entity to retrieve. If no id has previously been associated with the requested entity then the placeholder id &#39;UNKNOWN&#39; will be used in its place. </param>
        /// <param name="memento">A key for uniquely identifying this customer record in Bisnode&#39;s databases. **Should not be parsed as format is subject to change.** </param>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the returned entity with. Multiple data sets can be specified. </param>
        /// <returns>ConsumerResponse</returns>
        public ConsumerResponse GetConsumer (string bisnodeConsumerId, string memento, List<string> dataSet)
        {
             ApiResponse<ConsumerResponse> localVarResponse = GetConsumerWithHttpInfo(bisnodeConsumerId, memento, dataSet);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve a single consumer entity by ID (bisnodeConsumerId).  This endpoint returns single consumer data entry as identified by its *bisnodeConsumerId* or *memento*. If there is no bisnodeConsumerId then the placeholder id &#39;UNKNOWN&#39; should be used. Should the bisnodeConsumerId and memento point to different entities due to updated consumer data then the entity pointed to by bisnodeConsumerId will be returned. Bisnode recommends that you replace any stored instances of an entity with the most current one and update relations and/or indexes with any new bisnodeConsumerId and mementos that belong to the updated document. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bisnodeConsumerId">The bisnodeConsumerId of the consumer entity to retrieve. If no id has previously been associated with the requested entity then the placeholder id &#39;UNKNOWN&#39; will be used in its place. </param>
        /// <param name="memento">A key for uniquely identifying this customer record in Bisnode&#39;s databases. **Should not be parsed as format is subject to change.** </param>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the returned entity with. Multiple data sets can be specified. </param>
        /// <returns>ApiResponse of ConsumerResponse</returns>
        public ApiResponse< ConsumerResponse > GetConsumerWithHttpInfo (string bisnodeConsumerId, string memento, List<string> dataSet)
        {
            // verify the required parameter 'bisnodeConsumerId' is set
            if (bisnodeConsumerId == null)
                throw new ApiException(400, "Missing required parameter 'bisnodeConsumerId' when calling DefaultApi->GetConsumer");
            // verify the required parameter 'memento' is set
            if (memento == null)
                throw new ApiException(400, "Missing required parameter 'memento' when calling DefaultApi->GetConsumer");
            // verify the required parameter 'dataSet' is set
            if (dataSet == null)
                throw new ApiException(400, "Missing required parameter 'dataSet' when calling DefaultApi->GetConsumer");

            var localVarPath = "/{bisnodeConsumerId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (bisnodeConsumerId != null) localVarPathParams.Add("bisnodeConsumerId", Configuration.ApiClient.ParameterToString(bisnodeConsumerId)); // path parameter
            if (memento != null) localVarQueryParams.Add("memento", Configuration.ApiClient.ParameterToString(memento)); // query parameter
            if (dataSet != null) localVarQueryParams.Add("dataSet", Configuration.ApiClient.ParameterToString(dataSet)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetConsumer", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ConsumerResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ConsumerResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ConsumerResponse)));
            
        }

        /// <summary>
        /// Retrieve a single consumer entity by ID (bisnodeConsumerId).  This endpoint returns single consumer data entry as identified by its *bisnodeConsumerId* or *memento*. If there is no bisnodeConsumerId then the placeholder id &#39;UNKNOWN&#39; should be used. Should the bisnodeConsumerId and memento point to different entities due to updated consumer data then the entity pointed to by bisnodeConsumerId will be returned. Bisnode recommends that you replace any stored instances of an entity with the most current one and update relations and/or indexes with any new bisnodeConsumerId and mementos that belong to the updated document. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bisnodeConsumerId">The bisnodeConsumerId of the consumer entity to retrieve. If no id has previously been associated with the requested entity then the placeholder id &#39;UNKNOWN&#39; will be used in its place. </param>
        /// <param name="memento">A key for uniquely identifying this customer record in Bisnode&#39;s databases. **Should not be parsed as format is subject to change.** </param>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the returned entity with. Multiple data sets can be specified. </param>
        /// <returns>Task of ConsumerResponse</returns>
        public async System.Threading.Tasks.Task<ConsumerResponse> GetConsumerAsync (string bisnodeConsumerId, string memento, List<string> dataSet)
        {
             ApiResponse<ConsumerResponse> localVarResponse = await GetConsumerAsyncWithHttpInfo(bisnodeConsumerId, memento, dataSet);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Retrieve a single consumer entity by ID (bisnodeConsumerId).  This endpoint returns single consumer data entry as identified by its *bisnodeConsumerId* or *memento*. If there is no bisnodeConsumerId then the placeholder id &#39;UNKNOWN&#39; should be used. Should the bisnodeConsumerId and memento point to different entities due to updated consumer data then the entity pointed to by bisnodeConsumerId will be returned. Bisnode recommends that you replace any stored instances of an entity with the most current one and update relations and/or indexes with any new bisnodeConsumerId and mementos that belong to the updated document. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="bisnodeConsumerId">The bisnodeConsumerId of the consumer entity to retrieve. If no id has previously been associated with the requested entity then the placeholder id &#39;UNKNOWN&#39; will be used in its place. </param>
        /// <param name="memento">A key for uniquely identifying this customer record in Bisnode&#39;s databases. **Should not be parsed as format is subject to change.** </param>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the returned entity with. Multiple data sets can be specified. </param>
        /// <returns>Task of ApiResponse (ConsumerResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ConsumerResponse>> GetConsumerAsyncWithHttpInfo (string bisnodeConsumerId, string memento, List<string> dataSet)
        {
            // verify the required parameter 'bisnodeConsumerId' is set
            if (bisnodeConsumerId == null)
                throw new ApiException(400, "Missing required parameter 'bisnodeConsumerId' when calling DefaultApi->GetConsumer");
            // verify the required parameter 'memento' is set
            if (memento == null)
                throw new ApiException(400, "Missing required parameter 'memento' when calling DefaultApi->GetConsumer");
            // verify the required parameter 'dataSet' is set
            if (dataSet == null)
                throw new ApiException(400, "Missing required parameter 'dataSet' when calling DefaultApi->GetConsumer");

            var localVarPath = "/{bisnodeConsumerId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (bisnodeConsumerId != null) localVarPathParams.Add("bisnodeConsumerId", Configuration.ApiClient.ParameterToString(bisnodeConsumerId)); // path parameter
            if (memento != null) localVarQueryParams.Add("memento", Configuration.ApiClient.ParameterToString(memento)); // query parameter
            if (dataSet != null) localVarQueryParams.Add("dataSet", Configuration.ApiClient.ParameterToString(dataSet)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetConsumer", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ConsumerResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ConsumerResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ConsumerResponse)));
            
        }

        /// <summary>
        /// Search for consumers.  Returns a list of search hits. The data fields returned are determined by what is specified in the dataSet parameter. In order to get any usable result either phoneNumber or country must be specified. At the moment the search hits cannot be ordered by relevance but this feature will be part of a future release. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the search results with. Multiple data sets can be specified. </param>
        /// <param name="country">The country in which to search for consumers. Use [ISO 3166-1 Alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country codes. E.g. &#39;DK&#39;, &#39;FI&#39;, &#39;NO&#39; or &#39;SE&#39; </param>
        /// <param name="familyName">The family name (last name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="givenName">The given name (first name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="dateOfBirth">The Date of birth to search for. Must be in format yyyy-mm-dd at the moment. (optional)</param>
        /// <param name="phoneNumber">The phone number to search for. At the moment it must be an exact match in the [E.164](https://en.wikipedia.org/wiki/E.164) format. At the moment this must include the country prefix. E.g. +46855805900  (optional)</param>
        /// <returns>ConsumerSearchResultListResponse</returns>
        public ConsumerSearchResultListResponse SearchConsumers (List<string> dataSet, string country, string familyName = null, string givenName = null, string dateOfBirth = null, string phoneNumber = null)
        {
             ApiResponse<ConsumerSearchResultListResponse> localVarResponse = SearchConsumersWithHttpInfo(dataSet, country, familyName, givenName, dateOfBirth, phoneNumber);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Search for consumers.  Returns a list of search hits. The data fields returned are determined by what is specified in the dataSet parameter. In order to get any usable result either phoneNumber or country must be specified. At the moment the search hits cannot be ordered by relevance but this feature will be part of a future release. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the search results with. Multiple data sets can be specified. </param>
        /// <param name="country">The country in which to search for consumers. Use [ISO 3166-1 Alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country codes. E.g. &#39;DK&#39;, &#39;FI&#39;, &#39;NO&#39; or &#39;SE&#39; </param>
        /// <param name="familyName">The family name (last name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="givenName">The given name (first name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="dateOfBirth">The Date of birth to search for. Must be in format yyyy-mm-dd at the moment. (optional)</param>
        /// <param name="phoneNumber">The phone number to search for. At the moment it must be an exact match in the [E.164](https://en.wikipedia.org/wiki/E.164) format. At the moment this must include the country prefix. E.g. +46855805900  (optional)</param>
        /// <returns>ApiResponse of ConsumerSearchResultListResponse</returns>
        public ApiResponse< ConsumerSearchResultListResponse > SearchConsumersWithHttpInfo (List<string> dataSet, string country, string familyName = null, string givenName = null, string dateOfBirth = null, string phoneNumber = null)
        {
            // verify the required parameter 'dataSet' is set
            if (dataSet == null)
                throw new ApiException(400, "Missing required parameter 'dataSet' when calling DefaultApi->SearchConsumers");
            // verify the required parameter 'country' is set
            if (country == null)
                throw new ApiException(400, "Missing required parameter 'country' when calling DefaultApi->SearchConsumers");

            var localVarPath = "/";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (dataSet != null) localVarQueryParams.Add("dataSet", Configuration.ApiClient.ParameterToString(dataSet)); // query parameter
            if (country != null) localVarQueryParams.Add("country", Configuration.ApiClient.ParameterToString(country)); // query parameter
            if (familyName != null) localVarQueryParams.Add("familyName", Configuration.ApiClient.ParameterToString(familyName)); // query parameter
            if (givenName != null) localVarQueryParams.Add("givenName", Configuration.ApiClient.ParameterToString(givenName)); // query parameter
            if (dateOfBirth != null) localVarQueryParams.Add("dateOfBirth", Configuration.ApiClient.ParameterToString(dateOfBirth)); // query parameter
            if (phoneNumber != null) localVarQueryParams.Add("phoneNumber", Configuration.ApiClient.ParameterToString(phoneNumber)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SearchConsumers", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ConsumerSearchResultListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ConsumerSearchResultListResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ConsumerSearchResultListResponse)));
            
        }

        /// <summary>
        /// Search for consumers.  Returns a list of search hits. The data fields returned are determined by what is specified in the dataSet parameter. In order to get any usable result either phoneNumber or country must be specified. At the moment the search hits cannot be ordered by relevance but this feature will be part of a future release. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the search results with. Multiple data sets can be specified. </param>
        /// <param name="country">The country in which to search for consumers. Use [ISO 3166-1 Alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country codes. E.g. &#39;DK&#39;, &#39;FI&#39;, &#39;NO&#39; or &#39;SE&#39; </param>
        /// <param name="familyName">The family name (last name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="givenName">The given name (first name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="dateOfBirth">The Date of birth to search for. Must be in format yyyy-mm-dd at the moment. (optional)</param>
        /// <param name="phoneNumber">The phone number to search for. At the moment it must be an exact match in the [E.164](https://en.wikipedia.org/wiki/E.164) format. At the moment this must include the country prefix. E.g. +46855805900  (optional)</param>
        /// <returns>Task of ConsumerSearchResultListResponse</returns>
        public async System.Threading.Tasks.Task<ConsumerSearchResultListResponse> SearchConsumersAsync (List<string> dataSet, string country, string familyName = null, string givenName = null, string dateOfBirth = null, string phoneNumber = null)
        {
             ApiResponse<ConsumerSearchResultListResponse> localVarResponse = await SearchConsumersAsyncWithHttpInfo(dataSet, country, familyName, givenName, dateOfBirth, phoneNumber);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Search for consumers.  Returns a list of search hits. The data fields returned are determined by what is specified in the dataSet parameter. In order to get any usable result either phoneNumber or country must be specified. At the moment the search hits cannot be ordered by relevance but this feature will be part of a future release. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dataSet">The data set(s) to retrieve and decorate the search results with. Multiple data sets can be specified. </param>
        /// <param name="country">The country in which to search for consumers. Use [ISO 3166-1 Alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country codes. E.g. &#39;DK&#39;, &#39;FI&#39;, &#39;NO&#39; or &#39;SE&#39; </param>
        /// <param name="familyName">The family name (last name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="givenName">The given name (first name) to search for. Must be an exact match at the moment. (optional)</param>
        /// <param name="dateOfBirth">The Date of birth to search for. Must be in format yyyy-mm-dd at the moment. (optional)</param>
        /// <param name="phoneNumber">The phone number to search for. At the moment it must be an exact match in the [E.164](https://en.wikipedia.org/wiki/E.164) format. At the moment this must include the country prefix. E.g. +46855805900  (optional)</param>
        /// <returns>Task of ApiResponse (ConsumerSearchResultListResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ConsumerSearchResultListResponse>> SearchConsumersAsyncWithHttpInfo (List<string> dataSet, string country, string familyName = null, string givenName = null, string dateOfBirth = null, string phoneNumber = null)
        {
            // verify the required parameter 'dataSet' is set
            if (dataSet == null)
                throw new ApiException(400, "Missing required parameter 'dataSet' when calling DefaultApi->SearchConsumers");
            // verify the required parameter 'country' is set
            if (country == null)
                throw new ApiException(400, "Missing required parameter 'country' when calling DefaultApi->SearchConsumers");

            var localVarPath = "/";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (dataSet != null) localVarQueryParams.Add("dataSet", Configuration.ApiClient.ParameterToString(dataSet)); // query parameter
            if (country != null) localVarQueryParams.Add("country", Configuration.ApiClient.ParameterToString(country)); // query parameter
            if (familyName != null) localVarQueryParams.Add("familyName", Configuration.ApiClient.ParameterToString(familyName)); // query parameter
            if (givenName != null) localVarQueryParams.Add("givenName", Configuration.ApiClient.ParameterToString(givenName)); // query parameter
            if (dateOfBirth != null) localVarQueryParams.Add("dateOfBirth", Configuration.ApiClient.ParameterToString(dateOfBirth)); // query parameter
            if (phoneNumber != null) localVarQueryParams.Add("phoneNumber", Configuration.ApiClient.ParameterToString(phoneNumber)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SearchConsumers", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ConsumerSearchResultListResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ConsumerSearchResultListResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ConsumerSearchResultListResponse)));
            
        }

    }
}
