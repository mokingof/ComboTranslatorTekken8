using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class Tokenizer
    {
        Regex Button = new Regex(@"[1-4]");
        Regex Direction = new Regex(@"[1-4]");
        



        public List<Token> TokenizeString(string input)
        {
            List<Token> Tokens = new();
            var currentPosition = 0;

            while (currentPosition < input.Length)
            {
                if (char.IsDigit(input[currentPosition]))
                {
                    string value = FoundNumber(input[currentPosition]);
                    Tokens.Add(new(TokenType.Button, value, currentPosition));
                    currentPosition++;
                }


                currentPosition++;
            }
            return Tokens;
        }
        private string FoundNumber(char c)
        {
            Match match = Button.Match(c.ToString());
            return match.Value;   
            
        }

    }
}
