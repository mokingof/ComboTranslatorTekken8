namespace ComboTranslatorTekken8.Model.Utilities
{

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InputStringAttribute : Attribute
    {
        // Using attribute to associate string with each Inputcommand enum value.

        public string InputString { get; }

        public InputStringAttribute(string inputString)
        {
            InputString = inputString;
        }
    }
}
