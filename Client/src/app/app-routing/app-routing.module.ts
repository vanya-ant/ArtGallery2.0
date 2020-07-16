import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from '../home/home.component';
import {ContactsComponent} from '../contacts/contacts.component';
import {AboutComponent} from '../about/about.component';
import {PrivacyComponent} from '../privacy/privacy.component';
import {NotFoundComponent} from '../not-found/not-found.component';


const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: HomeComponent,
  },
  {
    path: 'auth',
    loadChildren: () => import('../auth/authentication-routing.module').then(m => m.AuthenticationRoutingModule)
  },
  {
    path: 'contacts',
    component: ContactsComponent,
    loadChildren: () => import('../contacts/contacts.module').then(m => m.ContactsModule),
    data: {
      isLogged: false
    },
  },
  {
    path: 'items',
    loadChildren: () => import('../items/items-routing.module').then(m => m.ItemsRoutingModule)
  },
  {
    path: 'blog',
    loadChildren: () => import('../blog/blog-routing.module').then(m => m.BlogRoutingModule)
  },
  {
    path: 'about',
    component: AboutComponent,
  },
  {
    path: 'privacy',
    component: PrivacyComponent
  },
  {
    path: '**',
    component: NotFoundComponent
  },
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
