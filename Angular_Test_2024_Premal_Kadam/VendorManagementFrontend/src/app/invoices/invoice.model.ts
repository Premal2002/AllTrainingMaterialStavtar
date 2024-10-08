export class Invoice {
    invoiceId: number;
    invoiceNumber: number;
    currencyId: number;
    vendorId: number;
    invoiceAmount: number;
    invoiceReceivedDate: Date;
    invoiceDueDate: Date;
    isActive: boolean;

    constructor(invoiceId: number,invoiceNumber: number, currencyId: number, vendorId: number, invoiceAmount: number, invoiceReceivedDate: Date, invoiceDueDate: Date, isActive: boolean) {
        this.invoiceId = invoiceId;
        this.invoiceNumber = invoiceNumber;
        this.currencyId = currencyId;
        this.vendorId = vendorId;
        this.invoiceAmount = invoiceAmount;
        this.invoiceReceivedDate = invoiceReceivedDate;
        this.invoiceDueDate = invoiceDueDate;
        this.isActive = isActive;
    }
}
