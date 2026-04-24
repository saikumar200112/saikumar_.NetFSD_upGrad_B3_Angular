

class Employee {
  public id: number;         
  protected name: string;      
  private _salary: number;     

  constructor(id: number, name: string, salary: number) {
    this.id = id;
    this.name = name;
    this._salary = salary;
  }

  
  get salary(): number {
    return this._salary;
  }

  set salary(value: number) {
    if (value > 0) {
      this._salary = value;
    } else {
      console.log("Error: Salary must be a positive value.");
    }
  }

  
  displayDetails(): void {
    console.log(`ID: ${this.id}, Name: ${this.name}, Salary: $${this._salary}`);
  }
}


class Manager extends Employee {
  public teamSize: number;

  constructor(id: number, name: string, salary: number, teamSize: number) {
    
    super(id, name, salary);
    this.teamSize = teamSize;
  }


  override displayDetails(): void {
   
    console.log(
      `[Manager] ID: ${this.id}, Name: ${this.name}, Team Size: ${this.teamSize}, Salary: $${this.salary}`
    );
  }
}


console.log("--- Organization Employee Records ---");


const emp1 = new Employee(101, "Alice Smith", 50000);
emp1.displayDetails();


emp1.salary = 55000; 
console.log(`Updated Salary for ${emp1.id}: $${emp1.salary}`);


const mgr1 = new Manager(201, "Bob Johnson", 85000, 10);
mgr1.displayDetails();


//mgr1.salary = -1000;