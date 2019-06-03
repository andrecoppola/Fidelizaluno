import Reactotron from 'reactotron-react-js'
import { reactotronRedux } from 'reactotron-redux'

console.log(process.env.NODE_ENV)

if (process.env.NODE_ENV === 'development') {
    const tron = Reactotron.configure()
        .use(reactotronRedux())
        .connect()

    tron.clear()

    console.tron = tron
}