import {
	Link
} from 'react-router';

// ===== styles =====
import stylesDefault from '../../index.css';
import './LandingPage.module.css';

// ===== components =====
import ButtonPrimary from '../ButtonPrimary/ButtonPrimary';

function LandingPage() {
    

    return (
        <>
						<div><h1>Victorify</h1></div>
						<div>
							<p>Level up your skills in your favorite games or share your expertise and earn money! Our platform connects gamers looking to improve their
							 abilities with experienced mentors ready to help. Whether you want to climb the ranks, master advanced strategies,
							  or teach others - you'll find the perfect fit here.</p>
						</div>
						<div>
							<Link to='/student'><ButtonPrimary content="Join as a student"/></Link>
							<Link to='/teacher'><ButtonPrimary content="Join as a teacher"/></Link>
							<Link to='/lesson'><ButtonPrimary content="Schedule a lesson"/></Link>
						</div>

        </>
    );
}

export default LandingPage;
