import { useState } from 'react';
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
					</Router>
    </>
  )
}

export default App
