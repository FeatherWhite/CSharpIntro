//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityAssociation
{
    using System;
    using System.Collections.Generic;
    
    public partial class MyClass
    {
        public MyClass()
        {
            this.MyClassChilds = new HashSet<MyClassChild>();
        }
    
        public int MyClassID { get; set; }
        public int MyClassContainerID { get; set; }
        public string Information { get; set; }
    
        public virtual MyClassContainer MyClassContainer { get; set; }
        public virtual ICollection<MyClassChild> MyClassChilds { get; set; }
    }
}
