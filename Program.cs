using System;

namespace Day_2_inheritence
{
    /* 
 Manager : Employee
    Prop
     string Designation -> cant be blank


 GeneralManager : Manager
    Prop
     string Perks -> no validations

 CEO : Employee
       Make CalNetSalary() a sealed method*/
    class Program
    {
        static void Main(string[] args)
        {
            Emp e1 = new Emp("Abhijit", 10, 30000);
            Emp e2 = new Manager( "Amol",20, 35000, "Manager");
            Emp e3 = new GeneralManager( "rahul", 30, 40000, "GeneralManager", "Car");
            Emp e4 = new CEO("kiran", 40, 50000);

        //    Manager m1 = new Manager("Abhijit", 10, 30000, "hr");
         //   Console.WriteLine(m1.displayDetails() + "Salary :" + e1.netSalary());

            Console.WriteLine(e1.displayDetails()+ ", Salary :"+ e1.netSalary());
            Console.WriteLine(e2.displayDetails() + ", Salary :" + e2.netSalary());
            Console.WriteLine(e3.displayDetails() + ", Salary :" + e3.netSalary());
            Console.WriteLine(e4.displayDetails() + ", Salary :" + e4.netSalary());
            Console.ReadLine();
        }
    }

    public class Emp

    {
        private string empName;
        public string EmpName
        {
            set
            {
                Boolean check = value.Contains(" ");
                if (!check)
                    empName = value;
                else
                    Console.WriteLine("Enter Valid Name(Name Must not be Contain Blank Space)");
                Console.WriteLine();
            }
            get
            {
                return empName;
            }
        }

        private int empNo;
        public int EmpNo
        {
            get
            {
                return empNo;
            }
        }
        private short deptNo;
        public short DeptNo
        {
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.Write("Enter Valid deptNo(deptNO Must Be Greater Than 0.)");
                Console.WriteLine();
            }
            get
            {
                return deptNo;
            }
        }
        private decimal basic;
        public decimal Basic
        {
            set
            {
                if (value > 10000 && value < 150000)
                    basic = value;
                else

                    Console.Write("Enter Valid basic(Basic Must Be Less Than 1.5L and More Than 1 Thousand.)");

                Console.WriteLine();
            }

            get
            {
                return basic;
            }
        }
        private static int empCount;
        static Emp()
        {
            empCount = 0;
        }
        public Emp(String empName = " ", short deptNo = 0, decimal basic = 0)
        {
            empCount++;
            this.empNo = empCount;
            EmpName = empName;
            Basic = basic;
            DeptNo = deptNo;
        }
        public virtual decimal netSalary()
        {
            int incentives = 5000;
            int homeAllowance = 2000;

            return  this.basic + incentives + homeAllowance;
        }

        public virtual string displayDetails()
        {
            return $"EmpNo :: {EmpNo}, EmpName :: {EmpName}, Department :: {DeptNo} ,salary::{netSalary()}\n";
        }
    }

    public class Manager : Emp
    {
        private string designation;
        public string Designation
        {
            set
            {
                Boolean check = value.Contains(" ");
                if (!check)
                    designation = value;
                else
                    Console.WriteLine("Enter Valid designation(designation Must not be Contain Blank Space)");
                Console.WriteLine();
            }
            get
            {
                return designation;
            }
        }
        public Manager( String empName = " ", short deptNo = 0,  decimal basic = 0,String designation = " ") : base(empName, deptNo, basic,netSalary())
        {
            Designation = designation;
        }

        public override decimal netSalary()
        {

            return base.netSalary() + 5000;
        }

        public override string displayDetails()
        {
            return $" {base.displayDetails()},Designation :: {Designation} ,salary::{netSalary()} ";
        }
    }

    public class GeneralManager : Manager
    { //no validation
        private string perks;
        public string Perks
        {
            set
            {
                  perks = value;
                
            }
            get
            {
                return perks;
            }
        }
        public GeneralManager(  String empName = " ", short deptNo = 0, decimal basic = 0,String designation = " ", String perks = " ") : base( empName, deptNo,  basic,netSalary(), designation)
        {
            Perks = perks;
        }
        public override decimal netSalary()
        {

            return base.netSalary() + 7000;
        }
        public override string displayDetails()
        {
            return $"{base.displayDetails()},Perks :: {Perks},salary::{netSalary()} ";
        }
    }
   
    public class CEO : Emp
    {
        public CEO( String empName = " ", short deptNo = 0, decimal basic = 0) : base(empName, deptNo, basic)
        {
           
        }
        public sealed override decimal netSalary()
        {

            return base.netSalary() + 8000;
        }
        public override string displayDetails()
        {
            return $"Detials of CEO : {base.displayDetails()}";
        }
    }

}
