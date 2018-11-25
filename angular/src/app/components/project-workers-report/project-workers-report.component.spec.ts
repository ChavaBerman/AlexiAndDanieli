import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectWorkersReportComponent } from './project-workers-report.component';

describe('ProjectWorkersReportComponent', () => {
  let component: ProjectWorkersReportComponent;
  let fixture: ComponentFixture<ProjectWorkersReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectWorkersReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectWorkersReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
