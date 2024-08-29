using SettingsDesign;
using SettingsDesign_Elemets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsDesign_Keyboard
{
  /// <summary>
  /// Отработка горячих клавиш
  /// </summary>
  class HotKeys
  {
    static bool start = false;
    static bool rejection = false;
    /// <summary>
    /// Действия, которые происходят при нажатии клавиши клавиатуры
    /// </summary>
    /// <param name="sender">Объект элмента управления</param>
    /// <param name="e">Данные для события Control.KeyDown </param>
    public void KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.ControlKey)
      {
        DataClass.VisibleInfoHelp();
      }
      else if (e.KeyCode == Keys.Enter)
      {

        if (rejection == true)
        {
          rejection =  !rejection;
          InfoToolTipPanel.gameStart = true;
        }

        if (InfoToolTipPanel.gameStart)
        {
          InfoToolTipPanel.rejection = false;
          DataClass.ResetСards();
          InfoToolTipPanel.gameStart = false;
          new InfoToolTipPanel().LoadToolTipPanel();
          DataClass.StartGame();
        }
        else
        {
          if (!rejection)
          {
            if (start) DataClass.GiveCardUser("валет", "черви");
            else start = !start;
          }
        }
      }
      else if (e.KeyCode == Keys.Space)
      {
        rejection = true;
        InfoToolTipPanel.rejection = true;
        new InfoToolTipPanel().LoadToolTipPanel();
        DataClass.GiveCardBot("Туз", "Черви");
      }
      else if (e.KeyCode == Keys.Escape) Application.Exit();

      DataClass.informationBoardOfPoints.Focus();
    }

    /// <summary>
    /// Действия, которые происходят при отпускании клавиши клавиатуры
    /// </summary>
    /// <param name="sender">Объект элмента управления</param>
    /// <param name="e">Данные для события Control.KeyUp </param>
    public void KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.ControlKey)
      {
        DataClass.informationBoardHelp.Visible = false;
      }
      DataClass.informationBoardOfPoints.Focus();
    }
  }
}
