
// ===== styles =====
import stylesDefault from '../../index.css';
import styles from './ButtonPrimary.module.css';


function ButtonPrimary(props: any) {

return(

	<button className={styles.buttonPrimary}>{props.content}</button>
);
}

export default ButtonPrimary;
