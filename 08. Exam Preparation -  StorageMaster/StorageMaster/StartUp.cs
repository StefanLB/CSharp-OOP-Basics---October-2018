using System;
using StorageMaster.Controller;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine(new Controller.StorageMaster());
            engine.Run();
        }
    }
}
