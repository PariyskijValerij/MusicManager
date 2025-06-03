namespace MusicManager
{
    partial class AddSongForm
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
            comboArtist = new ComboBox();
            label3 = new Label();
            numericYear = new NumericUpDown();
            pictureBoxSong = new PictureBox();
            btnChooseImage = new Button();
            btnOK = new Button();
            btnCancel = new Button();
            txtLink = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSong).BeginInit();
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
            label2.Location = new Point(10, 65);
            label2.Name = "label2";
            label2.Size = new Size(47, 21);
            label2.TabIndex = 2;
            label2.Text = "Artist";
            // 
            // comboArtist
            // 
            comboArtist.BackColor = Color.FromArgb(35, 35, 35);
            comboArtist.DropDownStyle = ComboBoxStyle.DropDownList;
            comboArtist.ForeColor = Color.White;
            comboArtist.FormattingEnabled = true;
            comboArtist.Location = new Point(12, 89);
            comboArtist.Name = "comboArtist";
            comboArtist.Size = new Size(148, 23);
            comboArtist.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(10, 121);
            label3.Name = "label3";
            label3.Size = new Size(40, 21);
            label3.TabIndex = 4;
            label3.Text = "Year";
            // 
            // numericYear
            // 
            numericYear.BackColor = Color.FromArgb(35, 35, 35);
            numericYear.Font = new Font("Segoe UI", 9F);
            numericYear.ForeColor = Color.White;
            numericYear.Location = new Point(11, 145);
            numericYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numericYear.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            numericYear.Name = "numericYear";
            numericYear.Size = new Size(148, 23);
            numericYear.TabIndex = 5;
            numericYear.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // pictureBoxSong
            // 
            pictureBoxSong.Location = new Point(190, 40);
            pictureBoxSong.Name = "pictureBoxSong";
            pictureBoxSong.Size = new Size(180, 180);
            pictureBoxSong.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSong.TabIndex = 6;
            pictureBoxSong.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.BackColor = Color.FromArgb(35, 35, 35);
            btnChooseImage.Location = new Point(10, 188);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(149, 23);
            btnChooseImage.TabIndex = 7;
            btnChooseImage.Text = "Chose image";
            btnChooseImage.UseVisualStyleBackColor = false;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(35, 35, 35);
            btnOK.Location = new Point(190, 284);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 8;
            btnOK.Text = "Confirm";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(35, 35, 35);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(85, 284);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // txtLink
            // 
            txtLink.BackColor = Color.FromArgb(35, 35, 35);
            txtLink.ForeColor = Color.White;
            txtLink.Location = new Point(12, 243);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(358, 23);
            txtLink.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 219);
            label4.Name = "label4";
            label4.Size = new Size(39, 21);
            label4.TabIndex = 11;
            label4.Text = "Link";
            // 
            // AddSongForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(391, 319);
            Controls.Add(label4);
            Controls.Add(txtLink);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnChooseImage);
            Controls.Add(pictureBoxSong);
            Controls.Add(numericYear);
            Controls.Add(label3);
            Controls.Add(comboArtist);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AddSongForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddSong";
            ((System.ComponentModel.ISupportInitialize)numericYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private ComboBox comboArtist;
        private Label label3;
        private NumericUpDown numericYear;
        private PictureBox pictureBoxSong;
        private Button btnChooseImage;
        private Button btnOK;
        private Button btnCancel;
        private TextBox txtLink;
        private Label label4;
    }
}