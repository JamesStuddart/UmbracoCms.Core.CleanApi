using System;
using System.Collections.Generic;
using System.Linq;

namespace UmbracoCMS.Core.CleanApi.Fabric.Models
{
    public class CleanResponse<T> where T : class
    {
        public readonly T Content;
        public CleanLinks Links { get; }
        
        public CleanResponse(T content, CleanLinks links = null)
        {
            Content = content;
            Links = links ?? new CleanLinks();
        }

        public void AddLink(string hypertextReference, string relationship, HttpVerbs verb)
        {
            if (!Links.Any(x => x.Href == hypertextReference && x.Rel == relationship && x.Type == Enum.GetName(verb.GetType(), verb)?.ToUpper()))
            {
                Links.Add(new CleanLink(hypertextReference, relationship, verb));   
            }
        }

        public void AddLink(string hypertextReference, string relationship, string type)
        {
            if (!Links.Any(x => x.Href == hypertextReference && x.Rel == relationship && x.Type == type))
            {
                Links.Add(new CleanLink(hypertextReference, relationship, type));   
            }
        }

        public void AddLink(CleanLink link)
        {
            if (!Links.Contains(link))
            {
                Links.Add(link);   
            }
        }
        
        public void AddLinks(IEnumerable<CleanLink> links)
        {
            foreach (var link in links)
            {
                Links.Add(link);
            }
        }
    }
}