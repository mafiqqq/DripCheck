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
  imageUrl1: string = "";
  imageUrl2: string = "";
  imageUrl3: string = "";
  imageUrls: {[key:string]: string} = {};
  selectedFile: File | undefined;
  filenames: string[] = [];
  previews: string[] = [];
  constructor(public service: ProductDetailService, private toastr: ToastrService) {

  }

  // onFileSelected(event: any){
  //   this.selectedFile = event.target.files[0] as File;
  //   this.imageUrl = "assets/images/" + this.selectedFile.name;  
  // }

  onFileSelected(event: any) {
    const files: FileList = event.target.files;
    
    if (files.length > 3) {
      alert('You can only upload a maximum of 3 images');
      event.target.value = null;
      return;
    }
    
    this.filenames = [];
    this.previews = [];
    
    for (let i=0; i < files.length; i++) {
      const file = files[i]
      this.filenames.push(files[i].name);
      const imageUrlKey = `imageUrl${i+1}`;
      this.imageUrls[imageUrlKey] = "assets/images/" + files[i].name;

      const reader = new FileReader();
      reader.onload = (e:any) => {
        this.previews.push(e.target.result);
      };
      reader.readAsDataURL(file);
    }

  }

  onSubmit(form:NgForm) {
    this.service.addProductDetail(this.imageUrls) 
    .subscribe({
      next: res => {
        this.service.resetForm(form)
        this.previews = []
        this.toastr.success('Added successfully', 'Product Registration')
      },
      error: err => {
        console.log(err)
      }
    })
  }


}
