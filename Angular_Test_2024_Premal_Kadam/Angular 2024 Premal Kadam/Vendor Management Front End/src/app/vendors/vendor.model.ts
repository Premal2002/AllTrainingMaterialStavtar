export class Vendor {
    vendorId: number;
    vendorCode: string;
    vendorLongName: string;
    vendorPhoneNumber: string;
    vendorEmail: string;
    vendorCreatedOn: Date;
    isActive: boolean;

    constructor(vendorId: number, vendorCode: string, vendorLongName: string,vendorPhoneNumber: string, vendorEmail: string, vendorCreatedOn: Date,isActive: boolean){
        this.vendorId = vendorId;
        this.vendorCode = vendorCode;
        this.vendorLongName = vendorLongName;
        this.vendorPhoneNumber = vendorPhoneNumber;
        this.vendorEmail = vendorEmail;
        this.vendorCreatedOn = vendorCreatedOn
        this.isActive= isActive;
    }
  }