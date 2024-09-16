import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StandaloneCompComponent } from './standalone-comp.component';

describe('StandaloneCompComponent', () => {
  let component: StandaloneCompComponent;
  let fixture: ComponentFixture<StandaloneCompComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ StandaloneCompComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StandaloneCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
