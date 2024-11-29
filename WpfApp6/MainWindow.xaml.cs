using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32; // для использования OpenFileDialog
using System.IO;
using System.Windows.Controls;

namespace WpfApp6;

public partial class MainWindow : Window
{
    //TODO:изменение шрифта, размер шрифта, жирный курсив подчеркнутый,выравнивание,и чтобы весь текст был на весь лист без колонок
    //TODO: и изменения применялись как в ворде то есть к выделенному тексту
    
    private string selectedFilePath;

    public MainWindow()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// Открытие и изменение файла
    /// </summary>
    private void FileOpenButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            selectedFilePath = openFileDialog.FileName;
            try
            {
                // Чтение содержимого файла
                string fileContent = File.ReadAllText(selectedFilePath, Encoding.UTF8);
                // Отображение содержимого в TextBox
                FileContentTextBox.Text = fileContent;
                MessageBox.Show($"Выбран файл: {selectedFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
            }
        }
    } 
    /// <summary>
    /// Сохранения изменения файла 
    /// </summary>
    private void SaveFileButton_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(selectedFilePath))
        {
            try
            {
                // Сохранение изменений в файл
                File.WriteAllText(selectedFilePath, FileContentTextBox.Text);
                MessageBox.Show("Изменения сохранены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show("Нет открытого файла для сохранения.");
        }
    } 
    /// <summary>
    /// Печать и сохранение в PDF файл 
    /// </summary>
    private void SealFile_Click(object sender, RoutedEventArgs e)
    {
        PrintDialog printDialog = new PrintDialog();

        if (printDialog.ShowDialog() == true)
        {
            FlowDocument flowDocument = new FlowDocument(new Paragraph(new Run(FileContentTextBox.Text)));
            IDocumentPaginatorSource idpSource = flowDocument;
            printDialog.PrintDocument(idpSource.DocumentPaginator, "Printing Document");
        }
    }
    /// <summary>
    /// Шрифты
    /// </summary>
    private void Font_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (RichTextBox.Selection != null)
        {
            RichTextBox.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, ((ComboBoxItem)Font.SelectedItem).Content);
        }
    }
    /// <summary>
    /// Размер шрифта
    /// </summary>
    private void FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (RichTextBox.Selection != null)
        {
            RichTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, Convert.ToDouble(((ComboBoxItem)FontSize.SelectedItem).Content));
        }
    }
    /// <summary>
    /// жирный шрифт
    /// </summary>
    private void BoldButton_Click(object sender, RoutedEventArgs e)
    {
        
    }
    /// <summary>
    /// курсивный шрифт
    /// </summary>
    private void ItalicButton_Click(object sender, RoutedEventArgs e)
    {
        
    }
    /// <summary>
    /// подчеркунтый шрифт
    /// </summary>
    private void UnderlineButton_Click(object sender, RoutedEventArgs e)
    {
        
    }
    /// <summary>
    /// выравнивание по левому краю 
    /// </summary>
    private void LeftButton_Click(object sender, RoutedEventArgs e)
    {

    }
    /// <summary>
    /// выравнивание по центру
    /// </summary>
    private void CenterButton_Click(object sender, RoutedEventArgs e)
    {
        
    }
    /// <summary>
    /// выравнивание по правому краю
    /// </summary>
    private void RightButton_Click(object sender, RoutedEventArgs e)
    {
        
    }
}
