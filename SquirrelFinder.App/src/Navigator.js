import React, { Component } from 'react';

export default class Navigator extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isToggleOn: true,
            currentIndex: 0,
            count: 0,
            
        };

        this.handlePreviousClick = this.handlePreviousClick.bind(this);
        this.handleNextClick = this.handleNextClick.bind(this);
        this.handleClearClick = this.handleClearClick.bind(this);

        fetch(this._baseUrl + '/squirrel/logging/count')
          .then(response => response.json())
          .then(count =>  this.setState({ count: count }));
    }

    handleErrorChanged(data){
        this.props.onErrorChanged(data);
    }

    handleClearClick() {
        fetch(this._baseUrl + '/squirrel/logging/clear')
          .then(data =>  this.setState({ count: 0, currentIndex: 0 }))
          .then(() => this.handleErrorChanged(null));
    }

    handleNextClick() {
        if (this.state.currentIndex === this.state.count - 1)
            return;

        this.setState({ currentIndex: this.state.currentIndex + 1 })

        fetch(this._baseUrl + '/squirrel/logging/get?index=' + this.state.currentIndex)
          .then(response => response.json())
          .then(data => this.handleErrorChanged(data));
    }

    handlePreviousClick() {
        if (this.state.currentIndex === 0)
            return;

        this.setState({ currentIndex: this.state.currentIndex - 1 })

        fetch(this._baseUrl + '/squirrel/logging/get?index=' + this.state.currentIndex)
          .then(response => response.json())
          .then(data => this.handleErrorChanged(data));
    }

    render() {
        return (
            <div>
                <button onClick={this.handlePreviousClick}>Previous</button>
                <button onClick={this.handleNextClick}>Next</button>
                <button onClick={this.handleClearClick}>Clear</button>
                <div>{this.props.count}</div>
            </div>
        );
    }
}