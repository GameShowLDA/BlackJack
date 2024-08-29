using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SettingsDesign_Controls
{
  class PictureHotkey : Control
  {

    #region Поля

    /// <summary>
    /// Положение текста на элементе
    /// </summary>
    StringFormat SF = new StringFormat();

    /// <summary>
    /// Цвет фона элемента
    /// </summary>
    Color _backColor = Color.White;

    /// <summary>
    /// Цвет текста элемента
    /// </summary>
    Color _textColor = Color.Black;

    /// <summary>
    /// Текст элемента
    /// </summary>
    string textInfo;
    #endregion

    #region Свойства

    /// <summary>
    /// Текст ифнормации
    /// </summary>
    public new string Text
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
    /// <param name="e"></param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      Graphics graphics = e.Graphics;
      Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
      graphics.FillRectangle(new SolidBrush(_backColor), rectangle);
      graphics.DrawString(textInfo, this.Font, new SolidBrush(_textColor), rectangle, SF);
    }
    #endregion

    #region Конструкторы

    /// <summary>
    /// Настройки элемента по умолчанию
    /// </summary>
    public PictureHotkey()
    {
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint /*| ControlStyles.Opaque*/, true);
      DoubleBuffered = true;
      SF.Alignment = StringAlignment.Center;
      SF.LineAlignment = StringAlignment.Center;
      BackColor = _backColor;
    }
    #endregion

  }
}
