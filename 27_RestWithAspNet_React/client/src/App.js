import React, { useState } from 'react';
import Header from './Header';



function App() {
  const [counter, setCounter] = useState(0);

  function increment(){
    setCounter(counter + 1);
  }

  return ( 
    <div>
      <Header>
        Counter: {counter}
      </Header>
      <button onClick={increment}>Add</button>
    </div>
   );
}

export default App;
