using System;
using System.Collections.Generic;

namespace UmbracoCMS.Core.CleanApi.Fabric.Models
{
    public class CleanLinks : List<CleanLink>
    {
    }
    
    public class CleanLink
    {

        public CleanLink(string relationship, string hypertextReference, HttpVerbs verb)
        {
            Rel = relationship;
            Href = hypertextReference;
            Type = Enum.GetName(verb.GetType(), verb)?.ToUpper();
        }

        public CleanLink(string relationship, string hypertextReference, string type)
        {
            Rel = relationship;
            Href = hypertextReference;
            Type = type;
        }
        
        public string Rel { get; }
        public string Href { get; }
        public string Type { get; }
    }
}