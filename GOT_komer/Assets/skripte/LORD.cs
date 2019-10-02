using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.skripte
{
    class LORD
    {
        string LordName;
        string LordTroopTier;
        string LordTotalTroops;
        string LordMarchSize;

        public string LordName1
        {
            get
            {
                return LordName;
            }

            set
            {
                LordName = value;
            }
        }

        public string LordTroopTier1
        {
            get
            {
                return LordTroopTier;
            }

            set
            {
                LordTroopTier = value;
            }
        }

        public string LordTotalTroops1
        {
            get
            {
                return LordTotalTroops;
            }

            set
            {
                LordTotalTroops = value;
            }
        }

        public string LordMarchSize1
        {
            get
            {
                return LordMarchSize;
            }

            set
            {
                LordMarchSize = value;
            }
        }

        public LORD(string lordName, string lordTroopTier, string lordTotalTroops, string lordMarchSize)
        {
            LordName1 = lordName;
            LordTroopTier1 = lordTroopTier;
            LordTotalTroops1 = lordTotalTroops;
            LordMarchSize1 = lordMarchSize;
        }

        public LORD() { }



    }
}
