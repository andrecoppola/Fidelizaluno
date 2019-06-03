import { PRESENCE_LIST } from '../actions/actionTypes';

const initialState = {
    presenca: '',
};

export const presencaReducer = (state = initialState, action) => {
    switch (action.type) {
        case PRESENCE_LIST:
        return {
          ...state,
          presenca: action.presenca.data
        };
      default:
        break;
    }
    return state;
}