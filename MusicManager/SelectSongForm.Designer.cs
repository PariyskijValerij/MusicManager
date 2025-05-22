namespace MusicManager
{
    partial class SelectSongForm
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
            components = new System.ComponentModel.Container();
            listViewSongs = new ListView();
            imageListSongs = new ImageList(components);
            label1 = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // listViewSongs
            // 
            listViewSongs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewSongs.BackColor = Color.FromArgb(35, 35, 35);
            listViewSongs.ForeColor = Color.White;
            listViewSongs.FullRowSelect = true;
            listViewSongs.LargeImageList = imageListSongs;
            listViewSongs.Location = new Point(12, 36);
            listViewSongs.MultiSelect = false;
            listViewSongs.Name = "listViewSongs";
            listViewSongs.OwnerDraw = true;
            listViewSongs.Size = new Size(488, 402);
            listViewSongs.TabIndex = 1;
            listViewSongs.TileSize = new Size(350, 76);
            listViewSongs.UseCompatibleStateImageBehavior = false;
            listViewSongs.View = View.Tile;
            listViewSongs.DrawItem += listViewSongs_DrawItem;
            // 
            // imageListSongs
            // 
            imageListSongs.ColorDepth = ColorDepth.Depth32Bit;
            imageListSongs.ImageSize = new Size(64, 64);
            imageListSongs.TransparentColor = Color.Transparent;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 2;
            label1.Text = "Select Song";
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(35, 35, 35);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(425, 10);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 12;
            btnOK.Text = "Confirm";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(35, 35, 35);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(344, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // SelectSongForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(507, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(label1);
            Controls.Add(listViewSongs);
            Name = "SelectSongForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SelectSongForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewSongs;
        private Label label1;
        private Button btnOK;
        private Button btnCancel;
        private ImageList imageListSongs;
    }
}