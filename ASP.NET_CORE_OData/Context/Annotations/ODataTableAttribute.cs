using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_CORE_OData.Context.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ODataTableAttribute : TableAttribute
    {
        public static readonly string defaultSchema = "Project.OData";
        public ODataTableAttribute(string name) : base(name)
        {
            this.Schema = defaultSchema;
        }
    }
}
