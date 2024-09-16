import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoViewChildComponent } from './demo-view-child.component';

describe('DemoViewChildComponent', () => {
  let component: DemoViewChildComponent;
  let fixture: ComponentFixture<DemoViewChildComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DemoViewChildComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DemoViewChildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
