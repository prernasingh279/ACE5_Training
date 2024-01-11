namespace oopseg
{
    class EmployeeClient{
        public static void Main(){
            Employee e1  = new Permanent();
            Employee t1 = new Trainee();
            System.Console.WriteLine("Enter 1 for Permanent and 2 for Trainee");
            int n = Convert.ToInt32(Console.ReadLine());
            if(n==1)
            {
            e1.AcceptDetails();
            e1.CalculateSalary();
            e1.DisplayDetails();
            }
           
           else{
              t1.AcceptDetails();
            t1.CalculateSalary();
            t1.DisplayDetails();
           }

           }
    }

}