import { useState, useEffect } from 'react';
import {
	Link,
	useParams
} from 'react-router';

// ===== styles =====
import stylesDefault from '../../index.css';
import styles from './CreateLesson.module.css';

function CreateLesson() {

	/*
================== Lesson model ==================
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Current { get; set; } // if lesson happend
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; } 
        public Student Student { get; set; }
============================================

- pobrac nauczycieli (lista do selectbox)
- pobrac studentow (lista do selectbox)
- datepicker (od dzisiejszej w przód)
- current domyslnie na false

                    <Route
                        path='/strategy/:id'
                        element={<StratSingle />}
                    ></Route>
	*/

	const [data, setData] = useState<any>([]);
	//const { id } = useParams();

	// useEffect(() => {
	// 		fetch('http://localhost:4200/strategy/' + id)
	// 				.then((response) => response.json())
	// 				.then((data) => {
	// 						setData(data);
	// 				})
	// 				.catch((error) => console.log(error));
	// }, []);

	useEffect(() => {
		fetch('http://localhost:8081/api/Teachers')
				.then((response) => response.json())
				.then((data) => {
						setData(data);
				})
				.catch((error) => console.log(error));
	}, []);


	if(data){
    return (
			<>
					<Link to='/'><button className={styles.button}>SEND</button></Link>
			</>
		);
	} else {
		return <div>redirect!!!</div>; // TODO: redirect
	}

}

export default CreateLesson;
