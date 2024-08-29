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
  /// Управление картами "Компьтера"
  /// </summary>
  public class BotCards
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
    int locationXCardBot;

    /// <summary>
    /// Все карты "Комьютера" в типе PictureBox
    /// Этот список нужен для того, чтобы удалить нужные нам Conrol-ы с формы
    /// </summary>
    List<PictureBox> cardsBot = new List<PictureBox>();

    /// <summary>
    /// Номиналы всех карт "Компьютера"
    /// Этот список нужен для того, чтобы отобразить карты в конце игры
    /// </summary>
    List<string> nominalCards = new List<string>();

    /// <summary>
    /// Масти всех карт "Компьютера"
    /// Этот список нужен для того, чтобы отобразить карты в конце игры
    /// </summary>
    List<string> suitCards = new List<string>();

    /// <summary>
    /// Переменная для расчёт локации первой карты
    /// </summary>
    bool firstCard = true;
    #endregion

    #region Методы

    /// <summary>
    /// Выдать карту "Компьютеру"
    /// </summary>
    /// <param name="nominal">Номинал карты</param>
    /// <param name="suit">Масть карты</param>
    public void GiveTheCard(string nominal, string suit)
    {
      if (firstCard) SettingLocation();
      nominalCards.Add(nominal);
      suitCards.Add(suit);

      PictureBox pictureBox = new PictureBox();
      pictureBox.Size = new System.Drawing.Size(pictureBoxWidth, pictureBoxHeight);
      pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
      pictureBox.BackgroundImage = new Bitmap(@"Resources\Image\Playing Cards\Обложка.jpg");

      pictureBox.Location = new Point(locationXCardBot, DataClass.sizeScreen.Height / 4);
      locationXCardBot += pictureBox.Width / 3;
      DataClass.gameForm.Controls.Add(pictureBox);
      cardsBot.Add(pictureBox);
      pictureBox.BringToFront();
    }

    /// <summary>
    /// Отображение карт "Компьютера"
    /// </summary>
    /// <param name="GameForm"></param>
    public void VisibleCards()
    {
      for (int i = 0; i < cardsBot.Count; i++)
      {
        cardsBot[i].BackgroundImage = new Bitmap(@".\Resources\Image\Playing Cards\" + suitCards[i] + "\\" + nominalCards[i] + " " + suitCards[i] + ".png");
      }
    }

    /// <summary>
    /// Сбросить все карты "Компьютера"
    /// </summary>
    public void ResetPlayerСards()
    {
      for (int i = cardsBot.Count - 1; i >= 0; i--)
      {
        DataClass.gameForm.Controls.Remove(cardsBot[i]);
      }
      firstCard = true;
      cardsBot.Clear();
    }

    /// <summary>
    /// Расчёт первоначальной локации карты
    /// </summary>
    private void SettingLocation()
    {
      locationXCardBot = (DataClass.sizeScreen.Width / 2) - pictureBoxWidth / 2;
      firstCard = false;
    }
    #endregion

    public BotCards()
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
  }
}
