using SettingsDesign;
using SettingsDesign_Controls;
using SettingsDesign_Keyboard;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsDesign_Elemets
{
  /// <summary>
  /// Загрузка элементов на форму
  /// </summary>
  class LoadElemetsForm
  {
    /// <summary>
    /// Загрузка всех элементов
    /// </summary>
    /// <param name="points"> Количество очков пользователя </param>
    public void LoadElements()
    {
      DataClass.gameForm?.Controls.Clear();
      new InfoToolTipPanel().LoadToolTipPanel();
      new InfoMessage().LoadInfoMessageHelpGame();
      new InfoMessage().LoadInfoMessageMotion();
      new InfoMessage().LoadInfoMessagePoint(0);
      new InfoMessage().LoadInfoMessageLossIsOverkill();
      new InfoMessage().LoadInfoMessageLossIsLess(0);
      new InfoMessage().LoadInfoMessageDraw();
      new InfoMessage().LoadInfoMessageVicroryMore(0);
      new InfoMessage().LoadInfoMessageVicroryFull();
    }

  }
}
