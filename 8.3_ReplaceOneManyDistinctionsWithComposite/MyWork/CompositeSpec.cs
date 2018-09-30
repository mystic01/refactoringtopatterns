using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReplaceOneManyDistinctionsWithComposite.MyWork
{
    public class CompositeSpec : Spec
    {
        private readonly List<Spec> _specs;

        public CompositeSpec()
        {
            _specs = new List<Spec>();
        }

        public ReadOnlyCollection<Spec> getSpecs()
        {
            return new ReadOnlyCollection<Spec>(_specs.AsReadOnly());
        }

        public override bool isSatisfiedBy(Product product)
        {
            IEnumerator<Spec> specifications = this.getSpecs().GetEnumerator();
            bool satisfiesAllSpecs = true;
            while (specifications.MoveNext())
            {
                Spec productSpec = specifications.Current;
                satisfiesAllSpecs &= productSpec.isSatisfiedBy(product);
            }

            return satisfiesAllSpecs;
        }

        public void Add(Spec spec)
        {
            _specs.Add(spec);
        }
    }
}