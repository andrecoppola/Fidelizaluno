import { turmaList, setClassId } from '../actions/actionCreator';
import 'isomorphic-fetch';
import defaultOptions from '../config/fetchConfig';
const config = require('../../config')

export default class TurmaService {
    static getTurmas(idProgram){
        return dispatch => {
        fetch(`${config.react.api.baseUrl}${config.react.api.turmaCourseRoute}/${idProgram}`, defaultOptions)
            .then(response => response.json())
            .then(response => {
                dispatch(turmaList(response));
                return response;
            })
            .catch(err => console.error(err.toString()))
        }
    }

    static setTurmaId(idTurma){
        return dispatch => {
            dispatch(setClassId(idTurma));
        }
    }
}