using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMASParser
{
    class Parse
    {
        List<float> noList = new List<float>();
        List<char> symb = new List<char>();
        static void Main(string[] args)
        {
            Parse p = new Parse();
            p.solve("1+1+1/2+1");
        
        }

        public void solve(string exp)
        {
            string no = "";
            exp = Reverse(exp);
            for(int i=0;i<exp.Length;i++)
            {

                Console.WriteLine("char ="+exp[i]);
                if(char.IsDigit(exp[i]))
                {
                    Console.WriteLine("is digit");
                    no +=exp[i];
                }
                else if(CheckSymbol(exp[i]))
                {
                    Console.WriteLine("is symbol");
                    char s = exp[i];

                    if (symb.Count != 0)
                    {
                        if (s.Equals(symb[symb.Count - 1]) )
                        {
                            Console.WriteLine("priority equl to prev");

                            if (!no.Equals(""))
                            {
                                Console.WriteLine(no);
                                float tempNum = float.Parse(no);
                                noList.Add(tempNum);
                                no = "";
                            }
                            symb.Add(s);
                        }
                        else
                        {
                            if (!no.Equals(""))
                            {
                                Console.WriteLine(no);
                                float tempNum = float.Parse(no);
                                noList.Add(tempNum);
                                no = "";
                            }
                            Console.Write("priority Check ...");
                            if (SymbPri(s) < SymbPri(symb[symb.Count - 1]))
                            {
                                Console.WriteLine("priority less, solving prior");
                                float a = noList[noList.Count - 1];
                                noList.RemoveAt(noList.Count - 1);
                                float b = noList[noList.Count - 1];
                                noList.RemoveAt(noList.Count - 1);

                                char prevSymbol = symb[symb.Count - 1];
                                symb.RemoveAt(symb.Count - 1);
                                float result = Calculate(a, b, prevSymbol);
                                Console.WriteLine(a + prevSymbol + b + " = " + result );
                                noList.Add(result);

                                i--;

                                
                            }
                            else
                            {
                                symb.Add(s);
                               
                            }

                        }
                    }
                    else
                    {
                        if (!no.Equals(""))
                        {
                            Console.WriteLine(no);
                            float tempNum = float.Parse(no);
                            noList.Add(tempNum);
                            no = "";
                        }
                        symb.Add(s);
                    }


                    
                }
                

                
            }
            noList.Add(int.Parse(no));
            while (noList.Count > 1)
            {
                Console.WriteLine("Solving while ...");
                float a = noList[noList.Count - 1];

                Console.WriteLine(a);

                noList.RemoveAt(noList.Count - 1);
                float b = noList[noList.Count - 1];

                Console.WriteLine(b);

                noList.RemoveAt(noList.Count - 1);

                char c = symb[symb.Count - 1];

                Console.WriteLine(c);

                symb.RemoveAt(symb.Count - 1);
                float result = Calculate(a, b, c);
                Console.WriteLine(" = " + result);
                noList.Add(result);

            }

            for(int j=0;j<noList.Count;j++)
            {
                Console.WriteLine(noList[j].ToString());

            }
            Console.ReadLine();
        }

        public bool CheckSymbol(char c)
        {
            if(c.Equals('+') || c.Equals('-') || c.Equals('*') || c.Equals('/'))
            {
                return true;
            }
            return false;

        }
       

        private int SymbPri(char c)
        {
            switch(c)
            {
                case '/':
                    {
                        return 4;
                        break;
                    }
                case '*':
                    {
                        return 3;
                        break;
                    }
                case '+':
                    {
                        return 2;
                        break;
                    }
                case '-':
                    {
                        return 1;
                        break;
                    }
                    
            }
            return 0;
        }

        private float Calculate(float a,float b, char sym)
        {
            switch(sym)
            {
                case '/':
                    {
                        return  a/b;
                       
                    }
                case '*':
                    {
                        return a*b;
                        
                    }
                case '+':
                    {
                        return a+b;
                        
                    }
                case '-':
                    {
                        return a-b;
                        
                    }
            }
            Console.WriteLine("No Legal symb Detected");
            return 0;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
