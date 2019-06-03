using FCNuvem.FidelizaAluno.API.Configuration;
using FCNuvem.FidelizaAluno.API.Models.Embed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Protocols;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace FCNuvem.FidelizaAluno.API.Services
{
    public class EmbeddedViewModelService : BaseViewModelService
    {
        private APIConfiguration ApiConfiguration => GetService<IOptions<APIConfiguration>>().Value;

        public EmbedConfig EmbedConfig
        {
            get { return m_embedConfig; }
        }

        public TileEmbedConfig TileEmbedConfig
        {
            get { return m_tileEmbedConfig; }
        }

        private EmbedConfig m_embedConfig;
        private TileEmbedConfig m_tileEmbedConfig;
        private TokenCredentials m_tokenCredentials;

        public EmbeddedViewModelService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
            m_tokenCredentials = null;
            m_embedConfig = new EmbedConfig();
            m_tileEmbedConfig = new TileEmbedConfig();
        }

        public async Task<bool> EmbedReport(string username, string roles)
        {
            // Get token credentials for user
            var getCredentialsResult = await GetTokenCredentials();
            if (!getCredentialsResult)
            {
                // The error message set in GetTokenCredentials
                return false;
            }

            try
            {
                // Create a Power BI Client object. It will be used to call Power BI APIs.
                using (var client = new PowerBIClient(new Uri(ApiConfiguration.Embedded.ApiUrl), m_tokenCredentials))
                {
                    // Get a list of reports.
                    var reports = await client.Reports.GetReportsInGroupAsync(ApiConfiguration.Embedded.WorkspaceId);

                    // No reports retrieved for the given workspace.
                    if (reports.Value.Count() == 0)
                    {
                        m_embedConfig.ErrorMessage = "No reports were found in the workspace";
                        return false;
                    }

                    Report report;
                    if (string.IsNullOrWhiteSpace(ApiConfiguration.Embedded.ReportId))
                    {
                        // Get the first report in the workspace.
                        report = reports.Value.FirstOrDefault();
                    }
                    else
                    {
                        report = reports.Value.FirstOrDefault(r => r.Id.Equals(ApiConfiguration.Embedded.ReportId, StringComparison.InvariantCultureIgnoreCase));
                    }

                    if (report == null)
                    {
                        m_embedConfig.ErrorMessage = "No report with the given ID was found in the workspace. Make sure ReportId is valid.";
                        return false;
                    }

                    var datasets = await client.Datasets.GetDatasetByIdInGroupAsync(ApiConfiguration.Embedded.WorkspaceId, report.DatasetId);
                    m_embedConfig.IsEffectiveIdentityRequired = datasets.IsEffectiveIdentityRequired;
                    m_embedConfig.IsEffectiveIdentityRolesRequired = datasets.IsEffectiveIdentityRolesRequired;
                    GenerateTokenRequest generateTokenRequestParameters;
                    // This is how you create embed token with effective identities
                    if (!string.IsNullOrWhiteSpace(username))
                    {
                        var rls = new EffectiveIdentity(username, new List<string> { report.DatasetId });
                        if (!string.IsNullOrWhiteSpace(roles))
                        {
                            var rolesList = new List<string>();
                            rolesList.AddRange(roles.Split(','));
                            rls.Roles = rolesList;
                        }
                        // Generate Embed Token with effective identities.
                        generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view", identities: new List<EffectiveIdentity> { rls });
                    }
                    else
                    {
                        // Generate Embed Token for reports without effective identities.
                        generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view");
                    }

                    var tokenResponse = await client.Reports.GenerateTokenInGroupAsync(ApiConfiguration.Embedded.WorkspaceId, report.Id, generateTokenRequestParameters);

                    if (tokenResponse == null)
                    {
                        m_embedConfig.ErrorMessage = "Failed to generate embed token.";
                        return false;
                    }

                    // Generate Embed Configuration.
                    m_embedConfig.EmbedToken = tokenResponse;
                    m_embedConfig.EmbedUrl = report.EmbedUrl;
                    m_embedConfig.Id = report.Id;
                }
            }
            catch (HttpOperationException exc)
            {
                m_embedConfig.ErrorMessage = string.Format("Status: {0} ({1})\r\nResponse: {2}\r\nRequestId: {3}", exc.Response.StatusCode, (int)exc.Response.StatusCode, exc.Response.Content, exc.Response.Headers["RequestId"].FirstOrDefault());
                return false;
            }

            return true;
        }

        public async Task<bool> EmbedDashboard()
        {
            // Get token credentials for user
            var getCredentialsResult = await GetTokenCredentials();
            if (!getCredentialsResult)
            {
                // The error message set in GetTokenCredentials
                return false;
            }

            try
            {
                // Create a Power BI Client object. It will be used to call Power BI APIs.
                using (var client = new PowerBIClient(new Uri(ApiConfiguration.Embedded.ApiUrl), m_tokenCredentials))
                {
                    // Get a list of dashboards.
                    var dashboards = await client.Dashboards.GetDashboardsInGroupAsync(ApiConfiguration.Embedded.WorkspaceId);

                    // Get the first report in the workspace.
                    var dashboard = dashboards.Value.FirstOrDefault();

                    if (dashboard == null)
                    {
                        m_embedConfig.ErrorMessage = "Workspace has no dashboards.";
                        return false;
                    }

                    // Generate Embed Token.
                    var generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view");
                    var tokenResponse = await client.Dashboards.GenerateTokenInGroupAsync(ApiConfiguration.Embedded.WorkspaceId, dashboard.Id, generateTokenRequestParameters);

                    if (tokenResponse == null)
                    {
                        m_embedConfig.ErrorMessage = "Failed to generate embed token.";
                        return false;
                    }

                    // Generate Embed Configuration.
                    m_embedConfig = new EmbedConfig()
                    {
                        EmbedToken = tokenResponse,
                        EmbedUrl = dashboard.EmbedUrl,
                        Id = dashboard.Id
                    };

                    return true;
                }
            }
            catch (HttpOperationException exc)
            {
                m_embedConfig.ErrorMessage = string.Format("Status: {0} ({1})\r\nResponse: {2}\r\nRequestId: {3}", exc.Response.StatusCode, (int)exc.Response.StatusCode, exc.Response.Content, exc.Response.Headers["RequestId"].FirstOrDefault());
                return false;
            }
        }

        public async Task<bool> EmbedTile()
        {
            // Get token credentials for user
            var getCredentialsResult = await GetTokenCredentials();
            if (!getCredentialsResult)
            {
                // The error message set in GetTokenCredentials
                m_tileEmbedConfig.ErrorMessage = m_embedConfig.ErrorMessage;
                return false;
            }

            try
            {
                // Create a Power BI Client object. It will be used to call Power BI APIs.
                using (var client = new PowerBIClient(new Uri(ApiConfiguration.Embedded.ApiUrl), m_tokenCredentials))
                {
                    // Get a list of dashboards.

                    var workspaces = client.Groups.GetGroups();
                    var sourceWorkspace = workspaces.Value.FirstOrDefault(g => g.Id == ApiConfiguration.Embedded.WorkspaceId);

                    var dashboards = await client.Dashboards.GetDashboardsInGroupAsync(ApiConfiguration.Embedded.WorkspaceId);

                    // Get the first report in the workspace.
                    var dashboard = dashboards.Value.FirstOrDefault();

                    if (dashboard == null)
                    {
                        m_tileEmbedConfig.ErrorMessage = "Workspace has no dashboards.";
                        return false;
                    }

                    var tiles = await client.Dashboards.GetTilesInGroupAsync(ApiConfiguration.Embedded.WorkspaceId, dashboard.Id);

                    // Get the first tile in the workspace.
                    var tile = tiles.Value.FirstOrDefault();

                    // Generate Embed Token for a tile.
                    var generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view");
                    var tokenResponse = await client.Tiles.GenerateTokenInGroupAsync(ApiConfiguration.Embedded.WorkspaceId, dashboard.Id, tile.Id, generateTokenRequestParameters);

                    if (tokenResponse == null)
                    {
                        m_tileEmbedConfig.ErrorMessage = "Failed to generate embed token.";
                        return false;
                    }

                    // Generate Embed Configuration.
                    m_tileEmbedConfig = new TileEmbedConfig()
                    {
                        EmbedToken = tokenResponse,
                        EmbedUrl = tile.EmbedUrl,
                        Id = tile.Id,
                        dashboardId = dashboard.Id
                    };

                    return true;
                }
            }
            catch (HttpOperationException exc)
            {
                m_embedConfig.ErrorMessage = string.Format("Status: {0} ({1})\r\nResponse: {2}\r\nRequestId: {3}", exc.Response.StatusCode, (int)exc.Response.StatusCode, exc.Response.Content, exc.Response.Headers["RequestId"].FirstOrDefault());
                return false;
            }
        }

        /// <summary>
        /// Check if web.config embed parameters have valid values.
        /// </summary>
        /// <returns>Null if web.config parameters are valid, otherwise returns specific error string.</returns>
        private string GetWebConfigErrors()
        {
            // Application Id must have a value.
            if (string.IsNullOrWhiteSpace(ApiConfiguration.Embedded.ApplicationId))
            {
                return "ApplicationId is empty. please register your application as Native app in https://dev.powerbi.com/apps and fill client Id in web.config.";
            }

            // Application Id must be a Guid object.
            Guid result;
            if (!Guid.TryParse(ApiConfiguration.Embedded.ApplicationId, out result))
            {
                return "ApplicationId must be a Guid object. please register your application as Native app in https://dev.powerbi.com/apps and fill application Id in web.config.";
            }

            // Workspace Id must have a value.
            if (string.IsNullOrWhiteSpace(ApiConfiguration.Embedded.WorkspaceId))
            {
                return "WorkspaceId is empty. Please select a group you own and fill its Id in web.config";
            }

            // Workspace Id must be a Guid object.
            if (!Guid.TryParse(ApiConfiguration.Embedded.WorkspaceId, out result))
            {
                return "WorkspaceId must be a Guid object. Please select a workspace you own and fill its Id in web.config";
            }

            if (ApiConfiguration.Embedded.AuthenticationType.Equals("MasterUser"))
            {
                // Username must have a value.
                if (string.IsNullOrWhiteSpace(ApiConfiguration.Embedded.Username))
                {
                    return "Username is empty. Please fill Power BI username in web.config";
                }

                // Password must have a value.
                if (string.IsNullOrWhiteSpace(ApiConfiguration.Embedded.Password))
                {
                    return "Password is empty. Please fill password of Power BI username in web.config";
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(ApiConfiguration.Embedded.ApplicationSecret))
                {
                    return "ApplicationSecret is empty. please register your application as Web app and fill appSecret in web.config.";
                }

                // Must fill tenant Id
                if (string.IsNullOrWhiteSpace(ApiConfiguration.Embedded.Tenant))
                {
                    return "Invalid Tenant. Please fill Tenant ID in Tenant under web.config";
                }
            }

            return null;
        }

        private async Task<OAuthResult> DoAuthentication()
        {
            if (ApiConfiguration.Embedded.AuthenticationType.Equals("MasterUser"))
            {
                var authenticationContext = new AuthenticationContext(ApiConfiguration.Embedded.AuthorityUrl);

                // Authentication using master user credentials

                var oauthEndpoint = new Uri(ApiConfiguration.Embedded.AuthorityUrl);

                using (var client = new HttpClient())
                {
                    var result = await client.PostAsync(oauthEndpoint, new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("resource", ApiConfiguration.Embedded.ResourceUrl),
                        new KeyValuePair<string, string>("client_id", "9fabcf50-85ae-4a2c-a054-e6e6b41dbb6e"),
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", ApiConfiguration.Embedded.Username),
                        new KeyValuePair<string, string>("password", ApiConfiguration.Embedded.Password),
                        new KeyValuePair<string, string>("scope", "openid"),
                    }));

                    var content = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<OAuthResult>(content);
                }
            }

            return null;
        }

        private async Task<bool> GetTokenCredentials()
        {
            // var result = new EmbedConfig { Username = username, Roles = roles };
            var error = GetWebConfigErrors();
            if (error != null)
            {
                m_embedConfig.ErrorMessage = error;
                return false;
            }

            // Authenticate using created credentials
            OAuthResult authenticationResult = null;
            try
            {
                authenticationResult = await DoAuthentication();
            }
            catch (AggregateException exc)
            {
                m_embedConfig.ErrorMessage = exc.InnerException.Message;
                return false;
            }

            if (authenticationResult == null)
            {
                m_embedConfig.ErrorMessage = "Authentication Failed.";
                return false;
            }

            m_tokenCredentials = new TokenCredentials(authenticationResult.AccessToken, "Bearer");
            return true;
        }
    }
}
