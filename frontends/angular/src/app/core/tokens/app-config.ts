import { InjectionToken } from '@angular/core';
import { environment } from '../../../environments/environment';

export interface AppConfig {
  apiBaseUrl: string;
  hubUrl: string;
  mediaBaseUrl: string;
  predatorMediaBaseUrl: string;
}

export const APP_CONFIG = new InjectionToken<AppConfig>('APP_CONFIG', {
  providedIn: 'root',
  factory: () => ({
    apiBaseUrl: environment.apiBaseUrl,
    hubUrl: environment.hubUrl,
    mediaBaseUrl: environment.mediaBaseUrl,
    predatorMediaBaseUrl: environment.predatorMediaBaseUrl
  })
});
