import { setEvasion } from '../actions/actionCreator';
import defaultOptions from '../config/fetchConfig';

const config = require('../../config')

export default class painelService {
    static setEvasion(programValue, idcampus) {
        return dispatch => {
            fetch(`${config.react.api.baseUrl}/evasion/Program/${programValue}?idcampus=${idcampus}`, defaultOptions)
                .then(response => response.json())
                .then(response => {
                    return (
                        dispatch(setEvasion(response.data, programValue)));
                });
        }
    }
}