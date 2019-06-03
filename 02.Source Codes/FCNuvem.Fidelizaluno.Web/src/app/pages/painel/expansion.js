import React from 'react'
import ExpansionPanel from '@material-ui/core/ExpansionPanel'
import ExpansionPanelDetails from '@material-ui/core/ExpansionPanelDetails'
import ExpansionPanelSummary from '@material-ui/core/ExpansionPanelSummary'
import Typography from '@material-ui/core/Typography'
import ExpandMoreIcon from '@material-ui/icons/ExpandMore'
import Styles from './painel.module.scss'
import next from '../../assets/icons/next_.svg'
import history from '../../../history'
import { connect } from 'react-redux'
import { painelService } from '../../services/index'
import defaultOptions from '../../config/fetchConfig'

const config = require('../../../config')

class Expandido extends React.Component {
  state = {
    expanded: null,
    cursos: [],
    turmas: [],
    alunos: [],
    turmaValue: '',
    rangeMin: '',
    rangeMax: ''
  }

  expandCurso = panel => (event, expandCurso) => {
    this.setState({
      expandCurso: expandCurso ? panel : false
    })
  }

  expandTurma = panel => (event, expandTurma) => {
    this.setState({
      expandTurma: expandTurma ? panel : false
    })
  }

  expandPeriodo = panel => (event, expandPeriodo) => {
    this.setState({
      expandPeriodo: expandPeriodo ? panel : false
    })
  }

  loadStudents(turmaValue) {
    let program = this.props.programValue

    fetch(
      `${config.react.api.baseUrl}${'/evasion/students/'}${program + '/' + turmaValue}`,
      defaultOptions
    )
      .then(response => response.json())
      .then(response => {
        this.setState({
          alunos: response
        })
      })
  }

  componentDidMount() {
    let cursos = this.props.value || []
    this.setState({ cursos: cursos })
    this.turmaSelect()
  }

  handleClick(id) {
    history.push(`/aluno/${id}`)
  }

  turmaSelect = value => {
    this.setState({
      turmaValue: value
    })
  }

  render() {
    const { expandPeriodo, expandCurso, expandTurma } = this.state
    const alunos = this.state.alunos
    console.log(this.state.alunos)

    return (
      <div className={Styles.cursos}>
        <h3>Cursos</h3>
        {this.props.listProgram.map(curso => (
          <ExpansionPanel
            expanded={expandCurso === 'panel' + curso.id}
            onChange={this.expandCurso('panel' + curso.id)}
            className={Styles.cursosTab}
          >
            <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
              <Typography>
                <i className={Styles.textS}>{curso.name}</i>
              </Typography>
              <Typography style={{ position: 'absolute', right: '30px' }}>
                {curso.amount}
              </Typography>
            </ExpansionPanelSummary>
            <ExpansionPanelDetails>
              <Typography className={Styles.expand}>
                {curso.periods.map(periodo => (
                  <ExpansionPanel
                    expanded={expandPeriodo === 'panel' + periodo.id}
                    onChange={this.expandPeriodo('panel' + periodo.id)}
                    className={Styles.cursosSubTab}
                  >
                    <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
                      <Typography>
                        <i className={Styles.textS}>Periodo: {periodo.description}</i>
                      </Typography>
                      <Typography>{this.curso}</Typography>
                    </ExpansionPanelSummary>
                    {periodo.class.map(turma => (
                      <ExpansionPanel
                        onClick={() => this.turmaSelect(turma.id)}
                        expand={expandTurma === 'panel' + turma.id}
                        onchange={this.expandTurma('panel' + turma.id)}
                        className={Styles.cursosSubTab}
                      >
                        <ExpansionPanelSummary
                          onClick={() => this.loadStudents(turma.id)}
                          expandIcon={<ExpandMoreIcon />}
                        >
                          <Typography>
                            <i className={Styles.textS}>Turma: {turma.name}</i>
                          </Typography>
                          <Typography>{this.periodo}</Typography>
                        </ExpansionPanelSummary>
                        <ExpansionPanelDetails>
                          <div className="table-responsive">
                            <table className="table" cellSpacing="0">
                              <thead>
                                <tr>
                                  <td width="50%">Nome</td>
                                  <td className="text-center">Motivo</td>
                                  <td className="text-center">Porcentagem de Evasão</td>
                                  <td />
                                </tr>
                              </thead>
                              {alunos.map(aluno => (
                                <tbody onClick={() => this.handleClick(aluno.id)}>
                                  <tr>
                                    <td className="pointer">{aluno.name}</td>
                                    <td className="text-center2">
                                      {aluno.reasonsEvasion.splice(0, 3).map(u => (
                                        u.name + '(' + (u.percentage * 100 + '%); ')
                                      ))}
                                    </td>
                                    <td className="text-center">{aluno.evasionChance * 100} %</td>
                                    <td className="pointer">
                                      <img className={Styles.Next} src={next} alt="next" />
                                    </td>
                                  </tr>
                                </tbody>
                              ))}
                            </table>
                          </div>
                        </ExpansionPanelDetails>
                      </ExpansionPanel>
                    ))}
                  </ExpansionPanel>
                ))}
              </Typography>
            </ExpansionPanelDetails>
          </ExpansionPanel>
        ))}
      </div>
    )
  }
}

const mapStateToProps = state => {
  return {
    listProgram: state.painelReducer.listProgram,
    programValue: state.painelReducer.programValue
  }
}
const mapDispatchToProps = dispatch => {
  return {
    setEvasion: (programValue, idcampus) => {
      dispatch(painelService.setEvasion(programValue, idcampus))
    }
  }
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Expandido)
