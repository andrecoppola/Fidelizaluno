import {List} from 'immutable';
import { CLASS_LIST, SET_CLASS_ID } from '../actions/actionTypes';

const initialState = {
    turmas: new List(),
    idTurma: ''
  };

export const turmaReducer = (state = initialState, action) => {
    switch (action.type) {
        case CLASS_LIST:
            return {
                ...state,
                turmas: action.turmas,
            };
        case SET_CLASS_ID:
            return {
                ...state,
                idTurma: action.idTurma,
            };
        default:
            break;
    }

    return state;
}