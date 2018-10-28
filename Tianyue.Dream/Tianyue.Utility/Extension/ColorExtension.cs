using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tianyue.Utility.Extension
{
    public static class ColorExtension
    {
        public static Color GetLowerColor(Color color)
        {
            try
            {
                short[] numArray1 = new short[3]
                {
                    color.R.ToString().ToInt16(),
                    color.G.ToString().ToInt16(),
                    color.B.ToString().ToInt16()
                };
                Color color1 = Color.FromRgb((byte)250, (byte)250, (byte)250);
                short[] numArray2 = new short[3]
                {
                    color1.R.ToString().ToInt16(),
                    color1.G.ToString().ToInt16(),
                    color1.B.ToString().ToInt16()
                };
                int num1 = 2;
                int num2 = 1;
                int[] numArray3 = new int[3];
                for (int index = 0; index < 3; ++index)
                    numArray3[index] = (int)numArray2[index] + ((int)numArray1[index] - (int)numArray2[index]) / num1 * num2;
                return Color.FromRgb(BitConverter.GetBytes(numArray3[0])[0], BitConverter.GetBytes(numArray3[1])[0], BitConverter.GetBytes(numArray3[2])[0]);
            }
            catch
            {
                return Colors.DarkGray;
            }
        }

        public static Color GetHeightColor(Color color)
        {
            try
            {
                short[] numArray1 = new short[3]
                {
                    color.R.ToString().ToInt16(),
                    color.G.ToString().ToInt16(),
                    color.B.ToString().ToInt16()
                };
                Color color1 = Color.FromRgb((byte)11, (byte)12, (byte)12);
                short[] numArray2 = new short[3]
                {
                    color1.R.ToString().ToInt16(),
                    color1.G.ToString().ToInt16(),
                    color1.B.ToString().ToInt16()
                };
                int num1 = 2;
                int num2 = 1;
                int[] numArray3 = new int[3];
                for (int index = 0; index < 3; ++index)
                    numArray3[index] = (int)numArray2[index] + ((int)numArray1[index] - (int)numArray2[index]) / num1 * num2;
                return Color.FromRgb(BitConverter.GetBytes(numArray3[0])[0], BitConverter.GetBytes(numArray3[1])[0], BitConverter.GetBytes(numArray3[2])[0]);
            }
            catch
            {
                return Colors.DarkGray;
            }
        }

    }
}
