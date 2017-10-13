using System;

namespace EncapsulateClassesWithFactory.MyWork.Descriptors
{
    public class DefaultDescriptor : AttributeDescriptor
    {
        readonly string descripterName;
        readonly Type mapperType;
        readonly Type forType;

        internal DefaultDescriptor(string descriptorName, Type mapperType, Type forType)
            : base(descriptorName, mapperType, forType)
        {
            this.descripterName = descriptorName;
            this.mapperType = mapperType;
            this.forType = forType;
        }
    }
}