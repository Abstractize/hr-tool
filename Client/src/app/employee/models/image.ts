/**
 * Image Model
 */
export class Image{
  /**
   * Creates an Image
   * @param url api url of the image.
   * @param id api id of the image.
   */
  constructor(
    public url: string,
    public id?: number
  ){}
}
