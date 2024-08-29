using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsDesign
{
  /// <summary>
  /// Управление картами "Игрока"
  /// </summary>
  public class PlayerCards
  {
    #region Поля

    /// <summary>
    /// Ширина карт по умолчанию
    /// </summary>
    int pictureBoxWidth = 116;

    /// <summary>
    /// Высота карт по умолчанию
    /// </summary>
    int pictureBoxHeight = 164;

    /// <summary>
    /// Локация X каждой карты. Первая локация расчитывается относительно размеров экрана, 
    /// остальные же относительно предыдущей карт
    /// </summary>
    int locationXCardUser;

    /// <summary>
    /// Все карты "Игрока" в типе PictureBox
    /// Этот список нужен для того, чтобы удалить нужные нам Conrol-ы с формы
    /// </summary>
    List<PictureBox> cardsUser = new List<PictureBox>();

    /// <summary>
    /// Переменная для расчёт локации первой карты
    /// </summary>
    bool firstCard = true;
    #endregion

    #region Методы

    /// <summary>
    /// Выдать карту игроку
    /// </summary>
    /// <param name="nominal">Номинал карты</param>
    /// <param name="suit">Масть карты</param>
    public void GiveTheCard(string nominal, string suit)
    {
      if (firstCard) SettingLocation();
      PictureBox pictureBox = new PictureBox();
      pictureBox.Size = new System.Drawing.Size(pictureBoxWidth, pictureBoxHeight);
      pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
      pictureBox.BackgroundImage = new Bitmap(@"Resources\Image\Playing Cards\" + suit + "\\" + nominal + " " + suit + ".png");
      pictureBox.Location = new Point(locationXCardUser, DataClass.sizeScreen.Height / 3 * 2);
      locationXCardUser += pictureBox.Width / 3;
      DataClass.gameForm.Controls.Add(pictureBox);
      cardsUser.Add(pictureBox);
      pictureBox.BringToFront();
    }

    /// <summary>
    /// Сбросить все карты игрока
    /// </summary>
    public void ResetPlayerСards()
    {
      for (int i = cardsUser.Count - 1; i >= 0; i--)
      {
        DataClass.gameForm.Controls.Remove(cardsUser[i]);
      }
      firstCard = true;
      cardsUser.Clear();
    }

    /// <summary>
    /// Расчёт первоначальной локации карты
    /// </summary>
    private void SettingLocation()
    {
      locationXCardUser = (DataClass.sizeScreen.Width / 2) - pictureBoxWidth / 2;
      firstCard = false;
    }


    public PlayerCards()
    {
      if (DataClass.sizeScreen.Width != 1920)
      {
        double newWidth = 1920.00 / DataClass.sizeScreen.Width;
        pictureBoxWidth /= Convert.ToInt32(Math.Abs(newWidth+1));
        pictureBoxWidth += 20;

        double newHeight = 1080.00 / DataClass.sizeScreen.Height;
        pictureBoxHeight /= Convert.ToInt32(Math.Abs(newHeight+1));
        pictureBoxHeight += 20;
      }
    }

    #endregion
  }
}
