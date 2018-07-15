using System;
using System.Collections;

namespace Reverse
{
    public class ReverseWords
    {
        static void Main(string[] args)
        {

            string input = "Cat and  dog";
            //string input = " Cat and  dog k ";
            //string input = "-1 1235-98 71924b , .w $*^*))&^%$*( $&";
            Console.WriteLine(input);

            string reversedStr = Reverse(input);
            Console.WriteLine(reversedStr);
            Console.ReadKey();
        }

        public static string Reverse(string input)
        {
            Stack stack = new Stack();
            Char[] chars = input.ToCharArray();
            Char[] target = new Char[chars.Length];
            int index = 0;

            for(int i =0;i< chars.Length; i++)
            {
                if(chars[i]!=' ')
                {
                    stack.Push(chars[i]);
                }
                else
                {
                    index = FlushStack(stack, target, index);
                    target[index] = ' ';
                    index++;
                }
            }
            index = FlushStack(stack, target, index);
            return new string(target);
        }

        private static int FlushStack(Stack stack, Char[] target, int index)
        {
            while (stack.Count != 0)
            {
                target[index] = (Char)stack.Pop();
                index++;
            }
            return index;
        }
    }
}
