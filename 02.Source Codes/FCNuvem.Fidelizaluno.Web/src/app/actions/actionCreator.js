import {
    COURSE_LIST,
    STUDENT_LIST,
    PROGRAM_LIST,
    CAMPUS_LIST,
    PRESENCE_LIST,
    SET_PROGRAM_ID,
    SET_COURSE_ID,
    SET_CLASS_ID,
    CLASS_LIST,
    SET_TITULO,
    SET_CAMPUS_ID,
    SET_EVASION,
    // SET_STUDENT_NAMEFORM,
    // SET_STUDENT_RGMFORM
} from './actionTypes'


export function alunoList(alunos) {
    return { type: STUDENT_LIST, alunos };
}

export function cursoList(cursos) {
    return { type: PROGRAM_LIST, cursos }
}

export function turmaList(turmas) {
    return { type: CLASS_LIST, turmas }
}
export function disciplinaList(disciplina) {
    return { type: COURSE_LIST, disciplina };
}

export function presenceList(presenca) {
    return { type: PRESENCE_LIST, presenca };
}

export function setProgramId(idCurso) {
    return { type: SET_PROGRAM_ID, idCurso }
}

export function setCourseId(idDisciplina) {
    return { type: SET_COURSE_ID, idDisciplina }
}

export function setClassId(idTurma) {
    return { type: SET_CLASS_ID, idTurma }
}

export function setTitulo(titulo) {
    return { type: SET_TITULO, titulo }
}
export function setCampus(id) {
    return { type: SET_CAMPUS_ID, id }
}
export function campusList(campus) {
    return { type: CAMPUS_LIST, campus }
}
export function setEvasion(program, programValue) {
    return { type: SET_EVASION, program, programValue }
}