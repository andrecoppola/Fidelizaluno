import React, { Component } from "react";
import Styles from './menu.module.scss';
import { connect } from 'react-redux';
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';
import { HeaderService } from '../../services/index';

class Header extends Component {

  state = {
    valor: ''
  }

  componentDidMount() {
    this.props.campusList();
  }

  handleChange = event => {
  };

  render() {
    const pathName = this.props.titulo;


    return (
      <div>
        <div className={Styles.Unidade}>
          <TextField
            select={true}
            id="searchUnidade"
            label="Unidade"
            type="search"
            margin="normal"
            fullWidth
            onChange={this.props.setCampus}
            value={this.props.valor}
            InputLabelProps={{ shrink: true }}
          >
            {this.props.campus.map(campus =>
              <MenuItem key={campus.id} value={campus.id}>{campus.name}
              </MenuItem>
            )}
          </TextField>
        </div>
        <div className={Styles.headerName}>
          <h1>{pathName}</h1>
        </div>

      </div>
    );
  }
}

const mapStateToProps = state => {
  return {
    titulo: state.headerReducer.titulo,
    campus: state.headerReducer.campus,
    valor: state.headerReducer.idcampus
  }
};

const mapDispatchToProps = dispatch => {
  return {
    campusList: () => {
      dispatch(HeaderService.campusList())
    },
    setCampus: (event) => {
      dispatch(HeaderService.setCampus(event.target.value))
    }
  }
}

const TimelineContainer = connect(mapStateToProps, mapDispatchToProps)(Header);

export default TimelineContainer;
