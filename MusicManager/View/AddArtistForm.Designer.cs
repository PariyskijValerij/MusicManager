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
            label4 = new Label();
            txtLink = new TextBox();
            label2 = new Label();
            txtDescription = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxArtist).BeginInit();
            SuspendLayout();
            // 
            // txtArtistName
            // 
            txtArtistName.BackColor = Color.FromArgb(35, 35, 35);
            txtArtistName.ForeColor = Color.White;
            txtArtistName.Location = new Point(12, 33);
            txtArtistName.Name = "txtArtistName";
            txtArtistName.Size = new Size(156, 23);
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
            btnChooseImage.Size = new Size(156, 23);
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
            btnCancel.Click += btnCancel_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 216);
            label4.Name = "label4";
            label4.Size = new Size(39, 21);
            label4.TabIndex = 13;
            label4.Text = "Link";
            // 
            // txtLink
            // 
            txtLink.BackColor = Color.FromArgb(35, 35, 35);
            txtLink.ForeColor = Color.White;
            txtLink.Location = new Point(12, 241);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(349, 23);
            txtLink.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 15;
            label2.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(35, 35, 35);
            txtDescription.ForeColor = Color.White;
            txtDescription.Location = new Point(12, 77);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(156, 107);
            txtDescription.TabIndex = 14;
            // 
            // AddArtistForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(391, 319);
            Controls.Add(label2);
            Controls.Add(txtDescription);
            Controls.Add(label4);
            Controls.Add(txtLink);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnChooseImage);
            Controls.Add(pictureBoxArtist);
            Controls.Add(label1);
            Controls.Add(txtArtistName);
            ForeColor = Color.White;
            Name = "AddArtistForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddArtist";
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
        private Label label4;
        private TextBox txtLink;
        private Label label2;
        private TextBox txtDescription;
    }
}