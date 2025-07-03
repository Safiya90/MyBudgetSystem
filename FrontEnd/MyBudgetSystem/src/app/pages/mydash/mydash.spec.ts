import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Mydash } from './mydash';

describe('Mydash', () => {
  let component: Mydash;
  let fixture: ComponentFixture<Mydash>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Mydash]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Mydash);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
