using System;

namespace EncapsulateClassesWithFactory.MyWork.Descriptors
{
    public class ReferenceDescriptor: AttributeDescriptor
    {
        readonly string descriptorName;
        readonly Type mapperType;
        readonly Type forType;

        internal ReferenceDescriptor(string descriptorName, Type mapperType, Type forType)
            : base(descriptorName, mapperType, forType)
        {
			this.descriptorName = descriptorName;
			this.mapperType = mapperType;
			this.forType = forType;
        }
    }
}