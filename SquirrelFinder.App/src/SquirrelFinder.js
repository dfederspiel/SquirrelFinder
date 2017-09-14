import React, { Component } from 'react';
import Entry from './Entry';
import Navigator from './Navigator';
import './SquirrelFinder.css';

class SquirrelFinder extends Component {

    constructor(props) {
      super(props);
      this.state = {
            data: null
        }

        this.handleErrorChanged = this.handleErrorChanged.bind(this);
    }

    handleErrorChanged(data) {
        this.setState({ data: data });
    }

    componentDidMount() {
        fetch('/squirrel/logging/get?index=0')
            .then(response => response.json())
            .then(data =>  this.setState({ data: data }))
            .catch(function (error) {  
                //console.log('Request failed', error);  
            });
    }

    render() {
        return (
            <div>
                <Navigator onErrorChanged={this.handleErrorChanged}/>
                <Entry data={this.state.data} />
            </div>
        );
    }
}

export default SquirrelFinder;
