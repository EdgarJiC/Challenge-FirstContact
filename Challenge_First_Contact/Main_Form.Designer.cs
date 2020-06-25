namespace Challenge_First_Contact
{
    partial class Main_Form
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
            this.Main_Grid = new System.Windows.Forms.DataGridView();
            this.PicAdd = new System.Windows.Forms.PictureBox();
            this.PicRemove = new System.Windows.Forms.PictureBox();
            this.PicEdit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_Grid
            // 
            this.Main_Grid.AllowUserToAddRows = false;
            this.Main_Grid.AllowUserToDeleteRows = false;
            this.Main_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Main_Grid.Location = new System.Drawing.Point(60, 146);
            this.Main_Grid.Name = "Main_Grid";
            this.Main_Grid.ReadOnly = true;
            this.Main_Grid.RowHeadersVisible = false;
            this.Main_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Main_Grid.Size = new System.Drawing.Size(972, 336);
            this.Main_Grid.TabIndex = 0;
            // 
            // PicAdd
            // 
            this.PicAdd.BackColor = System.Drawing.Color.Transparent;
            this.PicAdd.Image = global::Challenge_First_Contact.Properties.Resources.View_Add2;
            this.PicAdd.Location = new System.Drawing.Point(60, 105);
            this.PicAdd.Name = "PicAdd";
            this.PicAdd.Size = new System.Drawing.Size(30, 35);
            this.PicAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicAdd.TabIndex = 1;
            this.PicAdd.TabStop = false;
            this.PicAdd.Click += new System.EventHandler(this.PicAdd_Click);
            // 
            // PicRemove
            // 
            this.PicRemove.BackColor = System.Drawing.Color.Transparent;
            this.PicRemove.Image = global::Challenge_First_Contact.Properties.Resources.View_Remove;
            this.PicRemove.Location = new System.Drawing.Point(97, 105);
            this.PicRemove.Name = "PicRemove";
            this.PicRemove.Size = new System.Drawing.Size(30, 35);
            this.PicRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicRemove.TabIndex = 2;
            this.PicRemove.TabStop = false;
            this.PicRemove.Click += new System.EventHandler(this.PicAdd_Click);
            // 
            // PicEdit
            // 
            this.PicEdit.BackColor = System.Drawing.Color.Transparent;
            this.PicEdit.Image = global::Challenge_First_Contact.Properties.Resources.View_edit;
            this.PicEdit.Location = new System.Drawing.Point(133, 105);
            this.PicEdit.Name = "PicEdit";
            this.PicEdit.Size = new System.Drawing.Size(30, 35);
            this.PicEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicEdit.TabIndex = 3;
            this.PicEdit.TabStop = false;
            this.PicEdit.Click += new System.EventHandler(this.PicAdd_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1084, 607);
            this.Controls.Add(this.PicEdit);
            this.Controls.Add(this.PicRemove);
            this.Controls.Add(this.PicAdd);
            this.Controls.Add(this.Main_Grid);
            this.MaximizeBox = false;
            this.Name = "Main_Form";
            this.Text = "Control de inventarios";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Main_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Main_Grid;
        private System.Windows.Forms.PictureBox PicAdd;
        private System.Windows.Forms.PictureBox PicRemove;
        private System.Windows.Forms.PictureBox PicEdit;
    }
}

