import { useState } from 'react';
import {
	Link
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

	*/

    return (
        <>
						<Link to='/'><button className={styles.button}>SEND</button></Link>
        </>
    );
}

export default CreateLesson;
