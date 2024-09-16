import { TestBed } from '@angular/core/testing';

import { AppService } from './app.service';

describe('AppService', () => {
  let service: AppService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AppService);
    // console.log("h");
    
  });

  afterEach(()=>{
    console.log("after");
    
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('should return data from getData()', () => {
    expect(service.getData()).toEqual("Hello from service");
  });
});
