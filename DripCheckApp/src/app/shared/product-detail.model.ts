import { ProductOwner } from "./product-owner.model"

export class ProductDetail {
        productDetailId: number = 0
        productModel: string = ""
        productBrand: string = ""
        productColor: string = ""
        productImageUrl1: string = ""
        productImageUrl2: string = ""
        productImageUrl3: string = ""
        productPrice!: number
}
