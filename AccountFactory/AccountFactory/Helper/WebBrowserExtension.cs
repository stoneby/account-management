using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountFactory
{
    public static class WebBrowserExtension
    {
        public static HtmlElement GetElementsByClass(this HtmlDocument doc, string className)
        {
            foreach (HtmlElement e in doc.All)
                if (e.GetAttribute("className") == className)
                    return e;
            return null;
        }

        public static HtmlElement GetElementsByClass(this HtmlElement elem, string className)
        {
            foreach (HtmlElement e in elem.All)
                if (e.GetAttribute("className") == className)
                    return e;
            return null;
        }

        public static HtmlElement GetElementByClass(this HtmlElementCollection list, string className)
        {
            foreach (HtmlElement e in list)
                if (e.GetAttribute("className") == className)
                    return e;
            return null;
        }
    }
}
