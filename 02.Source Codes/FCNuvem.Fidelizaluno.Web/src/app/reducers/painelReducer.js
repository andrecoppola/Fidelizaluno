import { SET_EVASION } from '../actions/actionTypes';

const initialState = {
    programValue: '80/100',
    listProgram: []
};

export const painelReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_EVASION:
            return {
                ...state,
                programValue: action.programValue,
                listProgram: action.program,
            };
        default:
            break;
    }

    return state;
}