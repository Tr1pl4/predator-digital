import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Gamelist } from './gamelist';

describe('Gamelist', () => {
  let component: Gamelist;
  let fixture: ComponentFixture<Gamelist>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Gamelist],
    }).compileComponents();

    fixture = TestBed.createComponent(Gamelist);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
