import { AuthenticationContext, adalFetch, withAdalLogin } from 'react-adal';

export const adalConfig = {
  tenant: 'fcamaracloud.onmicrosoft.com',
  clientId: 'f5f21169-7ec6-4cb0-a0a4-34083f41bb9b',
  endpoints: {
    api: 'f5f21169-7ec6-4cb0-a0a4-34083f41bb9b',
  },
  cacheLocation: 'localStorage'//,
  //redirectUri: 'https://fidelizaluno-web.azurewebsites.net/home'
};

export const validateToken = () => {
  let token = getToken();

  return fetch("http://fidelizaluno-api.azurewebsites.net/api/user/validate", {
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