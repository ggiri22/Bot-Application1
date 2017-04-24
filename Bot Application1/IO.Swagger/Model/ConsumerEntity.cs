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
    /// Bisnode&#39;s representation of a consumer.
    /// </summary>
    [DataContract]
    public partial class ConsumerEntity :  IEquatable<ConsumerEntity>, IValidatableObject
    {
        /// <summary>
        /// The gender this person identifies as.
        /// </summary>
        /// <value>The gender this person identifies as.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum GenderEnum
        {
            
            /// <summary>
            /// Enum Male for "Male"
            /// </summary>
            [EnumMember(Value = "Male")]
            Male,
            
            /// <summary>
            /// Enum Female for "Female"
            /// </summary>
            [EnumMember(Value = "Female")]
            Female,
            
            /// <summary>
            /// Enum Unknown for "Unknown"
            /// </summary>
            [EnumMember(Value = "Unknown")]
            Unknown
        }

        /// <summary>
        /// The gender this person identifies as.
        /// </summary>
        /// <value>The gender this person identifies as.</value>
        [DataMember(Name="gender", EmitDefaultValue=false)]
        public GenderEnum? Gender { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumerEntity" /> class.
        /// </summary>
        /// <param name="Deceased">The consumer is no longer in the realm of the living. May he/she rest in peace..</param>
        /// <param name="Gender">The gender this person identifies as..</param>
        /// <param name="GivenName">The customer&#39;s given name (first name) as is proper to use when informally addressing the customer..</param>
        /// <param name="Memento">A key for uniquely identifying this customer record in Bisnode&#39;s databases. Used for retrieving more data on the customer or tracking changes to the customer&#39;s information in the appriopriate APIs when these are available. &lt;strong&gt;Should not be parsed as format is subject to change.&lt;/strong&gt;.</param>
        /// <param name="FullName">The formatted full name of the consumer. A combination of the fields givenName and familyName in a format that is proper for formally addressing the customer..</param>
        /// <param name="FirstNames">All first names of this consumer..</param>
        /// <param name="Language">Indicates the language this consumer prefers, in accordance with &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc5646\&quot;&gt;RFC5646&lt;/a&gt;. E.g. sv, en-GB .</param>
        /// <param name="PhoneList">List of phone numbers on which this consumer could be reached..</param>
        /// <param name="DateOfBirth">Date of birth in accordance with &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/ISO_8601\&quot;&gt;ISO 8601&lt;/a&gt; date, i.e. YYYY-MM-DD.</param>
        /// <param name="BisnodeConsumerId">Bisnode&#39;s ID on this consumer. This can be used for retrieving more data on the customer or tracking changes to the customer&#39;s information in the appriopriate APIs when these are available. Currently we do not have this for all countries. &lt;strong&gt;Should not be parsed as format is subject to change.&lt;/strong&gt; Until we have this for all countries please use &lt;strong&gt;memento&lt;/strong&gt; instead..</param>
        /// <param name="_Protected">The consumer&#39;s information is protected and will not be returned. Any previously stored information should be removed in compliance with local laws..</param>
        /// <param name="AddressList">List of addresses on which this consumer can be reached..</param>
        /// <param name="FamilyName">The customer&#39;s family name (last name)..</param>
        /// <param name="YearOfBirth">A four digit representation.</param>
        public ConsumerEntity(bool? Deceased = default(bool?), GenderEnum? Gender = default(GenderEnum?), string GivenName = default(string), string Memento = default(string), string FullName = default(string), List<string> FirstNames = default(List<string>), string Language = default(string), List<Telephone> PhoneList = default(List<Telephone>), string DateOfBirth = default(string), string BisnodeConsumerId = default(string), bool? _Protected = default(bool?), List<Address> AddressList = default(List<Address>), string FamilyName = default(string), decimal? YearOfBirth = default(decimal?))
        {
            this.Deceased = Deceased;
            this.Gender = Gender;
            this.GivenName = GivenName;
            this.Memento = Memento;
            this.FullName = FullName;
            this.FirstNames = FirstNames;
            this.Language = Language;
            this.PhoneList = PhoneList;
            this.DateOfBirth = DateOfBirth;
            this.BisnodeConsumerId = BisnodeConsumerId;
            this._Protected = _Protected;
            this.AddressList = AddressList;
            this.FamilyName = FamilyName;
            this.YearOfBirth = YearOfBirth;
        }
        
        /// <summary>
        /// The consumer is no longer in the realm of the living. May he/she rest in peace.
        /// </summary>
        /// <value>The consumer is no longer in the realm of the living. May he/she rest in peace.</value>
        [DataMember(Name="deceased", EmitDefaultValue=false)]
        public bool? Deceased { get; set; }
        /// <summary>
        /// The customer&#39;s given name (first name) as is proper to use when informally addressing the customer.
        /// </summary>
        /// <value>The customer&#39;s given name (first name) as is proper to use when informally addressing the customer.</value>
        [DataMember(Name="givenName", EmitDefaultValue=false)]
        public string GivenName { get; set; }
        /// <summary>
        /// A key for uniquely identifying this customer record in Bisnode&#39;s databases. Used for retrieving more data on the customer or tracking changes to the customer&#39;s information in the appriopriate APIs when these are available. &lt;strong&gt;Should not be parsed as format is subject to change.&lt;/strong&gt;
        /// </summary>
        /// <value>A key for uniquely identifying this customer record in Bisnode&#39;s databases. Used for retrieving more data on the customer or tracking changes to the customer&#39;s information in the appriopriate APIs when these are available. &lt;strong&gt;Should not be parsed as format is subject to change.&lt;/strong&gt;</value>
        [DataMember(Name="memento", EmitDefaultValue=false)]
        public string Memento { get; set; }
        /// <summary>
        /// The formatted full name of the consumer. A combination of the fields givenName and familyName in a format that is proper for formally addressing the customer.
        /// </summary>
        /// <value>The formatted full name of the consumer. A combination of the fields givenName and familyName in a format that is proper for formally addressing the customer.</value>
        [DataMember(Name="fullName", EmitDefaultValue=false)]
        public string FullName { get; set; }
        /// <summary>
        /// All first names of this consumer.
        /// </summary>
        /// <value>All first names of this consumer.</value>
        [DataMember(Name="firstNames", EmitDefaultValue=false)]
        public List<string> FirstNames { get; set; }
        /// <summary>
        /// Indicates the language this consumer prefers, in accordance with &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc5646\&quot;&gt;RFC5646&lt;/a&gt;. E.g. sv, en-GB 
        /// </summary>
        /// <value>Indicates the language this consumer prefers, in accordance with &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc5646\&quot;&gt;RFC5646&lt;/a&gt;. E.g. sv, en-GB </value>
        [DataMember(Name="language", EmitDefaultValue=false)]
        public string Language { get; set; }
        /// <summary>
        /// List of phone numbers on which this consumer could be reached.
        /// </summary>
        /// <value>List of phone numbers on which this consumer could be reached.</value>
        [DataMember(Name="phoneList", EmitDefaultValue=false)]
        public List<Telephone> PhoneList { get; set; }
        /// <summary>
        /// Date of birth in accordance with &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/ISO_8601\&quot;&gt;ISO 8601&lt;/a&gt; date, i.e. YYYY-MM-DD
        /// </summary>
        /// <value>Date of birth in accordance with &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/ISO_8601\&quot;&gt;ISO 8601&lt;/a&gt; date, i.e. YYYY-MM-DD</value>
        [DataMember(Name="dateOfBirth", EmitDefaultValue=false)]
        public string DateOfBirth { get; set; }
        /// <summary>
        /// Bisnode&#39;s ID on this consumer. This can be used for retrieving more data on the customer or tracking changes to the customer&#39;s information in the appriopriate APIs when these are available. Currently we do not have this for all countries. &lt;strong&gt;Should not be parsed as format is subject to change.&lt;/strong&gt; Until we have this for all countries please use &lt;strong&gt;memento&lt;/strong&gt; instead.
        /// </summary>
        /// <value>Bisnode&#39;s ID on this consumer. This can be used for retrieving more data on the customer or tracking changes to the customer&#39;s information in the appriopriate APIs when these are available. Currently we do not have this for all countries. &lt;strong&gt;Should not be parsed as format is subject to change.&lt;/strong&gt; Until we have this for all countries please use &lt;strong&gt;memento&lt;/strong&gt; instead.</value>
        [DataMember(Name="bisnodeConsumerId", EmitDefaultValue=false)]
        public string BisnodeConsumerId { get; set; }
        /// <summary>
        /// The consumer&#39;s information is protected and will not be returned. Any previously stored information should be removed in compliance with local laws.
        /// </summary>
        /// <value>The consumer&#39;s information is protected and will not be returned. Any previously stored information should be removed in compliance with local laws.</value>
        [DataMember(Name="protected", EmitDefaultValue=false)]
        public bool? _Protected { get; set; }
        /// <summary>
        /// List of addresses on which this consumer can be reached.
        /// </summary>
        /// <value>List of addresses on which this consumer can be reached.</value>
        [DataMember(Name="addressList", EmitDefaultValue=false)]
        public List<Address> AddressList { get; set; }
        /// <summary>
        /// The customer&#39;s family name (last name).
        /// </summary>
        /// <value>The customer&#39;s family name (last name).</value>
        [DataMember(Name="familyName", EmitDefaultValue=false)]
        public string FamilyName { get; set; }
        /// <summary>
        /// A four digit representation
        /// </summary>
        /// <value>A four digit representation</value>
        [DataMember(Name="yearOfBirth", EmitDefaultValue=false)]
        public decimal? YearOfBirth { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConsumerEntity {\n");
            sb.Append("  Deceased: ").Append(Deceased).Append("\n");
            sb.Append("  Gender: ").Append(Gender).Append("\n");
            sb.Append("  GivenName: ").Append(GivenName).Append("\n");
            sb.Append("  Memento: ").Append(Memento).Append("\n");
            sb.Append("  FullName: ").Append(FullName).Append("\n");
            sb.Append("  FirstNames: ").Append(FirstNames).Append("\n");
            sb.Append("  Language: ").Append(Language).Append("\n");
            sb.Append("  PhoneList: ").Append(PhoneList).Append("\n");
            sb.Append("  DateOfBirth: ").Append(DateOfBirth).Append("\n");
            sb.Append("  BisnodeConsumerId: ").Append(BisnodeConsumerId).Append("\n");
            sb.Append("  _Protected: ").Append(_Protected).Append("\n");
            sb.Append("  AddressList: ").Append(AddressList).Append("\n");
            sb.Append("  FamilyName: ").Append(FamilyName).Append("\n");
            sb.Append("  YearOfBirth: ").Append(YearOfBirth).Append("\n");
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
            return this.Equals(obj as ConsumerEntity);
        }

        /// <summary>
        /// Returns true if ConsumerEntity instances are equal
        /// </summary>
        /// <param name="other">Instance of ConsumerEntity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConsumerEntity other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Deceased == other.Deceased ||
                    this.Deceased != null &&
                    this.Deceased.Equals(other.Deceased)
                ) && 
                (
                    this.Gender == other.Gender ||
                    this.Gender != null &&
                    this.Gender.Equals(other.Gender)
                ) && 
                (
                    this.GivenName == other.GivenName ||
                    this.GivenName != null &&
                    this.GivenName.Equals(other.GivenName)
                ) && 
                (
                    this.Memento == other.Memento ||
                    this.Memento != null &&
                    this.Memento.Equals(other.Memento)
                ) && 
                (
                    this.FullName == other.FullName ||
                    this.FullName != null &&
                    this.FullName.Equals(other.FullName)
                ) && 
                (
                    this.FirstNames == other.FirstNames ||
                    this.FirstNames != null &&
                    this.FirstNames.SequenceEqual(other.FirstNames)
                ) && 
                (
                    this.Language == other.Language ||
                    this.Language != null &&
                    this.Language.Equals(other.Language)
                ) && 
                (
                    this.PhoneList == other.PhoneList ||
                    this.PhoneList != null &&
                    this.PhoneList.SequenceEqual(other.PhoneList)
                ) && 
                (
                    this.DateOfBirth == other.DateOfBirth ||
                    this.DateOfBirth != null &&
                    this.DateOfBirth.Equals(other.DateOfBirth)
                ) && 
                (
                    this.BisnodeConsumerId == other.BisnodeConsumerId ||
                    this.BisnodeConsumerId != null &&
                    this.BisnodeConsumerId.Equals(other.BisnodeConsumerId)
                ) && 
                (
                    this._Protected == other._Protected ||
                    this._Protected != null &&
                    this._Protected.Equals(other._Protected)
                ) && 
                (
                    this.AddressList == other.AddressList ||
                    this.AddressList != null &&
                    this.AddressList.SequenceEqual(other.AddressList)
                ) && 
                (
                    this.FamilyName == other.FamilyName ||
                    this.FamilyName != null &&
                    this.FamilyName.Equals(other.FamilyName)
                ) && 
                (
                    this.YearOfBirth == other.YearOfBirth ||
                    this.YearOfBirth != null &&
                    this.YearOfBirth.Equals(other.YearOfBirth)
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
                if (this.Deceased != null)
                    hash = hash * 59 + this.Deceased.GetHashCode();
                if (this.Gender != null)
                    hash = hash * 59 + this.Gender.GetHashCode();
                if (this.GivenName != null)
                    hash = hash * 59 + this.GivenName.GetHashCode();
                if (this.Memento != null)
                    hash = hash * 59 + this.Memento.GetHashCode();
                if (this.FullName != null)
                    hash = hash * 59 + this.FullName.GetHashCode();
                if (this.FirstNames != null)
                    hash = hash * 59 + this.FirstNames.GetHashCode();
                if (this.Language != null)
                    hash = hash * 59 + this.Language.GetHashCode();
                if (this.PhoneList != null)
                    hash = hash * 59 + this.PhoneList.GetHashCode();
                if (this.DateOfBirth != null)
                    hash = hash * 59 + this.DateOfBirth.GetHashCode();
                if (this.BisnodeConsumerId != null)
                    hash = hash * 59 + this.BisnodeConsumerId.GetHashCode();
                if (this._Protected != null)
                    hash = hash * 59 + this._Protected.GetHashCode();
                if (this.AddressList != null)
                    hash = hash * 59 + this.AddressList.GetHashCode();
                if (this.FamilyName != null)
                    hash = hash * 59 + this.FamilyName.GetHashCode();
                if (this.YearOfBirth != null)
                    hash = hash * 59 + this.YearOfBirth.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            // Memento (string) maxLength
            if(this.Memento != null && this.Memento.Length > 256)
            {
                yield return new ValidationResult("Invalid value for Memento, length must be less than 256.", new [] { "Memento" });
            }

            // YearOfBirth (decimal?) minimum
            if(this.YearOfBirth < (decimal?)1899)
            {
                yield return new ValidationResult("Invalid value for YearOfBirth, must be a value greater than or equal to 1899.", new [] { "YearOfBirth" });
            }

            yield break;
        }
    }

}
