using System.Collections.Generic;

namespace RefactoringToPatterns_Command.MyWork
{
    public abstract class Handler
    {
        protected CatalogApp _catalogApp;
        public abstract HandlerResponse execute(Dictionary<string, string> parameters);
    }
}