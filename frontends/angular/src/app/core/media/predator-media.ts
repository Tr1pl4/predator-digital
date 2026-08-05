import { environment } from '../../../environments/environment';

export type PredatorMovie = 1 | 2;

export function predatorMovieFolder(movie: PredatorMovie): `movie-${PredatorMovie}` {
  return `movie-${movie}`;
}

export function predatorAvatarUrl(movie: PredatorMovie, fileName: string): string {
  return `${environment.predatorMediaBaseUrl}/avatars/${predatorMovieFolder(movie)}/${fileName}`;
}

export function predatorCardBackUrl(): string {
  return `${environment.predatorMediaBaseUrl}/CardArt.png`;
}
