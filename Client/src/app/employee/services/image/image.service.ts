import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Image } from '../../models/image';

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
    return this.http.post<Image>(this.url, value);
  }
}
