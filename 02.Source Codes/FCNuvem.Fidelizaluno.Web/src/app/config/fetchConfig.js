import { getToken } from './adalConfig'

const defaultOptions = {
  headers: {
    'Authorization': 'Bearer ' + getToken(),
  }
};
  
export default defaultOptions;