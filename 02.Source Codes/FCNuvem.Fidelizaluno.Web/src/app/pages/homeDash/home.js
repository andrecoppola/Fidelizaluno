import React, { Component } from 'react';
import Report from 'powerbi-report-component';
import { HeaderService } from '../../services/index';
import { connect } from 'react-redux';
import defaultOptions from '../../config/fetchConfig';

const config = require('../../../config')

class Home extends Component {
    state = {
        accessToken: '',
        embedUrl: '',
        embedId: '',
    };

    style = {
        height: '800px'
    }
    settings = {
        filterPaneEnabled: false,
        navContentPaneEnabled: false
    }


    getToken() {
        return fetch(`${config.react.api.baseUrl}${'/embedded'}`, defaultOptions)
            .then(response => response.json())
            .then(response => {
                this.setState({
                    accessToken: response.embedToken.token,
                    embedUrl: response.embedUrl,
                    embedId: response.id,
                    isLoaded: true
                })
            })
    }


    componentDidMount() {
        this.getToken()
        this.props.setTitulo("Pagina Inicial");
    }

    render() {
        const isLoaded = this.state.isLoaded;
        let report;

        if (isLoaded) {

            report = <Report
                embedType="report"
                tokenType="Embed"
                accessToken={this.state.accessToken}
                embedUrl={this.state.embedUrl}
                embedId={this.state.embedId}
                permissions="All"
                style={this.style}
                extraSettings={this.settings}
            />;
        }


        document.title = 'Página Inicial - Fidelizaluno'
        return (
            <div className='wrapper'>
                {report}
            </div>
        );
    }
}

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

export default connect(mapStateToProps, mapDispatchToProps)(Home);
