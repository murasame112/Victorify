import { useState } from 'react';
import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';
import LandingPage from './components/LandingPage/LandingPage';
import {
	BrowserRouter as Router,
	Routes,
	Route,
	Link,
	Navigate,
	useLocation
} from 'react-router';


function App() {

  return (
    <>
					<Router>
						<div className='content'>
							 <Routes>
							 <Route path='/' element={<LandingPage/>}></Route>
									<Route
											path='*'
											element={<Navigate to='/' replace />}
									></Route>
							</Routes> 
						</div>
						<Footer/>
					</Router>
    </>
  )
}

export default App
