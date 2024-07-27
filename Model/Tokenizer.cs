using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class Tokenizer
    {
        //PrintCombo("b3,dash,2+3+1,ff4,ssl,UB1,d/f1+2+3");
        Regex SingleButton = new Regex(@"[1234]");
        Regex SingleDirection = new Regex(@"[dfubDFUB]");

        Regex MultiButton = new Regex(@"^[1-4](\+[1-4]){1,3}$");


        Match Match;


        public List<Token> TokenizeString(string input)
        {
            List<Token> Tokens = new();

            char[] delimiters = { ' ' };
            List<string> temp = input.Split(delimiters).ToList();

            for (int i = 0; i < temp.Count; i++)
            {

                if (temp[i].Any(char.IsDigit))
                {
                    if (temp[i].Contains("+"))
                    {
                        var combination = CombinationButtons(temp[i]);
                        Tokens.Add(new Token(TokenType.CombinedButton, combination, i));
                    }
                    else
                    {
                        var button = Button(temp[i]);
                        Tokens.Add(new Token(TokenType.Button, button, i));
                    }
                }
                else if (!temp[i].Any(char.IsDigit) && temp[i].Length == 1)
                {
                    var direction = Directions(temp[i]);
                    Tokens.Add(new Token(TokenType.Direction, direction, i));
                }
            }
            return Tokens;
        }
        private string Button(string input)
        {
            Match = SingleButton.Match(input);

            return Match.Value;
        }
        private string CombinationButtons(string input)
        {
            Console.WriteLine(input);
            if (ContainsNoDuplicate(input))
            {
                Match = MultiButton.Match(input);
                return Match.Value;
                
            }

            return "Error: Duplicate button input";
        }
        private string Directions(string input)
        {
            Match = SingleDirection.Match(input);
            return Match.Value;
        }
        private string SpecialCommands(string input)
        {
            return null;
        }
        private string Separators(string input)
        {
            return null;
        }

        private bool ContainsNoDuplicate(string input)
        {
            return input.Replace("+", "").Distinct().Count() == input.Replace("+","").Length;

        }

        private bool IsCombinedInput(string input)
        {
            bool hasDirection = input.Any(char.IsLetter);
            bool hasButton = input.Any(char.IsDigit);
            return hasDirection && hasButton;
        }
    }
}
