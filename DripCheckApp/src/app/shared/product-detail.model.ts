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
        productHeight: string = ""
        productSerialNumbersText: string = ""
        serialNumbers: string[] = []
        productWidth: string = ""
        productWeight: string = ""
        productDisplaySize: string = ""
        productDisplayType: string = ""
        productResolution: string = ""
        productProcessor: string = ""
        productOS: string = ""
        productMemoryRAM: string = ""
        productMemoryROM: string = ""
        productRearCamera: string = ""
        productFrontCamera: string = ""
        productBattery: string = ""
        productRelDate: string = ""
}
