import { TestBed } from '@angular/core/testing';
import { ImageService } from './image.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Image } from '../../models/image';

describe('ImageService', () => {
  let service: ImageService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ImageService]
    });
    service = TestBed.inject(ImageService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('be able to Post', () => {
    const dummyPost: FormData = new FormData();
    service.post(dummyPost).subscribe(posts => {
        expect(posts).toBeTruthy();
    });

    const request = httpMock.expectOne( `${service.url}`);
    expect(request.request.method).toBe('POST');
    request.flush(new Image('',0));
  });

  afterEach(() => {
    httpMock.verify();
  });
});
