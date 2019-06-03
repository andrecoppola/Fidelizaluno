import {List} from 'immutable';
import { PROGRAM_LIST, SET_PROGRAM_ID } from '../actions/actionTypes';

const initialState = {
    cursos: new List(),
    idCurso: ''
  };

export const cursoReducer = (state = initialState, action) => {
    switch (action.type) {
        case PROGRAM_LIST:
            return {
                ...state,
                cursos: action.cursos
            };
        case SET_PROGRAM_ID:
            return {
                ...state,
                idCurso: action.idCurso
            }
        default:
            break;
    }

    return state;
}