import React, { useState, useEffect } from 'react';

// ===== styles =====
import stylesDefault from '../../index.css';
import styles from './LandingPage.module.css';

// ===== components =====
import ButtonPrimary from '../ButtonPrimary/ButtonPrimary';

function LandingPage() {
    

    return (
        <>
					<div className={styles.landing}> 
						<div><h1>Victorify</h1></div>
						<div>
							<p>Level up your skills in your favorite games or share your expertise and earn money! Our platform connects gamers looking to improve their
							 abilities with experienced mentors ready to help. Whether you want to climb the ranks, master advanced strategies,
							  or teach others - you'll find the perfect fit here.</p>
						</div>
						<div>
							<ButtonPrimary content="Join as a student"/>
							<ButtonPrimary content="Join as a teacher"/>
						</div>

					</div>
        </>
    );
}

export default LandingPage;
