using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;

namespace ListViewInsertionDragDemo
{
  public partial class DemoForm : Form
  {
    #region Instance Fields

    private List<Color> _colors;

    #endregion

    #region Public Constructors

    public DemoForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Overridden Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      _colors = new List<Color>(new[]
                                {
                                  Color.FromArgb(0, 48, 96), Color.FromArgb(47, 96, 144), Color.FromArgb(47, 96, 192), Color.FromArgb(0, 48, 144), Color.FromArgb(0, 0, 144), Color.FromArgb(0, 0, 207), Color.FromArgb(0, 0, 96), Color.FromArgb(0, 96, 96), Color.FromArgb(0, 96, 144), Color.FromArgb(0, 151, 192), Color.FromArgb(0, 103, 207), Color.FromArgb(0, 48, 207), Color.FromArgb(0, 0, 255), Color.FromArgb(48, 48, 255), Color.FromArgb(48, 48, 144), Color.FromArgb(96, 152, 144), Color.FromArgb(0, 152, 159), Color.FromArgb(48, 200, 207), Color.FromArgb(0, 200, 255), Color.FromArgb(0, 152, 255), Color.FromArgb(0, 103, 255), Color.FromArgb(48, 103, 255), Color.FromArgb(48, 48, 192), Color.FromArgb(96, 103, 144), Color.FromArgb(48, 152, 96), Color.FromArgb(0, 200, 144), Color.FromArgb(0, 200, 192), Color.FromArgb(0, 255, 255), Color.FromArgb(48, 200, 255), Color.FromArgb(48, 151, 255), Color.FromArgb(96, 151, 255), Color.FromArgb(96, 96, 255), Color.FromArgb(95, 0, 255), Color.FromArgb(96, 0, 192), Color.FromArgb(48, 151, 48), Color.FromArgb(0, 200, 96), Color.FromArgb(0, 255, 144), Color.FromArgb(96, 255, 207), Color.FromArgb(96, 255, 255), Color.FromArgb(96, 200, 255), Color.FromArgb(144, 200, 255), Color.FromArgb(144, 151, 255), Color.FromArgb(144, 103, 255), Color.FromArgb(144, 48, 255), Color.FromArgb(144, 0, 255), Color.FromArgb(0, 96, 0), Color.FromArgb(0, 200, 0), Color.FromArgb(0, 255, 0), Color.FromArgb(96, 255, 144), Color.FromArgb(144, 255, 192), Color.FromArgb(207, 255, 255), Color.FromArgb(192, 200, 255), Color.FromArgb(192, 151, 255), Color.FromArgb(192, 96, 255), Color.FromArgb(192, 48, 255), Color.FromArgb(192, 0, 255), Color.FromArgb(144, 0, 192), Color.FromArgb(0, 48, 0), Color.FromArgb(0, 152, 48), Color.FromArgb(47, 200, 47), Color.FromArgb(96, 255, 96), Color.FromArgb(144, 255, 144), Color.FromArgb(207, 255, 207), Color.FromArgb(255, 255, 255), Color.FromArgb(255, 200, 255), Color.FromArgb(255, 151, 255), Color.FromArgb(255, 104, 255), Color.FromArgb(255, 0, 255), Color.FromArgb(207, 0, 207), Color.FromArgb(96, 0, 96), Color.FromArgb(47, 96, 0), Color.FromArgb(0, 152, 0), Color.FromArgb(96, 255, 48), Color.FromArgb(144, 255, 96), Color.FromArgb(192, 255, 144), Color.FromArgb(255, 255, 207), Color.FromArgb(255, 200, 207), Color.FromArgb(255, 151, 207), Color.FromArgb(255, 96, 192), Color.FromArgb(255, 48, 207), Color.FromArgb(207, 0, 144), Color.FromArgb(144, 47, 144), Color.FromArgb(48, 48, 0), Color.FromArgb(96, 151, 0), Color.FromArgb(144, 255, 47), Color.FromArgb(207, 255, 96), Color.FromArgb(255, 255, 144), Color.FromArgb(255, 200, 144), Color.FromArgb(255, 152, 96), Color.FromArgb(255, 96, 144), Color.FromArgb(255, 48, 144), Color.FromArgb(207, 48, 144), Color.FromArgb(144, 0, 144), Color.FromArgb(96, 96, 47), Color.FromArgb(144, 200, 0), Color.FromArgb(192, 255, 57), Color.FromArgb(255, 255, 96), Color.FromArgb(255, 200, 96), Color.FromArgb(255, 152, 96), Color.FromArgb(255, 96, 96), Color.FromArgb(255, 0, 96), Color.FromArgb(207, 103, 144), Color.FromArgb(144, 48, 96), Color.FromArgb(144, 151, 96), Color.FromArgb(192, 200, 0), Color.FromArgb(255, 255, 0), Color.FromArgb(255, 200, 0), Color.FromArgb(255, 151, 47), Color.FromArgb(255, 103, 0), Color.FromArgb(255, 96, 96), Color.FromArgb(192, 0, 95), Color.FromArgb(96, 0, 47), Color.FromArgb(159, 103, 48), Color.FromArgb(207, 151, 0), Color.FromArgb(255, 151, 0), Color.FromArgb(192, 96, 0), Color.FromArgb(255, 48, 0), Color.FromArgb(255, 0, 0), Color.FromArgb(192, 0, 0), Color.FromArgb(144, 0, 47), Color.FromArgb(96, 48, 0), Color.FromArgb(144, 96, 0), Color.FromArgb(192, 48, 0), Color.FromArgb(144, 48, 0), Color.FromArgb(144, 0, 0), Color.FromArgb(127, 0, 0), Color.FromArgb(144, 48, 48), Color.White, Color.Black, Color.FromArgb(207, 200, 207), Color.FromArgb(144, 151, 144), Color.FromArgb(96, 103, 96), Color.FromArgb(192, 192, 192), Color.FromArgb(127, 127, 127), Color.FromArgb(48, 48, 48)
                                });
      this.GenerateImages();
      this.GenerateItems();
    }

    #endregion

    #region Private Members

    private void GenerateImages()
    {
      foreach (Color color in _colors)
      {
        Bitmap image;
        Rectangle bounds;

        bounds = new Rectangle(Point.Empty, imageList.ImageSize);
        image = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);

        using (Graphics g = Graphics.FromImage(image))
        {
          g.SmoothingMode = SmoothingMode.AntiAlias;

          using (Brush brush = new SolidBrush(color))
          {
            g.FillEllipse(brush, bounds);
          }
        }

        imageList.Images.Add(image);
      }
    }

    private void GenerateItems()
    {
      for (int i = 0; i < _colors.Count; i++)
      {
        ListViewItem item;
        Color color;

        color = _colors[i];

        item = new ListViewItem
               {
                 ImageIndex = i,
                 Text = i.ToString(CultureInfo.InvariantCulture)
               };
        item.SubItems.Add(string.Format("{0}, {1}, {2}", color.R, color.G, color.B));
        item.SubItems.Add(string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B));

        listView.Items.Add(item);
      }
    }

    #endregion

    #region Event Handlers

    private void allowItemDragCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      listView.AllowItemDrag = allowItemDragCheckBox.Checked;
    }

    #endregion

    private void listView_ItemDragDrop(object sender, ListViewItemDragEventArgs e)
    {
      eventsListBox.AddEvent((Control)sender, "ItemDragDrop", e);
    }

    private void listView_ItemDragging(object sender, CancelListViewItemDragEventArgs e)
    {
      eventsListBox.AddEvent((Control)sender, "ItemDragging", e);
    }
  }
}
