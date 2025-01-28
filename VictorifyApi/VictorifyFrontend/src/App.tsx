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
import CreateLesson from './components/CreateLesson/CreateLesson';

function App() {

	const handleTeacherFormData = (data: any) => {
		const requestOptions = {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify(data),
		};
		fetch('https://localhost:8081/api/Teachers', requestOptions).then(
			(response) => response.json()
		);
	};

	const handleStudentFormData = (data: any) => {
		const requestOptions = {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify(data),
		};
		fetch('https://localhost:8081/api/Students', requestOptions).then(
			(response) => response.json()
		);
	};

	const handleLessonFormData = (data: any) => {
		const requestOptions = {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify(data),
		};
		fetch('https://localhost:8081/api/Lessons', requestOptions).then(
			(response) => response.json()
		);
	};


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
									<Route path='/student' element={<CreateStudent sendFormData={handleStudentFormData}/>}></Route>
									<Route path='/teacher' element={<CreateTeacher sendFormData={handleTeacherFormData}/>}></Route>
									<Route path='/lesson' element={<CreateLesson sendFormData={handleLessonFormData}/>}></Route>

								</Routes>
							</div>
						</div>
					</Router>
    </>
  )
}

export default App
