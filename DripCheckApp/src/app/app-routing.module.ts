import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { WarrantyDetailsComponent } from './warranty-details/warranty-details.component';
import { SerialDetailsComponent } from './serial-details/serial-details.component';
import { ProductDetailFormComponent } from './product-details/product-detail-form/product-detail-form.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

const routes: Routes = [
    {path: '', redirectTo: 'home', pathMatch: 'full'},
    {path: 'home', component: HomeComponent},
    {path: 'warranty', component: WarrantyDetailsComponent},
    {path: 'serial', component: SerialDetailsComponent},
    {path: 'register-product', component: ProductDetailFormComponent},
    {path: 'all-products', component: ProductDetailsComponent}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}