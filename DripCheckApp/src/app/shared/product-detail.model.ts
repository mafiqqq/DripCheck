import { ProductOwner } from "./product-owner.model"

export class ProductDetail {
        productDetailId: number = 0
        productModel: string = ""
        productBrand: string = ""
        productColor: string = ""
        productImageUrl: string = ""
        productPrice!: number
}
