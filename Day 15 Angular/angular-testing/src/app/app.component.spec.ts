import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { Component, DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';
import { Router, RouterLinkWithHref, RouterOutlet } from '@angular/router';

describe('AppComponent', () => {
  let fixture : ComponentFixture<AppComponent>;
  let component : AppComponent;
  let debugElement : DebugElement;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        AppComponent
      ],
    }).compileComponents();
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    debugElement = fixture.debugElement;
    fixture.detectChanges();
    });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'angular-testing'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('angular-testing');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.content span')?.textContent).toContain('angular-testing app is running!');
  });

  it(`router outlet test`, () => {
    const routerOutlet = debugElement.query(By.directive(RouterOutlet));
    expect(routerOutlet).not.toBeNull();
  });

  it(`router outlet link with href`, () => {
    const links = debugElement.queryAll(By.directive(RouterLinkWithHref));
    expect(links.length).toBeGreaterThan(0);
  });
});
