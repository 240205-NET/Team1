using System;
using System.Text;
using System.Xml.Serialization;

namespace RecipeFinder
{

    public class Meal : Recipe
    {
        public string? idMeal { get; set; }
        public string? strMeal { get; set; }
        public string? strDrinkAlternate { get; set; }
        public string? strCategory { get; set; }
        public string? strArea { get; set; }
        public string? strInstructions { get; set; }
        public string? strMealThumb { get; set; }
        public string? strTags { get; set; }
        public string? strYoutube { get; set; }
        public string? strIngredient1 { get; set; }
        public string? strIngredient2 { get; set; }
        public string? strIngredient3 { get; set; }
        private XmlSerializer Serializer = new XmlSerializer(typeof(Meal));

        public override string SerilizeXML()
        {
            var stringWriter = new StringWriter();

            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.idMeal} | {this.strMeal} | {this.strCategory} | {this.strArea} | {this.strIngredient1} | {this.strIngredient2} | {this.strIngredient3}");
            return sb.ToString();
        }
    }
    public class MealResponse
    {
        public List<Meal> meals { get; set; }
    }

}