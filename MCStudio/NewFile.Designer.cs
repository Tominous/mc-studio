namespace MCStudio
{
    partial class NewFile
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
            this.cmlJson = new MCStudio.CommandLink();
            this.cmlFunction = new MCStudio.CommandLink();
            this.cmlCancel = new MCStudio.CommandLink();
            this.SuspendLayout();
            // 
            // cmlJson
            // 
            this.cmlJson.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmlJson.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmlJson.Location = new System.Drawing.Point(12, 12);
            this.cmlJson.Name = "cmlJson";
            this.cmlJson.Note = "Create a JSon or a mcmeta file";
            this.cmlJson.Size = new System.Drawing.Size(275, 50);
            this.cmlJson.TabIndex = 3;
            this.cmlJson.Text = "New JSON file";
            this.cmlJson.Click += new System.EventHandler(this.clJson_Click);
            // 
            // cmlFunction
            // 
            this.cmlFunction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmlFunction.Location = new System.Drawing.Point(12, 68);
            this.cmlFunction.Name = "cmlFunction";
            this.cmlFunction.Note = "Create a new Minecraft function file";
            this.cmlFunction.Size = new System.Drawing.Size(275, 50);
            this.cmlFunction.TabIndex = 4;
            this.cmlFunction.Text = "New function";
            this.cmlFunction.UseVisualStyleBackColor = true;
            this.cmlFunction.Click += new System.EventHandler(this.clFunction_Click);
            // 
            // cmlCancel
            // 
            this.cmlCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmlCancel.Location = new System.Drawing.Point(12, 156);
            this.cmlCancel.Name = "cmlCancel";
            this.cmlCancel.Size = new System.Drawing.Size(275, 50);
            this.cmlCancel.TabIndex = 5;
            this.cmlCancel.Text = "Cancel";
            this.cmlCancel.UseVisualStyleBackColor = true;
            this.cmlCancel.Click += new System.EventHandler(this.clCancel_Click);
            // 
            // NewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 218);
            this.ControlBox = false;
            this.Controls.Add(this.cmlCancel);
            this.Controls.Add(this.cmlFunction);
            this.Controls.Add(this.cmlJson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New file";
            this.ResumeLayout(false);

        }

        #endregion
        private CommandLink cmlJson;
        private CommandLink cmlFunction;
        private CommandLink cmlCancel;
    }
}