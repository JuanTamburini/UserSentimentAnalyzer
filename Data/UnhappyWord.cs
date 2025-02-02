namespace UserSentiment.Data;
internal class UnhappyWord
{
	public string Word { get; set; } = string.Empty;
	public byte Weight { get; set; } = 0;

	public UnhappyWord(string word, byte weigth)
	{
		Word = word;
		Weight = weigth;
	}

	// Defino 3 casos: Insuficiente (1), Fastidioso (5), Enojado (10)
	// TODO: Se deberian grabar en base de datos la misma palabra en su versión plural, femenino y masculino ?
	// Estos registros hace que el método de comparación tome todas las versiones como posibles y aumente bastante el score por una sola palabra.
	// Tener frases armadas como "la concha de su madre" hace que la comparación por levenshtein no funcione.
	public static List<UnhappyWord> GetUnhappyWordsMock() => new List<UnhappyWord>
	{
		new("forro",5),
		new("puto",5),
		new("hijos de puta",10),
		new("concha",1),
		new("la concha de su madre",10),
		new("chorros",10),
		new("ladrones",5),
		new("ladron",5),
		new("ladri",5),
		new("inutiles",10),
		new("inutil",5),
		new("inservible",10),
		new("cagon",5),
		new("la puta que los parió",10),
		new("chanta",1),
		new("desconsiderados",1),
		new("pelotudo",10),
		new("boludo",5),
		new("gil",5),
		new("giles",5),
		new("salame",5),
		new("chupapija",10),
		new("pija",5),
		new("mogólico",10),
		new("trolo",5),
		new("gato",5),
		new("pajero",5),
		new("conchudo",5),
		new("conchudos",5),
		new("careta",5),
	};
}
