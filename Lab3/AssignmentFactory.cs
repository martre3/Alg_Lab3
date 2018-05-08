using System;
namespace Lab3
{
    public static class AssignmentFactory
    {
        public static IAssignment CreateAssignment(Assignment assignment)
        {
            switch(assignment)
            {
                case Assignment.First:
                    return new FirstAssignment();
                case Assignment.Second:
                    return new SecondAssignment();
            }
            return null;
        }
    }
}
