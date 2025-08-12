
namespace NoteTakingApplication
{
    partial class NoteTaker
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
            noteBox = new TextBox();
            titleBox = new TextBox();
            Title = new Label();
            Notes = new Label();
            previousNotes = new DataGridView();
            loadButton = new Button();
            deleteButton = new Button();
            saveButton = new Button();
            newNoteButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)previousNotes).BeginInit();
            SuspendLayout();
            // 
            // noteBox
            // 
            noteBox.Location = new Point(504, 81);
            noteBox.Multiline = true;
            noteBox.Name = "noteBox";
            noteBox.Size = new Size(471, 514);
            noteBox.TabIndex = 0;
            // 
            // titleBox
            // 
            titleBox.Location = new Point(504, 29);
            titleBox.Name = "titleBox";
            titleBox.Size = new Size(471, 23);
            titleBox.TabIndex = 1;
            // 
            // Title
            // 
            Title.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Title.Location = new Point(504, 5);
            Title.Name = "Title";
            Title.Size = new Size(471, 21);
            Title.TabIndex = 2;
            Title.Text = "Title:";
            Title.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Notes
            // 
            Notes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Notes.Location = new Point(504, 55);
            Notes.Name = "Notes";
            Notes.Size = new Size(471, 23);
            Notes.TabIndex = 3;
            Notes.Text = "Notes:";
            Notes.TextAlign = ContentAlignment.MiddleLeft;
            Notes.Click += Notes_Click;
            // 
            // previousNotes
            // 
            previousNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            previousNotes.BackgroundColor = Color.White;
            previousNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            previousNotes.Location = new Point(12, 29);
            previousNotes.Name = "previousNotes";
            previousNotes.Size = new Size(486, 448);
            previousNotes.TabIndex = 4;
            
            // 
            // loadButton
            // 
            loadButton.BackColor = Color.White;
            loadButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loadButton.Location = new Point(301, 483);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(197, 53);
            loadButton.TabIndex = 5;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = false;
            loadButton.Click += loadButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.White;
            deleteButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteButton.Location = new Point(301, 542);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(197, 53);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.White;
            saveButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveButton.Location = new Point(12, 542);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(283, 53);
            saveButton.TabIndex = 7;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // newNoteButton
            // 
            newNoteButton.BackColor = Color.White;
            newNoteButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            newNoteButton.Location = new Point(12, 483);
            newNoteButton.Name = "newNoteButton";
            newNoteButton.Size = new Size(283, 53);
            newNoteButton.TabIndex = 8;
            newNoteButton.Text = "New Note";
            newNoteButton.UseVisualStyleBackColor = false;
            newNoteButton.Click += newNoteButton_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 5);
            label1.Name = "label1";
            label1.Size = new Size(486, 21);
            label1.TabIndex = 9;
            label1.Text = "Previous Notes:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NoteTaker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(987, 607);
            Controls.Add(label1);
            Controls.Add(newNoteButton);
            Controls.Add(saveButton);
            Controls.Add(deleteButton);
            Controls.Add(loadButton);
            Controls.Add(previousNotes);
            Controls.Add(Notes);
            Controls.Add(Title);
            Controls.Add(titleBox);
            Controls.Add(noteBox);
            Name = "NoteTaker";
            Text = "NoteTaker";
            Load += NoteTaker_Load;
            ((System.ComponentModel.ISupportInitialize)previousNotes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion

        private TextBox noteBox;
        private TextBox titleBox;
        private Label Title;
        private Label Notes;
        private DataGridView previousNotes;
        private Button loadButton;
        private Button deleteButton;
        private Button saveButton;
        private Button newNoteButton;
        private Label label1;
    }
}
