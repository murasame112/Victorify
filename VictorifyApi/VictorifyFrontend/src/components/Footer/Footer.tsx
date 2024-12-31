import stylesDefault from '../../index.css';
import styles from './Footer.module.css';

function Footer() {
    return (
        <div className={styles.footer}>
            <div className={styles.content}>
                <p>Web Design by Tomasz Więsek, 2024</p>
            </div>
        </div>
    );
}

export default Footer;
