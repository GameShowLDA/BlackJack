using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SettingsDesign_Controls;
using SettingsDesign_Elemets;
using SettingsDesign_Keyboard;

namespace SettingsDesign
{
  public partial class GameForm : Form
  {
    public GameForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Загрузка формы, на которой отображаются все элементы управления
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GameForm_Load(object sender, EventArgs e)
    {
      DataClass.gameForm = this;
      this.KeyPreview = true;
      this.Font = DataClass.fontElements;
      this.DoubleBuffered = true;
      this.KeyUp += (s, a) => new HotKeys().KeyUp(s, a);
      this.KeyDown += (s, a) => new HotKeys().KeyDown(s, a);
      new СonfiguringFormProperties().SettingsForm();
      new LoadElemetsForm().LoadElements();
      foreach (Control control in this.Controls)
      {
        control.KeyDown += (s, a) => new HotKeys().KeyDown(s, a);
        control.KeyUp += (s, a) => new HotKeys().KeyUp(s, a);
      }
      DataClass.AddElementsGameForm();
      TestFormLoad();
    }

    /// <summary>
    /// Настройки тестовой формы
    /// </summary>
    private void TestFormLoad()
    {
      TestForm testForm = new TestForm();
      testForm.Show();
      //testForm.Location = new Point(Screen.AllScreens[1].WorkingArea.Location.X / 2, Screen.AllScreens[1].WorkingArea.Location.Y);
      //testForm.Width = Screen.AllScreens[1].WorkingArea.Width / 2;
      //testForm.Height = Screen.AllScreens[1].WorkingArea.Height;
      testForm.Location = new Point(DataClass.sizeScreen.Width / 3 * 2, 0);
      testForm.Width = DataClass.sizeScreen.Width / 3;
      testForm.Height = DataClass.sizeScreen.Height;
    }
  }
}
