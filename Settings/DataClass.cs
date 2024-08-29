using SettingsDesign_Controls;
using SettingsDesign_Elemets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsDesign
{
  /// <summary>
  /// Общие данные программы
  /// </summary>
  static public class DataClass
  {
    #region Поля

    /// <summary>
    /// Размер экрана
    /// </summary>
    static public Size sizeScreen = Screen.PrimaryScreen.Bounds.Size;

    /// <summary>
    /// "Экземпляр" главной формы
    /// </summary>
    static public Form gameForm;

    /// <summary>
    /// Работа с картами игрока
    /// </summary>
    static public PlayerCards playerCardsClass = new PlayerCards();

    /// <summary>
    /// Работа с картами "Компьютера"
    /// </summary>
    static public BotCards botCardsClass = new BotCards();

    /// <summary>
    /// "Экземпляр" информационного табло с правилами игры
    /// </summary>
    static public InformationBoard informationBoardHelp;

    /// <summary>
    /// "Экземпляр" информационного табло с очками пользователя
    /// </summary>
    static public InformationBoard informationBoardOfPoints;

    /// <summary>
    /// "Экземпляр" информационного табло с подсказкой о ходе
    /// </summary>
    static public InformationBoard InformationBoardMotion;

    /// <summary>
    /// "Экземпляр" информационного табло с проигрышом из-за перебора
    /// </summary>
    static public InformationBoard InformationLoosIsOverkill;

    /// <summary>
    /// "Экземпляр" информационного табло с проигрышом из-за большего количества очков "Компьютера"
    /// </summary>
    static public InformationBoard InformationLoosIsLess;

    /// <summary>
    /// "Экземпляр" информационного табло с ничьёй
    /// </summary>
    static public InformationBoard InformationDraw;

    /// <summary>
    /// "Экземпляр" информационного табло с победой из-за большего количества очков
    /// </summary>
    static public InformationBoard InformationVicroryMore;

    /// <summary>
    /// "Экземпляр" информационного табло с победой из-за набора 21 очка
    /// </summary>
    static public InformationBoard InformationVicroryFull;

    /// <summary>
    /// "Экземпляр" панели с подсказками горячих клавиш
    /// </summary>
    static public Panel InformationToolTipPanel;

    /// <summary>
    /// Активное информационное табло на данный момент
    /// </summary>
    static private InformationBoard visibleInfo;

    /// <summary>
    /// Информационное табло, которое было активно до нового Акивного информационного табло)))
    /// </summary>
    static private InformationBoard lastVisibleInfo;

    /// <summary>
    /// Коллекция шрифтов программы
    /// </summary>
    static public PrivateFontCollection myFontCollection = new PrivateFontCollection();

    /// <summary>
    /// Шрифт элементов
    /// </summary>
    static public Font fontElements;
    #endregion

    #region Методы
    
    /// <summary>
    ///  количества набранных очков
    /// </summary>
    /// <param name="points"></param>
    static public void SetPointsUser(int points)
    {
      informationBoardOfPoints.TextInfo = "Ваши очки: " + points;
    }

    /// <summary>
    /// Отображает информационное табло с правилами игры
    /// </summary>
    static public void VisibleInfoHelp()
    {
      CheckVisibleInfo(informationBoardHelp);
    }

    /// <summary>
    /// Отображает информационное табло с очками польхователя
    /// </summary>
    static public void VisibleInfoPoints()
    {
      CheckVisibleInfo(informationBoardOfPoints);
    }

    /// <summary>
    /// Отображает информационное табло с подсказкой ходы
    /// </summary>
    static public void VisibleInfoMotion()
    {
      CheckVisibleInfo(InformationBoardMotion);
    }

    /// <summary>
    /// Отображает информационное табло с проигрышом из-за перебора
    /// </summary>
    static public void VisibleInfoLoosIsOverkill()
    {
      CheckVisibleInfo(InformationLoosIsOverkill);
    }

    /// <summary>
    /// Отображает информационное табло с проигрышом из-за большего количества очков "Компьютера"
    /// </summary>
    static public void VisibleInfoLoosIsLess()
    {
      CheckVisibleInfo(InformationLoosIsLess);
    }

    /// <summary>
    /// Отображает информационное табло с ничьёй
    /// </summary>
    static public void VisibleInfoDraw()
    {
      CheckVisibleInfo(InformationDraw);
    }

    /// <summary>
    /// Отображает информационное табло с победой из-за большего количества очков
    /// </summary>
    static public void VisibleInfoVicroryMore()
    {
      CheckVisibleInfo(InformationVicroryMore);
    }

    /// <summary>
    /// Отображает информационное табло с победой из-за набора 21 очка
    /// </summary>
    static public void VisibleInfoVicroryFull()
    {
      CheckVisibleInfo(InformationVicroryFull);
    }

    /// <summary>
    /// Выдать карту игроку
    /// </summary>
    /// <param name="nominal">Номинал карты</param>
    /// <param name="suit">Масть карты</param>
    static public void GiveCardUser(string nominal, string suit)
    {
      playerCardsClass.GiveTheCard(nominal, suit);
    }

    /// <summary>
    /// Выдать карту "Комьютеру"
    /// </summary>
    /// <param name="nominal">Номинал карты</param>
    /// <param name="suit">Масть карты</param>
    static public void GiveCardBot(string nominal, string suit)
    {
      botCardsClass.GiveTheCard(nominal, suit);
    }

    /// <summary>
    /// Отображение карт компьютера
    /// </summary>
    static public void VisibleCardsBot()
    {
      DataClass.botCardsClass.VisibleCards();
    }

    /// <summary>
    /// Сброс всех карт
    /// </summary>
    static public void ResetСards()
    {
      InfoToolTipPanel.gameStart = true;
      new InfoToolTipPanel().LoadToolTipPanel();

      playerCardsClass.ResetPlayerСards();
      botCardsClass.ResetPlayerСards();
    }

    /// <summary>
    /// Скрывает ифнормационное табло и выводит новое табло
    /// </summary>
    /// <param name="informationBoard"></param>
    static private void CheckVisibleInfo(InformationBoard informationBoard)
    {
      if (visibleInfo == null)
      {
        visibleInfo = informationBoard;
        lastVisibleInfo = informationBoard;
      }

      lastVisibleInfo = visibleInfo;
      visibleInfo = informationBoard;
      lastVisibleInfo.Visible = false;
      visibleInfo.Visible = true;
    }

    /// <summary>
    /// Добавление всех информационных табло на форму
    /// </summary>
    static public void AddElementsGameForm()
    {
     gameForm.Controls.Add(informationBoardHelp);
     gameForm.Controls.Add(informationBoardOfPoints);
     gameForm.Controls.Add(InformationBoardMotion);
     gameForm.Controls.Add(InformationLoosIsOverkill);
     gameForm.Controls.Add(InformationLoosIsLess);
     gameForm.Controls.Add(InformationDraw);
     gameForm.Controls.Add(InformationVicroryMore);
     gameForm.Controls.Add(InformationVicroryFull);
     gameForm.Controls.Add(InformationToolTipPanel);
    }

    static public void StartGame()
    { 
    
    }
    #endregion

    static DataClass()
    {
      myFontCollection.AddFontFile(@".\Resources\Font\arnamu.ttf");
      fontElements = new Font(myFontCollection.Families[0], 10);
    }
  }
}
