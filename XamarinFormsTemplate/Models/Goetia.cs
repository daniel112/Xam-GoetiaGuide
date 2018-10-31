using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace GoetiaGuide.Core.Models {

    [Flags]
    public enum Direction {
        NotSet,
        North,
        East,
        South,
        West
    }

    [DynamoDBTable("Goetias")]
    public class Goetia : ModelBase {

        [DynamoDBHashKey]
        public int ID { get; set; }
        [DynamoDBProperty]
        public string Name { get; set; }
        [DynamoDBProperty]
        public string Level { get; set; }
        [DynamoDBProperty]
        public Direction Direction { get; set; } // NESW
        [DynamoDBProperty]
        public string Tarot { get; set; }
        [DynamoDBProperty]
        public List<string> Planet { get; set; }
        [DynamoDBProperty]
        public string Metal { get; set; }
        [DynamoDBProperty]
        public List<string> Element { get; set; } // Ex: Earth, Fire
        [DynamoDBProperty]
        public string Color { get; set; }
        [DynamoDBProperty]
        public string Plant { get; set; }
        [DynamoDBProperty]
        public string Incense { get; set; }
        [DynamoDBProperty]
        public string Zodiac { get; set; }
        [DynamoDBProperty]
        public string DemonicEnn { get; set; }
        [DynamoDBProperty]
        public string Description { get; set; }
        [DynamoDBProperty]
        public List<string> Keywords { get; set; }
        [DynamoDBProperty]
        public string ImageURL { get; set; }

        public Goetia(int id, string name, string level, Direction direction, string tarot, List<string> planet, string metal,
                      List<string>element, string color, string plant, string incense, string zodiac, string demonicEnn,
                      List<string>keywords, string imageURL, string description) {
            this.ID = id;
            this.Name = name;
            this.Level = level;
            this.Direction = direction;
            this.Tarot = tarot;
            this.Plant = plant;
            this.Planet = planet;
            this.Metal = metal;
            this.Element = element;
            this.Color = color;
            this.Incense = incense;
            this.Zodiac = zodiac;
            this.DemonicEnn = demonicEnn;
            this.Keywords = keywords;
            this.ImageURL = imageURL;
            this.Description = description;

        }
        public Goetia() {
        }
    }
}
