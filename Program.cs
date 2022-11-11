namespace DesignPatterns
{
    /* Singleton Pattern
     * Objects that only have one instance but a global access point
    */
    public class Singleton
    {
        private string g; private static Singleton instance;
        private Singleton(string g)
        {
            this.g = g;
        }
        public static Singleton getInstance(string g)
        {
            if (instance == null)
            {
                instance = new Singleton(g);
            }
            return instance;
        }
        public string getString() { return g; }
    }

    /* Factory Method Pattern
     * a class that returns an interface 
    */
    class CreditCardFactory
    {
        //returns a class even though its return type is an interface because the class extends the interface
        public static CrediCard GetCrediCard(string cardType)
        {
            CrediCard crediCard = null;

            switch (cardType)
            {
                case "MoneyBack":
                    crediCard = new MoneyBack();
                    break;
                case "Titanium":
                    crediCard = new Titanium();
                    break;
                case "Platinum":
                    crediCard = new Platinum();
                    break;
            }
            return crediCard;
        }
    }
    interface CrediCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }
    class MoneyBack : CrediCard
    {
        public string GetCardType()
        {
            return "MoneyBack";
        }
        public int GetCreditLimit()
        {
            return 15000;
        }
        public int GetAnnualCharge()
        {
            return 500;
        }
    }
    class Titanium : CrediCard
    {
        public string GetCardType()
        {
            return "Titanium Edge";
        }
        public int GetCreditLimit()
        {
            return 25000;
        }
        public int GetAnnualCharge()
        {
            return 1500;
        }
    }
    class Platinum : CrediCard
    {
        public string GetCardType()
        {
            return "Platinum Plus";
        }
        public int GetCreditLimit()
        {
            return 35000;
        }
        public int GetAnnualCharge()
        {
            return 2000;
        }
    }
    
    /* Prototype Pattern
     * MemberwiseCLone returns an object with all of the fields filled out
    */
    public class Employee
    {
        public string Name { get; set; }
        public string Dept { get; set; }

        public Employee GetClone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //Singleton Pattern
            Console.Write("Enter text: ");
            Singleton g = Singleton.getInstance(Console.ReadLine());
            Console.WriteLine(g.getString());

            //Factory Method Pattern
            Console.Write("Select a Credit Card: ");
            CrediCard crediCard = CreditCardFactory.GetCrediCard(Console.ReadLine());
            string name = crediCard.GetCardType();
            Console.WriteLine("Your Credit Card Name is: {0}", name);

            //Prototype Pattern
            Employee emp1 = new Employee();
            emp1.Name = "Anurag";
            emp1.Dept = "IT";
            Employee emp2 = emp1.GetClone();
            emp2.Name = "Pranaya";

            Console.WriteLine("Emplpyee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Department: " + emp1.Dept);
            Console.WriteLine("Emplpyee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Department: " + emp2.Dept);
        }
    }
}
