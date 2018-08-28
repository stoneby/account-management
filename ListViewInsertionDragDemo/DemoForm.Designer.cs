namespace ListViewInsertionDragDemo
{
  partial class DemoForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.allowItemDragCheckBox = new System.Windows.Forms.CheckBox();
      this.eventsListBox = new ListViewInsertionDragDemo.EventsListBox();
      this.listView = new ListViewInsertionDragDemo.ListView();
      this.indexColumnHeader = new System.Windows.Forms.ColumnHeader();
      this.rgbColumnHeader = new System.Windows.Forms.ColumnHeader();
      this.htmlColumnHeader = new System.Windows.Forms.ColumnHeader();
      this.SuspendLayout();
      // 
      // imageList
      // 
      this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
      this.imageList.ImageSize = new System.Drawing.Size(16, 16);
      this.imageList.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // allowItemDragCheckBox
      // 
      this.allowItemDragCheckBox.AutoSize = true;
      this.allowItemDragCheckBox.Checked = true;
      this.allowItemDragCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.allowItemDragCheckBox.Location = new System.Drawing.Point(344, 12);
      this.allowItemDragCheckBox.Name = "allowItemDragCheckBox";
      this.allowItemDragCheckBox.Size = new System.Drawing.Size(97, 17);
      this.allowItemDragCheckBox.TabIndex = 1;
      this.allowItemDragCheckBox.Text = "&Allow item drag";
      this.allowItemDragCheckBox.UseVisualStyleBackColor = true;
      this.allowItemDragCheckBox.CheckedChanged += new System.EventHandler(this.allowItemDragCheckBox_CheckedChanged);
      // 
      // eventsListBox
      // 
      this.eventsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.eventsListBox.FormattingEnabled = true;
      this.eventsListBox.HorizontalScrollbar = true;
      this.eventsListBox.Location = new System.Drawing.Point(344, 31);
      this.eventsListBox.Name = "eventsListBox";
      this.eventsListBox.Size = new System.Drawing.Size(467, 394);
      this.eventsListBox.TabIndex = 2;
      // 
      // listView
      // 
      this.listView.AllowDrop = true;
      this.listView.AllowItemDrag = true;
      this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexColumnHeader,
            this.rgbColumnHeader,
            this.htmlColumnHeader});
      this.listView.FullRowSelect = true;
      this.listView.HideSelection = false;
      this.listView.Location = new System.Drawing.Point(12, 12);
      this.listView.Name = "listView";
      this.listView.Size = new System.Drawing.Size(326, 413);
      this.listView.SmallImageList = this.imageList;
      this.listView.TabIndex = 0;
      this.listView.UseCompatibleStateImageBehavior = false;
      this.listView.View = System.Windows.Forms.View.Details;
      this.listView.ItemDragDrop += new System.EventHandler<ListViewInsertionDragDemo.ListViewItemDragEventArgs>(this.listView_ItemDragDrop);
      this.listView.ItemDragging += new System.EventHandler<ListViewInsertionDragDemo.CancelListViewItemDragEventArgs>(this.listView_ItemDragging);
      // 
      // indexColumnHeader
      // 
      this.indexColumnHeader.Text = "Index";
      // 
      // rgbColumnHeader
      // 
      this.rgbColumnHeader.Text = "RGB";
      this.rgbColumnHeader.Width = 120;
      // 
      // htmlColumnHeader
      // 
      this.htmlColumnHeader.Text = "HTML";
      this.htmlColumnHeader.Width = 120;
      // 
      // DemoForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(823, 437);
      this.Controls.Add(this.eventsListBox);
      this.Controls.Add(this.allowItemDragCheckBox);
      this.Controls.Add(this.listView);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "DemoForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ListView Item Drag Demonstration";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private ListView listView;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.ColumnHeader indexColumnHeader;
    private System.Windows.Forms.ColumnHeader rgbColumnHeader;
    private System.Windows.Forms.CheckBox allowItemDragCheckBox;
    private System.Windows.Forms.ColumnHeader htmlColumnHeader;
    private EventsListBox eventsListBox;
  }
}

