import { useState } from 'react';
import {
	BrowserRouter as Router,
	Routes,
	Route,
	Link,
	Navigate,
	useLocation
} from 'react-router';

// ===== components =====
import LandingPage from './components/LandingPage/LandingPage';
import CreateStudent from './components/CreateStudent/CreateStudent';
import CreateTeacher from './components/CreateTeacher/CreateTeacher';

function App() {

  return (
    <>
					<Router>
						<div className='content'>
							<div className='box'>
							 	<Routes>
							 	<Route path='/' element={<LandingPage/>}></Route>
									<Route
											path='*'
											element={<Navigate to='/' replace />}
									></Route>
									<Route path='/student' element={<CreateStudent/>}></Route>
									<Route path='/teacher' element={<CreateTeacher/>}></Route>

								</Routes>
							</div>
						</div>
					</Router>
    </>
  )
}

export default App
