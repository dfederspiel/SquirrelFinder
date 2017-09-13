import React from 'react';
import ReactDOM from 'react-dom';
import SquirrelFinder from './SquirrelFinder';

class TestableSquirrelFinder extends SquirrelFinder {

}

it('renders without crashing', () => {
  const div = document.createElement('div');
  ReactDOM.render(<SquirrelFinder baseUrl="http://localhost:60876" />, div);
});

it('does something', () => {
  const sf = new SquirrelFinder();

});