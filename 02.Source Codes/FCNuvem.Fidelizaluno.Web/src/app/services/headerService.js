import { setCampus, setTitulo, campusList } from '../actions/actionCreator';
import defaultOptions from '../config/fetchConfig';

const config = require('../../config')

export default class HeaderService {
    static setTitulo(titulo){
        return dispatch => {
            dispatch(setTitulo(titulo));
        }
    }
    static setCampus(id){
        return dispatch => {
            dispatch(setCampus(id));
        }
    }
    static campusList() {
        return dispatch => {
            fetch(`${config.react.api.baseUrl}${'/campus'}`, defaultOptions)
                .then(response => response.json())
                .then(response => {
                    dispatch(campusList(response));
                });
        }
    }
}