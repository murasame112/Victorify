import { useState, useEffect } from 'react';
import { Link, useParams } from 'react-router';

// ===== styles =====
import stylesDefault from '../../index.css';
import styles from './CreateLesson.module.css';

function CreateLesson({ sendFormData }: any) {
    const [teachers, setTeachers] = useState<any[]>([]);
    const [students, setStudents] = useState<any[]>([]);
    const [minDate, setMinDate] = useState<string>('');
    const [maxDate, setMaxDate] = useState<string>('');
    const [teacherId, setTeacher] = useState<number>(0);
    const [studentId, setStudent] = useState<number>(0);
    const [date, setDate] = useState<Date>(new Date());
		const [studentFlag, setStudentFlag] = useState<boolean>(false);
		const [teacherFlag, setTeacherFlag] = useState<boolean>(false);
		const [buttonState, setButtonState] = useState<boolean>(false);

    const updateTeachers = () => {
        let t: any[] = [
            {
                id: 77,
                name: 'Adam',
                surname: 'Mickiewicz',
                nickname: 'amick',
                email: 'amickiewicz@example.com',
                hourlyRate: 45,
                lessons: null,
            },
            {
                id: 78,
                name: 'Maria',
                surname: 'Konopnicka',
                nickname: 'mkonop',
                email: 'mkonopnicka@example.com',
                hourlyRate: 50,
                lessons: null,
            },
            {
                id: 79,
                name: 'Henryk',
                surname: 'Sienkiewicz',
                nickname: 'hsienk',
                email: 'hsienkiewicz@example.com',
                hourlyRate: 60,
                lessons: null,
            },
            {
                id: 80,
                name: 'Juliusz',
                surname: 'Słowacki',
                nickname: 'jslow',
                email: 'jslowacki@example.com',
                hourlyRate: 55,
                lessons: null,
            },
            {
                id: 81,
                name: 'Eliza',
                surname: 'Orzeszkowa',
                nickname: 'eorzesz',
                email: 'eorzeszkowa@example.com',
                hourlyRate: 40,
                lessons: null,
            },
            {
                id: 82,
                name: 'Stanisław',
                surname: 'Wyspiański',
                nickname: 'swysp',
                email: 'swyspianski@example.com',
                hourlyRate: 65,
                lessons: null,
            },
            {
                id: 83,
                name: 'Zofia',
                surname: 'Nałkowska',
                nickname: 'znalk',
                email: 'znalkowska@example.com',
                hourlyRate: 50,
                lessons: null,
            },
            {
                id: 84,
                name: 'Władysław',
                surname: 'Reymont',
                nickname: 'wreym',
                email: 'wreymont@example.com',
                hourlyRate: 70,
                lessons: null,
            },
            {
                id: 85,
                name: 'Jan',
                surname: 'Kochanowski',
                nickname: 'jkochan',
                email: 'jkochanowski@example.com',
                hourlyRate: 35,
                lessons: null,
            },
            {
                id: 86,
                name: 'Stefan',
                surname: 'Żeromski',
                nickname: 'szerom',
                email: 'szeromski@example.com',
                hourlyRate: 45,
                lessons: null,
            },
        ];
        setTeachers(t);
    };

    const updateStudents = () => {
        let s: any[] = [
            {
                id: 11,
                name: 'Jan',
                surname: 'Matejko',
                nickname: 'jmatej',
                email: 'jmatejko@example.com',
                lessons: null,
            },
            {
                id: 12,
                name: 'Fryderyk',
                surname: 'Chopin',
                nickname: 'fchopin',
                email: 'fchopin@example.com',
                lessons: null,
            },
            {
                id: 13,
                name: 'Stanisław',
                surname: 'Moniuszko',
                nickname: 'smoniusz',
                email: 'smoniuszko@example.com',
                lessons: null,
            },
            {
                id: 14,
                name: 'Witkacy',
                surname: 'Witkiewicz',
                nickname: 'wwitkiew',
                email: 'wwitkiewicz@example.com',
                lessons: null,
            },
            {
                id: 15,
                name: 'Artur',
                surname: 'Grottger',
                nickname: 'agrott',
                email: 'agrottger@example.com',
                lessons: null,
            },
            {
                id: 16,
                name: 'Ignacy',
                surname: 'Paderewski',
                nickname: 'ipaderew',
                email: 'ipaderewski@example.com',
                lessons: null,
            },
            {
                id: 17,
                name: 'Jacek',
                surname: 'Malczewski',
                nickname: 'jmalcz',
                email: 'jmalczewski@example.com',
                lessons: null,
            },
            {
                id: 18,
                name: 'Wojciech',
                surname: 'Kossak',
                nickname: 'wkossak',
                email: 'wkossak@example.com',
                lessons: null,
            },
            {
                id: 19,
                name: 'Zygmunt',
                surname: 'Noskowski',
                nickname: 'znoskow',
                email: 'znoskowski@example.com',
                lessons: null,
            },
            {
                id: 20,
                name: 'Józef',
                surname: 'Czapski',
                nickname: 'jczapski',
                email: 'jczapski@example.com',
                lessons: null,
            },
        ];
        setStudents(s);
    };

    const updateTeacher = (event: any) => {
        setTeacher(event.target.value);
				setTeacherFlag(true);
				if(studentFlag){
					setButtonState(true);
				}
    };

    const updateStudent = (event: any) => {
        setStudent(Number(event.target.value));
				setStudentFlag(true);
				if(teacherFlag){
					setButtonState(true);
				}
    };

    const updateDate = (event: any) => {
        setDate(new Date(event.target.any));
    };

    const setTodayAsMin = () => {
        setMinDate(new Date().toISOString().split('T')[0]);
    };

    const setTodaysMax = () => {
        let max = new Date();
        max.setFullYear(max.getFullYear() + 1);
        setMaxDate(max.toISOString().split('T')[0]);
    };

    useEffect(() => {
        updateTeachers();
        updateStudents();
        setTodayAsMin();
        setTodaysMax();
    }, []);

    const getNames = function (X: any) {
        return (
            <option key={X.id} value={X.id}>
                {X.name} {X.surname}
            </option>
        );
    };

    const submitForm = () => {
        const data: any = {
            teacherId: teacherId,
            studentId: studentId,
            date: date,
            current: false,
        };
        sendFormData(data);
    };

    const cl = () => {
        const data: any = {
            teacherId: teacherId,
            studentId: studentId,
            date: date,
            current: false,
        };
        console.log(data);
    };

    return (
        <>
            <div className={styles.form}>
                <div>
                    <p>Choose a teacher:</p>
                    <select
                        className={styles.select}
                        value={teacherId}
                        onChange={updateTeacher}
                    >
                        <option value={0} disabled>
                            -- Select a teacher --
                        </option>
                        {teachers.map(getNames)}
                    </select>
                </div>
                <div>
                    <p>Choose a student:</p>
                    <select
                        className={styles.select}
                        value={studentId}
                        onChange={updateStudent}
                    >
                        <option value={0} disabled>
                            -- Select a student --
                        </option>
                        {students.map(getNames)}
                    </select>
                </div>
                <div>
                    <p>Date:</p>
                    <input
                        className={styles.input}
                        type='date'
                        id='date'
                        name='trip-start'
                        defaultValue={minDate}
                        min={minDate}
                        max={maxDate}
                        onChange={updateDate}
                    />
                </div>
            </div>
            <Link to='/'>
                <button onClick={submitForm} className={styles.button} disabled={!buttonState}>
                    SEND
                </button>
            </Link>
        </>
    );
}

export default CreateLesson;
