import { AuthenticationContext, adalFetch, withAdalLogin } from 'react-adal';

export const adalConfig = {
  tenant: '{tenant}',
  clientId: '{clientId}',
  endpoints: {
    api: '{clientId}',
  },
  cacheLocation: 'localStorage'
};

export const validateToken = () => {
  let token = getToken();

  return fetch("{apiUrl}/api/user/validate", {
    headers: {
      'Authorization': 'Bearer ' + token,
    },
    method: "POST"
  })
    .then(response => response.json())
    .then(response => {
      if (!response.sucess)
        authContext.logOut();
    })
    .catch(error => authContext.logOut())
}


export const getToken = () => {
  return authContext.getCachedToken(authContext.config.clientId);
};

export const defaultOptions = {
  headers: {
    'Authorization': 'Bearer ' + getToken,
  }
};

export const authContext = new AuthenticationContext(adalConfig);

export const adalApiFetch = (fetch, url, options) =>
  adalFetch(authContext, adalConfig.endpoints.api, fetch, url, options);

export const getUser = () => {
  return authContext.getCachedUser();
}

export const withAdalLoginApi = withAdalLogin(authContext, adalConfig.endpoints.api);