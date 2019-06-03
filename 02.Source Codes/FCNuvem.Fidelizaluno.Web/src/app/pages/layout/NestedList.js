import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import ListSubheader from '@material-ui/core/ListSubheader';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import Divider from '@material-ui/core/Divider';
import Tooltip from '@material-ui/core/Tooltip';
import  defaultOptions from '../../config/fetchConfig'
import { connect } from 'react-redux';
import { HeaderService } from '../../services/index';

import Styles from './menu.module.scss';

//Icones em svg
import logo from '../../assets/icons/logo-menu-nome.svg';
import logoFooter from '../../assets/icons/logo-fideliza-laranja.svg';
import oneNoteIcon from '../../assets/icons/onenote50x50.png';
import teamsIcon from '../../assets/icons/teams50x50.png';

const config = require('../../../config');

class NestedList extends Component {
    state = {
        quantidadeCurso100: 0
    }

    loadCurso100() {
        return fetch(`${config.react.api.baseUrl}${'/evasion/Amount/80/100?idCampus='}${this.props.idcampus}`, defaultOptions)
            .then(response => response.json())
            .then(response => {
                this.setState({
                    quantidadeCurso100: response.amount || 0
                })
            })
    }

    componentDidMount() {
        this.loadCurso100();
    }



    render() {
        return (

            <List
                component="nav"
                subheader={<ListSubheader className={Styles.cadastro} component="div"></ListSubheader>}>
                <ListItem>
                    <Link to='/home'>
                        <img src={logo} className={Styles.logo} alt="logo" />
                    </Link>
                </ListItem>
                <Link to="/home">
                    <ListItem button>
                        <ListItemIcon>
                            <i className="fa fa-2x fa-home" aria-hidden="true" />
                        </ListItemIcon>
                        <i>Página Inicial</i>
                    </ListItem>
                </Link>
                <Link to="/buscaAlunos">
                    <ListItem button>
                        <ListItemIcon>
                            <i className="fa fa-2x fa-graduation-cap" aria-hidden="true" />
                        </ListItemIcon>
                        <i>Alunos</i>
                    </ListItem>
                </Link>
                <Link to="/controleDePresenca">
                    <ListItem button>
                        <ListItemIcon>
                            <i className="fa fa-2x fa-tasks" aria-hidden="true" />
                        </ListItemIcon>
                        <i>Presença</i>
                    </ListItem>
                </Link>
                <Link to='/painel' >
                    <ListItem button>
                        <ListItemIcon>
                            <i className="fas fa-flag fa-fw" />
                        </ListItemIcon>
                        <i>Evasão <i className={Styles.evasao}>{this.state.quantidadeCurso100}</i></i>
                    </ListItem>
                </Link>
                <Link to="/alunosAusentes">
                    <ListItem button>
                        <ListItemIcon>
                            <i className="fa fa-2x fa-user-alt-slash" aria-hidden="true" />
                        </ListItemIcon>
                        <i>Alunos Ausentes</i>
                    </ListItem>
                </Link>
                <footer>
                    <div className={Styles.officeBtn}>
                        <div className={Styles.abrir}><p>Ir para:</p></div>
                        <a target="_blank" rel="noopener noreferrer" href="https://www.onenote.com/signin?wdorigin=ondcnotebooks&showHrd=true">
                            <Tooltip title="One Note" placement="top">
                                <img className={Styles.footerIcons} src={oneNoteIcon} alt="oneNote" />
                            </Tooltip>
                        </a>
                        <a target="_blank" rel="noopener noreferrer" href="https://teams.microsoft.com/_#/?lm=deeplink&lmsrc=officeWaffle">
                            <Tooltip title="Teams" placement="top">
                                <img className={Styles.footerIcons} src={teamsIcon} alt="teams" />
                            </Tooltip>
                        </a>
                    </div>
                    <div className={Styles.logoFooter}>
                        <img src={logoFooter} alt="footer" />
                    </div>
                </footer>

            </List >
        );
    }
}

const mapStateToProps = state => {
  return {
      idcampus: state.headerReducer.idcampus
  }
};

const mapDispatchToProps = dispatch => {
  return {
      setCampus: (event) => {
          dispatch(HeaderService.setCampus(event.target.value))
      }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(NestedList);