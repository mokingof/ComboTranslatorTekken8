using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Reflection;

namespace ComboTranslatorTekken8.Model
{
    public class InputParser
    {
        private readonly Dictionary<string, InputCommand> inputMap;

        public InputParser()
        {                                                               //CASE INSENSITIVE
            inputMap = new Dictionary<string, InputCommand>(StringComparer.Ordinal);
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
        public List<Input> ParseInput(string inputString)
        {
            var result = new List<Input>();
            //Split input string into tokens via spaces
            char[] delimiters = { ',', ' ' };
            var tokens = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (inputMap.TryGetValue(token, out var command))
                {
                    result.Add(new Input(command));
                }
                else
                {
                    throw new ArgumentException($"Invalid input: {token}");
                }
            }

            return result;
        }
    }
}
