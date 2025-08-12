using System.Data;
using System.Text;

namespace NoteTakingApplication
{
    public partial class NoteTaker : Form
    {
        // Path to the file where notes are saved/loaded
        private string notesFilePath = "notes.txt";

        // DataTable to hold notes, with columns for Title and Note content
        DataTable notes = new DataTable();

        // Flag to indicate if a note is currently being edited
        bool editing = false;

        public NoteTaker()
        {
            InitializeComponent(); // Initialize form components
        }

        // Helper method to escape text for CSV format (handles commas and quotes)
        private string EscapeForCsv(string field)
        {
            if (field.Contains(",") || field.Contains("\""))
            {
                // Double any internal quotes
                field = field.Replace("\"", "\"\"");
                // Wrap in quotes
                return $"\"{field}\"";
            }
            return field;
        }

        // Helper method to parse CSV line into individual fields
        private List<string> ParseCsvLine(string line)
        {
            List<string> fields = new List<string>();
            bool inQuotes = false; // Track if currently inside quotes
            StringBuilder field = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '\"')
                {
                    // Handle escaped quotes
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                    {
                        field.Append('\"'); // Add quote
                        i++; // Skip next quote
                    }
                    else
                    {
                        inQuotes = !inQuotes; // Toggle inQuotes
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    // Comma outside quotes ends the field
                    fields.Add(field.ToString());
                    field.Clear();
                }
                else
                {
                    // Append character to current field
                    field.Append(c);
                }
            }
            // Add the last field after loop
            fields.Add(field.ToString());
            return fields;
        }

        // Save current notes to a text file for data persistence
        private void SaveNotesToFile()
        {
            if (notes == null) return; // No notes to save

            using (StreamWriter sw = new StreamWriter(notesFilePath))
            {
                // Loop through all note rows
                foreach (DataRow row in notes.Rows)
                {
                    // Skip the placeholder row
                    if (row[0].ToString().StartsWith("Select")) continue;

                    // Escape content and write as CSV line
                    string line = $"{EscapeForCsv(row["Title"].ToString())},{EscapeForCsv(row["Note"].ToString())}";
                    sw.WriteLine(line);
                }
            }
        }

        // Load notes from the text file during startup
        private void LoadNotesFromFile()
        {
            if (!File.Exists(notesFilePath))
                return; // No file to load

            notes.Rows.Clear(); // Clear existing notes before loading

            using (StreamReader sr = new StreamReader(notesFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var fields = ParseCsvLine(line);
                    if (fields.Count >= 2)
                    {
                        // Add each parsed note to the DataTable
                        notes.Rows.Add(fields[0], fields[1]);
                    }
                }
            }

            // If no real notes loaded, add placeholder message
            if (notes.Rows.Count == 0)
            {
                AddPlaceholderRow();
            }
        }

        // Utility method to display the placeholder message in the notes list
        private void AddPlaceholderRow()
        {
            notes.Rows.Clear(); // Clear existing rows
            notes.Rows.Add("Select a note or create a new one", ""); // Add placeholder
        }

        // Event: Form loads
        private void NoteTaker_Load(object sender, EventArgs e)
        {
            // Set up columns for the notes DataTable
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            // Load existing notes from file
            LoadNotesFromFile();

            // Bind DataTable to DataGridView
            previousNotes.DataSource = notes;

            // Make DataGridView read-only to prevent direct editing
            previousNotes.ReadOnly = true;
        }

        // Event: When the "Notes" label is clicked (resets input fields)
        private void Notes_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }

        // Event: Load the selected note into input fields for editing
        private void loadButton_Click(object sender, EventArgs e)
        {
            // Get index of selected row
            int rowIndex = previousNotes.CurrentCell.RowIndex;

            // Check index validity
            if (rowIndex >= 0 && rowIndex < notes.Rows.Count)
            {
                // Load note title and content into text boxes
                titleBox.Text = notes.Rows[rowIndex].ItemArray[0].ToString();
                noteBox.Text = notes.Rows[rowIndex].ItemArray[1].ToString();

                // Set editing mode to true so save operation updates this note
                editing = true;
            }
        }

        // Event: Delete the currently selected note
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete the selected row
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();

                // If all notes are deleted, show the placeholder message
                if (notes.Rows.Count == 0)
                {
                    AddPlaceholderRow();
                }
            }
            catch (Exception)
            {
                // Handle invalid delete attempts
                Console.WriteLine("Not a valid note to delete");
            }
        }

        // Event: Save the note from input fields to the list and file
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Initialize the notes DataTable if null
            if (notes == null)
            {
                notes = new DataTable();
                notes.Columns.Add("Title");
                notes.Columns.Add("Note");
            }

            // Remove placeholder if present before adding a real note
            if (notes.Rows.Count == 1 && notes.Rows[0][0].ToString().StartsWith("Select"))
            {
                notes.Rows.Clear();
            }

            // Save edits to an existing note
            if (editing && previousNotes.CurrentCell != null && previousNotes.CurrentCell.RowIndex >= 0 && previousNotes.CurrentCell.RowIndex < notes.Rows.Count)
            {
                int rowIndex = previousNotes.CurrentCell.RowIndex;
                notes.Rows[rowIndex]["Title"] = titleBox.Text;
                notes.Rows[rowIndex]["Note"] = noteBox.Text;
            }
            else
            {
                // Add a new note
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }

            // Persist notes to file
            SaveNotesToFile();

            // Show placeholder if no notes exist
            if (notes.Rows.Count == 0)
            {
                AddPlaceholderRow();
            }

            // Clear input fields and reset editing flag
            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;
        }

        // Event: Double-click on a note to load it into input fields for editing
        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (notes.Rows.Count > 0 && previousNotes.CurrentCell != null)
            {
                int rowIndex = previousNotes.CurrentCell.RowIndex;
                if (rowIndex >= 0 && rowIndex < notes.Rows.Count)
                {
                    // Populate text boxes with selected note
                    titleBox.Text = notes.Rows[rowIndex].ItemArray[0].ToString();
                    noteBox.Text = notes.Rows[rowIndex].ItemArray[1].ToString();

                    // Set editing mode so save updates this note
                    editing = true;
                }
            }
        }

        // Event: Start a new note by clearing input fields and showing placeholder
        private void newNoteButton_Click(object sender, EventArgs e)
        {
            // Clear only the input fields for a fresh note
            titleBox.Text = "";
            noteBox.Text = "";
            // Reset editing mode
            editing = false;
        }
    }
}