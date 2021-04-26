namespace LoggerHomework.Layouts
{
    using LoggerHomework.Layouts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            switch (type.ToLower())
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout");
            }
        }
    }
}
