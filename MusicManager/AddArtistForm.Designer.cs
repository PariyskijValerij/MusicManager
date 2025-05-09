namespace MusicManager
{
    partial class AddArtistForm
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
            txtArtistName = new TextBox();
            label1 = new Label();
            pictureBoxArtist = new PictureBox();
            btnChooseImage = new Button();
            btnOK = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArtist).BeginInit();
            SuspendLayout();
            // 
            // txtArtistName
            // 
            txtArtistName.BackColor = Color.FromArgb(35, 35, 35);
            txtArtistName.ForeColor = Color.White;
            txtArtistName.Location = new Point(12, 33);
            txtArtistName.Name = "txtArtistName";
            txtArtistName.Size = new Size(109, 23);
            txtArtistName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // pictureBoxArtist
            // 
            pictureBoxArtist.Location = new Point(181, 33);
            pictureBoxArtist.Name = "pictureBoxArtist";
            pictureBoxArtist.Size = new Size(180, 180);
            pictureBoxArtist.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxArtist.TabIndex = 2;
            pictureBoxArtist.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.BackColor = Color.FromArgb(35, 35, 35);
            btnChooseImage.Location = new Point(12, 190);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(109, 23);
            btnChooseImage.TabIndex = 3;
            btnChooseImage.Text = "Chose image";
            btnChooseImage.UseVisualStyleBackColor = false;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(35, 35, 35);
            btnOK.Location = new Point(203, 284);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 4;
            btnOK.Text = "Confirm";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(35, 35, 35);
            btnCancel.Location = new Point(93, 284);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // AddArtistForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(391, 319);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnChooseImage);
            Controls.Add(pictureBoxArtist);
            Controls.Add(label1);
            Controls.Add(txtArtistName);
            ForeColor = Color.White;
            Name = "AddArtistForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddArtistForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxArtist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtArtistName;
        private Label label1;
        private PictureBox pictureBoxArtist;
        private Button btnChooseImage;
        private Button btnOK;
        private Button btnCancel;
    }
}