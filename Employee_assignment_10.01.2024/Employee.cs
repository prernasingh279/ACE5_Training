using System.Security.Cryptography;

namespace oopseg
{
    abstract class Employee
    {
        public int Empid{get;set;}
        public string? Name{get;set;}
        public float salary{get;set;}
        public DateTime doj{get;set;}

        public virtual void AcceptDetails(){
            System.Console.WriteLine("Enter the Empid");
            Empid = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter the Name");
            Name = Console.ReadLine();
            System.Console.WriteLine("Enter the date of joining");
            doj = Convert.ToDateTime(Console.ReadLine());
        }

        public virtual void DisplayDetails(){
            System.Console.WriteLine($"Employee ID : {Empid}");
            System.Console.WriteLine($"Name : {Name}");
            System.Console.WriteLine($"DOJ : {doj}");
        }

        // public void CalculateSalary(){
        //     salary = 0.0f ; 
        // }

        abstract public void  CalculateSalary();
    }

    class Permanent : Employee{
        public int BasicPay{get;set;}
        public int HRA{get;set;}
        public int DA{get;set;}
        public int PF{get;set;}
        
        public override void AcceptDetails(){
            base.AcceptDetails();
            System.Console.WriteLine("Enter the Basic, HRA, DA, Pf");
            BasicPay=Convert.ToInt32(Console.ReadLine());
            HRA=Convert.ToInt32(Console.ReadLine());
            DA=Convert.ToInt32(Console.ReadLine());
            PF=Convert.ToInt32(Console.ReadLine());
        }
        

        public override void CalculateSalary(){
            salary = BasicPay+HRA+DA-PF;
        }
        
          public override void DisplayDetails(){
            base.DisplayDetails();
            System.Console.WriteLine($"Basic : {BasicPay}\nHRA : {HRA}\nDA : {DA}\nPF : {PF}"); 
            System.Console.WriteLine($"The salary is : {salary}");
        }
    }

        class Trainee: Employee
        {
            public float bonus{get;set;}
            public string ProjectName{get;set;}

            public override void AcceptDetails(){
                base.AcceptDetails();
                
                System.Console.WriteLine("Enter the ProjectName");
                ProjectName=Console.ReadLine();
            }

            public override void CalculateSalary(){
                System.Console.WriteLine("Enter the salary");
                salary = Convert.ToInt32(Console.ReadLine());
                if(ProjectName=="banking")
                {
                    bonus = (float)(0.05*salary);
                    salary += bonus;
                }
                else if(ProjectName=="insurance")
                {
                    bonus = (float)(0.1*salary);
                    salary+=bonus;
                }
            }
            public override void DisplayDetails(){
            base.DisplayDetails();
            System.Console.WriteLine("ProjectName :"+ProjectName);
            System.Console.WriteLine($"Bonus : {bonus}"); 
            System.Console.WriteLine($"The salary is : {salary}");
        }
        }

    
}