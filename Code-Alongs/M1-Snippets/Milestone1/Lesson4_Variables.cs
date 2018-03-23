using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone1
{
    class Lesson4_Variables
    {
        //~~_field variable is an example of a field. contained inside the code block { } of class ExampleType. This means the scope of _field is all of ExampleType.~~
        //~~parameter variable allows other parts of our application to pass an integer value into the Method(). Its scope is only within the Method() code block.~~
        //~~localVariable declaration is also inside the Method() code block and is only usable inside it.~~
        //~~Method() is marked public, any other code that links to this project can invoke it and pass data to parameter.~~ 
        //~~_field is marked as private only the other members of ExampleType may use it.~~
        //~~localVariable is defined inside Method() no code outside of the Method() block can access it.~~

        //class ExampleType
        //{
        //    private int _field;

        //    public void Method(int parameter)
        //    {
        //        int localVariable;
        //    }
        //}



        //~~intializing in declaration vs. just declaring~~

        //public void Method(int parameter)
        //{
        //    int uninitialized;
        //    int initialized = 5;
        //}



        //~~indicate on the variable declaration that it supports null by using the "?"~~

        //int simple = null;        ~~error~~
        //int? nullable = null;     ~~ok~~
    }

}
