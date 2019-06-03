import { presenceList } from '../actions/actionCreator';
import defaultOptions from '../config/fetchConfig';

const config = require('../../config')

export default class PresenceService {
    static presenceList(filtro, date) {
        let params = {};

        for (const key in filtro) {
            if (filtro[key])
                params[key] = filtro[key];
        }
        var url = new URL(`${config.react.api.baseUrl}${'/presence/Absent/'}${date}`);
        url.search = new URLSearchParams(params);


        return dispatch => {
            fetch(url, defaultOptions)
                .then(response => response.json())
                .then(presenca => {
                    dispatch(presenceList(presenca));
                    return presenca;
                })
                .catch(err => console.error(err.toString()))
        }
    }
}