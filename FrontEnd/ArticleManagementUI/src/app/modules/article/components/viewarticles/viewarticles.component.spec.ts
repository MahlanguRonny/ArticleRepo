import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewarticlesComponent } from './viewarticles.component';

describe('ViewarticlesComponent', () => {
  let component: ViewarticlesComponent;
  let fixture: ComponentFixture<ViewarticlesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewarticlesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewarticlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
