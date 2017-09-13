import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import SquirrelFinder from './SquirrelFinder';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<SquirrelFinder />, document.getElementById('root'));
registerServiceWorker();
