using System;
using System.Text;
using System.Xml.Serialization;

namespace RecipeFinder
{

    public class Meal : Recipe
    {
        public string Name { get; set; } = string.Empty;
        public string Category {  get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public string? Meal_thumb { get; set; }
        public string? Tags { get; set; }
        public string? Youtube { get; set; }
        public string Ingredient1 { get; set; } = string.Empty;
        public string? Ingredient2 { get; set; }
        public string? Ingredient3 { get; set; }
        public string? Ingredient4 { get; set; }
        public string? Ingredient5 { get; set; }
        public string? Ingredient6 { get; set; }
        public string? Ingredient7 { get; set; }
        public string? Ingredient8 { get; set; }
        public string? Ingredient9 { get; set; }
        public string? Ingredient10 { get; set; }
        public string? Ingredient11 { get; set; }
        public string? Ingredient12 { get; set; }
        public string? Ingredient13 { get; set; }
        public string? Ingredient14 { get; set; }
        public string? Ingredient15 { get; set; }
        public string Measure1 { get; set; } = string.Empty;
        public string? Measure2 { get; set; }
        public string? Measure3 { get; set; }
        public string? Measure4 { get; set; }
        public string? Measure5 { get; set; }
        public string? Measure6 { get; set; }
        public string? Measure7 { get; set; }
        public string? Measure8 { get; set; }
        public string? Measure9 { get; set; }
        public string? Measure10 { get; set; }
        public string? Measure11 { get; set; }
        public string? Measure12 { get; set; }
        public string? Measure13 { get; set; }
        public string? Measure14 { get; set; }
        public string? Measure15 { get; set; }
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
            // sb.Append($"{this.idMeal} | {this.strMeal} | {this.strCategory} | {this.strArea} | {this.strIngredient1} | {this.strIngredient2} | {this.strIngredient3}");
            sb.Append($"\n\nName: {Name}\t|" +
                      $"\tCategory: {Category}\t|" +
                      $"\tArea: {Area}" +
                      $"\nInstructions: \n{Instructions}" +
                      $"\nThumbnail: {Meal_thumb}" +
                      $"\nTags: {Tags}" +
                      $"\nYoutube: {Youtube}" +
                      $"\nIngredients:\t{Ingredient1}\t|" +
                      $"\t{Ingredient2}\t|" +
                      $"\t{Ingredient3}\t|" +
                      $"\t{Ingredient4}\t|" +
                      $"\t{Ingredient5}\t|" +
                      $"\n\t\t{Ingredient6}\t|" +
                      $"\t{Ingredient7}\t|" +
                      $"\t{Ingredient8}\t|" +
                      $"\t{Ingredient9}\t|" +
                      $"\t{Ingredient10}\t|" +
                      $"\n\t\t{Ingredient11}\t|" +
                      $"\t{Ingredient12}\t|" +
                      $"\t{Ingredient13}\t|" +
                      $"\t{Ingredient14}\t|" +
                      $"\t{Ingredient15}\t|" +
                      $"\n\nMeasures:\t{Measure1}\t|" +
                      $"\t{Measure2}\t|" +
                      $"\t{Measure3}\t|" +
                      $"\t{Measure4}\t|" +
                      $"\t{Measure5}\t|" +
                      $"\n\t\t{Measure6}\t|" +
                      $"\t{Measure7}\t|" +
                      $"\t{Measure8}\t|" +
                      $"\t{Measure9}\t|" +
                      $"\t{Measure10}\t|" +
                      $"\n\t\t{Measure11}\t|" +
                      $"\t{Measure12}\t|" +
                      $"\t{Measure13}\t|" +
                      $"\t{Measure14}\t|" +        
                      $"\t{Measure15}"); 
            return sb.ToString();
        }
    }
    public class MealResponse
    {
        public List<Meal> meals { get; set; }
    }

}