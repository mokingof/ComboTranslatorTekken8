using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.Utilities;
using ComboTranslatorTekken8.Pages.Shared;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model.Parsing
{
    public class InputParser
    {
        private readonly Dictionary<string, InputCommand> inputMap;
        private readonly ComboContext comboContext = new();
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
            Console.WriteLine($"Parsing input: {inputString}");

            comboContext.ProcessInput(inputString);
            List<Token> tokens = comboContext.GetTokens();
            List<InputCommand?> storeParsedCommands = new();

            Console.WriteLine($"Tokens generated: {tokens.Count}");

            foreach (var token in tokens)
            {
                Console.WriteLine($"Processing token: Type={token.Type}, Value={token.Value}");

                if (inputMap.ContainsKey(token.Value))
                {
                    InputCommand command = inputMap[token.Value];
                    storeParsedCommands.Add(command);
                    Console.WriteLine($"Matched to InputCommand: {command}");
                }
                else
                {
                    Console.WriteLine($"No matching InputCommand found for token: {token.Value}");
                }
            }

            Console.WriteLine($"Total InputCommands generated: {storeParsedCommands.Count}");

            return storeParsedCommands;
        }
    }
}