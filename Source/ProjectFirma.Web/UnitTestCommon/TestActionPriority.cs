using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestActionPriority
        {
            public static ActionPriority Create()
            {
                var program = TestProgram.Create();
                var actionPriority = ActionPriority.CreateNewBlank(program);
                return actionPriority;
            }

            /// <summary>
            /// Create new ActionPriority and attach it to the given context
            /// </summary>
            public static ActionPriority Create(DatabaseEntities dbContext)
            {
                var program = TestProgram.Create(dbContext);
                var nextActionPriorityNumber = ActionPriority.GetNextActionPriorityNumberForProgram(dbContext.ActionPriorities, program.ProgramID);
                var actionPriority = new ActionPriority(program, nextActionPriorityNumber, MakeTestName("Test Action Priority Name", ActionPriority.FieldLengths.ActionPriorityName));
                var newActionPriority = actionPriority;
                dbContext.ActionPriorities.Add(newActionPriority);
                return newActionPriority;
            }
        }
    }
}