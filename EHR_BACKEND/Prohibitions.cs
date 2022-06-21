namespace EHR_BACKEND
{
    public class Prohibitions
    {
        static string [] palabras = {
            "Idiota","","","","","","","","","","","","","","","","","","","",
            "","","","","","","","","","","","","","","","","","","","",
            "","","","","","","","","","","","","","","","","","","","",
            "","","","","","","","","","","","","","","","","","","","",
        };
        public static string validateName(string word)
        {
            foreach (string c in palabras)
            {
                if(c == word)
                {
                    word = "Invalid";
                }
            }

            return word;
        }
        
    }
}
