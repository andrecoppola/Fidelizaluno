import { runWithAdal } from 'react-adal'
import { authContext } from '../src/app/config/adalConfig'

const DO_NOT_LOGIN = false

runWithAdal(
  authContext,
  () => {
    // validateToken();
    require('./indexApp.js')
  },
  DO_NOT_LOGIN
)
