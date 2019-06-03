import React from 'react'
import TextField from '@material-ui/core/TextField'
import MenuItem from '@material-ui/core/MenuItem'
import Snackbar from '@material-ui/core/Snackbar'
import Styles from '../../painel/painel.module.scss'
import next from '../../../assets/icons/next_.svg'
import history from '../../../../history'
import { TurmaService, CursoService, HeaderService, PresenceService } from '../../../services/index'
import { connect } from 'react-redux'

class alunosAusentes extends React.Component {
  state = {
    idCurso: '',
    idTurma: '',
    open: false,
    date: new Date().toISOString().substr(0, 10),
    cursos: [],
    turmas: []
  }

  loadTurmas = prop => event => {
    let idCurso = event.target.value
    this.setState({ [prop]: idCurso })
    this.props.getTurmas(idCurso)
  }

  handleChange = prop => event => {
    this.setState({ [prop]: event.target.value })
  }

  handleClick(idStudent) {
    history.push(`/aluno/${idStudent}`)
  }

  loadAlunos = prop => event => {
    event.preventDefault()
    this.setState({ [prop]: event.target.value })

    let dateSplit = prop === 'date' ? event.target.value.split('-') : this.state.date.split('-')
    let date = dateSplit[2] + '/' + dateSplit[1] + '/' + dateSplit[0]

    let filtro = {
      idProgram: this.state.idCurso,
      ClassRoom: this.state.idTurma,
      idCampus: this.props.idcampus
    }

    this.props.presenceList(filtro, date)
  }

  componentDidMount() {
    this.props.getCurso()
    this.props.setTitulo('Alunos Ausentes')
    this.loadAlunos()
  }

  handleClose = (event, reason) => {
    if (reason === 'clickaway') {
      return
    }

    this.setState({ open: false })
  }

  render() {
    console.log(this.props.presenca)

    document.title = 'Alunos Ausentes - Fidelizaluno'

    return (
      <div>
        <Snackbar
          anchorOrigin={{
            vertical: 'top',
            horizontal: 'right'
          }}
          open={this.state.open}
          autoHideDuration={6000}
          message="Salvo com sucesso!"
          onClose={this.handleClose}
        />
        <div className="wrapper">
          <div className="filter">
            <div className="col-group">
              <div className="col-3">
                <div className="form-group">
                  <TextField
                    select={true}
                    id="selectCurso"
                    label="Curso"
                    type="search"
                    margin="normal"
                    fullWidth
                    value={this.state.idCurso}
                    InputLabelProps={{ shrink: true }}
                    onChange={this.loadTurmas('idCurso')}
                  >
                    {this.props.cursos.map(option => (
                      <MenuItem key={option.id} value={option.id}>
                        {option.name}
                      </MenuItem>
                    ))}
                  </TextField>
                </div>
              </div>
              <div className="col-2">
                <div className="form-group">
                  <TextField
                    select
                    id="selectTurmas"
                    label="Turma"
                    type="search"
                    margin="normal"
                    fullWidth
                    InputLabelProps={{ shrink: true }}
                    value={this.state.idTurma}
                    onChange={this.loadAlunos('idTurma').bind(this)}
                  >
                    {this.props.turmas.map(option => (
                      <MenuItem key={option.id} value={option.id}>
                        {option.name}
                      </MenuItem>
                    ))}
                  </TextField>
                </div>
              </div>
              <div className="col-2">
                <div className="form-group">
                  <TextField
                    id="selectData"
                    label="Data"
                    type="date"
                    margin="normal"
                    fullWidth
                    InputLabelProps={{ shrink: true }}
                    value={this.state.date}
                    onChange={this.loadAlunos('date').bind(this)}
                  />
                </div>
              </div>
            </div>
          </div>
          {this.props.presenca.length > 0 && (
            <div>
              <div className="table-responsive">
                <table className="table" cellSpacing="0">
                  <thead>
                    <tr>
                      <td />
                      <td width="80">Nome</td>
                      <td width="80">RA</td>
                      <td width="80">Frequência</td>
                      <td width="80">Telefone</td>
                    </tr>
                  </thead>
                  <tbody>
                    {this.props.presenca.map(option => (
                      <tr>
                        <td className="pointer">
                          <img
                            onClick={() => this.handleClick(option.idStuden)}
                            src={option.photoUrl}
                            alt="Avatar"
                            style={{ width: '70px' }}
                          />
                        </td>
                        <td onClick={() => this.handleClick(option.idStudent)} className="pointer">
                          {option.name}
                        </td>
                        <td onClick={() => this.handleClick(option.idStudent)} className="pointer">
                          {option.ra}
                        </td>
                        <td onClick={() => this.handleClick(option.idStudent)} className="pointer">
                          {option.frequency.toFixed(2)}%
                        </td>
                        <td onClick={() => this.handleClick(option.idStudent)} className="pointer">
                          {option.phoneNumber}
                        </td>
                        <td onClick={() => this.handleClick(option.idStudent)} className="pointer">
                          <img className={Styles.Next} src={next} alt="next" />
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            </div>
          )}
        </div>
      </div>
    )
  }
}

const mapStateToProps = state => {
  return {
    idcampus: state.headerReducer.idcampus,
    presenca: state.presencaReducer.presenca,
    cursos: state.cursoReducer.cursos,
    turmas: state.turmaReducer.turmas
  }
}

const mapDispatchToProps = dispatch => {
  return {
    setCampus: event => {
      dispatch(HeaderService.setCampus(event.target.value))
    },
    getCurso: () => {
      dispatch(CursoService.getCurso())
    },
    getTurmas: idCurso => {
      dispatch(TurmaService.getTurmas(idCurso))
    },
    setTitulo: titulo => {
      dispatch(HeaderService.setTitulo(titulo))
    },
    presenceList: (filtro, date) => {
      dispatch(PresenceService.presenceList(filtro, date))
    }
  }
}

const TimelineContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(alunosAusentes)

export default TimelineContainer
