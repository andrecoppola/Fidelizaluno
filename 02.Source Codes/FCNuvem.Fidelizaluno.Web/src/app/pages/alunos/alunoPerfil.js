import React, { Component } from 'react'
import styles from './aluno.module.scss'
import TextField from '@material-ui/core/TextField'
import { HeaderService } from '../../services/index'
import { connect } from 'react-redux'
import defaultOptions from '../../config/fetchConfig'

const config = require('../../../config')

class alunoPerfil extends Component {
  constructor(props) {
    super(props)
    this.state = {
      alunos: [],
      endereco: [],
      person: []
    }
  }

  loadDados() {
    let id = this.props.match.params.id

    var url = new URL(`${config.react.api.baseUrl}${'/student/'}${id}`)

    fetch(url, defaultOptions)
      .then(response => response.json())
      .then(alunos => {
        this.setState({ alunos: alunos, endereco: alunos.person.address, person: alunos.person })
      })
      .catch(err => console.error(err.toString()))
  }

  inadimplenteStatus() {
    if (this.state.overdue) {
      return 'Sim'
    } else {
      return 'Não'
    }
  }

  componentDidMount() {
    this.loadDados()
    this.props.setTitulo('Perfil do Aluno')
  }

  loadReason() {
    if (this.state.alunos.reasonsEvasion) {
      return this.state.alunos.reasonsEvasion.map((reason, index) => {
        if (index < 3)
          return (
            reason.name + '(' + (reason.percentage * 100 + '%); ')
          )
      })
    }
  }

  render() {
    document.title = 'Perfil - Fidelizaluno'
    console.log(this.state.alunos)

    return (
      <div key={this.props.match.params.id} className="wrapper">
        <div className="col-group">
          <div className="col-3 text-center">
            <div className={styles.alunoFoto}>
              <img src={this.state.person.urlPicture} className={styles.avatar} alt="Avatar" />
            </div>
          </div>
          <div className="col-9">
            <div className="col-group">
              <div className="col-9">
                <TextField
                  disabled
                  className={styles['form-input']}
                  id="standard-disabled"
                  InputLabelProps={{ shrink: true }}
                  label="Nome:"
                  value={this.state.person.name}
                  margin="normal"
                  fullWidth
                />
              </div>
              <div className="col-3">
                <TextField
                  disabled
                  className={styles['form-input']}
                  id="standard-disabled"
                  InputLabelProps={{ shrink: true }}
                  label="RGM"
                  value={this.state.alunos.ra}
                  margin="normal"
                />
              </div>
              <div className="col-4">
                <TextField
                  disabled
                  className={styles['form-input']}
                  id="standard-disabled"
                  InputLabelProps={{ shrink: true }}
                  label="Endereço"
                  value={this.state.endereco.addressLine1}
                  margin="normal"
                />
              </div>
              <div className="col-1">
                <TextField
                  disabled
                  className={styles['form-input']}
                  id="standard-disabled"
                  InputLabelProps={{ shrink: true }}
                  label="Nº"
                  value={this.state.endereco.number}
                  margin="normal"
                />
              </div>
              <div className="col-3">
                <TextField
                  disabled
                  className={styles['form-input']}
                  id="standard-disabled"
                  InputLabelProps={{ shrink: true }}
                  label="Bairro"
                  value={this.state.endereco.region}
                  margin="normal"
                />
              </div>
              <div className="col-3">
                <TextField
                  disabled
                  className={styles['form-input']}
                  id="standard-disabled"
                  InputLabelProps={{ shrink: true }}
                  label="Cidade"
                  value={this.state.endereco.city}
                  margin="normal"
                />
              </div>
              <div className="col-1">
                <TextField
                  disabled
                  className={styles['form-input']}
                  id="standard-disabled"
                  InputLabelProps={{ shrink: true }}
                  label="UF"
                  value={this.state.endereco.state}
                  margin="normal"
                />
              </div>
              <div className="col-6">
                <TextField
                  disabled
                  className={styles['form-input']}
                  id="standard-disabled"
                  InputLabelProps={{ shrink: true }}
                  label="Email:"
                  value={this.state.person.email}
                  margin="normal"
                  fullWidth
                />
              </div>
              <div className="col-3">
                <TextField
                  disabled
                  className={styles['form-input']}
                  id="standard-disabled"
                  InputLabelProps={{ shrink: true }}
                  label="Gênero:"
                  value={this.state.person.genre}
                  margin="normal"
                />
              </div>
            </div>
          </div>
        </div>

        <div className="col-group">
          <div className="col-6">
            <TextField
              disabled
              className={styles['form-input']}
              id="standard-disabled"
              InputLabelProps={{ shrink: true }}
              label="Curso:"
              defaultValue="Analise e desenvolvimento de Sistemas"
              margin="normal"
              fullWidth
            />
          </div>
          <div className="col-3">
            <TextField
              disabled
              className={styles['form-input']}
              id="standard-disabled"
              InputLabelProps={{ shrink: true }}
              label="Tipo"
              defaultValue="Bacharel"
              margin="normal"
            />
          </div>
          <div className="col-3">
            <TextField
              disabled
              className={styles['form-input']}
              id="standard-disabled"
              InputLabelProps={{ shrink: true }}
              label="Inicio"
              defaultValue="02/2018"
              margin="normal"
            />
          </div>
          <div className="col-2">
            <TextField
              disabled
              className={styles['form-input']}
              id="standard-disabled"
              label="Média de Notas"
              InputLabelProps={{ shrink: true }}
              value={this.state.alunos.mediaScore}
              margin="normal"
            />
          </div>
          <div className="col-2">
            <TextField
              disabled
              className={styles['form-input']}
              id="standard-disabled"
              InputLabelProps={{ shrink: true }}
              label="Frequência"
              value={this.state.alunos.frequency}
              margin="normal"
            />
          </div>
          <div className="col-2">
            <TextField
              disabled
              className={styles['form-input']}
              id="standard-disabled"
              InputLabelProps={{ shrink: true }}
              label="Distância Casa X Instituição"
              value={this.state.alunos.distancia}
              margin="normal"
            />
          </div>
          <div className="col-3">
            <TextField
              disabled
              className={styles['form-input']}
              id="standard-disabled"
              InputLabelProps={{ shrink: true }}
              label="Inadimplente"
              value={this.inadimplenteStatus()}
              margin="normal"
            />
          </div>
        </div>

        <div className={styles.aluno}>
          <div className={styles.Percent}>
            <p className={styles.Evasao}>Possibilidades de Evasão</p>
            <p className={styles.PossibilidadePorcentagem}>{this.state.alunos.evasionChance * 100}%</p>
          </div>
          <div className={styles.Percent}>
            <p className={styles.Evasao}>Motivo</p>
            <p className={styles.Possibilidade}>{this.loadReason()}</p>
          </div>
        </div>
      </div>
    )
  }
}

const mapStateToProps = state => {
  return {}
}

const mapDispatchToProps = dispatch => {
  return {
    setTitulo: titulo => {
      dispatch(HeaderService.setTitulo(titulo))
    }
  }
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(alunoPerfil)
