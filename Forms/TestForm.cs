using SettingsDesign_Elemets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsDesign
{
  public partial class TestForm : Form
  {

    /// <summary>
    /// Тестовая форма. В релизе игры её не будет, да и она не нажна по сути
    /// Чисто для проверки отработки моих методов
    /// Установка очков пользователя
    /// Выдача карт пользователю
    /// Выдача карт компьютеру
    /// Чтобы отлючить форму нужно закменнировать вызов метода TestFormLoad() в основной форме (GameForm)
    /// </summary>
    public TestForm()
    {
      InitializeComponent();
      SettingsForm();
    }

    /// <summary>
    /// Настройки формы
    /// </summary>
    /// <returns></returns>
    public void SettingsForm()
    {
      this.Location = new Point(Screen.AllScreens[1].WorkingArea.Location.X / 2, Screen.AllScreens[1].WorkingArea.Location.Y);
      this.Width = Screen.AllScreens[1].WorkingArea.Width / 2;
      this.Height = Screen.AllScreens[1].WorkingArea.Height;

      #region Выдача очков пользователю
      Label countPoints = new Label
      {
        Text = "Кол-во очков: ",
      };
      countPoints.Width = TextRenderer.MeasureText(countPoints.Text, countPoints.Font).Width;
      TextBox text = new TextBox();
      text.Location = new Point(countPoints.Location.X + countPoints.Width, 0);
      Button buttonPoints = new Button();
      buttonPoints.Location = new Point(text.Location.X + text.Width, 0);
      buttonPoints.Click += (s, a) =>
            {
              buttonPoints.Name = text.Text;
              if (buttonPoints.Name != string.Empty)
                DataClass.SetPointsUser(Convert.ToInt32(buttonPoints.Name));
            };
      buttonPoints.Text = "Выдать";
      #endregion

      #region Выдача карт пользователю
      Label countUserCardsNominal = new Label
      {
        Text = "Номинал карты: ",
      };
      countUserCardsNominal.Location = new Point(countPoints.Location.X, countPoints.Location.Y + countPoints.Height + 10);
      countUserCardsNominal.Width = TextRenderer.MeasureText(countUserCardsNominal.Text, countUserCardsNominal.Font).Width;
      TextBox textUserCardsNominal = new TextBox();
      textUserCardsNominal.Location = new Point(countUserCardsNominal.Location.X + countUserCardsNominal.Width, countUserCardsNominal.Location.Y);

      Label countUserCardsSuit = new Label
      {
        Text = "Масть карты: ",
      };
      countUserCardsSuit.Location = new Point(countUserCardsNominal.Location.X, countUserCardsNominal.Location.Y + countUserCardsNominal.Height);
      countUserCardsSuit.Width = TextRenderer.MeasureText(countUserCardsSuit.Text, countUserCardsSuit.Font).Width;
      TextBox textUserCardsSuit = new TextBox();
      textUserCardsSuit.Location = new Point(countUserCardsSuit.Location.X + countUserCardsSuit.Width, countUserCardsSuit.Location.Y);

      Button buttonCards = new Button();
      buttonCards.Location = new Point(textUserCardsSuit.Location.X + textUserCardsSuit.Width, textUserCardsSuit.Location.Y);
      buttonCards.Click += (s, a) =>
      {
        string nominal = string.Empty;
        string suit = string.Empty;

        switch (textUserCardsNominal.Text)
        {
          case "6": { nominal = textUserCardsNominal.Text; break; }
          case "7": { nominal = textUserCardsNominal.Text; break; }
          case "8": { nominal = textUserCardsNominal.Text; break; }
          case "9": { nominal = textUserCardsNominal.Text; break; }
          case "10": { nominal = textUserCardsNominal.Text; break; }
          case "Валет": { nominal = textUserCardsNominal.Text; break; }
          case "валет": { nominal = textUserCardsNominal.Text; break; }
          case "Дама": { nominal = textUserCardsNominal.Text; break; }
          case "дама": { nominal = textUserCardsNominal.Text; break; }
          case "Король": { nominal = textUserCardsNominal.Text; break; }
          case "король": { nominal = textUserCardsNominal.Text; break; }
          case "Туз": { nominal = textUserCardsNominal.Text; break; }
          case "туз": { nominal = textUserCardsNominal.Text; break; }
          default: break;
        }
        switch (textUserCardsSuit.Text)
        {
          case "пики": { suit = textUserCardsSuit.Text; break; }
          case "Пики": { suit = "пики"; break; }
          case "черви": { suit = textUserCardsSuit.Text; break; }
          case "Черви": { suit = "черви"; break; }
          case "крести": { suit = textUserCardsSuit.Text; break; }
          case "Крести": { suit = "крести"; break; }
          case "буби": { suit = textUserCardsSuit.Text; break; }
          case "Буби": { suit = "буби"; break; }
          default: break;
        }

        if (suit != string.Empty && nominal != string.Empty)
        {
          DataClass.playerCardsClass.GiveTheCard(nominal, suit);
          DataClass.botCardsClass.GiveTheCard(nominal, suit);
        }
      };
      buttonCards.Text = "Выдать";
      #endregion

      #region Работа с картами
      Button buttonVisibleCards = new Button();
      buttonVisibleCards.Location = new Point(0, buttonCards.Location.Y + buttonCards.Height + 10);
      buttonVisibleCards.Text = "Карты бота";
      buttonVisibleCards.Click += (s, a) =>DataClass.VisibleCardsBot();

      Button buttonReset = new Button();
      buttonReset.Location = new Point(buttonVisibleCards.Location.X + buttonVisibleCards.Width + 10, buttonVisibleCards.Location.Y);
      buttonReset.Text = "Сброс карт";
      buttonReset.Click += (s, a) => DataClass.ResetСards();
      #endregion

      #region Работа с инфо таблом
      Button buttonHelp = new Button();
      buttonHelp.Location = new Point(0, buttonVisibleCards.Location.Y + buttonVisibleCards.Height + 10);
      buttonHelp.Text = "Правила";
      buttonHelp.Click += (s, a) => DataClass.VisibleInfoHelp();

      Button buttonPointsVisible = new Button();
      buttonPointsVisible.Location = new Point(buttonHelp.Location.X + buttonHelp.Width+10, buttonHelp.Location.Y);
      buttonPointsVisible.Text = "Очки";
      buttonPointsVisible.Click += (s, a) => DataClass.VisibleInfoPoints();

      Button buttonMotion = new Button();
      buttonMotion.Location = new Point(buttonPointsVisible.Location.X + buttonPointsVisible.Width + 10, buttonPointsVisible.Location.Y);
      buttonMotion.Text = "Ход";
      buttonMotion.Click += (s, a) => DataClass.VisibleInfoMotion();

      Button buttonLossOverkill = new Button();
      buttonLossOverkill.Location = new Point(buttonMotion.Location.X + buttonMotion.Width + 10, buttonMotion.Location.Y);
      buttonLossOverkill.Text = "Перебор";
      buttonLossOverkill.Click += (s, a) => DataClass.VisibleInfoLoosIsOverkill();

      Button buttonLossLess = new Button();
      buttonLossLess.Location = new Point(buttonLossOverkill.Location.X + buttonLossOverkill.Width + 10, buttonLossOverkill.Location.Y);
      buttonLossLess.Text = "Бот WIN";
      buttonLossLess.Click += (s, a) => DataClass.VisibleInfoLoosIsLess();
     
      Button buttonDraw = new Button();
      buttonDraw.Location = new Point(buttonLossLess.Location.X + buttonLossLess.Width + 10, buttonLossLess.Location.Y);
      buttonDraw.Text = "Ничья";
      buttonDraw.Click += (s, a) => DataClass.VisibleInfoDraw();
      
      Button buttonVicroryMore = new Button();
      buttonVicroryMore.Location = new Point(buttonDraw.Location.X + buttonDraw.Width + 10, buttonDraw.Location.Y);
      buttonVicroryMore.Text = "Игрок WIN";
      buttonVicroryMore.Click += (s, a) => DataClass.VisibleInfoVicroryMore();
      
      Button buttonVicroryFull = new Button();
      buttonVicroryFull.Location = new Point(buttonVicroryMore.Location.X + buttonVicroryMore.Width + 10, buttonVicroryMore.Location.Y);
      buttonVicroryFull.Text = "21";
      buttonVicroryFull.Click += (s, a) => DataClass.VisibleInfoVicroryFull();

      #endregion

      Button buttonStartGame = new Button();
      buttonStartGame.Location = new Point(0, buttonVicroryMore.Location.Y + buttonVicroryMore.Height + 10);
      buttonStartGame.Text = "Начать игру";
      buttonStartGame.Click += (s, a) => 
      {
        DataClass.GiveCardUser("6","пики");
        DataClass.GiveCardUser("туз","черви");

        DataClass.GiveCardBot("8", "крести");
        DataClass.GiveCardBot("Валет", "Пики");
      };

      this.Controls.Add(countPoints);
      this.Controls.Add(text);
      this.Controls.Add(buttonPoints);
      this.Controls.Add(countUserCardsNominal);
      this.Controls.Add(textUserCardsNominal);
      this.Controls.Add(countUserCardsSuit);
      this.Controls.Add(textUserCardsSuit);
      this.Controls.Add(buttonCards);
      this.Controls.Add(buttonVisibleCards);
      this.Controls.Add(buttonReset);
      this.Controls.Add(buttonHelp);
      this.Controls.Add(buttonPointsVisible);
      this.Controls.Add(buttonMotion);
      this.Controls.Add(buttonLossOverkill);
      this.Controls.Add(buttonLossLess);
      this.Controls.Add(buttonDraw);
      this.Controls.Add(buttonVicroryMore);
      this.Controls.Add(buttonVicroryFull);
      this.Controls.Add(buttonStartGame);
    }
  }
}
