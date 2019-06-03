import React from 'react';
import PropTypes from 'prop-types';
import AppBar from '@material-ui/core/AppBar';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import Typography from '@material-ui/core/Typography';
import Badge from '@material-ui/core/Badge';
import Expandido from './expansion';
import Styles from './painel.module.scss';
import { connect } from 'react-redux';
import { HeaderService, painelService } from '../../services/index';
import defaultOptions from '../../config/fetchConfig';

const config = require('../../../config')

function TabContainer(props) {
    return (
        <Typography component="div">
            {props.children}
        </Typography>
    );
}

TabContainer.propTypes = {
    children: PropTypes.node.isRequired,
};


const Percent = {
    boxShadow: 'none',
    color: '#000',
    backgroundColor: '#fff',
    marginTop: '45px',
}

const button = {
    borderRadius: '0px',
    boxShadow: '0px 0px 10px 0px #ccc',
    margin: '1%',
    height: '130px',
    minWidth: '110px',
    position: 'center',
    backgroundColor: '#F93131',
}

const button1 = {
    borderRadius: '0px',
    boxShadow: '0px 0px 10px 0px #ccc',
    margin: '1%',
    height: '130px',
    minWidth: '110px',
    position: 'center',
    backgroundColor: '#FF7979',
}

const button2 = {
    borderRadius: '0px',
    boxShadow: '0px 0px 10px 0px #ccc',
    margin: '1%',
    height: '130px',
    minWidth: '110px',
    position: 'center',
    backgroundColor: '#FFBE72',
}
const button3 = {
    borderRadius: '0px',
    boxShadow: '0px 0px 10px 0px #ccc',
    margin: '1%',
    height: '130px',
    minWidth: '110px',
    position: 'center',
    backgroundColor: '#FFD15C',
}
const button4 = {
    borderRadius: '0px',
    boxShadow: '0px 0px 10px 0px #ccc',
    margin: '1%',
    height: '130px',
    minWidth: '110px',
    position: 'center',
    backgroundColor: '#FFD15C',
}




class ScrollableTabsButtonForce extends React.Component {

    state = {
        value: 0,
        cursos: this.props,
        amount1: '',
        amount2: '',
        amount3: '',
        amount4: '',
        amount5: ''
    }

    handleChange = (event, value) => {
        this.setState({ value });
    };



    componentDidMount() {
        this.loadAmount()
        this.props.setEvasion(this.props.programValue, this.props.idcampus);
    }

    loadAmount() {
        fetch(`${config.react.api.baseUrl}${'/evasion/Amount/80/100?idCampus='}${this.props.idcampus}`, defaultOptions)
            .then(response => response.json())
            .then(response => {
                this.setState({
                    amount1: response.amount || 0
                })
            })
        fetch(`${config.react.api.baseUrl}${'/evasion/Amount/60/80?idCampus='}${this.props.idcampus}`, defaultOptions)
            .then(response => response.json())
            .then(response => {
                this.setState({
                    amount2: response.amount || 0
                })
            })
        fetch(`${config.react.api.baseUrl}${'/evasion/Amount/40/60?idCampus='}${this.props.idcampus}`, defaultOptions)
            .then(response => response.json())
            .then(response => {
                this.setState({
                    amount3: response.amount || 0
                })
            })
        fetch(`${config.react.api.baseUrl}${'/evasion/Amount/20/40?idCampus='}${this.props.idcampus}`, defaultOptions)
            .then(response => response.json())
            .then(response => {
                this.setState({
                    amount4: response.amount || 0
                })
            })
        fetch(`${config.react.api.baseUrl}${'/evasion/Amount/0/20?idCampus='}${this.props.idcampus}`, defaultOptions)
            .then(response => response.json())
            .then(response => {
                this.setState({
                    amount5: response.amount || 0
                })
            })
    }

    render() {
        const { value } = this.state;
        console.log(this.props.idcampus);
        

        return (
            <div >

                <AppBar position="static" style={Percent}>
                    <Tabs
                        value={value}
                        onChange={this.handleChange}
                        variant="scrollable"
                        scrollButtons="on"
                        indicatorColor="primary"
                        textColor="primary"
                        fullWidth
                    >
                        <Tab style={button} onClick={() =>
                            this.props.setEvasion('80/100', this.props.idcampus) & this.loadAmount()}
                            icon={<div><p className={Styles.Number}>100-80%</p></div>} />
                        <Badge className={Styles.badge} badgeContent={this.state.amount1}
                            color="primary"></Badge>
                        <Tab style={button1} onClick={() =>
                            this.props.setEvasion('60/80', this.props.idcampus) & this.loadAmount()}
                            icon={<div><p className={Styles.Number}>80-60%</p></div>} />
                        <Badge className={Styles.badge} badgeContent={this.state.amount2}
                            color="primary"></Badge>
                        <Tab style={button2} onClick={() =>
                            this.props.setEvasion('40/60', this.props.idcampus) & this.loadAmount()}
                            icon={<div><p className={Styles.Number}>60-40%</p></div>} />
                        <Badge className={Styles.badge} badgeContent={this.state.amount3}
                            color="primary"></Badge>
                        <Tab style={button3} onClick={() =>
                            this.props.setEvasion('20/40', this.props.idcampus) & this.loadAmount()}
                            icon={<div><p className={Styles.Number}>40-20%</p></div>} />
                        <Badge className={Styles.badge} badgeContent={this.state.amount4}
                            color="primary"></Badge>
                        <Tab style={button4} onClick={() =>
                            this.props.setEvasion('0/20', this.props.idcampus) & this.loadAmount()}
                            icon={<div><p className={Styles.Number}>20-00%</p></div>} />
                        <Badge className={Styles.badge} badgeContent={this.state.amount5}
                            color="primary"></Badge>
                    </Tabs>
                </AppBar>
                {value === 0 && <TabContainer><Expandido /></TabContainer>}
                {value === 2 && <TabContainer><Expandido /></TabContainer>}
                {value === 4 && <TabContainer><Expandido /></TabContainer>}
                {value === 6 && <TabContainer><Expandido /></TabContainer>}
                {value === 8 && <TabContainer><Expandido /></TabContainer>}
            </div>
        );
    }
}

ScrollableTabsButtonForce.propTypes = {
    classes: PropTypes.object.isRequired,
};

const mapStateToProps = state => {
    return {
        idcampus: state.headerReducer.idcampus,
        listProgram: state.painelReducer.listProgram,
        programValue: state.painelReducer.programValue,
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
        setEvasion: (programValue, idcampus) => {
            dispatch(painelService.setEvasion(programValue, idcampus))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ScrollableTabsButtonForce);
