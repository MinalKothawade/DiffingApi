using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffingApi
{
    public class DiffingServices
    {


        public static bool CheckStringSize(string Leftstring, string RightString)
        {
            try
            { 
            if(Leftstring.Length!=RightString.Length)
            {
                return false;
            }

            
            }
            catch(Exception ex)
            {

            }

            return true;
        }


        public static bool CheckStringEquality(string Leftstring, string RightString)
        {
            try
            {
                if (Leftstring == RightString)
            {
                return true;
            }
            }
            catch (Exception ex)
            {

            }

            return false;
        }
        /// <summary>
        /// This function is checking difference between input and providing number changes required to match the document..
        /// For Example LeftString="Car Lexus" and RightString="Cur Lexas"
        /// Expected Output will be diifs[0]:{ offset=1 , Length=1},diifs[1]:{ offset=7 , Length=2}
        /// offset is presenting the length of string and Length is representing number of changes required to match the string till that offset 
        /// </summary>
        /// <param name="Leftstring"></param>
        /// <param name="RightString"></param>
        /// <returns> List changes required to match the string of both sides</returns>
        public static List<Diffs> CheckDiffing(string Leftstring, string RightString)
        {

            try
            {
                var Listobj = new List<Diffs>();
                char[] LeftCharArr = Leftstring.ToArray();
                char[] RightCharArr = RightString.ToArray();

                int length = 0;
                
                for (int i=0;i<LeftCharArr.Length;i++)
                {
                    if(LeftCharArr[i]!=RightCharArr[i])
                    {
                        length++;
                        Listobj.Add(new Diffs(i, length));
                    }
                }

                

                return Listobj;
            }
            catch (Exception ex)
            {

            }

            return null;

        }
    }
}
