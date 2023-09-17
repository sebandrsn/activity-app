import React from 'react';
import './stylesheets/main.css'
import { Home } from './pages/Home';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import HikingTrail from './pages/HikingTrail';
import NotFound from './pages/NotFound';
import Header from './components/Header';

function App() {
  return (
    <BrowserRouter>
    <Header />
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/hikingtrail/:id' element={<HikingTrail />} />
        <Route path='*' element={<NotFound />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
