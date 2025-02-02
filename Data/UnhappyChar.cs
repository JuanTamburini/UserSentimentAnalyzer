using System.Collections.Generic;

namespace UserSentiment.Data;
internal class UnhappyChar
{
	public string SpecialChars { get; set; } = string.Empty;
	public byte Weight { get; set; } = 0;

	public UnhappyChar(string specialChars, byte weigth)
	{
		SpecialChars = specialChars;
		Weight = weigth;
	}

    // Defino 4 casos: Positivo (0), Neutral (5), Negativo (10), Muy negativo (15 o 20)
	public static List<UnhappyChar> GetUnhappyCharsMock = new List<UnhappyChar>
	{
	    new("\U0001F600", 0), // Grinning Face 😀
        new("\U0001F601", 0), // Grinning Face with Smiling Eyes 😁
        new("\U0001F602", 0), // Face with Tears of Joy 😂
        new("\U0001F603", 0), // Smiling Face with Open Mouth 😃
        new("\U0001F604", 0), // Smiling Face with Open Mouth and Smiling Eyes 😄
        new("\U0001F605", 0), // Smiling Face with Open Mouth and Cold Sweat 😅
        new("\U0001F606", 0), // Smiling Face with Open Mouth and Tightly-Closed Eyes 😆
        new("\U0001F607", 0), // Smiling Face with Halo 😇
        new("\U0001F608", 0), // Smiling Face with Horns 😈
        new("\U0001F609", 0), // Winking Face 😉
        new("\U0001F60A", 0), // Smiling Face with Smiling Eyes 😊
        new("\U0001F60B", 0), // Face Savoring Delicious Food 😋
        new("\U0001F60C", 0), // Relieved Face 😌
        new("\U0001F60D", 0), // Smiling Face with Heart-Eyes 😍
        new("\U0001F60E", 0), // Smiling Face with Sunglasses 😎
        new("\U0001F60F", 0), // Smirking Face 😏
        new("\U0001F610", 5), // Neutral Face 😐
        new("\U0001F611", 10), // Expressionless Face 😑
        new("\U0001F612", 10), // Unamused Face 😒
        new("\U0001F613", 10), // Face with Cold Sweat 😓
        new("\U0001F614", 5), // Pensive Face 😔
        new("\U0001F615", 5), // Confused Face 😕
        new("\U0001F616", 0), // Confounded Face 😖
        new("\U0001F617", 0), // Kissing Face 😗
        new("\U0001F618", 0), // Face Throwing a Kiss 😘
        new("\U0001F619", 0), // Kissing Face with Smiling Eyes 😙
        new("\U0001F61A", 0), // Kissing Face with Closed Eyes 😚
        new("\U0001F61B", 0), // Face with Stuck-Out Tongue 😛
        new("\U0001F61C", 0), // Face with Stuck-Out Tongue and Winking Eye 😜
        new("\U0001F61D", 0), // Face with Stuck-Out Tongue and Tightly-Closed Eyes 😝
        new("\U0001F61E", 10), // Disappointed Face 😞
        new("\U0001F61F", 5), // Worried Face 😟
        new("\U0001F620", 20), // Angry Face 😠
        new("\U0001F621", 20), // Pouting Face 😡
        new("\U0001F622", 10), // Crying Face 😢
        new("\U0001F623", 5), // Persevering Face 😣
        new("\U0001F624", 10), // Face with Look of Triumph 😤
        new("\U0001F625", 5), // Disappointed but Relieved Face 😥
        new("\U0001F626", 5), // Frowning Face with Open Mouth 😦
        new("\U0001F627", 5), // Anguished Face 😧
        new("\U0001F628", 5), // Fearful Face 😨
        new("\U0001F629", 10), // Weary Face 😩
        new("\U0001F62A", 5), // Sleepy Face 😪
        new("\U0001F62B", 10), // Tired Face 😫
        new("\U0001F62C", 5), // Grimacing Face 😬
        new("\U0001F62D", 15), // Loudly Crying Face 😭
        new("\U0001F62E", 5), // Face with Open Mouth 😮
        new("\U0001F62F", 5), // Hushed Face 😯
        new("\U0001F630", 10), // Face with Open Mouth and Cold Sweat 😰
        new("\U0001F631", 10), // Face Screaming in Fear 😱
        new("\U0001F632", 5), // Astonished Face 😲
        new("\U0001F633", 0), // Flushed Face 😳
        new("\U0001F634", 5), // Sleeping Face 😴
        new("\U0001F635", 5), // Dizzy Face 😵
        new("\U0001F636", 5), // Face Without Mouth 😶
        new("\U0001F637", 5), // Face with Medical Mask 😷
        new("\U0001F638", 0), // Grinning Cat Face with Smiling Eyes 😸
        new("\U0001F639", 0), // Cat Face with Tears of Joy 😹
        new("\U0001F63A", 0), // Smiling Cat Face with Open Mouth 😺
        new("\U0001F63B", 0), // Smiling Cat Face with Heart-Shaped Eyes 😻
        new("\U0001F63C", 0), // Cat Face with Wry Smile 😼
        new("\U0001F63D", 0), // Kissing Cat Face with Closed Eyes 😽
        new("\U0001F63E", 0), // Pouting Cat Face 😾
        new("\U0001F63F", 0), // Crying Cat Face 😿
        new("\U0001F640", 0), // Weary Cat Face 🙀
        new("\U0001F641", 10), // Slightly Frowning Face 🙁
        new("\U0001F642", 0), // Slightly Smiling Face 🙂
        new("\U0001F643", 0), // Upside-Down Face 🙃
        new("\U0001F644", 10), // Face with Rolling Eyes 🙄
        new("\U0001F645", 10), // Face with No Good Gesture 🙅
        new("\U0001F646", 0), // Face with OK Gesture 🙆
        new("\U0001F647", 5), // Person Bowing Deeply 🙇
        new("\U0001F648", 0), // See-No-Evil Monkey 🙈
        new("\U0001F649", 0), // Hear-No-Evil Monkey 🙉
        new("\U0001F64A", 0), // Speak-No-Evil Monkey 🙊
        new("\U0001F64B", 0), // Happy Person Raising One Hand 🙋
        new("\U0001F64C", 0), // Person Raising Both Hands in Celebration 🙌
        new("\U0001F64D", 0), // Person Frowning 🙍
        new("\U0001F64E", 0), // Person with Pouting Face 🙎
        new("\U0001F64F", 0)  // Folded Hands 🙏
	};
}
