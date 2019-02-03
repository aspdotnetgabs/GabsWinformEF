using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace GabsWinformEF
{
    public partial class FormTransactions : Form
    {
        public FormTransactions()
        {
            InitializeComponent();
        }

        private void FormTransactions_Load(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("transaction.csv"))
            {
                txtTransaction.Text = reader.ReadToEnd();
            }

            // What is CSV? https://en.wikipedia.org/wiki/Comma-separated_values
            ReadCsvToDataGrid("transaction.csv", '|'); // Can be pipe| or comma,
        }

        private void ReadCsvToDataGrid(string filename, char delimiter)
        {
            using (var reader = new StreamReader(filename))
            {
                string lineHeader = reader.ReadLine();
                string lineItem = string.Empty;

                do
                {
                    lineItem = reader.ReadLine();

                    if (!string.IsNullOrEmpty(lineItem) && lineItem != lineHeader)
                    {
                        // https://blogs.msdn.microsoft.com/csharpfaq/2004/03/12/what-character-escape-sequences-are-available/
                        lineItem = lineItem.Replace("\"", string.Empty);
                        // https://stackoverflow.com/questions/8928601/how-can-i-split-a-string-with-a-string-delimiter
                        string[] column = lineItem.Split(delimiter); 
                        var row = new DgvItem();
                        row.ItemName = column[0];
                        row.Quantity = column[1];

                        // Catch errors when string is empty and cannot be parse to double type
                        try
                        {
                            https://stackoverflow.com/questions/5168592/force-a-string-to-2-decimal-places
                            row.Price = string.Format("{0:f2}", double.Parse(column[2]));
                        }
                        catch
                        {
                            // Just do nothing
                        }
                        try
                        {
                            row.Amount = string.Format("{0:f2}", double.Parse(column[3]));
                        }
                        catch { }

                        bindingSource1.List.Add(row);
                    }
                }
                while (!string.IsNullOrEmpty(lineItem));

            }
        }
    }

    class DgvItem
    {
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
    }
}
