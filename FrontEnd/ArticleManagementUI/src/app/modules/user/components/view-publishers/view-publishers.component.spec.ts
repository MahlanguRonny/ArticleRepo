import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewPublishersComponent } from './view-publishers.component';

describe('ViewPublishersComponent', () => {
  let component: ViewPublishersComponent;
  let fixture: ComponentFixture<ViewPublishersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewPublishersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewPublishersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
