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

        fetch('/squirrel/logging/count')
          .then(response => response.json())
          .then(count =>  this.setState({ count: count }))
          .catch(function (error) {  
                //console.log('Request failed', error);  
            });
    }

    handleErrorChanged(data){
        this.props.onErrorChanged(data);
    }

    handleClearClick() {
        fetch('/squirrel/logging/clear')
          .then(data =>  this.setState({ count: 0, currentIndex: 0 }))
          .then(() => this.handleErrorChanged(null))
          .catch(function (error) {  
                //console.log('Request failed', error);  
            });
    }

    handleNextClick() {
        if (this.state.currentIndex === this.state.count - 1)
            return;

        let newIndex = this.state.currentIndex + 1;
        this.setState({ currentIndex: newIndex })

        fetch('/squirrel/logging/get?index=' + newIndex)
          .then(response => response.json())
          .then(data => this.handleErrorChanged(data))
          .catch(function (error) {  
                //console.log('Request failed', error);  
            });
    }

    handlePreviousClick() {
        if (this.state.currentIndex === 0)
            return;

        let newIndex = this.state.currentIndex - 1;
        this.setState({ currentIndex: newIndex })

        fetch('/squirrel/logging/get?index=' + newIndex)
          .then(response => response.json())
          .then(data => this.handleErrorChanged(data))
          .catch(function (error) {  
                //console.log('Request failed', error);  
            });
    }

    render() {
        return (
            <div>
                <div>
                    <button onClick={this.handlePreviousClick}>Previous</button>
                    <button onClick={this.handleNextClick}>Next</button>
                    <button onClick={this.handleClearClick}>Clear</button>
                </div>
                <div>
                    <div>Error Count: {this.state.count}</div>
                    <div>Current Error Index: {this.state.currentIndex}</div>
                </div>
            </div>
        );
    }
}