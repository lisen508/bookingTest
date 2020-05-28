using System;

namespace BookingPlatform.Commom
{
    /// <summary>
    /// 属性名称
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NameAttribute : Attribute
    {
        public NameAttribute() { }

        public NameAttribute(string name)
        {
            this.Name = name;
        }
        //记录名称
        public string Name { get; set; }
    }
}
