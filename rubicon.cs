using System;
using System.Collections.Generic;
using System.Linq;

class Rubicon
{ 
    public static void Main() 
    {   
//        List<char> left = new List<char> {'S', 'S', 'S', 'T', 'T', 'T'};            // 左岸
        List<char> left = new List<char> {'S'};            // 左岸
        List<char> right = new List<char>{};                                        // 右岸
        List<string> patternList = new List<string> {"S", "T", "SS", "ST", "TT"};   // 渡るパターン
        List<string> process = new List<string>();                                  // 渡り方
        bool isFinish = false;                                                      // 右岸に渡りきったか

        Rubicon rubicon = new Rubicon();

        while (!isFinish) {
            foreach (string pattern in patternList) {
                
                try {
                    // 川を渡る
                    rubicon.crossRiver(left, right, pattern);
                } catch (ArgumentOutOfRangeException) {
                    continue;
                }
                
                // 両岸が安全か？
                if (!rubicon.isSafe(left) || !rubicon.isSafe(right)) {
                    continue;
                }
                Console.WriteLine(pattern);
                process.Add(pattern);
                Console.WriteLine("とおた");
                // 全員が右岸へ渡りきったか？
                isFinish = rubicon.isEnd(right);
                if (isFinish) {
                    break;
                }
            }
        }

       Console.WriteLine(process);
    }

    // 兵士が巨人に食べられないか
    private bool isSafe(List<char> c)
    {
        bool result = true;
        int sCount, tCount;
        Rubicon rubicon = new Rubicon();
        sCount = rubicon.countNumber(c, 'S');
        tCount = rubicon.countNumber(c, 'T');

        // 兵士 < 巨人のとき
        if (sCount < tCount) {
            result = false;
        }

        return result;
    }

    // 指定したものの数を数える
    private int countNumber(List<char> c, char s)
    {

        int count = (from x in c 
                    where x == s
                    select x).Count();
        return count;
    }

    // 全員がルビコン川を渡れたか
    private bool isEnd(List<char> c)
    {
        return c.Count == 1;
    }

    // 川を渡る
    private void crossRiver(List<char> from, List<char> To, string pattern)
    {

        switch (pattern) {
            case "S":
                from.RemoveAt(from.IndexOf('S'));
                To.Add('S');
                break;
            case "T":
                from.RemoveAt(from.IndexOf('T'));
                To.Add('T');
                break;
            case "SS":
                from.RemoveAt(from.IndexOf('S'));
                from.RemoveAt(from.IndexOf('S'));
                To.Add('S');
                To.Add('S');
                break;
            case "TT":
                from.RemoveAt(from.IndexOf('T'));
                from.RemoveAt(from.IndexOf('T'));
                To.Add('T');
                To.Add('T');
                break;
            case "ST":
                from.RemoveAt(from.IndexOf('S'));
                from.RemoveAt(from.IndexOf('T'));
                To.Add('S');
                To.Add('T');
                break;
        }
    }


} 