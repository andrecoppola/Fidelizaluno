import { alunoList } from '../actions/actionCreator';
import 'isomorphic-fetch';
import defaultOptions from '../config/fetchConfig';

const config = require('../../config')

export default class AlunoService {
    static searchAluno(filtro){
        let params = {};

        for (const key in filtro) {
            if (filtro[key])
              params[key] = filtro[key];
        }

        var url = new URL( `${config.react.api.baseUrl}${config.react.api.alunosRoute}`);
        url.search = new URLSearchParams(params);

        return dispatch => {
        fetch(url, defaultOptions)
            .then(response => response.json())
            .then(alunos => {
                dispatch(alunoList(alunos));

                return alunos;
            })
            .catch(err => console.error(err.toString()))
        }
    }
}