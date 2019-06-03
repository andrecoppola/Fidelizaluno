import React, { Component } from 'react';
import TextField from '@material-ui/core/TextField';
import estilos from './busca.module.scss';
import MenuItem from '@material-ui/core/MenuItem';
import next from "../../../assets/icons/next_.svg";
import history from '../../../../history';
import { AlunoService, TurmaService, CursoService, HeaderService } from '../../../services/index';
import { connect } from 'react-redux';

class BuscaAlunos extends Component {

    state = {
        name: '',
        ra: '',
        idClassRoom: '',
        idProgram: ''
    }

    handleChange = prop => event => {
        this.setState({ prop: event.target.value });
    };

    componentDidMount() {
        this.props.getCurso();
        this.props.setTitulo("Busca de Alunos");
    }

    handleChange = prop => event => {
        this.setState({ [prop]: event.target.value });
    };

    loadTurmas = prop => event => {
        let idProgram = event.target.value;
        this.setState({ [prop]: idProgram });
        this.props.getTurmas(idProgram);
    }


    reset = () => {
        this.setState({ idClassRoom: '' });
        this.setState({ idProgram: '' });
        this.setState({ alunos: [] });
    }

    formSubmit = event => {
        event.preventDefault();

        let filtro = {
            name: this.state.name,
            RA: this.state.ra,
            idProgram: this.state.idProgram,
            idClassRoom: this.state.idClassRoom,
            idCampus: this.props.idcampus
        }
        this.props.searchAluno(filtro);
    }

    handleClick(id) {
        history.push(`/aluno/${id}`)
    }

    render() {
        const { idProgram, idClassRoom } = this.state;
        document.title = 'Busca de Alunos - Fidelizaluno'
        return (
            <div className="wrapper">
                <form method="get" action="." onSubmit={this.formSubmit} className="filter">
                    <div className="col-group">
                        <div className="col-3">
                            <div className="form-group">
                                <TextField
                                    id="searchAluno"
                                    label="Nome do Aluno"
                                    placeholder="Digite o nome do aluno"
                                    type="search"
                                    margin="normal"
                                    onChange={this.handleChange("name")}
                                    fullWidth
                                />
                            </div>
                        </div>
                        <div className="col-3">
                            <div className="form-group">
                                <TextField
                                    id="searchRA"
                                    label="RGM"
                                    placeholder="RGM do aluno"
                                    type="search"
                                    onChange={this.handleChange("ra")}
                                    margin="normal"
                                    fullWidth
                                />
                            </div>
                        </div>
                        <div className="col-3">
                            <div className="form-group">
                                <TextField
                                    select={true}
                                    id="searchCurso"
                                    label="Curso"
                                    type="search"
                                    margin="normal"
                                    fullWidth
                                    value={idProgram}
                                    InputLabelProps={{ shrink: true }}
                                    onChange={this.loadTurmas("idProgram")}
                                >
                                    {this.props.cursos.map((option) => (
                                        <MenuItem key={option.id} value={option.id}>{option.name}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </div>
                        </div>
                        <div className="col-3">
                            <div className="form-group">
                                <TextField
                                    select
                                    id="searchTurmas"
                                    label="Turma"
                                    type="search"
                                    margin="normal"
                                    fullWidth
                                    InputLabelProps={{ shrink: true }}
                                    value={idClassRoom}
                                    onChange={this.handleChange("idClassRoom")}
                                >
                                    {this.props.turmas.map((option) => (
                                        <MenuItem key={option.id} value={option.id}>
                                            {option.name}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </div>
                        </div>
                        <div className="col-12">
                            <input className={estilos.BtnBusca} type="submit" value="Pesquisar" />
                            <input className={estilos.BtnLimpa} type="reset" value="Limpar" onClick={this.reset} />
                        </div>
                    </div>
                </form>
                <div className="table-responsive">
                    <table className="table" cellSpacing="0">
                        <thead>
                            <tr>
                                <td width="80"></td>
                                <td></td>
                                <td className="text-center">Frequência</td>
                                <td className="text-center">Média de Nota</td>
                                <td className="text-center">Inadimplente</td>
                                <td className="text-center">% de Evasão</td>
                                <td></td>
                            </tr>
                        </thead>
                        <tbody>
                            {this.props.alunos.map((aluno) => (
                                <tr key={aluno.id}>
                                    <td width="80">
                                        <img onClick={() => this.handleClick(aluno.id)} src={aluno.urlPicture} className={estilos.avatar} alt="Avatar" />
                                    </td>
                                    <td className={estilos.pointer} onClick={() => this.handleClick(aluno.id)}>
                                        {aluno.name}
                                    </td>
                                    <td className="text-center">{aluno.frequency.toFixed(2)}%</td>
                                    <td className="text-center">{aluno.mediaScore}</td>
                                    <td className="text-center">{aluno.overdue ? "Sim" : "Não"}</td>
                                    <td className="text-center"><span className="text-red">{aluno.evasionChance * 100}%</span></td>
                                    <td>
                                        <img className="pointer" onClick={() => this.handleClick(aluno.id)} src={next} alt="next" />
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        alunos: state.alunoReducer.alunos,
        cursos: state.cursoReducer.cursos,
        turmas: state.turmaReducer.turmas,
        idcampus: state.headerReducer.idcampus
    }
};

const mapDispatchToProps = dispatch => {
    return {
        searchAluno: (filtro) => {
            dispatch(AlunoService.searchAluno(filtro));
        },
        getCurso: () => {
            dispatch(CursoService.getCurso());
        },
        getTurmas: (idCurso) => {
            dispatch(TurmaService.getTurmas(idCurso));
        },
        setTitulo: (titulo) => {
            dispatch(HeaderService.setTitulo(titulo))
        },
        setCampus: (event) => {
          dispatch(HeaderService.setCampus(event.target.value))
      }
    }
}

const TimelineContainer = connect(mapStateToProps, mapDispatchToProps)(BuscaAlunos);

export default TimelineContainer;