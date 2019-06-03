import {List} from 'immutable';
import {STUDENT_LIST} from '../actions/actionTypes';

const initialState = {
  nomeForm: '',
  rgmForm: '',
  alunos: new List(),
  
};

export const alunoReducer = (state = initialState, action) => {
  switch (action.type) {
    case STUDENT_LIST:
      return {
        ...state,
        alunos: new List(action.alunos)
      };
    default:
      break;
  }

  return state;
}
