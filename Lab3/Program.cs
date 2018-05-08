using System;

namespace Lab3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AssignmentFactory.CreateAssignment(Assignment.First).Execute();
            AssignmentFactory.CreateAssignment(Assignment.Second).Execute();
        }
    }
}
