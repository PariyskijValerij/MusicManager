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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            splitContainer3 = new SplitContainer();
            label6 = new Label();
            txtAlbumFilter = new TextBox();
            btnClearAlbumsFilter = new Button();
            btnFilterAlbums = new Button();
            listViewAlbums = new ListView();
            imageListAlbums = new ImageList(components);
            btnAddAlbum = new Button();
            btnEditAlbum = new Button();
            btnDeleteAlbum = new Button();
            label4 = new Label();
            listViewAlbumSongs = new ListView();
            imageListSongs = new ImageList(components);
            btnRemoveSongFromAlbum = new Button();
            btnAddSongToAlbum = new Button();
            splitContainer2 = new SplitContainer();
            btnClearFilters = new Button();
            btnFilterSongs = new Button();
            listViewAllSongs = new ListView();
            btnAddSong = new Button();
            btnDeleteSong = new Button();
            btnEditSong = new Button();
            listViewSongAlbums = new ListView();
            label3 = new Label();
            splitContainer1 = new SplitContainer();
            label5 = new Label();
            txtArtistFilter = new TextBox();
            btnClearArtistsFilters = new Button();
            btnFilterArtists = new Button();
            btnEditArtist = new Button();
            listViewArtists = new ListView();
            imageListArtists = new ImageList(components);
            btnDeleteArtist = new Button();
            btnAddArtist = new Button();
            listViewArtistSongs = new ListView();
            label2 = new Label();
            tabAlbums = new TabPage();
            label1 = new Label();
            tabSongs = new TabPage();
            tabArtists = new TabPage();
            tabControlMain = new TabControl();
            imageListAlbumSongs = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabAlbums.SuspendLayout();
            tabSongs.SuspendLayout();
            tabArtists.SuspendLayout();
            tabControlMain.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer3
            // 
            resources.ApplyResources(splitContainer3, "splitContainer3");
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(label6);
            splitContainer3.Panel1.Controls.Add(txtAlbumFilter);
            splitContainer3.Panel1.Controls.Add(btnClearAlbumsFilter);
            splitContainer3.Panel1.Controls.Add(btnFilterAlbums);
            splitContainer3.Panel1.Controls.Add(listViewAlbums);
            splitContainer3.Panel1.Controls.Add(btnAddAlbum);
            splitContainer3.Panel1.Controls.Add(btnEditAlbum);
            splitContainer3.Panel1.Controls.Add(btnDeleteAlbum);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(label4);
            splitContainer3.Panel2.Controls.Add(listViewAlbumSongs);
            splitContainer3.Panel2.Controls.Add(btnRemoveSongFromAlbum);
            splitContainer3.Panel2.Controls.Add(btnAddSongToAlbum);
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // txtAlbumFilter
            // 
            txtAlbumFilter.BackColor = Color.FromArgb(35, 35, 35);
            txtAlbumFilter.ForeColor = Color.White;
            resources.ApplyResources(txtAlbumFilter, "txtAlbumFilter");
            txtAlbumFilter.Name = "txtAlbumFilter";
            // 
            // btnClearAlbumsFilter
            // 
            btnClearAlbumsFilter.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnClearAlbumsFilter, "btnClearAlbumsFilter");
            btnClearAlbumsFilter.Name = "btnClearAlbumsFilter";
            btnClearAlbumsFilter.UseVisualStyleBackColor = false;
            btnClearAlbumsFilter.Click += btnClearAlbumsFilter_Click;
            // 
            // btnFilterAlbums
            // 
            btnFilterAlbums.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnFilterAlbums, "btnFilterAlbums");
            btnFilterAlbums.Name = "btnFilterAlbums";
            btnFilterAlbums.UseVisualStyleBackColor = false;
            btnFilterAlbums.Click += btnFilterAlbums_Click;
            // 
            // listViewAlbums
            // 
            resources.ApplyResources(listViewAlbums, "listViewAlbums");
            listViewAlbums.BackColor = Color.FromArgb(35, 35, 35);
            listViewAlbums.ForeColor = Color.White;
            listViewAlbums.FullRowSelect = true;
            listViewAlbums.LargeImageList = imageListAlbums;
            listViewAlbums.MultiSelect = false;
            listViewAlbums.Name = "listViewAlbums";
            listViewAlbums.OwnerDraw = true;
            listViewAlbums.TileSize = new Size(300, 76);
            listViewAlbums.UseCompatibleStateImageBehavior = false;
            listViewAlbums.View = View.Tile;
            listViewAlbums.DrawItem += listViewAlbums_DrawItem;
            listViewAlbums.SelectedIndexChanged += listViewAlbums_SelectedIndexChanged;
            // 
            // imageListAlbums
            // 
            imageListAlbums.ColorDepth = ColorDepth.Depth32Bit;
            resources.ApplyResources(imageListAlbums, "imageListAlbums");
            imageListAlbums.TransparentColor = Color.Transparent;
            // 
            // btnAddAlbum
            // 
            btnAddAlbum.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnAddAlbum, "btnAddAlbum");
            btnAddAlbum.Name = "btnAddAlbum";
            btnAddAlbum.UseVisualStyleBackColor = false;
            btnAddAlbum.Click += btnAddAlbum_Click;
            // 
            // btnEditAlbum
            // 
            btnEditAlbum.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnEditAlbum, "btnEditAlbum");
            btnEditAlbum.Name = "btnEditAlbum";
            btnEditAlbum.UseVisualStyleBackColor = false;
            btnEditAlbum.Click += btnEditAlbum_Click;
            // 
            // btnDeleteAlbum
            // 
            btnDeleteAlbum.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnDeleteAlbum, "btnDeleteAlbum");
            btnDeleteAlbum.Name = "btnDeleteAlbum";
            btnDeleteAlbum.UseVisualStyleBackColor = false;
            btnDeleteAlbum.Click += btnDeleteAlbum_Click;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // listViewAlbumSongs
            // 
            resources.ApplyResources(listViewAlbumSongs, "listViewAlbumSongs");
            listViewAlbumSongs.BackColor = Color.FromArgb(35, 35, 35);
            listViewAlbumSongs.ForeColor = Color.White;
            listViewAlbumSongs.FullRowSelect = true;
            listViewAlbumSongs.LargeImageList = imageListSongs;
            listViewAlbumSongs.MultiSelect = false;
            listViewAlbumSongs.Name = "listViewAlbumSongs";
            listViewAlbumSongs.OwnerDraw = true;
            listViewAlbumSongs.TileSize = new Size(300, 76);
            listViewAlbumSongs.UseCompatibleStateImageBehavior = false;
            listViewAlbumSongs.View = View.Tile;
            listViewAlbumSongs.DrawItem += listViewAlbumSongs_DrawItem;
            // 
            // imageListSongs
            // 
            imageListSongs.ColorDepth = ColorDepth.Depth32Bit;
            resources.ApplyResources(imageListSongs, "imageListSongs");
            imageListSongs.TransparentColor = Color.Transparent;
            // 
            // btnRemoveSongFromAlbum
            // 
            btnRemoveSongFromAlbum.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnRemoveSongFromAlbum, "btnRemoveSongFromAlbum");
            btnRemoveSongFromAlbum.Name = "btnRemoveSongFromAlbum";
            btnRemoveSongFromAlbum.UseVisualStyleBackColor = false;
            btnRemoveSongFromAlbum.Click += btnRemoveSongFromAlbum_Click;
            // 
            // btnAddSongToAlbum
            // 
            btnAddSongToAlbum.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnAddSongToAlbum, "btnAddSongToAlbum");
            btnAddSongToAlbum.Name = "btnAddSongToAlbum";
            btnAddSongToAlbum.UseVisualStyleBackColor = false;
            btnAddSongToAlbum.Click += btnAddSongToAlbum_Click;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(splitContainer2, "splitContainer2");
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(btnClearFilters);
            splitContainer2.Panel1.Controls.Add(btnFilterSongs);
            splitContainer2.Panel1.Controls.Add(listViewAllSongs);
            splitContainer2.Panel1.Controls.Add(btnAddSong);
            splitContainer2.Panel1.Controls.Add(btnDeleteSong);
            splitContainer2.Panel1.Controls.Add(btnEditSong);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(listViewSongAlbums);
            splitContainer2.Panel2.Controls.Add(label3);
            // 
            // btnClearFilters
            // 
            btnClearFilters.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnClearFilters, "btnClearFilters");
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // btnFilterSongs
            // 
            btnFilterSongs.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnFilterSongs, "btnFilterSongs");
            btnFilterSongs.Name = "btnFilterSongs";
            btnFilterSongs.UseVisualStyleBackColor = false;
            btnFilterSongs.Click += btnFilterSongs_Click;
            // 
            // listViewAllSongs
            // 
            resources.ApplyResources(listViewAllSongs, "listViewAllSongs");
            listViewAllSongs.BackColor = Color.FromArgb(35, 35, 35);
            listViewAllSongs.ForeColor = Color.White;
            listViewAllSongs.FullRowSelect = true;
            listViewAllSongs.LargeImageList = imageListSongs;
            listViewAllSongs.MultiSelect = false;
            listViewAllSongs.Name = "listViewAllSongs";
            listViewAllSongs.OwnerDraw = true;
            listViewAllSongs.TileSize = new Size(300, 76);
            listViewAllSongs.UseCompatibleStateImageBehavior = false;
            listViewAllSongs.View = View.Tile;
            listViewAllSongs.DrawItem += listViewAllSongs_DrawItem;
            listViewAllSongs.SelectedIndexChanged += listViewAllSongs_SelectedIndexChanged;
            // 
            // btnAddSong
            // 
            btnAddSong.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnAddSong, "btnAddSong");
            btnAddSong.Name = "btnAddSong";
            btnAddSong.UseVisualStyleBackColor = false;
            btnAddSong.Click += btnAddSong_Click;
            // 
            // btnDeleteSong
            // 
            btnDeleteSong.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnDeleteSong, "btnDeleteSong");
            btnDeleteSong.Name = "btnDeleteSong";
            btnDeleteSong.UseVisualStyleBackColor = false;
            btnDeleteSong.Click += btnDeleteSong_Click;
            // 
            // btnEditSong
            // 
            btnEditSong.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnEditSong, "btnEditSong");
            btnEditSong.Name = "btnEditSong";
            btnEditSong.UseVisualStyleBackColor = false;
            btnEditSong.Click += btnEditSong_Click;
            // 
            // listViewSongAlbums
            // 
            resources.ApplyResources(listViewSongAlbums, "listViewSongAlbums");
            listViewSongAlbums.BackColor = Color.FromArgb(35, 35, 35);
            listViewSongAlbums.ForeColor = Color.White;
            listViewSongAlbums.FullRowSelect = true;
            listViewSongAlbums.LargeImageList = imageListAlbums;
            listViewSongAlbums.MultiSelect = false;
            listViewSongAlbums.Name = "listViewSongAlbums";
            listViewSongAlbums.OwnerDraw = true;
            listViewSongAlbums.TileSize = new Size(300, 76);
            listViewSongAlbums.UseCompatibleStateImageBehavior = false;
            listViewSongAlbums.View = View.Tile;
            listViewSongAlbums.DrawItem += listViewSongAlbums_DrawItem;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(txtArtistFilter);
            splitContainer1.Panel1.Controls.Add(btnClearArtistsFilters);
            splitContainer1.Panel1.Controls.Add(btnFilterArtists);
            splitContainer1.Panel1.Controls.Add(btnEditArtist);
            splitContainer1.Panel1.Controls.Add(listViewArtists);
            splitContainer1.Panel1.Controls.Add(btnDeleteArtist);
            splitContainer1.Panel1.Controls.Add(btnAddArtist);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(listViewArtistSongs);
            splitContainer1.Panel2.Controls.Add(label2);
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // txtArtistFilter
            // 
            txtArtistFilter.BackColor = Color.FromArgb(35, 35, 35);
            txtArtistFilter.ForeColor = Color.White;
            resources.ApplyResources(txtArtistFilter, "txtArtistFilter");
            txtArtistFilter.Name = "txtArtistFilter";
            // 
            // btnClearArtistsFilters
            // 
            btnClearArtistsFilters.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnClearArtistsFilters, "btnClearArtistsFilters");
            btnClearArtistsFilters.Name = "btnClearArtistsFilters";
            btnClearArtistsFilters.UseVisualStyleBackColor = false;
            btnClearArtistsFilters.Click += btnClearArtistsFilters_Click;
            // 
            // btnFilterArtists
            // 
            btnFilterArtists.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnFilterArtists, "btnFilterArtists");
            btnFilterArtists.Name = "btnFilterArtists";
            btnFilterArtists.UseVisualStyleBackColor = false;
            btnFilterArtists.Click += btnFilterArtists_Click;
            // 
            // btnEditArtist
            // 
            btnEditArtist.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnEditArtist, "btnEditArtist");
            btnEditArtist.Name = "btnEditArtist";
            btnEditArtist.UseVisualStyleBackColor = false;
            btnEditArtist.Click += btnEditArtist_Click;
            // 
            // listViewArtists
            // 
            resources.ApplyResources(listViewArtists, "listViewArtists");
            listViewArtists.BackColor = Color.FromArgb(35, 35, 35);
            listViewArtists.ForeColor = Color.White;
            listViewArtists.LargeImageList = imageListArtists;
            listViewArtists.MultiSelect = false;
            listViewArtists.Name = "listViewArtists";
            listViewArtists.OwnerDraw = true;
            listViewArtists.TileSize = new Size(300, 76);
            listViewArtists.UseCompatibleStateImageBehavior = false;
            listViewArtists.View = View.Tile;
            listViewArtists.DrawItem += listViewArtists_DrawItem;
            listViewArtists.SelectedIndexChanged += listViewArtists_SelectedIndexChanged;
            // 
            // imageListArtists
            // 
            imageListArtists.ColorDepth = ColorDepth.Depth32Bit;
            resources.ApplyResources(imageListArtists, "imageListArtists");
            imageListArtists.TransparentColor = Color.Transparent;
            // 
            // btnDeleteArtist
            // 
            btnDeleteArtist.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnDeleteArtist, "btnDeleteArtist");
            btnDeleteArtist.Name = "btnDeleteArtist";
            btnDeleteArtist.UseVisualStyleBackColor = false;
            btnDeleteArtist.Click += btnDeleteArtist_Click;
            // 
            // btnAddArtist
            // 
            btnAddArtist.BackColor = Color.FromArgb(35, 35, 35);
            resources.ApplyResources(btnAddArtist, "btnAddArtist");
            btnAddArtist.Name = "btnAddArtist";
            btnAddArtist.UseVisualStyleBackColor = false;
            btnAddArtist.Click += btnAddArtist_Click;
            // 
            // listViewArtistSongs
            // 
            resources.ApplyResources(listViewArtistSongs, "listViewArtistSongs");
            listViewArtistSongs.BackColor = Color.FromArgb(35, 35, 35);
            listViewArtistSongs.ForeColor = Color.White;
            listViewArtistSongs.LargeImageList = imageListSongs;
            listViewArtistSongs.MultiSelect = false;
            listViewArtistSongs.Name = "listViewArtistSongs";
            listViewArtistSongs.OwnerDraw = true;
            listViewArtistSongs.TileSize = new Size(300, 76);
            listViewArtistSongs.UseCompatibleStateImageBehavior = false;
            listViewArtistSongs.View = View.Tile;
            listViewArtistSongs.DrawItem += listViewArtistSongs_DrawItem;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // tabAlbums
            // 
            tabAlbums.BackColor = Color.FromArgb(30, 30, 30);
            tabAlbums.Controls.Add(splitContainer3);
            tabAlbums.Controls.Add(label1);
            tabAlbums.ForeColor = Color.White;
            resources.ApplyResources(tabAlbums, "tabAlbums");
            tabAlbums.Name = "tabAlbums";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // tabSongs
            // 
            tabSongs.BackColor = Color.FromArgb(30, 30, 30);
            tabSongs.Controls.Add(splitContainer2);
            tabSongs.ForeColor = Color.White;
            resources.ApplyResources(tabSongs, "tabSongs");
            tabSongs.Name = "tabSongs";
            // 
            // tabArtists
            // 
            tabArtists.BackColor = Color.FromArgb(30, 30, 30);
            tabArtists.Controls.Add(splitContainer1);
            tabArtists.ForeColor = Color.White;
            resources.ApplyResources(tabArtists, "tabArtists");
            tabArtists.Name = "tabArtists";
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabArtists);
            tabControlMain.Controls.Add(tabSongs);
            tabControlMain.Controls.Add(tabAlbums);
            resources.ApplyResources(tabControlMain, "tabControlMain");
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // imageListAlbumSongs
            // 
            imageListAlbumSongs.ColorDepth = ColorDepth.Depth32Bit;
            resources.ApplyResources(imageListAlbumSongs, "imageListAlbumSongs");
            imageListAlbumSongs.TransparentColor = Color.Transparent;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(tabControlMain);
            Name = "MainForm";
            Load += MainForm_Load;
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabAlbums.ResumeLayout(false);
            tabAlbums.PerformLayout();
            tabSongs.ResumeLayout(false);
            tabArtists.ResumeLayout(false);
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
        private ImageList imageListAlbumSongs;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Button btnFilterSongs;
        private Button btnClearFilters;
        private Label label4;
        private Button btnClearArtistsFilters;
        private Button btnFilterArtists;
        private Label label5;
        private TextBox txtArtistFilter;
        private Label label6;
        private TextBox txtAlbumFilter;
        private Button btnClearAlbumsFilter;
        private Button btnFilterAlbums;
    }
}
