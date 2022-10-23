using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Naumenko.Console.Note14
{
    public  class TelephonNumber
    {
        private int _indexArray = 0;
        public int IndexArray 
        {
            get
            {
                return _indexArray;
            }
            set
            {
                if(value >= 0)
                {
                    _indexArray = value;
                }
                
            }
        }
        public int TelephonNum { get; set; }
        public TelephonNumber(int indexArray, int telephonNum)
        {
            IndexArray = indexArray;
            TelephonNum = telephonNum;
        }   
        public static TelephonNumber CreateTelephonNum(ref int indexArray, ref int telephonNum)
        {
            return new TelephonNumber(indexArray, telephonNum);
        }
    }
}
