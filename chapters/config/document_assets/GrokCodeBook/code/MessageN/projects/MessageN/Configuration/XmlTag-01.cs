using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MessageN.Configuration
{
    ///<summary>Wrapper class for System.Xml.Linq.XElement.</summary>
    public class XmlTag
    {
        public virtual IEnumerable<XmlTag> Elements()
        {
            throw new NotImplementedException();
        }
        
        public virtual string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}