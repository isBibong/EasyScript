using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ImageSearcher
{
    public static System.Drawing.Point? FindImage(string templatePath, double threshold = 0.8)
    {
        // 1. 截取全螢幕
        using (Bitmap screenBmp = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,
                                             System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height))
        {
            using (Graphics g = Graphics.FromImage(screenBmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, screenBmp.Size);
            }

            // 轉換與處理
            using (Mat refMatRaw = BitmapConverter.ToMat(screenBmp)) // CV_8UC4
            using (Mat tplMat = new Mat(templatePath, ImreadModes.Color)) // 強制 3 通道讀取
            using (Mat refMat = new Mat())
            using (Mat res = new Mat())
            {
                // 修正截圖通道問題：將 4 通道轉為 3 通道
                Cv2.CvtColor(refMatRaw, refMat, ColorConversionCodes.BGRA2BGR);

                // 模板匹配
                Cv2.MatchTemplate(refMat, tplMat, res, TemplateMatchModes.CCoeffNormed);
                Cv2.MinMaxLoc(res, out _, out double maxVal, out _, out OpenCvSharp.Point maxLoc);

                if (maxVal >= threshold)
                {
                    // 回傳中心點
                    return new System.Drawing.Point(maxLoc.X + tplMat.Cols / 2, maxLoc.Y + tplMat.Rows / 2);
                }
            }
        }
        return null;
    }
}
