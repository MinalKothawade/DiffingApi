using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffingApi
{

    public class Diffs
    {
        public int Offset { get; set; }
        public int Length { get; set; }

        public  Diffs(int offset,int length)
        {
            this.Length = length;
            this.Offset = offset;
        }
    }

    public class ResponseData
    {
       
     
        public int StatusCode { get; set; }

        public string DiffResultType { get; set; }

        public List<Diffs> diffs { get; set; }
    }
}
