import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamHeadHomeComponent } from './team-head-home.component';

describe('TeamHeadHomeComponent', () => {
  let component: TeamHeadHomeComponent;
  let fixture: ComponentFixture<TeamHeadHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeamHeadHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamHeadHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
