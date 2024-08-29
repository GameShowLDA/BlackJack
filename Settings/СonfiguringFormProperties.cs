using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsDesign
{
  /// <summary>
  /// Настройки свойств формы 
  /// </summary>
  class СonfiguringFormProperties
  {
    /// <summary>
    /// Настройки свойств формы (размеры, положение, "дизайн")
    /// </summary>
    /// <param name="form"></param>
    public void SettingsForm()
    {
      //myFontCollection.AddFontFile(@".\Resources\Font\FiraMonoOT-Bold.otf");
      //myFontCollection.AddFontFile(@".\Resources\Font\FiraMonoOT-Regular.otf");
      //DataClass.fontElements = new Font(DataClass.myFontCollection.Families[1], 10);
      DataClass.gameForm.WindowState = FormWindowState.Maximized;
      DataClass.gameForm.FormBorderStyle = FormBorderStyle.None;
      DataClass.gameForm.BackgroundImageLayout = ImageLayout.Stretch;
      DataClass.gameForm.BackgroundImage = new Bitmap(@".\Resources\Image\Form Image\BackImage.jpg");
    }
  }
}
