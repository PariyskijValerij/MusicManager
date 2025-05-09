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
            tabSongs = new TabPage();
            btnDeleteSong = new Button();
            listViewAllSongs = new ListView();
            imageListSongs = new ImageList(components);
            btnAddSong = new Button();
            tabSearch = new TabPage();
            tabArtists = new TabPage();
            splitContainer1 = new SplitContainer();
            btnChangeArtistImage = new Button();
            listViewArtists = new ListView();
            imageListArtists = new ImageList(components);
            btnDeleteArtist = new Button();
            btnAddArtist = new Button();
            label2 = new Label();
            dataGridArtistSongs = new DataGridView();
            tabControlMain = new TabControl();
            tabSongs.SuspendLayout();
            tabArtists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridArtistSongs).BeginInit();
            tabControlMain.SuspendLayout();
            SuspendLayout();
            // 
            // tabAlbums
            // 
            tabAlbums.BackColor = Color.FromArgb(30, 30, 30);
            tabAlbums.ForeColor = Color.White;
            tabAlbums.Location = new Point(4, 24);
            tabAlbums.Name = "tabAlbums";
            tabAlbums.Size = new Size(792, 422);
            tabAlbums.TabIndex = 3;
            tabAlbums.Text = "Albums";
            // 
            // tabSongs
            // 
            tabSongs.BackColor = Color.FromArgb(30, 30, 30);
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
            // btnDeleteSong
            // 
            btnDeleteSong.BackColor = Color.FromArgb(35, 35, 35);
            btnDeleteSong.Location = new Point(89, 11);
            btnDeleteSong.Name = "btnDeleteSong";
            btnDeleteSong.Size = new Size(83, 23);
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
            listViewAllSongs.Size = new Size(776, 374);
            listViewAllSongs.TabIndex = 5;
            listViewAllSongs.TileSize = new Size(600, 76);
            listViewAllSongs.UseCompatibleStateImageBehavior = false;
            listViewAllSongs.View = View.Tile;
            listViewAllSongs.DrawItem += listViewAllSongs_DrawItem;
            // 
            // imageListSongs
            // 
            imageListSongs.ColorDepth = ColorDepth.Depth32Bit;
            imageListSongs.ImageSize = new Size(64, 64);
            imageListSongs.TransparentColor = Color.Transparent;
            // 
            // btnAddSong
            // 
            btnAddSong.BackColor = Color.FromArgb(35, 35, 35);
            btnAddSong.Location = new Point(8, 11);
            btnAddSong.Name = "btnAddSong";
            btnAddSong.Size = new Size(75, 23);
            btnAddSong.TabIndex = 4;
            btnAddSong.Text = "Add Song";
            btnAddSong.UseVisualStyleBackColor = false;
            btnAddSong.Click += btnAddSong_Click;
            // 
            // tabSearch
            // 
            tabSearch.BackColor = Color.FromArgb(30, 30, 30);
            tabSearch.ForeColor = Color.White;
            tabSearch.Location = new Point(4, 24);
            tabSearch.Name = "tabSearch";
            tabSearch.Size = new Size(792, 422);
            tabSearch.TabIndex = 1;
            tabSearch.Text = "Search";
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
            splitContainer1.Panel1.Controls.Add(btnChangeArtistImage);
            splitContainer1.Panel1.Controls.Add(listViewArtists);
            splitContainer1.Panel1.Controls.Add(btnDeleteArtist);
            splitContainer1.Panel1.Controls.Add(btnAddArtist);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(dataGridArtistSongs);
            splitContainer1.Size = new Size(792, 422);
            splitContainer1.SplitterDistance = 375;
            splitContainer1.TabIndex = 0;
            // 
            // btnChangeArtistImage
            // 
            btnChangeArtistImage.BackColor = Color.FromArgb(35, 35, 35);
            btnChangeArtistImage.Location = new Point(190, 10);
            btnChangeArtistImage.Name = "btnChangeArtistImage";
            btnChangeArtistImage.Size = new Size(104, 23);
            btnChangeArtistImage.TabIndex = 6;
            btnChangeArtistImage.Text = "Change Image";
            btnChangeArtistImage.UseVisualStyleBackColor = false;
            btnChangeArtistImage.Click += btnChangeArtistImage_Click;
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
            listViewArtists.Size = new Size(352, 375);
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
            btnDeleteArtist.Location = new Point(99, 10);
            btnDeleteArtist.Name = "btnDeleteArtist";
            btnDeleteArtist.Size = new Size(85, 23);
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
            btnAddArtist.Size = new Size(85, 23);
            btnAddArtist.TabIndex = 2;
            btnAddArtist.Text = "Add Artist";
            btnAddArtist.UseVisualStyleBackColor = false;
            btnAddArtist.Click += btnAddArtist_Click;
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
            // dataGridArtistSongs
            // 
            dataGridArtistSongs.AllowUserToAddRows = false;
            dataGridArtistSongs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridArtistSongs.Location = new Point(8, 39);
            dataGridArtistSongs.Name = "dataGridArtistSongs";
            dataGridArtistSongs.ReadOnly = true;
            dataGridArtistSongs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridArtistSongs.Size = new Size(397, 378);
            dataGridArtistSongs.TabIndex = 0;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabSearch);
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
            tabSongs.ResumeLayout(false);
            tabArtists.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridArtistSongs).EndInit();
            tabControlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabAlbums;
        private TabPage tabSongs;
        private TabPage tabSearch;
        private TabPage tabArtists;
        private SplitContainer splitContainer1;
        private Button btnDeleteArtist;
        private Button btnAddArtist;
        private TabControl tabControlMain;
        private Button btnAddSong;
        private Label label2;
        private DataGridView dataGridArtistSongs;
        private ListView listViewArtists;
        private ImageList imageListArtists;
        private ListView listViewAllSongs;
        private ImageList imageListSongs;
        private Button btnDeleteSong;
        private Button btnChangeArtistImage;
    }
}
