import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from '../home/home.component';
import {LoginComponent} from '../auth/login/login.component';
import {RegisterComponent} from '../auth/register/register.component';
import {ContactsComponent} from '../contacts/contacts.component';
import {ArtistsComponent} from '../artists/artists-list/artists.component';
import {ArtistCreateComponent} from '../artists/artist-create/artist-create.component';
import {ItemsComponent} from '../items/items/items.component';
import {ItemDetailsComponent} from '../items/item-details/item-details.component';
import {ItemCreateComponent} from '../items/item-create/item-create.component';
import {AuthGuard} from '../auth/auth.guard';
import {AboutComponent} from '../about/about.component';
import {ForgotPasswordComponent} from '../forgot-password/forgot-password.component';
import {PrivacyComponent} from '../privacy/privacy.component';
import {NotFoundComponent} from '../not-found/not-found.component';
import {ArtistDetailsComponent} from '../artists/artist-details/artist-details.component';
import {ArticlesAllComponent} from '../blog/articles-all/articles-all.component';
import {ArticleDetailsComponent} from '../blog/article-details/article-details.component';
import {ShoppingCartComponent} from '../shopping-cart/shopping-cart/shopping-cart.component';
import {AdminAuthGuardGuard} from '../auth/admin-auth-guard.guard';

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
