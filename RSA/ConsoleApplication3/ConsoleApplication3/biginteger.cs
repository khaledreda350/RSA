using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class bigdiv
    {
        public string q, r;
    }
    class biginteger
    {

        public static bool check(string a, string b)
        {
            int size1 = a.Length, size2 = b.Length;
            if (size1 < size2)
                return true;
            else if (size1 == size2)
            {
                int x, y;
                for (int i = 0; i < size1; i++)
                {
                    x = (int)a[i] - '0';
                    y = (int)b[i] - '0';
                    if (x < y)
                        return true;
                    else if (x == y)
                        continue;
                    else break;
                }
            }
            return false;
        }


        public static string add(string p, string d)
        {
            int cary = 0;
            int size1 = p.Length;
            int size2 = d.Length;
            int max = Math.Max(size1, size2);
            char[] s1 = p.ToCharArray();
            char[] s2 = d.ToCharArray();
            Array.Reverse(s1);
            Array.Reverse(s2);
            string l = new string(s1);
            string m = new string(s2);
            StringBuilder s = new StringBuilder();
            char w;
            if (size1 < size2)
            {
                l = l.PadRight(m.Length, '0');
            }
            else
            {
                m = m.PadRight(l.Length, '0');

            }
            for (int ii = 0; ii < max; ii++)
            {

                int n1 = (int)l[ii] - '0';
                int n2 = (int)m[ii] - '0';
                int sum;
                if (n1 + n2 + cary >= 10)
                {
                    sum = n1 + n2 + cary - 10;
                    w = (char)(sum + '0');
                    s.Append(w);
                    cary = 1;
                }
                else
                {

                    sum = n1 + n2 + cary;
                    w = (char)(sum + '0');
                    s.Append(w);
                    cary = 0;
                }


            }
            if (cary == 1)
                s.Append('1');

            string ss = s.ToString();
            char[] c = ss.ToCharArray();
            Array.Reverse(c);
            int i = 0;
            while (c[i] == '0')
            {
                if (i < c.Length - 1)
                    i++;
                else
                    break;
            }
            string ll = new string(c);
            string v = ll.Substring(i, ll.Length - i);
            return v;
        }

        public static string sub(string p, string d)
        {

            int cary = 0;
            int size1 = p.Length;
            int size2 = d.Length;
            int max = Math.Max(size1, size2);
            char[] s1 = p.ToCharArray();
            char[] s2 = d.ToCharArray();
            Array.Reverse(s1);
            Array.Reverse(s2);
            string l = new string(s1);
            string m = new string(s2);
            StringBuilder s = new StringBuilder();
            char w;
            if (size1 > size2)
            {
                m = m.PadRight(l.Length, '0');

            }
            else
            {
                l = l.PadRight(m.Length, '0');

            }
            for (int i = 0; i < size2; i++)
            {
                int n1 = (int)l[i] - '0';
                int n2 = (int)m[i] - '0';
                int sum = n1 - n2 - cary;

                if (sum < 0)
                {
                    sum = sum + 10;

                    cary = 1;
                }
                else
                {
                    cary = 0;
                }
                w = (char)(sum + '0');

                s.Append(w);
            }

            for (int i = size2; i < size1; i++)
            {
                int n1 = (int)l[i] - '0';
                int sum = n1 - cary;

                if (sum < 0)
                {
                    sum = sum + 10;
                    cary = 1;
                }
                else
                    cary = 0;

                w = (char)(sum + '0');
                s.Append(w);
            }

            string ss = s.ToString();
            char[] res = ss.ToCharArray();
            Array.Reverse(res);
            int y = 0;
            while (res[y] == '0')
            {
                if (y < res.Length - 1)
                    y++;
                else
                    break;
            }
            string ll = new string(res);
            string v = ll.Substring(y, ll.Length - y);
            return v;


        }

        public static string mult(string x, string y)
        {
            int len_x = x.Length;
            int len_y = y.Length;
            if (len_x > len_y)
            {
            //    char[] sty = y.ToCharArray();
            //    Array.Reverse(sty);
            //    string s1 = new string(sty);
            //    s1 = s1.PadRight(x.Length, '0');
            //    sty = s1.ToCharArray();
            //    Array.Reverse(sty);
            //    y = new string(sty);
            y=y.PadLeft(len_x,'0');    
        }
            else if (len_y > len_x)
            {
                x = x.PadLeft(len_y, '0');              
                //char[] sty = x.ToCharArray();
                //Array.Reverse(sty);
                //string s1 = new string(sty);
                //s1=s1.PadRight(y.Length,'0');
                //sty = s1.ToCharArray();
                //Array.Reverse(sty);
                //x = new string(sty);
    }
            int le_x = x.Length;
            int le_y = y.Length;

            if (le_x == 1 || le_y == 1)
            {
                return Convert.ToString((int.Parse(x) * int.Parse(y)));
            }
            string a = x.Substring(0, le_x / 2);
            string b = x.Substring(le_x / 2, le_x - (le_x / 2));

            string c = y.Substring(0, le_y / 2);
            string d = y.Substring(le_y / 2, le_y - (le_y / 2));
           
            string calc1 = mult(a, c);
            string calc2 = mult(b, d);
            string step_3 = mult(add(a, b), add(c, d));

            string z = sub(step_3, add(calc1, calc2));
            if (le_x % 2 == 1)
            {
                //for (int i = 0; i <= le_x; i++)
                //{
                //    calc1 += "0";
                //}
                int len_calc1 = le_x + calc1.Length + 1;
                calc1=calc1.PadRight( len_calc1, '0');
            }
            else
            {
                //for (int i = 0; i < le_x; i++)
                {
                //    calc1 += "0";
                    int len_calc1 = le_x + calc1.Length;
               calc1= calc1.PadRight(len_calc1 , '0');
            }
        }
            int l_x = (le_x + 1) / 2;
            //for (int i = 0; i < le_x; i++)
            //{
            //    z += "0";
                int len_z = l_x + z.Length ;
            z=z.PadRight(len_z,'0');
            //}

            return add(add(calc1, calc2), z);


        }

        public static bigdiv div(string a, string b)
        {
            bigdiv big = new bigdiv();
            if (check(a, b)){
            big.q="0";big.r=a;
                return big;
            }

           big =div(a,add(b,b));
            big.q = add(big.q, big.q);
            if (check(big.r, b))
            {
                return big;
            }
            else
            {
               big.q=add(big.q, "1"); big.r=sub(big.r, b);
               return big;
            }
        }
  
        public static string modofpow(string n, string b,string mod)
        {
            bigdiv big;
            if (b.Equals("1"))
            {
                big = div(n, mod);
                return big.r;
            }
                big=div(b,"2");
            string p = modofpow(n,big.q,mod);

            if (big.r.Equals("0"))
            {
               big = div(p, mod);
                return div(mult(big.r, big.r), mod).r;
            }

            else
            {
                big = div(p, mod);
                bigdiv biger = div(n, mod);
              // return div(mult(mult(big.r, big.r), biger.r), mod).r;
              return div(mult(div(mult(big.r, big.r), mod).r, biger.r), mod).r;
            }
        }

        public static string encryption(string n, string e, string m )
        {
            return modofpow(m, e, n);
        }

        public static string string_encryption(string n, string e, string m ) {
            int m1 = m.Length;
            string b = "";
            for (int i = 0; i < m1; i++)
            {
                int r = (int)m[i];
                string s = Convert.ToString(r);
                string asc = "";
                asc=modofpow(s, e, n);
                b+=asc;
                
            }
            return b;
        }

        public static string decryption(string n, string d, string m)
        {
            return modofpow(m, d, n);
        }

        public static string string_decryption(string n, string d, string m) 
        {

            string zz= modofpow(n, d, m);
       
            int y=zz.Length;
            string xx = " ";
            for (int i=0;i<y;i++)
            {
       
                xx+= (char)(zz[i]- '0');
            }
            return xx;
        }

    }
}
    





