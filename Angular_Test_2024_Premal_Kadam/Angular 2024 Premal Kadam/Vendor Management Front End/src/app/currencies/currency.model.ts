export class Currency {
    currencyId: number;
    currencyName: string;
    currencyCode: string;
  
    constructor(currencyId: number, currencyName: string, currencyCode: string) {
      this.currencyId = currencyId;
      this.currencyName = currencyName;
      this.currencyCode = currencyCode;
    }
  }
  