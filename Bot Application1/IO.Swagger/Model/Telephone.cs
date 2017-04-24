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
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Telephone
    /// </summary>
    [DataContract]
    public partial class Telephone :  IEquatable<Telephone>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum Mobile for "Mobile"
            /// </summary>
            [EnumMember(Value = "Mobile")]
            Mobile,
            
            /// <summary>
            /// Enum Landline for "Landline"
            /// </summary>
            [EnumMember(Value = "Landline")]
            Landline,
            
            /// <summary>
            /// Enum Fax for "Fax"
            /// </summary>
            [EnumMember(Value = "Fax")]
            Fax
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Telephone" /> class.
        /// </summary>
        /// <param name="Country">Two letter country code in accordance with &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2\&quot;&gt;ISO 3166-1 Alpha-2&lt;/a&gt;. E.g. &#39;SE&#39; .</param>
        /// <param name="Number">Phone number on &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/E.164\&quot;&gt;E.164&lt;/a&gt; format. E.g. +46855805900 .</param>
        /// <param name="Restricted">Whether this number is blocked for telemarketing..</param>
        /// <param name="Type">Type.</param>
        public Telephone(string Country = default(string), string Number = default(string), bool? Restricted = default(bool?), TypeEnum? Type = default(TypeEnum?))
        {
            this.Country = Country;
            this.Number = Number;
            this.Restricted = Restricted;
            this.Type = Type;
        }
        
        /// <summary>
        /// Two letter country code in accordance with &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2\&quot;&gt;ISO 3166-1 Alpha-2&lt;/a&gt;. E.g. &#39;SE&#39; 
        /// </summary>
        /// <value>Two letter country code in accordance with &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2\&quot;&gt;ISO 3166-1 Alpha-2&lt;/a&gt;. E.g. &#39;SE&#39; </value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }
        /// <summary>
        /// Phone number on &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/E.164\&quot;&gt;E.164&lt;/a&gt; format. E.g. +46855805900 
        /// </summary>
        /// <value>Phone number on &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/E.164\&quot;&gt;E.164&lt;/a&gt; format. E.g. +46855805900 </value>
        [DataMember(Name="number", EmitDefaultValue=false)]
        public string Number { get; set; }
        /// <summary>
        /// Whether this number is blocked for telemarketing.
        /// </summary>
        /// <value>Whether this number is blocked for telemarketing.</value>
        [DataMember(Name="restricted", EmitDefaultValue=false)]
        public bool? Restricted { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Telephone {\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  Restricted: ").Append(Restricted).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as Telephone);
        }

        /// <summary>
        /// Returns true if Telephone instances are equal
        /// </summary>
        /// <param name="other">Instance of Telephone to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Telephone other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Country == other.Country ||
                    this.Country != null &&
                    this.Country.Equals(other.Country)
                ) && 
                (
                    this.Number == other.Number ||
                    this.Number != null &&
                    this.Number.Equals(other.Number)
                ) && 
                (
                    this.Restricted == other.Restricted ||
                    this.Restricted != null &&
                    this.Restricted.Equals(other.Restricted)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Country != null)
                    hash = hash * 59 + this.Country.GetHashCode();
                if (this.Number != null)
                    hash = hash * 59 + this.Number.GetHashCode();
                if (this.Restricted != null)
                    hash = hash * 59 + this.Restricted.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            // Country (string) maxLength
            if(this.Country != null && this.Country.Length > 2)
            {
                yield return new ValidationResult("Invalid value for Country, length must be less than 2.", new [] { "Country" });
            }

            // Country (string) minLength
            if(this.Country != null && this.Country.Length < 2)
            {
                yield return new ValidationResult("Invalid value for Country, length must be greater than 2.", new [] { "Country" });
            }

            // Number (string) pattern
            Regex regexNumber = new Regex(@"^\\+[1-9]\\d{1,14}$", RegexOptions.CultureInvariant);
            if (false == regexNumber.Match(this.Number).Success)
            {
                yield return new ValidationResult("Invalid value for Number, must match a pattern of /^\\+[1-9]\\d{1,14}$/.", new [] { "Number" });
            }

            yield break;
        }
    }

}
