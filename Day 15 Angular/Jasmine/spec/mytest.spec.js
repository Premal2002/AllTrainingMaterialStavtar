class Calculator{
    add(num1,num2){
        return num1+num2;
    }

    sub(num1,num2){
        return num1-num2;
    }
}


describe("Checking mu calculator functions", function() {
    let a;
  
    it("check addition", function() {
      calc = new Calculator();
  
      expect(10).toBe(calc.add(7,3));
    });

    it("check subtraction", function() {
        calc = new Calculator();
    
        expect(10).toBe(calc.sub(7,3));
      });
  });