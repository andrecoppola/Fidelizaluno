import React, { Component } from 'react';
import ScrollableTabsButtonAuto from './percent';
import { HeaderService, painelService } from '../../services/index';
import { connect } from 'react-redux';

class Alertas extends Component {

    componentDidMount() {
        this.props.setTitulo("Possibilidade de Evasão");
    }

    render() {

        document.title = 'Painel - Fidelizaluno'
        return (
            <div className='wrapper'>
                <ScrollableTabsButtonAuto />
            </div>

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
        setTitulo: (titulo) => {
            dispatch(HeaderService.setTitulo(titulo))
        },
        setCampus: (event) => {
            dispatch(HeaderService.setCampus(event.target.value))
        },
        setEvasion: (program) => {
            dispatch(painelService.setEvasion(program))
        },
        setValue: (programValue) => {
            dispatch(painelService.setValue(programValue))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Alertas);
