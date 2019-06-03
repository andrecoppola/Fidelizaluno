import React, { Component } from 'react';
import Menu from './menuresponsivo';
import SimpleModalWrapped from '../chatbot/chatbot';



class Layout extends Component {

    render() {
        const { children } = this.props;
        return (
            <div>
                <SimpleModalWrapped/>
                <Menu />
                <section>
                    {children}
                </section>
            </div>
        );
    }
}

export default Layout;