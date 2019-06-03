import { combineReducers } from "redux";
import { alunoReducer } from './alunoReducer';
import { cursoReducer } from './cursoReducer'
import { turmaReducer } from './turmaReducer'
import { headerReducer } from './headerReducer';
import { painelReducer } from './painelReducer';
import { presencaReducer } from './presencaReducer';

const rootReducer = combineReducers({
    alunoReducer,
    cursoReducer,
    turmaReducer,
    headerReducer,
    painelReducer,
    presencaReducer,
});

export default rootReducer;

