// See https://aka.ms/new-console-template for more information

using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
namespace Test
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class SkillAttribute : Attribute
    {
        public SkillAttribute(string name, int min, int max)
        {
            Name = name;
            Min = min;
            Max = max;
        }

        public string Name { get; private set; }
        public int Min { get; private set; }
        public int Max { get; private set; }
        public bool IsValid(object obj)
        {
            return (int)obj > Min && (int)obj < Max;
        }

    }
    public class Player
    {
        public string Name { get; set; }

        [Skill(nameof(Age), 20, 40)]
        public int Age { get; set; }

        [Skill(nameof(Speed), 60, 100)]
        public int Speed { get; set; }

        [Skill(nameof(Power), 40, 100)]
        public int Power { get; set; }

        [Skill(nameof(BallControl), 70, 100)]
        public int BallControl { get; set; }

        [Skill(nameof(Age), 30, 100)]
        public int Skill { get; set; }

        public Player(string name, int age, int speed, int power, int ballControl, int skill)
        {
            Name = name;
            Age = age;
            Speed = speed;
            Power = power;
            BallControl = ballControl;
            Skill = skill;
        }

        public class PlayerValidator
        {
            public static List<ErroMessage> Validate(Player player)
            {
                List<ErroMessage> erroMessages = new List<ErroMessage>();
                PropertyInfo[] propertyInfos = typeof(Player).GetProperties();
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    var SkillAttributes = propertyInfo.GetCustomAttributes<SkillAttribute>();
                    object value = propertyInfo.GetValue(player, null);
                    if (SkillAttributes != null)
                    {
                        foreach (var attribute in SkillAttributes)
                        {
                            if (!attribute.IsValid(value))
                                erroMessages.Add(new ErroMessage(nameof(propertyInfo), $"{attribute.Name} must be between {attribute.Min} and {attribute.Max}. Current value: {value}"));
                        }

                    }
                }
                return erroMessages;
            }
        }
        public class ErroMessage
        {
            public string Name;
            public string Description;

            public ErroMessage(string name, string description)
            {
                Name = name;
                Description = description;
            }
            public override string ToString()
            {
                return $"{Name}: {Description}";
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Player[] players = { new Player("Messi", 20, 50, 100, 60, 70), new Player("Ronaldo", 5, 40, 65, 44, 8), new Player("Kaka", 5, 10, 65, 44, 8) };
                List<List<ErroMessage>> messages = new List<List<ErroMessage>>();
                foreach (Player player in players)
                {
                    messages.Add(PlayerValidator.Validate(player));
                }
                foreach(List<ErroMessage> message in messages)
                {
                    foreach (ErroMessage erroMessage in message)
                        Console.WriteLine(erroMessage.ToString());
                }
            }
        }

    }
}
