using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xv2CoreLib;
using System.Drawing;

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

        public static Color Light = Color.FromArgb(255, 255, 136, 174);
        public static Color LightTransparent = Color.FromArgb(127, 255, 136, 174);

        public static Color heavy = Color.FromArgb(255, 57, 244, 1);
        public static Color heavyTransparent = Color.FromArgb(127, 57, 244, 1);

        public static Color kiblast = Color.FromArgb(255, 255, 0, 0);
        public static Color kiblastTransparent = Color.FromArgb(127, 255, 0, 0);

        public static Color jump = Color.FromArgb(255, 0, 164, 255);
        public static Color jumpTransparent = Color.FromArgb(127, 0, 164, 255);

        public static Color multiinput = Color.FromArgb(255, 128, 128, 255);
        public static Color multiinputTransparent = Color.FromArgb(127, 128, 128, 255);
    }
}
