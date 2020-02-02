using System;

using System.Collections.Generic;

using System.Text;



namespace ConsoleApp2

{

    interface ILogger

    {

        void Log(string message);



        void Log(Exception exception);

    }

}

