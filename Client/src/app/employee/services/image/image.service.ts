import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  api : string = environment.APIEndpoint;
  controller: string = 'image';
  url: string;
  constructor(private readonly http: HttpClient) {
    this.url =`${this.api}/${this.controller}`;
  }

  post(value: FormData){
    const config = {
      headers: {
        'content-type': 'multipart/form-data',
      },
    };
    return this.http.post(this.url, value, config);
  }
}
