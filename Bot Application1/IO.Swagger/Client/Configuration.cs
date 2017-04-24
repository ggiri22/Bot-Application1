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
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IO.Swagger.Client
{
    /// <summary>
    /// Represents a set of configuration settings
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Initializes a new instance of the Configuration class with different settings
        /// </summary>
        /// <param name="apiClient">Api client</param>
        /// <param name="defaultHeader">Dictionary of default HTTP header</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="apiKey">Dictionary of API key</param>
        /// <param name="apiKeyPrefix">Dictionary of API key prefix</param>
        /// <param name="tempFolderPath">Temp folder path</param>
        /// <param name="dateTimeFormat">DateTime format string</param>
        /// <param name="timeout">HTTP connection timeout (in milliseconds)</param>
        /// <param name="userAgent">HTTP user agent</param>
        public Configuration(ApiClient apiClient = null,
                             Dictionary<String, String> defaultHeader = null,
                             string username = null,
                             string password = null,
                             string accessToken = null,
                             Dictionary<String, String> apiKey = null,
                             Dictionary<String, String> apiKeyPrefix = null,
                             string tempFolderPath = null,
                             string dateTimeFormat = null,
                             int timeout = 100000,
                             string userAgent = "Swagger-Codegen/1.0.0/csharp"
                            )
        {
            setApiClientUsingDefault(apiClient);

            Username = username;
            Password = password;
            AccessToken = accessToken;
            UserAgent = userAgent;

            if (defaultHeader != null)
                DefaultHeader = defaultHeader;
            if (apiKey != null)
                ApiKey = apiKey;
            if (apiKeyPrefix != null)
                ApiKeyPrefix = apiKeyPrefix;

            TempFolderPath = tempFolderPath;
            DateTimeFormat = dateTimeFormat;
            Timeout = timeout;
        }

        /// <summary>
        /// Initializes a new instance of the Configuration class.
        /// </summary>
        /// <param name="apiClient">Api client.</param>
        public Configuration(ApiClient apiClient)
        {
            setApiClientUsingDefault(apiClient);
        }

        /// <summary>
        /// Version of the package.
        /// </summary>
        /// <value>Version of the package.</value>
        public const string Version = "1.0.0";

        /// <summary>
        /// Gets or sets the default Configuration.
        /// </summary>
        /// <value>Configuration.</value>
        public static Configuration Default = new Configuration();

        /// <summary>
        /// Default creation of exceptions for a given method name and response object
        /// </summary>
        public static readonly ExceptionFactory DefaultExceptionFactory = (methodName, response) =>
        {
            int status = (int) response.StatusCode;
            if (status >= 400) return new ApiException(status, String.Format("Error calling {0}: {1}", methodName, response.Content), response.Content);
            if (status == 0) return new ApiException(status, String.Format("Error calling {0}: {1}", methodName, response.ErrorMessage), response.ErrorMessage);
            return null;
        };

        /// <summary>
        /// Gets or sets the HTTP timeout (milliseconds) of ApiClient. Default to 100000 milliseconds.
        /// </summary>
        /// <value>Timeout.</value>
        public int Timeout
        {
            get { return ApiClient.RestClient.Timeout; }

            set
            {
                if (ApiClient != null)
                    ApiClient.RestClient.Timeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the default API client for making HTTP calls.
        /// </summary>
        /// <value>The API client.</value>
        public ApiClient ApiClient;

        /// <summary>
        /// Set the ApiClient using Default or ApiClient instance.
        /// </summary>
        /// <param name="apiClient">An instance of ApiClient.</param>
        /// <returns></returns>
        public void setApiClientUsingDefault (ApiClient apiClient = null)
        {
            if (apiClient == null)
            {
                if (Default != null && Default.ApiClient == null)
                    Default.ApiClient = new ApiClient();

                ApiClient = Default != null ? Default.ApiClient : new ApiClient();
            }
            else
            {
                if (Default != null && Default.ApiClient == null)
                    Default.ApiClient = apiClient;

                ApiClient = apiClient;
            }
        }

        private Dictionary<String, String> _defaultHeaderMap = new Dictionary<String, String>();

        /// <summary>
        /// Gets or sets the default header.
        /// </summary>
        public Dictionary<String, String> DefaultHeader
        {
            get { return _defaultHeaderMap; }

            set
            {
                _defaultHeaderMap = value;
            }
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        public void AddDefaultHeader(string key, string value)
        {
            _defaultHeaderMap[key] = value;
        }

        /// <summary>
        /// Add Api Key Header.
        /// </summary>
        /// <param name="key">Api Key name.</param>
        /// <param name="value">Api Key value.</param>
        /// <returns></returns>
        public void AddApiKey(string key, string value)
        {
            ApiKey[key] = value;
        }

        /// <summary>
        /// Sets the API key prefix.
        /// </summary>
        /// <param name="key">Api Key name.</param>
        /// <param name="value">Api Key value.</param>
        public void AddApiKeyPrefix(string key, string value)
        {
            ApiKeyPrefix[key] = value;
        }

        /// <summary>
        /// Gets or sets the HTTP user agent.
        /// </summary>
        /// <value>Http user agent.</value>
        public String UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the username (HTTP basic authentication).
        /// </summary>
        /// <value>The username.</value>
        public String Username { get; set; }

        /// <summary>
        /// Gets or sets the password (HTTP basic authentication).
        /// </summary>
        /// <value>The password.</value>
        public String Password { get; set; }

        /// <summary>
        /// Gets or sets the access token for OAuth2 authentication.
        /// </summary>
        /// <value>The access token.</value>
        public String AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// </summary>
        /// <value>The API key.</value>
        public Dictionary<String, String> ApiKey = new Dictionary<String, String>();

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        /// </summary>
        /// <value>The prefix of the API key.</value>
        public Dictionary<String, String> ApiKeyPrefix = new Dictionary<String, String>();

        /// <summary>
        /// Get the API key with prefix.
        /// </summary>
        /// <param name="apiKeyIdentifier">API key identifier (authentication scheme).</param>
        /// <returns>API key with prefix.</returns>
        public string GetApiKeyWithPrefix (string apiKeyIdentifier)
        {
            var apiKeyValue = "";
            ApiKey.TryGetValue (apiKeyIdentifier, out apiKeyValue);
            var apiKeyPrefix = "";
            if (ApiKeyPrefix.TryGetValue (apiKeyIdentifier, out apiKeyPrefix))
                return apiKeyPrefix + " " + apiKeyValue;
            else
                return apiKeyValue;
        }

        private string _tempFolderPath;

        /// <summary>
        /// Gets or sets the temporary folder path to store the files downloaded from the server.
        /// </summary>
        /// <value>Folder path.</value>
        public String TempFolderPath
        {
            get
            {
                // default to Path.GetTempPath() if _tempFolderPath is not set
                if (String.IsNullOrEmpty(_tempFolderPath))
                {
                    _tempFolderPath = Path.GetTempPath();
                }
                return _tempFolderPath;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    _tempFolderPath = value;
                    return;
                }

                // create the directory if it does not exist
                if (!Directory.Exists(value))
                    Directory.CreateDirectory(value);

                // check if the path contains directory separator at the end
                if (value[value.Length - 1] == Path.DirectorySeparatorChar)
                    _tempFolderPath = value;
                else
                    _tempFolderPath = value  + Path.DirectorySeparatorChar;
            }
        }

        private const string ISO8601_DATETIME_FORMAT = "o";

        private string _dateTimeFormat = ISO8601_DATETIME_FORMAT;

        /// <summary>
        /// Gets or sets the the date time format used when serializing in the ApiClient
        /// By default, it's set to ISO 8601 - "o", for others see:
        /// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        /// and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        /// No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public String DateTimeFormat
        {
            get
            {
                return _dateTimeFormat;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }

        /// <summary>
        /// Returns a string with essential information for debugging.
        /// </summary>
        public static String ToDebugReport()
        {
            String report = "C# SDK (IO.Swagger) Debug Report:\n";
            report += "    OS: " + Environment.OSVersion + "\n";
            report += "    .NET Framework Version: " + Assembly
                     .GetExecutingAssembly()
                     .GetReferencedAssemblies()
                     .Where(x => x.Name == "System.Core").First().Version.ToString()  + "\n";
            report += "    Version of the API: 0.1\n";
            report += "    SDK Package Version: 1.0.0\n";

            return report;
        }
    }
}
