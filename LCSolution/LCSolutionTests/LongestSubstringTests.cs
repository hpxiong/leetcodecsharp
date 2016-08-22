using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LCSolution.Tests
{
    [TestClass()]
    public class LongestSubstringTests
    {
        [TestMethod()]
        public void LengthOfLongestSubstringTest()
        {
            string input = string.Empty;
            int expected = -1;
            int actual = -1;
            LongestSubstring sl = new LongestSubstring();

            input = "hsenbppkqtpddbuotbbqcwivrfxjujjddntgeiq";
            expected = 11;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

            input = "abbba";
            expected = 2;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

            input = "ckilbkd";
            expected = 5;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

            input = "abcabcbb";
            expected = 3;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

            input = "aaabcccdeeefffhgdg";
            expected = 4;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

            input = "aba";
            expected = 2;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

            input = "abcdefg";
            expected = 7;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

            input = "abcdabcd";
            expected = 4;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

            input = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            expected = 94;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

            input = "Tempor lectus mauris integer eu, ut? Sagittis cursus. Augue proin, magna! Augue, sed urna scelerisque? Et! Proin et, lundium diam ut natoque augue porta elementum phasellus augue ac tempor nec rhoncus et scelerisque platea et nisi mattis vut pellentesque mauris, diam scelerisque, ut dignissim, amet? Vel facilisis elementum lacus eros et et tristique nisi dapibus montes massa arcu in scelerisque, eu natoque dis? Eros nascetur, ridiculus, nisi cum mauris turpis ac pid, porta purus, quis, nunc a vel! Vel adipiscing ultricies sociis vel! Sit, vel montes et quis. Lacus dis, habitasse in in montes hac turpis! Mattis sagittis? Scelerisque ut placerat lectus urna integer porttitor. Diam ultricies sociis. Sed est integer proin! Adipiscing non! Ut dis? Nunc augue porta odio.Dis mattis tincidunt ut, aliquet porta facilisis eros turpis. Mus cras scelerisque pellentesque turpis et auctor urna etiam habitasse? Tortor pellentesque ac, urna mauris, odio tristique nisi elit vut, cursus cum. Pid nunc elementum porta, nunc augue sociis quis scelerisque sed, augue penatibus dignissim ridiculus in rhoncus, urna urna parturient. Nec, adipiscing dignissim purus, augue. Sed lacus ultricies odio, non dictumst! Magna tincidunt, sit turpis eros vut ultrices enim, sit dignissim. Dictumst tortor tincidunt, augue natoque vut velit eros! Lundium eu. Est augue. Etiam nisi tincidunt ultrices, nascetur dapibus, porttitor nisi porta augue nunc cursus? Sociis proin urna sit, vel tortor? Turpis in, habitasse nascetur vel phasellus, vut rhoncus aliquam velit risus natoque. Tempor porttitor, sit magna, sed, enim.";
            expected = 13;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

            input = "tempor lectus mauris integer eu, ut? sagit";
            expected = 11;
            actual = sl.LengthOfLongestSubstring(input);
            Assert.AreEqual(expected, actual, input);

        }
    }
}
