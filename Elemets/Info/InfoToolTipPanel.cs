using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SettingsDesign;
using SettingsDesign_Controls;

namespace SettingsDesign_Elemets
{
  /// <summary>
  /// Информационное табло с горячими клавишами
  /// </summary>
  class InfoToolTipPanel
  {
    /// <summary>
    /// Информационное табло при не начатой игре (если true) и информационное табло при начатой игре (если false)
    /// </summary>
    static public bool gameStart = true;

    /// <summary>
    /// Информационное табло, если отказ от карты
    /// </summary>
    static public bool rejection = false;

    /// <summary>
    /// Загрузка панели отображения горячих клавиш
    /// </summary>
    public void LoadToolTipPanel()
    {

      DataClass.gameForm.Controls.Remove(DataClass.InformationToolTipPanel);
      DataClass.InformationToolTipPanel = null;

      Color textColor = Color.White;
      int distance = 5;
      int width = 10;

      Panel panelToolTip = new Panel();
      panelToolTip.BackColor = Color.Black;

      if (gameStart)
      {
        Label labelHelp = new Label();
        labelHelp.Font = DataClass.gameForm.Font;
        labelHelp.Text = "Правила";
        labelHelp.ForeColor = textColor;
        labelHelp.Size = TextRenderer.MeasureText(labelHelp.Text, labelHelp.Font);
        panelToolTip.Height = labelHelp.Height * 2;
        labelHelp.Location = new Point(distance, (panelToolTip.Height - labelHelp.Height) / 2);
        width += labelHelp.Width + distance;

        PictureHotkey pictureHotkeyCtrl = new PictureHotkey();
        string labelHelpHotKeyCtrl = "L Ctrl";
        pictureHotkeyCtrl.Text = labelHelpHotKeyCtrl;
        pictureHotkeyCtrl.Width = TextRenderer.MeasureText(labelHelpHotKeyCtrl, DataClass.gameForm.Font).Width + 10;
        pictureHotkeyCtrl.Height = panelToolTip.Height - distance * 2;
        pictureHotkeyCtrl.Location = new Point(labelHelp.Location.X + labelHelp.Width + distance, distance);
        width += pictureHotkeyCtrl.Width + distance;

        Label labelStart = new Label();
        labelStart.Font = DataClass.gameForm.Font;
        labelStart.Text = "Начать игру";

        labelStart.ForeColor = textColor;
        labelStart.Size = TextRenderer.MeasureText(labelStart.Text, labelStart.Font);
        labelStart.Location = new Point(pictureHotkeyCtrl.Location.X + pictureHotkeyCtrl.Width + distance, (panelToolTip.Height - labelStart.Height) / 2);
        width += labelStart.Width + distance;

        PictureHotkey pictureHotkeyEnter = new PictureHotkey();
        string labelHelpHotKeyEnter = "Enter";
        pictureHotkeyEnter.Text = labelHelpHotKeyEnter;
        pictureHotkeyEnter.Width = TextRenderer.MeasureText(labelHelpHotKeyEnter, DataClass.gameForm.Font).Width + 10;
        pictureHotkeyEnter.Height = panelToolTip.Height - distance * 2;
        pictureHotkeyEnter.Location = new Point(labelStart.Location.X + labelStart.Width + distance, distance);
        width += pictureHotkeyEnter.Width + distance;

        Label labelExit = new Label();
        labelExit.Font = DataClass.gameForm.Font;
        labelExit.Text = "Выход";
        labelExit.ForeColor = textColor;
        labelExit.Size = TextRenderer.MeasureText(labelExit.Text, labelExit.Font);
        labelExit.Location = new Point(pictureHotkeyEnter.Location.X + pictureHotkeyEnter.Width + distance, (panelToolTip.Height - labelExit.Height) / 2);
        width += labelExit.Width + distance;

        PictureHotkey pictureHotkeyExit = new PictureHotkey();
        string labelHelpHotKeyExit = "Esc";
        pictureHotkeyExit.Text = labelHelpHotKeyExit;
        pictureHotkeyExit.Width = TextRenderer.MeasureText(labelHelpHotKeyExit, DataClass.gameForm.Font).Width + 10;
        pictureHotkeyExit.Height = panelToolTip.Height - distance * 2;
        pictureHotkeyExit.Location = new Point(labelExit.Location.X + labelExit.Width + distance, distance);
        width += pictureHotkeyExit.Width + distance;

        panelToolTip.Width = width;
        panelToolTip.Location = new Point(DataClass.sizeScreen.Width - panelToolTip.Width, DataClass.sizeScreen.Height - 40);

        panelToolTip.Controls.Add(labelHelp);
        panelToolTip.Controls.Add(pictureHotkeyCtrl);

        panelToolTip.Controls.Add(labelStart);
        panelToolTip.Controls.Add(pictureHotkeyEnter);

        panelToolTip.Controls.Add(labelExit);
        panelToolTip.Controls.Add(pictureHotkeyExit);
      }
      else 
      {
        if (!rejection)
        {
          Label labelHelp = new Label();
          labelHelp.Font = DataClass.gameForm.Font;
          labelHelp.Text = "Правила";
          labelHelp.ForeColor = textColor;
          labelHelp.Size = TextRenderer.MeasureText(labelHelp.Text, labelHelp.Font);
          panelToolTip.Height = labelHelp.Height * 2;
          labelHelp.Location = new Point(distance, (panelToolTip.Height - labelHelp.Height) / 2);
          width += labelHelp.Width + distance;

          PictureHotkey pictureHotkeyCtrl = new PictureHotkey();
          string labelHelpHotKeyCtrl = "L Ctrl";
          pictureHotkeyCtrl.Text = labelHelpHotKeyCtrl;
          pictureHotkeyCtrl.Width = TextRenderer.MeasureText(labelHelpHotKeyCtrl, DataClass.gameForm.Font).Width + 10;
          pictureHotkeyCtrl.Height = panelToolTip.Height - distance * 2;
          pictureHotkeyCtrl.Location = new Point(labelHelp.Location.X + labelHelp.Width + distance, distance);
          width += pictureHotkeyCtrl.Width + distance;

          Label labelCancel = new Label();
          labelCancel.Font = DataClass.gameForm.Font;
          labelCancel.Text = "Отказаться";

          labelCancel.ForeColor = textColor;
          labelCancel.Size = TextRenderer.MeasureText(labelCancel.Text, labelCancel.Font);
          labelCancel.Location = new Point(pictureHotkeyCtrl.Location.X + pictureHotkeyCtrl.Width + distance, (panelToolTip.Height - labelCancel.Height) / 2);
          width += labelCancel.Width + distance;

          PictureHotkey pictureHotkeyWhitespace = new PictureHotkey();
          string labelHelpHotKeyEnterCancel = "Пробел";
          pictureHotkeyWhitespace.Text = labelHelpHotKeyEnterCancel;
          pictureHotkeyWhitespace.Width = TextRenderer.MeasureText(labelHelpHotKeyEnterCancel, DataClass.gameForm.Font).Width + 10;
          pictureHotkeyWhitespace.Height = panelToolTip.Height - distance * 2;
          pictureHotkeyWhitespace.Location = new Point(labelCancel.Location.X + labelCancel.Width + distance, distance);
          width += pictureHotkeyWhitespace.Width + distance;

          Label labelAdd = new Label();
          labelAdd.Font = DataClass.gameForm.Font;
          labelAdd.Text = "Взять";

          labelAdd.ForeColor = textColor;
          labelAdd.Size = TextRenderer.MeasureText(labelAdd.Text, labelAdd.Font);
          labelAdd.Location = new Point(pictureHotkeyWhitespace.Location.X + pictureHotkeyWhitespace.Width + distance, (panelToolTip.Height - labelAdd.Height) / 2);
          width += labelAdd.Width + distance;

          PictureHotkey pictureHotkeyAdd = new PictureHotkey();
          string labelHelpHotKeyEnterAdd = "Enter";
          pictureHotkeyAdd.Text = labelHelpHotKeyEnterAdd;
          pictureHotkeyAdd.Width = TextRenderer.MeasureText(labelHelpHotKeyEnterAdd, DataClass.gameForm.Font).Width + 10;
          pictureHotkeyAdd.Height = panelToolTip.Height - distance * 2;
          pictureHotkeyAdd.Location = new Point(labelAdd.Location.X + labelAdd.Width + distance, distance);
          width += pictureHotkeyAdd.Width + distance;

          Label labelExit = new Label();
          labelExit.Font = DataClass.gameForm.Font;
          labelExit.Text = "Выход";
          labelExit.ForeColor = textColor;
          labelExit.Size = TextRenderer.MeasureText(labelExit.Text, labelExit.Font);
          labelExit.Location = new Point(pictureHotkeyAdd.Location.X + pictureHotkeyAdd.Width + distance, (panelToolTip.Height - labelExit.Height) / 2);
          width += labelExit.Width + distance;

          PictureHotkey pictureHotkeyExit = new PictureHotkey();
          string labelHelpHotKeyExit = "Esc";
          pictureHotkeyExit.Text = labelHelpHotKeyExit;
          pictureHotkeyExit.Width = TextRenderer.MeasureText(labelHelpHotKeyExit, DataClass.gameForm.Font).Width + 10;
          pictureHotkeyExit.Height = panelToolTip.Height - distance * 2;
          pictureHotkeyExit.Location = new Point(labelExit.Location.X + labelExit.Width + distance, distance);
          width += pictureHotkeyExit.Width + distance;

          panelToolTip.Width = width;
          panelToolTip.Location = new Point(DataClass.sizeScreen.Width - panelToolTip.Width, DataClass.sizeScreen.Height - 40);


          panelToolTip.Controls.Add(labelHelp);
          panelToolTip.Controls.Add(pictureHotkeyCtrl);

          panelToolTip.Controls.Add(labelCancel);
          panelToolTip.Controls.Add(pictureHotkeyWhitespace);

          panelToolTip.Controls.Add(labelAdd);
          panelToolTip.Controls.Add(pictureHotkeyAdd);

          panelToolTip.Controls.Add(labelExit);
          panelToolTip.Controls.Add(pictureHotkeyExit);
        }
        else
        {

          Label labelHelp = new Label();
          labelHelp.Font = DataClass.gameForm.Font;
          labelHelp.Text = "Правила";
          labelHelp.ForeColor = textColor;
          labelHelp.Size = TextRenderer.MeasureText(labelHelp.Text, labelHelp.Font);
          panelToolTip.Height = labelHelp.Height * 2;
          labelHelp.Location = new Point(distance, (panelToolTip.Height - labelHelp.Height) / 2);
          width += labelHelp.Width + distance;

          PictureHotkey pictureHotkeyCtrl = new PictureHotkey();
          string labelHelpHotKeyCtrl = "L Ctrl";
          pictureHotkeyCtrl.Text = labelHelpHotKeyCtrl;
          pictureHotkeyCtrl.Width = TextRenderer.MeasureText(labelHelpHotKeyCtrl, DataClass.gameForm.Font).Width + 10;
          pictureHotkeyCtrl.Height = panelToolTip.Height - distance * 2;
          pictureHotkeyCtrl.Location = new Point(labelHelp.Location.X + labelHelp.Width + distance, distance);
          width += pictureHotkeyCtrl.Width + distance;

          Label labelAdd = new Label();
          labelAdd.Font = DataClass.gameForm.Font;
          labelAdd.Text = "Новая игра";

          labelAdd.ForeColor = textColor;
          labelAdd.Size = TextRenderer.MeasureText(labelAdd.Text, labelAdd.Font);
          labelAdd.Location = new Point(pictureHotkeyCtrl.Location.X + pictureHotkeyCtrl.Width + distance, (panelToolTip.Height - labelAdd.Height) / 2);
          width += labelAdd.Width + distance;

          PictureHotkey pictureHotkeyAdd = new PictureHotkey();
          string labelHelpHotKeyEnterAdd = "Enter";
          pictureHotkeyAdd.Text = labelHelpHotKeyEnterAdd;
          pictureHotkeyAdd.Width = TextRenderer.MeasureText(labelHelpHotKeyEnterAdd, DataClass.gameForm.Font).Width + 10;
          pictureHotkeyAdd.Height = panelToolTip.Height - distance * 2;
          pictureHotkeyAdd.Location = new Point(labelAdd.Location.X + labelAdd.Width + distance, distance);
          width += pictureHotkeyAdd.Width + distance;

          Label labelExit = new Label();
          labelExit.Font = DataClass.gameForm.Font;
          labelExit.Text = "Выход";
          labelExit.ForeColor = textColor;
          labelExit.Size = TextRenderer.MeasureText(labelExit.Text, labelExit.Font);
          labelExit.Location = new Point(pictureHotkeyAdd.Location.X + pictureHotkeyAdd.Width + distance, (panelToolTip.Height - labelExit.Height) / 2);
          width += labelExit.Width + distance;

          PictureHotkey pictureHotkeyExit = new PictureHotkey();
          string labelHelpHotKeyExit = "Esc";
          pictureHotkeyExit.Text = labelHelpHotKeyExit;
          pictureHotkeyExit.Width = TextRenderer.MeasureText(labelHelpHotKeyExit, DataClass.gameForm.Font).Width + 10;
          pictureHotkeyExit.Height = panelToolTip.Height - distance * 2;
          pictureHotkeyExit.Location = new Point(labelExit.Location.X + labelExit.Width + distance, distance);
          width += pictureHotkeyExit.Width + distance;

          panelToolTip.Width = width;
          panelToolTip.Location = new Point(DataClass.sizeScreen.Width - panelToolTip.Width, DataClass.sizeScreen.Height - 40);


          panelToolTip.Controls.Add(labelHelp);
          panelToolTip.Controls.Add(pictureHotkeyCtrl);

          panelToolTip.Controls.Add(labelAdd);
          panelToolTip.Controls.Add(pictureHotkeyAdd);

          panelToolTip.Controls.Add(labelExit);
          panelToolTip.Controls.Add(pictureHotkeyExit);


        }
      }
      DataClass.InformationToolTipPanel = panelToolTip;
      DataClass.gameForm.Controls.Add(DataClass.InformationToolTipPanel);
      DataClass.InformationToolTipPanel.Focus();
    }
  }
}
