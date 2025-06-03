namespace MusicManager
{
    partial class AddAlbumForm
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
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            pictureBoxImage = new PictureBox();
            btnChooseImage = new Button();
            btnCancel = new Button();
            btnOK = new Button();
            comboArtist = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(11, 16);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.FromArgb(35, 35, 35);
            txtTitle.ForeColor = Color.White;
            txtTitle.Location = new Point(12, 40);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(148, 23);
            txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 66);
            label2.Name = "label2";
            label2.Size = new Size(47, 21);
            label2.TabIndex = 2;
            label2.Text = "Artist";
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Location = new Point(190, 40);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(180, 180);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImage.TabIndex = 4;
            pictureBoxImage.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.BackColor = Color.FromArgb(35, 35, 35);
            btnChooseImage.Location = new Point(11, 197);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(149, 23);
            btnChooseImage.TabIndex = 5;
            btnChooseImage.Text = "Chose image";
            btnChooseImage.UseVisualStyleBackColor = false;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(35, 35, 35);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(85, 284);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(35, 35, 35);
            btnOK.Location = new Point(190, 284);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 11;
            btnOK.Text = "Confirm";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // comboArtist
            // 
            comboArtist.BackColor = Color.FromArgb(35, 35, 35);
            comboArtist.DropDownStyle = ComboBoxStyle.DropDownList;
            comboArtist.ForeColor = Color.White;
            comboArtist.FormattingEnabled = true;
            comboArtist.Location = new Point(12, 90);
            comboArtist.Name = "comboArtist";
            comboArtist.Size = new Size(148, 23);
            comboArtist.TabIndex = 12;
            // 
            // AddAlbumForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(391, 319);
            Controls.Add(comboArtist);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Controls.Add(btnChooseImage);
            Controls.Add(pictureBoxImage);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            ForeColor = Color.White;
            Name = "AddAlbumForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddAlbum";
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private PictureBox pictureBoxImage;
        private Button btnChooseImage;
        private Button btnCancel;
        private Button btnOK;
        private ComboBox comboArtist;
    }
}