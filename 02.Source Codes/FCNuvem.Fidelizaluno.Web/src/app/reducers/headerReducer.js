import { List } from 'immutable';
import { CAMPUS_LIST, SET_CAMPUS_ID, SET_TITULO } from '../actions/actionTypes';

const initialState = {
    titulo: '',
    campus: new List(),
    idcampus: 1
};

export const headerReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_TITULO:
            return {
                ...state,
                titulo: action.titulo,
            };
        case SET_CAMPUS_ID:
            return {
                ...state,
                idcampus: action.id,
            };
        case CAMPUS_LIST:
            return {
                ...state,
                campus: action.campus
            };
        default:
            break;
    }

    return state;
}