import { useState } from 'react';
import {
	Link
} from 'react-router';
// ===== styles =====
import stylesDefault from '../../index.css';
import styles from './CreateStudent.module.css';

function CreateStudent({ sendFormData }: any) {
	const [name, setName] = useState<string>('');
	const [surname, setSurname] = useState<string>('');
	const [nickname, setNickname] = useState<string>('');
	const [email, setEmail] = useState<string>('');

	const updateName = (event: any) => {
		setName(event.target.value);
	};

	const updateSurname = (event: any) => {
		setSurname(event.target.value);
	};

	const updateNickname = (event: any) => {
		setNickname(event.target.value);
	};

	const updateEmail = (event: any) => {
		setEmail(event.target.value);
	};


	const submitForm = () => {

		const data: any = {
				name: name,
				surname: surname,
				nickname: nickname,
				email: email
		};
		sendFormData(data);
	};

    return (
        <>
						<div className={styles.form}>
                <input
										className={styles.input}
                    type='text'
                    placeholder='Name'
                    onChange={updateName}
                ></input>
                <input
										className={styles.input}
                    type='text'
                    placeholder='Surname'
                    onChange={updateSurname}
                ></input>
								<input
										className={styles.input}
                    type='text'
                    placeholder='Nickname'
                    onChange={updateNickname}
                ></input>
								<input
										className={styles.input}
                    type='text'
                    placeholder='Email'
                    onChange={updateEmail}
                ></input>
            </div>
						<Link to='/'><button onClick={submitForm} className={styles.button}>SEND</button></Link>
        </>
    );
}

export default CreateStudent;
