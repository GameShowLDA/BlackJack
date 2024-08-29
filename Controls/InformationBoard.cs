using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsDesign_Controls
{
  public class InformationBoard : Control
  {
    #region Поля

    /// <summary>
    /// Положение текста на элементе
    /// </summary>
    StringFormat SF = new StringFormat();

    /// <summary>
    /// Цвет фона элемента
    /// </summary>
    Color _backColor = Color.Black;

    /// <summary>
    /// Цвет текста элемента
    /// </summary>
    Color _textColor = Color.White;

    /// <summary>
    /// Текст элемента
    /// </summary>
    string textInfo;
    #endregion

    #region Свойства
    /// <summary>
    /// Текст информации
    /// </summary>
    public string TextInfo
    {
      get
      {
        return textInfo;
      }
      set
      {
        textInfo = value;
        Invalidate();
      }
    }
    #endregion

    #region Методы
    /// <summary>
    /// Отрисовка элемента
    /// </summary>
    /// <param name="e">Данные для события Control.Paint </param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      Graphics graphics = e.Graphics;
      Rectangle rectangle;

      if (SF.Alignment == StringAlignment.Center) rectangle = new Rectangle(0, 0, this.Width, this.Height);
      else  rectangle = new Rectangle(5, 0, this.Width, this.Height);

      graphics.FillRectangle(new SolidBrush(Color.FromArgb(50,_backColor)), rectangle);
      graphics.DrawString(textInfo, this.Font, new SolidBrush(_textColor), rectangle, SF);
    }

    /// <summary>
    /// Положение текста в элементе
    /// </summary>
    /// <param name="textLineAlignment">Параметр выравнивния строки текста </param>
    public void SetTextFormat(string textLineAlignment)
    {
      switch (textLineAlignment)
      {
        case "Left": { SF.Alignment = StringAlignment.Near; break; }
        case "Right": { SF.Alignment = StringAlignment.Far; break; }
        default: { SF.Alignment = StringAlignment.Center; break; }
      }
      Invalidate();
    }
    #endregion

    #region Конструкторы
    /// <summary>
    /// Настройки элемента по умолчанию
    /// </summary>
    public InformationBoard()
    {
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint , true);
      DoubleBuffered = true;
      SF.Alignment = StringAlignment.Center;
      SF.LineAlignment = StringAlignment.Center;
      BackColor = _backColor;
    }
    #endregion
  }
}
