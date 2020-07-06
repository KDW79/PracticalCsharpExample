using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch17_OOP
{
    abstract class GreetingBase
    {
        public virtual string GetMessage()
        {
            return "";

        }
    }

    class GreetingMorning : GreetingBase
    {
        public override string GetMessage()
        {
            return "Good Morning";
        }
        public override string ToString()
        {
            return "Class Name: GreetingMorning";
        }
    }

    class GreetingAfternoon : GreetingBase
    {
        public override string GetMessage()
        {
            return "Good Afternoon";
        }
        public override string ToString()
        {
            return "Class Name: GreetingAfternoon";
        }
    }

    class GreetingEvening : GreetingBase
    {
        public override string GetMessage()
        {
            return "Good Evening";
        }
        public override string ToString()
        {
            return "Class Name: GreetingEvening";
        }
    }

    class GreetingMorning2 : IGreeting
    {
        public  string GetMessage()
        {
            return "Good Morning";
        }
        public override string ToString()
        {
            return "Class Name: GreetingMorning";
        }
    }

    class GreetingAfternoon2 : IGreeting
    {
        public  string GetMessage()
        {
            return "Good Afternoon";
        }
        public override string ToString()
        {
            return "Class Name: GreetingAfternoon";
        }
    }

    class GreetingEvening2 : IGreeting
    {
        public  string GetMessage()
        {
            return "Good Evening";
        }
        public override string ToString()
        {
            return "Class Name: GreetingEvening";
        }
    }

}
