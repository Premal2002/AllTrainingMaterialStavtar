import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

describe('AppComponent', () => {
let router : Router;
let location : Location;
let fixture : ComponentFixture<AppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule.withRoutes([
            {path : '',component : HomeComponent},
            {path : 'about',component : AboutComponent}
          ])
      ],
      declarations: [
        AppComponent, HomeComponent, AboutComponent
      ],
    }).compileComponents();
    router = TestBed.inject(Router);
    location = TestBed.inject(Location);
    fixture = TestBed.createComponent(AppComponent);
    router.initialNavigation();

  });

  it('routing for "" should navigate to Home', () => {
    router.navigate(['']).then(()=>{
        fixture.detectChanges();
        expect(location.path()).toBe('/');
    })
  });

  it('routing for "about" should navigate to About', () => {
    router.navigate(['/about']).then(()=>{
        fixture.detectChanges();
        expect(location.path()).toBe('/about');
    })
  });

});
