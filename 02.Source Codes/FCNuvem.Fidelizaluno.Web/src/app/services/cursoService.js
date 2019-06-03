import { cursoList } from '../actions/actionCreator';
import 'isomorphic-fetch';
import defaultOptions from '../config/fetchConfig';
const config = require('../../config')

export default class CursoService {
    static getCurso(){
        return dispatch => {
        fetch(`${config.react.api.baseUrl}${config.react.api.cursoRoute}`, defaultOptions)
            .then(response => response.json())
            .then(response => {
                dispatch(cursoList(response));
                return response;
            })
            .catch(err => console.error(err.toString()))
        }
    }
}