using ComboTranslatorTekken8.Pages.Shared;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class InputParser
    {
        private readonly Dictionary<string, InputCommand> inputMap;

        public InputParser()
        {
            inputMap = new Dictionary<string, InputCommand>();
            InitializeInputMap();
        }
        private void InitializeInputMap()
        {
            var type = typeof(InputCommand);
            var values = Enum.GetValues(type);

            foreach (InputCommand value in values)
            {
                var memberInfo = type.GetMember(value.ToString()).FirstOrDefault();
                var attributes = memberInfo?.GetCustomAttributes<InputStringAttribute>(false);

                if (attributes != null)
                {
                    foreach (var attribute in attributes)
                    {
                        // Using reflection to populate the inputMap
                        inputMap[attribute.InputString] = value;
                    }
                }
            }

        }
        public List<InputCommand?> ParseInput(string inputString)
        {
            List<string> tokens = new();
            List<InputCommand?> storeParsedCommands = new();

            foreach (var token in tokens)
            {
                if (inputMap.ContainsKey(token))
                {
                    storeParsedCommands.Add(inputMap[token]);
                }
               
            }

            return storeParsedCommands;
        }
     
       

    }
}
