import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Lobbies } from './lobbies';

describe('Lobbies', () => {
  let component: Lobbies;
  let fixture: ComponentFixture<Lobbies>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Lobbies],
    }).compileComponents();

    fixture = TestBed.createComponent(Lobbies);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
