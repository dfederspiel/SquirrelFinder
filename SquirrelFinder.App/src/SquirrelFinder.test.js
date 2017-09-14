import React from 'react';
import ReactDOM from 'react-dom';

import SquirrelFinder from './SquirrelFinder';


it('renders without crashing', () => {
  const div = document.createElement('div');
  ReactDOM.render(<SquirrelFinder />, div);
});