using System;
using System.Collections.Generic;
using Oqtane.Shared;

namespace Oqtane.Models
{
    /// <summary>
    /// Script inherits from Resource and offers constructors with parameters specific to Scripts
    /// </summary>
    public class Script : Resource
    {
        private void SetDefaults()
        {
            this.ResourceType = ResourceType.Script;
            this.Location = ResourceLocation.Body;
        }

        public Script(string Src)
        {
            SetDefaults();
            this.Url = Src;
        }

        public Script(string Content, string Type)
        {
            SetDefaults();
            this.Content = Content;
            this.Type = Type;
        }

        public Script(string Content, ResourceLoadBehavior LoadBehavior)
        {
            SetDefaults();
            this.Content = Content;
            this.LoadBehavior = LoadBehavior;
        }

        public Script(string Src, string Integrity, string CrossOrigin)
        {
            SetDefaults();
            this.Url = Src;
            this.Integrity = Integrity;
            this.CrossOrigin = CrossOrigin;
        }

        public Script(string Src, string Integrity, string CrossOrigin, string Type, string Content, ResourceLocation Location, string Bundle, ResourceLoadBehavior LoadBehavior, Dictionary<string, string> DataAttributes, string RenderMode)
        {
            SetDefaults();
            this.Url = Src;
            this.Integrity = Integrity;
            this.CrossOrigin = CrossOrigin;
            this.Type = Type;
            this.Content = Content;
            this.Location = Location;
            this.Bundle = Bundle;
            this.LoadBehavior = LoadBehavior;
            this.DataAttributes = DataAttributes;
            this.RenderMode = RenderMode;
        }

        [Obsolete("This constructor is deprecated. Use constructor with LoadBehavior parameter instead.", false)]
        public Script(string Src, string Integrity, string CrossOrigin, string Type, string Content, ResourceLocation Location, string Bundle, bool Reload, Dictionary<string, string> DataAttributes, string RenderMode)
        {
            SetDefaults();
            this.Url = Src;
            this.Integrity = Integrity;
            this.CrossOrigin = CrossOrigin;
            this.Type = Type;
            this.Content = Content;
            this.Location = Location;
            this.Bundle = Bundle;
            this.LoadBehavior = (Reload) ? ResourceLoadBehavior.BlazorPageScript : ResourceLoadBehavior.Once;
            this.DataAttributes = DataAttributes;
            this.RenderMode = RenderMode;
        }

    }
}
