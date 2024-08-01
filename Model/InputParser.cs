using ComboTranslatorTekken8.Pages.Shared;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class InputParser
    {
        private readonly Dictionary<string, InputCommand> inputMap;
        private readonly ComboContext comboContext;
        public InputParser()
        {
            inputMap = new Dictionary<string, InputCommand>();
            comboContext = new ComboContext();
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
            ResetContext();
            comboContext.ProcessInput(inputString);
            List<Token> tokens = comboContext.Tokens;
            List<InputCommand?> storeParsedCommands = new();

            foreach (var token in tokens)
            {
                if (inputMap.ContainsKey(token.Value))
                {
                    storeParsedCommands.Add(inputMap[token.Value]);
                }
            }
            return storeParsedCommands;
        }
        private void ResetContext()
        {
            comboContext.Reset(); 
        }
    }
}
