import React, { Component } from 'react';
import './SquirrelFinder.css';

class Entry extends Component {
    render() {

        if(!this.props.data) return <div></div>;

        const entry = this.props.data;
        function getStack(stack) {
            return stack.map((line, idx) => (<li className="stack-info" key={idx }><i>{line}</i></li>));
        }

        return (
             <div className="log-entry" key={entry.LogEntry.activityId }>
                <h2>{entry.LogEntry.title}</h2>
                <ul>
                    <li>HandlingInstanceId: {entry.HandlingInstanceId}</li>
                    <li>Type: {entry.Type}</li>
                    <li>Message: {entry.Message}</li>
                    <li>Source: {entry.Source}</li>
                    <li>WebEventCode: {entry.WebEventCode}</li>
                    <li>ErrorCode: {entry.ErrorCode}</li>
                    <li>Data: {entry.Data}</li>
                    <li>TargetSite: {entry.TargetSite}</li>
                    <li>
                        StackTrace:
                        <ul>
                            {getStack(entry.StackTrace)}
                        </ul>
                    </li>
                    <li>MachineName: {entry.MachineName}</li>
                    <li>RequestedUrl: <a href={entry.RequestedUrl}>{entry.RequestedUrl}</a></li>
                </ul>
                <pre>{entry.LogEntry.message}</pre>
                <pre>{entry.CallStack}</pre>
             </div>
        );
    }
}

class Navigator extends Component {
    constructor(props) {
        super(props);
        this.state = {isToggleOn: true};

        // This binding is necessary to make `this` work in the callback
        this.handlePreviousClick = this.handlePreviousClick.bind(this);
        this.handleNextClick = this.handleNextClick.bind(this);
        this.handleClearClick = this.handleClearClick.bind(this);
    }
    handlePreviousClick(e) {
        this.props.onPreviousClick();
    }

    handleNextClick(e) {
        this.props.onNextClick();
    }

    handleClearClick(e) {
        this.props.onClearClick();
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

class SquirrelFinder extends Component {

    constructor() {
      super();
      this.state = {
            data: null,
            currentIndex: 0,
            count: 0
        }

        this.handleClearClick = this.handleClearClick.bind(this);
        this.handleNextClick = this.handleNextClick.bind(this);
        this.handlePreviousClick = this.handlePreviousClick.bind(this);
    }

    handleClearClick() {
        fetch('/squirrel/logging/clear')
          .then(data =>  this.setState({ data: null, count: 0, currentIndex: 0 }));
    }

    handleNextClick() {
        if (this.state.currentIndex === this.state.count - 1)
            return;

        this.setState({ currentIndex: this.state.currentIndex + 1 })

        fetch('/squirrel/logging/get?index=' + this.state.currentIndex)
          .then(response => response.json())
          .then(data =>  this.setState({ data: data }));
    }

    handlePreviousClick() {
        if (this.state.currentIndex === 0)
            return;

        this.setState({ currentIndex: this.state.currentIndex - 1 })

        fetch('/squirrel/logging/get?index=' + this.state.currentIndex)
          .then(response => response.json())
          .then(data =>  this.setState({ data: data }));
    }

    componentDidMount() {
        fetch('/squirrel/logging/get?index=0')
          .then(response => response.json())
          .then(data =>  this.setState({ data: data }));

        fetch('/squirrel/logging/count')
          .then(response => response.json())
          .then(data =>  this.setState({ count: data }));
    }

    render() {
        return (
            <div>
                <Navigator count={this.state.count}
                           onClearClick={this.handleClearClick} 
                           onPreviousClick={this.handlePreviousClick} 
                           onNextClick={this.handleNextClick}/>
                <Entry data={this.state.data} />
            </div>
        );
    }
}

export default SquirrelFinder;
