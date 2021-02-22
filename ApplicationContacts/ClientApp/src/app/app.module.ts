import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './components/shared/nav-bar/nav-bar.component';
import { TituloComponent } from './components/shared/titulo/titulo.component';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { DashboarbComponent } from './components/dashboarb/dashboarb.component';
import { MatFormFieldModule, MatTableModule, MatInputModule, MatDatepickerModule, MatNativeDateModule, MatDivider, MatDividerModule, MatOptionModule, MatSelectModule, MatCardModule, MatGridListModule, MatListModule } from '@angular/material';
import {MatButtonModule} from '@angular/material/button';
import {MatDialogModule} from '@angular/material/dialog';

import { PaginationModule } from 'ngx-bootstrap/pagination';

import { TextMaskModule } from 'angular2-text-mask';
import { EditorComponent } from './components/editor/editor.component';

/*const routes: Routes = [
  { path: 'home', component: AppComponent},
  { path: 'editor', component: EditorComponent},
  { path: 'editor/:id', component: EditorComponent},
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: '**', redirectTo: 'home', pathMatch: 'full'},
]*/

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    TituloComponent,
    DashboarbComponent,
    EditorComponent
  ],
  imports: [
    PaginationModule.forRoot(),
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatDividerModule,
    MatOptionModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    TextMaskModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    NgxSpinnerModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 3500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
      closeButton: true
    }),
    RouterModule.forRoot([
      { path: 'home', component: DashboarbComponent},
      { path: 'editor', component: EditorComponent},
      { path: 'editor/:id', component: EditorComponent},
      { path: '', redirectTo: 'home', pathMatch: 'full'},
      { path: '**', redirectTo: 'home', pathMatch: 'full'},
    ])
  ],
  providers: [MatDatepickerModule],
  bootstrap: [AppComponent],
  entryComponents : [
  ],
  exports:[
    RouterModule
  ]
})
export class AppModule { }
