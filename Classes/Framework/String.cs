using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework
{
	public class StringService
    {
        /// <summary>
        /// Devuelve el listado de todas las palabras dentro de text que tienen el prefijo determinado en prefix. Las palabras pueden incluir letras de a-z y números
        /// </summary>
        /// <param name="text">Texto en donde se va a buscar las coincidencias</param>
        /// <param name="prefix">Prefijo con el que deben empezar todas las coincidencias.</param>
        /// <param name="specialCharactersIncluded">Todos los caracters especiales a incluir todos juntos. Ejemplo si se quiere incluir el (.) y tambien el ($): .$</param>
        /// <returns>Array con todas las coincidencias. Tener en cuenta que estan ordenadas por orden de aparición y no quita las repetidas.</returns>
        public static string[] GetAllWordMatchesAfterPrefix(string text, string prefix, string specialCharactersIncluded = "")
        {
            return (from Match match in Regex.Matches(text, prefix + "[A-Za-z0-9" + specialCharactersIncluded + "]*") select match.Value).ToArray();
        }

        public static string RemoveAllUrls(string text)
        {
            var pattern = @"(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?";
            foreach (Match match in Regex.Matches(text, pattern))
                text = text.Replace(match.Value, string.Empty);
            return text;
        }

        public static string ReplaceCharactersWithDiaeresisOrAccent(string text)
        {
            // Normalize the string to Unicode normalization form D (NFD) to decompose accented characters.
            var normalizedString = text.Normalize(NormalizationForm.FormD);

            // Create a string builder to build the final result.
            var result = new StringBuilder();

            foreach (var c in normalizedString)
            {
                // If the character is not a diacritic, add it to the result.
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        public static string RemoveNonNumericCharacters(string text)
        {
            return Regex.Replace(text, "[^0-9]", "");
        }

        public static int ComputeLevenshteinDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                else
                    return t.Length;
            }
            else if (string.IsNullOrEmpty(t))
                return s.Length;
            else
            {
                int n = s.Length;
                int m = t.Length;
                int[,] d = new int[n + 1, m + 1];

                // initialize the top and right of the table to 0, 1, 2, ...
                for (int i = 0; i <= n; d[i, 0] = i++) ;
                for (int j = 1; j <= m; d[0, j] = j++) ;

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                        int min1 = d[i - 1, j] + 1;
                        int min2 = d[i, j - 1] + 1;
                        int min3 = d[i - 1, j - 1] + cost;
                        d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                    }
                }
                return d[n, m];
            }
        }
    }
}