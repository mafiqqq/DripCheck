import { ProductOwner } from "./product-owner.model"

export class ProductDetail {
        // serialNumber: string = ""
        productDetailId: number = 0
        productModel: string = ""
        productBrand: string = ""
        productColor: string = ""
        productImageUrl: string = ""
        productPrice: number = 0.00
        productOwners: ProductOwner[] | undefined;
}
