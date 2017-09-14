import React, { Component } from 'react';

export default class Entry extends Component {
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