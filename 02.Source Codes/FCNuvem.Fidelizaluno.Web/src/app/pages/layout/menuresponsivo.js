import React from 'react';
import PropTypes from 'prop-types';
import AppBar from '@material-ui/core/AppBar';
import CssBaseline from '@material-ui/core/CssBaseline';
import Drawer from '@material-ui/core/Drawer';
import Hidden from '@material-ui/core/Hidden';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import Toolbar from '@material-ui/core/Toolbar';
import { withStyles } from '@material-ui/core/styles';
import { Link } from 'react-router-dom';
import Header from './head';
import { getUser } from '../../config/adalConfig';
import logo from '../../assets/icons/logo_fidelizaluno.svg';
import siren from '../../assets/icons/Siren.svg';
import sirenDanger from '../../assets/icons/siren-danger.svg';
import NestedList from './NestedList'
import Styles from './menu.module.scss';

const config = require('../../../config')

const drawerWidth = 240;

const styles = theme => ({
    root: {
        display: 'flex',
        padding: 0,
    },
    drawer: {
        border: 'none',
        [theme.breakpoints.up('sm')]: {
            width: drawerWidth,
            flexShrink: 0,
        },
    },
    AppBar: {
        border: 'none',
        zIndex: 999,
        margin: '0px',
        boxShadow: 'none',
        color: '#000',
        backgroundColor: '#fff'
    },
    menuButton: {
        marginRight: 10,
        backgroundColor: '#d47a26',
        [theme.breakpoints.up('sm')]: {
            display: 'none',
        },
    },
    toolbar: theme.mixins.toolbar,
    drawerPaper: {
        borderColor: '#DEDEDE',
        width: drawerWidth,
        background: '#FAFAFA',
    },
    content: {
        flexGrow: 1,
        padding: theme.spacing.unit * 3,
    },
});


class Menu extends React.Component {


    constructor(props) {
        super(props);
        this.state = {
            time: Date.now(),
            mobileOpen: false,
            top: 0,
            quantidadeNotificacaoProcurado: 0,
            valor: '',
            campus: [],
            campusId: '',
            email: ''
        };
    }

    handleDrawerToggle = () => {
        this.setState(state => ({ mobileOpen: !state.mobileOpen }));
    };

    handleChange = event => {
        this.setState({ valor: event.target.value });
    };


    componentDidMount() {
        // this.interval = setInterval(() => this.verificaAtualizacao(), 1000);
        let user = getUser();
        this.setState({
            sirene: siren,
            headerClass: "header",
            name: user.profile.name,
            email: user.profile.email
        });
    }



    verificaAtualizacao() {
        fetch(`${config.react.api.baseUrl}${'/notification'}`)
            .then(response => response.json())
            .then(notificacoes => {
                if (notificacoes.length > 4) {
                    this.intervalAlert = setTimeout(() => this.animaAlerta(), 1500);
                }
                else {
                    clearTimeout(this.intervalAlert);
                    this.setState({ sirene: siren });
                }
            })
            .catch(err => console.error(this.props.url, err.toString()))
    }

    animaAlerta() {
        if (this.state.sirene === siren)
            this.setState({ sirene: sirenDanger });
        else
            this.setState({ sirene: siren });
    }


    componentWillUnmount() {
        clearInterval(this.interval);
    }

    render() {
        const { classes, theme } = this.props;

        const drawer = (
            <NestedList />
        );

        return (
            <div className={Styles.Body}>
                <CssBaseline />
                <AppBar position="fixed" className={this.state.headerClass}>
                    <Toolbar className={Styles.appBar}>
                        <Link to='/home'>
                            <img src={logo} className={Styles.logo2} alt="logo" />
                        </Link>
                        <Header />

                        <div className={Styles.procurados}>
                            <Link to='/procurados' onClick={this.refreshPage}>
                                <img color="red" src={this.state.sirene} alt="siren" />
                            </Link>
                        </div>
                        <div className={Styles.UserName}><i>{this.state.name}</i><br /><i>{this.state.email}</i></div>
                        <div className={Styles.dropdown}>
                            <div className={Styles.dropbtn}>
                                <i className="fa fa-user-circle" aria-hidden="true" />
                            </div>
                        </div>
                        <IconButton
                            color="inherit"
                            aria-label="Open drawer"
                            onClick={this.handleDrawerToggle}
                            className={classes.menuButton}
                        >
                            <MenuIcon />
                        </IconButton>
                    </Toolbar>
                </AppBar>
                <nav className={classes.drawer}>
                    <Hidden smUp implementation="css">
                        <Drawer
                            container={this.props.container}
                            variant="temporary"
                            anchor={theme.direction === 'rtl' ? 'right' : 'left'}
                            open={this.state.mobileOpen}
                            onClose={this.handleDrawerToggle}
                            classes={{
                                paper: classes.drawerPaper,
                            }}
                        >
                            {drawer}
                        </Drawer>
                    </Hidden>
                    <Hidden xsDown implementation="css">
                        <Drawer
                            classes={{
                                paper: classes.drawerPaper,
                            }}
                            variant="permanent"
                            open
                        >
                            {drawer}
                        </Drawer>
                    </Hidden>
                </nav>

            </div>
        );
    }
}

Menu.propTypes = {
    classes: PropTypes.object.isRequired,
    container: PropTypes.object,
    theme: PropTypes.object.isRequired,
};

export default withStyles(styles, { withTheme: true })(Menu);
