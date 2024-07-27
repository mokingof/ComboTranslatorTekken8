using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class Tokenizer
    {
        //PrintCombo("b3,dash,2+3+1,ff4,ssl,UB1,d/f1+2+3");
        Regex SingleButton = new Regex(@"[1234]");
        Regex MultiButton = new Regex(@"^[1-4](\+[1-4]){1,3}$");
        


        public List<Token> TokenizeString(string input)
        {
            List<Token> Tokens = new();

            char[] delimiters = { ',' };  
            List<string> temp = input.Split(delimiters).ToList();

            for (int i = 0; i < temp.Count; i++)
            {

                if (temp[i].Any(char.IsDigit))
                {
                    if (i + 1 < temp.Count && temp[i + 1].Equals("+"))
                    {
                        var combination = CombinationButtons(temp[i]);
                        Tokens.Add(new Token(TokenType.CombinedButton, combination, i));

                    } 
                    else
                    {
                        var button = Button(input[i]);
                        Tokens.Add(new Token(TokenType.Button, button, i));
                    }
                }
                
                

            }
            return Tokens;
        }
        private string Button(char input)
        {
            Match match = SingleButton.Match(input.ToString());
            return match.Value;
        }
        private string CombinationButtons(string input)
        {   
            if (ContainsDuplicate(input))
            {
                throw new Exception("Error: Duplicate button input");
            }
            Match match = MultiButton.Match(input.ToString());
            return match.Value;
          
        }

        private string Directions(string input)
        {
            return null;

        }
        private string SpecialCommands(string input)
        {
            return null;
        }
        private string Separators(string input)
        {
            return null;
        }

        private bool ContainsDuplicate(string input)
        {
            return input.Distinct().Count() == input.Length;
           
        
        }
    }
}
