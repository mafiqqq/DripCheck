import { WarrantyDetail } from "./warranty-detail.model";

export class ProductOwner {
    productOwnerId: number = 0;
    ownerFirstName: string = "";
    ownerLastName: string = "";
    emailAddress: string = "";
    phoneNum: string = "";
    productSerialNumber: string = "";
    productDetailId: number = 0;
    productDetail: string = "";
    warrantyDetailId: number = 0;
    warrantyDetail!: WarrantyDetail;
}

