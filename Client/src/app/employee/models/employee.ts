import { Image } from "./image";

export class Employee{
  constructor(
    public employeeId: string,
    public name: string,
    public picture: Image,
    public phoneNumber: string,
    public email: string,
    public hireDate: Date,
    public managerId?: string,
    public id?: number
  ){}
}
