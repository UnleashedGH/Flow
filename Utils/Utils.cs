using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xv2CoreLib;

namespace Flow.Utils
{
    public static class Utils
    {
        public static string translateButtonInputFlag(uint flg)
        {
            Xv2CoreLib.BCM.ButtonInput a = (Xv2CoreLib.BCM.ButtonInput)flg;
           

            string[] s = a.ToString().Split(new char[] { ',', ' ' });
            if (s.Length > 1)
                return "M";

            if (s.Length == 1)
            {
                switch (s[0])
                {
                    case "light":
                        return "L";
                    case "heavy":
                        return "H";
                    case "blast":
                        return "K";
                    case "jump":
                        return "J";
                    case "":
                        return "";

                }
            }
            return "";
        }


        //should probably add the rest of the colors here
    }
}
