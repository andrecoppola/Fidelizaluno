import React from 'react';
import {connect} from 'react-redux';

class ControlePresenca extends React.Component {
    
    render() {
        document.title = 'Controle de Presença - Fidelizaluno'
        window.location.href = 'https://web.powerapps.com/webplayer/app?source=portal&screenColor=rgba(251%2c+101%2c+60%2c+1)&appId=%2fproviders%2fMicrosoft.PowerApps%2fapps%2fe59171dd-146b-460f-8683-695833a5eca5&environment-name=Default-6e68e6a6-4d6b-4505-9622-fddaf8cfc755'

        return (
            <div>
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
    }
  }
  
  const TimelineContainer = connect(mapStateToProps,mapDispatchToProps)(ControlePresenca);

export default TimelineContainer;