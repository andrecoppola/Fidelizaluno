import { createStore, compose, applyMiddleware } from 'redux'
import reducers from "./app/reducers";

import thunkMiddleware from 'redux-thunk';

const initialState = window.__PRELOADED_STATE__;
const middlewares = [thunkMiddleware]

const store = createStore(
    reducers, initialState,
    compose(
        applyMiddleware(...middlewares),
        // process.env.NODE_ENV === 'development' ? null : console.tron.createEnhancer()
    )
)

export default store