using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI01AdventureWorksWinFormsUI
{
    public class Query
    {
        public string Language { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string  Size { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ProductLine { get; set; }
        public bool Availability { get; set; }

        public Query(string language, string category, string subcateogry, string size, string clas, string style, string productLine, bool availability)
        {
            Language = checkNull(language);
            Category = checkNull(category);
            Subcategory = checkNull(subcateogry);
            Size = checkNull(size);
            Class = checkNull(clas);
            Style = checkNull(style);
            ProductLine = checkNull(productLine);
            Availability = availability;
        }
        private string checkNull(string tocheck)
        {
            if (tocheck == null)
            {
                return "NULL";
            } else
            {
                return $"'{tocheck}'";
            }
                    
        }

        public string ToQuery()
        {
            return $"EXEC spGeneric_ShowResult @Idioma = {Language}, @Category = {Category}, @Subcategory = {Subcategory}, " +
                    $"@Size = {Size}, @Class = {Class}, @Style = {Style}, @ProductLine = {ProductLine}, @Availability = {Availability};";
        }
    }
}