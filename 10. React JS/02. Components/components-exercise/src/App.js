import './App.css';
import { Calculator } from './components/Calculator';
import React from 'react';

function App() {
  const [numbers, setNumbers] = React.useState(0);

  return (
    <div className="site-wrapper">
      <input onChange={(e) => setNumbers(e.target.value)} placeholder='numbers' />
      <Calculator totalNumbers={numbers} />
    </div>
  );
}

export default App;
