import { Image } from "./image";
/**
 * Employee Model.
 */
export class Employee{
  /**
   * Creates an Employee
   * @param employeeId working id of the employee.
   * @param name employee name.
   * @param picture employee picture image.
   * @param phoneNumber employee phone number.
   * @param email employee email.
   * @param hireDate employee date that was hired.
   * @param managerId working id of the employee manager.
   * @param id api id of the employee.
   */
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
