namespace MusicManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabAlbums = new TabPage();
            btnRemoveSongFromAlbum = new Button();
            label1 = new Label();
            listViewAlbumSongs = new ListView();
            imageListSongs = new ImageList(components);
            btnAddSongToAlbum = new Button();
            btnEditAlbum = new Button();
            btnDeleteAlbum = new Button();
            btnAddAlbum = new Button();
            listViewAlbums = new ListView();
            imageListAlbums = new ImageList(components);
            tabSongs = new TabPage();
            label3 = new Label();
            listViewSongAlbums = new ListView();
            btnEditSong = new Button();
            btnDeleteSong = new Button();
            listViewAllSongs = new ListView();
            btnAddSong = new Button();
            tabArtists = new TabPage();
            splitContainer1 = new SplitContainer();
            btnEditArtist = new Button();
            listViewArtists = new ListView();
            imageListArtists = new ImageList(components);
            btnDeleteArtist = new Button();
            btnAddArtist = new Button();
            listViewArtistSongs = new ListView();
            label2 = new Label();
            tabControlMain = new TabControl();
            tabAlbums.SuspendLayout();
            tabSongs.SuspendLayout();
            tabArtists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControlMain.SuspendLayout();
            SuspendLayout();
            // 
            // tabAlbums
            // 
            tabAlbums.BackColor = Color.FromArgb(30, 30, 30);
            tabAlbums.Controls.Add(btnRemoveSongFromAlbum);
            tabAlbums.Controls.Add(label1);
            tabAlbums.Controls.Add(listViewAlbumSongs);
            tabAlbums.Controls.Add(btnAddSongToAlbum);
            tabAlbums.Controls.Add(btnEditAlbum);
            tabAlbums.Controls.Add(btnDeleteAlbum);
            tabAlbums.Controls.Add(btnAddAlbum);
            tabAlbums.Controls.Add(listViewAlbums);
            tabAlbums.ForeColor = Color.White;
            tabAlbums.Location = new Point(4, 24);
            tabAlbums.Name = "tabAlbums";
            tabAlbums.Size = new Size(792, 422);
            tabAlbums.TabIndex = 3;
            tabAlbums.Text = "Albums";
            // 
            // btnRemoveSongFromAlbum
            // 
            btnRemoveSongFromAlbum.BackColor = Color.FromArgb(35, 35, 35);
            btnRemoveSongFromAlbum.Location = new Point(555, 11);
            btnRemoveSongFromAlbum.Name = "btnRemoveSongFromAlbum";
            btnRemoveSongFromAlbum.Size = new Size(90, 23);
            btnRemoveSongFromAlbum.TabIndex = 7;
            btnRemoveSongFromAlbum.Text = "Remove Song";
            btnRemoveSongFromAlbum.UseVisualStyleBackColor = false;
            btnRemoveSongFromAlbum.Click += btnRemoveSongFromAlbum_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(392, 13);
            label1.Name = "label1";
            label1.Size = new Size(103, 21);
            label1.TabIndex = 6;
            label1.Text = "Album Songs";
            // 
            // listViewAlbumSongs
            // 
            listViewAlbumSongs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewAlbumSongs.BackColor = Color.FromArgb(35, 35, 35);
            listViewAlbumSongs.ForeColor = Color.White;
            listViewAlbumSongs.FullRowSelect = true;
            listViewAlbumSongs.LargeImageList = imageListSongs;
            listViewAlbumSongs.Location = new Point(392, 40);
            listViewAlbumSongs.MultiSelect = false;
            listViewAlbumSongs.Name = "listViewAlbumSongs";
            listViewAlbumSongs.OwnerDraw = true;
            listViewAlbumSongs.Size = new Size(392, 374);
            listViewAlbumSongs.TabIndex = 5;
            listViewAlbumSongs.TileSize = new Size(300, 76);
            listViewAlbumSongs.UseCompatibleStateImageBehavior = false;
            listViewAlbumSongs.View = View.Tile;
            listViewAlbumSongs.DrawItem += listViewAlbumSongs_DrawItem;
            // 
            // imageListSongs
            // 
            imageListSongs.ColorDepth = ColorDepth.Depth32Bit;
            imageListSongs.ImageSize = new Size(64, 64);
            imageListSongs.TransparentColor = Color.Transparent;
            // 
            // btnAddSongToAlbum
            // 
            btnAddSongToAlbum.BackColor = Color.FromArgb(35, 35, 35);
            btnAddSongToAlbum.Location = new Point(651, 11);
            btnAddSongToAlbum.Name = "btnAddSongToAlbum";
            btnAddSongToAlbum.Size = new Size(133, 23);
            btnAddSongToAlbum.TabIndex = 4;
            btnAddSongToAlbum.Text = "Add Song To Album";
            btnAddSongToAlbum.UseVisualStyleBackColor = false;
            btnAddSongToAlbum.Click += btnAddSongToAlbum_Click;
            // 
            // btnEditAlbum
            // 
            btnEditAlbum.BackColor = Color.FromArgb(35, 35, 35);
            btnEditAlbum.Location = new Point(102, 11);
            btnEditAlbum.Name = "btnEditAlbum";
            btnEditAlbum.Size = new Size(88, 23);
            btnEditAlbum.TabIndex = 3;
            btnEditAlbum.Text = "Edit Album";
            btnEditAlbum.UseVisualStyleBackColor = false;
            btnEditAlbum.Click += btnEditAlbum_Click;
            // 
            // btnDeleteAlbum
            // 
            btnDeleteAlbum.BackColor = Color.FromArgb(35, 35, 35);
            btnDeleteAlbum.Location = new Point(196, 11);
            btnDeleteAlbum.Name = "btnDeleteAlbum";
            btnDeleteAlbum.Size = new Size(88, 23);
            btnDeleteAlbum.TabIndex = 2;
            btnDeleteAlbum.Text = "Delete Album";
            btnDeleteAlbum.UseVisualStyleBackColor = false;
            btnDeleteAlbum.Click += btnDeleteAlbum_Click;
            // 
            // btnAddAlbum
            // 
            btnAddAlbum.BackColor = Color.FromArgb(35, 35, 35);
            btnAddAlbum.Location = new Point(8, 11);
            btnAddAlbum.Name = "btnAddAlbum";
            btnAddAlbum.Size = new Size(88, 23);
            btnAddAlbum.TabIndex = 1;
            btnAddAlbum.Text = "Add Album";
            btnAddAlbum.UseVisualStyleBackColor = false;
            btnAddAlbum.Click += btnAddAlbum_Click;
            // 
            // listViewAlbums
            // 
            listViewAlbums.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewAlbums.BackColor = Color.FromArgb(35, 35, 35);
            listViewAlbums.ForeColor = Color.White;
            listViewAlbums.FullRowSelect = true;
            listViewAlbums.LargeImageList = imageListAlbums;
            listViewAlbums.Location = new Point(8, 40);
            listViewAlbums.MultiSelect = false;
            listViewAlbums.Name = "listViewAlbums";
            listViewAlbums.OwnerDraw = true;
            listViewAlbums.Size = new Size(375, 374);
            listViewAlbums.TabIndex = 0;
            listViewAlbums.TileSize = new Size(300, 76);
            listViewAlbums.UseCompatibleStateImageBehavior = false;
            listViewAlbums.View = View.Tile;
            listViewAlbums.DrawItem += listViewAlbums_DrawItem;
            listViewAlbums.SelectedIndexChanged += listViewAlbums_SelectedIndexChanged;
            // 
            // imageListAlbums
            // 
            imageListAlbums.ColorDepth = ColorDepth.Depth32Bit;
            imageListAlbums.ImageSize = new Size(64, 64);
            imageListAlbums.TransparentColor = Color.Transparent;
            // 
            // tabSongs
            // 
            tabSongs.BackColor = Color.FromArgb(30, 30, 30);
            tabSongs.Controls.Add(label3);
            tabSongs.Controls.Add(listViewSongAlbums);
            tabSongs.Controls.Add(btnEditSong);
            tabSongs.Controls.Add(btnDeleteSong);
            tabSongs.Controls.Add(listViewAllSongs);
            tabSongs.Controls.Add(btnAddSong);
            tabSongs.ForeColor = Color.White;
            tabSongs.Location = new Point(4, 24);
            tabSongs.Name = "tabSongs";
            tabSongs.Size = new Size(792, 422);
            tabSongs.TabIndex = 2;
            tabSongs.Text = "Songs";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(399, 13);
            label3.Name = "label3";
            label3.Size = new Size(135, 21);
            label3.TabIndex = 10;
            label3.Text = "Albums with song";
            // 
            // listViewSongAlbums
            // 
            listViewSongAlbums.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewSongAlbums.BackColor = Color.FromArgb(35, 35, 35);
            listViewSongAlbums.Font = new Font("Segoe UI", 10F);
            listViewSongAlbums.ForeColor = Color.White;
            listViewSongAlbums.FullRowSelect = true;
            listViewSongAlbums.LargeImageList = imageListAlbums;
            listViewSongAlbums.Location = new Point(399, 40);
            listViewSongAlbums.MultiSelect = false;
            listViewSongAlbums.Name = "listViewSongAlbums";
            listViewSongAlbums.OwnerDraw = true;
            listViewSongAlbums.Size = new Size(385, 374);
            listViewSongAlbums.TabIndex = 9;
            listViewSongAlbums.TileSize = new Size(300, 76);
            listViewSongAlbums.UseCompatibleStateImageBehavior = false;
            listViewSongAlbums.View = View.Tile;
            listViewSongAlbums.DrawItem += listViewSongAlbums_DrawItem;
            // 
            // btnEditSong
            // 
            btnEditSong.BackColor = Color.FromArgb(35, 35, 35);
            btnEditSong.Location = new Point(102, 11);
            btnEditSong.Name = "btnEditSong";
            btnEditSong.Size = new Size(88, 23);
            btnEditSong.TabIndex = 8;
            btnEditSong.Text = "Edit Song";
            btnEditSong.UseVisualStyleBackColor = false;
            btnEditSong.Click += btnEditSong_Click;
            // 
            // btnDeleteSong
            // 
            btnDeleteSong.BackColor = Color.FromArgb(35, 35, 35);
            btnDeleteSong.Location = new Point(196, 11);
            btnDeleteSong.Name = "btnDeleteSong";
            btnDeleteSong.Size = new Size(88, 23);
            btnDeleteSong.TabIndex = 7;
            btnDeleteSong.Text = "Delete Song";
            btnDeleteSong.UseVisualStyleBackColor = false;
            btnDeleteSong.Click += btnDeleteSong_Click;
            // 
            // listViewAllSongs
            // 
            listViewAllSongs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewAllSongs.BackColor = Color.FromArgb(35, 35, 35);
            listViewAllSongs.Font = new Font("Segoe UI", 10F);
            listViewAllSongs.ForeColor = Color.White;
            listViewAllSongs.FullRowSelect = true;
            listViewAllSongs.LargeImageList = imageListSongs;
            listViewAllSongs.Location = new Point(8, 40);
            listViewAllSongs.MultiSelect = false;
            listViewAllSongs.Name = "listViewAllSongs";
            listViewAllSongs.OwnerDraw = true;
            listViewAllSongs.Size = new Size(385, 374);
            listViewAllSongs.TabIndex = 5;
            listViewAllSongs.TileSize = new Size(300, 76);
            listViewAllSongs.UseCompatibleStateImageBehavior = false;
            listViewAllSongs.View = View.Tile;
            listViewAllSongs.DrawItem += listViewAllSongs_DrawItem;
            listViewAllSongs.SelectedIndexChanged += listViewAllSongs_SelectedIndexChanged;
            // 
            // btnAddSong
            // 
            btnAddSong.BackColor = Color.FromArgb(35, 35, 35);
            btnAddSong.Location = new Point(8, 11);
            btnAddSong.Name = "btnAddSong";
            btnAddSong.Size = new Size(88, 23);
            btnAddSong.TabIndex = 4;
            btnAddSong.Text = "Add Song";
            btnAddSong.UseVisualStyleBackColor = false;
            btnAddSong.Click += btnAddSong_Click;
            // 
            // tabArtists
            // 
            tabArtists.BackColor = Color.FromArgb(30, 30, 30);
            tabArtists.Controls.Add(splitContainer1);
            tabArtists.ForeColor = Color.White;
            tabArtists.Location = new Point(4, 24);
            tabArtists.Name = "tabArtists";
            tabArtists.Size = new Size(792, 422);
            tabArtists.TabIndex = 0;
            tabArtists.Text = "Artists";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnEditArtist);
            splitContainer1.Panel1.Controls.Add(listViewArtists);
            splitContainer1.Panel1.Controls.Add(btnDeleteArtist);
            splitContainer1.Panel1.Controls.Add(btnAddArtist);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(listViewArtistSongs);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Size = new Size(792, 422);
            splitContainer1.SplitterDistance = 374;
            splitContainer1.TabIndex = 0;
            // 
            // btnEditArtist
            // 
            btnEditArtist.BackColor = Color.FromArgb(35, 35, 35);
            btnEditArtist.Location = new Point(90, 10);
            btnEditArtist.Name = "btnEditArtist";
            btnEditArtist.Size = new Size(77, 23);
            btnEditArtist.TabIndex = 6;
            btnEditArtist.Text = "Edit Artist";
            btnEditArtist.UseVisualStyleBackColor = false;
            btnEditArtist.Click += btnEditArtist_Click;
            // 
            // listViewArtists
            // 
            listViewArtists.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewArtists.BackColor = Color.FromArgb(35, 35, 35);
            listViewArtists.Font = new Font("Segoe UI", 12F);
            listViewArtists.ForeColor = Color.White;
            listViewArtists.LargeImageList = imageListArtists;
            listViewArtists.Location = new Point(8, 39);
            listViewArtists.MultiSelect = false;
            listViewArtists.Name = "listViewArtists";
            listViewArtists.OwnerDraw = true;
            listViewArtists.Size = new Size(351, 375);
            listViewArtists.TabIndex = 4;
            listViewArtists.TileSize = new Size(300, 76);
            listViewArtists.UseCompatibleStateImageBehavior = false;
            listViewArtists.View = View.Tile;
            listViewArtists.DrawItem += listViewArtists_DrawItem;
            listViewArtists.SelectedIndexChanged += listViewArtists_SelectedIndexChanged;
            // 
            // imageListArtists
            // 
            imageListArtists.ColorDepth = ColorDepth.Depth32Bit;
            imageListArtists.ImageSize = new Size(64, 64);
            imageListArtists.TransparentColor = Color.Transparent;
            // 
            // btnDeleteArtist
            // 
            btnDeleteArtist.BackColor = Color.FromArgb(35, 35, 35);
            btnDeleteArtist.Location = new Point(173, 10);
            btnDeleteArtist.Name = "btnDeleteArtist";
            btnDeleteArtist.Size = new Size(81, 23);
            btnDeleteArtist.TabIndex = 3;
            btnDeleteArtist.Text = "Delete Artist";
            btnDeleteArtist.UseVisualStyleBackColor = false;
            btnDeleteArtist.Click += btnDeleteArtist_Click;
            // 
            // btnAddArtist
            // 
            btnAddArtist.BackColor = Color.FromArgb(35, 35, 35);
            btnAddArtist.Location = new Point(8, 10);
            btnAddArtist.Name = "btnAddArtist";
            btnAddArtist.Size = new Size(76, 23);
            btnAddArtist.TabIndex = 2;
            btnAddArtist.Text = "Add Artist";
            btnAddArtist.UseVisualStyleBackColor = false;
            btnAddArtist.Click += btnAddArtist_Click;
            // 
            // listViewArtistSongs
            // 
            listViewArtistSongs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewArtistSongs.BackColor = Color.FromArgb(35, 35, 35);
            listViewArtistSongs.Font = new Font("Segoe UI", 12F);
            listViewArtistSongs.ForeColor = Color.White;
            listViewArtistSongs.LargeImageList = imageListSongs;
            listViewArtistSongs.Location = new Point(8, 39);
            listViewArtistSongs.MultiSelect = false;
            listViewArtistSongs.Name = "listViewArtistSongs";
            listViewArtistSongs.OwnerDraw = true;
            listViewArtistSongs.Size = new Size(398, 375);
            listViewArtistSongs.TabIndex = 7;
            listViewArtistSongs.TileSize = new Size(300, 76);
            listViewArtistSongs.UseCompatibleStateImageBehavior = false;
            listViewArtistSongs.View = View.Tile;
            listViewArtistSongs.DrawItem += listViewArtistSongs_DrawItem;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 14);
            label2.Name = "label2";
            label2.Size = new Size(130, 15);
            label2.TabIndex = 1;
            label2.Text = "Songs by selected artist";
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabArtists);
            tabControlMain.Controls.Add(tabSongs);
            tabControlMain.Controls.Add(tabAlbums);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(800, 450);
            tabControlMain.TabIndex = 0;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlMain);
            Name = "MainForm";
            Text = "Music Manager";
            Load += MainForm_Load;
            tabAlbums.ResumeLayout(false);
            tabAlbums.PerformLayout();
            tabSongs.ResumeLayout(false);
            tabSongs.PerformLayout();
            tabArtists.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabAlbums;
        private TabPage tabSongs;
        private TabPage tabArtists;
        private SplitContainer splitContainer1;
        private Button btnDeleteArtist;
        private Button btnAddArtist;
        private TabControl tabControlMain;
        private Button btnAddSong;
        private Label label2;
        private ListView listViewArtists;
        private ImageList imageListArtists;
        private ListView listViewAllSongs;
        private ImageList imageListSongs;
        private Button btnDeleteSong;
        private Button btnEditArtist;
        private Button btnEditSong;
        private ListView listViewAlbums;
        private Button btnAddAlbum;
        private ImageList imageListAlbums;
        private Button btnDeleteAlbum;
        private Button btnEditAlbum;
        private Button btnAddSongToAlbum;
        private Label label1;
        private ListView listViewAlbumSongs;
        private Button btnRemoveSongFromAlbum;
        private ListView listViewArtistSongs;
        private Label label3;
        private ListView listViewSongAlbums;
    }
}
