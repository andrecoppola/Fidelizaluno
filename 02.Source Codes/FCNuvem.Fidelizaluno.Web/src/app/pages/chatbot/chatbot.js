import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Modal from '@material-ui/core/Modal';
import estilos from './chatBot.module.scss'
import bot from '../../assets/icons/bt-chatbot.svg';
import { DirectLine } from 'botframework-directlinejs';
import ReactWebChat from 'botframework-webchat';

import Logo from '../../assets/icons/logo-fidelizaluno-login.svg';
import { createStyleSet } from 'botframework-webchat-component';

const styleSet = createStyleSet({});

styleSet.uploadButton = {
    ...styleSet.uploadButton,
    display: 'none'
};

const styles = theme => ({
    paper: {
        width: theme.spacing.unit * 50,
        backgroundColor: theme.palette.background.paper,
        boxShadow: theme.shadows[5],
        padding: theme.spacing.unit * 4,
        outline: 'none',
    },
});


class SimpleModal extends React.Component {
    constructor(props) {
        super(props);

        this.directLine = new DirectLine({ token: 't5XYXbfifcA.wrtLwgAFPfIkrlycO_iyzBVTsZ66kQpvPOHl1Td0ozc' });
    }

    state = {
        open: false,
    };

    handleOpen = () => {
        this.setState({ open: true });
    };

    handleClose = () => {
        this.setState({ open: false });
    };

    render() {

        return (
            <div className={estilos.bot}>
                <img className={estilos.btn} src={bot} alt="chatBot" onClick={this.handleOpen} />
                <Modal
                    aria-labelledby="simple-modal-title"
                    aria-describedby="simple-modal-description"
                    open={this.state.open}
                    onClose={this.handleClose}
                >
                    <div className={estilos.modalBot}>
                        <img src={Logo} alt="logo" className={estilos.logoChat} />
                        <div className={estilos.botDiv}>
                            <ReactWebChat directLine={this.directLine} styleSet={styleSet} />
                        </div>
                    </div>
                </Modal>
            </div>
        );
    }
}

SimpleModal.propTypes = {
    classes: PropTypes.object.isRequired,
};

// We need an intermediary variable for handling the recursive nesting.
const SimpleModalWrapped = withStyles(styles)(SimpleModal);

export default SimpleModalWrapped;