import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { WarrantyDetailsComponent } from './warranty-details/warranty-details.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { SerialDetailFormComponent } from './serial-details/serial-detail-form/serial-detail-form.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductDetailFormComponent } from './product-details/product-detail-form/product-detail-form.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProductViewComponent } from './product-view/product-view.component';
import { ProductViewSingleComponent } from './product-view-single/product-view-single.component';
import { MyProductComponent } from './my-product/my-product.component';
import { NgxQrcodeStylingModule } from 'ngx-qrcode-styling';

@NgModule({
  declarations: [
    AppComponent,
    WarrantyDetailsComponent,
    SerialDetailFormComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    ProductDetailsComponent,
    ProductDetailFormComponent,
    LoginComponent,
    RegisterComponent,
    ProductViewComponent,
    ProductViewSingleComponent,
    MyProductComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
    RouterModule.forRoot([]),
    NgxQrcodeStylingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
