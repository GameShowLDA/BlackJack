using SettingsDesign_Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsDesign
{
  class InfoMessage
  {
    /// <summary>
    /// Локация по горизонтали информационного табло относительно экрана
    /// </summary>
    int locationX = 0;

    /// <summary>
    /// Локация по вертикали информационного табло относительно экрана
    /// </summary>
    int locationY = 20;

    /// <summary>
    /// Дополнительная высота(Чтобы текст не прилипал к краям по бокам)
    /// </summary>
    int additionalWidth = 20;

    /// <summary>
    /// Дополнительная высота(Чтобы текст не прилипал к краям сверху и снизу)
    /// </summary>
    int additionalHeight = 20;

    /// <summary>
    /// Загрузка информационного табло с правилами игры.
    /// </summary>
    public void LoadInfoMessageHelpGame()
    {
      string text = File.ReadAllText(@".\Resources\Files\Rules of the game");
      InformationBoard informationBoardHelp = new InformationBoard();
      informationBoardHelp.Location = new Point(locationX, locationY);
      informationBoardHelp.Size = new Size(TextRenderer.MeasureText(text, DataClass.gameForm.Font).Width, TextRenderer.MeasureText(text, DataClass.gameForm.Font).Height + additionalHeight);
      informationBoardHelp.TextInfo = text;
      informationBoardHelp.SetTextFormat("Left");
      informationBoardHelp.Visible = false;

      DataClass.informationBoardHelp = informationBoardHelp;
      //TODO: ОТключил добавление элмента  для теста
      //DataClass.gameForm.Controls.Add(informationBoardHelp);
    }

    /// <summary>
    /// Загрузка информационного табло о ходе игрока
    /// </summary>
    public void LoadInfoMessageMotion()
    {
      string text = "Возьмите ещё карту или останьтесь с картами, которые у вас на руках";
      InformationBoard InformationBoardMotion = new InformationBoard();
      InformationBoardMotion.Location = new Point(locationX, locationY);
      InformationBoardMotion.TextInfo = text;
      InformationBoardMotion.Size = new Size(TextRenderer.MeasureText(text, DataClass.gameForm.Font).Width, TextRenderer.MeasureText(text, DataClass.gameForm.Font).Height + additionalHeight);
      InformationBoardMotion.SetTextFormat("Left");
      InformationBoardMotion.Visible = false;

      DataClass.InformationBoardMotion = InformationBoardMotion;

      //TODO: ОТключил добавление элмента  для теста
      //DataClass.gameForm.Controls.Add(InformationBoardMotion);
    }

    /// <summary>
    /// Загрузка информационного табло о набранных очках на экран
    /// </summary>
    /// <param name="points"></param>
    public void LoadInfoMessagePoint(int points)
    {
      string text = "Ваши очки: " + points;
      InformationBoard informationBoardOfPoints = new InformationBoard();
      informationBoardOfPoints.Location = new Point(locationX, locationY);
      informationBoardOfPoints.TextInfo = text;
      informationBoardOfPoints.Size = new Size(TextRenderer.MeasureText(text, DataClass.gameForm.Font).Width+ additionalWidth, TextRenderer.MeasureText(text, DataClass.gameForm.Font).Height+ additionalHeight);
      informationBoardOfPoints.Visible = false;

      DataClass.informationBoardOfPoints = informationBoardOfPoints;
      //TODO: ОТключил добавление элмента  для теста
      //DataClass.gameForm.Controls.Add(informationBoardOfPoints);
    }

    /// <summary>
    /// Загрузка панели отображения информации о проигрыше из-за перебора
    /// </summary>
    public void LoadInfoMessageLossIsOverkill()
    {
      string text = "У вас перебор. Вы проиграли.";
      InformationBoard InformationLoosIsOverkill = new InformationBoard();
      InformationLoosIsOverkill.Location = new Point(0, locationY);
      InformationLoosIsOverkill.TextInfo = text;
      InformationLoosIsOverkill.Size = new Size(TextRenderer.MeasureText(text, DataClass.gameForm.Font).Width + additionalWidth, TextRenderer.MeasureText(text, DataClass.gameForm.Font).Height + additionalHeight);
      InformationLoosIsOverkill.Visible = false;

      DataClass.InformationLoosIsOverkill = InformationLoosIsOverkill;
      //TODO: ОТключил добавление элмента  для теста
      //DataClass.gameForm.Controls.Add(InformationLoosIsOverkill);
    }

    /// <summary>
    /// Загрузка панели отображения информации о проигрыше из-за большого количества очков "Компьютера"
    /// </summary>
    /// <param name="pointsBot">Очки противника"</param>
    public void LoadInfoMessageLossIsLess(int pointsBot)
    {
      string text = "У противника " + pointsBot + ". Вы проиграли.";
      InformationBoard InformationLoosIsLess = new InformationBoard();
      InformationLoosIsLess.Location = new Point(0, locationY);
      InformationLoosIsLess.TextInfo = text;
      InformationLoosIsLess.Size = new Size(TextRenderer.MeasureText(text, DataClass.gameForm.Font).Width + additionalWidth, TextRenderer.MeasureText(text, DataClass.gameForm.Font).Height + additionalHeight);
      InformationLoosIsLess.Visible = false;

      DataClass.InformationLoosIsLess = InformationLoosIsLess;
      //TODO: ОТключил добавление элмента  для теста
      //DataClass.gameForm.Controls.Add(InformationLoosIsLess);
    }

    /// <summary>
    /// Загрузка панели отображения информации о ничье
    /// </summary>
    public void LoadInfoMessageDraw()
    {
      string text = "У вас и у противника равное число очков на руках. Раздача закончилась вничью(\"равно\").";
      InformationBoard InformationDraw = new InformationBoard();
      InformationDraw.Location = new Point(0, locationY);
      InformationDraw.TextInfo = text;
      InformationDraw.Size = new Size(TextRenderer.MeasureText(text, DataClass.gameForm.Font).Width / 2 + additionalWidth, TextRenderer.MeasureText(text, DataClass.gameForm.Font).Height * 2 + additionalHeight);
      InformationDraw.SetTextFormat("Left");
      InformationDraw.Visible = false;

      DataClass.InformationDraw = InformationDraw;
      //TODO: ОТключил добавление элмента  для теста
      //DataClass.gameForm.Controls.Add(InformationDraw);
    }

    /// <summary>
    /// Загрузка панели отображения информации о победе из-за большего количества очков
    /// </summary>
    public void LoadInfoMessageVicroryMore(int points)
    {
      string text = "У вас " + points + ". Вы выиграли!";
      InformationBoard InformationVicroryMore = new InformationBoard();
      InformationVicroryMore.Location = new Point(0, locationY);
      InformationVicroryMore.TextInfo = text;
      InformationVicroryMore.Size = new Size(TextRenderer.MeasureText(text, DataClass.gameForm.Font).Width + additionalWidth, TextRenderer.MeasureText(text, DataClass.gameForm.Font).Height + additionalHeight);
      InformationVicroryMore.Visible = false;

      DataClass.InformationVicroryMore = InformationVicroryMore;
      //TODO: ОТключил добавление элмента  для теста
      //DataClass.gameForm.Controls.Add(InformationVicroryMore);
    }

    /// <summary>
    /// Загрузка панели отображения информации о победе из-за большего количества очков
    /// </summary>
    public void LoadInfoMessageVicroryFull()
    {
      string text = "У вас \"Очко\". Вы выиграли!";
      InformationBoard InformationVicroryFull = new InformationBoard();
      InformationVicroryFull.Location = new Point(0, locationY);
      InformationVicroryFull.TextInfo = text;
      InformationVicroryFull.Size = new Size(TextRenderer.MeasureText(text, DataClass.gameForm.Font).Width + additionalWidth, TextRenderer.MeasureText(text, DataClass.gameForm.Font).Height + additionalHeight);
      InformationVicroryFull.Visible = false;

      DataClass.InformationVicroryFull = InformationVicroryFull;
      //TODO: ОТключил добавление элмента  для теста
      //DataClass.gameForm.Controls.Add(InformationVicroryFull);
    }

  }
}
