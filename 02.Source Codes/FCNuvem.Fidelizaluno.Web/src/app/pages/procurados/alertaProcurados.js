import estilos from '../alunos/buscaAlunos/busca.module.scss';

import React from 'react';
import PropTypes from 'prop-types';
import AppBar from '@material-ui/core/AppBar';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import Typography from '@material-ui/core/Typography';
import { HeaderService } from '../../services/index';
import { connect } from 'react-redux';
import defaultOptions from '../../config/fetchConfig';

const config = require('../../../config')

function TabContainer(props) {
    return (
        <Typography component="div" style={{ padding: 8 * 3 }}>
            {props.children}
        </Typography>
    );
}


TabContainer.propTypes = {
    children: PropTypes.node.isRequired,
};

const Bar = {
    boxShadow: 'none',
    color: '#000',
    backgroundColor: '#fff',
}

class alertaProcurados extends React.Component {
    state = {
        value: 0,
        procurados: []
    };

    componentDidMount() {
        fetch(`${config.react.api.baseUrl}${'/notification'}`, defaultOptions)
            .then(response => response.json())
            .then(procurados => {
                this.setState({ procurados: procurados })
            })
            .catch(err => console.error(err.toString()))

        fetch(`${config.react.api.baseUrl}${'/notification/deleteall'}`, {
            method: "POST",
            cache: 'no-cache',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({})
        }).then((response) => {
            this.setState({ open: true })
        })
        this.props.setTitulo("Alertas");
    }

    handleChange = (event, value) => {
        this.setState({ value });
    };

    render() {
        const { value } = this.state;

        return (
            <div className="wrapper">
                <AppBar position="static" style={Bar}>
                    <Tabs
                        value={value}
                        onChange={this.handleChange}
                        indicatorColor="primary"
                        textColor="primary"
                        variant="scrollable"
                        scrollButtons="auto"
                    >
                        <Tab label="Procurados" />
                        <Tab label="Crianças Desaparecidas" />
                    </Tabs>
                </AppBar>
                {value === 0 && <TabContainer><div className="table-responsive">
                    <table className="table" cellSpacing="0">
                        <thead>
                            <tr>
                                <td width="80"></td>
                                <td></td>
                                <td className="text-center">Data da Ocorrência</td>
                                <td className="text-center">Delito</td>
                                <td></td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.procurados.filter(q => q.reason !== "Desaparecido")
                                    .map((procurado) => (
                                        <tr>
                                            <td width="80">
                                                <img src={`https://fidelizablob.blob.core.windows.net/wanted/${procurado.personId}.png`} className={estilos.avatar} alt="Avatar" />
                                            </td>
                                            <td>
                                                {procurado.name}
                                            </td>
                                            <td className="text-center2">{new Date(procurado.data).toLocaleDateString()}</td>
                                            <td className="text-center">{procurado.reason}</td>
                                        </tr>
                                    ))
                            }
                        </tbody>
                    </table>
                </div></TabContainer>}
                {value === 1 && <TabContainer><div className="table-responsive">
                    <table className="table" cellSpacing="0">
                        <thead>
                            <tr>
                                <td width="80"></td>
                                <td></td>
                                <td className="text-center">Data da Ocorrência</td>
                                <td className="text-center">Região</td>
                                <td></td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.procurados.filter(q => q.reason === "Desaparecido")
                                    .map((procurado) => (
                                        <tr>
                                            <td width="80">
                                                <img src={`https://fidelizablob.blob.core.windows.net/wanted/${procurado.personId}.png`} className={estilos.avatar} alt="Avatar" />
                                            </td>
                                            <td>
                                                {procurado.name}
                                            </td>
                                            <td className="text-center2">{new Date(procurado.data).toLocaleDateString()}</td>
                                            <td className="text-center">{procurado.reason}</td>
                                        </tr>
                                    ))
                            }
                        </tbody>
                    </table>
                </div></TabContainer>}
            </div>
        );
    }
}

alertaProcurados.propTypes = {
    classes: PropTypes.object.isRequired,
};

const mapStateToProps = state => {
    return {
    }
};

const mapDispatchToProps = dispatch => {
    return {
        setTitulo: (titulo) => {
            dispatch(HeaderService.setTitulo(titulo))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(alertaProcurados);
