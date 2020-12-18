import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  api : string = environment.APIEndpoint;
  constructor() { }


}
