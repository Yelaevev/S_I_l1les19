using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static bool SherlockValidString(string s)
        {
            bool Flag = false;
            if (s == null) return false;
            ////<<<проверка алфавита чтобы был латинским (строчные)|| (заглавные)>>>
            foreach (char test in s)
            {
                if ((((int)test >= 97) && ((int)test <= 122)) || (((int)test >= 65) && ((int)test <= 90)))
                {
                    Flag = true;

                }
                else return false;
            }

            List<int> Valid = new List<int>();
            int check = 0;
            int t = 0;
            int equal;
            bool flag;
            bool checkFlag;
            int board = s.Length;

            ////<<<сложение всех одинаковых букв и удаление онных, после сложения>>>
            if (Flag)
            { 
                while (t < board)
                {
                    check = 0;
                    equal = 0;
                    flag = true;
                    char temp = s[t];
                    while (equal < board)
                    {
                        checkFlag = true;
                        if (temp == s[equal])
                        {
                            check++;
                            s = s.Remove(equal, 1);
                            board = s.Length;
                            flag = false;
                            checkFlag = false;
                        }

                        if (checkFlag) equal++;
                    }

                    if (check != 0) Valid.Add(check);
                    if (flag) t++;

                }
                ////<<<поиск условия валидности>>>
                Valid.Sort();
                //foreach (int z in Valid) Console.Write(z + " ");
                //Console.WriteLine();
                if (Valid.Count == 1) return true;

                if (Valid.Count == 2)
                {
                    if ((Valid[0] == Valid[1]) || (Valid[1] - Valid[0] == 1)) return true;
                }

                if ((Valid[0] == Valid[1]) && (Valid[0] == Valid[Valid.Count - 1])) return true;
                if ((Valid[0] == Valid[1]) && (Valid[Valid.Count - 2] == Valid[Valid.Count - 1] - 1)) return true;
                if ((Valid[Valid.Count - 2] == Valid[Valid.Count - 1]) && (Valid[0] == Valid[1] - 1)) return true;
            }
            return false;
        }
        //static void Main(string[] args)
        //{
        //    string s = "xxyyzabc";
        //    Console.WriteLine(SherlockValidString(s));
           
        //}

    }
}
