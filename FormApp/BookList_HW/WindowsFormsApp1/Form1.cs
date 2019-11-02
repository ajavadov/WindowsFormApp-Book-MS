using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = booksList.SelectedIndex;
            Object obj = booksList.Items[index];
            Book book = (Book)obj;
            textBoxName.Text = book.Name;
            textBoxAuthor.Text = book.Author;
            textBoxGenre.Text = book.Genre;
            textBoxPage.Text =book.Pages.ToString();
            IsNew.Checked = book.isNew;
            numInStock.Value = book.inStock;

        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Name = textBoxName.Text;
            book.Author = textBoxAuthor.Text;
            book.Genre = textBoxGenre.Text;
            book.Pages = int.Parse(textBoxPage.Text);
            book.isNew = IsNew.Checked;
            book.inStock = numInStock.Value;
            textBoxName.Clear();
            textBoxAuthor.Clear();
            textBoxGenre.Clear();
            textBoxPage.Clear();
            numInStock.Value = 0;
            IsNew.Checked = false;
            booksList.Items.Add(book);


        }
        string fileName = "myBooks.dat";

        private void btnSave_Click(object sender, EventArgs e)
        {
            List < Book > books= new List<Book>();

            foreach (Book item in booksList.Items)
            {
                books.Add(item);
            }

            

            Stream stream = File.OpenWrite(fileName);

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(stream, books);

            stream.Close();
            stream.Dispose();


        }

       

        private void btnFetch_Click_1(object sender, EventArgs e)
        {
            Stream stream = File.OpenRead(fileName);

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            List<Book> books =(List <Book>)binaryFormatter.Deserialize(stream);

            booksList.Items.AddRange(books.ToArray());

            stream.Close();
            stream.Dispose();
        }
    }
}
