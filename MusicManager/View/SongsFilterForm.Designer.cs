namespace MusicManager
{
    partial class SongsFilterForm
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
            textTitle = new TextBox();
            comboArtist = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtYearMin = new TextBox();
            label4 = new Label();
            txtYearMax = new TextBox();
            lblError = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            SuspendLayout();
            // 
            // textTitle
            // 
            textTitle.BackColor = Color.FromArgb(35, 35, 35);
            textTitle.ForeColor = Color.White;
            textTitle.Location = new Point(12, 30);
            textTitle.Name = "textTitle";
            textTitle.Size = new Size(210, 23);
            textTitle.TabIndex = 0;
            // 
            // comboArtist
            // 
            comboArtist.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboArtist.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboArtist.BackColor = Color.FromArgb(35, 35, 35);
            comboArtist.ForeColor = Color.White;
            comboArtist.FormattingEnabled = true;
            comboArtist.Location = new Point(12, 80);
            comboArtist.Name = "comboArtist";
            comboArtist.Size = new Size(121, 23);
            comboArtist.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 2;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(47, 21);
            label2.TabIndex = 3;
            label2.Text = "Artist";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 106);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 4;
            label3.Text = "Min Year";
            // 
            // txtYearMin
            // 
            txtYearMin.BackColor = Color.FromArgb(35, 35, 35);
            txtYearMin.ForeColor = Color.White;
            txtYearMin.Location = new Point(12, 130);
            txtYearMin.Name = "txtYearMin";
            txtYearMin.Size = new Size(210, 23);
            txtYearMin.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 156);
            label4.Name = "label4";
            label4.Size = new Size(73, 21);
            label4.TabIndex = 6;
            label4.Text = "Max Year";
            // 
            // txtYearMax
            // 
            txtYearMax.BackColor = Color.FromArgb(35, 35, 35);
            txtYearMax.ForeColor = Color.White;
            txtYearMax.Location = new Point(12, 180);
            txtYearMax.Name = "txtYearMax";
            txtYearMax.Size = new Size(210, 23);
            txtYearMax.TabIndex = 7;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 12F);
            lblError.Location = new Point(102, 284);
            lblError.Name = "lblError";
            lblError.Size = new Size(115, 21);
            lblError.TabIndex = 8;
            lblError.Text = "Nothing Found";
            lblError.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(35, 35, 35);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(223, 284);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(35, 35, 35);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(304, 284);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 14;
            btnOK.Text = "Confirm";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // SongsFilterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(391, 319);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lblError);
            Controls.Add(txtYearMax);
            Controls.Add(label4);
            Controls.Add(txtYearMin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboArtist);
            Controls.Add(textTitle);
            ForeColor = Color.White;
            MaximumSize = new Size(407, 358);
            MinimumSize = new Size(407, 358);
            Name = "SongsFilterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SongsFilterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textTitle;
        private ComboBox comboArtist;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtYearMin;
        private Label label4;
        private TextBox txtYearMax;
        private Label lblError;
        private Button btnCancel;
        private Button btnOK;
    }
}