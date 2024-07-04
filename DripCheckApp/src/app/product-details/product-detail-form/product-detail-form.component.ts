import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProductDetail } from 'src/app/shared/product-detail.model';
import { ProductDetailService } from 'src/app/shared/product-detail.service';

@Component({
  selector: 'app-product-detail-form',
  templateUrl: './product-detail-form.component.html',
  styles: [
  ]
})
export class ProductDetailFormComponent {
  
  productDetails: ProductDetail[] = [];
  imageUrl: string = "";
  selectedFile: File | undefined;
  constructor(public service: ProductDetailService, private toastr: ToastrService) {

  }

  onFileSelected(event: any){
    this.selectedFile = event.target.files[0] as File;
    this.imageUrl = "assets/images/" + this.selectedFile.name;  
  }

  onSubmit(form:NgForm) {
    this.service.addProductDetail(this.imageUrl) 
    .subscribe({
      next: res => {
        console.log(res)
        this.service.resetForm(form)
        this.imageUrl = ""
        this.toastr.success('Added successfully', 'Product Registration')
      },
      error: err => {
        console.log(err)
      }
    })
  }


}
