import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { About } from './pages/about/about';
import { Contact } from './pages/contact/contact';
import { Signin } from './pages/signin/signin';
import { Signup } from './pages/signup/signup';
import { Mydash } from './pages/mydash/mydash';
import { Navbar } from './components/navbar/navbar';
import { Footer } from './components/footer/footer';

export const routes: Routes = [
  { path: '', component: Home },
   { path: 'about', component: About },
  { path: 'contact', component: Contact },
    { path: 'signin', component: Signin },
  { path: 'signup', component: Signup },
   { path: 'mydash', component: Mydash },
     { path: 'navbar', component: Navbar },
      { path: 'footer', component: Footer },

];
