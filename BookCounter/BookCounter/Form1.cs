using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const int MAX_BOOK = 100;
        private Book[] bookArray = new Book[MAX_BOOK]; 
        private void buttonSave_Click(object sender, EventArgs e)
        {
            bookArray[Book.counter] = new Book(textBoxName.Text, textBoxAuthor.Text);
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            textBoxAll.Clear();
            for (int i = 1; i < Book.counter; i++)
            textBoxAll.AppendText(bookArray[i].Name + " @ " + bookArray[i].Author + " - " + bookArray[i].Number + "\r\n");           
        }
    }
}
public class Book
{
    public static int counter = 1;
    public string Name { get; set; }
    public string Author { get; set; }
    public int Number { get; set; } = counter;

    public Book(string name, string author)
    {
        Name = name;
        Author = author;
        counter++;
    }
    public Book()
    {
        counter++;
        Number = counter;
    }
}