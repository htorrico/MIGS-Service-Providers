using Common.Exceptions;
using Common.HttpHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Proxy
{
    public class CustomProxyREST<K> : IDisposable where K : class, new()
    {
        private IConfigurationLib ConfigurationLib = null;
        public CustomProxyREST(IConfigurationLib _ConfigurationLib)
        {
            ConfigurationLib = _ConfigurationLib;
        }

        public async Task<EResponseBase<TokenResponse>> GetToken(
        string urlBase,
        string tokenPrefix,
        string transactionId,
        string origen,
        bool ignoreSSLCertificate,
        int secondsTimeOutWS,
        IEnumerable<KeyValuePair<string, string>> securityData)
        {
            try
            {
                var request = JsonConvert.SerializeObject(securityData);
                using (var httpClient = new HttpClient())
                {
                    using (var content = new FormUrlEncodedContent(securityData))
                    {
                        try
                        {
                            var url = ProxyBase.GetURL(urlBase, tokenPrefix);
                            content.Headers.Clear();
                            content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                            HttpResponseMessage response = await httpClient.PostAsync(url, content);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                var result = await response.Content.ReadAsStringAsync();
                                var responseData = JsonConvert.DeserializeObject<TokenResponse>(result);
                                return new UtilitariesResponse<TokenResponse>(ConfigurationLib).setResponseBaseForOK(responseData);
                            }
                            else
                            {
                                var result = await response.Content.ReadAsStringAsync();
                                var responseData = JsonConvert.DeserializeObject<TokenErrorResponse>(result);
                                return new UtilitariesResponse<TokenResponse>(ConfigurationLib).setResponseBaseForNoAuthorized(responseData);
                            }


                        }
                        catch (Exception ex)
                        {
                            return new UtilitariesResponse<TokenResponse>(ConfigurationLib).setResponseBaseForException(ex);
                        }
                    }
                }
            }
            catch (WSNotFoundException ex)
            {
                return new UtilitariesResponse<TokenResponse>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (WSNotAuthorized ex)
            {
                return new UtilitariesResponse<TokenResponse>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<TokenResponse>(ConfigurationLib).setResponseBaseForException(ex);
            }
        }

        public Task Get(string coreAPI_UrlBase, string coreAPI_ServicePrefix, string coreAPI_ClientController, string coreAPI_Client_GetAction, string tokenType, string v, string transactionId, string mobile, object coreAPI_IgnoreSSL, string coreAPI_Timeout)
        {
            throw new NotImplementedException();
        }

        public async Task<EResponseBase<K>> Get(
            string urlBase,
            string servicePrefix,
            string controller,
            string action,
            string tokenType,
            string accessToken,
            string transactionId,
            string origen,
            bool ignoreSSLCertificate,
            int secondsTimeOutWS
            )
        {
            try
            {
                if (ignoreSSLCertificate) ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                using (var client = ProxyBase.GetClient(secondsTimeOutWS, urlBase, transactionId, origen, tokenType, accessToken))
                {
                    try
                    {
                        var url = ProxyBase.GetURL(urlBase, servicePrefix, controller, action);
                        var response = client.GetAsync(url).Result;
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            ProxyBase.validResponse(response);
                            var result = await response.Content.ReadAsStringAsync();
                            var model = JsonConvert.DeserializeObject<EResponseBase<K>>(result);
                            return model;
                        }
                        else
                        {
                            if (response.StatusCode == HttpStatusCode.Unauthorized)
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForNoAuthorized();
                            else
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForExceptionUnexpected();
                        }

                    }
                    catch (Exception ex)
                    {
                        return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
                    }
                }
            }
            catch (WSNotFoundException ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (WSNotAuthorized ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
        }


        public async Task<EResponseBase<K>> Get(
             string urlBase,
             string servicePrefix,
             string controller,
             string action,
             string tokenType,
             string accessToken,
             string transactionId,
             string origen,
             bool ignoreSSLCertificate,
             int secondsTimeOutWS,
             string queryParams
             )
        {
            try
            {
                if (ignoreSSLCertificate) ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                using (var client = ProxyBase.GetClient(secondsTimeOutWS, urlBase, transactionId, origen, tokenType, accessToken))
                {
                    try
                    {
                        var url = ProxyBase.GetURL(urlBase, servicePrefix, controller, action, queryParams);
                        var response = client.GetAsync(url).Result;
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            ProxyBase.validResponse(response);
                            var result = await response.Content.ReadAsStringAsync();
                            var model = JsonConvert.DeserializeObject<EResponseBase<K>>(result);
                            return model;
                        }
                        else
                        {
                            if (response.StatusCode == HttpStatusCode.Unauthorized)
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForNoAuthorized();
                            else
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForExceptionUnexpected();
                        }

                    }
                    catch (Exception ex)
                    {
                        return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
                    }
                }
            }
            catch (WSNotFoundException ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (WSNotAuthorized ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
        }

        public async Task<EResponseBase<K>> Get(
             string urlBase,
             string servicePrefix,
             string controller,
             string action,
             string tokenType,
             string accessToken,
             string transactionId,
             string origen,
             bool ignoreSSLCertificate,
             int secondsTimeOutWS,
             int id
             )
        {
            try
            {
                if (ignoreSSLCertificate) ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                using (var client = ProxyBase.GetClient(secondsTimeOutWS, urlBase, transactionId, origen, tokenType, accessToken))
                {
                    try
                    {
                        var url = ProxyBase.GetURL(urlBase, servicePrefix, controller, action, id);
                        var response = client.GetAsync(url).Result;
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            ProxyBase.validResponse(response);
                            var result = await response.Content.ReadAsStringAsync();
                            var model = JsonConvert.DeserializeObject<EResponseBase<K>>(result);
                            return model;
                        }
                        else
                        {
                            if (response.StatusCode == HttpStatusCode.Unauthorized)
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForNoAuthorized();
                            else
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForExceptionUnexpected();
                        }
                    }
                    catch (Exception ex)
                    {
                        return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
                    }
                }
            }
            catch (WSNotFoundException ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (WSNotAuthorized ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CustomProxyREST() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class CustomProxyREST<T, K> : IDisposable where T : class, new() where K : class, new()
    {

        private IConfigurationLib ConfigurationLib = null;
        public CustomProxyREST(IConfigurationLib _ConfigurationLib)
        {
            ConfigurationLib = _ConfigurationLib;
        }


        public async Task<EResponseBase<K>> Post(
            string urlBase,
            string servicePrefix,
            string controller,
            string action,
            string tokenType,
            string accessToken,
            string transactionId,
            string origen,
            bool ignoreSSLCertificate,
            int secondsTimeOutWS,
            T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                if (ignoreSSLCertificate) ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                using (var client = ProxyBase.GetClient(secondsTimeOutWS, urlBase, transactionId, origen, tokenType, accessToken))
                {
                    try
                    {
                        var url = ProxyBase.GetURL(urlBase, servicePrefix, controller, action);
                        var response = client.PostAsync(url, content).Result;
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            ProxyBase.validResponse(response);
                            var result = await response.Content.ReadAsStringAsync();
                            var modelResponse = JsonConvert.DeserializeObject<EResponseBase<K>>(result);
                            return modelResponse;
                        }
                        else
                        {
                            if (response.StatusCode == HttpStatusCode.Unauthorized)
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForNoAuthorized();
                            else
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForExceptionUnexpected();
                        }

                    }
                    catch (Exception ex)
                    {
                        return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
                    }
                }
            }
            catch (WSNotFoundException ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (WSNotAuthorized ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
        }


        public async Task<EResponseBase<K>> Put(
            string urlBase,
            string servicePrefix,
            string controller,
            string action,
            string tokenType,
            string accessToken,
            string transactionId,
            string origen,
            bool ignoreSSLCertificate,
            int secondsTimeOutWS,
            T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                using (var client = ProxyBase.GetClient(secondsTimeOutWS, urlBase, transactionId, origen, tokenType, accessToken))
                {
                    try
                    {
                        var url = ProxyBase.GetURL(urlBase, servicePrefix, controller, action);
                        var response = client.PutAsync(url, content).Result;
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            ProxyBase.validResponse(response);
                            var result = await response.Content.ReadAsStringAsync();
                            var modelResponse = JsonConvert.DeserializeObject<EResponseBase<K>>(result);
                            return modelResponse;
                        }
                        else
                        {
                            if (response.StatusCode == HttpStatusCode.Unauthorized)
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForNoAuthorized();
                            else
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForExceptionUnexpected();
                        }

                    }
                    catch (Exception ex)
                    {
                        return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
                    }
                }
            }
            catch (WSNotFoundException ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (WSNotAuthorized ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
        }

        public async Task<EResponseBase<K>> Delete(
            string urlBase,
            string servicePrefix,
            string controller,
            string action,
            string tokenType,
            string accessToken,
            string transactionId,
            string origen,
            bool ignoreSSLCertificate,
            int secondsTimeOutWS,
            T model)
        {
            try
            {
                using (var client = ProxyBase.GetClient(secondsTimeOutWS, urlBase, transactionId, origen, tokenType, accessToken))
                {
                    try
                    {
                        var url = ProxyBase.GetURL(urlBase, servicePrefix, controller, action);
                        var response = client.DeleteAsync(url).Result;
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            ProxyBase.validResponse(response);
                            var result = await response.Content.ReadAsStringAsync();
                            var modelResponse = JsonConvert.DeserializeObject<EResponseBase<K>>(result);
                            return modelResponse;
                        }
                        else
                        {
                            if (response.StatusCode == HttpStatusCode.Unauthorized)
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForNoAuthorized();
                            else
                                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForExceptionUnexpected();
                        }

                    }
                    catch (Exception ex)
                    {
                        return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
                    }
                }

            }
            catch (WSNotFoundException ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (WSNotAuthorized ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
            catch (Exception ex)
            {
                return new UtilitariesResponse<K>(ConfigurationLib).setResponseBaseForException(ex);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CustomProxyREST() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
